using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents a hook factory.</para>
	/// </summary>
	public interface IHookFactory
	{
		/// <summary>
		///   <para>Tries to create a hook for the specified <paramref name="instance"/>, and returns a value that indicates whether a hook was created successfully.</para>
		/// </summary>
		/// <param name="instance">The object to create a hook for.</param>
		/// <param name="hook">A hook created for the specified <paramref name="instance"/>.</param>
		/// <returns><see langword="true"/>, if a hook was successfully created; otherwise, <see langword="false"/>.</returns>
		bool TryCreate(object instance, out IHook hook);
	}
	/// <summary>
	///   <para>Represents a hook factory, that creates hooks attachable to instances of type <typeparamref name="T"/>.</para>
	/// </summary>
	/// <typeparam name="T">The type of objects that the created hooks can be attached to.</typeparam>
	public interface IHookFactory<T> : IHookFactory
	{
		/// <summary>
		///   <para>Tries to create a hook for the specified <paramref name="instance"/> of type <typeparamref name="T"/>, and returns a value that indicates whether a hook was created successfully.</para>
		/// </summary>
		/// <param name="instance">The instance of type <typeparamref name="T"/> to create a hook for.</param>
		/// <param name="hook">A hook created for the specified <paramref name="instance"/> of type <typeparamref name="T"/>.</param>
		/// <returns><see langword="true"/>, if a hook was successfully created; otherwise, <see langword="false"/>.</returns>
		bool TryCreate(T instance, out IHook<T> hook);
	}
	/// <summary>
	///   <para>Represents a hook factory base. Implements the interfaces, leaving only one abstract method to implement.</para>
	/// </summary>
	/// <typeparam name="T">The type of objects that the created hooks can be attached to.</typeparam>
	public abstract class HookFactoryBase<T> : IHookFactory<T>
	{
		/// <inheritdoc/>
		public abstract bool TryCreate(T instance, out IHook<T> hook);
		bool IHookFactory.TryCreate(object instance, out IHook hook)
		{
			bool res = TryCreate((T)instance, out IHook<T> hookT);
			hook = hookT;
			return res;
		}
	}
}
