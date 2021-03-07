using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using HarmonyLib;

namespace RogueLibsCore
{
	public class HomeBaseUnlock : UnlockWrapper
	{
		public HomeBaseUnlock(string name, bool unlockedFromStart = false) : base(name, "HomeBase", unlockedFromStart) { }
		internal HomeBaseUnlock(Unlock unlock) : base(unlock) { }

		public override bool IsEnabled
		{
			get => !Unlock.notActive;
			set => Unlock.notActive = !value;
		}
		public override bool IsAvailable
		{
			get => !Unlock.unavailable;
			set
			{
				Unlock.unavailable = !value;
				bool? cur = gc?.sessionDataBig?.homeBaseUnlocks?.Contains(Unlock);
				if (cur == true && !value) { gc.sessionDataBig.homeBaseUnlocks.Remove(Unlock); Unlock.homeBaseCount--; }
				else if (cur == false && value) { gc.sessionDataBig.homeBaseUnlocks.Add(Unlock); Unlock.homeBaseCount++; }
			}
		}
	}
	public class ExtraUnlock : UnlockWrapper
	{
		public ExtraUnlock(string name, bool unlockedFromStart = false) : base(name, "Extra", unlockedFromStart) { }
		internal ExtraUnlock(Unlock unlock) : base(unlock) { }

		public override bool IsEnabled
		{
			get => !Unlock.notActive;
			set => Unlock.notActive = !value;
		}
		public override bool IsAvailable
		{
			get => !Unlock.unavailable;
			set
			{
				Unlock.unavailable = !value;
				bool? cur = gc?.sessionDataBig?.extraUnlocks?.Contains(Unlock);
				if (cur == true && !value) { gc.sessionDataBig.extraUnlocks.Remove(Unlock); Unlock.extraCount--; }
				else if (cur == false && value) { gc.sessionDataBig.extraUnlocks.Add(Unlock); Unlock.extraCount++; }
			}
		}
	}
	public class LoadoutUnlock : UnlockWrapper
	{
		public LoadoutUnlock(string name, bool unlockedFromStart = false) : base(name, "Loadout", unlockedFromStart) { }
		internal LoadoutUnlock(Unlock unlock) : base(unlock) { }

		public override bool IsEnabled
		{
			get => !Unlock.notActive;
			set => Unlock.notActive = !value;
		}
		public override bool IsAvailable
		{
			get => !Unlock.unavailable;
			set
			{
				Unlock.unavailable = !value;
				bool? cur = gc?.sessionDataBig?.loadoutUnlocks?.Contains(Unlock);
				if (cur == true && !value) { gc.sessionDataBig.loadoutUnlocks.Remove(Unlock); Unlock.loadoutCount--; }
				else if (cur == false && value) { gc.sessionDataBig.loadoutUnlocks.Add(Unlock); Unlock.loadoutCount++; }
			}
		}
	}
	public class AgentUnlock : UnlockWrapper
	{
		public AgentUnlock(string name, bool unlockedFromStart = false) : base(name, "Agent", unlockedFromStart) { }
		internal AgentUnlock(Unlock unlock) : base(unlock) { }

		public override bool IsEnabled
		{
			get => !Unlock.notActive;
			set => Unlock.notActive = !value;
		}
		public override bool IsAvailable
		{
			get => !Unlock.unavailable;
			set
			{
				Unlock.unavailable = !value;
				bool? cur = gc?.sessionDataBig?.agentUnlocks?.Contains(Unlock);
				if (cur == true && !value) { gc.sessionDataBig.agentUnlocks.Remove(Unlock); Unlock.agentCount--; }
				else if (cur == false && value) { gc.sessionDataBig.agentUnlocks.Add(Unlock); Unlock.agentCount++; }
			}
		}
	}
}
