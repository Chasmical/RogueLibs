using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BepInEx.Logging;

namespace RogueLibsCore
{
	public sealed class RogueEvent<T> : IDisposable where T : RogueEventArgs
	{
		private readonly object _lock = new object();
		private List<RogueEventSubscriber<T>> subscribers = new List<RogueEventSubscriber<T>>(0);

		public RogueEventSubscriber<T> Subscribe(RogueEventHandler<T> handler)
			=> Subscribe(handler, null, null, null);
		public RogueEventSubscriber<T> Subscribe(RogueEventHandler<T> handler, string name)
			=> Subscribe(handler, name, null, null);
		public RogueEventSubscriber<T> Subscribe(RogueEventHandler<T> handler, string name, string[] before, string[] after)
		{
			RogueEventSubscriber<T> sub = new RogueEventSubscriber<T>(handler, name, before, after);
			lock (_lock)
			{
				subscribers.Capacity++;
				subscribers.Add(sub);
				subscribers.Sort();
			}
			return sub;
		}

		public void Unsubscribe(RogueEventHandler<T> handler)
		{
			lock (_lock) subscribers.Capacity -= subscribers.RemoveAll(s => s.Handler == handler);
		}
		public void Unsubscribe(string id)
		{
			lock (_lock) subscribers.Capacity -= subscribers.RemoveAll(s => s.Name == id);
		}

		public void LogDebugInfo()
		{
			ManualLogSource log = RogueLibs.Logger;
			log.LogDebug($"RogueEvent<{typeof(T).FullName}>. {subscribers.Count} subscribers:");
			int index = 0;
			foreach (RogueEventSubscriber<T> subscriber in subscribers)
				log.LogDebug($"{index++}: {subscriber}");
		}
		public void Dispose() => subscribers = null;
		public bool Raise(T eventArgs)
		{
			lock (_lock)
				for (int i = 0; i < subscribers.Count && !eventArgs.Handled; i++)
					subscribers[i].Handler.Invoke(eventArgs);
			return !eventArgs.Cancel;
		}

		public static RogueEvent<T> operator +(RogueEvent<T> @event, RogueEventHandler<T> handler)
		{
			@event.Subscribe(handler);
			return @event;
		}
		public static RogueEvent<T> operator -(RogueEvent<T> @event, RogueEventHandler<T> handler)
		{
			@event.Unsubscribe(handler);
			return @event;
		}
	}
}
