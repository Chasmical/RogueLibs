using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLibsCore.Test
{
	[ItemCategories(RogueCategories.Supplies, RogueCategories.Technology, RogueCategories.Usable)]
	public class LootBox : CustomItem, IItemUsable
	{
		public static void Test()
		{
			RogueLibs.CreateCustomItem<LootBox>()
				.WithName(new CustomNameInfo("Loot Box"))
				.WithDescription(new CustomNameInfo("Gives you a random item."))
				.WithUnlock(new ItemUnlock { UnlockCost = 10, CharacterCreationCost = 3, LoadoutCost = 3 });
		}

		public override void SetupDetails()
		{
			Item.itemType = ItemTypes.Tool;
			Item.itemValue = 40;
			Item.initCount = 2;
			Item.rewardCount = 3;
			Item.stackable = true;
			Item.goesInToolbar = true;
			Item.cantBeCloned = true;
		}
		public bool UseItem()
		{
			List<Unlock> unlockPool = gc.sessionDataBig.unlocks.FindAll(u => u.unlockType == "Item");
			List<InvItem> pool = new List<InvItem>();

			Random rnd = new Random();
			for (int i = 0; i < 3; i++)
			{
				Unlock u = unlockPool[rnd.Next(unlockPool.Count)];
				InvItem item = new InvItem { invItemName = u.unlockName };
				item.SetupDetails(false);
				pool.Add(item);
			}

			InvItem selected = pool[0];
			for (int i = 1; i < pool.Count; i++)
				if (pool[i].itemValue < selected.itemValue)
					selected = pool[i];

			Count--;
			Inventory.AddItem(selected);
			gc.audioHandler.Play(Owner, "BeginCombine");

			return true;
		}
	}
}
