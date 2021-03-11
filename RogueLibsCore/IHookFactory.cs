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
		///   <para>Determines whether the current factory can create a hook for the specified <paramref name="obj"/>.</para>
		/// </summary>
		/// <param name="obj">Instance to create a hook for.</param>
		/// <returns><see langword="true"/>, if the current factory can create a hook for the specified <paramref name="obj"/>; otherwise, <see langword="false"/>.</returns>
		bool CanCreate(object obj);
		/// <summary>
		///   <para>Creates a new instance of the hook type for the specified <paramref name="obj"/>.</para>
		/// </summary>
		/// <param name="obj">Instance to create a hook for.</param>
		/// <returns>Hook created for the specified <paramref name="obj"/>.</returns>
		IHook CreateHook(object obj);
	}
	/// <summary>
	///   <para>Base interface for hook factories, producing hooks, attachable to instance of <typeparamref name="T"/> type.</para>
	/// </summary>
	/// <typeparam name="T">Type that the produced hooks can be attached to.</typeparam>
	public interface IHookFactory<T> : IHookFactory
	{
		/// <summary>
		///   <para>Determines whether the current factory can create a hook for the specified <paramref name="obj"/>.</para>
		/// </summary>
		/// <param name="obj">Instance to create a hook for.</param>
		/// <returns><see langword="true"/>, if the current factory can create a hook for the specified <paramref name="obj"/>; otherwise, <see langword="false"/>.</returns>
		bool CanCreate(T obj);
		/// <summary>
		///   <para>Creates a new instance of the hook type for the specified <paramref name="obj"/>.</para>
		/// </summary>
		/// <param name="obj">Instance to create a hook for.</param>
		/// <returns>Hook created for the specified <paramref name="obj"/>.</returns>
		IHook<T> CreateHook(T obj);
	}
	/// <summary>
	///   <para>Hook factory base class. Implements some of the methods.</para>
	/// </summary>
	/// <typeparam name="T">Type that the produced hooks can be attached to.</typeparam>
	public abstract class HookFactoryBase<T> : IHookFactory<T>
	{
		/// <summary>
		///   <para>Determines whether the current factory can create a hook for the specified <paramref name="obj"/>.</para>
		/// </summary>
		/// <param name="obj">Instance to create a hook for.</param>
		/// <returns><see langword="true"/>, if the current factory can create a hook for the specified <paramref name="obj"/>; otherwise, <see langword="false"/>.</returns>
		public abstract bool CanCreate(T obj);
		/// <summary>
		///   <para>Creates a new instance of the hook type for the specified <paramref name="obj"/>.</para>
		/// </summary>
		/// <param name="obj">Instance to create a hook for.</param>
		/// <returns>Hook created for the specified <paramref name="obj"/>.</returns>
		public abstract IHook<T> CreateHook(T obj);

		bool IHookFactory.CanCreate(object obj) => obj is T t && CanCreate(t);
		IHook IHookFactory.CreateHook(object obj) => CreateHook((T)obj);
	}
}
