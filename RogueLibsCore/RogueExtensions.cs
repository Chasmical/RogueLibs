using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLibsCore
{
	public static class RogueExtensions
	{
		private static HookController<T> GetHookController<T>(T obj, ref object field, bool create)
		{
			HookController<T> controller = field as HookController<T>;
			if (controller == null && create) field = controller = new HookController<T>(obj);
			return controller;
		}

		public static void AddHook(this InvItem obj, IHook<InvItem> hook)
			=> GetHookController(obj, ref obj.__RogueLibsHooks, true).AddHook(hook);
		public static void AddHook(this Agent obj, IHook<Agent> hook)
			=> GetHookController(obj, ref obj.__RogueLibsHooks, true).AddHook(hook);
		public static void AddHook(this ObjectReal obj, IHook<ObjectReal> hook)
			=> GetHookController(obj, ref obj.__RogueLibsHooks, true).AddHook(hook);
		public static void AddHook(this StatusEffect obj, IHook<StatusEffect> hook)
			=> GetHookController(obj, ref obj.__RogueLibsHooks, true).AddHook(hook);
		public static void AddHook(this Trait obj, IHook<Trait> hook)
			=> GetHookController(obj, ref obj.__RogueLibsHooks, true).AddHook(hook);

		public static THook AddHook<THook>(this InvItem obj) where THook : IHook<InvItem>, new()
			=> GetHookController(obj, ref obj.__RogueLibsHooks, true).AddHook<THook>();
		public static THook AddHook<THook>(this Agent obj) where THook : IHook<Agent>, new()
			=> GetHookController(obj, ref obj.__RogueLibsHooks, true).AddHook<THook>();
		public static THook AddHook<THook>(this ObjectReal obj) where THook : IHook<ObjectReal>, new()
			=> GetHookController(obj, ref obj.__RogueLibsHooks, true).AddHook<THook>();
		public static THook AddHook<THook>(this StatusEffect obj) where THook : IHook<StatusEffect>, new()
			=> GetHookController(obj, ref obj.__RogueLibsHooks, true).AddHook<THook>();
		public static THook AddHook<THook>(this Trait obj) where THook : IHook<Trait>, new()
			=> GetHookController(obj, ref obj.__RogueLibsHooks, true).AddHook<THook>();

		public static bool RemoveHook(this InvItem obj, IHook<InvItem> hook)
			=> GetHookController(obj, ref obj.__RogueLibsHooks, false)?.RemoveHook(hook) == true;
		public static bool RemoveHook(this Agent obj, IHook<Agent> hook)
			=> GetHookController(obj, ref obj.__RogueLibsHooks, false)?.RemoveHook(hook) == true;
		public static bool RemoveHook(this ObjectReal obj, IHook<ObjectReal> hook)
			=> GetHookController(obj, ref obj.__RogueLibsHooks, false)?.RemoveHook(hook) == true;
		public static bool RemoveHook(this StatusEffect obj, IHook<StatusEffect> hook)
			=> GetHookController(obj, ref obj.__RogueLibsHooks, false)?.RemoveHook(hook) == true;
		public static bool RemoveHook(this Trait obj, IHook<Trait> hook)
			=> GetHookController(obj, ref obj.__RogueLibsHooks, false)?.RemoveHook(hook) == true;

		public static bool RemoveHook<THook>(this InvItem obj) where THook : IHook<InvItem>
			=> GetHookController(obj, ref obj.__RogueLibsHooks, false)?.RemoveHook<THook>() == true;
		public static bool RemoveHook<THook>(this Agent obj) where THook : IHook<Agent>
			=> GetHookController(obj, ref obj.__RogueLibsHooks, false)?.RemoveHook<THook>() == true;
		public static bool RemoveHook<THook>(this ObjectReal obj) where THook : IHook<ObjectReal>
			=> GetHookController(obj, ref obj.__RogueLibsHooks, false)?.RemoveHook<THook>() == true;
		public static bool RemoveHook<THook>(this StatusEffect obj) where THook : IHook<StatusEffect>
			=> GetHookController(obj, ref obj.__RogueLibsHooks, false)?.RemoveHook<THook>() == true;
		public static bool RemoveHook<THook>(this Trait obj) where THook : IHook<Trait>
			=> GetHookController(obj, ref obj.__RogueLibsHooks, false)?.RemoveHook<THook>() == true;

		public static TType GetHook<TType>(this InvItem obj)
		{
			HookController<InvItem> controller = GetHookController(obj, ref obj.__RogueLibsHooks, false);
			return controller != null ? controller.GetHook<TType>() : default;
		}
		public static TType GetHook<TType>(this Agent obj)
		{
			HookController<Agent> controller = GetHookController(obj, ref obj.__RogueLibsHooks, false);
			return controller != null ? controller.GetHook<TType>() : default;
		}
		public static TType GetHook<TType>(this ObjectReal obj)
		{
			HookController<ObjectReal> controller = GetHookController(obj, ref obj.__RogueLibsHooks, false);
			return controller != null ? controller.GetHook<TType>() : default;
		}
		public static TType GetHook<TType>(this StatusEffect obj)
		{
			HookController<StatusEffect> controller = GetHookController(obj, ref obj.__RogueLibsHooks, false);
			return controller != null ? controller.GetHook<TType>() : default;
		}
		public static TType GetHook<TType>(this Trait obj)
		{
			HookController<Trait> controller = GetHookController(obj, ref obj.__RogueLibsHooks, false);
			return controller != null ? controller.GetHook<TType>() : default;
		}

		public static IEnumerable<TType> GetHooks<TType>(this InvItem obj)
			=> GetHookController(obj, ref obj.__RogueLibsHooks, false)?.GetHooks<TType>() ?? Enumerable.Empty<TType>();
		public static IEnumerable<TType> GetHooks<TType>(this Agent obj)
			=> GetHookController(obj, ref obj.__RogueLibsHooks, false)?.GetHooks<TType>() ?? Enumerable.Empty<TType>();
		public static IEnumerable<TType> GetHooks<TType>(this ObjectReal obj)
			=> GetHookController(obj, ref obj.__RogueLibsHooks, false)?.GetHooks<TType>() ?? Enumerable.Empty<TType>();
		public static IEnumerable<TType> GetHooks<TType>(this StatusEffect obj)
			=> GetHookController(obj, ref obj.__RogueLibsHooks, false)?.GetHooks<TType>() ?? Enumerable.Empty<TType>();
		public static IEnumerable<TType> GetHooks<TType>(this Trait obj)
			=> GetHookController(obj, ref obj.__RogueLibsHooks, false)?.GetHooks<TType>() ?? Enumerable.Empty<TType>();

		public static HookController<InvItem> GetHookController(this InvItem obj)
			=> GetHookController(obj, ref obj.__RogueLibsHooks, false);
		public static HookController<Agent> GetHookController(this Agent obj)
			=> GetHookController(obj, ref obj.__RogueLibsHooks, false);
		public static HookController<ObjectReal> GetHookController(this ObjectReal obj)
			=> GetHookController(obj, ref obj.__RogueLibsHooks, false);
		public static HookController<StatusEffect> GetHookController(this StatusEffect obj)
			=> GetHookController(obj, ref obj.__RogueLibsHooks, false);
		public static HookController<Trait> GetHookController(this Trait obj)
			=> GetHookController(obj, ref obj.__RogueLibsHooks, false);

		public static StatusEffects GetStatusEffects(this StatusEffect statusEffect)
			=> (StatusEffects)statusEffect.__RogueLibsContainer;
		public static StatusEffects GetStatusEffects(this Trait trait)
			=> (StatusEffects)trait.__RogueLibsContainer;

		public static InventoryEvents GetEvents(this InvDatabase inventory)
		{
			if (inventory.__RogueLibsEvents is InventoryEvents events) return events;
			inventory.__RogueLibsEvents = events = new InventoryEvents(inventory);
			return events;
		}

		public static T AddItem<T>(this InvDatabase inventory, int count)
			where T : CustomItem
		{
			InvItem item = inventory.AddItem(CustomItemInfo.Get<T>().Name, count);
			return item.GetHook<T>();
		}
		public static T GetItem<T>(this InvDatabase inventory)
			where T : CustomItem
		{
			InvItem item = inventory.FindItem(CustomItemInfo.Get<T>().Name);
			return item?.GetHook<T>();
		}

		public static UnlockButtonState GetState(this ButtonData buttonData)
		{
			if (buttonData.scrollingHighlighted) return UnlockButtonState.Selected;
			if (buttonData.scrollingHighlighted2) return UnlockButtonState.Purchasable;
			if (buttonData.scrollingHighlighted3) return UnlockButtonState.Locked;
			if (buttonData.scrollingHighlighted4) return UnlockButtonState.Disabled;
			else return UnlockButtonState.Normal;
		}
		public static void SetState(this ButtonData buttonData, UnlockButtonState value)
		{
			if (value == UnlockButtonState.Selected)
			{
				buttonData.scrollingHighlighted = true;
				buttonData.scrollingHighlighted2 = false;
				buttonData.scrollingHighlighted3 = false;
				buttonData.scrollingHighlighted4 = false;
				buttonData.highlightedSprite = buttonData.scrollingMenu?.solidObjectButtonSelected ?? buttonData.characterCreation.solidObjectButtonSelected;
			}
			else if (value == UnlockButtonState.Purchasable)
			{
				buttonData.scrollingHighlighted = false;
				buttonData.scrollingHighlighted2 = true;
				buttonData.scrollingHighlighted3 = false;
				buttonData.scrollingHighlighted4 = false;
				buttonData.highlightedSprite = buttonData.scrollingMenu?.solidObjectButtonLocked ?? buttonData.characterCreation.solidObjectButtonLocked;
			}
			else if (value == UnlockButtonState.Locked)
			{
				buttonData.scrollingHighlighted = false;
				buttonData.scrollingHighlighted2 = false;
				buttonData.scrollingHighlighted3 = true;
				buttonData.scrollingHighlighted4 = false;
				buttonData.highlightedSprite = buttonData.scrollingMenu?.solidObjectButtonRed ?? buttonData.characterCreation.solidObjectButtonRed;
			}
			else if (value == UnlockButtonState.Disabled)
			{
				buttonData.scrollingHighlighted = false;
				buttonData.scrollingHighlighted2 = false;
				buttonData.scrollingHighlighted3 = false;
				buttonData.scrollingHighlighted4 = true;
				buttonData.highlightedSprite = buttonData.scrollingMenu?.solidObjectButton ?? buttonData.characterCreation.solidObjectButton;
			}
			else
			{
				buttonData.scrollingHighlighted = false;
				buttonData.scrollingHighlighted2 = false;
				buttonData.scrollingHighlighted3 = false;
				buttonData.scrollingHighlighted4 = false;
				buttonData.highlightedSprite = buttonData.scrollingMenu?.solidObjectButton ?? buttonData.characterCreation.solidObjectButton;
			}
		}
	}
}
