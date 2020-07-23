using System;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents a custom in-game item.</para>
	/// </summary>
	public class CustomItem : CustomUnlock
	{
		internal CustomItem(string id, CustomName name, CustomName description) : base(id, name, description) { }

		public override string Type => "Item";

		private bool available = true;
		public override bool Available
		{
			get => available;
			set
			{
				if (unlock != null)
					RogueLibs.PluginInstance.EnsureOne(GameController.gameController.sessionDataBig.itemUnlocks, unlock, value);
				available = value;
			}
		}

		private bool availableInCharacterCreation = true;
		public bool AvailableInCharacterCreation
		{
			get => availableInCharacterCreation;
			set
			{
				if (unlock != null)
					RogueLibs.PluginInstance.EnsureOne(GameController.gameController.sessionDataBig.itemUnlocksCharacterCreation, unlock, value);
				availableInCharacterCreation = value;
			}
		}

		private bool availableInItemTeleporter = true;
		public bool AvailableInItemTeleporter
		{
			get => availableInItemTeleporter;
			set
			{
				if (unlock != null)
					RogueLibs.PluginInstance.EnsureOne(GameController.gameController.sessionDataBig.freeItemUnlocks, unlock, value);
				availableInItemTeleporter = value;
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