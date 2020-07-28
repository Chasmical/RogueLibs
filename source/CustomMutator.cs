using System;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents a custom in-game mutator (also known as challenge).</para>
	/// </summary>
	public class CustomMutator : CustomUnlock, IComparable<CustomMutator>
	{
		internal CustomMutator(string id, CustomName name, CustomName description) : base(id, name, description) { }

		/// <summary>
		///   <para>Compares this <see cref="CustomMutator"/> with <paramref name="another"/>.</para>
		/// </summary>
		public int CompareTo(CustomMutator another) => base.CompareTo(another);

		/// <summary>
		///   <para>Type of this <see cref="CustomUnlock"/> - "Challenge".</para>
		/// </summary>
		public override string Type => "Challenge";

		private bool isActive = false;
		/// <summary>
		///   <para>Determines whether this <see cref="CustomMutator"/> is active.</para>
		/// </summary>
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

				GameController.gameController?.SetDailyRunText();
				GameController.gameController?.mainGUI?.scrollingMenuScript?.UpdateOtherVisibleMenus(GameController.gameController.mainGUI.scrollingMenuScript.menuType);
			}
		}

		private bool available = true;
		/// <summary>
		///   <para>Determines whether this <see cref="CustomMutator"/> will be accessible in the Mutators Menu. (Default: <see langword="true"/>)</para>
		/// </summary>
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

		/// <summary>
		///   <para>Method that will be used in the <see cref="ScrollingMenu.PushedButton(ButtonHelper)"/> patch.</para>
		///   <para><see cref="ScrollingMenu"/> arg1 is the current instance of <see cref="ScrollingMenu"/>;<br/><see cref="ButtonHelper"/> arg2 is this mutator's <see cref="ButtonHelper"/>;<br/><see cref="bool"/> result determines whether the original RogueLibs patch should be executed.</para>
		/// </summary>
		public Func<ScrollingMenu, ButtonHelper, bool> ScrollingMenu_PushedButton { get; set; }

		/// <summary>
		///   <para>Event that is invoked when this mutator is toggled on/off in the Mutators Menu.</para>
		///   <para><see cref="ScrollingMenu"/> arg1 is the current instance of <see cref="ScrollingMenu"/>;<br/><see cref="ButtonHelper"/> arg2 is this mutator's <see cref="ButtonHelper"/>;<br/><see cref="bool"/> arg3 is the new state.</para>
		/// </summary>
		public event Action<ScrollingMenu, ButtonHelper, bool> OnToggledInMutatorMenu;
		/// <summary>
		///   <para>Event that is invoked when this mutator is unlocked in the Mutators Menu.</para>
		///   <para><see cref="ScrollingMenu"/> arg1 is the current instance of <see cref="ScrollingMenu"/>;<br/><see cref="ButtonHelper"/> arg2 is this mutator's <see cref="ButtonHelper"/>.</para>
		/// </summary>
		public event Action<ScrollingMenu, ButtonHelper> OnUnlockedInMutatorMenu;

		internal void InvokeOnToggledEvent(ScrollingMenu sm, ButtonHelper bh, bool newState) => OnToggledInMutatorMenu?.Invoke(sm, bh, newState);
		internal void InvokeOnUnlockedEvent(ScrollingMenu sm, ButtonHelper bh) => OnUnlockedInMutatorMenu?.Invoke(sm, bh);

	}
}
