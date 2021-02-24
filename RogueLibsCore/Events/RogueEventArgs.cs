using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BepInEx.Logging;

namespace RogueLibsCore
{
	public abstract class RogueEventArgs : IDisposable
	{
		public bool Handled { get; set; }
		public bool Cancel { get; set; }
		private Dictionary<string, object> states = new Dictionary<string, object>();
		public void Dispose() => states = null;

		public object this[string stateId]
		{
			get => states.TryGetValue(stateId, out object state) ? state : null;
			set => states[stateId] = value;
		}
		public T GetState<T>() => (T)states.Values.FirstOrDefault(s => s is T);
	}
}
