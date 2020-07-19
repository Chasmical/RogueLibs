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
		/// <summary>
		///   <para><see cref="CustomItem"/> of this <see cref="CustomAbility"/>.</para>
		/// </summary>
		public CustomItem Item { get; }

		/// <summary>
		///   <para>Id of this <see cref="CustomAbility"/>.</para>
		/// </summary>
		public string Id => Item.Id;
		/// <summary>
		///   <para><see cref="UnityEngine.Sprite"/> of this <see cref="CustomAbility"/>.</para>
		/// </summary>
		public Sprite Sprite
		{
			get => Item.Sprite;
			set => Item.Sprite = value;
		}

		/// <summary>
		///   <para>Localizable name if this <see cref="CustomAbility"/>.</para>
		/// </summary>
		public CustomName Name
		{
			get => Item.Name;
			set => Item.Name = value;
		}
		/// <summary>
		///   <para>Localizable description if this <see cref="CustomAbility"/>.</para>
		/// </summary>
		public CustomName Description
		{
			get => Item.Description;
			set => Item.Description = value;
		}

		internal CustomAbility(CustomItem item) => Item = item;

		/// <summary>
		///   <para>Delegate that will be used to display special ability's indicator. See <see cref="StatusEffects.SpecialAbilityInterfaceCheck"/> for more details.</para>
		///   <para><see cref="Agent"/> arg1 is the special ability's owner;<br/><see cref="InvItem"/> arg2 is special ability's item.</para>
		/// </summary>
		public Action<InvItem, Agent> InterfaceCheck { get; set; }
		/// <summary>
		///   <para>Delegate that will be used to determine the special ability's recharge period.</para>
		///   <para><see cref="Agent"/> arg1 is the special ability's owner;<br/><see cref="InvItem"/> arg2 is special ability's item;<br/><see cref="WaitForSeconds"/> result is the interval between invoking <see cref="Recharge"/> delegate.</para>
		/// </summary>
		public Func<InvItem, Agent, WaitForSeconds> RechargePeriod { get; set; }
		/// <summary>
		///   <para>Delegate that will be used to determine the recharging process for the special ability. See <see cref="StatusEffects.RechargeSpecialAbility(string)"/> for more details.</para>
		///   <para><see cref="Agent"/> arg1 is the special ability's owner;<br/><see cref="InvItem"/> arg2 is special ability's item.</para>
		/// </summary>
		public Action<InvItem, Agent> Recharge { get; set; }
		/// <summary>
		///   <para>Delegate that will be invoked when the player presses the special ability button. See <see cref="StatusEffects.PressedSpecialAbility"/> for more details.</para>
		///   <para><see cref="Agent"/> arg1 is the special ability's owner;<br/><see cref="InvItem"/> arg2 is special ability's item.</para>
		/// </summary>
		public Action<InvItem, Agent> OnPressed { get; set; }
		/// <summary>
		///   <para>Delegate that will be invoked when the player holds the special ability button. See <see cref="StatusEffects.HeldSpecialAbility"/> for more details.</para>
		///   <para><see cref="Agent"/> arg1 is the special ability's owner;<br/><see cref="InvItem"/> arg2 is special ability's item.</para>
		/// </summary>
		public Action<InvItem, Agent> OnHeld { get; set; }
		/// <summary>
		///   <para>Delegate that will be invoked when the player releases the special ability button. See <see cref="StatusEffects.ReleasedSpecialAbility"/> for more details.</para>
		///   <para><see cref="Agent"/> arg1 is the special ability's owner;<br/><see cref="InvItem"/> arg2 is special ability's item.</para>
		/// </summary>
		public Action<InvItem, Agent> OnReleased { get; set; }

	}
}
