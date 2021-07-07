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

		public static DebugFlags Debug { get; set; }
#if DEBUG
			= DebugFlags.All;
#endif

		public static bool IsDebugEnabled(DebugFlags flags) => (Debug & flags) == flags;
		public static void LogDebug(string message) => Logger.LogDebug(message);

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
