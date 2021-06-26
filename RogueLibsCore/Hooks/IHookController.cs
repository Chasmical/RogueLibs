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
	public interface IHookController : IEnumerable<IHook>
	{
		object Instance { get; }

		void AddHook(IHook hook);
		bool RemoveHook(IHook hook);

		THook GetHook<THook>();
		IEnumerable<THook> GetHooks<THook>();
	}
	public interface IHookController<T> : IHookController, IEnumerable<IHook<T>>
	{
		new T Instance { get; }

		void AddHook(IHook<T> hook);
		bool RemoveHook(IHook<T> hook);
	}
	public sealed class HookController<T> : IHookController<T>
	{
		public HookController(T instance) => Instance = instance;
		public T Instance { get; }
		object IHookController.Instance => Instance;

		private readonly List<IHook<T>> hooks = new List<IHook<T>>();

		public void AddHook(IHook<T> hook)
		{
			if (hook is null) throw new ArgumentNullException(nameof(hook));
			hook.Instance = Instance;
			hooks.Add(hook);
		}
		public THook AddHook<THook>()
			where THook : IHook<T>, new()
		{
			THook hook = new THook { Instance = Instance };
			hooks.Add(hook);
			return hook;
		}
		void IHookController.AddHook(IHook hook)
		{
			if (hook is null) throw new ArgumentNullException(nameof(hook));
			if (hook is IHook<T> ihook) AddHook(ihook);
			else throw new ArgumentException("Invalid type!", nameof(hook));
		}

		public bool RemoveHook(IHook<T> hook) => hooks.Remove(hook);
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

		public THook GetHook<THook>() => (THook)hooks.Find(h => h is THook);
		public IEnumerable<THook> GetHooks<THook>() => hooks.OfType<THook>();
		public IEnumerable<IHook<T>> GetHooks() => hooks.ToArray();

		public IEnumerator<IHook<T>> GetEnumerator() => hooks.GetEnumerator();
		IEnumerator<IHook> IEnumerable<IHook>.GetEnumerator() => GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
