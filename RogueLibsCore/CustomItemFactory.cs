using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace RogueLibsCore
{
	public interface ICustomItemFactory
	{
		CustomItemInfo ItemInfo { get; }
	}
	public sealed class CustomItemFactory<T> : HookFactoryBase<InvItem>, ICustomItemFactory where T : CustomItem, new()
	{
		public CustomItemInfo ItemInfo { get; } = CustomItemInfo.Get(typeof(T));
		public override bool CanCreate(InvItem obj) => obj.invItemName == ItemInfo.Name;
		public override IHook<InvItem> CreateHook(InvItem obj)
		{
			IHook<InvItem> hook = new T() { ItemInfo = ItemInfo };
			hook.Instance = obj;
			return hook;
		}
	}
}
