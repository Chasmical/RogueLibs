using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using HarmonyLib;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Achievement unlock wrapper.</para>
	/// </summary>
	public class AchievementUnlock : DisplayedUnlock
	{
		/// <summary>
		///   <para>Initializes a new instance of <see cref="AchievementUnlock"/> class.</para>
		/// </summary>
		public AchievementUnlock() : this(null, false) { }
		/// <summary>
		///   <para>Initializes a new instance of <see cref="AchievementUnlock"/> with the specified <paramref name="name"/>.</para>
		/// </summary>
		/// <param name="name">Unlock's name/id.</param>
		/// <param name="unlockedFromStart">Determines whether the unlock is unlocked from the start.</param>
		public AchievementUnlock(string name, bool unlockedFromStart = false) : base(name, "Achievement", unlockedFromStart) { }
		internal AchievementUnlock(Unlock unlock) : base(unlock) { }

		/// <inheritdoc/>
		public override bool IsEnabled
		{
			get => !Unlock.notActive;
			set => Unlock.notActive = !value;
		}
		/// <inheritdoc/>
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

		/// <inheritdoc/>
		public override void OnPushedButton() => UpdateMenu();
	}
}
