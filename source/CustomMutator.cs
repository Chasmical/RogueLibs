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


	}
}
