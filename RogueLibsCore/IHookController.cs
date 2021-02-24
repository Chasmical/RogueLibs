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
		THook AddHook<THook>() where THook : IHook, new();

		bool RemoveHook(IHook hook);
		bool RemoveHook<THook>();

		THook GetHook<THook>();
		IEnumerable<TType> GetHooks<TType>();
	}
	public interface IHookController<T> : IHookController, IEnumerable<IHook<T>>
	{
		void AddHook(IHook<T> hook);
		new THook AddHook<THook>() where THook : IHook<T>, new();

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
			if (hook is IHook<T> ihook) AddHook(ihook);
			else throw new ArgumentException("Invalid type!", nameof(hook));
		}
		THook IHookController.AddHook<THook>()
		{
			THook hook = new THook { Instance = Instance };
			if (hook is IHook<T> ihook)
			{
				AddHook(ihook);
				return hook;
			}
			else throw new ArgumentException("Invalid type!", nameof(THook));
		}

		public bool RemoveHook(IHook<T> hook) => hooks.Remove(hook);
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

		public THook GetHook<THook>() => (THook)hooks.Find(h => h is THook);
		public IEnumerable<TType> GetHooks<TType>() => hooks.OfType<TType>();

		public IEnumerator<IHook<T>> GetEnumerator() => hooks.GetEnumerator();
		IEnumerator<IHook> IEnumerable<IHook>.GetEnumerator() => GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
