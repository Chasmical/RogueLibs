using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using BepInEx;
using BepInEx.Logging;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents a collection of hooks, attached to a single object.</para>
	/// </summary>
	public interface IHookController : IEnumerable<IHook>
	{
		/// <summary>
		///   <para>Gets the object that the hooks are attached to.</para>
		/// </summary>
		object Instance { get; }

		/// <summary>
		///   <para>Attaches the specified <paramref name="hook"/> to the current instance.</para>
		/// </summary>
		/// <param name="hook">The hook to attach to the current instance.</param>
		void AddHook(IHook hook);
		/// <summary>
		///   <para>Detaches the specified <paramref name="hook"/> from the current instance.</para>
		/// </summary>
		/// <param name="hook">The hook to detach from the current instance.</param>
		/// <returns><see langword="true"/>, if the hook was successfully detached; otherwise, <see langword="false"/>.</returns>
		bool RemoveHook(IHook hook);

		/// <summary>
		///   <para>Gets a hook from the collection that is assignable to a variable of <typeparamref name="THook"/> type.</para>
		/// </summary>
		/// <typeparam name="THook">The type of the hook to search for.</typeparam>
		/// <returns>A hook that is assignable to a variable of <typeparamref name="THook"/> type, if found; otherwise, <see langword="null"/>.</returns>
		THook GetHook<THook>();
		/// <summary>
		///   <para>Returns an enumerable collection of all hooks in the collection that are assignable to a variable of <typeparamref name="THook"/> type.</para>
		/// </summary>
		/// <typeparam name="THook">The type of the hooks to search for.</typeparam>
		/// <returns>An enumerable collection of hooks that are assignable to a variable of <typeparamref name="THook"/> type.</returns>
		IEnumerable<THook> GetHooks<THook>();
	}
	/// <summary>
	///   <para>Represents a collection of hooks, attached to a single instance of type <typeparamref name="T"/>.</para>
	/// </summary>
	/// <typeparam name="T">The type of objects, that the hooks can be attached to.</typeparam>
	public interface IHookController<T> : IHookController, IEnumerable<IHook<T>>
	{
		/// <summary>
		///   <para>Gets the instance of type <typeparamref name="T"/> that the hooks are attached to.</para>
		/// </summary>
		new T Instance { get; }

		/// <summary>
		///   <para>Attaches the specified <paramref name="hook"/> to the current instance.</para>
		/// </summary>
		/// <param name="hook">The hook to attach to the current instance.</param>
		void AddHook(IHook<T> hook);
		/// <summary>
		///   <para>Detaches the specified <paramref name="hook"/> from the current instance.</para>
		/// </summary>
		/// <param name="hook">The hook to detach from the current instance.</param>
		/// <returns><see langword="true"/>, if the hook was successfully detached; otherwise, <see langword="false"/>.</returns>
		bool RemoveHook(IHook<T> hook);
	}
	/// <summary>
	///   <para>The default implementation of <see cref="IHookController{T}"/>.</para>
	/// </summary>
	/// <typeparam name="T">The type of objects that the hooks can be attached to.</typeparam>
	public sealed class HookController<T> : IHookController<T>
	{
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="HookController{T}"/> class with the specified <paramref name="instance"/>.</para>
		/// </summary>
		/// <param name="instance">An object that the hooks will be attached to.</param>
		public HookController(T instance) => Instance = instance;
		/// <inheritdoc/>
		public T Instance { get; }
		object IHookController.Instance => Instance;

		private readonly List<IHook<T>> hooks = new List<IHook<T>>();

		/// <inheritdoc/>
		public void AddHook(IHook<T> hook)
		{
			if (hook is null) throw new ArgumentNullException(nameof(hook));
			hook.Instance = Instance;
			hooks.Add(hook);
			hook.Initialize();
		}
		/// <summary>
		///   <para>Creates a hook of the specified <typeparamref name="THook"/> type using its default constructor and attaches it to the current instance.</para>
		/// </summary>
		/// <typeparam name="THook">The type of the hook to create and attach to the current instance.</typeparam>
		/// <returns>The created hook of the specified <typeparamref name="THook"/> type.</returns>
		public THook AddHook<THook>()
			where THook : IHook<T>, new()
		{
			THook hook = new THook { Instance = Instance };
			hooks.Add(hook);
			hook.Initialize();
			return hook;
		}
		void IHookController.AddHook(IHook hook)
		{
			if (hook is null) throw new ArgumentNullException(nameof(hook));
			if (hook is IHook<T> ihook) AddHook(ihook);
			else throw new ArgumentException("Invalid type!", nameof(hook));
		}

		/// <inheritdoc/>
		public bool RemoveHook(IHook<T> hook) => hooks.Remove(hook);
		/// <summary>
		///   <para>Detaches a hook of the specified <typeparamref name="THook"/> type from the current instance.</para>
		/// </summary>
		/// <typeparam name="THook">The type of the hook to detach from the current instance.</typeparam>
		/// <returns><see langword="true"/>, if a hook of the specified <typeparamref name="THook"/> type was successfully detached; otherwise, <see langword="false"/>.</returns>
		public bool RemoveHook<THook>()
		{
			int index = hooks.FindIndex(h => h is THook);
			if (index is -1) return false;
			hooks.RemoveAt(index);
			return true;
		}
		bool IHookController.RemoveHook(IHook hook)
		{
			int index = hooks.FindIndex(h => h == hook);
			if (index is -1) return false;
			hooks.RemoveAt(index);
			return true;
		}

		/// <inheritdoc/>
		public THook GetHook<THook>() => (THook)hooks.Find(h => h is THook);
		/// <inheritdoc/>
		public IEnumerable<THook> GetHooks<THook>() => hooks.OfType<THook>();
		/// <summary>
		///   <para>Gets all hooks attached to the current instance.</para>
		/// </summary>
		/// <returns>A collection of hooks attached to the current instance.</returns>
		public IEnumerable<IHook<T>> GetHooks() => hooks.ToArray();

		/// <inheritdoc/>
		public IEnumerator<IHook<T>> GetEnumerator() => hooks.GetEnumerator();
		IEnumerator<IHook> IEnumerable<IHook>.GetEnumerator() => GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
