using System;
using System.Collections.Generic;
using System.Reflection;
using BepInEx;
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
        public static BaseUnityPlugin Plugin { get; internal set; } = null!; // set in RogueLibsPlugin.Awake()
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

        internal static void LogDebug(string message) => Logger.LogDebug(message);
        internal static void LogWarning(string message) => Logger.LogWarning(message);
        internal static void LogError(string message) => Logger.LogError(message);
        internal static void LogError(Exception e, string methodName, object hookObj, object? container = null)
        {
            object? instance = hookObj is IHook hook ? hook.Instance : string.Empty;

            string instanceName = instance switch
            {
                InvItem item => item.invItemName,
                StatusEffect effect => effect.statusEffectName,
                Trait trait => trait.traitName,
                Agent agent => agent.agentName,
                ObjectReal objectReal => objectReal.objectName,
                UnlockWrapper wrapper => $"{wrapper.Name} ({wrapper.Type})",
                _ => instance?.ToString() ?? string.Empty,
            };

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
        internal static void LogError(MethodBase method)
        {
            LogError(method.DeclaringType?.FullName ?? "[No declaring type]");
            LogError(method.Name);
        }

        internal const int SpecialInt = -488755541;

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
        ///   <para>The list of object hook factories, used by RogueLibs.</para>
        /// </summary>
        public static readonly List<IHookFactory<PlayfieldObject>> ObjectFactories = new List<IHookFactory<PlayfieldObject>>();

        /// <summary>
        ///   <para>The list of name providers, used by RogueLibs.</para>
        /// </summary>
        public static readonly List<INameProvider> NameProviders = new List<INameProvider>();

        /// <summary>
        ///   <para>The list of all unlocks in the game, including the vanilla ones too.</para>
        /// </summary>
        public static readonly List<UnlockWrapper> Unlocks = new List<UnlockWrapper>();
        internal static readonly List<UnlockWrapper> CustomUnlocks = new List<UnlockWrapper>();

        /// <summary>
        ///   <para>The list of all custom disasters, that will be used in the game.</para>
        /// </summary>
        public static readonly List<CustomDisaster> CustomDisasters = new List<CustomDisaster>();
        /// <summary>
        ///   <para>Returns the currently active custom disaster.</para>
        /// </summary>
        /// <returns>The currently active instance of <see cref="CustomDisaster"/>, if there is one; otherwise, <see langword="null"/>.</returns>
        public static CustomDisaster? GetActiveDisaster() => CustomDisasters.Find(static d => d.IsActive);

        /// <summary>
        ///   <para>The list of extra sprites, that will be used if a sprite is not found in the appropriate collection.</para>
        /// </summary>
        public static readonly Dictionary<string, Sprite> ExtraSprites = new Dictionary<string, Sprite>();

        /// <summary>
        ///   <para>The <see cref="tk2dSpriteCollectionData"/> that contains the item sprites, or <see langword="null"/>, if it's not initialized yet.</para>
        /// </summary>
        public static tk2dSpriteCollectionData? ItemSprites { get; internal set; }
        /// <summary>
        ///   <para>The <see cref="tk2dSpriteCollectionData"/> that contains the object sprites, or <see langword="null"/>, if it's not initialized yet.</para>
        /// </summary>
        public static tk2dSpriteCollectionData? ObjectSprites { get; internal set; }
        /// <summary>
        ///   <para>The <see cref="tk2dSpriteCollectionData"/> that contains the floor sprites, or <see langword="null"/>, if it's not initialized yet.</para>
        /// </summary>
        public static tk2dSpriteCollectionData? FloorSprites { get; internal set; }
        /// <summary>
        ///   <para>The <see cref="tk2dSpriteCollectionData"/> that contains the projectile sprites, or <see langword="null"/>, if it's not initialized yet.</para>
        /// </summary>
        public static tk2dSpriteCollectionData? BulletSprites { get; internal set; }
        /// <summary>
        ///   <para>The <see cref="tk2dSpriteCollectionData"/> that contains the hair sprites, or <see langword="null"/>, if it's not initialized yet.</para>
        /// </summary>
        public static tk2dSpriteCollectionData? HairSprites { get; internal set; }
        /// <summary>
        ///   <para>The <see cref="tk2dSpriteCollectionData"/> that contains the facial hair sprites, or <see langword="null"/>, if it's not initialized yet.</para>
        /// </summary>
        public static tk2dSpriteCollectionData? FacialHairSprites { get; internal set; }
        /// <summary>
        ///   <para>The <see cref="tk2dSpriteCollectionData"/> that contains the head piece sprites, or <see langword="null"/>, if it's not initialized yet.</para>
        /// </summary>
        public static tk2dSpriteCollectionData? HeadPieceSprites { get; internal set; }
        /// <summary>
        ///   <para>The <see cref="tk2dSpriteCollectionData"/> that contains the agent sprites, or <see langword="null"/>, if it's not initialized yet.</para>
        /// </summary>
        public static tk2dSpriteCollectionData? AgentSprites { get; internal set; }
        /// <summary>
        ///   <para>The <see cref="tk2dSpriteCollectionData"/> that contains the agent body sprites, or <see langword="null"/>, if it's not initialized yet.</para>
        /// </summary>
        public static tk2dSpriteCollectionData? BodySprites { get; internal set; }
        /// <summary>
        ///   <para>The <see cref="tk2dSpriteCollectionData"/> that contains the wreckage sprites, or <see langword="null"/>, if it's not initialized yet.</para>
        /// </summary>
        public static tk2dSpriteCollectionData? WreckageSprites { get; internal set; }
        /// <summary>
        ///   <para>The <see cref="tk2dSpriteCollectionData"/> that contains the interface sprites, or <see langword="null"/>, if it's not initialized yet.</para>
        /// </summary>
        public static tk2dSpriteCollectionData? InterfaceSprites { get; internal set; }
        /// <summary>
        ///   <para>The <see cref="tk2dSpriteCollectionData"/> that contains the decal sprites, or <see langword="null"/>, if it's not initialized yet.</para>
        /// </summary>
        public static tk2dSpriteCollectionData? DecalSprites { get; internal set; }
        /// <summary>
        ///   <para>The <see cref="tk2dSpriteCollectionData"/> that contains the wall top sprites, or <see langword="null"/>, if it's not initialized yet.</para>
        /// </summary>
        public static tk2dSpriteCollectionData? WallTopSprites { get; internal set; }
        /// <summary>
        ///   <para>The <see cref="tk2dSpriteCollectionData"/> that contains the wall sprites, or <see langword="null"/>, if it's not initialized yet.</para>
        /// </summary>
        public static tk2dSpriteCollectionData? WallSprites { get; internal set; }
        /// <summary>
        ///   <para>The <see cref="tk2dSpriteCollectionData"/> that contains the spawner sprites, used in the Level Editor, or <see langword="null"/>, if it's not initialized yet.</para>
        /// </summary>
        public static tk2dSpriteCollectionData? SpawnerSprites { get; internal set; }
        /// <summary>
        ///   <para>The <see cref="tk2dSpriteCollectionData"/> that contains the shadow sprites, or <see langword="null"/>, if it's not initialized yet.</para>
        /// </summary>
        public static tk2dSpriteCollectionData? ShadowSprites { get; internal set; }
        /// <summary>
        ///   <para>The <see cref="tk2dSpriteCollectionData"/> that contains the tile shadow sprites, or <see langword="null"/>, if it's not initialized yet.</para>
        /// </summary>
        public static tk2dSpriteCollectionData? TileShadowSprites { get; internal set; }


    }
}
