using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BepInEx.Logging;

namespace RogueLibsCore
{
	public sealed class RogueEventSubscriber<T> : IComparable<RogueEventSubscriber<T>>, IComparable where T : RogueEventArgs
	{
		internal RogueEventSubscriber(RogueEventHandler<T> handler, string name, string[] before, string[] after)
		{
			Handler = handler ?? throw new ArgumentNullException(nameof(handler));
			if (name != null) Name = name;
			else
			{
				Name = GetAutoName();
				AutoName = true;
			}
			before?.CopyTo(_before = new string[before.Length], 0);
			Before = new ReadOnlyCollection<string>(before);
			after?.CopyTo(_after = new string[after.Length], 0);
			After = new ReadOnlyCollection<string>(after);
		}
		private string GetAutoName()
		{
			MethodInfo method = Handler.Method;
			return method.DeclaringType.FullName + "." + method.Name;
		}
		public RogueEventHandler<T> Handler { get; }
		public string Name { get; }
		public bool AutoName { get; }
		private readonly string[] _before;
		public ReadOnlyCollection<string> Before { get; }
		private readonly string[] _after;
		public ReadOnlyCollection<string> After { get; }

		public int CompareTo(RogueEventSubscriber<T> subscriber)
			=> _before != null && Array.IndexOf(_before, subscriber.Name) != -1 ? -1
			: _after != null && Array.IndexOf(_after, subscriber.Name) != -1 ? 1
			: Name.CompareTo(subscriber.Name);
		int IComparable.CompareTo(object obj) => obj == null ? 1
			: obj is RogueEventSubscriber<T> subscriber ? CompareTo(subscriber)
			: throw new ArgumentException("", nameof(obj));
		public override string ToString() => Name + (AutoName ? null : $" ({GetAutoName()})");
	}
	public delegate void RogueEventHandler<in T>(T args) where T : RogueEventArgs;
}
