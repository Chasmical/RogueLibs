using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Contains events for various inventory actions.</para>
	/// </summary>
	public class InventoryEvents : IHook<InvDatabase>
	{
		private InventoryEvents() { }
		/// <summary>
		///   <para>Initializes a new instance of <see cref="InventoryEvents"/> for the specified <paramref name="inventory"/>.</para>
		/// </summary>
		/// <param name="inventory">Inventory to attach the events to.</param>
		/// <exception cref="ArgumentNullException"><paramref name="inventory"/> is <see langword="null"/>.</exception>
		public InventoryEvents(InvDatabase inventory) => Inventory = inventory ?? throw new ArgumentNullException(nameof(inventory));
		/// <summary>
		///   <para>Inventory that the inventory events are attached to.</para>
		/// </summary>
		public InvDatabase Inventory { get; private set; }
		InvDatabase IHook<InvDatabase>.Instance { get => Inventory; set => Inventory = value; }
		object IHook.Instance { get => Inventory; set => Inventory = (InvDatabase)value; }
		void IHook.Initialize() { }

		internal readonly RogueEvent<OnItemUsedArgs> onItemUsed = new RogueEvent<OnItemUsedArgs>();
		/// <summary>
		///   <para>Event that is called after every item usage.</para>
		/// </summary>
		/// <exception cref="ArgumentNullException"><see langword="value"/> is <see langword="null"/>.</exception>
		public event RogueEventHandler<OnItemUsedArgs> OnItemUsed
		{
			add => onItemUsed.Subscribe(value);
			remove => onItemUsed.Unsubscribe(value);
		}
		internal readonly RogueEvent<OnItemsCombinedArgs> onItemsCombined = new RogueEvent<OnItemsCombinedArgs>();
		/// <summary>
		///   <para>Event that is called after every item combination.</para>
		/// </summary>
		/// <exception cref="ArgumentNullException"><see langword="value"/> is <see langword="null"/>.</exception>
		public event RogueEventHandler<OnItemsCombinedArgs> OnItemsCombined
		{
			add => onItemsCombined.Subscribe(value);
			remove => onItemsCombined.Unsubscribe(value);
		}
		internal readonly RogueEvent<OnItemTargetedArgs> onItemTargeted = new RogueEvent<OnItemTargetedArgs>();
		/// <summary>
		///   <para>Event that is called after every item targeting.</para>
		/// </summary>
		/// <exception cref="ArgumentNullException"><see langword="value"/> is <see langword="null"/>.</exception>
		public event RogueEventHandler<OnItemTargetedArgs> OnItemTargeted
		{
			add => onItemTargeted.Subscribe(value);
			remove => onItemTargeted.Unsubscribe(value);
		}

		internal static readonly RogueEvent<OnItemUsedArgs> onItemUseCheck = new RogueEvent<OnItemUsedArgs>();
		/// <summary>
		///   <para>Event that is used to determine whether an item can be used.</para>
		/// </summary>
		/// <exception cref="ArgumentNullException"><see langword="value"/> is <see langword="null"/>.</exception>
		public static event RogueEventHandler<OnItemUsedArgs> OnItemUseCheck
		{
			add => onItemUseCheck.Subscribe(value);
			remove => onItemUseCheck.Unsubscribe(value);
		}
		internal static readonly RogueEvent<OnItemsCombinedArgs> onItemsCombineCheck = new RogueEvent<OnItemsCombinedArgs>();
		/// <summary>
		///   <para>Event that is used to determine whether an item can be combined with another.</para>
		/// </summary>
		/// <exception cref="ArgumentNullException"><see langword="value"/> is <see langword="null"/>.</exception>
		public static event RogueEventHandler<OnItemsCombinedArgs> OnItemsCombineCheck
		{
			add => onItemsCombineCheck.Subscribe(value);
			remove => onItemsCombineCheck.Unsubscribe(value);
		}
		internal static readonly RogueEvent<OnItemTargetedArgs> onItemTargetCheck = new RogueEvent<OnItemTargetedArgs>();
		/// <summary>
		///   <para>Event that is used to determine whether an item can be targeted at an object.</para>
		/// </summary>
		/// <exception cref="ArgumentNullException"><see langword="value"/> is <see langword="null"/>.</exception>
		public static event RogueEventHandler<OnItemTargetedArgs> OnItemTargetCheck
		{
			add => onItemTargetCheck.Subscribe(value);
			remove => onItemTargetCheck.Unsubscribe(value);
		}

		/// <summary>
		///   <para>Global inventory events that handles events from all inventories.</para>
		/// </summary>
		public static InventoryEvents Global { get; } = new InventoryEvents();
	}
	/// <summary>
	///   <para><see cref="RogueEventArgs"/> containing the usage event data: an item that was used and the agent who used it.</para>
	/// </summary>
	public class OnItemUsedArgs : RogueEventArgs
	{
		/// <summary>
		///   <para>Initializes a new instance of <see cref="OnItemUsedArgs"/> with the specified <paramref name="item"/> and <paramref name="user"/>.</para>
		/// </summary>
		/// <param name="item">Item that was used.</param>
		/// <param name="user">Agent who used the <paramref name="item"/>.</param>
		public OnItemUsedArgs(InvItem item, Agent user)
		{
			if (item is null) throw new ArgumentNullException(nameof(item));
			if (user is null) throw new ArgumentNullException(nameof(user));
			Item = item;
			User = user;
		}
		/// <summary>
		///   <para>Gets the used item.</para>
		/// </summary>
		public InvItem Item { get; }
		/// <summary>
		///   <para>Gets the agent who used the item.</para>
		/// </summary>
		public Agent User { get; }
	}
	/// <summary>
	///   <para><see cref="RogueEventArgs"/> containing the combination event data: items that were combined and the agent who combined them.</para>
	/// </summary>
	public class OnItemsCombinedArgs : RogueEventArgs
	{
		/// <summary>
		///   <para>Initializes a new instance of <see cref="OnItemsCombinedArgs"/> with the specified <paramref name="item"/>, <paramref name="otherItem"/> and <paramref name="combiner"/>.</para>
		/// </summary>
		/// <param name="item">Item that was combined with the <paramref name="otherItem"/>. Guaranteed to be of type "Combine".</param>
		/// <param name="otherItem">Item that was combined with the <paramref name="item"/>.</param>
		/// <param name="combiner">Agent who combined <paramref name="item"/> with the <paramref name="otherItem"/>.</param>
		public OnItemsCombinedArgs(InvItem item, InvItem otherItem, Agent combiner)
		{
			if (item is null) throw new ArgumentNullException(nameof(item));
			if (otherItem is null) throw new ArgumentNullException(nameof(otherItem));
			if (combiner is null) throw new ArgumentNullException(nameof(combiner));
			Item = item;
			OtherItem = otherItem;
			Combiner = combiner;
		}
		/// <summary>
		///   <para>Gets the first of the combined items. Guaranteed to be of type "Combine".</para>
		/// </summary>
		public InvItem Item { get; }
		/// <summary>
		///   <para>Gets the second of the combined items.</para>
		/// </summary>
		public InvItem OtherItem { get; }
		/// <summary>
		///   <para>Gets the agent who combined the items.</para>
		/// </summary>
		public Agent Combiner { get; }
	}
	/// <summary>
	///   <para><see cref="RogueEventArgs"/> containing the targeting event data: item that was used, the targeted object and the agent who used the item.</para>
	/// </summary>
	public class OnItemTargetedArgs : RogueEventArgs
	{
		/// <summary>
		///   <para>Initializes a new instance of <see cref="OnItemTargetedArgs"/> with the specified <paramref name="item"/>, <paramref name="target"/> and <paramref name="user"/>.</para>
		/// </summary>
		/// <param name="item">Item that was used to target an object.</param>
		/// <param name="target">Object that the <paramref name="item"/> was used on.</param>
		/// <param name="user">Agent who used the <paramref name="item"/></param>
		public OnItemTargetedArgs(InvItem item, PlayfieldObject target, Agent user)
		{
			if (item is null) throw new ArgumentNullException(nameof(item));
			if (target is null) throw new ArgumentNullException(nameof(target));
			if (user is null) throw new ArgumentNullException(nameof(user));
			Item = item;
			Target = target;
			User = user;
		}
		/// <summary>
		///   <para>Gets the used item.</para>
		/// </summary>
		public InvItem Item { get; }
		/// <summary>
		///   <para>Gets the targeted object.</para>
		/// </summary>
		public PlayfieldObject Target { get; }
		/// <summary>
		///   <para>Gets the agent who used the item.</para>
		/// </summary>
		public Agent User { get; }
	}
}
