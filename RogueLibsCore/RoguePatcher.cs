using System;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace RogueLibsCore
{
	public class RoguePatcher
	{
		public RoguePatcher(BaseUnityPlugin myPlugin) : this(myPlugin, myPlugin.GetType()) { }
		public RoguePatcher(BaseUnityPlugin myPlugin, Type typeWithPatches)
		{
			log = (ManualLogSource)loggerProperty.GetValue(myPlugin);
			guid = myPlugin.Info.Metadata.GUID;
			TypeWithPatches = typeWithPatches;
		}

		private static readonly PropertyInfo loggerProperty = AccessTools.Property(typeof(BaseUnityPlugin), "Logger");
		private readonly string guid;
		private readonly ManualLogSource log;
		public Type TypeWithPatches { get; set; }

		public bool Prefix(Type type, string originalMethod, Type[] parameterTypes = null)
			=> Prefix(type, originalMethod, $"{type.Name}_{originalMethod}", parameterTypes);
		public bool Prefix(Type type, string originalMethod, string patchMethod, Type[] parameterTypes = null)
		{
			try
			{
				MethodInfo original = AccessTools.Method(type, originalMethod, parameterTypes);
				MethodInfo patch = AccessTools.Method(TypeWithPatches, patchMethod);
				new Harmony(guid).Patch(original, new HarmonyMethod(patch));
				return true;
			}
			catch (Exception e)
			{
				log.LogError(e);
				return false;
			}
		}

		public bool Postfix(Type type, string originalMethod, Type[] parameterTypes = null)
			=> Postfix(type, originalMethod, $"{type.Name}_{originalMethod}", parameterTypes);
		public bool Postfix(Type type, string originalMethod, string patchMethod, Type[] parameterTypes = null)
		{
			try
			{
				MethodInfo original = AccessTools.Method(type, originalMethod, parameterTypes);
				MethodInfo patch = AccessTools.Method(TypeWithPatches, patchMethod);
				new Harmony(guid).Patch(original, null, new HarmonyMethod(patch));
				return true;
			}
			catch (Exception e)
			{
				log.LogError(e);
				return false;
			}
		}

		public bool Transpiler(Type type, string originalMethod, Type[] parameterTypes = null)
			=> Transpiler(type, originalMethod, $"{type.Name}_{originalMethod}", parameterTypes);
		public bool Transpiler(Type type, string originalMethod, string patchMethod, Type[] parameterTypes = null)
		{
			try
			{
				MethodInfo original = AccessTools.Method(type, originalMethod, parameterTypes);
				MethodInfo patch = AccessTools.Method(TypeWithPatches, patchMethod);
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
