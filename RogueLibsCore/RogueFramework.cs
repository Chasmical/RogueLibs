using System;
using System.Collections.Generic;
using BepInEx.Logging;
using UnityEngine;
using BepInEx;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents the internal workings of RogueLibs.</para>
	/// </summary>
	public static class RogueFramework
	{
		/// <summary>
		///   <para>The RogueLibs' plugin instance.</para>
		/// </summary>
		public static BaseUnityPlugin Plugin { get; internal set; }
		internal static ManualLogSource Logger { get; set; }

		/// <summary>
		///   <para>Determines whether the RogueLibs is in Debug mode.</para>
		/// </summary>
		public static bool Debug { get; set; }
#if DEBUG
			= true;
#endif
		/// <summary>
		///   <para>Determines the RogueLibs' enabled debugging flags.</para>
		/// </summary>
		public static DebugFlags DebugFlags { get; set; }
#if DEBUG
			= DebugFlags.EnableTools | DebugFlags.Abilities | DebugFlags.Effects;
#endif

		/// <summary>
		///   <para>Determines whether any of the specified <paramref name="flags"/> is enabled.</para>
		/// </summary>
		/// <param name="flags">The flags to test for.</param>
		/// <returns><see langword="true"/>, if any of the specified <paramref name="flags"/> is enabled; otherwise, <see langword="false"/>.</returns>
		public static bool IsDebugEnabled(DebugFlags flags) => (DebugFlags & flags) != 0;

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

		/// <summary>
		///   <para>The list of item hook factories, used by RogueLibs.</para>
		/// </summary>
		public static readonly List<IHookFactory<InvItem>> ItemFactories = new List<IHookFactory<InvItem>>();
		/// <summary>
		///   <para>The list of trait hook factories, used by RogueLibs.</para>
		/// </summary>
		public static readonly List<IHookFactory<Trait>> TraitFactories = new List<IHookFactory<Trait>>();
		/// <summary>
		///   <para>The list of effect hook factories, used by RogueLibs.</para>
		/// </summary>
		public static readonly List<IHookFactory<StatusEffect>> EffectFactories = new List<IHookFactory<StatusEffect>>();

		/// <summary>
		///   <para>The list of name providers, used by RogueLibs.</para>
		/// </summary>
		public static readonly List<INameProvider> NameProviders = new List<INameProvider>();

		/// <summary>
		///   <para>The list of all unlocks in the game, including original ones too.</para>
		/// </summary>
		public static readonly List<UnlockWrapper> Unlocks = new List<UnlockWrapper>();
		internal static readonly List<UnlockWrapper> CustomUnlocks = new List<UnlockWrapper>();

		/// <summary>
		///   <para>The list of extra sprites, that will be used if a sprite is not found in the appropriate collection.</para>
		/// </summary>
		public static readonly Dictionary<string, Sprite> ExtraSprites = new Dictionary<string, Sprite>();
	}
	/// <summary>
	///   <para>Represents the debugging flags.</para>
	/// </summary>
	[Flags]
	public enum DebugFlags
	{
		/// <summary>
		///   <para>No debug flags specified.</para>
		/// </summary>
		None = 0,

		/// <summary>
		///   <para>Specifies that names stuff should be logged.</para>
		/// </summary>
		Names       = 1 << 0,
		/// <summary>
		///   <para>Specifies that unlocks stuff should be logged.</para>
		/// </summary>
		Unlocks     = 1 << 1,
		/// <summary>
		///   <para>Specifies that unlock menus stuff should be logged.</para>
		/// </summary>
		UnlockMenus = 1 << 2,
		/// <summary>
		///   <para>Specifies that sprites stuff should be logged.</para>
		/// </summary>
		Sprites     = 1 << 3,
		/// <summary>
		///   <para>Specifies that items stuff should be logged.</para>
		/// </summary>
		Items       = 1 << 4,
		/// <summary>
		///   <para>Specifies that traits stuff should be logged.</para>
		/// </summary>
		Traits      = 1 << 5,
		/// <summary>
		///   <para>Specifies that effects stuff should be logged.</para>
		/// </summary>
		Effects     = 1 << 6,
		/// <summary>
		///   <para>Specifies that abilities stuff should be logged.</para>
		/// </summary>
		Abilities   = 1 << 7,

		/// <summary>
		///   <para>Specifies that various debug tools should be enabled.</para>
		/// </summary>
		EnableTools = 1 << 31,

		/// <summary>
		///   <para>Specifies all debug flags. Expect a giant wall of constantly flowing text.</para>
		/// </summary>
		All = Names | Unlocks | UnlockMenus | Sprites | Items | Traits | Effects | Abilities | EnableTools
	}
}
