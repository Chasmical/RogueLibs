using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLibsCore
{
	public static class InventoryEvents
	{
		internal static readonly RogueEvent<OnItemUsedArgs> onItemUsing = new RogueEvent<OnItemUsedArgs>();
		public static event RogueEventHandler<OnItemUsedArgs> OnItemUsing
		{
			add => onItemUsing.Subscribe(value);
			remove => onItemUsing.Unsubscribe(value);
		}
		internal static readonly RogueEvent<OnItemsCombinedArgs> onItemsCombining = new RogueEvent<OnItemsCombinedArgs>();
		public static event RogueEventHandler<OnItemsCombinedArgs> OnItemsCombining
		{
			add => onItemsCombining.Subscribe(value);
			remove => onItemsCombining.Unsubscribe(value);
		}
		internal static readonly RogueEvent<OnItemTargetedArgs> onItemTargeting = new RogueEvent<OnItemTargetedArgs>();
		public static event RogueEventHandler<OnItemTargetedArgs> OnItemTargeting
		{
			add => onItemTargeting.Subscribe(value);
			remove => onItemTargeting.Unsubscribe(value);
		}
	}
	public class OnItemUsedArgs : RogueEventArgs
	{
		public OnItemUsedArgs(InvItem item, Agent user)
		{
			Item = item;
			User = user;
		}
		public InvDatabase Inventory => Item.database;
		public InvItem Item { get; }
		public Agent User { get; set; }
	}
	public class OnItemsCombinedArgs : RogueEventArgs
	{
		public OnItemsCombinedArgs(InvItem item, InvItem otherItem, Agent combiner)
		{
			Item = item;
			OtherItem = otherItem;
			Combiner = combiner;
		}
		public InvDatabase Inventory => Item.database;
		public InvItem Item { get; }
		public InvItem OtherItem { get; set; }
		public Agent Combiner { get; set; }
	}
	public class OnItemTargetedArgs : RogueEventArgs
	{
		public OnItemTargetedArgs(InvItem item, PlayfieldObject targetObject, Agent user)
		{
			Item = item;
			Target = targetObject;
			User = user;
		}
		public InvDatabase Inventory => Item.database;
		public InvItem Item { get; }
		public PlayfieldObject Target { get; set; }
		public Agent User { get; set; }
	}
	public class RogueEvent<TArgs> where TArgs : RogueEventArgs
	{
		private readonly List<RogueEventHandler<TArgs>> list = new List<RogueEventHandler<TArgs>>(0);

		public void Subscribe(RogueEventHandler<TArgs> handler)
		{
			list.Capacity++;
			list.Add(handler);
		}
		public void Unsubscribe(RogueEventHandler<TArgs> handler)
		{
			if (list.Remove(handler))
				list.Capacity--;
		}
		public bool Raise(TArgs args)
		{
			for (int i = 0; i < list.Count && !args.Handled; i++)
				list[i](args);
			return !args.Cancel;
		}
	}
	public class RogueEventArgs : EventArgs
	{
		public bool Handled { get; set; }
		public bool Cancel { get; set; }
	}
	public delegate void RogueEventHandler<TArgs>(TArgs args) where TArgs : RogueEventArgs;
}
