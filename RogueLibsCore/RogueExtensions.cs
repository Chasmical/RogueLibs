using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLibsCore
{
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
