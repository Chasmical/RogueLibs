namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents a "Clear All" button in the Mutators Menu.</para>
	/// </summary>
	public class ClearAllMutatorsUnlock : MutatorUnlock
	{
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="ClearAllMutatorsUnlock"/> class.</para>
		/// </summary>
		public ClearAllMutatorsUnlock() : base("ClearAll", true) { }
		/// <inheritdoc/>
		public override bool IsAvailable { get; set; } = true;
		/// <inheritdoc/>
		public override bool IsEnabled { get => false; set { } }

		/// <inheritdoc/>
		public override void OnPushedButton()
		{
			if (IsUnlocked && gc.serverPlayer)
			{
				PlaySound(VanillaAudio.ClickButton);
				foreach (DisplayedUnlock du in Menu.Unlocks)
					if (du.IsEnabled != (du.IsEnabled = false)) du.UpdateButton();
				UpdateMenu();
			}
			else PlaySound(VanillaAudio.CantDo);
		}
	}
}
