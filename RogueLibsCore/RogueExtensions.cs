using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLibsCore
{
	public static class HookExtensions
	{
		private static HookController<T> GetHookController<T>(T obj, ref object field, bool create)
		{
			HookController<T> controller = field as HookController<T>;
			if (controller is null && create) field = controller = new HookController<T>(obj);
			return controller;
		}

		public static void AddHook(this InvItem obj, IHook<InvItem> hook)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			if (hook is null) throw new ArgumentNullException(nameof(hook));
			GetHookController(obj, ref obj.__RogueLibsHooks, true).AddHook(hook);
		}
		public static void AddHook(this Agent obj, IHook<Agent> hook)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			if (hook is null) throw new ArgumentNullException(nameof(hook));
			GetHookController(obj, ref obj.__RogueLibsHooks, true).AddHook(hook);
		}
		public static void AddHook(this ObjectReal obj, IHook<ObjectReal> hook)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			if (hook is null) throw new ArgumentNullException(nameof(hook));
			GetHookController(obj, ref obj.__RogueLibsHooks, true).AddHook(hook);
		}
		public static void AddHook(this StatusEffect obj, IHook<StatusEffect> hook)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			if (hook is null) throw new ArgumentNullException(nameof(hook));
			GetHookController(obj, ref obj.__RogueLibsHooks, true).AddHook(hook);
		}
		public static void AddHook(this Trait obj, IHook<Trait> hook)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			if (hook is null) throw new ArgumentNullException(nameof(hook));
			GetHookController(obj, ref obj.__RogueLibsHooks, true).AddHook(hook);
		}

		public static THook AddHook<THook>(this InvItem obj) where THook : IHook<InvItem>, new()
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			return GetHookController(obj, ref obj.__RogueLibsHooks, true).AddHook<THook>();
		}
		public static THook AddHook<THook>(this Agent obj) where THook : IHook<Agent>, new()
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			return GetHookController(obj, ref obj.__RogueLibsHooks, true).AddHook<THook>();
		}
		public static THook AddHook<THook>(this ObjectReal obj) where THook : IHook<ObjectReal>, new()
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			return GetHookController(obj, ref obj.__RogueLibsHooks, true).AddHook<THook>();
		}
		public static THook AddHook<THook>(this StatusEffect obj) where THook : IHook<StatusEffect>, new()
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			return GetHookController(obj, ref obj.__RogueLibsHooks, true).AddHook<THook>();
		}
		public static THook AddHook<THook>(this Trait obj) where THook : IHook<Trait>, new()
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			return GetHookController(obj, ref obj.__RogueLibsHooks, true).AddHook<THook>();
		}

		public static bool RemoveHook(this InvItem obj, IHook<InvItem> hook)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			return GetHookController(obj, ref obj.__RogueLibsHooks, false)?.RemoveHook(hook) == true;
		}
		public static bool RemoveHook(this Agent obj, IHook<Agent> hook)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			return GetHookController(obj, ref obj.__RogueLibsHooks, false)?.RemoveHook(hook) == true;
		}
		public static bool RemoveHook(this ObjectReal obj, IHook<ObjectReal> hook)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			return GetHookController(obj, ref obj.__RogueLibsHooks, false)?.RemoveHook(hook) == true;
		}
		public static bool RemoveHook(this StatusEffect obj, IHook<StatusEffect> hook)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			return GetHookController(obj, ref obj.__RogueLibsHooks, false)?.RemoveHook(hook) == true;
		}
		public static bool RemoveHook(this Trait obj, IHook<Trait> hook)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			return GetHookController(obj, ref obj.__RogueLibsHooks, false)?.RemoveHook(hook) == true;
		}

		public static bool RemoveHook<THook>(this InvItem obj) where THook : IHook<InvItem>
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			return GetHookController(obj, ref obj.__RogueLibsHooks, false)?.RemoveHook<THook>() == true;
		}
		public static bool RemoveHook<THook>(this Agent obj) where THook : IHook<Agent>
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			return GetHookController(obj, ref obj.__RogueLibsHooks, false)?.RemoveHook<THook>() == true;
		}
		public static bool RemoveHook<THook>(this ObjectReal obj) where THook : IHook<ObjectReal>
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			return GetHookController(obj, ref obj.__RogueLibsHooks, false)?.RemoveHook<THook>() == true;
		}
		public static bool RemoveHook<THook>(this StatusEffect obj) where THook : IHook<StatusEffect>
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			return GetHookController(obj, ref obj.__RogueLibsHooks, false)?.RemoveHook<THook>() == true;
		}
		public static bool RemoveHook<THook>(this Trait obj) where THook : IHook<Trait>
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			return GetHookController(obj, ref obj.__RogueLibsHooks, false)?.RemoveHook<THook>() == true;
		}

		public static THook GetHook<THook>(this InvItem obj)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			HookController<InvItem> controller = GetHookController(obj, ref obj.__RogueLibsHooks, false);
			return controller != null ? controller.GetHook<THook>() : default;
		}
		public static THook GetHook<THook>(this Agent obj)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			HookController<Agent> controller = GetHookController(obj, ref obj.__RogueLibsHooks, false);
			return controller != null ? controller.GetHook<THook>() : default;
		}
		public static THook GetHook<THook>(this ObjectReal obj)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			HookController<ObjectReal> controller = GetHookController(obj, ref obj.__RogueLibsHooks, false);
			return controller != null ? controller.GetHook<THook>() : default;
		}
		public static THook GetHook<THook>(this StatusEffect obj)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			HookController<StatusEffect> controller = GetHookController(obj, ref obj.__RogueLibsHooks, false);
			return controller != null ? controller.GetHook<THook>() : default;
		}
		public static THook GetHook<THook>(this Trait obj)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			HookController<Trait> controller = GetHookController(obj, ref obj.__RogueLibsHooks, false);
			return controller != null ? controller.GetHook<THook>() : default;
		}
		public static UnlockWrapper GetHook(this Unlock obj)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			return (UnlockWrapper)obj.__RogueLibsCustom;
		}

		public static IEnumerable<THook> GetHooks<THook>(this InvItem obj)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			return GetHookController(obj, ref obj.__RogueLibsHooks, false)?.GetHooks<THook>() ?? Enumerable.Empty<THook>();
		}
		public static IEnumerable<THook> GetHooks<THook>(this Agent obj)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			return GetHookController(obj, ref obj.__RogueLibsHooks, false)?.GetHooks<THook>() ?? Enumerable.Empty<THook>();
		}
		public static IEnumerable<THook> GetHooks<THook>(this ObjectReal obj)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			return GetHookController(obj, ref obj.__RogueLibsHooks, false)?.GetHooks<THook>() ?? Enumerable.Empty<THook>();
		}
		public static IEnumerable<THook> GetHooks<THook>(this StatusEffect obj)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			return GetHookController(obj, ref obj.__RogueLibsHooks, false)?.GetHooks<THook>() ?? Enumerable.Empty<THook>();
		}
		public static IEnumerable<THook> GetHooks<THook>(this Trait obj)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			return GetHookController(obj, ref obj.__RogueLibsHooks, false)?.GetHooks<THook>() ?? Enumerable.Empty<THook>();
		}

		public static StatusEffects GetStatusEffects(this StatusEffect statusEffect)
		{
			if (statusEffect is null) throw new ArgumentNullException(nameof(statusEffect));
			return (StatusEffects)statusEffect.__RogueLibsContainer;
		}
		public static StatusEffects GetStatusEffects(this Trait trait)
		{
			if (trait is null) throw new ArgumentNullException(nameof(trait));
			return (StatusEffects)trait.__RogueLibsContainer;
		}
	}
	public static class RogueExtensions
	{
		public static T AddItem<T>(this InvDatabase inventory, int amount)
			where T : CustomItem
		{
			if (inventory is null) throw new ArgumentNullException(nameof(inventory));
			if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount), amount, $"{nameof(amount)} must be greater than 0.");
			InvItem item = inventory.AddItem(ItemInfo.Get<T>().Name, amount);
			return item.GetHook<T>();
		}
		public static T GetItem<T>(this InvDatabase inventory)
			where T : CustomItem
		{
			if (inventory is null) throw new ArgumentNullException(nameof(inventory));
			InvItem item = inventory.FindItem(ItemInfo.Get<T>().Name);
			return item?.GetHook<T>();
		}
		public static bool HasItem<T>(this InvDatabase inventory)
			where T : CustomItem
		{
			if (inventory is null) throw new ArgumentNullException(nameof(inventory));
			InvItem item = inventory.FindItem(ItemInfo.Get<T>().Name);
			return item != null;
		}
		public static bool HasItem<T>(this InvDatabase inventory, int amount)
			where T : CustomItem
		{
			if (inventory is null) throw new ArgumentNullException(nameof(inventory));
			string itemName = ItemInfo.Get<T>().Name;
			List<InvItem> items = inventory.InvItemList.FindAll(i => i.invItemName == itemName);
			return items.Sum(i => i.invItemCount) >= amount;
		}

		public static UnlockButtonState GetState(this ButtonData buttonData)
		{
			if (buttonData is null) throw new ArgumentNullException(nameof(buttonData));
			if (buttonData.scrollingHighlighted) return UnlockButtonState.Selected;
			if (buttonData.scrollingHighlighted2) return UnlockButtonState.Purchasable;
			if (buttonData.scrollingHighlighted3) return UnlockButtonState.Locked;
			if (buttonData.scrollingHighlighted4) return UnlockButtonState.Disabled;
			else return UnlockButtonState.Normal;
		}
		public static void SetState(this ButtonData buttonData, UnlockButtonState value)
		{
			if (buttonData is null) throw new ArgumentNullException(nameof(buttonData));
			buttonData.scrollingHighlighted = value == UnlockButtonState.Selected;
			buttonData.scrollingHighlighted2 = value == UnlockButtonState.Purchasable;
			buttonData.scrollingHighlighted3 = value == UnlockButtonState.Locked;
			buttonData.scrollingHighlighted4 = value == UnlockButtonState.Disabled;
			buttonData.highlightedSprite = value == UnlockButtonState.Selected
					? buttonData.scrollingMenu?.solidObjectButtonSelected ?? buttonData.characterCreation.solidObjectButtonSelected
				: value == UnlockButtonState.Purchasable
					? buttonData.scrollingMenu?.solidObjectButtonLocked ?? buttonData.characterCreation.solidObjectButtonLocked
				: value == UnlockButtonState.Locked
					? buttonData.scrollingMenu?.solidObjectButtonRed ?? buttonData.characterCreation.solidObjectButtonRed
				: value == UnlockButtonState.Disabled
					? buttonData.scrollingMenu?.solidObjectButton ?? buttonData.characterCreation.solidObjectButton
				: buttonData.scrollingMenu?.solidObjectButton ?? buttonData.characterCreation.solidObjectButton;
		}

		public static T AddTrait<T>(this Agent agent)
			where T : CustomTrait
		{
			if (agent is null) throw new ArgumentNullException(nameof(agent));
			string traitName = TraitInfo.Get<T>().Name;
			agent.statusEffects.AddTrait(traitName);
			return agent.statusEffects.TraitList.Find(t => t.traitName == traitName)?.GetHook<T>();
		}
		public static T GetTrait<T>(this Agent agent)
			where T : CustomTrait
		{
			if (agent is null) throw new ArgumentNullException(nameof(agent));
			string traitName = TraitInfo.Get<T>().Name;
			return agent.statusEffects.TraitList.Find(t => t.traitName == traitName)?.GetHook<T>();
		}
		public static bool HasTrait<T>(this Agent agent) where T : CustomTrait
		{
			if (agent is null) throw new ArgumentNullException(nameof(agent));
			return agent.statusEffects.hasTrait(TraitInfo.Get<T>().Name);
		}

		public static Trait AddTrait(this Agent agent, string traitName)
		{
			if (agent is null) throw new ArgumentNullException(nameof(agent));
			agent.statusEffects.AddTrait(traitName);
			return agent.GetTrait(traitName);
		}
		public static Trait GetTrait(this Agent agent, string traitName)
		{
			if (agent is null) throw new ArgumentNullException(nameof(agent));
			return agent.statusEffects.TraitList.Find(t => t.traitName == traitName);
		}
		public static bool HasTrait(this Agent agent, string traitName)
		{
			if (agent is null) throw new ArgumentNullException(nameof(agent));
			return agent.statusEffects.hasTrait(traitName);
		}
	}
}
