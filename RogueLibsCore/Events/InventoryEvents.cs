using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLibsCore
{
	public class InventoryEvents
	{
		private InventoryEvents() { }
		public InventoryEvents(InvDatabase inventory) => Inventory = inventory ?? throw new ArgumentNullException(nameof(inventory));
		public InvDatabase Inventory { get; }

		internal readonly RogueEvent<OnItemUsedArgs> onItemUsed = new RogueEvent<OnItemUsedArgs>();
		public event RogueEventHandler<OnItemUsedArgs> OnItemUsed
		{
			add => onItemUsed.Subscribe(value);
			remove => onItemUsed.Unsubscribe(value);
		}
		internal readonly RogueEvent<OnItemsCombinedArgs> onItemsCombined = new RogueEvent<OnItemsCombinedArgs>();
		public event RogueEventHandler<OnItemsCombinedArgs> OnItemsCombined
		{
			add => onItemsCombined.Subscribe(value);
			remove => onItemsCombined.Unsubscribe(value);
		}
		internal readonly RogueEvent<OnItemTargetedArgs> onItemTargeted = new RogueEvent<OnItemTargetedArgs>();
		public event RogueEventHandler<OnItemTargetedArgs> OnItemTargeted
		{
			add => onItemTargeted.Subscribe(value);
			remove => onItemTargeted.Unsubscribe(value);
		}

		internal static readonly RogueEvent<OnItemUsedArgs> onItemUseCheck = new RogueEvent<OnItemUsedArgs>();
		public static event RogueEventHandler<OnItemUsedArgs> OnItemUseCheck
		{
			add => onItemUseCheck.Subscribe(value);
			remove => onItemUseCheck.Unsubscribe(value);
		}
		internal static readonly RogueEvent<OnItemsCombinedArgs> onItemsCombineCheck = new RogueEvent<OnItemsCombinedArgs>();
		public static event RogueEventHandler<OnItemsCombinedArgs> OnItemsCombineCheck
		{
			add => onItemsCombineCheck.Subscribe(value);
			remove => onItemsCombineCheck.Unsubscribe(value);
		}
		internal static readonly RogueEvent<OnItemTargetedArgs> onItemTargetCheck = new RogueEvent<OnItemTargetedArgs>();
		public static event RogueEventHandler<OnItemTargetedArgs> OnItemTargetCheck
		{
			add => onItemTargetCheck.Subscribe(value);
			remove => onItemTargetCheck.Unsubscribe(value);
		}

		public static InventoryEvents Global { get; } = new InventoryEvents();
	}
	public class OnItemUsedArgs : RogueEventArgs
	{
		public OnItemUsedArgs(InvItem item, Agent user)
		{
			Item = item;
			User = user;
		}
		public InvItem Item { get; }
		public Agent User { get; }
	}
	public class OnItemsCombinedArgs : RogueEventArgs
	{
		public OnItemsCombinedArgs(InvItem item, InvItem otherItem, Agent combiner)
		{
			Item = item;
			OtherItem = otherItem;
			Combiner = combiner;
		}
		public InvItem Item { get; }
		public InvItem OtherItem { get; }
		public Agent Combiner { get; }
	}
	public class OnItemTargetedArgs : RogueEventArgs
	{
		public OnItemTargetedArgs(InvItem item, PlayfieldObject target)
		{
			Item = item;
			Target = target;
		}
		public InvItem Item { get; }
		public PlayfieldObject Target { get; }
	}
}
