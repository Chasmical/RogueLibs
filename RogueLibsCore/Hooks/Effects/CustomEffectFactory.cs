using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a factory of <see cref="CustomEffect"/> hooks.</para>
    /// </summary>
    public sealed class CustomEffectFactory : HookFactoryBase<StatusEffect>
    {
        private readonly Dictionary<string, EffectEntry> effectsDict = new Dictionary<string, EffectEntry>();
        /// <inheritdoc/>
        public override bool TryCreate(StatusEffect? instance, [NotNullWhen(true)] out IHook<StatusEffect>? hook)
        {
            if (instance is not null && effectsDict.TryGetValue(instance.statusEffectName, out EffectEntry entry))
            {
                hook = entry.Initializer();
                if (hook is CustomEffect custom)
                    custom.Metadata = entry.Metadata;
                return true;
            }
            hook = null;
            return false;
        }
        /// <summary>
        ///   <para>Adds the specified <typeparamref name="TEffect"/> type to the factory.</para>
        /// </summary>
        /// <typeparam name="TEffect">The <see cref="CustomEffect"/> type to add.</typeparam>
        /// <returns>The added effect's metadata.</returns>
        public CustomEffectMetadata AddEffect<TEffect>() where TEffect : CustomEffect, new()
        {
            CustomEffectMetadata metadata = CustomEffectMetadata.Get<TEffect>();
            effectsDict.Add(metadata.Name, new EffectEntry { Initializer = static () => new TEffect(), Metadata = metadata });
            return metadata;
        }

        private struct EffectEntry
        {
            public Func<IHook<StatusEffect>> Initializer;
            public CustomEffectMetadata Metadata;
        }
    }
}
