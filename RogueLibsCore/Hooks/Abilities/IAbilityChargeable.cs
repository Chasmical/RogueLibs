namespace RogueLibsCore
{
	/// <summary>
	///   <para>Indicates that a custom ability is chargeable.</para>
	/// </summary>
	public interface IAbilityChargeable
	{
		/// <summary>
		///   <para>The method that is called each frame when the special ability is held.</para>
		/// </summary>
		/// <param name="e">The custom ability's holding data.</param>
		void OnHeld(AbilityHeldArgs e);
		/// <summary>
		///   <para>The method that is called when the special ability is released.</para>
		/// </summary>
		/// <param name="e">The custom ability's release data.</param>
		void OnReleased(AbilityReleasedArgs e);
	}
}
