using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RogueLibsCore.Test
{
	[ItemCategories(RogueCategories.Technology)]
	public class Recycler : CustomItem, IItemCombinable
	{
		public static void Test()
		{
			RogueLibs.CreateCustomItem<Recycler>()
				.WithName(new CustomNameInfo("Recycler"))
				.WithDescription(new CustomNameInfo("Recycles an item into something else, but of lesser value."))
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

		private int DetermineCost(InvItem item, out int removeCount)
		{
			float myCostFloat;
			if (item.hasCharges)
			{
				myCostFloat = item.itemValue * item.invItemCount;
				removeCount = item.invItemCount;
			}
			else if (item.itemType == "WeaponMelee" || item.itemType == "WeaponProjectile" || item.itemType == "Wearable")
			{
				float durability = item.invItemCount / item.initCount;
				myCostFloat = item.itemValue * durability * durability;
				removeCount = item.invItemCount;
			}
			else
			{
				myCostFloat = item.itemValue;
				removeCount = 1;
			}
			return (int)Mathf.Ceil(0.9f * myCostFloat);
		}
		public bool CombineItems(InvItem other)
		{
			if (!CombineFilter(other)) return false;

			int myCost = DetermineCost(other, out int removeCount);

			List<InvItem> pool = new List<InvItem>();
			foreach (Unlock unlock in gc.sessionDataBig.unlocks.Where(u => u.unlockType == "Item"))
			{
				InvItem candidate = new InvItem { invItemName = unlock.unlockName };
				candidate.SetupDetails(false);
				int candidateCost;
				if (candidate.hasCharges)
				{
					candidate.invItemCount = candidate.initCount;
					candidateCost = candidate.itemValue * candidate.initCount;
				}
				else if (candidate.itemType == "WeaponMelee" || candidate.itemType == "WeaponProjectile" || candidate.itemType == "Wearable")
				{
					candidate.invItemCount = candidate.initCount;
					candidateCost = candidate.itemValue;
				}
				else
				{
					candidate.invItemCount = 1;
					candidateCost = candidate.itemValue;
				}

				if (candidateCost < myCost) pool.Add(candidate);
			}

			if (pool.Count is 0)
			{
				Owner.SayDialogue("RecyclerTooCheap");
				gc.audioHandler.Play(Owner, "CantDo");
				return false;
			}

			InvItem item = pool[new System.Random().Next(pool.Count)];
			Inventory.SubtractFromItemCount(other, removeCount);
			Count--;
			Inventory.AddItem(item);
			gc.audioHandler.Play(Owner, "CombineItem");

			return true;
		}
		public CustomTooltip CombineCursorText(InvItem other) => gc.nameDB.GetName("Recycle", "Interface");
		public CustomTooltip CombineTooltip(InvItem other)
		{
			int cost = DetermineCost(other, out int removeCount);
			string text = "$" + cost;
			if (removeCount != other.invItemCount) text += $" ({removeCount})";
			return text;
		}
	}
}
