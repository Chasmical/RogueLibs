using UnityEngine;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Indicates that a custom item is targetable anywhere.</para>
	/// </summary>
	public interface IItemTargetableAnywhere
	{
		/// <summary>
		///   <para>Determines whether to highlight the cursor when hovering over the specified <paramref name="position"/> and combining the current item.</para>
		/// </summary>
		/// <param name="position">The target position.</param>
		/// <returns><see langword="true"/>, if the current item can be targeted at the specified <paramref name="position"/>; otherwise, <see langword="false"/>.</returns>
		bool TargetFilter(Vector2 position);
		/// <summary>
		///   <para>Uses the current item on the specified <paramref name="position"/>. The return value indicates whether the usage succeeded or failed.</para>
		/// </summary>
		/// <param name="position">The target position.</param>
		/// <returns><see langword="true"/>, if the item was successfully used on the specified <paramref name="position"/>; otherwise, <see langword="false"/>.</returns>
		bool TargetPosition(Vector2 position);
		/// <summary>
		///   <para>Determines the cursor text when hovering over the specified <paramref name="position"/>.</para>
		/// </summary>
		/// <param name="position">The target position.</param>
		/// <returns>The cursor text to display, or <see langword="null"/> to display the default cursor text.</returns>
		CustomTooltip TargetCursorText(Vector2 position);
	}
}
