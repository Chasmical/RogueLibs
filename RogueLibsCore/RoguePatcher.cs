using System;
using System.Reflection;
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

		public bool Prefix(Type type, string originalMethod, Type[] parameterTypes = null)
		{
			if (type is null) throw new ArgumentNullException(nameof(type));
			if (originalMethod is null) throw new ArgumentNullException(nameof(originalMethod));
			return Prefix(type, originalMethod, $"{type.Name}_{originalMethod}", parameterTypes);
		}
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
				harmony.Patch(original, new HarmonyMethod(patch));
				return true;
			}
			catch (Exception e)
			{
				log.LogError(e);
				return false;
			}
		}

		public bool Postfix(Type type, string originalMethod, Type[] parameterTypes = null)
		{
			if (type is null) throw new ArgumentNullException(nameof(type));
			if (originalMethod is null) throw new ArgumentNullException(nameof(originalMethod));
			return Postfix(type, originalMethod, $"{type.Name}_{originalMethod}", parameterTypes);
		}
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
				harmony.Patch(original, null, new HarmonyMethod(patch));
				return true;
			}
			catch (Exception e)
			{
				log.LogError(e);
				return false;
			}
		}

		public bool Transpiler(Type type, string originalMethod, Type[] parameterTypes = null)
		{
			if (type is null) throw new ArgumentNullException(nameof(type));
			if (originalMethod is null) throw new ArgumentNullException(nameof(originalMethod));
			return Transpiler(type, originalMethod, $"{type.Name}_{originalMethod}", parameterTypes);
		}
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
				harmony.Patch(original, null, null, new HarmonyMethod(patch));
				return true;
			}
			catch (Exception e)
			{
				log.LogError(e);
				return false;
			}
		}

		public bool Finalizer(Type type, string originalMethod, Type[] parameterTypes = null)
		{
			if (type is null) throw new ArgumentNullException(nameof(type));
			if (originalMethod is null) throw new ArgumentNullException(nameof(originalMethod));
			return Finalizer(type, originalMethod, $"{type.Name}_{originalMethod}", parameterTypes);
		}
		public bool Finalizer(Type type, string originalMethod, string patchMethod, Type[] parameterTypes = null)
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
				harmony.Patch(original, null, null, null, new HarmonyMethod(patch));
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
