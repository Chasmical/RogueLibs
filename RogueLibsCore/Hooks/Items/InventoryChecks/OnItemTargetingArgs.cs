using System;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents the item targeting inventory check args.</para>
	/// </summary>
	public class OnItemTargetingArgs : RogueEventArgs
	{
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="OnItemTargetingArgs"/> class with the specified <paramref name="item"/>, <paramref name="targetObject"/> and <paramref name="user"/>.</para>
		/// </summary>
		/// <param name="item">The item being used.</param>
		/// <param name="targetObject">The object being targeted.</param>
		/// <param name="user">The agent using the item.</param>
		/// <exception cref="ArgumentNullException"><paramref name="item"/>, <paramref name="targetObject"/> or <paramref name="user"/> is <see langword="null"/>.</exception>
		public OnItemTargetingArgs(InvItem item, PlayfieldObject targetObject, Agent user)
		{
			Item = item ?? throw new ArgumentNullException(nameof(item));
			Target = targetObject ?? throw new ArgumentNullException(nameof(targetObject));
			User = user ?? throw new ArgumentNullException(nameof(user));
		}
		/// <summary>
		///   <para>Gets the item's inventory.</para>
		/// </summary>
		public InvDatabase Inventory => Item.database;
		/// <summary>
		///   <para>Gets the item being used.</para>
		/// </summary>
		public InvItem Item { get; }
		/// <summary>
		///   <para>Gets or sets the object being targeted.</para>
		/// </summary>
		public PlayfieldObject Target { get; set; }
		/// <summary>
		///   <para>Gets or sets the agent using the item.</para>
		/// </summary>
		public Agent User { get; set; }
	}
}
