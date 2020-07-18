using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents a custom in-game ability.</para>
	/// </summary>
	public class CustomAbility
	{
		public CustomItem Item { get; }

		public string Id => Item.Id;
		public Sprite Sprite
		{
			get => Item.Sprite;
			set => Item.Sprite = value;
		}

		internal CustomAbility(CustomItem item) => Item = item;

		/// <summary>
		///   <para>Delegate that will be used to determine the special ability's target object. See <see cref="StatusEffects.FindSpecialAbilityObject"/> for more details.</para>
		///   <para><see cref="Agent"/> arg is the special ability's owner.</para>
		/// </summary>
		public Func<Agent, InvItem, PlayfieldObject> FindObject { get; set; }
		/// <summary>
		///   <para>Delegate that will be used to determine whether a special ability indicator will be shown. See <see cref="StatusEffects.SpecialAbilityInterfaceCheck"/> for more details.</para>
		///   <para><see cref="Agent"/> arg1 is the special ability's owner;<br/><see cref="PlayfieldObject"/> arg2 is the target object that was found using <see cref="FindObject"/> delegate.</para>
		/// </summary>
		public Action<Agent, InvItem, PlayfieldObject> InterfaceCheck { get; set; }
		/// <summary>
		///   <para>Delegate that will be used to determine the special ability's recharge period.</para>
		/// </summary>
		public Func<Agent, InvItem, WaitForSeconds> RechargePeriod { get; set; }
		/// <summary>
		///   <para>Delegate that will be used to determine the recharging process for the special ability.</para>
		/// </summary>
		public Action<Agent, InvItem> Recharge { get; set; }
		/// <summary>
		///   <para>Delegate that will be invoked when the player presses the special ability button. See <see cref="StatusEffects.PressedSpecialAbility"/> for more details.</para>
		///   <para><see cref="Agent"/> arg1 is the special ability's owner;<br/><see cref="PlayfieldObject"/> arg2 is the target object that was found using <see cref="FindObject"/> delegate.</para>
		/// </summary>
		public Action<Agent, InvItem, PlayfieldObject> OnPressed { get; set; }
		/// <summary>
		///   <para>Delegate that will be invoked when the player holds the special ability button. See <see cref="StatusEffects.HeldSpecialAbility"/> for more details.</para>
		///   <para><see cref="Agent"/> arg1 is the special ability's owner;<br/><see cref="PlayfieldObject"/> arg2 is the target object that was found using <see cref="FindObject"/> delegate.</para>
		/// </summary>
		public Action<Agent, InvItem> OnHeld { get; set; }
		/// <summary>
		///   <para>Delegate that will be invoked when the player releases the special ability button. See <see cref="StatusEffects.ReleasedSpecialAbility"/> for more details.</para>
		///   <para><see cref="Agent"/> arg1 is the special ability's owner;<br/><see cref="PlayfieldObject"/> arg2 is the target object that was found using <see cref="FindObject"/> delegate.</para>
		/// </summary>
		public Action<Agent, InvItem> OnReleased { get; set; }

	}
}
