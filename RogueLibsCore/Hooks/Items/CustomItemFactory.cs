using System;
using System.Collections.Generic;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a factory of <see cref="CustomItem"/> hooks.</para>
    /// </summary>
    public sealed class CustomItemFactory : HookFactoryBase<InvItem>
    {
        private readonly Dictionary<string, ItemEntry> itemsDict = new Dictionary<string, ItemEntry>();
        /// <inheritdoc/>
        public override bool TryCreate(InvItem? instance, out IHook<InvItem>? hook)
        {
            if (instance != null && itemsDict.TryGetValue(instance.invItemName, out ItemEntry entry))
            {
                hook = entry.Initializer();
                if (hook is CustomItem custom)
                    custom.ItemInfo = entry.ItemInfo;
                return true;
            }
            hook = null;
            return false;
        }
        /// <summary>
        ///   <para>Adds the specified <typeparamref name="TItem"/> type to the factory.</para>
        /// </summary>
        /// <typeparam name="TItem">The <see cref="CustomItem"/> type to add.</typeparam>
        /// <returns>The added item's metadata.</returns>
        public ItemInfo AddItem<TItem>() where TItem : CustomItem, new()
        {
            ItemInfo info = ItemInfo.Get<TItem>();
            if (RogueFramework.IsDebugEnabled(DebugFlags.Items))
                RogueFramework.LogDebug($"Created custom item {typeof(TItem)} ({info.Name}).");
            itemsDict.Add(info.Name, new ItemEntry { Initializer = static () => new TItem(), ItemInfo = info });
            return info;
        }

        private struct ItemEntry
        {
            public Func<IHook<InvItem>> Initializer;
            public ItemInfo ItemInfo;
        }
    }
}
