using System;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Provides methods to add inventory checks.</para>
    /// </summary>
    public static class InventoryChecks
    {
        internal static readonly RogueEvent<OnItemUsingArgs> onItemUsing = new RogueEvent<OnItemUsingArgs>();
        internal static readonly RogueEvent<OnItemsCombiningArgs> onItemsCombining = new RogueEvent<OnItemsCombiningArgs>();
        internal static readonly RogueEvent<OnItemTargetingArgs> onItemTargeting = new RogueEvent<OnItemTargetingArgs>();
        internal static readonly RogueEvent<OnItemTargetingAnywhereArgs> onItemTargetingAnywhere = new RogueEvent<OnItemTargetingAnywhereArgs>();

        /// <summary>
        ///   <para>Adds an item usage inventory check with the specified <paramref name="name"/> and <paramref name="handler"/>.</para>
        /// </summary>
        /// <param name="name">The name of the inventory check to add.</param>
        /// <param name="handler">The inventory check handler.</param>
        /// <exception cref="ArgumentNullException"><paramref name="handler"/> is <see langword="null"/>.</exception>
        public static void AddItemUsingCheck(string name, RogueEventHandler<OnItemUsingArgs> handler)
        {
            if (handler is null) throw new ArgumentNullException(nameof(handler));
            if (RogueFramework.IsDebugEnabled(DebugFlags.Items))
                RogueFramework.LogDebug($"Added \"{name}\" usage inventory check.");
            onItemUsing.Subscribe(name, handler);
        }
        /// <summary>
        ///   <para>Adds an item combining inventory check with the specified <paramref name="name"/> and <paramref name="handler"/>.</para>
        /// </summary>
        /// <param name="name">The name of the inventory check to add.</param>
        /// <param name="handler">The inventory check handler.</param>
        /// <exception cref="ArgumentNullException"><paramref name="handler"/> is <see langword="null"/>.</exception>
        public static void AddItemsCombiningCheck(string name, RogueEventHandler<OnItemsCombiningArgs> handler)
        {
            if (handler is null) throw new ArgumentNullException(nameof(handler));
            if (RogueFramework.IsDebugEnabled(DebugFlags.Items))
                RogueFramework.LogDebug($"Added \"{name}\" combining inventory check.");
            onItemsCombining.Subscribe(name, handler);
        }
        /// <summary>
        ///   <para>Adds an item targeting inventory check with the specified <paramref name="name"/> and <paramref name="handler"/>.</para>
        /// </summary>
        /// <param name="name">The name of the inventory check to add.</param>
        /// <param name="handler">The inventory check handler.</param>
        /// <exception cref="ArgumentNullException"><paramref name="handler"/> is <see langword="null"/>.</exception>
        public static void AddItemTargetingCheck(string name, RogueEventHandler<OnItemTargetingArgs> handler)
        {
            if (handler is null) throw new ArgumentNullException(nameof(handler));
            if (RogueFramework.IsDebugEnabled(DebugFlags.Items))
                RogueFramework.LogDebug($"Added \"{name}\" targeting inventory check.");
            onItemTargeting.Subscribe(name, handler);
        }
        /// <summary>
        ///   <para>Adds an item targeting anywhere inventory check with the specified <paramref name="name"/> and <paramref name="handler"/>.</para>
        /// </summary>
        /// <param name="name">The name of the inventory check to add.</param>
        /// <param name="handler">The inventory check handler.</param>
        /// <exception cref="ArgumentNullException"><paramref name="handler"/> is <see langword="null"/>.</exception>
        public static void AddItemTargetingAnywhereCheck(string name, RogueEventHandler<OnItemTargetingAnywhereArgs> handler)
        {
            if (handler is null) throw new ArgumentNullException(nameof(handler));
            if (RogueFramework.IsDebugEnabled(DebugFlags.Items))
                RogueFramework.LogDebug($"Added \"{name}\" targeting anywhere inventory check.");
            onItemTargetingAnywhere.Subscribe(name, handler);
        }

        /// <summary>
        ///   <para>Determines whether the specified <paramref name="checkName"/> is allowed on the specified <paramref name="item"/>.</para>
        /// </summary>
        /// <param name="item">The item to check whether the inventory check is allowed for.</param>
        /// <param name="checkName">The name of the inventory check.</param>
        /// <returns><see langword="true"/>, if the inventory check is allowed; otherwise, <see langword="false"/>.</returns>
        public static bool IsCheckAllowed(InvItem? item, string checkName) => IsCheckAllowed(item?.GetHook<CustomItem>(), checkName);
        /// <summary>
        ///   <para>Determines whether the specified <paramref name="checkName"/> is allowed on the specified <paramref name="customItem"/>.</para>
        /// </summary>
        /// <param name="customItem">The custom item to check whether the inventory check is allowed for.</param>
        /// <param name="checkName">The name of the inventory check.</param>
        /// <returns><see langword="true"/>, if the inventory check is allowed; otherwise, <see langword="false"/>.</returns>
        public static bool IsCheckAllowed(CustomItem? customItem, string checkName)
            => customItem?.ItemInfo.IgnoredChecks.Contains(checkName) != true;
    }
}
