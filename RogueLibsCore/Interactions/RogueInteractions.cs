using System;
using System.Collections.Generic;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Provides a set of static methods for creating and manipulating interaction providers.</para>
    /// </summary>
    public static class RogueInteractions
    {
        /// <summary>
        ///   <para>The list of interaction providers, used by RogueLibs.</para>
        /// </summary>
        public static readonly List<IInteractionProvider> Providers = new List<IInteractionProvider>();

        /// <summary>
        ///   <para>Creates a <see cref="SimpleInteractionProvider{T}"/> with the specified <paramref name="handler"/>.</para>
        /// </summary>
        /// <typeparam name="T">The type of the object the interactions are for.</typeparam>
        /// <param name="handler">A delegate that handles interactions using a <see cref="SimpleInteractionProvider{T}"/>.</param>
        /// <returns>The created instance of the <see cref="SimpleInteractionProvider{T}"/> class.</returns>
        public static SimpleInteractionProvider<T> CreateProvider<T>(Action<SimpleInteractionProvider<T>> handler) where T : PlayfieldObject
        {
            SimpleInteractionProvider<T> provider = new SimpleInteractionProvider<T>(handler);
            Providers.Add(provider);
            return provider;
        }
        /// <summary>
        ///   <para>Creates a <see cref="SimpleInteractionProvider{T}"/> with the specified <paramref name="handler"/>. The delegate's return value is ignored.</para>
        /// </summary>
        /// <typeparam name="T">The type of the object the interactions are for.</typeparam>
        /// <param name="handler">A delegate that handles interactions using a <see cref="SimpleInteractionProvider{T}"/>. The return value is ignored.</param>
        /// <returns>The created instance of the <see cref="SimpleInteractionProvider{T}"/> class.</returns>
        public static SimpleInteractionProvider<T> CreateProvider<T>(Func<SimpleInteractionProvider<T>, object> handler) where T : PlayfieldObject
        {
            SimpleInteractionProvider<T> provider = new SimpleInteractionProvider<T>(h => handler(h));
            Providers.Add(provider);
            return provider;
        }
        /// <summary>
        ///   <para>Creates a <see cref="SimpleInteractionProvider"/> with the specified <paramref name="handler"/>.</para>
        /// </summary>
        /// <param name="handler">A delegate that handles interactions using a <see cref="SimpleInteractionProvider"/>.</param>
        /// <returns>The created instance of the <see cref="SimpleInteractionProvider"/> class.</returns>
        public static SimpleInteractionProvider CreateProvider(Action<SimpleInteractionProvider> handler)
        {
            SimpleInteractionProvider provider = new SimpleInteractionProvider(handler);
            Providers.Add(provider);
            return provider;
        }
        /// <summary>
        ///   <para>Creates a <see cref="SimpleInteractionProvider"/> with the specified <paramref name="handler"/>. The delegate's return value is ignored.</para>
        /// </summary>
        /// <param name="handler">A delegate that handles interactions using a <see cref="SimpleInteractionProvider"/>. The return value is ignored.</param>
        /// <returns>The created instance of the <see cref="SimpleInteractionProvider"/> class.</returns>
        public static SimpleInteractionProvider CreateProvider(Func<SimpleInteractionProvider, object> handler)
        {
            SimpleInteractionProvider provider = new SimpleInteractionProvider(h => handler(h));
            Providers.Add(provider);
            return provider;
        }

    }
}
