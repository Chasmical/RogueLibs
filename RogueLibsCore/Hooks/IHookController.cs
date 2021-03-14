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
	///   <para>Base interface for hook controllers.</para>
	/// </summary>
	public interface IHookController : IEnumerable<IHook>
	{
		/// <summary>
		///   <para>Gets the instance, that the current hook is attached to.</para>
		/// </summary>
		object Instance { get; }

		/// <summary>
		///   <para>Initializes the specified <paramref name="hook"/> and adds it to the hook controller.</para>
		/// </summary>
		/// <param name="hook">Hook to attach to the hook controller.</param>
		void AddHook(IHook hook);
		/// <summary>
		///   <para>Removes the specified <paramref name="hook"/> from the hook controller.</para>
		/// </summary>
		/// <param name="hook">Hook to remove from the hook controller.</param>
		/// <returns><see langword="true"/>, if the hook was successfully removed; otherwise, <see langword="false"/>.</returns>
		bool RemoveHook(IHook hook);

		/// <summary>
		///   <para>Searches for a hook of the specified <typeparamref name="THook"/> type and returns the first occurence.</para>
		/// </summary>
		/// <typeparam name="THook">Type of the hook to search for.</typeparam>
		/// <returns>First occurence of a hook of the specified <typeparamref name="THook"/> type, if found; otherwise, <see langword="null"/>.</returns>
		THook GetHook<THook>();
		/// <summary>
		///   <para>Iterates through the hooks of the specified <typeparamref name="THook"/> type.</para>
		/// </summary>
		/// <typeparam name="THook">Type of the hooks to search for.</typeparam>
		/// <returns>Hooks of the specified <typeparamref name="THook"/> type, or an empty collection.</returns>
		IEnumerable<THook> GetHooks<THook>();
	}
	/// <summary>
	///   <para>Base interface for hook controllers, attachable to instances of type <typeparamref name="T"/>.</para>
	/// </summary>
	/// <typeparam name="T">Type that the hook controller is attachable to.</typeparam>
	public interface IHookController<T> : IHookController, IEnumerable<IHook<T>>
	{
		/// <summary>
		///   <para>Initializes the specified <paramref name="hook"/> and adds it to the hook controller.</para>
		/// </summary>
		/// <param name="hook">Hook to attach to the hook controller.</param>
		void AddHook(IHook<T> hook);
		/// <summary>
		///   <para>Removes the specified <paramref name="hook"/> from the hook controller.</para>
		/// </summary>
		/// <param name="hook">Hook to remove from the hook controller.</param>
		/// <returns><see langword="true"/>, if the hook was successfully removed; otherwise, <see langword="false"/>.</returns>
		bool RemoveHook(IHook<T> hook);
	}
	/// <summary>
	///   <para>Primary hook controller class, attachable to instances of type <typeparamref name="T"/>.</para>
	/// </summary>
	/// <typeparam name="T">Type that the hook controller is attachable to.</typeparam>
	public sealed class HookController<T> : IHookController<T>
	{
		/// <summary>
		///   <para>Initializes a new instance of <see cref="HookController{T}"/> with the specified <paramref name="instance"/>.</para>
		/// </summary>
		/// <param name="instance">Instance that the hook controller is attached to.</param>
		public HookController(T instance) => Instance = instance;
		/// <summary>
		///   <para>Instance that the hook controller is attached to.</para>
		/// </summary>
		public T Instance { get; }
		object IHookController.Instance => Instance;

		private readonly List<IHook<T>> hooks = new List<IHook<T>>();

		/// <summary>
		///   <para>Initializes the specified <paramref name="hook"/> and adds it to the hook controller.</para>
		/// </summary>
		/// <param name="hook">Hook to attach to the hook controller.</param>
		public void AddHook(IHook<T> hook)
		{
			hook.Instance = Instance;
			hooks.Add(hook);
		}
		/// <summary>
		///   <para>Initializes a new instance of the specified <typeparamref name="THook"/> type using the default constructor and adds it to the hook controller.</para>
		/// </summary>
		/// <typeparam name="THook">Type of the hook to initialize and add to the hook controller.</typeparam>
		public THook AddHook<THook>()
			where THook : IHook<T>, new()
		{
			THook hook = new THook { Instance = Instance };
			hooks.Add(hook);
			return hook;
		}
		void IHookController.AddHook(IHook hook)
		{
			if (hook is IHook<T> ihook) AddHook(ihook);
			else throw new ArgumentException("Invalid type!", nameof(hook));
		}

		/// <summary>
		///   <para>Removes the specified <paramref name="hook"/> from the hook controller.</para>
		/// </summary>
		/// <param name="hook">Hook to remove from the hook controller.</param>
		/// <returns><see langword="true"/>, if the hook was successfully removed; otherwise, <see langword="false"/>.</returns>
		public bool RemoveHook(IHook<T> hook) => hooks.Remove(hook);
		/// <summary>
		///   <para>Removes the first occurence of a hook of the specified <typeparamref name="THook"/> type from the hook controller.</para>
		/// </summary>
		/// <typeparam name="THook">Type of the hook to remove from the hook controller.</typeparam>
		/// <returns><see langword="true"/>, if the hook was successfully removed; otherwise, <see langword="false"/>.</returns>
		public bool RemoveHook<THook>()
		{
			int index = hooks.FindIndex(h => h is THook);
			if (index == -1) return false;
			hooks.RemoveAt(index);
			return true;
		}
		bool IHookController.RemoveHook(IHook hook)
		{
			int index = hooks.FindIndex(h => h == hook);
			if (index == -1) return false;
			hooks.RemoveAt(index);
			return true;
		}

		/// <summary>
		///   <para>Searches for a hook of the specified <typeparamref name="THook"/> type and returns the first occurence.</para>
		/// </summary>
		/// <typeparam name="THook">Type of the hook to search for.</typeparam>
		/// <returns>First occurence of a hook of the specified <typeparamref name="THook"/> type, if found; otherwise, <see langword="null"/>.</returns>
		public THook GetHook<THook>() => (THook)hooks.Find(h => h is THook);
		/// <summary>
		///   <para>Iterates through hooks of the specified <typeparamref name="THook"/> type.</para>
		/// </summary>
		/// <typeparam name="THook">Type of the hooks to search for.</typeparam>
		/// <returns>Hooks of the specified <typeparamref name="THook"/> type, or an empty collection.</returns>
		public IEnumerable<THook> GetHooks<THook>() => hooks.OfType<THook>();

		/// <summary>
		///   <para>Gets the default enumerator for the current hook controller.</para>
		/// </summary>
		/// <returns>Enumerator that itereates through the hook controller.</returns>
		public IEnumerator<IHook<T>> GetEnumerator() => hooks.GetEnumerator();
		IEnumerator<IHook> IEnumerable<IHook>.GetEnumerator() => GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
