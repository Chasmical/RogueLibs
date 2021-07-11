using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Provides methods to add inventory checks.</para>
	/// </summary>
	public static class InventoryChecks
	{
		internal static readonly RogueEvent<OnItemUsingArgs> onItemUsing = new RogueEvent<OnItemUsingArgs>();
		internal static readonly RogueEvent<OnItemsCombiningArgs> onItemsCombining = new RogueEvent<OnItemsCombiningArgs>();
		internal static readonly RogueEvent<OnItemTargetingArgs> onItemTargeting = new RogueEvent<OnItemTargetingArgs>();
		internal static readonly RogueEvent<OnItemTargetingAnywhereArgs> onItemTargetingAnywhere = new RogueEvent<OnItemTargetingAnywhereArgs>();

		/// <summary>
		///   <para>Adds an item usage inventory check with the specified <paramref name="name"/> and <paramref name="handler"/>.</para>
		/// </summary>
		/// <param name="name">The name of the inventory check to add.</param>
		/// <param name="handler">The inventory check handler.</param>
		/// <exception cref="ArgumentNullException"><paramref name="handler"/> is <see langword="null"/>.</exception>
		public static void AddItemUsingCheck(string name, RogueEventHandler<OnItemUsingArgs> handler)
		{
			if (handler is null) throw new ArgumentNullException(nameof(handler));
			if (RogueFramework.IsDebugEnabled(DebugFlags.Items))
				RogueFramework.LogDebug($"Added \"{name}\" usage inventory check.");
			onItemUsing.Subscribe(name, handler);
		}
		/// <summary>
		///   <para>Adds an item combining inventory check with the specified <paramref name="name"/> and <paramref name="handler"/>.</para>
		/// </summary>
		/// <param name="name">The name of the inventory check to add.</param>
		/// <param name="handler">The inventory check handler.</param>
		/// <exception cref="ArgumentNullException"><paramref name="handler"/> is <see langword="null"/>.</exception>
		public static void AddItemsCombiningCheck(string name, RogueEventHandler<OnItemsCombiningArgs> handler)
		{
			if (handler is null) throw new ArgumentNullException(nameof(handler));
			if (RogueFramework.IsDebugEnabled(DebugFlags.Items))
				RogueFramework.LogDebug($"Added \"{name}\" combining inventory check.");
			onItemsCombining.Subscribe(name, handler);
		}
		/// <summary>
		///   <para>Adds an item targeting inventory check with the specified <paramref name="name"/> and <paramref name="handler"/>.</para>
		/// </summary>
		/// <param name="name">The name of the inventory check to add.</param>
		/// <param name="handler">The inventory check handler.</param>
		/// <exception cref="ArgumentNullException"><paramref name="handler"/> is <see langword="null"/>.</exception>
		public static void AddItemTargetingCheck(string name, RogueEventHandler<OnItemTargetingArgs> handler)
		{
			if (handler is null) throw new ArgumentNullException(nameof(handler));
			if (RogueFramework.IsDebugEnabled(DebugFlags.Items))
				RogueFramework.LogDebug($"Added \"{name}\" targeting inventory check.");
			onItemTargeting.Subscribe(name, handler);
		}
		/// <summary>
		///   <para>Adds an item targeting anywhere inventory check with the specified <paramref name="name"/> and <paramref name="handler"/>.</para>
		/// </summary>
		/// <param name="name">The name of the inventory check to add.</param>
		/// <param name="handler">The inventory check handler.</param>
		/// <exception cref="ArgumentNullException"><paramref name="handler"/> is <see langword="null"/>.</exception>
		public static void AddItemTargetingAnywhereCheck(string name, RogueEventHandler<OnItemTargetingAnywhereArgs> handler)
		{
			if (handler is null) throw new ArgumentNullException(nameof(handler));
			if (RogueFramework.IsDebugEnabled(DebugFlags.Items))
				RogueFramework.LogDebug($"Added \"{name}\" targeting anywhere inventory check.");
			onItemTargetingAnywhere.Subscribe(name, handler);
		}

		/// <summary>
		///   <para>Determines whether the specified <paramref name="checkName"/> is allowed on the specified <paramref name="item"/>.</para>
		/// </summary>
		/// <param name="item">The item to check whether the inventory check is allowed for.</param>
		/// <param name="checkName">The name of the inventory check.</param>
		/// <returns><see langword="true"/>, if the inventory check is allowed; otherwise, <see langword="false"/>.</returns>
		public static bool IsCheckAllowed(InvItem item, string checkName) => IsCheckAllowed(item?.GetHook<CustomItem>(), checkName);
		/// <summary>
		///   <para>Determines whether the specified <paramref name="checkName"/> is allowed on the specified <paramref name="customItem"/>.</para>
		/// </summary>
		/// <param name="customItem">The custom item to check whether the inventory check is allowed for.</param>
		/// <param name="checkName">The name of the inventory check.</param>
		/// <returns><see langword="true"/>, if the inventory check is allowed; otherwise, <see langword="false"/>.</returns>
		public static bool IsCheckAllowed(CustomItem customItem, string checkName)
			=> customItem?.ItemInfo.IgnoredChecks.Contains(checkName) != true;
	}
	/// <summary>
	///   <para>Represents the item usage inventory check args.</para>
	/// </summary>
	public class OnItemUsingArgs : RogueEventArgs
	{
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="OnItemUsingArgs"/> class with the specified <paramref name="item"/> and <paramref name="user"/>.</para>
		/// </summary>
		/// <param name="item">The item being used.</param>
		/// <param name="user">The agent using the item.</param>
		/// <exception cref="ArgumentNullException"><paramref name="item"/> or <paramref name="user"/> is <see langword="null"/>.</exception>
		public OnItemUsingArgs(InvItem item, Agent user)
		{
			Item = item ?? throw new ArgumentNullException(nameof(item));
			User = user ?? throw new ArgumentNullException(nameof(user));
		}
		/// <summary>
		///   <para>Gets the item's inventory.</para>
		/// </summary>
		public InvDatabase Inventory => Item.database;
		/// <summary>
		///   <para>Gets the item being used.</para>
		/// </summary>
		public InvItem Item { get; }
		/// <summary>
		///   <para>Gets or sets the agent using the item.</para>
		/// </summary>
		public Agent User { get; set; }
	}
	/// <summary>
	///   <para>Represents the item combining inventory check args.</para>
	/// </summary>
	public class OnItemsCombiningArgs : RogueEventArgs
	{
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="OnItemsCombiningArgs"/> class with the specified <paramref name="item"/>, <paramref name="otherItem"/> and <paramref name="combiner"/>.</para>
		/// </summary>
		/// <param name="item">The item being combined.</param>
		/// <param name="otherItem">The item being combined with.</param>
		/// <param name="combiner">The agent combining the two items.</param>
		/// <exception cref="ArgumentNullException"><paramref name="item"/>, <paramref name="otherItem"/> or <paramref name="combiner"/> is <see langword="null"/>.</exception>
		public OnItemsCombiningArgs(InvItem item, InvItem otherItem, Agent combiner)
		{
			Item = item ?? throw new ArgumentNullException(nameof(item));
			OtherItem = otherItem ?? throw new ArgumentNullException(nameof(otherItem));
			Combiner = combiner ?? throw new ArgumentNullException(nameof(combiner));
		}
		/// <summary>
		///   <para>Gets the item's inventory.</para>
		/// </summary>
		public InvDatabase Inventory => Item.database;
		/// <summary>
		///   <para>Gets the item being combined.</para>
		/// </summary>
		public InvItem Item { get; }
		/// <summary>
		///   <para>Gets or sets the item being combined with.</para>
		/// </summary>
		public InvItem OtherItem { get; set; }
		/// <summary>
		///   <para>Gets or sets the agent combining the two items.</para>
		/// </summary>
		public Agent Combiner { get; set; }
	}
	/// <summary>
	///   <para>Represents the item targeting inventory check args.</para>
	/// </summary>
	public class OnItemTargetingArgs : RogueEventArgs
	{
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="OnItemTargetingArgs"/> class with the specified <paramref name="item"/>, <paramref name="targetObject"/> and <paramref name="user"/>.</para>
		/// </summary>
		/// <param name="item">The item being used.</param>
		/// <param name="targetObject">The object being targeted.</param>
		/// <param name="user">The agent using the item.</param>
		/// <exception cref="ArgumentNullException"><paramref name="item"/>, <paramref name="targetObject"/> or <paramref name="user"/> is <see langword="null"/>.</exception>
		public OnItemTargetingArgs(InvItem item, PlayfieldObject targetObject, Agent user)
		{
			Item = item ?? throw new ArgumentNullException(nameof(item));
			Target = targetObject ?? throw new ArgumentNullException(nameof(targetObject));
			User = user ?? throw new ArgumentNullException(nameof(user));
		}
		/// <summary>
		///   <para>Gets the item's inventory.</para>
		/// </summary>
		public InvDatabase Inventory => Item.database;
		/// <summary>
		///   <para>Gets the item being used.</para>
		/// </summary>
		public InvItem Item { get; }
		/// <summary>
		///   <para>Gets or sets the object being targeted.</para>
		/// </summary>
		public PlayfieldObject Target { get; set; }
		/// <summary>
		///   <para>Gets or sets the agent using the item.</para>
		/// </summary>
		public Agent User { get; set; }
	}
	/// <summary>
	///   <para>Represents the item targeting anywhere inventory check args.</para>
	/// </summary>
	public class OnItemTargetingAnywhereArgs : RogueEventArgs
	{
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="OnItemTargetingAnywhereArgs"/> class with the specified <paramref name="item"/>, <paramref name="position"/> and <paramref name="user"/>.</para>
		/// </summary>
		/// <param name="item">The item being used.</param>
		/// <param name="position">The position being targeted.</param>
		/// <param name="user">The agent using the item.</param>
		/// <exception cref="ArgumentNullException"><paramref name="item"/> or <paramref name="user"/> is <see langword="null"/>.</exception>
		public OnItemTargetingAnywhereArgs(InvItem item, Vector2 position, Agent user)
		{
			Item = item ?? throw new ArgumentNullException(nameof(item));
			Target = position;
			User = user ?? throw new ArgumentNullException(nameof(user));
		}
		/// <summary>
		///   <para>Gets the item's inventory.</para>
		/// </summary>
		public InvDatabase Inventory => Item.database;
		/// <summary>
		///   <para>Gets the item being used.</para>
		/// </summary>
		public InvItem Item { get; }
		/// <summary>
		///   <para>Gets or sets the position being targeted.</para>
		/// </summary>
		public Vector2 Target { get; set; }
		/// <summary>
		///   <para>Gets or sets the agent using the item.</para>
		/// </summary>
		public Agent User { get; set; }
	}
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
		public void Subscribe(string name, RogueEventHandler<TArgs> handler)
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
			if (handler is null) return false;
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
		public bool Raise(TArgs args, ICollection<string> ignoreList)
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
	/// <summary>
	///   <para>Represents event args for the <see cref="RogueEvent{TArgs}"/> class.</para>
	/// </summary>
	public class RogueEventArgs : EventArgs
	{
		/// <summary>
		///   <para>Determines whether the event is handled, and other subscribers should not be called.</para>
		/// </summary>
		public bool Handled { get; set; }
		/// <summary>
		///   <para>Determines whether the event's action should be cancelled and not get executed.</para>
		/// </summary>
		public bool Cancel { get; set; }
	}
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
