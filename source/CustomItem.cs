using System;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents a custom in-game item.</para>
	/// </summary>
	public class CustomItem : CustomUnlock, IComparable<CustomItem>
	{
		internal CustomItem(string id, CustomName name, CustomName description) : base(id, name, description) { }

		/// <summary>
		///   <para>Compares this <see cref="CustomItem"/> with <paramref name="another"/>.</para>
		/// </summary>
		public int CompareTo(CustomItem another) => base.CompareTo(another);

		/// <summary>
		///   <para>Type of this <see cref="CustomUnlock"/> - "Item".</para>
		/// </summary>
		public override string Type => "Item";

		private bool isActive = true;
		/// <summary>
		///   <para>Determines whether this <see cref="CustomItem"/> is active and will be obtainable in-game. (Default: <see langword="true"/>)</para>
		/// </summary>
		public bool IsActive
		{
			get => unlock != null ? (isActive = !unlock.notActive) : isActive;
			set
			{
				if (unlock != null)
					unlock.notActive = !value;
				isActive = value;
			}
		}

		private bool available = true;
		/// <summary>
		///   <para>Determines whether this <see cref="CustomItem"/> will be accessible in the Rewards Menu and in-game. (Default: <see langword="true"/>)</para>
		/// </summary>
		public override bool Available
		{
			get => unlock != null ? (available = !unlock.unavailable) : available;
			set
			{
				if (unlock != null)
				{
					RogueLibs.PluginInstance.EnsureOne(GameController.gameController.sessionDataBig.itemUnlocks, unlock, value);
					if (available && !value) Unlock.itemCount--;
					else if (!available && value) Unlock.itemCount++;
					unlock.unavailable = !value;
				}
				available = value;
			}
		}

		private bool availableInCharacterCreation = true;
		/// <summary>
		///   <para>Determines whether this <see cref="CustomItem"/> will be accessible in the Character Creation menu. (Default: <see langword="true"/>)</para>
		/// </summary>
		public bool AvailableInCharacterCreation
		{
			get => unlock != null ? (availableInCharacterCreation = !unlock.unavailable || unlock.onlyInCharacterCreation) : availableInCharacterCreation;
			set
			{
				if (unlock != null)
				{
					RogueLibs.PluginInstance.EnsureOne(GameController.gameController.sessionDataBig.itemUnlocksCharacterCreation, unlock, value);
					if (available && !value) Unlock.itemCountCharacterCreation--;
					else if (!available && value) Unlock.itemCountCharacterCreation++;
					unlock.onlyInCharacterCreation = !available && value;
				}
				availableInCharacterCreation = value;
			}
		}

		private bool availableInItemTeleporter = true;
		/// <summary>
		///   <para>Determines whether this <see cref="CustomItem"/> will be accessible in the Item Teleporter menu. (Default: <see langword="true"/>)</para>
		/// </summary>
		public bool AvailableInItemTeleporter
		{
			get => unlock != null ? (availableInItemTeleporter = unlock.freeItem) : availableInItemTeleporter;
			set
			{
				if (unlock != null)
				{
					RogueLibs.PluginInstance.EnsureOne(GameController.gameController.sessionDataBig.freeItemUnlocks, unlock, value);
					if (available && !value) Unlock.itemCountFree--;
					else if (!available && value) Unlock.itemCountFree++;
					unlock.freeItem = value;
				}
				availableInItemTeleporter = value;
			}
		}

		private int costInCharacterCreation = 1;
		/// <summary>
		///   <para>Determines the cost of this <see cref="CustomItem"/> in the Character Creation menu, in points. (Default: 1)</para>
		/// </summary>
		public int CostInCharacterCreation
		{
			get => unlock != null ? (costInCharacterCreation = unlock.cost3) : costInCharacterCreation;
			set
			{
				if (unlock != null)
					unlock.cost3 = value;
				costInCharacterCreation = value;
			}
		}

		private int costInLoadout = 1;
		/// <summary>
		///   <para>Determines the cost of this <see cref="CustomItem"/> in the Loadout Menu, in nuggets. (Default: 1)</para>
		/// </summary>
		public int CostInLoadout
		{
			get => unlock != null ? (costInLoadout = unlock.cost2) : costInLoadout;
			set
			{
				if (unlock != null)
					unlock.cost2 = value;
				costInLoadout = value;
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

		/// <summary>
		///   <para>Method that will be used in the <see cref="ScrollingMenu.PushedButton(ButtonHelper)"/> patch.</para>
		///   <para><see cref="ScrollingMenu"/> arg1 is the current instance of <see cref="ScrollingMenu"/>;<br/><see cref="ButtonHelper"/> arg2 is this item's <see cref="ButtonHelper"/>;<br/><see cref="bool"/> result determines whether the original RogueLibs patch should be executed.</para>
		/// </summary>
		public Func<ScrollingMenu, ButtonHelper, bool> ScrollingMenu_PushedButton { get; set; }
		/// <summary>
		///   <para>Method that will be used in the <see cref="CharacterCreation.PushedButton(ButtonHelper)"/> patch.</para>
		///   <para><see cref="CharacterCreation"/> arg1 is the current instance of <see cref="CharacterCreation"/>;<br/><see cref="ButtonHelper"/> arg2 is this item's <see cref="ButtonHelper"/>;<br/><see cref="bool"/> result determines whether the original RogueLibs patch should be executed.</para>
		/// </summary>
		public Func<CharacterCreation, ButtonHelper, bool> CharacterCreation_PushedButton { get; set; }

		/// <summary>
		///   <para>Event that is invoked when this item is toggled on/off in the Rewards Menu.</para>
		///   <para><see cref="ScrollingMenu"/> arg1 is the current instance of <see cref="ScrollingMenu"/>;<br/><see cref="ButtonHelper"/> arg2 is this item's <see cref="ButtonHelper"/>;<br/><see cref="bool"/> arg3 is the new state.</para>
		/// </summary>
		public event Action<ScrollingMenu, ButtonHelper, bool> OnToggledInRewardsMenu;
		/// <summary>
		///   <para>Event that is invoked when this item is unlocked in the Rewards Menu.</para>
		///   <para><see cref="ScrollingMenu"/> arg1 is the current instance of <see cref="ScrollingMenu"/>;<br/><see cref="ButtonHelper"/> arg2 is this item's <see cref="ButtonHelper"/>.</para>
		/// </summary>
		public event Action<ScrollingMenu, ButtonHelper> OnUnlockedInRewardsMenu;

		internal void InvokeOnToggledEvent(ScrollingMenu sm, ButtonHelper bh, bool newState) => OnToggledInRewardsMenu?.Invoke(sm, bh, newState);
		internal void InvokeOnUnlockedEvent(ScrollingMenu sm, ButtonHelper bh) => OnUnlockedInRewardsMenu?.Invoke(sm, bh);

		/// <summary>
		///   <para>Event that is invoked when this item is added/removed in the Character Creation menu.</para>
		///   <para><see cref="CharacterCreation"/> arg1 is the current instance of <see cref="CharacterCreation"/>;<br/><see cref="ButtonHelper"/> arg2 is this item's <see cref="ButtonHelper"/>;<br/><see cref="bool"/> arg3 is the new state.</para>
		/// </summary>
		public event Action<CharacterCreation, ButtonHelper, bool> OnToggledInCharacterCreation;
		/// <summary>
		///   <para>Event that is invoked when this item is unlocked in the Character Creation menu.</para>
		///   <para><see cref="CharacterCreation"/> arg1 is the current instance of <see cref="CharacterCreation"/>;<br/><see cref="ButtonHelper"/> arg2 is this item's <see cref="ButtonHelper"/>.</para>
		/// </summary>
		public event Action<CharacterCreation, ButtonHelper> OnUnlockedInCharacterCreation;

		internal void InvokeOnToggledEvent(CharacterCreation cc, ButtonHelper bh, bool newState) => OnToggledInCharacterCreation?.Invoke(cc, bh, newState);
		internal void InvokeOnUnlockedEvent(CharacterCreation cc, ButtonHelper bh) => OnUnlockedInCharacterCreation?.Invoke(cc, bh);
	}
}