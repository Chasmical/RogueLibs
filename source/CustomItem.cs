using System;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents a custom in-game item.</para>
	/// </summary>
	public class CustomItem
	{
		/// <summary>
		///   <para>Id of this <see cref="CustomItem"/>.</para>
		/// </summary>
		public string Id { get; }

		internal CustomItem(string id)
		{
			Id = id;
			SpawnDictionary = new Dictionary<string, int>();
		}

		/// <summary>
		///   <para>Delegate that will be invoked when setting up this custom item. See <see cref="InvItem.SetupDetails(bool)"/> for more details.</para>
		///   <para><see cref="InvItem"/> obj is this custom item.</para>
		/// </summary>
		public Action<InvItem> SetupDetails { get; set; }
		/// <summary>
		///   <para>Delegate that will be invoked when used/consumed on right-click. See <see cref="ItemFunctions.UseItem(InvItem, Agent)"/> for more details.</para>
		///   <para><see cref="InvItem"/> arg1 is this custom item;<br/><see cref="Agent"/> arg2 is the owner of this custom item.</para>
		/// </summary>
		public Action<InvItem, Agent> UseItem { get; set; }

		/// <summary>
		///   <para>Delegate that will be used to determine whether an object can be targeted by this item.</para>
		///   <para><see cref="InvItem"/> arg1 is this custom item;<br/><see cref="Agent"/> arg2 is the owner of this custom item;<br/><see cref="PlayfieldObject"/> arg3 is an object that is being targeted.</para>
		/// </summary>
		public Func<InvItem, Agent, PlayfieldObject, bool> TargetFilter { get; set; }
		/// <summary>
		///   <para>Delegate that will be invoked when used on an object. See <see cref="ItemFunctions.TargetObject(InvItem, Agent, PlayfieldObject, string)"/> for more details.</para>
		///   <para><see cref="InvItem"/> arg1 is this custom item;<br/><see cref="Agent"/> arg2 is the owner of this custom item;<br/><see cref="PlayfieldObject"/> arg3 is an object that is being targeted.</para>
		/// </summary>
		public Action<InvItem, Agent, PlayfieldObject> TargetObject { get; set; }
		/// <summary>
		///   <para>Text that will be displayed when targeting objects.</para>
		/// </summary>
		public CustomName HoverText { get; set; }

		/// <summary>
		///   <para>Delegate that will be used to determine whether an item can be combined with this item.</para>
		///   <para><see cref="InvItem"/> arg1 is this custom item;<br/><see cref="Agent"/> arg2 is the owner of this custom item;<br/><see cref="InvItem"/> arg3 is the other item.</para>
		/// </summary>
		public Func<InvItem, Agent, InvItem, bool> CombineFilter { get; set; }
		/// <summary>
		///   <para>Delegate that will be invoked when combined with an item. See <see cref="ItemFunctions.CombineItems(InvItem, Agent, InvItem, int, string)"/> for more details.</para>
		///   <para><see cref="InvItem"/> arg1 is this custom item;<br/><see cref="Agent"/> arg2 is the owner of this custom item;<br/><see cref="InvItem"/> arg3 is the other item;<br/><see cref="int"/> arg4 is the item's slot number.</para>
		/// </summary>
		public Action<InvItem, Agent, InvItem, int> CombineItem { get; set; }
		/// <summary>
		///   <para>Delegate that will be used to determine the tooltip text when combining items with this item. Return <see langword="null"/> or <see cref="string.Empty"/> to not add the tooltip text.</para>
		///   <para><see cref="InvItem"/> arg1 is this custom item;<br/><see cref="Agent"/> arg2 is the owner of this custom item;<br/><see cref="InvItem"/> arg3 is the other item.</para>
		/// </summary>
		public Func<InvItem, Agent, InvItem, string> CombineTooltip { get; set; }

		/// <summary>
		///   <para><see cref="Sprite"/> that will be used for this item.</para>
		/// </summary>
		public Sprite Sprite { get; set; }

		private CustomName name, description;

		/// <summary>
		///   <para>Localizable name of this <see cref="CustomItem"/>.</para>
		/// </summary>
		public CustomName Name
		{
			get
			{
				if (name == null)
					name = RogueLibs.GetCustomName(Id, "Item");
				return name;
			}
			set => name = value;
		}
		/// <summary>
		///   <para>Localizable description of this <see cref="CustomItem"/>.</para>
		/// </summary>
		public CustomName Description
		{
			get
			{
				if (description == null)
					description = RogueLibs.GetCustomName(Id, "Description");
				return description;
			}
			set => description = value;
		}

		/// <summary>
		///   <para>Dictionary of RandomLists' names that this item will spawn in and spawn chances. See <see cref="RandomItems.fillItems"/> for more details.</para>
		/// </summary>
		public Dictionary<string, int> SpawnDictionary { get; set; }

		/// <summary>
		///   <para>Sets this item's hover text.</para>
		/// </summary>
		public void SetHoverText(CustomNameInfo info) => HoverText = RogueLibs.SetCustomName("Verb" + Id, "Interface", info);
		/// <summary>
		///   <para>Adds this item to a <see cref="RandomList"/> with the specified <paramref name="listName"/>, with the specified <paramref name="spawnChance"/>. See <see cref="RandomItems.fillItems"/> for more info.</para>
		/// </summary>
		public void AddSpawnList(string listName, int spawnChance)
		{
			if (SpawnDictionary.ContainsKey(listName))
				SpawnDictionary[listName] = spawnChance;
			else
				SpawnDictionary.Add(listName, spawnChance);

			RandomList list = RogueLibs.GetRandomList(listName, "Items", "Item");
			if (list != null) GameController.gameController.rnd.CreateRandomElement(list, Id, spawnChance);
		}
	}
}