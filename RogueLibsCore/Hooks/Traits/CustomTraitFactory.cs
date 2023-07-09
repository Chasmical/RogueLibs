using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a factory of <see cref="CustomTrait"/> hooks.</para>
    /// </summary>
    public sealed class CustomTraitFactory : HookFactoryBase<Trait>
    {
        private readonly Dictionary<string, TraitEntry> traitsDict = new Dictionary<string, TraitEntry>();
        /// <inheritdoc/>
        public override bool TryCreate(Trait? instance, [NotNullWhen(true)] out IHook<Trait>? hook)
        {
            if (instance != null && traitsDict.TryGetValue(instance.traitName, out TraitEntry entry))
            {
                hook = entry.Initializer();
                if (hook is CustomTrait custom)
                    custom.Metadata = entry.Metadata;
                return true;
            }
            hook = null;
            return false;
        }
        /// <summary>
        ///   <para>Adds the specified <typeparamref name="TTrait"/> type to the factory.</para>
        /// </summary>
        /// <typeparam name="TTrait">The <see cref="CustomTrait"/> type to add.</typeparam>
        /// <returns>The added trait's metadata.</returns>
        public CustomTraitMetadata AddTrait<TTrait>() where TTrait : CustomTrait, new()
        {
            CustomTraitMetadata metadata = CustomTraitMetadata.Get<TTrait>();
            traitsDict.Add(metadata.Name, new TraitEntry { Initializer = static () => new TTrait(), Metadata = metadata });
            return metadata;
        }

        private struct TraitEntry
        {
            public Func<IHook<Trait>> Initializer;
            public CustomTraitMetadata Metadata;
        }
    }
}
