using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Base interface for <see cref="CustomItemFactory{T}"/>.</para>
	/// </summary>
	public interface ICustomItemFactory : IHookFactory
	{
		/// <summary>
		///   <para>Default information about a custom item, specified in the type's attributes.</para>
		/// </summary>
		CustomItemInfo ItemInfo { get; }
	}
	/// <summary>
	///   <para>Represents a specialized <see cref="IHookFactory{T}"/> for the <typeparamref name="TItem"/> custom item type.</para>
	/// </summary>
	/// <typeparam name="TItem">Custom item's type.</typeparam>
	public sealed class CustomItemFactory<TItem> : HookFactoryBase<InvItem>, ICustomItemFactory where TItem : CustomItem, new()
	{
		/// <summary>
		///   <para>Default information about a custom item, specified in the type's attributes.</para>
		/// </summary>
		public CustomItemInfo ItemInfo { get; } = CustomItemInfo.Get(typeof(TItem));
		/// <summary>
		///   <para>Determines whether this factory can create a hook for the specified <paramref name="obj"/> (if its name matches the custom item's name).</para>
		/// </summary>
		/// <param name="obj"><see cref="InvItem"/> object.</param>
		/// <returns><see langword="true"/>, if this factory can create a hook for the specified <paramref name="obj"/> (if its name matches the custom item's name); otherwise, <see langword="false"/>.</returns>
		public override bool CanCreate(InvItem obj) => obj.invItemName == ItemInfo.Name;
		/// <summary>
		///   <para>Creates a new instance of the <typeparamref name="TItem"/> type for the specified <paramref name="obj"/>.</para>
		/// </summary>
		/// <param name="obj"><see cref="InvItem"/> object.</param>
		/// <returns><typeparamref name="TItem"/> custom item hook, that was created for the specified <paramref name="obj"/>.</returns>
		public override IHook<InvItem> CreateHook(InvItem obj)
		{
			IHook<InvItem> hook = new TItem() { ItemInfo = ItemInfo };
			hook.Instance = obj;
			return hook;
		}
	}
}
