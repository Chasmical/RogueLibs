using System;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents a custom in-game item.</para>
	/// </summary>
	public class CustomItem : IComparable<CustomItem>
	{
		/// <summary>
		///   <para>Id of this <see cref="CustomItem"/>.</para>
		/// </summary>
		public string Id { get; }

		/// <summary>
		///   <para>Determines the position of this <see cref="CustomItem"/> in the list.</para>
		/// </summary>
		public int SortingOrder { get; set; } = -1;
		/// <summary>
		///   <para>Determines the position of this <see cref="CustomItem"/> in the list, if its SortingOrder equals to another's SortingOrder.</para>
		/// </summary>
		public int SortingIndex { get; set; } = 0;

		int IComparable<CustomItem>.CompareTo(CustomItem other)
		{
			int res = SortingOrder.CompareTo(other.SortingOrder);
			return res != 0 ? res : SortingIndex.CompareTo(other.SortingIndex);
		}

		/// <summary>
		///   <para>Localizable name of this <see cref="CustomItem"/>.</para>
		/// </summary>
		public CustomName Name { get; }
		/// <summary>
		///   <para>Localizable description of this <see cref="CustomItem"/>.</para>
		/// </summary>
		public CustomName Description { get; }

		/// <summary>
		///   <para>Determines whether this <see cref="CustomItem"/> is unlocked.</para>
		/// </summary>
		public bool Unlocked { get; set; } = true;
		/// <summary>
		///   <para>Determines whether this <see cref="CustomItem"/> will be displayed.</para>
		/// </summary>
		public bool ShowInMenu { get; set; } = true;

		internal CustomItem(string id, CustomName name, CustomName description)
		{
			Id = id;
			Name = name;
			Description = description;
		}

		private Sprite sprite;
		/// <summary>
		///   <para><see cref="UnityEngine.Sprite"/> that will be used for this <see cref="CustomItem"/>.</para>
		/// </summary>
		public Sprite Sprite
		{
			get => sprite;
			set
			{
				GameResources gr = GameController.gameController.gameResources;

				int index = gr.itemList.IndexOf(sprite);
				if (index != -1) gr.itemList[index] = sprite = value;
				else gr.itemList.Add(sprite = value);

				if (gr.itemDic.ContainsKey(Id)) gr.itemDic[Id] = value;
				else gr.itemDic.Add(Id, value);
			}
		}

		/// <summary>
		///   <para>Method that will be invoked when setting up this custom item. See <see cref="InvItem.SetupDetails(bool)"/> for more details.</para>
		///   <para><see cref="InvItem"/> obj is this custom item.</para>
		/// </summary>
		public Action<InvItem> SetupDetails { get; set; }
		/// <summary>
		///   <para>Method that will be invoked when this custom item is used/consumed on right-click. See <see cref="ItemFunctions.UseItem(InvItem, Agent)"/> for more details.</para>
		///   <para><see cref="InvItem"/> arg1 is this custom item;<br/><see cref="Agent"/> arg2 is the custom item's owner.</para>
		/// </summary>
		public Action<InvItem, Agent> UseItem { get; set; }

		/// <summary>
		///   <para>Method that will be used to determine whether an item can be combined with this item.</para>
		///   <para><see cref="InvItem"/> arg1 is this custom item;<br/><see cref="Agent"/> arg2 is the custom item's owner;<br/><see cref="InvItem"/> arg3 is the other item.</para>
		/// </summary>
		public Func<InvItem, Agent, InvItem, bool> CombineFilter { get; set; }
		/// <summary>
		///   <para>Method that will be invoked when this custom item is combined with another item. See <see cref="ItemFunctions.CombineItems(InvItem, Agent, InvItem, int, string)"/> for more details.</para>
		///   <para><see cref="InvItem"/> arg1 is this custom item;<br/><see cref="Agent"/> arg2 is the custom item's owner;<br/><see cref="InvItem"/> arg3 is the other item.</para>
		/// </summary>
		public Action<InvItem, Agent, InvItem> CombineItems { get; set; }
		/// <summary>
		///   <para>Method that will be used to determine the combine tooltip text.</para>
		///   <para><see cref="InvItem"/> arg1 is this custom item;<br/><see cref="Agent"/> arg2 is the custom item's owner;<br/><see cref="InvItem"/> arg3 is the other item.</para>
		/// </summary>
		public Func<InvItem, Agent, InvItem, string> CombineTooltip { get; set; }

		/// <summary>
		///   <para>Method that will be used to determine whether an object can be targeted by this custom item.</para>
		///   <para><see cref="InvItem"/> arg1 is this custom item;<br/><see cref="Agent"/> arg2 is the custom item's owner;<br/><see cref="PlayfieldObject"/> arg3 is the targeted object.</para>
		/// </summary>
		public Func<InvItem, Agent, PlayfieldObject, bool> TargetFilter { get; set; }
		/// <summary>
		///   <para>Method that will be invoked when this custom item is used on an object. See <see cref="ItemFunctions.TargetObject(InvItem, Agent, PlayfieldObject, string)"/> for more details.</para>
		///   <para><see cref="InvItem"/> arg1 is this custom item;<br/><see cref="Agent"/> arg2 is the custom item's owner;<br/><see cref="PlayfieldObject"/> arg3 is the targeted object.</para>
		/// </summary>
		public Action<InvItem, Agent, PlayfieldObject> TargetObject { get; set; }
		/// <summary>
		///   <para>Localizable text that will be displayed when targeting objects.</para>
		/// </summary>
		public CustomName TargetText { get; private set; }

		/// <summary>
		///   <para>Creates a new <see cref="CustomName"/> and sets <see cref="TargetText"/> to it.</para>
		/// </summary>
		public CustomName SetTargetText(CustomNameInfo info) => RogueLibs.CreateCustomName("Verb" + Id, "Interface", info);

	}
}