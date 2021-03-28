using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Base interface for hooks.</para>
	/// </summary>
	public interface IHook
	{
		/// <summary>
		///   <para>Initializes the current hook.</para>
		/// </summary>
		void Initialize();
		/// <summary>
		///   <para>Gets/sets the instance, that the current hook is attached to.</para>
		/// </summary>
		object Instance { get; set; }
	}
	/// <summary>
	///   <para>Base interface for hooks, attachable to instances of type <typeparamref name="T"/>.</para>
	/// </summary>
	/// <typeparam name="T">Type that the hooks can be attached to.</typeparam>
	public interface IHook<T> : IHook
	{
		/// <summary>
		///   <para>Gets/sets the instance, that the current hook is attached to.</para>
		/// </summary>
		new T Instance { get; set; }
	}
	/// <summary>
	///   <para>Hook base class. Implements some of the properties and methods.</para>
	/// </summary>
	/// <typeparam name="T">Type that the hooks can be attached to.</typeparam>
	public abstract class HookBase<T> : IHook<T>
	{
		/// <summary>
		///   <para>Initializes the current hook.</para>
		/// </summary>
		protected abstract void Initialize();
		void IHook.Initialize() => Initialize();

		/// <summary>
		///   <para>Gets/sets the instance, that the current hook is attached to.</para>
		/// </summary>
		protected T Instance { get; set; }
		T IHook<T>.Instance { get => Instance; set => Instance = (T)value; }
		object IHook.Instance { get => Instance; set => Instance = (T)value; }
	}
}
