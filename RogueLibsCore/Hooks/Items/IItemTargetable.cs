namespace RogueLibsCore
{
	/// <summary>
	///   <para>Indicates that a custom item is targetable.</para>
	/// </summary>
	public interface IItemTargetable
	{
		/// <summary>
		///   <para>Determines whether to highlight the <paramref name="target"/> object when targeting the current item.</para>
		/// </summary>
		/// <param name="target">The target object.</param>
		/// <returns><see langword="true"/>, if the current item can be targeted at the <paramref name="target"/> object; otherwise, <see langword="false"/>.</returns>
		bool TargetFilter(PlayfieldObject target);
		/// <summary>
		///   <para>Uses the current item on the <paramref name="target"/> object. The return value indicates whether the usage succeeded or failed.</para>
		/// </summary>
		/// <param name="target">The target object.</param>
		/// <returns><see langword="true"/>, if the item was successfully used on the <paramref name="target"/> object; otherwise, <see langword="false"/>.</returns>
		bool TargetObject(PlayfieldObject target);
		/// <summary>
		///   <para>Determines the cursor text when hovering over the <paramref name="target"/> object.</para>
		/// </summary>
		/// <param name="target">The target object.</param>
		/// <returns>The cursor text to display, or <see langword="null"/> to display the default cursor text.</returns>
		CustomTooltip TargetCursorText(PlayfieldObject target);
	}
}
