namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents an agent unlock.</para>
	/// </summary>
	public class AgentUnlock : UnlockWrapper
	{
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="AgentUnlock"/> class without a name.</para>
		/// </summary>
		public AgentUnlock() : this(null, false) { }
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="AgentUnlock"/> class without a name.</para>
		/// </summary>
		/// <param name="unlockedFromStart">Determines whether the unlock is unlocked by default.</param>
		public AgentUnlock(bool unlockedFromStart) : this(null, unlockedFromStart) { }
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="AgentUnlock"/> class with the specified <paramref name="name"/>.</para>
		/// </summary>
		/// <param name="name">The unlock's and agent's name.</param>
		public AgentUnlock(string name) : this(name, false) { }
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="AgentUnlock"/> class with the specified <paramref name="name"/>.</para>
		/// </summary>
		/// <param name="name">The unlock's and agent's name.</param>
		/// <param name="unlockedFromStart">Determines whether the unlock is unlocked by default.</param>
		public AgentUnlock(string name, bool unlockedFromStart) : base(name, UnlockTypes.Agent, unlockedFromStart) { }
		internal AgentUnlock(Unlock unlock) : base(unlock) { }

		/// <summary>
		///   <para>Gets the <see cref="BigQuestUnlock"/> associated with this agent.</para>
		/// </summary>
		public BigQuestUnlock BigQuest { get; internal set; }

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
				bool? cur = gc?.sessionDataBig?.agentUnlocks?.Contains(Unlock);
				if (cur == true && !value) { gc.sessionDataBig.agentUnlocks.Remove(Unlock); Unlock.agentCount--; }
				else if (cur == false && value) { gc.sessionDataBig.agentUnlocks.Add(Unlock); Unlock.agentCount++; }
			}
		}

		/// <summary>
		///   <para>Gets or sets whether this unlock's agent is a Super Special Abilities variant of another agent.</para>
		/// </summary>
		public bool IsSSA
		{
			get => Unlock.isUpgrade;
			set => Unlock.isUpgrade = value;
		}

		/// <summary>
		///   <para>Sets up the Agent's associated <see cref="BigQuestUnlock"/>.</para>
		/// </summary>
		public override void SetupUnlock()
		{
			string bigQuest = Name + "_BQ";
			BigQuest = (BigQuestUnlock)RogueFramework.Unlocks.Find(u => u is BigQuestUnlock bq && bq.Name == bigQuest);
			if (BigQuest != null)
			{
				BigQuest.Agent = this;
				BigQuest.IsAvailableInCC = !IsSSA;
			}
		}
	}
}
