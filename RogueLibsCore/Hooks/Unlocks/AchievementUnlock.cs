using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using HarmonyLib;

namespace RogueLibsCore
{
	public class AchievementUnlock : DisplayedUnlock
	{
		public AchievementUnlock() : this(null, false) { }
		public AchievementUnlock(string name, bool unlockedFromStart = false) : base(name, "Achievement", unlockedFromStart) { }
		internal AchievementUnlock(Unlock unlock) : base(unlock) { }

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
				bool? cur = gc?.sessionDataBig?.achievementUnlocks?.Contains(Unlock);
				if (cur == true && !value) { gc.sessionDataBig.achievementUnlocks.Remove(Unlock); Unlock.achievementCount--; }
				else if (cur == false && value) { gc.sessionDataBig.achievementUnlocks.Add(Unlock); Unlock.achievementCount++; }
			}
		}

		public override void OnPushedButton() => UpdateMenu();
	}
}
