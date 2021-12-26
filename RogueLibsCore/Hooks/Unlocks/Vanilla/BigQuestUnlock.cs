namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents a Big Quest unlock.</para>
	/// </summary>
	public class BigQuestUnlock : DisplayedUnlock, IUnlockInCC
	{
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="BigQuestUnlock"/> class without a name.</para>
		/// </summary>
		public BigQuestUnlock() : this(null, false) { }
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="BigQuestUnlock"/> class without a name.</para>
		/// </summary>
		/// <param name="unlockedFromStart">Determines whether the unlock is unlocked by default.</param>
		public BigQuestUnlock(bool unlockedFromStart) : this(null, unlockedFromStart) { }
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="BigQuestUnlock"/> class with the specified <paramref name="name"/>.</para>
		/// </summary>
		/// <param name="name">The unlock's and Big Quest's name. Must be of format: "&lt;AgentUnlock&gt;_BQ".</param>
		public BigQuestUnlock(string name) : this(name, false) { }
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="BigQuestUnlock"/> class with the specified <paramref name="name"/>.</para>
		/// </summary>
		/// <param name="name">The unlock's and Big Quest's name. Must be of format: "&lt;AgentUnlock&gt;_BQ".</param>
		/// <param name="unlockedFromStart">Determines whether the unlock is unlocked by default.</param>
		public BigQuestUnlock(string name, bool unlockedFromStart) : base(name, UnlockTypes.BigQuest, unlockedFromStart) => IsAvailableInCC = true;
		internal BigQuestUnlock(Unlock unlock) : base(unlock) { }

		/// <inheritdoc/>
		public override bool IsEnabled
		{
			get => !Unlock.notActive;
			set => Unlock.notActive = !value;
		}
		/// <inheritdoc/>
		public bool IsAddedToCC
		{
			get => ((CustomCharacterCreation)Menu).CC.bigQuestChosen == Agent.Name;
			set
			{
				bool cur = IsAddedToCC;
				if (cur && !value) ((CustomCharacterCreation)Menu).CC.bigQuestChosen = "";
				else if (!cur && value) ((CustomCharacterCreation)Menu).CC.bigQuestChosen = Agent.Name;
			}
		}

		/// <inheritdoc/>
		public override bool IsAvailable
		{
			get => !Unlock.unavailable;
			set
			{
				Unlock.unavailable = !value;
				bool? cur = gc?.sessionDataBig?.bigQuestUnlocks?.Contains(Unlock);
				if (cur == true && !value) { gc.sessionDataBig.bigQuestUnlocks.Remove(Unlock); Unlock.bigQuestCount--; }
				else if (cur == false && value) { gc.sessionDataBig.bigQuestUnlocks.Add(Unlock); Unlock.bigQuestCount++; }
			}
		}
		/// <inheritdoc/>
		public bool IsAvailableInCC
		{
			get => Unlock.onlyInCharacterCreation;
			set => Unlock.onlyInCharacterCreation = value;
		}

        /// <summary>
        ///   <para>Gets or sets whether the Big Quest is unlocked. This is synchronized with its <see cref="AgentUnlock"/>.</para>
        /// </summary>
        public override bool IsUnlocked { get => Agent.IsUnlocked; set => Agent.IsUnlocked = value; }
        /// <summary>
		///   <para>Gets or sets whether the Big Quest is complete.</para>
		/// </summary>
		public bool IsCompleted { get => Unlock.unlocked; set => Unlock.unlocked = value; }

		/// <summary>
		///   <para>Gets the <see cref="AgentUnlock"/> associated with this Big Quest.</para>
		/// </summary>
		public AgentUnlock Agent { get; internal set; }
        public string AgentName => Name.Substring(0, Name.Length - 3);

		/// <summary>
		///   <para>Sets up the Big Quest's associated <see cref="AgentUnlock"/>.</para>
		/// </summary>
		public override void SetupUnlock()
		{
			Agent = (AgentUnlock)RogueFramework.Unlocks.Find(u => u is AgentUnlock a && a.Name == AgentName);
			if (Agent != null)
			{
				Agent.BigQuest = this;
				IsAvailableInCC = !Agent.IsSSA;
			}
		}

		/// <inheritdoc/>
		public override void UpdateButton()
		{
			if (Menu.Type == UnlocksMenuType.CharacterCreation)
			{
				UpdateButton(IsAddedToCC);
			}
		}
		/// <inheritdoc/>
		public override void OnPushedButton()
		{
			if (IsUnlocked)
			{
				if (Menu.Type == UnlocksMenuType.CharacterCreation)
				{
					PlaySound(VanillaAudio.ClickButton);
					BigQuestUnlock previous = (BigQuestUnlock)Menu.Unlocks.Find(u => u is BigQuestUnlock bigQuest && bigQuest.IsAddedToCC);
					IsAddedToCC = !IsAddedToCC;
					UpdateButton();
					previous?.UpdateButton();
					UpdateMenu();
				}
			}
			else if (Unlock.nowAvailable && UnlockCost > 0 && UnlockCost <= gc.sessionDataBig.nuggets)
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
            string name = gc.nameDB.GetName(Name, NameTypes.Unlock);
            string agentName = Agent.GetName();
            if (Agent.Name == VanillaAgents.GangsterCrepe || Agent.Name == VanillaAgents.GangsterBlahd)
                agentName += $", {gc.nameDB.GetName(Agent.Name + "_N", NameTypes.Agent)}";
            return $"{name} ({agentName})";
		}
		/// <inheritdoc/>
		public override string GetDescription() => gc.nameDB.GetName("D_" + Name, NameTypes.Unlock);

        public override string GetFancyDescription()
        {
            if (IsUnlocked || Unlock.nowAvailable || Menu.ShowLockedUnlocks)
            {
                string text = GetDescription();
                AddCancellationsTo(ref text);
                AddRecommendationsTo(ref text);
                if (!IsUnlocked || RogueFramework.IsDebugEnabled(DebugFlags.Unlocks | DebugFlags.UnlockMenus))
                    AddPrerequisitesTo(ref text);
                return text;
            }
            else
            {
                string text = "?????";
                AddPrerequisitesTo(ref text);
                return text;
            }
        }

        public override bool ShowInPrerequisites => true;
    }
}
