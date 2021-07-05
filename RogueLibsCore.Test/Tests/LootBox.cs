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

			RogueLibs.CreateCustomSprite("LootBox1", SpriteScope.Items, Properties.Resources.LootBox1);
			RogueLibs.CreateCustomSprite("LootBox2", SpriteScope.Items, Properties.Resources.LootBox2);
			RogueLibs.CreateCustomSprite("LootBox3", SpriteScope.Items, Properties.Resources.LootBox3);
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

			int rnd = new Random().Next(3) + 1;
			Item.LoadItemSprite($"LootBox{rnd}");
		}
		public bool UseItem()
		{
			List<Unlock> unlockPool = gc.sessionDataBig.unlocks.FindAll(u => u.unlockType == "Item");
			List<InvItem> pool = new List<InvItem>();

			Random rnd = new Random();
			for (int i = 0; i < 3; i++)
			{
				Unlock u;
				InvItem item;
				do
				{
					u = unlockPool[rnd.Next(unlockPool.Count)];
					item = new InvItem { invItemName = u.unlockName };
					item.SetupDetails(false);
				}
				while (item.itemValue < 1 || item.initCount == 0);

				item.invItemCount = item.initCount;
				pool.Add(item);
			}

			InvItem selected = pool[0];
			int selectedCost = Owner.determineMoneyCost(selected, selected.itemValue, "");
			for (int i = 1; i < pool.Count; i++)
			{
				int cost = Owner.determineMoneyCost(pool[i], pool[i].itemValue, "");
				if (cost < selectedCost)
				{
					selected = pool[i];
					selectedCost = cost;
				}
			}

			Count--;
			Inventory.AddItem(selected);
			gc.audioHandler.Play(Owner, "BeginCombine");

			return true;
		}
	}
}
