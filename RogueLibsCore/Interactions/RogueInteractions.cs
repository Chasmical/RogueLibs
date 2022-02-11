using System;
using System.Collections.Generic;

namespace RogueLibsCore
{
    public static class RogueInteractions
    {
        public static readonly List<IInteractionProvider> Providers = new List<IInteractionProvider>();

        public static SimpleInteractionProvider<T> CreateProvider<T>(Action<SimpleInteractionProvider<T>> handler) where T : PlayfieldObject
        {
            SimpleInteractionProvider<T> provider = new SimpleInteractionProvider<T>(handler);
            Providers.Add(provider);
            return provider;
        }
        public static SimpleInteractionProvider<T> CreateProvider<T>(Func<SimpleInteractionProvider<T>, object> handler) where T : PlayfieldObject
        {
            SimpleInteractionProvider<T> provider = new SimpleInteractionProvider<T>(h => handler(h));
            Providers.Add(provider);
            return provider;
        }
        public static SimpleInteractionProvider CreateProvider(Action<SimpleInteractionProvider> handler)
        {
            SimpleInteractionProvider provider = new SimpleInteractionProvider(handler);
            Providers.Add(provider);
            return provider;
        }
        public static SimpleInteractionProvider CreateProvider(Func<SimpleInteractionProvider, object> handler)
        {
            SimpleInteractionProvider provider = new SimpleInteractionProvider(h => handler(h));
            Providers.Add(provider);
            return provider;
        }

    }
}
