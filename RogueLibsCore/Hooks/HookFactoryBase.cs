using System.Diagnostics.CodeAnalysis;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a hook factory base. Implements the interfaces, leaving only one abstract method to implement.</para>
    /// </summary>
    /// <typeparam name="T">The type of objects that the created hooks can be attached to.</typeparam>
    public abstract class HookFactoryBase<T> : IHookFactory where T : notnull
    {
        /// <summary>
        ///   <para>Tries to create a hook for the specified <paramref name="instance"/> of type <typeparamref name="T"/>, and returns a value that indicates whether a hook was created successfully.</para>
        /// </summary>
        /// <param name="instance">The instance of type <typeparamref name="T"/> to create a hook for.</param>
        /// <param name="hook">A hook created for the specified <paramref name="instance"/> of type <typeparamref name="T"/>.</param>
        /// <returns><see langword="true"/>, if a hook was successfully created; otherwise, <see langword="false"/>.</returns>
        public abstract bool TryCreate(T instance, [NotNullWhen(true)] out IHook<T>? hook);

        IHook? IHookFactory.TryCreateHook(object instance)
            => instance is T instanceT && TryCreate(instanceT, out IHook<T>? hook) ? hook : null;

    }
}
