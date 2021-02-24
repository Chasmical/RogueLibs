using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RogueLibsCore
{
	public interface IHook
	{
		void Initialize();
		object Instance { get; set; }
	}
	public interface IHook<T> : IHook
	{
		new T Instance { get; set; }
	}
	public abstract class HookBase<T> : IHook<T>
	{
		public abstract void Initialize();
		protected T Instance { get; set; }
		T IHook<T>.Instance { get => Instance; set => Instance = (T)value; }
		object IHook.Instance { get => Instance; set => Instance = (T)value; }
	}
}
