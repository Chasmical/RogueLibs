using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Reflection;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Collection of RogueLibs extension methods.</para>
	/// </summary>
	public static class BaseUnityPluginExtensions
	{
		/// <summary>
		///   <para>It's just a shortcut for: <c>Logger.LogError(<paramref name="message"/>); Logger.LogError(<paramref name="e"/>);</c>.</para>
		/// </summary>
		public static void LogErrorWith(this BaseUnityPlugin plugin, string message, Exception e)
		{
			PropertyInfo property = AccessTools.Property(typeof(BaseUnityPlugin), "Logger");
			ManualLogSource logger = (ManualLogSource)property.GetValue(plugin, new object[0]);
			logger.LogError(message);
			logger.LogError(e);
		}

		/// <summary>
		///   <para>Patches an original method so that the given patch method will be called right before the original.</para>
		///   <para>Automatically catches and logs all errors. Returns true if the patch was successful, returns false if an error occured.</para>
		/// </summary>
		public static bool PatchPrefix(this BaseUnityPlugin me, Type type, string methodName, Type patchType, string patchMethodName, params Type[] types)
		{
			if (types.Length == 0)
				types = null;
			MethodInfo original;
			MethodInfo patch;
			try
			{
				original = AccessTools.Method(type, methodName, types);
			}
			catch (Exception e)
			{
				me.LogErrorWith("Could not find original method " + type.Name + "." + methodName + "(..)!", e);
				return false;
			}
			try
			{
				patch = AccessTools.Method(patchType, patchMethodName);
			}
			catch (Exception e)
			{
				me.LogErrorWith("Could not find prefix-method " + patchType.Name + "." + patchMethodName + "(..)!", e);
				return false;
			}
			try
			{
				new Harmony(me.Info.Metadata.GUID).Patch(original, new HarmonyMethod(patch));
			}
			catch (Exception e)
			{
				me.LogErrorWith("Failed to prefix-patch " + type.Name + "." + methodName + "(..) with " + patchType.Name + "." + patchMethodName + "(..)!", e);
				return false;
			}
			return true;
		}
		/// <summary>
		///   <para>Patches an original method so that the given patch method will be called right after the original.</para>
		///   <para>Automatically catches and logs all errors. Returns true if the patch was successful, returns false if an error occured.</para>
		/// </summary>
		public static bool PatchPostfix(this BaseUnityPlugin me, Type type, string methodName, Type patchType, string patchMethodName, params Type[] types)
		{
			if (types.Length == 0)
				types = null;
			MethodInfo original;
			MethodInfo patch;
			try
			{
				original = AccessTools.Method(type, methodName, types);
			}
			catch (Exception e)
			{
				me.LogErrorWith("Could not find original method " + type.Name + "." + methodName + "(..)!", e);
				return false;
			}
			try
			{
				patch = AccessTools.Method(patchType, patchMethodName);
			}
			catch (Exception e)
			{
				me.LogErrorWith("Could not find postfix-method " + patchType.Name + "." + patchMethodName + "(..)!", e);
				return false;
			}
			try
			{
				new Harmony(me.Info.Metadata.GUID).Patch(original, null, new HarmonyMethod(patch));
			}
			catch (Exception e)
			{
				me.LogErrorWith("Failed to postfix-patch " + type.Name + "." + methodName + "(..) with " + patchType.Name + "." + patchMethodName + "(..)!", e);
				return false;
			}
			return true;
		}
	}
}
