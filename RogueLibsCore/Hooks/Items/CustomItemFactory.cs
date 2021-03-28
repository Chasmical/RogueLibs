using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Base interface for <see cref="CustomItemFactory{TItem}"/>.</para>
	/// </summary>
	public interface ICustomItemFactory : IHookFactory
	{
		/// <summary>
		///   <para>Default information about a custom item, defined in the type's attributes.</para>
		/// </summary>
		CustomItemInfo ItemInfo { get; }
	}
	/// <summary>
	///   <para>Represents a specialized <see cref="IHookFactory{T}"/> for the <typeparamref name="TItem"/> custom item type.</para>
	/// </summary>
	/// <typeparam name="TItem">Custom item's type.</typeparam>
	public sealed class CustomItemFactory<TItem> : HookFactoryBase<InvItem>, ICustomItemFactory where TItem : CustomItem, new()
	{
		/// <inheritdoc/>
		public CustomItemInfo ItemInfo { get; } = CustomItemInfo.Get(typeof(TItem));
		/// <inheritdoc/>
		public override bool CanCreate(InvItem obj) => !(obj is null) && obj.invItemName == ItemInfo.Name;
		/// <inheritdoc/>
		public override IHook<InvItem> CreateHook(InvItem obj)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			IHook<InvItem> hook = new TItem() { ItemInfo = ItemInfo };
			hook.Instance = obj;
			return hook;
		}
	}
}
