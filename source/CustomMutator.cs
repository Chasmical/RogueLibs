using System;
using System.Collections.Generic;
using System.Linq;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents a custom in-game mutator (also known as challenge).</para>
	/// </summary>
	public class CustomMutator : CustomUnlock
	{
		internal CustomMutator(string id, CustomName name, CustomName description) : base(id, name, description) { }

		public override string Type => "Challenge";

		private bool isActive = false;
		public bool IsActive
		{
			get => unlock != null ? (isActive == GameController.gameController.challenges.Contains(Id)) : isActive;
			set
			{
				if (unlock != null)
				{
					RogueLibs.PluginInstance.EnsureOne(GameController.gameController.challenges, Id, value);
					unlock.notActive = !value;
				}
				isActive = value;

				GameController.gameController.SetDailyRunText();
				GameController.gameController.mainGUI?.scrollingMenuScript?.UpdateOtherVisibleMenus(GameController.gameController.mainGUI.scrollingMenuScript.menuType);
			}
		}

		private bool available = true;
		public override bool Available
		{
			get => unlock != null ? (available = !unlock.unavailable) : available;
			set
			{
				if (unlock != null)
				{
					RogueLibs.PluginInstance.EnsureOne(GameController.gameController.sessionDataBig.challengeUnlocks, unlock, value);
					if (available && !value) Unlock.challengeCount--;
					else if (!available && value) Unlock.challengeCount++;
					unlock.unavailable = !value;
				}
				available = value;
			}
		}

	}
}
