namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents a custom status effect.</para>
	/// </summary>
	public abstract class CustomEffect : HookBase<StatusEffect>
	{
		/// <summary>
		///   <para>Gets the current <see cref="StatusEffect"/> instance.</para>
		/// </summary>
		public StatusEffect Effect => Instance;
		/// <summary>
		///   <para>Gets the status effect's <see cref="global::StatusEffects"/> instance.</para>
		/// </summary>
		public StatusEffects StatusEffects => Effect.GetStatusEffects();
		/// <summary>
		///   <para>Gets the status effect's owner.</para>
		/// </summary>
		public Agent Owner => Effect.GetStatusEffects().agent;
		/// <summary>
		///   <para>Gets the agent that caused the status effect.</para>
		/// </summary>
		public Agent CausedBy => Effect.causingAgent;

		/// <summary>
		///   <para>Gets or sets the status effect's current time.</para>
		/// </summary>
		public int CurrentTime { get => Effect.curTime; set => Effect.curTime = value; }

		/// <summary>
		///   <para>Gets the currently used instance of <see cref="GameController"/>.</para>
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Usage of gc fields in SoR")]
		public static GameController gc => GameController.gameController;

		/// <summary>
		///   <para>Gets the custom effect's metadata.</para>
		/// </summary>
		public EffectInfo EffectInfo { get; internal set; }

		/// <inheritdoc/>
		protected override sealed void Initialize()
		{
			Effect.dontRemoveOnDeath = !EffectInfo.RemoveOnDeath;
			Effect.removeOnKnockout = EffectInfo.RemoveOnKnockOut;
			Effect.keepBetweenLevels = !EffectInfo.RemoveOnNextLevel;
		}

		/// <summary>
		///   <para>Gets the default status effect time. Might get called on a partially initialized status effect.</para>
		/// </summary>
		/// <returns>The default status effect time, in seconds.</returns>
		public abstract int GetEffectTime();
		/// <summary>
		///   <para>Gets the default status effect hate. Might get called on a partially initialized status effect.
		///   <br/>Usually, it's 5 for negative effects and 0 for positive.</para>
		/// </summary>
		/// <returns>The default status effect hate.</returns>
		public abstract int GetEffectHate();

		/// <summary>
		///   <para>The method that is called when the status effect is added.</para>
		/// </summary>
		public abstract void OnAdded();
		/// <summary>
		///   <para>The method that is called when the status effect is refreshed.</para>
		/// </summary>
		public virtual void OnRefreshed() => CurrentTime = GetEffectTime();
		/// <summary>
		///   <para>The method that is called when the status effect is removed.</para>
		/// </summary>
		public abstract void OnRemoved();
		/// <summary>
		///   <para>The method that is called as a part of the status effect's update coroutine.</para>
		/// </summary>
		/// <param name="e">The custom effect's update data.</param>
		public abstract void OnUpdated(EffectUpdatedArgs e);
	}
}
