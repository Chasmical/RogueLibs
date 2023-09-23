using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a factory of <see cref="CustomItem"/> hooks.</para>
    /// </summary>
    public sealed class CustomItemFactory : HookFactoryBase<InvItem>
    {
        private readonly Dictionary<string, ItemEntry> itemsDict = new Dictionary<string, ItemEntry>();
        /// <inheritdoc/>
        public override bool TryCreate(InvItem? instance, [NotNullWhen(true)] out IHook<InvItem>? hook)
        {
            if (instance?.invItemName is not null && itemsDict.TryGetValue(instance.invItemName, out ItemEntry entry))
            {
                hook = entry.Initializer();
                if (hook is CustomItem custom)
                    custom.Metadata = entry.Metadata;
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
        public CustomItemMetadata AddItem<TItem>() where TItem : CustomItem, new()
        {
            CustomItemMetadata metadata = CustomItemMetadata.Get<TItem>();
            itemsDict.Add(metadata.Name, new ItemEntry { Initializer = static () => new TItem(), Metadata = metadata });
            return metadata;
        }

        private struct ItemEntry
        {
            public Func<IHook<InvItem>> Initializer;
            public CustomItemMetadata Metadata;
        }
    }
}
