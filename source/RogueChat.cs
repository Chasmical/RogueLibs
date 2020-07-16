using System;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>A class for catching and processing in-game commands.</para>
	/// </summary>
	public class RogueChat
	{
		/// <summary>
		///   <para>An event that is invoked every time a new message in chat is created.</para>
		/// </summary>
		public static event Action<MessageArgs> OnCommand;

		internal static void InvokeCommand(string text)
		{
			MessageArgs args = new MessageArgs()
			{
				Text = text
			};
			OnCommand?.Invoke(args);
		}
	}
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
