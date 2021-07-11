using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents a hook.</para>
	/// </summary>
	public interface IHook
	{
		/// <summary>
		///   <para>Initializes the hook.</para>
		/// </summary>
		void Initialize();
		/// <summary>
		///   <para>Gets or sets the instance that the hook is attached to.</para>
		/// </summary>
		object Instance { get; set; }
	}
	/// <summary>
	///   <para>Represents a hook, attachable to instances of type <typeparamref name="T"/>.</para>
	/// </summary>
	/// <typeparam name="T">The type of objects that the hook can be attached to.</typeparam>
	public interface IHook<T> : IHook
	{
		/// <summary>
		///   <para>Gets or sets the instance that the hook is attached to.</para>
		/// </summary>
		new T Instance { get; set; }
	}
	/// <summary>
	///   <para>Represents a hook base. Implements the interfaces, leaving only one abstract method to implement.</para>
	/// </summary>
	/// <typeparam name="T">The type of objects that the hook can be attached to.</typeparam>
	public abstract class HookBase<T> : IHook<T>
	{
		/// <summary>
		///   <para>Initializes the hook.</para>
		/// </summary>
		protected abstract void Initialize();
		void IHook.Initialize() => Initialize();

		/// <summary>
		///   <para>Gets or sets the instance that the hook is attached to.</para>
		/// </summary>
		protected T Instance { get; set; }
		T IHook<T>.Instance { get => Instance; set => Instance = (T)value; }
		object IHook.Instance { get => Instance; set => Instance = (T)value; }
	}
}
