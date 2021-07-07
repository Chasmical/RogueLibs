using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLibsCore
{
	public static class InventoryChecks
	{
		internal static readonly RogueEvent<OnItemUsingArgs> onItemUsing = new RogueEvent<OnItemUsingArgs>();
		internal static readonly RogueEvent<OnItemsCombiningArgs> onItemsCombining = new RogueEvent<OnItemsCombiningArgs>();
		internal static readonly RogueEvent<OnItemTargetingArgs> onItemTargeting = new RogueEvent<OnItemTargetingArgs>();

		public static void AddItemUsingCheck(string name, RogueEventHandler<OnItemUsingArgs> check)
			=> onItemUsing.Subscribe(name, check);
		public static void AddItemsCombiningCheck(string name, RogueEventHandler<OnItemsCombiningArgs> check)
			=> onItemsCombining.Subscribe(name, check);
		public static void AddItemTargetingCheck(string name, RogueEventHandler<OnItemTargetingArgs> check)
			=> onItemTargeting.Subscribe(name, check);

		public static bool IsCheckAllowed(InvItem item, string checkName) => IsCheckAllowed(item?.GetHook<CustomItem>(), checkName);
		public static bool IsCheckAllowed(CustomItem customItem, string checkName)
			=> customItem?.ItemInfo.IgnoredChecks.Contains(checkName) != true;
	}
	public class OnItemUsingArgs : RogueEventArgs
	{
		public OnItemUsingArgs(InvItem item, Agent user)
		{
			Item = item;
			User = user;
		}
		public InvDatabase Inventory => Item.database;
		public InvItem Item { get; }
		public Agent User { get; set; }
	}
	public class OnItemsCombiningArgs : RogueEventArgs
	{
		public OnItemsCombiningArgs(InvItem item, InvItem otherItem, Agent combiner)
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
	public class OnItemTargetingArgs : RogueEventArgs
	{
		public OnItemTargetingArgs(InvItem item, PlayfieldObject targetObject, Agent user)
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
		private readonly List<RogueEventSubscriber<TArgs>> list = new List<RogueEventSubscriber<TArgs>>(0);

		public void Subscribe(RogueEventHandler<TArgs> handler) => Subscribe(null, handler);
		public void Subscribe(string name, RogueEventHandler<TArgs> handler)
		{
			list.Capacity++;
			list.Add(new RogueEventSubscriber<TArgs>(name, handler));
		}
		public void Unsubscribe(RogueEventHandler<TArgs> handler)
		{
			int removed = list.RemoveAll(h => h.Handler == handler);
			if (removed > 0) list.Capacity -= removed;
		}
		public void Unsubscribe(string name)
		{
			int removed = list.RemoveAll(h => h.Name == name);
			if (removed > 0) list.Capacity -= removed;
		}
		public bool Raise(TArgs args, IEnumerable<string> ignoreList)
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
	public class RogueEventArgs : EventArgs
	{
		public bool Handled { get; set; }
		public bool Cancel { get; set; }
	}
	public class RogueEventSubscriber<TArgs> where TArgs : RogueEventArgs
	{
		public RogueEventSubscriber(string name, RogueEventHandler<TArgs> handler)
		{
			Name = name;
			Handler = handler;
		}
		public string Name { get; }
		public RogueEventHandler<TArgs> Handler { get; }
	}
	public delegate void RogueEventHandler<TArgs>(TArgs args) where TArgs : RogueEventArgs;
}
