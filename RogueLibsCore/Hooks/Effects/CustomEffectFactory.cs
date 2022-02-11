using System;
using System.Collections.Generic;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a factory of <see cref="CustomEffect"/> hooks.</para>
    /// </summary>
    public sealed class CustomEffectFactory : HookFactoryBase<StatusEffect>
    {
        private readonly Dictionary<string, EffectEntry> effectsDict = new Dictionary<string, EffectEntry>();
        /// <inheritdoc/>
        public override bool TryCreate(StatusEffect? instance, out IHook<StatusEffect>? hook)
        {
            if (instance is not null && effectsDict.TryGetValue(instance.statusEffectName, out EffectEntry entry))
            {
                hook = entry.Initializer();
                if (hook is CustomEffect custom)
                    custom.EffectInfo = entry.EffectInfo;
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
        public EffectInfo AddEffect<TEffect>() where TEffect : CustomEffect, new()
        {
            EffectInfo info = EffectInfo.Get<TEffect>();
            if (RogueFramework.IsDebugEnabled(DebugFlags.Effects))
                RogueFramework.LogDebug($"Created custom effect {typeof(TEffect)} ({info.Name}).");
            effectsDict.Add(info.Name, new EffectEntry { Initializer = static () => new TEffect(), EffectInfo = info });
            return info;
        }

        private struct EffectEntry
        {
            public Func<IHook<StatusEffect>> Initializer;
            public EffectInfo EffectInfo;
        }
    }
}
