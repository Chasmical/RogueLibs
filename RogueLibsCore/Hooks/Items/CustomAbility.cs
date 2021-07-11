using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents a custom ability.</para>
	/// </summary>
	public abstract class CustomAbility : CustomItem
	{
		/// <inheritdoc/>
		public override void SetupDetails()
		{
			Item.stackable = true;
			Item.initCount = 0;
			Item.lowCountThreshold = 100;
		}

		/// <summary>
		///   <para>The method that is called when the special ability is added.</para>
		/// </summary>
		public abstract void OnAdded();
		/// <summary>
		///   <para>The method that is called when the special ability is pressed.</para>
		/// </summary>
		public abstract void OnPressed();
		internal float lastHeld;

		/// <summary>
		///   <para>Gets the last <see cref="PlayfieldObject"/> returned by the <see cref="IAbilityTargetable.FindTarget"/> method.</para>
		/// </summary>
		public PlayfieldObject CurrentTarget { get; internal set; }
	}
	/// <summary>
	///   <para>Indicates that a custom ability is chargeable.</para>
	/// </summary>
	public interface IAbilityChargeable
	{
		/// <summary>
		///   <para>The method that is called each frame when the special ability is held.</para>
		/// </summary>
		/// <param name="e">The custom ability's holding data.</param>
		void OnHeld(OnAbilityHeldArgs e);
		/// <summary>
		///   <para>The method that is called when the special ability is released.</para>
		/// </summary>
		/// <param name="e">The custom ability's release data.</param>
		void OnReleased(OnAbilityReleasedArgs e);
	}
	/// <summary>
	///   <para>Represents the custom ability's holding args.</para>
	/// </summary>
	public class OnAbilityHeldArgs : EventArgs
	{
		/// <summary>
		///   <para>Gets or sets the current holding time, in seconds.</para>
		/// </summary>
		public float HeldTime { get; set; }
		/// <summary>
		///   <para>Interrupts the custom ability's holding.</para>
		/// </summary>
		public void Interrupt() => HeldTime = 0f;
	}
	/// <summary>
	///   <para>Represents the custom ability's released args.</para>
	/// </summary>
	public class OnAbilityReleasedArgs : EventArgs
	{
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="OnAbilityReleasedArgs"/> class with the specified <paramref name="heldTime"/>.</para>
		/// </summary>
		/// <param name="heldTime">The custom ability's held time.</param>
		public OnAbilityReleasedArgs(float heldTime) => HeldTime = heldTime;
		/// <summary>
		///   <para>Gets the last holding time, in seconds.</para>
		/// </summary>
		public float HeldTime { get; }
	}
	/// <summary>
	///   <para>Indicates that a custom ability is rechargeable.</para>
	/// </summary>
	public interface IAbilityRechargeable
	{
		/// <summary>
		///   <para>The method that is called as a part of the special ability's recharging coroutine.</para>
		/// </summary>
		/// <param name="e">The custom ability's recharging data.</param>
		void OnRecharge(OnAbilityRechargingArgs e);
	}
	/// <summary>
	///   <para>Represents the custom ability's recharging args.</para>
	/// </summary>
	public class OnAbilityRechargingArgs : EventArgs
	{
		/// <summary>
		///   <para>Gets or sets the recharging coroutine's update delay, in seconds.</para>
		/// </summary>
		public float UpdateDelay { get; set; }
		/// <summary>
		///   <para>Gets or sets whether to display the Recharged text, when the custom ability is recharged.</para>
		/// </summary>
		public bool ShowRechargedText { get; set; }
	}
	/// <summary>
	///   <para>Indicates that a custom ability is targetable.</para>
	/// </summary>
	public interface IAbilityTargetable
	{
		/// <summary>
		///   <para>The method that is called to determine what the special ability owner can use the ability on.</para>
		/// </summary>
		/// <returns>The target object, if the special ability can be used; otherwise, <see langword="null"/>.</returns>
		PlayfieldObject FindTarget();
	}
}
