namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents an unlock that is available in the Character Creation menu.</para>
	/// </summary>
	public interface IUnlockInCC
	{
		/// <summary>
		///   <para>Gets or sets whether the unlock is added to a custom character.</para>
		/// </summary>
		bool IsAddedToCC { get; set; }
		/// <summary>
		///   <para>Gets or sets whether the unlock is available in the Character Creation menu.</para>
		/// </summary>
		bool IsAvailableInCC { get; set; }
	}
}
