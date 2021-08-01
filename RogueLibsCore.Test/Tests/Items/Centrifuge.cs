using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLibsCore.Test
{
	public class Centrifuge : CustomItem, IItemCombinable
	{
		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomItem<Centrifuge>()
				.WithName(new CustomNameInfo("Centrifuge"))
				.WithDescription(new CustomNameInfo("Combine with a syringe to invert its effect."))
				.WithSprite(Properties.Resources.Centrifuge)
				.WithUnlock(new ItemUnlock
				{
					UnlockCost = 10,
					LoadoutCost = 5,
					CharacterCreationCost = 3,
					Prerequisites = { "Antidote" },
				});
		}

		public override void SetupDetails()
		{
			Item.itemType = ItemTypes.Combine;
			Item.itemValue = 8;
			Item.initCount = 10;
			Item.stackable = true;
			Item.hasCharges = true;
		}

		private static readonly Dictionary<string, string> invertDictionary = new Dictionary<string, string>
		{
			["Poisoned"] = "RegenerateHealth",
			["Slow"] = "Fast",
			["Weak"] = "Strength",
			["Acid"] = "Invincible",
			["Confused"] = "Invisible",
		};
		static Centrifuge()
		{
			foreach (KeyValuePair<string, string> pair in invertDictionary.ToArray())
				invertDictionary.Add(pair.Value, pair.Key);
		}

		public bool CombineFilter(InvItem other) => other.invItemName == "Syringe"
			&& other.contents.Count > 0 && invertDictionary.ContainsKey(other.contents[0]);
		public bool CombineItems(InvItem other)
		{
			if (!CombineFilter(other)) return false;

			other.contents[0] = invertDictionary[other.contents[0]];

			Count--;
			gc.audioHandler.Play(Owner, "CombineItem");
			return true;
		}
		public CustomTooltip CombineCursorText(InvItem other) => default;
		public CustomTooltip CombineTooltip(InvItem other) => default;
	}
}
