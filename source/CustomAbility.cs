using System;
using UnityEngine;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents a custom in-game ability.</para>
	/// </summary>
	public class CustomAbility : CustomUnlock
	{
		internal CustomAbility(string id, CustomName name, CustomName description) : base(id, name, description) { }

		public override string Type => "Ability";

		private bool available = true;
		public override bool Available
		{
			get => available;
			set
			{
				if (unlock != null)
					RogueLibs.PluginInstance.EnsureOne(GameController.gameController.sessionDataBig.abilityUnlocks, unlock, value);
				available = value;
			}
		}

		public bool AvailableInCharacterCreation { get; set; } = true;
		// non-regular implementation (because there is no list for this kind of abilities)

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
