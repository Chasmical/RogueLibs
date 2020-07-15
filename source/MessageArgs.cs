using System;

namespace RogueLibsCore
{
	/// <summary>
	///   <para><see cref="EventArgs"/> that are used for <see cref="RogueChat.OnCommand"/> event.</para>
	/// </summary>
	public class MessageArgs : EventArgs
	{
		/// <summary>
		///   <para>Text of the command.</para>
		/// </summary>
		public string Text { get; set; }
	}
}
