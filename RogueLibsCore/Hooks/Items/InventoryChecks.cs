using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RogueLibsCore
{
	public static class InventoryChecks
	{
		internal static readonly RogueEvent<OnItemUsingArgs> onItemUsing = new RogueEvent<OnItemUsingArgs>();
		internal static readonly RogueEvent<OnItemsCombiningArgs> onItemsCombining = new RogueEvent<OnItemsCombiningArgs>();
		internal static readonly RogueEvent<OnItemTargetingArgs> onItemTargeting = new RogueEvent<OnItemTargetingArgs>();
		internal static readonly RogueEvent<OnItemTargetingAnywhereArgs> onItemTargetingAnywhere = new RogueEvent<OnItemTargetingAnywhereArgs>();

		public static void AddItemUsingCheck(string name, RogueEventHandler<OnItemUsingArgs> check)
		{
			if (RogueFramework.IsDebugEnabled(DebugFlags.Items))
				RogueFramework.LogDebug($"Added \"{name}\" usage inventory check.");
			onItemUsing.Subscribe(name, check);
		}
		public static void AddItemsCombiningCheck(string name, RogueEventHandler<OnItemsCombiningArgs> check)
		{
			if (RogueFramework.IsDebugEnabled(DebugFlags.Items))
				RogueFramework.LogDebug($"Added \"{name}\" combining inventory check.");
			onItemsCombining.Subscribe(name, check);
		}
		public static void AddItemTargetingCheck(string name, RogueEventHandler<OnItemTargetingArgs> check)
		{
			if (RogueFramework.IsDebugEnabled(DebugFlags.Items))
				RogueFramework.LogDebug($"Added \"{name}\" targeting inventory check.");
			onItemTargeting.Subscribe(name, check);
		}
		public static void AddItemTargetingAnywhereCheck(string name, RogueEventHandler<OnItemTargetingAnywhereArgs> check)
		{
			if (RogueFramework.IsDebugEnabled(DebugFlags.Items))
				RogueFramework.LogDebug($"Added \"{name}\" targeting anywhere inventory check.");
			onItemTargetingAnywhere.Subscribe(name, check);
		}

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
	public class OnItemTargetingAnywhereArgs : RogueEventArgs
	{
		public OnItemTargetingAnywhereArgs(InvItem item, Vector2 position, Agent user)
		{
			Item = item;
			Target = position;
			User = user;
		}
		public InvDatabase Inventory => Item.database;
		public InvItem Item { get; }
		public Vector2 Target { get; set; }
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
