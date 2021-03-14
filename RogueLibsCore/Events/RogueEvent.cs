using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BepInEx.Logging;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents a more complex event system.</para>
	/// </summary>
	/// <typeparam name="T">Type of the <see cref="RogueEventArgs"/> to use.</typeparam>
	public sealed class RogueEvent<T> : IDisposable where T : RogueEventArgs
	{
		private object _lock = new object();
		private List<RogueEventSubscriber<T>> subscribers = new List<RogueEventSubscriber<T>>(0);

		/// <summary>
		///   <para>Adds the specified <paramref name="handler"/> to the invokation list.</para>
		/// </summary>
		/// <param name="handler">Event handler to add to the invokation list.</param>
		/// <returns>Created <see cref="RogueEventSubscriber{T}"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="handler"/> is <see langword="null"/>.</exception>
		public RogueEventSubscriber<T> Subscribe(RogueEventHandler<T> handler)
			=> Subscribe(handler, null, null, null);
		/// <summary>
		///   <para>Adds the specified <paramref name="handler"/> to the invokation list under the specified <paramref name="name"/>.</para>
		/// </summary>
		/// <param name="handler">Event handler to add to the invokation list.</param>
		/// <param name="name">Event subscriber's name/id.</param>
		/// <returns>Created <see cref="RogueEventSubscriber{T}"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="handler"/> is <see langword="null"/>.</exception>
		public RogueEventSubscriber<T> Subscribe(RogueEventHandler<T> handler, string name)
			=> Subscribe(handler, name, null, null);
		/// <summary>
		///   <para>Adds the specified <paramref name="handler"/> to the invokation list under the specified <paramref name="name"/>, before and after the specified subscribers.</para>
		/// </summary>
		/// <param name="handler">Event handler to add to the invokation list.</param>
		/// <param name="name">Event subscriber's name/id.</param>
		/// <param name="before">Event subscribers, that this handler will be executed prior to.</param>
		/// <param name="after">Event subscribers, that this handler will be executed after.</param>
		/// <returns>Created <see cref="RogueEventSubscriber{T}"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="handler"/> is <see langword="null"/>.</exception>
		public RogueEventSubscriber<T> Subscribe(RogueEventHandler<T> handler, string name, string[] before, string[] after)
		{
			if (handler is null) throw new ArgumentNullException(nameof(handler));
			RogueEventSubscriber<T> sub = new RogueEventSubscriber<T>(handler, name, before, after);
			lock (_lock)
			{
				subscribers.Capacity++;
				subscribers.Add(sub);
				subscribers.Sort();
			}
			return sub;
		}

		/// <summary>
		///   <para>Removes the specified <paramref name="subscriber"/> from the invokation list.</para>
		/// </summary>
		/// <param name="subscriber">Event subscriber to remove from the invokation list.</param>
		public void Unsubscribe(RogueEventSubscriber<T> subscriber)
		{
			lock (_lock) if (subscribers.Remove(subscriber)) subscribers.Capacity--;
		}
		/// <summary>
		///   <para>Removes the specified <paramref name="handler"/> from the invokation list.</para>
		/// </summary>
		/// <param name="handler">Event handler to remove from the invokation list.</param>
		public void Unsubscribe(RogueEventHandler<T> handler)
		{
			lock (_lock) subscribers.Capacity -= subscribers.RemoveAll(s => s.Handler == handler);
		}
		/// <summary>
		///   <para>Removes a subscriber with the specified <paramref name="name"/> from the invokation list.</para>
		/// </summary>
		/// <param name="name">Name/id of the subscriber to remove from the invokation list.</param>
		public void Unsubscribe(string name)
		{
			lock (_lock) subscribers.Capacity -= subscribers.RemoveAll(s => s.Name == name);
		}

		/// <summary>
		///   <para>Logs debug info about the current object.</para>
		/// </summary>
		public void LogDebugInfo()
		{
			ManualLogSource log = RogueLibsInternals.Logger;
			log.LogDebug($"RogueEvent<{typeof(T).FullName}>. {subscribers.Count} subscribers:");
			int index = 0;
			foreach (RogueEventSubscriber<T> subscriber in subscribers)
				log.LogDebug($"{index++}: {subscriber}");
		}
		/// <summary>
		///   <para>Frees all of the managed resources used by this instance.</para>
		/// </summary>
		public void Dispose()
		{
			subscribers = null;
			_lock = null;
		}
		/// <summary>
		///   <para>Raises an event with the specified <paramref name="eventArgs"/>.</para>
		/// </summary>
		/// <param name="eventArgs"><see cref="RogueEventArgs"/> to invoke the event handlers with.</param>
		/// <returns><see langword="true"/>, if the invokation was not cancelled; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="eventArgs"/> is <see langword="null"/>.</exception>
		public bool Raise(T eventArgs)
		{
			if (eventArgs is null) throw new ArgumentNullException(nameof(eventArgs));
			lock (_lock)
				for (int i = 0; i < subscribers.Count && !eventArgs.Handled; i++)
					subscribers[i].Handler.Invoke(eventArgs);
			return !eventArgs.Cancel;
		}
	}
}
