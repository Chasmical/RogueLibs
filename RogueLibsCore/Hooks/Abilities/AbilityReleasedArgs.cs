using System;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents the custom ability's released args.</para>
	/// </summary>
	public class AbilityReleasedArgs : EventArgs
	{
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="AbilityReleasedArgs"/> class with the specified <paramref name="heldTime"/>.</para>
		/// </summary>
		/// <param name="heldTime">The custom ability's held time.</param>
		public AbilityReleasedArgs(float heldTime) => HeldTime = heldTime;
		/// <summary>
		///   <para>Gets the last holding time, in seconds.</para>
		/// </summary>
		public float HeldTime { get; }
	}
}
