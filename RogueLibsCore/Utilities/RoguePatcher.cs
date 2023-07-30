using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Diagnostics;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a simplified Harmony patcher.</para>
    /// </summary>
    public class RoguePatcher
    {
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="RoguePatcher"/> class with the specified <paramref name="callerPlugin"/>.</para>
        /// </summary>
        /// <param name="callerPlugin">The instance of <see cref="BaseUnityPlugin"/> responsible for the patches.</param>
        // ReSharper disable once ConditionalAccessQualifierIsNonNullableAccordingToAPIContract
        public RoguePatcher(BaseUnityPlugin callerPlugin) : this(callerPlugin, callerPlugin?.GetType()!) { }
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="RoguePatcher"/> class with the specified <paramref name="callerPlugin"/>.</para>
        /// </summary>
        /// <param name="callerPlugin">The instance of <see cref="BaseUnityPlugin"/> responsible for the patches.</param>
        /// <param name="typeWithPatches">The type containing patch methods.</param>
        public RoguePatcher(BaseUnityPlugin callerPlugin, Type typeWithPatches)
        {
            if (callerPlugin is null) throw new ArgumentNullException(nameof(callerPlugin));
            log = (ManualLogSource)loggerProperty.GetValue(callerPlugin);
            harmony = new Harmony(callerPlugin.Info.Metadata.GUID);
            _typeWithPatches = typeWithPatches ?? throw new ArgumentNullException(nameof(typeWithPatches));
            Results = new ReadOnlyCollection<PatchRecord>(results);
        }

        private static readonly PropertyInfo loggerProperty = AccessTools.Property(typeof(BaseUnityPlugin), "Logger");
        private readonly Harmony harmony;
        /// <summary>
        ///   <para>Returns the underling <see cref="Harmony"/> instance, used by the patcher.</para>
        /// </summary>
        /// <returns>The underlying <see cref="Harmony"/> instance, used by the patcher.</returns>
        public Harmony GetHarmony() => harmony;
        private readonly ManualLogSource log;
        private Type _typeWithPatches;
        /// <summary>
        ///   <para>Gets or sets the type containing the patch methods.</para>
        /// </summary>
        public Type TypeWithPatches
        {
            get => _typeWithPatches;
            set => _typeWithPatches = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        ///   <para>Gets or sets whether the patcher should record the patches.</para>
        /// </summary>
        public bool EnableStopwatch { get; set; }
        private readonly List<PatchRecord> results = new List<PatchRecord>();
        /// <summary>
        ///   <para>Gets a read-only collection of the recorded patches.</para>
        /// </summary>
        public ReadOnlyCollection<PatchRecord> Results { get; }
        /// <summary>
        ///   <para>Clears the recorded patches.</para>
        /// </summary>
        public void ClearResults() => results.Clear();
        /// <summary>
        ///   <para>Logs the recorded patches.</para>
        /// </summary>
        public void LogResults()
        {
            int failed = results.Count(static r => !r.Success);
            log.LogDebug($"Measured {results.Count} patches{(failed > 0 ? $" ({failed} failed)" : string.Empty)}:");
            TimeSpan total = TimeSpan.Zero;
            foreach (PatchRecord time in results)
            {
                string text = $"| {time.PatchType,10}" +
                    $" | {time.Target?.DeclaringType?.Name + "." + time.Target?.Name,-50}" +
                    $" | {time.Elapsed.TotalMilliseconds,4:####}ms |";

                if (time.Success)
                    log.LogDebug(text);
                else log.LogWarning(text);

                total += time.Elapsed;
            }
            log.LogDebug($"Total: {total.TotalMilliseconds,5:#####}ms");
        }
        /// <summary>
        ///   <para>Logs the recorded patches, that took more than the specified <paramref name="threshold"/> of milliseconds to complete.</para>
        /// </summary>
        /// <param name="threshold">The threshold, in milliseconds.</param>
        public void LogResults(int threshold)
        {
            int failed = results.Count(static r => !r.Success);
            int count = results.Count(r => r.Elapsed.TotalMilliseconds > threshold);
            log.LogDebug($"Measured {count} patches above {threshold}ms (from total {results.Count}){(failed > 0 ? $" ({failed} failed)" : string.Empty)}:");
            TimeSpan total = TimeSpan.Zero;
            TimeSpan totalThreshold = TimeSpan.Zero;
            foreach (PatchRecord time in results)
            {
                if (time.Elapsed.TotalMilliseconds > threshold)
                {
                    string text = $"| {time.PatchType,10}" +
                        $" | {time.Target?.DeclaringType?.Name + "." + time.Target?.Name,-50}" +
                        $" | {time.Elapsed.TotalMilliseconds,4:####}ms |";

                    if (time.Success)
                        log.LogDebug(text);
                    else log.LogWarning(text);

                    totalThreshold += time.Elapsed;
                }
                total += time.Elapsed;
            }
            log.LogDebug($"Total: {totalThreshold.TotalMilliseconds,5:#####}ms (from total {total.TotalMilliseconds,5:#####}ms)");
        }
        /// <summary>
        ///   <para>Sorts the recorded patches by their time in descending order.</para>
        /// </summary>
        public void SortResults() => results.Sort(static (a, b) => -a.Elapsed.CompareTo(b.Elapsed));

        private bool hasErrors;
        /// <summary>
        ///   <para>Determines whether any of the previous patches failed and resets the value.</para>
        /// </summary>
        /// <returns><see langword="true"/>, if any of the previous patches failed; otherwise, <see langword="false"/>.</returns>
        public bool AnyErrors()
        {
            bool any = hasErrors;
            hasErrors = false;
            return any;
        }

        private const BindingFlags All = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
        private static MethodInfo? FindMethod(Type type, string methodName, Type[]? parameterTypes)
        {
            if (parameterTypes is not null) return type.GetMethod(methodName, All, null, parameterTypes, null);

            MethodInfo? match = null;
            int maxParamCount = -1;

            foreach (MethodInfo method in type.GetMethods(All))
            {
                if (method.Name != methodName) continue;
                if (match is null) match = method;
                else
                {
                    if (maxParamCount == -1) maxParamCount = match.GetParameters().Length;
                    int paramCount = method.GetParameters().Length;
                    if (paramCount > maxParamCount) match = method;
                }
            }
            return match;
        }

        /// <summary>
        ///   <para>Prefix-patches the specified <paramref name="targetType"/>'s <paramref name="targetMethod"/>, optionally with the specified <paramref name="targetParameterTypes"/>, with a patch method called "&lt;<paramref name="targetType"/>&gt;_&lt;<paramref name="targetMethod"/>&gt;".</para>
        /// </summary>
        /// <param name="targetType">The target method's type.</param>
        /// <param name="targetMethod">The target method's name.</param>
        /// <param name="targetParameterTypes">The target method's parameter types.</param>
        /// <returns><see langword="true"/>, if the patching was successful; otherwise, <see langword="false"/>.</returns>
        public bool Prefix(Type targetType, string targetMethod, Type[]? targetParameterTypes = null)
            => PatchShared(HarmonyPatchType.Prefix, targetType, targetMethod, targetParameterTypes);
        /// <summary>
        ///   <para>Prefix-patches the specified <paramref name="targetType"/>'s <paramref name="targetMethod"/>, optionally with the specified <paramref name="targetParameterTypes"/>, with the specified <paramref name="patchMethod"/>.</para>
        /// </summary>
        /// <param name="targetType">The target method's type.</param>
        /// <param name="targetMethod">The target method's name.</param>
        /// <param name="patchMethod">The patch method's name.</param>
        /// <param name="targetParameterTypes">The target method's parameter types.</param>
        /// <returns><see langword="true"/>, if the patching was successful; otherwise, <see langword="false"/>.</returns>
        public bool Prefix(Type targetType, string targetMethod, string patchMethod, Type[]? targetParameterTypes = null)
            => PatchShared(HarmonyPatchType.Prefix, targetType, targetMethod, patchMethod, targetParameterTypes);

        /// <summary>
        ///   <para>Postfix-patches the specified <paramref name="targetType"/>'s <paramref name="targetMethod"/>, optionally with the specified <paramref name="targetParameterTypes"/>, with a patch method called "&lt;<paramref name="targetType"/>&gt;_&lt;<paramref name="targetMethod"/>&gt;".</para>
        /// </summary>
        /// <param name="targetType">The target method's type.</param>
        /// <param name="targetMethod">The target method's name.</param>
        /// <param name="targetParameterTypes">The target method's parameter types.</param>
        /// <returns><see langword="true"/>, if the patching was successful; otherwise, <see langword="false"/>.</returns>
        public bool Postfix(Type targetType, string targetMethod, Type[]? targetParameterTypes = null)
            => PatchShared(HarmonyPatchType.Postfix, targetType, targetMethod, targetParameterTypes);
        /// <summary>
        ///   <para>Postfix-patches the specified <paramref name="targetType"/>'s <paramref name="targetMethod"/>, optionally with the specified <paramref name="targetParameterTypes"/>, with the specified <paramref name="patchMethod"/>.</para>
        /// </summary>
        /// <param name="targetType">The target method's type.</param>
        /// <param name="targetMethod">The target method's name.</param>
        /// <param name="patchMethod">The patch method's name.</param>
        /// <param name="targetParameterTypes">The target method's parameter types.</param>
        /// <returns><see langword="true"/>, if the patching was successful; otherwise, <see langword="false"/>.</returns>
        public bool Postfix(Type targetType, string targetMethod, string patchMethod, Type[]? targetParameterTypes = null)
            => PatchShared(HarmonyPatchType.Postfix, targetType, targetMethod, patchMethod, targetParameterTypes);

        /// <summary>
        ///   <para>Transpiler-patches the specified <paramref name="targetType"/>'s <paramref name="targetMethod"/>, optionally with the specified <paramref name="targetParameterTypes"/>, with a patch method called "&lt;<paramref name="targetType"/>&gt;_&lt;<paramref name="targetMethod"/>&gt;".</para>
        /// </summary>
        /// <param name="targetType">The target method's type.</param>
        /// <param name="targetMethod">The target method's name.</param>
        /// <param name="targetParameterTypes">The target method's parameter types.</param>
        /// <returns><see langword="true"/>, if the patching was successful; otherwise, <see langword="false"/>.</returns>
        public bool Transpiler(Type targetType, string targetMethod, Type[]? targetParameterTypes = null)
            => PatchShared(HarmonyPatchType.Transpiler, targetType, targetMethod, targetParameterTypes);
        /// <summary>
        ///   <para>Transpiler-patches the specified <paramref name="targetType"/>'s <paramref name="targetMethod"/>, optionally with the specified <paramref name="targetParameterTypes"/>, with the specified <paramref name="patchMethod"/>.</para>
        /// </summary>
        /// <param name="targetType">The target method's type.</param>
        /// <param name="targetMethod">The target method's name.</param>
        /// <param name="patchMethod">The patch method's name.</param>
        /// <param name="targetParameterTypes">The target method's parameter types.</param>
        /// <returns><see langword="true"/>, if the patching was successful; otherwise, <see langword="false"/>.</returns>
        public bool Transpiler(Type targetType, string targetMethod, string patchMethod, Type[]? targetParameterTypes = null)
            => PatchShared(HarmonyPatchType.Transpiler, targetType, targetMethod, patchMethod, targetParameterTypes);

        /// <summary>
        ///   <para>Finalizer-patches the specified <paramref name="targetType"/>'s <paramref name="targetMethod"/>, optionally with the specified <paramref name="targetParameterTypes"/>, with a patch method called "&lt;<paramref name="targetType"/>&gt;_&lt;<paramref name="targetMethod"/>&gt;".</para>
        /// </summary>
        /// <param name="targetType">The target method's type.</param>
        /// <param name="targetMethod">The target method's name.</param>
        /// <param name="targetParameterTypes">The target method's parameter types.</param>
        /// <returns><see langword="true"/>, if the patching was successful; otherwise, <see langword="false"/>.</returns>
        public bool Finalizer(Type targetType, string targetMethod, Type[]? targetParameterTypes = null)
            => PatchShared(HarmonyPatchType.Finalizer, targetType, targetMethod, targetParameterTypes);
        /// <summary>
        ///   <para>Finalizer-patches the specified <paramref name="targetType"/>'s <paramref name="targetMethod"/>, optionally with the specified <paramref name="targetParameterTypes"/>, with the specified <paramref name="patchMethod"/>.</para>
        /// </summary>
        /// <param name="targetType">The target method's type.</param>
        /// <param name="targetMethod">The target method's name.</param>
        /// <param name="patchMethod">The patch method's name.</param>
        /// <param name="targetParameterTypes">The target method's parameter types.</param>
        /// <returns><see langword="true"/>, if the patching was successful; otherwise, <see langword="false"/>.</returns>
        public bool Finalizer(Type targetType, string targetMethod, string patchMethod, Type[]? targetParameterTypes = null)
            => PatchShared(HarmonyPatchType.Finalizer, targetType, targetMethod, patchMethod, targetParameterTypes);

        private bool PatchShared(HarmonyPatchType type, Type targetType, string targetMethod, Type[]? targetParameterTypes)
        {
            if (targetType is null) throw new ArgumentNullException(nameof(targetType));
            if (targetMethod is null) throw new ArgumentNullException(nameof(targetMethod));

            return PatchShared(type, targetType, targetMethod, $"{targetType.Name}_{targetMethod}", targetParameterTypes);
        }
        private bool PatchShared(HarmonyPatchType type, Type targetType, string targetMethod, string patchMethod, Type[]? targetParameterTypes)
        {
            if (targetType is null) throw new ArgumentNullException(nameof(targetType));
            if (targetMethod is null) throw new ArgumentNullException(nameof(targetMethod));
            if (patchMethod is null) throw new ArgumentNullException(nameof(patchMethod));

            Stopwatch? sw = null;
            MethodInfo? target = null;
            MethodInfo? patch = null;
            try
            {
                if (EnableStopwatch) (sw = new Stopwatch()).Start();

                target = FindMethod(targetType, targetMethod, targetParameterTypes)
                      ?? throw new MemberNotFoundException($"Target method {targetType.FullName}.{targetMethod} could not be found.");
                patch = FindMethod(TypeWithPatches, patchMethod, null)
                     ?? throw new MemberNotFoundException($"Patch method {TypeWithPatches.FullName}.{patchMethod} could not be found.");

                _ = ApplyPatch(type, target, new HarmonyMethod(patch));

                if (sw is not null)
                {
                    sw.Stop();
                    results.Add(new PatchRecord(type.ToString(), target, patch, sw.Elapsed, true));
                }
                return true;
            }
            catch (Exception e)
            {
                if (sw is not null)
                {
                    sw.Stop();
                    results.Add(new PatchRecord(type.ToString(), target, patch, sw.Elapsed, false));
                }
                log.LogError($"Could not patch {targetType.Name}.{targetMethod}() with {patchMethod}().");
                log.LogError(e);
                hasErrors = true;
                return false;
            }
        }
        private MethodInfo ApplyPatch(HarmonyPatchType type, MethodInfo target, HarmonyMethod patch) => type switch
        {
            HarmonyPatchType.Prefix => harmony.Patch(target, patch),
            HarmonyPatchType.Postfix => harmony.Patch(target, null, patch),
            HarmonyPatchType.Transpiler => harmony.Patch(target, null, null, patch),
            HarmonyPatchType.Finalizer => harmony.Patch(target, null, null, null, patch, null),
            HarmonyPatchType.ILManipulator => harmony.Patch(target, null, null, null, null, patch),
        };

    }
}
