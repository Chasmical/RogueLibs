using System;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents event args for the <see cref="RogueEvent{TArgs}"/> class.</para>
	/// </summary>
	public class RogueEventArgs : EventArgs
	{
		/// <summary>
		///   <para>Determines whether the event is handled, and other subscribers should not be called.</para>
		/// </summary>
		public bool Handled { get; set; }
		/// <summary>
		///   <para>Determines whether the event's action should be cancelled and not get executed.</para>
		/// </summary>
		public bool Cancel { get; set; }
	}
}
