using System;
using System.Collections.Generic;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents an event, that can stop its execution once the event args are handled, and determines whether the planned action was cancelled by any of the subscribers.</para>
    /// </summary>
    /// <typeparam name="TArgs">The <see cref="RogueEventArgs"/> used by the event.</typeparam>
    public class RogueEvent<TArgs> where TArgs : RogueEventArgs
    {
        private readonly List<RogueEventSubscriber<TArgs>> list = new List<RogueEventSubscriber<TArgs>>(0);

        /// <summary>
        ///   <para>Subscribes a new subscriber with the specified <paramref name="handler"/>.</para>
        /// </summary>
        /// <param name="handler">The handler of the subscriber.</param>
        /// <exception cref="ArgumentNullException"><paramref name="handler"/> is <see langword="null"/>.</exception>
        public void Subscribe(RogueEventHandler<TArgs> handler) => Subscribe(null, handler);
        /// <summary>
        ///   <para>Subscribes a new subscriber with the specified <paramref name="name"/> and <paramref name="handler"/>.</para>
        /// </summary>
        /// <param name="name">The name of the subscriber.</param>
        /// <param name="handler">The handler of the subscriber.</param>
        /// <exception cref="ArgumentNullException"><paramref name="handler"/> is <see langword="null"/>.</exception>
        public void Subscribe(string? name, RogueEventHandler<TArgs> handler)
        {
            if (handler is null) throw new ArgumentNullException(nameof(handler));
            list.Capacity++;
            list.Add(new RogueEventSubscriber<TArgs>(name, handler));
        }
        /// <summary>
        ///   <para>Unsubscribes all subscribers with the specified <paramref name="handler"/>.</para>
        /// </summary>
        /// <param name="handler">The handler of the subscribers to unsubscribe.</param>
        /// <returns><see langword="true"/>, if at least one subscriber was successfully unsubscribed; otherwise, <see langword="false"/>.</returns>
        public bool Unsubscribe(RogueEventHandler<TArgs> handler)
        {
            int removed = list.RemoveAll(h => h.Handler == handler);
            if (removed > 0)
            {
                list.Capacity -= removed;
                return true;
            }
            return false;
        }
        /// <summary>
        ///   <para>Unsubscribes all subscribers with the specified <paramref name="name"/>.</para>
        /// </summary>
        /// <param name="name">The name of the subscribers to unsubscribe.</param>
        /// <returns><see langword="true"/>, if at least one subscriber was successfully unsubscribed; otherwise, <see langword="false"/>.</returns>
        public void Unsubscribe(string name)
        {
            int removed = list.RemoveAll(h => h.Name == name);
            if (removed > 0) list.Capacity -= removed;
        }
        /// <summary>
        ///   <para>Raises an event with the specified <paramref name="args"/>, ignoring subscribers with names from the specified <paramref name="ignoreList"/>.</para>
        /// </summary>
        /// <param name="args">The event args to raise an event with.</param>
        /// <param name="ignoreList">The names of the subscribers to ignore.</param>
        /// <returns><see langword="true"/>, if the action was not cancelled by any of the subscribers; otherwise, <see langword="false"/>.</returns>
        public bool Raise(TArgs args, ICollection<string>? ignoreList)
        {
            for (int i = 0; i < list.Count && !args.Handled; i++)
            {
                RogueEventSubscriber<TArgs> sub = list[i];
                if (sub.Name != null && ignoreList?.Contains(sub.Name) == true) continue;
                list[i].Handler(args);
            }
            return !args.Cancel;
        }
    }
}
