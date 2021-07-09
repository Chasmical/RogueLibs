using System;
using System.Collections.Generic;
using BepInEx.Logging;
using UnityEngine;

namespace RogueLibsCore
{
	public static class RogueFramework
	{
		public static RogueLibsPlugin Plugin { get; internal set; }
		internal static ManualLogSource Logger { get; set; }

		public static bool Debug { get; set; }
		public static DebugFlags DebugFlags { get; set; }
#if DEBUG
			= DebugFlags.EnableTools | DebugFlags.Abilities | DebugFlags.Unlocks;
#endif

		public static bool IsDebugEnabled(DebugFlags flags) => (DebugFlags & flags) == flags;

		internal static void LogDebug(string message) => Logger.LogDebug(message);
		internal static void LogWarning(string message) => Logger.LogWarning(message);
		internal static void LogError(string message) => Logger.LogError(message);
		internal static void LogError(Exception e, string methodName, object hookObj, object container = null)
		{
			IHook hook = (IHook)hookObj;
			object instance = hook.Instance;

			string instanceName = instance is InvItem item ? item.invItemName
				: instance is StatusEffect effect ? effect.statusEffectName
				: instance is Trait trait ? trait.traitName
				: instance is Agent agent ? agent.agentName
				: instance is ObjectReal objectReal ? objectReal.objectName
				: instance is UnlockWrapper wrapper ? $"{wrapper.Name} ({wrapper.Type})"
				: instance.ToString();

			string containerName = container is null ? string.Empty
				: ", " + (
					container is Item ? "on the ground"
					: container is Agent a ? a.agentName
					: container is ObjectReal o ? o.objectName
					: container is UnlocksMenu m ? m.Type.ToString()
					: container.ToString()
				);

			Logger.LogError($"{methodName} error in {hookObj} ({instanceName}{containerName})");
			Logger.LogError(e);
		}

		public static readonly List<IHookFactory<InvItem>> ItemFactories = new List<IHookFactory<InvItem>>();
		public static readonly List<IHookFactory<Trait>> TraitFactories = new List<IHookFactory<Trait>>();
		public static readonly List<IHookFactory<StatusEffect>> EffectFactories = new List<IHookFactory<StatusEffect>>();

		public static readonly List<INameProvider> NameProviders = new List<INameProvider>();

		public static readonly List<UnlockWrapper> Unlocks = new List<UnlockWrapper>();
		internal static readonly List<UnlockWrapper> CustomUnlocks = new List<UnlockWrapper>();

		public static readonly Dictionary<string, Sprite> ExtraSprites = new Dictionary<string, Sprite>();
	}
	[Flags]
	public enum DebugFlags
	{
		None = 0,

		Names       = 1 << 0,
		Unlocks     = 1 << 1,
		UnlockMenus = 1 << 2,
		Sprites     = 1 << 3,
		Items       = 1 << 4,
		Traits      = 1 << 5,
		Effects     = 1 << 6,
		Abilities   = 1 << 7,

		EnableTools = 1 << 31,

		All = Names | Unlocks | UnlockMenus | Sprites | Items | Traits | Effects | Abilities | EnableTools
	}
}
