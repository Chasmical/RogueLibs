using System;

namespace RogueLibsCore
{
	public class OnLanguageChangedArgs : EventArgs
	{
		public OnLanguageChangedArgs(LanguageCode prev, LanguageCode value)
		{
			PreviousValue = prev;
			Value = value;
		}
		public LanguageCode PreviousValue { get; }
		public LanguageCode Value { get; }
	}
}
