using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLibsCore
{
	public abstract class CustomAbility : CustomItem
	{
		public abstract void OnAdded();
		public abstract void OnPressed();
		public abstract void OnHeld(OnAbilityHeldArgs e);
		public abstract void OnReleased(OnAbilityReleasedArgs e);
		public abstract void OnUpdated(OnAbilityUpdatedArgs e);
		internal float lastHeld;

		public PlayfieldObject CurrentTarget { get; internal set; }
		public abstract PlayfieldObject FindTarget();
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
	public class OnAbilityUpdatedArgs : EventArgs
	{
		public float NextDelay { get; set; }
	}
}
