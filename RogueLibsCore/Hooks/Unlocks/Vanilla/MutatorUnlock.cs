namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents a mutator unlock.</para>
	/// </summary>
	public class MutatorUnlock : DisplayedUnlock
	{
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="MutatorUnlock"/> class without a name.</para>
		/// </summary>
		public MutatorUnlock() : this(null, false) { }
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="MutatorUnlock"/> class without a name.</para>
		/// </summary>
		/// <param name="unlockedFromStart">Determines whether the unlock is unlocked by default.</param>
		public MutatorUnlock(bool unlockedFromStart) : this(null, unlockedFromStart) { }
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="MutatorUnlock"/> class with the specified <paramref name="name"/>.</para>
		/// </summary>
		/// <param name="name">The unlock's and mutator's name.</param>
		public MutatorUnlock(string name) : this(name, false) { }
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="MutatorUnlock"/> class with the specified <paramref name="name"/>.</para>
		/// </summary>
		/// <param name="name">The unlock's and mutator's name.</param>
		/// <param name="unlockedFromStart">Determines whether the unlock is unlocked by default.</param>
		public MutatorUnlock(string name, bool unlockedFromStart) : base(name, UnlockTypes.Mutator, unlockedFromStart) { }
		internal MutatorUnlock(Unlock unlock) : base(unlock) { }

		/// <inheritdoc/>
		public override bool IsEnabled
		{
			get => gc.challenges.Contains(Name);
			set
			{
				if (IsEnabled)
				{
					if (!value)
					{
						gc.challenges.Remove(Name);
						if (Menu.Type == UnlocksMenuType.MutatorMenu)
							gc.originalChallenges.Remove(Name);
					}
				}
				else if (value)
				{
					gc.challenges.Add(Name);
					if (Menu.Type == UnlocksMenuType.MutatorMenu)
						gc.originalChallenges.Add(Name);
				}
			}
		}
		/// <inheritdoc/>
		public override bool IsAvailable
		{
			get => !Unlock.unavailable;
			set
			{
				Unlock.unavailable = !value;
				bool? cur = gc?.sessionDataBig?.challengeUnlocks?.Contains(Unlock);
				if (cur == true && !value) { gc.sessionDataBig.challengeUnlocks.Remove(Unlock); Unlock.challengeCount--; }
				else if (cur == false && value) { gc.sessionDataBig.challengeUnlocks.Add(Unlock); Unlock.challengeCount++; }
			}
		}

		/// <inheritdoc/>
		public override void OnPushedButton()
		{
			if (IsUnlocked)
			{
				if (gc.serverPlayer)
				{
					PlaySound(VanillaAudio.ClickButton);
					if (IsEnabled = !IsEnabled)
						foreach (DisplayedUnlock du in EnumerateCancellations())
							du.IsEnabled = false;
					SendAnnouncementInChat(IsEnabled ? "AddedChallenge" : "RemovedChallenge", Name);
					UpdateButton();
					UpdateMenu();
				}
				else PlaySound(VanillaAudio.CantDo);
			}
			else if (Unlock.nowAvailable && UnlockCost <= gc.sessionDataBig.nuggets)
			{
				PlaySound(VanillaAudio.BuyUnlock);
				gc.unlocks.SubtractNuggets(UnlockCost);
				gc.unlocks.DoUnlockForced(Name, Type);
				UpdateAllUnlocks();
				UpdateMenu();
			}
			else PlaySound(VanillaAudio.CantDo);
		}

		/// <inheritdoc/>
		public override string GetName()
		{
			if (IsUnlocked || Unlock.nowAvailable)
			{
				if (!Name.Contains("NoD_")) return gc.nameDB.GetName(Name, Unlock.unlockNameType);
				return gc.nameDB.GetName("Remove", NameTypes.Interface) + " - "
					+ gc.nameDB.GetName("LevelFeeling" + Name.Replace("NoD_", string.Empty) + "_Name", NameTypes.Interface);
			}
			else return "?????";
		}
		/// <inheritdoc/>
		public override string GetDescription()
			=> IsUnlocked || Unlock.nowAvailable
			? Name.Contains("NoD_")
				? gc.nameDB.GetName("NoDisasterDescription", NameTypes.Unlock)
				: gc.nameDB.GetName("D_" + Name, Unlock.unlockDescriptionType)
			: "?????";
	}
}
