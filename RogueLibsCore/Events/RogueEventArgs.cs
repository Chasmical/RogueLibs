using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BepInEx.Logging;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents a more complex event data container.</para>
	/// </summary>
	public abstract class RogueEventArgs
	{
		/// <summary>
		///   <para>Determines whether the current event was handled successfully. If set to <see langword="true"/>, the event data doesn't go through to the other subscribers.</para>
		/// </summary>
		public bool Handled { get; set; }
		/// <summary>
		///   <para>Determines whether the current event action should be cancelled.</para>
		/// </summary>
		public bool Cancel { get; set; }
	}
}
