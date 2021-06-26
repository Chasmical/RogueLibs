using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RogueLibsCore
{
	public interface IHookFactory
	{
		bool TryCreate(object instance, out IHook hook);
	}
	public interface IHookFactory<T> : IHookFactory
	{
		bool TryCreate(T instance, out IHook<T> hook);
	}
	public abstract class HookFactoryBase<T> : IHookFactory<T>
	{
		public abstract bool TryCreate(T instance, out IHook<T> hook);
		bool IHookFactory.TryCreate(object instance, out IHook hook)
		{
			bool res = TryCreate((T)instance, out IHook<T> hookT);
			hook = hookT;
			return res;
		}
	}
}
