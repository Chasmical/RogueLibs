using System;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents an event subscriber for the <see cref="RogueEvent{TArgs}"/> class.</para>
    /// </summary>
    /// <typeparam name="TArgs">The <see cref="RogueEventArgs"/> used by the event.</typeparam>
    public class RogueEventSubscriber<TArgs> where TArgs : RogueEventArgs
    {
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="RogueEventSubscriber{TArgs}"/> class with the specified <paramref name="name"/> and <paramref name="handler"/>.</para>
        /// </summary>
        /// <param name="name">The name of the subscriber.</param>
        /// <param name="handler">The handler of the subscriber.</param>
        /// <exception cref="ArgumentNullException"><paramref name="handler"/> is <see langword="null"/>.</exception>
        public RogueEventSubscriber(string name, RogueEventHandler<TArgs> handler)
        {
            if (handler is null) throw new ArgumentNullException(nameof(handler));
            Name = name;
            Handler = handler;
        }
        /// <summary>
        ///   <para>Gets the subscriber's name.</para>
        /// </summary>
        public string Name { get; }
        /// <summary>
        ///   <para>Gets the subscriber's handler.</para>
        /// </summary>
        public RogueEventHandler<TArgs> Handler { get; }
    }
    /// <summary>
    ///   <para>Represents an event handler for the <see cref="RogueEvent{TArgs}"/> class.</para>
    /// </summary>
    /// <typeparam name="TArgs">The <see cref="RogueEventArgs"/> used by the event.</typeparam>
    /// <param name="e">The event args.</param>
    public delegate void RogueEventHandler<TArgs>(TArgs e) where TArgs : RogueEventArgs;
}
