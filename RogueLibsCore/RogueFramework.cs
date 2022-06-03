﻿using System;
using System.Collections.Generic;
using BepInEx.Logging;
using UnityEngine;

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
        public static RogueLibsPlugin Plugin { get; internal set; } = null!; // set in RogueLibsPlugin.Awake()
        internal static ManualLogSource Logger { get; set; } = null!; // set in RogueLibsPlugin.Awake()

        /// <summary>
        ///   <para>Determines whether RogueLibs was compiled in the Debug configuration.</para>
        /// </summary>
        public static bool Debug =>
#if DEBUG
            true;
#else
            false;
#endif

        /// <summary>
        ///   <para>Determines the RogueLibs' enabled debugging flags.</para>
        /// </summary>
        public static DebugFlags DebugFlags { get; set; }

        /// <summary>
        ///   <para>Determines whether any of the specified <paramref name="flags"/> is enabled.</para>
        /// </summary>
        /// <param name="flags">The flags to test for.</param>
        /// <returns><see langword="true"/>, if any of the specified <paramref name="flags"/> is enabled; otherwise, <see langword="false"/>.</returns>
        public static bool IsDebugEnabled(DebugFlags flags) => (DebugFlags & flags) != 0;

        internal static void LogDebug(string message) => Logger.LogDebug(message);
        internal static void LogWarning(string message) => Logger.LogWarning(message);
        internal static void LogError(string message) => Logger.LogError(message);
        internal static void LogError(Exception e, string methodName, object hookObj, object? container = null)
        {
            object? instance = hookObj is IHook hook ? hook.Instance : string.Empty;

            string instanceName = instance is InvItem item ? item.invItemName
                : instance is StatusEffect effect ? effect.statusEffectName
                : instance is Trait trait ? trait.traitName
                : instance is Agent agent ? agent.agentName
                : instance is ObjectReal objectReal ? objectReal.objectName
                : instance is UnlockWrapper wrapper ? $"{wrapper.Name} ({wrapper.Type})"
                : instance?.ToString() ?? string.Empty;

            string containerName = container is null ? string.Empty
                : (instanceName.Length > 0 ? ", " : string.Empty) + (
                    container is Item ? "on the ground"
                    : container is Agent a ? a.agentName
                    : container is PlayfieldObject o ? o.objectName
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

        public static tk2dSpriteCollectionData? ItemSprites { get; internal set; }
        public static tk2dSpriteCollectionData? ObjectSprites { get; internal set; }
        public static tk2dSpriteCollectionData? FloorSprites { get; internal set; }
        public static tk2dSpriteCollectionData? BulletSprites { get; internal set; }
        public static tk2dSpriteCollectionData? HairSprites { get; internal set; }
        public static tk2dSpriteCollectionData? FacialHairSprites { get; internal set; }
        public static tk2dSpriteCollectionData? HeadPieceSprites { get; internal set; }
        public static tk2dSpriteCollectionData? AgentSprites { get; internal set; }
        public static tk2dSpriteCollectionData? BodySprites { get; internal set; }
        public static tk2dSpriteCollectionData? WreckageSprites { get; internal set; }
        public static tk2dSpriteCollectionData? InterfaceSprites { get; internal set; }
        public static tk2dSpriteCollectionData? DecalSprites { get; internal set; }
        public static tk2dSpriteCollectionData? WallTopSprites { get; internal set; }
        public static tk2dSpriteCollectionData? WallSprites { get; internal set; }
        public static tk2dSpriteCollectionData? SpawnerSprites { get; internal set; }


    }
}
