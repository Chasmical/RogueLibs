namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents status effect initialization information.</para>
	/// </summary>
	public struct CreateEffectInfo
	{
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="CreateEffectInfo"/> structure with the specified <paramref name="specificTime"/>.</para>
		/// </summary>
		/// <param name="specificTime">The effect's time.</param>
		public CreateEffectInfo(int specificTime)
		{
			SpecificTime = specificTime;
			DontShowText = false;
			IgnoreElectronic = false;
			CauserAgent = null;
		}
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="CreateEffectInfo"/> structure with the specified <paramref name="causerAgent"/>.</para>
		/// </summary>
		/// <param name="causerAgent">The agent that caused this effect.</param>
		public CreateEffectInfo(Agent causerAgent)
		{
			SpecificTime = 0;
			DontShowText = false;
			IgnoreElectronic = false;
			CauserAgent = causerAgent;
		}
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="CreateEffectInfo"/> structure with the specified <paramref name="causerAgent"/> and <paramref name="specificTime"/>.</para>
		/// </summary>
		/// <param name="causerAgent">The agent that caused this effect.</param>
		/// <param name="specificTime">The effect's time.</param>
		public CreateEffectInfo(Agent causerAgent, int specificTime)
		{
			SpecificTime = specificTime;
			DontShowText = false;
			IgnoreElectronic = false;
			CauserAgent = causerAgent;
		}

		/// <summary>
		///   <para>Gets or sets the effect's time.</para>
		/// </summary>
		public int SpecificTime { get; set; }
		/// <summary>
		///   <para>Gets or sets whether a buff text shouldn't be displayed.</para>
		/// </summary>
		public bool DontShowText { get; set; }
		/// <summary>
		///   <para>Gets or sets whether the effect ignores the "Electronic" trait.</para>
		/// </summary>
		public bool IgnoreElectronic { get; set; }
		/// <summary>
		///   <para>Gets or sets the agent that caused this effect.</para>
		/// </summary>
		public Agent CauserAgent { get; set; }
	}
}
