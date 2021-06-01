using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Base interface for hook factories.</para>
	/// </summary>
	public interface IHookFactory
	{
		/// <summary>
		///   <para>Tries to create a hook for the specified <paramref name="instance"/>.</para>
		/// </summary>
		/// <param name="instance">The instance to create a hook for.</param>
		/// <param name="hook">The created hook.</param>
		/// <returns><see langword="true"/>, if a hook was created; otherwise, <see langword="false"/>.</returns>
		bool TryCreate(object instance, out IHook hook);
	}
	/// <summary>
	///   <para>Base interface for hook factories, producing hooks, attachable to instance of <typeparamref name="T"/> type.</para>
	/// </summary>
	/// <typeparam name="T">Type that the produced hooks can be attached to.</typeparam>
	public interface IHookFactory<T> : IHookFactory
	{
		/// <summary>
		///   <para>Tries to create a hook for the specified <paramref name="instance"/>.</para>
		/// </summary>
		/// <param name="instance">The instance to create a hook for.</param>
		/// <param name="hook">The created hook.</param>
		/// <returns><see langword="true"/>, if a hook was created; otherwise, <see langword="false"/>.</returns>
		bool TryCreate(T instance, out IHook<T> hook);
	}
	/// <summary>
	///   <para>Hook factory base class. Implements some of the methods.</para>
	/// </summary>
	/// <typeparam name="T">Type that the produced hooks can be attached to.</typeparam>
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
