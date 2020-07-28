using System;
using UnityEngine;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents a custom in-game ability.</para>
	/// </summary>
	public class CustomAbility : CustomUnlock, IComparable<CustomAbility>
	{
		internal CustomAbility(string id, CustomName name, CustomName description) : base(id, name, description) { }

		/// <summary>
		///   <para>Compares this <see cref="CustomAbility"/> with <paramref name="another"/>.</para>
		/// </summary>
		public int CompareTo(CustomAbility another) => base.CompareTo(another);

		/// <summary>
		///   <para>Type of this <see cref="CustomUnlock"/> - "Ability".</para>
		/// </summary>
		public override string Type => "Ability";

		private bool available = true;
		/// <summary>
		///   <para>Determines whether this <see cref="CustomAbility"/> will be accessible in-game. (Default: <see langword="true"/>)</para>
		/// </summary>
		public override bool Available
		{
			get => unlock != null ? (available = !unlock.unavailable) : available;
			set
			{
				if (unlock != null)
				{
					RogueLibs.PluginInstance.EnsureOne(GameController.gameController.sessionDataBig.abilityUnlocks, unlock, value);
					if (available && !value) Unlock.abilityCount--;
					else if (!available && value) Unlock.abilityCount++;
					unlock.unavailable = !value;
				}
				available = value;
			}
		}

		/// <summary>
		///   <para>Determines whether this <see cref="CustomAbility"/> will be accessible in the Character Creation menu. (Default: <see langword="true"/>)</para>
		/// </summary>
		public bool AvailableInCharacterCreation { get; set; } = true;
		// non-regular implementation (because there is no list for this kind of abilities)

		private int costInCharacterCreation = 1;
		/// <summary>
		///   <para>Determines the cost of this <see cref="CustomAbility"/> in the Character Creation menu, in points. (Default: 1)</para>
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

		/// <summary>
		///   <para>Method that will be invoked when setting up this custom ability. See <see cref="InvItem.SetupDetails(bool)"/> for more details.</para>
		///   <para><see cref="InvItem"/> obj is this custom ability.</para>
		/// </summary>
		public Action<InvItem> SetupDetails { get; set; }

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
		///   <para>Method that will be invoked when the player releases the special ability button (or presses the left mouse button).</para>
		///   <para><see cref="InvItem"/> arg1 is this custom ability;<br/><see cref="Agent"/> arg2 is the custom ability's owner.</para>
		/// </summary>
		public Action<InvItem, Agent> OnReleased { get; set; }

		/// <summary>
		///   <para>Method that will be used in the <see cref="CharacterCreation.PushedButton(ButtonHelper)"/> patch.</para>
		///   <para><see cref="CharacterCreation"/> arg1 is the current instance of <see cref="CharacterCreation"/>;<br/><see cref="ButtonHelper"/> arg2 is this ability's <see cref="ButtonHelper"/>;<br/><see cref="bool"/> result determines whether the original RogueLibs patch should be executed.</para>
		/// </summary>
		public Func<CharacterCreation, ButtonHelper, bool> CharacterCreation_PushedButton { get; set; }

		/// <summary>
		///   <para>Event that is invoked when this ability is toggled on/off in the Character Creation menu.</para>
		///   <para><see cref="CharacterCreation"/> arg1 is the current instance of <see cref="CharacterCreation"/>;<br/><see cref="ButtonHelper"/> arg2 is this ability's <see cref="ButtonHelper"/>;<br/><see cref="bool"/> arg3 is the new state.</para>
		/// </summary>
		public event Action<CharacterCreation, ButtonHelper, bool> OnToggledInCharacterCreation;
		/// <summary>
		///   <para>Event that is invoked when this ability is unlocked in the Character Creation menu.</para>
		///   <para><see cref="CharacterCreation"/> arg1 is the current instance of <see cref="CharacterCreation"/>;<br/><see cref="ButtonHelper"/> arg2 is this ability's <see cref="ButtonHelper"/>.</para>
		/// </summary>
		public event Action<CharacterCreation, ButtonHelper> OnUnlockedInCharacterCreation;

		internal void InvokeOnToggledEvent(CharacterCreation cc, ButtonHelper bh, bool newState) => OnToggledInCharacterCreation?.Invoke(cc, bh, newState);
		internal void InvokeOnUnlockedEvent(CharacterCreation cc, ButtonHelper bh) => OnUnlockedInCharacterCreation?.Invoke(cc, bh);

	}

	/// <summary>
	///   <para>Helper delegate for <see cref="CustomAbility.OnHeld"/> event.</para>
	/// </summary>
	public delegate void ActionRef<T1, T2, Tref>(T1 arg1, T2 arg2, ref Tref arg3);
}
