using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RogueLibsCore.Test
{
	[ItemCategories(RogueCategories.Technology)]
	public class Converter : CustomItem, IItemCombinable
	{
		public static void Test()
		{
			RogueLibs.CreateCustomItem<Converter>()
				.WithName(new CustomNameInfo("Converter"))
				.WithDescription(new CustomNameInfo("Converts an item into something else, but of lesser value."))
				.WithSprite(Properties.Resources.Converter)
				.WithUnlock(new ItemUnlock { UnlockCost = 10, CharacterCreationCost = 5, LoadoutCost = 5 });

			RogueLibs.CreateCustomName("RecyclerTooCheap", "Dialogue", new CustomNameInfo("This thing is too cheap!"));
			RogueLibs.CreateCustomName("Recycle", "Interface", new CustomNameInfo("Recycle"));
		}

		public override void SetupDetails()
		{
			Item.itemType = ItemTypes.Combine;
			Item.initCount = 5;
			Item.itemValue = 20;
			Item.stackable = true;
			Item.hasCharges = true;
		}
		public bool CombineFilter(InvItem other) => !other.questItem && !other.CantDrop(Owner);

		private int DetermineCount(InvItem item)
			=> item.isArmor || item.isArmorHead || item.hasCharges || item.isWeapon && item.itemType != ItemTypes.WeaponThrown
					? item.invItemCount : 1;
		public bool CombineItems(InvItem other)
		{
			if (!CombineFilter(other)) return false;

			int myCost = (int)Mathf.Ceil(0.8f * Owner.determineMoneyCost(other, other.itemValue, ""));
			int removeCount = DetermineCount(other);

			List<InvItem> pool = new List<InvItem>();
			foreach (Unlock unlock in gc.sessionDataBig.unlocks.Where(u => u.unlockType == "Item"))
			{
				InvItem candidate = new InvItem { invItemName = unlock.unlockName };
				candidate.SetupDetails(false);
				if (candidate.itemValue < 1 || candidate.initCount == 0) continue;
				candidate.invItemCount = candidate.initCount;

				int candidateCost = Owner.determineMoneyCost(candidate, candidate.itemValue, "");
				if (candidateCost < myCost) pool.Add(candidate);
			}

			if (pool.Count is 0)
			{
				Owner.SayDialogue("RecyclerTooCheap");
				gc.audioHandler.Play(Owner, "CantDo");
				return false;
			}

			pool.Sort((a, b) => -a.itemValue.CompareTo(b.itemValue));
			int rndCount = Mathf.Min(pool.Count, 10);

			InvItem item = pool[new System.Random().Next(rndCount)];
			Inventory.SubtractFromItemCount(other, removeCount);
			Count--;
			Inventory.AddItem(item);
			gc.audioHandler.Play(Owner, "CombineItem");

			return true;
		}
		public CustomTooltip CombineCursorText(InvItem other) => gc.nameDB.GetName("Recycle", "Interface");
		public CustomTooltip CombineTooltip(InvItem other)
		{
			int cost = Owner.determineMoneyCost(other, other.itemValue, "");
			int removeCount = DetermineCount(other);
			string text = "$" + cost;
			if (removeCount != other.invItemCount) text += $" ({removeCount})";
			return text;
		}
	}
}
