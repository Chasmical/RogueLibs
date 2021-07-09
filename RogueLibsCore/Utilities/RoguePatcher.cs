using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Diagnostics;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace RogueLibsCore
{
	public class RoguePatcher
	{
		public RoguePatcher(BaseUnityPlugin myPlugin)
		{
			if (myPlugin is null) throw new ArgumentNullException(nameof(myPlugin));
			log = (ManualLogSource)loggerProperty.GetValue(myPlugin);
			harmony = new Harmony(myPlugin.Info.Metadata.GUID);
			TypeWithPatches = myPlugin.GetType();
		}
		public RoguePatcher(BaseUnityPlugin myPlugin, Type typeWithPatches)
		{
			if (myPlugin is null) throw new ArgumentNullException(nameof(myPlugin));
			if (typeWithPatches is null) throw new ArgumentNullException(nameof(typeWithPatches));
			log = (ManualLogSource)loggerProperty.GetValue(myPlugin);
			harmony = new Harmony(myPlugin.Info.Metadata.GUID);
			TypeWithPatches = typeWithPatches;
		}

		private static readonly PropertyInfo loggerProperty = AccessTools.Property(typeof(BaseUnityPlugin), "Logger");
		private readonly Harmony harmony;
		private readonly ManualLogSource log;
		private Type typeWithPatches;
		public Type TypeWithPatches
		{
			get => typeWithPatches;
			set => typeWithPatches = value ?? throw new ArgumentNullException(nameof(value));
		}

		public bool EnableStopwatch { get; set; }
		private List<PatchTime> results = new List<PatchTime>();
		public ReadOnlyCollection<PatchTime> Results { get; }
		public void ClearResults() => results = new List<PatchTime>();
		public void LogResults()
		{
			log.LogDebug($"Measured {results.Count} patches:");
			TimeSpan total = TimeSpan.Zero;
			foreach (PatchTime time in results)
			{
				log.LogDebug($"| {time.PatchTypeString,10}" +
					$" | {time.Target.DeclaringType.Name + "." + time.Target.Name, -40}" +
					$" | {time.Elapsed.TotalMilliseconds,4:####}ms |");
				total += time.Elapsed;
			}
			log.LogDebug($"Total: {total,5:#####}ms");
		}

		private static readonly BindingFlags All = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

		public bool Prefix(Type targetType, string targetMethod, Type[] targetParameterTypes = null)
		{
			if (targetType is null) throw new ArgumentNullException(nameof(targetType));
			if (targetMethod is null) throw new ArgumentNullException(nameof(targetMethod));
			return Prefix(targetType, targetMethod, $"{targetType.Name}_{targetMethod}", targetParameterTypes);
		}
		public bool Prefix(Type targetType, string targetMethod, string patchMethod, Type[] targetParameterTypes = null)
		{
			if (targetType is null) throw new ArgumentNullException(nameof(targetType));
			if (targetMethod is null) throw new ArgumentNullException(nameof(targetMethod));
			if (patchMethod is null) throw new ArgumentNullException(nameof(patchMethod));
			Stopwatch sw = null;
			try
			{
				if (EnableStopwatch)
				{
					sw = new Stopwatch();
					sw.Start();
					MethodInfo target = targetType.GetMethod(targetMethod, All, null, targetParameterTypes, null)
						?? throw new MemberNotFoundException($"Target method {targetType.FullName}.{targetMethod} could not be found.");
					MethodInfo patch = TypeWithPatches.GetMethod(patchMethod, All)
						?? throw new MemberNotFoundException($"Patch method {TypeWithPatches.FullName}.{patchMethod} could not be found.");
					harmony.Patch(target, new HarmonyMethod(patch));
					sw.Stop();

					results.Add(new PatchTime("Prefix", target, patch, sw.Elapsed));
				}
				else
				{
					MethodInfo target = targetType.GetMethod(targetMethod, All, null, targetParameterTypes, null)
						?? throw new MemberNotFoundException($"Target method {targetType.FullName}.{targetMethod} could not be found.");
					MethodInfo patch = TypeWithPatches.GetMethod(patchMethod, All)
						?? throw new MemberNotFoundException($"Patch method {TypeWithPatches.FullName}.{patchMethod} could not be found.");
					harmony.Patch(target, new HarmonyMethod(patch));
				}
				return true;
			}
			catch (Exception e)
			{
				sw?.Reset();
				log.LogError(e);
				return false;
			}
		}

		public bool Postfix(Type targetType, string targetMethod, Type[] targetParameterTypes = null)
		{
			if (targetType is null) throw new ArgumentNullException(nameof(targetType));
			if (targetMethod is null) throw new ArgumentNullException(nameof(targetMethod));
			return Postfix(targetType, targetMethod, $"{targetType.Name}_{targetMethod}", targetParameterTypes);
		}
		public bool Postfix(Type targetType, string targetMethod, string patchMethod, Type[] targetParameterTypes = null)
		{
			if (targetType is null) throw new ArgumentNullException(nameof(targetType));
			if (targetMethod is null) throw new ArgumentNullException(nameof(targetMethod));
			if (patchMethod is null) throw new ArgumentNullException(nameof(patchMethod));
			Stopwatch sw = null;
			try
			{
				if (EnableStopwatch)
				{
					sw = new Stopwatch();
					sw.Start();
					MethodInfo target = targetType.GetMethod(targetMethod, All, null, targetParameterTypes, null)
						?? throw new MemberNotFoundException($"Target method {targetType.FullName}.{targetMethod} could not be found.");
					MethodInfo patch = TypeWithPatches.GetMethod(patchMethod, All)
						?? throw new MemberNotFoundException($"Patch method {TypeWithPatches.FullName}.{patchMethod} could not be found.");
					harmony.Patch(target, null, new HarmonyMethod(patch));
					sw.Stop();

					results.Add(new PatchTime("Postfix", target, patch, sw.Elapsed));
				}
				else
				{
					MethodInfo target = targetType.GetMethod(targetMethod, All, null, targetParameterTypes, null)
						?? throw new MemberNotFoundException($"Target method {targetType.FullName}.{targetMethod} could not be found.");
					MethodInfo patch = TypeWithPatches.GetMethod(patchMethod, All)
						?? throw new MemberNotFoundException($"Patch method {TypeWithPatches.FullName}.{patchMethod} could not be found.");
					harmony.Patch(target, null, new HarmonyMethod(patch));
				}
				return true;
			}
			catch (Exception e)
			{
				sw?.Reset();
				log.LogError(e);
				return false;
			}
		}

		public bool Transpiler(Type targetType, string targetMethod, Type[] targetParameterTypes = null)
		{
			if (targetType is null) throw new ArgumentNullException(nameof(targetType));
			if (targetMethod is null) throw new ArgumentNullException(nameof(targetMethod));
			return Transpiler(targetType, targetMethod, $"{targetType.Name}_{targetMethod}", targetParameterTypes);
		}
		public bool Transpiler(Type targetType, string targetMethod, string patchMethod, Type[] targetParameterTypes = null)
		{
			if (targetType is null) throw new ArgumentNullException(nameof(targetType));
			if (targetMethod is null) throw new ArgumentNullException(nameof(targetMethod));
			if (patchMethod is null) throw new ArgumentNullException(nameof(patchMethod));
			Stopwatch sw = null;
			try
			{
				if (EnableStopwatch)
				{
					sw = new Stopwatch();
					sw.Start();
					MethodInfo target = targetType.GetMethod(targetMethod, All, null, targetParameterTypes, null)
						?? throw new MemberNotFoundException($"Target method {targetType.FullName}.{targetMethod} could not be found.");
					MethodInfo patch = TypeWithPatches.GetMethod(patchMethod, All)
						?? throw new MemberNotFoundException($"Patch method {TypeWithPatches.FullName}.{patchMethod} could not be found.");
					harmony.Patch(target, null, null, new HarmonyMethod(patch));
					sw.Stop();

					results.Add(new PatchTime("Transpiler", target, patch, sw.Elapsed));
				}
				else
				{
					MethodInfo target = targetType.GetMethod(targetMethod, All, null, targetParameterTypes, null)
						?? throw new MemberNotFoundException($"Target method {targetType.FullName}.{targetMethod} could not be found.");
					MethodInfo patch = TypeWithPatches.GetMethod(patchMethod, All)
						?? throw new MemberNotFoundException($"Patch method {TypeWithPatches.FullName}.{patchMethod} could not be found.");
					harmony.Patch(target, null, null, new HarmonyMethod(patch));
				}
				return true;
			}
			catch (Exception e)
			{
				sw?.Reset();
				log.LogError(e);
				return false;
			}
		}

		public bool Finalizer(Type targetType, string targetMethod, Type[] targetParameterTypes = null)
		{
			if (targetType is null) throw new ArgumentNullException(nameof(targetType));
			if (targetMethod is null) throw new ArgumentNullException(nameof(targetMethod));
			return Finalizer(targetType, targetMethod, $"{targetType.Name}_{targetMethod}", targetParameterTypes);
		}
		public bool Finalizer(Type targetType, string targetMethod, string patchMethod, Type[] targetParameterTypes = null)
		{
			if (targetType is null) throw new ArgumentNullException(nameof(targetType));
			if (targetMethod is null) throw new ArgumentNullException(nameof(targetMethod));
			if (patchMethod is null) throw new ArgumentNullException(nameof(patchMethod));
			Stopwatch sw = null;
			try
			{
				if (EnableStopwatch)
				{
					sw = new Stopwatch();
					sw.Start();
					MethodInfo target = targetType.GetMethod(targetMethod, All, null, targetParameterTypes, null)
						?? throw new MemberNotFoundException($"Target method {targetType.FullName}.{targetMethod} could not be found.");
					MethodInfo patch = TypeWithPatches.GetMethod(patchMethod, All)
						?? throw new MemberNotFoundException($"Patch method {TypeWithPatches.FullName}.{patchMethod} could not be found.");
					harmony.Patch(target, null, null, null, new HarmonyMethod(patch));
					sw.Stop();

					results.Add(new PatchTime("Finalizer", target, patch, sw.Elapsed));
				}
				else
				{
					MethodInfo target = targetType.GetMethod(targetMethod, All, null, targetParameterTypes, null)
						?? throw new MemberNotFoundException($"Target method {targetType.FullName}.{targetMethod} could not be found.");
					MethodInfo patch = TypeWithPatches.GetMethod(patchMethod, All)
						?? throw new MemberNotFoundException($"Patch method {TypeWithPatches.FullName}.{patchMethod} could not be found.");
					harmony.Patch(target, null, null, null, new HarmonyMethod(patch));
				}
				return true;
			}
			catch (Exception e)
			{
				sw?.Reset();
				log.LogError(e);
				return false;
			}
		}
	}
	public class PatchTime
	{
		public PatchTime(string patchType, MethodInfo target, MethodInfo patch, TimeSpan elapsed)
		{
			PatchTypeString = patchType;
			Target = target;
			Patch = patch;
			Elapsed = elapsed;
		}
		public string PatchTypeString { get; }
		public MethodInfo Target { get; }
		public MethodInfo Patch { get; }
		public TimeSpan Elapsed { get; }
	}
}
