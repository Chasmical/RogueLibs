using System;
using UnityEngine;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents a custom in-game ability.</para>
	/// </summary>
	public class CustomAbility : IComparable<CustomAbility>
	{
		/// <summary>
		///   <para>Id of this <see cref="CustomAbility"/>.</para>
		/// </summary>
		public string Id => Item.Id;

		/// <summary>
		///   <para>Determines the position of this <see cref="CustomAbility"/> in the list.</para>
		/// </summary>
		public int SortingOrder
		{
			get => Item.SortingOrder;
			set => Item.SortingOrder = value;
		}
		/// <summary>
		///   <para>Determines the position of this <see cref="CustomAbility"/> in the list, if its SortingOrder equals to another's SortingOrder.</para>
		/// </summary>
		public int SortingIndex
		{
			get => Item.SortingIndex;
			set => Item.SortingIndex = value;
		}

		int IComparable<CustomAbility>.CompareTo(CustomAbility other)
		{
			int res = SortingOrder.CompareTo(other.SortingOrder);
			return res != 0 ? res : SortingIndex.CompareTo(other.SortingIndex);
		}

		/// <summary>
		///   <para>Localizable name of this <see cref="CustomAbility"/>.</para>
		/// </summary>
		public CustomName Name => Item.Name;
		/// <summary>
		///   <para>Localizable description of this <see cref="CustomAbility"/>.</para>
		/// </summary>
		public CustomName Description => Item.Description;

		/// <summary>
		///   <para>Determines whether this <see cref="CustomAbility"/> is unlocked.</para>
		/// </summary>
		public bool Unlocked
		{
			get => Item.Unlocked;
			set => Item.Unlocked = value;
		}
		/// <summary>
		///   <para>Determines whether this <see cref="CustomAbility"/> will be displayed.</para>
		/// </summary>
		public bool ShowInMenu
		{
			get => Item.ShowInMenu;
			set => Item.ShowInMenu = value;
		}

		internal CustomAbility(CustomItem item) => Item = item;

		/// <summary>
		///   <para><see cref="UnityEngine.Sprite"/> that will be used for this <see cref="CustomAbility"/>.</para>
		/// </summary>
		public Sprite Sprite
		{
			get => Item.Sprite;
			set => Item.Sprite = value;
		}
		/// <summary>
		///   <para><see cref="CustomItem"/> of this <see cref="CustomAbility"/>.</para>
		/// </summary>
		public CustomItem Item { get; }

		/// <summary>
		///   <para>Method that will be used to determine an object that the special ability indicator should be displayed over. Return <see langword="null"/> to hide the indicator.</para>
		///   <para><see cref="InvItem"/> arg1 is this custom ability;<br/><see cref="Agent"/> arg2 is the custom ability's owner.</para>
		/// </summary>
		public Func<InvItem, Agent, PlayfieldObject> IndicatorCheck { get; set; }

		/// <summary>
		///   <para>Method that will be used to determine the recharging period of this custom ability. Return <see langword="null"/> if the ability is not recharging.</para>
		///   <para><see cref="InvItem"/> arg1 is this custom ability;<br/><see cref="Agent"/> arg2 is the custom ability's owner.</para>
		/// </summary>
		public Func<InvItem, Agent, WaitForSeconds> RechargeInterval { get; set; }
		/// <summary>
		///   <para>Method that will be invoked when recharging this custom ability.</para>
		///   <para><see cref="InvItem"/> arg1 is this custom ability;<br/><see cref="Agent"/> arg2 is the custom ability's owner.</para>
		/// </summary>
		public Action<InvItem, Agent> Recharge { get; set; }

		/// <summary>
		///   <para>Method that will be invoked when the player presses the special ability button.</para>
		///   <para><see cref="InvItem"/> arg1 is this custom ability;<br/><see cref="Agent"/> arg2 is the custom ability's owner.</para>
		/// </summary>
		public Action<InvItem, Agent> OnPressed { get; set; }
		/// <summary>
		///   <para>Method that will be invoked when the player holds the special ability button.</para>
		///   <para><see cref="InvItem"/> arg1 is this custom ability;<br/><see cref="Agent"/> arg2 is the custom ability's owner;<br/><see cref="float"/> arg3 is time in seconds that the player was holding the button.</para>
		/// </summary>
		public ActionRef<InvItem, Agent, float> OnHeld { get; set; }
		/// <summary>
		///   <para>Method that will be invoked when the player releases the special ability button.</para>
		///   <para><see cref="InvItem"/> arg1 is this custom ability;<br/><see cref="Agent"/> arg2 is the custom ability's owner;<br/><see cref="float"/> arg3 is time in seconds that the player was holding the button.</para>
		/// </summary>
		public Action<InvItem, Agent> OnReleased { get; set; }

	}

	/// <summary>
	///   <para>Helper delegate for <see cref="CustomAbility.OnHeld"/> event.</para>
	/// </summary>
	public delegate void ActionRef<T1, T2, Tref>(T1 arg1, T2 arg2, ref Tref arg3);
}
