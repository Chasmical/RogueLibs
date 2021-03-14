using System;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Simplified <see cref="Harmony"/> patcher.</para>
	/// </summary>
	public class RoguePatcher
	{
		/// <summary>
		///   <para>Initializes a new instance of <see cref="RoguePatcher"/> with the specified <paramref name="myPlugin"/>.</para>
		/// </summary>
		/// <param name="myPlugin">The instance of your plugin.</param>
		public RoguePatcher(BaseUnityPlugin myPlugin)
		{
			if (myPlugin is null) throw new ArgumentNullException(nameof(myPlugin));
			log = (ManualLogSource)loggerProperty.GetValue(myPlugin);
			guid = myPlugin.Info.Metadata.GUID;
			TypeWithPatches = myPlugin.GetType();
		}
		/// <summary>
		///   <para>Initializes a new instance of <see cref="RoguePatcher"/> with the specified <paramref name="myPlugin"/> and <paramref name="typeWithPatches"/>.</para>
		/// </summary>
		/// <param name="myPlugin">The instance of your plugin.</param>
		/// <param name="typeWithPatches">Type with patch methods.</param>
		public RoguePatcher(BaseUnityPlugin myPlugin, Type typeWithPatches)
		{
			if (myPlugin is null) throw new ArgumentNullException(nameof(myPlugin));
			if (typeWithPatches is null) throw new ArgumentNullException(nameof(typeWithPatches));
			log = (ManualLogSource)loggerProperty.GetValue(myPlugin);
			guid = myPlugin.Info.Metadata.GUID;
			TypeWithPatches = typeWithPatches;
		}

		private static readonly PropertyInfo loggerProperty = AccessTools.Property(typeof(BaseUnityPlugin), "Logger");
		private readonly string guid;
		private readonly ManualLogSource log;
		private Type typeWithPatches;
		/// <summary>
		///   <para>Type where patch methods will be search for.</para>
		/// </summary>
		/// <exception cref="ArgumentNullException"><see langword="value"/> is <see langword="null"/>.</exception>
		public Type TypeWithPatches
		{
			get => typeWithPatches;
			set => typeWithPatches = value ?? throw new ArgumentNullException(nameof(value));
		}

		/// <summary>
		///   <para>Prefix-patches the specified <paramref name="type"/>'s <paramref name="originalMethod"/>, optionally with <paramref name="parameterTypes"/>.</para>
		/// </summary>
		/// <param name="type">Type that the original method is defined in.</param>
		/// <param name="originalMethod">Original method's name.</param>
		/// <param name="parameterTypes">Original method's parameter types.</param>
		/// <returns><see langword="true"/>, if the patching was successful; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="type"/> or <paramref name="originalMethod"/> is <see langword="null"/>.</exception>
		public bool Prefix(Type type, string originalMethod, Type[] parameterTypes = null)
		{
			if (type is null) throw new ArgumentNullException(nameof(type));
			if (originalMethod is null) throw new ArgumentNullException(nameof(originalMethod));
			return Prefix(type, originalMethod, $"{type.Name}_{originalMethod}", parameterTypes);
		}
		/// <summary>
		///   <para>Prefix-patches the specified <paramref name="type"/>'s <paramref name="originalMethod"/> with the specified <paramref name="patchMethod"/>, optionally with <paramref name="parameterTypes"/>.</para>
		/// </summary>
		/// <param name="type">Type that the original method is defined in.</param>
		/// <param name="originalMethod">Original method's name.</param>
		/// <param name="patchMethod">Patch method's name.</param>
		/// <param name="parameterTypes">Original method's parameter types.</param>
		/// <returns><see langword="true"/>, if the patching was successful; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="type"/>, <paramref name="originalMethod"/> or <paramref name="patchMethod"/> is <see langword="null"/>.</exception>
		public bool Prefix(Type type, string originalMethod, string patchMethod, Type[] parameterTypes = null)
		{
			if (type is null) throw new ArgumentNullException(nameof(type));
			if (originalMethod is null) throw new ArgumentNullException(nameof(originalMethod));
			if (patchMethod is null) throw new ArgumentNullException(nameof(patchMethod));
			try
			{
				MethodInfo original = AccessTools.Method(type, originalMethod, parameterTypes);
				if (original is null) throw new MemberNotFoundException($"Original method {type.FullName}.{originalMethod} could not be found.");
				MethodInfo patch = AccessTools.Method(TypeWithPatches, patchMethod);
				if (patch is null) throw new MemberNotFoundException($"Patch method {TypeWithPatches.FullName}.{patchMethod} could not be found.");
				new Harmony(guid).Patch(original, new HarmonyMethod(patch));
				return true;
			}
			catch (Exception e)
			{
				log.LogError(e);
				return false;
			}
		}

		/// <summary>
		///   <para>Postfix-patches the specified <paramref name="type"/>'s <paramref name="originalMethod"/>, optionally with <paramref name="parameterTypes"/>.</para>
		/// </summary>
		/// <param name="type">Type that the original method is defined in.</param>
		/// <param name="originalMethod">Original method's name.</param>
		/// <param name="parameterTypes">Original method's parameter types.</param>
		/// <returns><see langword="true"/>, if the patching was successful; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="type"/> or <paramref name="originalMethod"/> is <see langword="null"/>.</exception>
		public bool Postfix(Type type, string originalMethod, Type[] parameterTypes = null)
		{
			if (type is null) throw new ArgumentNullException(nameof(type));
			if (originalMethod is null) throw new ArgumentNullException(nameof(originalMethod));
			return Postfix(type, originalMethod, $"{type.Name}_{originalMethod}", parameterTypes);
		}
		/// <summary>
		///   <para>Postfix-patches the specified <paramref name="type"/>'s <paramref name="originalMethod"/> with the specified <paramref name="patchMethod"/>, optionally with <paramref name="parameterTypes"/>.</para>
		/// </summary>
		/// <param name="type">Type that the original method is defined in.</param>
		/// <param name="originalMethod">Original method's name.</param>
		/// <param name="patchMethod">Patch method's name.</param>
		/// <param name="parameterTypes">Original method's parameter types.</param>
		/// <returns><see langword="true"/>, if the patching was successful; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="type"/>, <paramref name="originalMethod"/> or <paramref name="patchMethod"/> is <see langword="null"/>.</exception>
		public bool Postfix(Type type, string originalMethod, string patchMethod, Type[] parameterTypes = null)
		{
			if (type is null) throw new ArgumentNullException(nameof(type));
			if (originalMethod is null) throw new ArgumentNullException(nameof(originalMethod));
			if (patchMethod is null) throw new ArgumentNullException(nameof(patchMethod));
			try
			{
				MethodInfo original = AccessTools.Method(type, originalMethod, parameterTypes);
				if (original is null) throw new MemberNotFoundException($"Original method {type.FullName}.{originalMethod} could not be found.");
				MethodInfo patch = AccessTools.Method(TypeWithPatches, patchMethod);
				if (patch is null) throw new MemberNotFoundException($"Patch method {TypeWithPatches.FullName}.{patchMethod} could not be found.");
				new Harmony(guid).Patch(original, null, new HarmonyMethod(patch));
				return true;
			}
			catch (Exception e)
			{
				log.LogError(e);
				return false;
			}
		}

		/// <summary>
		///   <para>Transpiler-patches the specified <paramref name="type"/>'s <paramref name="originalMethod"/>, optionally with <paramref name="parameterTypes"/>.</para>
		/// </summary>
		/// <param name="type">Type that the original method is defined in.</param>
		/// <param name="originalMethod">Original method's name.</param>
		/// <param name="parameterTypes">Original method's parameter types.</param>
		/// <returns><see langword="true"/>, if the patching was successful; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="type"/> or <paramref name="originalMethod"/> is <see langword="null"/>.</exception>
		public bool Transpiler(Type type, string originalMethod, Type[] parameterTypes = null)
		{
			if (type is null) throw new ArgumentNullException(nameof(type));
			if (originalMethod is null) throw new ArgumentNullException(nameof(originalMethod));
			return Transpiler(type, originalMethod, $"{type.Name}_{originalMethod}", parameterTypes);
		}
		/// <summary>
		///   <para>Transpiler-patches the specified <paramref name="type"/>'s <paramref name="originalMethod"/> with the specified <paramref name="patchMethod"/>, optionally with <paramref name="parameterTypes"/>.</para>
		/// </summary>
		/// <param name="type">Type that the original method is defined in.</param>
		/// <param name="originalMethod">Original method's name.</param>
		/// <param name="patchMethod">Patch method's name.</param>
		/// <param name="parameterTypes">Original method's parameter types.</param>
		/// <returns><see langword="true"/>, if the patching was successful; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="type"/>, <paramref name="originalMethod"/> or <paramref name="patchMethod"/> is <see langword="null"/>.</exception>
		public bool Transpiler(Type type, string originalMethod, string patchMethod, Type[] parameterTypes = null)
		{
			if (type is null) throw new ArgumentNullException(nameof(type));
			if (originalMethod is null) throw new ArgumentNullException(nameof(originalMethod));
			if (patchMethod is null) throw new ArgumentNullException(nameof(patchMethod));
			try
			{
				MethodInfo original = AccessTools.Method(type, originalMethod, parameterTypes);
				if (original is null) throw new MemberNotFoundException($"Original method {type.FullName}.{originalMethod} could not be found.");
				MethodInfo patch = AccessTools.Method(TypeWithPatches, patchMethod);
				if (patch is null) throw new MemberNotFoundException($"Patch method {TypeWithPatches.FullName}.{patchMethod} could not be found.");
				new Harmony(guid).Patch(original, null, null, new HarmonyMethod(patch));
				return true;
			}
			catch (Exception e)
			{
				log.LogError(e);
				return false;
			}
		}
	}
}
