using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLibsCore
{
	public abstract class CustomAbility : CustomItem
	{
		public override void SetupDetails()
		{
			Item.stackable = true;
			Item.initCount = 0;
			Item.lowCountThreshold = 100;
		}

		public abstract void OnAdded();
		public abstract void OnPressed();
		internal float lastHeld;

		public PlayfieldObject CurrentTarget { get; internal set; }
	}
	public interface IAbilityChargeable
	{
		void OnHeld(OnAbilityHeldArgs e);
		void OnReleased(OnAbilityReleasedArgs e);
	}
	public class OnAbilityHeldArgs : EventArgs
	{
		public float HeldTime { get; set; }
		public void Interrupt() => HeldTime = 0f;
	}
	public class OnAbilityReleasedArgs : EventArgs
	{
		public OnAbilityReleasedArgs(float heldTime) => HeldTime = heldTime;
		public float HeldTime { get; }
	}
	public class OnAbilityRechargingArgs : EventArgs
	{
		public float UpdateDelay { get; set; }
	}
	public interface IAbilityRechargeable
	{
		void OnRecharge(OnAbilityRechargingArgs e);
	}
	public interface IAbilityTargetable
	{
		PlayfieldObject FindTarget();
	}
}
