using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RogueLibsCore
{
	public interface IHookFactory
	{
		bool CanCreate(object obj);
		IHook CreateHook(object obj);
	}
	public interface IHookFactory<T> : IHookFactory
	{
		bool CanCreate(T obj);
		IHook<T> CreateHook(T obj);
	}
	public abstract class HookFactoryBase<T> : IHookFactory<T>
	{
		public abstract bool CanCreate(T obj);
		public abstract IHook<T> CreateHook(T obj);

		bool IHookFactory.CanCreate(object obj) => obj is T t && CanCreate(t);
		IHook IHookFactory.CreateHook(object obj) => CreateHook((T)obj);
	}
}
