using System;
using System.Collections.Generic;
using System.Linq;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents a custom in-game mutator (also known as challenge).</para>
	/// </summary>
	public class CustomMutator : CustomUnlock
	{
		internal CustomMutator(string id, CustomName name, CustomName description) : base(id, name, description) { }

		public override string Type => "Challenge";

		private bool available = true;
		public override bool Available
		{
			get => available;
			set
			{
				if (unlock != null)
					RogueLibs.PluginInstance.EnsureOne(GameController.gameController.sessionDataBig.challengeUnlocks, unlock, value);
				available = value;
			}
		}

	}
}
