using System.Collections.Generic;
using BepInEx.Logging;
using UnityEngine;

namespace RogueLibsCore
{
	public static class RogueFramework
	{
		public static RogueLibsPlugin Plugin { get; internal set; }
		internal static ManualLogSource Logger { get; set; }

		public static bool DebugMode { get; set; }

		public static readonly List<IHookFactory<InvItem>> ItemFactories = new List<IHookFactory<InvItem>>();
		public static readonly List<IHookFactory<Trait>> TraitFactories = new List<IHookFactory<Trait>>();
		public static readonly List<IHookFactory<StatusEffect>> EffectFactories = new List<IHookFactory<StatusEffect>>();

		public static readonly List<INameProvider> NameProviders = new List<INameProvider>();

		public static readonly List<UnlockWrapper> Unlocks = new List<UnlockWrapper>();
		internal static readonly List<UnlockWrapper> CustomUnlocks = new List<UnlockWrapper>();

		public static readonly Dictionary<string, Sprite> ExtraSprites = new Dictionary<string, Sprite>();
	}
}
