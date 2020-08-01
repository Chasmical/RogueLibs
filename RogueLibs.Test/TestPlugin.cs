using BepInEx;
using UnityEngine;

namespace RogueLibsCore.Test
{
#pragma warning disable CS1591

	[BepInPlugin(pluginGuid, pluginName, pluginVersion)]
	[BepInDependency(RogueLibs.pluginGuid, "2.0.0")]
	public class TestPlugin : BaseUnityPlugin
	{
		public const string pluginGuid = "abbysssal.streetsofrogue.roguelibs.test";
		public const string pluginName = "RogueLibs.Test";
		public const string pluginVersion = "0.6.0";

		public void Awake()
		{
			Sprite noSprite = RogueUtilities.ConvertToSprite(new byte[0]);

			#region Giant Ability
			CustomAbility giantAbility = RogueLibs.CreateCustomAbility("GiantAbility_u", noSprite, false,
				new CustomNameInfo("Giant"),
				new CustomNameInfo("Gives you Giant status effect"),
				item =>
				{
					item.lowCountThreshold = 100;
					item.initCount = 0;
					item.stackable = true;
				});

			giantAbility.OnPressed = (item, agent) =>
			{
				if (item.invItemCount > 0) // is recharging
					agent.gc.audioHandler.Play(agent, "CantDo");
				else
				{
					agent.statusEffects.AddStatusEffect("Giant", true, true, 3);
					agent.inventory.buffDisplay.specialAbilitySlot.MakeNotUsable();
					// make special ability slot half-transparent
					item.invItemCount = 100; // 100 x 0.13f = 13 seconds to recharge
											 // or you can replace 100 with 13, and 0.13 with 1 to make it simpler
				}
			};
			giantAbility.RechargeInterval = (item, agent)
				=> item.invItemCount > 0 ? new WaitForSeconds(0.13f) : null;
			giantAbility.Recharge = (item, agent) =>
			{
				if (item.invItemCount > 0 && agent.statusEffects.CanRecharge())
				{ // if can recharge
					item.invItemCount--;
					if (item.invItemCount == 0) // ability recharged
					{
						agent.statusEffects.CreateBuffText("Recharged", agent.objectNetID);
						agent.gc.audioHandler.Play(agent, "Recharge");
						agent.inventory.buffDisplay.specialAbilitySlot.MakeUsable();
						// make special ability slot fully visible
					}
				}
			};
			giantAbility.UnlockCost = 5;
			giantAbility.CostInCharacterCreation = 10;
			#endregion

			#region Regeneration Ability
			CustomAbility regeneration = RogueLibs.CreateCustomAbility("RegenerationAbility_u", noSprite, false,
				new CustomNameInfo("Regeneration"),
				new CustomNameInfo("Use it to regenerate health"),
				item =>
				{
					item.initCount = 0;
					item.stackable = true;
				});

			regeneration.OnHeld = (InvItem item, Agent agent, ref float time) =>
			{
				if (time * 2f > item.invItemCount && item.invItemCount < 10)
					item.invItemCount++;
			};
			regeneration.OnReleased = (item, agent) =>
			{
				if (item.invItemCount < 2) return;
				agent.statusEffects.ChangeHealth(item.invItemCount);
				item.invItemCount = 0;
				agent.gc.audioHandler.Play(agent, "Heal");
			};
			regeneration.UnlockCost = 3;
			regeneration.CostInCharacterCreation = 10;
			#endregion

			#region Cool Trait 
			CustomTrait someCoolTrait = RogueLibs.CreateCustomTrait("SomeCoolTrait_u3", false,
				new CustomNameInfo("Cool Trait"),
				new CustomNameInfo("It's a very cool trait. It does a lot of cool stuff."));
			someCoolTrait.UnlockCost = 2;
			someCoolTrait.CostInCharacterCreation = 5;
			#endregion

			#region Cool Trait +
			CustomTrait someCoolTrait2 = RogueLibs.CreateCustomTrait("SomeCoolTrait2_u3", false,
				new CustomNameInfo("<color=purple>Cool Trait +</color>"),
				new CustomNameInfo("It's an extremely cool trait! You won't believe what it can do!"));
			someCoolTrait.Upgrade = someCoolTrait2.Id;
			someCoolTrait.Conflicting.Add(someCoolTrait2.Id);
			someCoolTrait2.UnlockCost = 8;
			someCoolTrait2.Prerequisites.Add(someCoolTrait.Id);
			someCoolTrait2.CostInCharacterCreation = 10;
			someCoolTrait2.Recommendations.Add("Banana");
			someCoolTrait.GetSpecialUnlockInfo = unlock => "Some unique method of unlocking the trait.";
			#endregion

			#region Wild Bypasser
			CustomItem wildBypasser = RogueLibs.CreateCustomItem("WildBypasser_u3", RogueUtilities.ConvertToSprite(Properties.Resources.WildBypasser), false,
				new CustomNameInfo("Wild Bypasser",
					null, null, null, null,
					"Универсальный проход сквозь стены",
					null, null),
				new CustomNameInfo("Warps you in the direction you're facing. Teleports through any amount of walls.",
					null, null, null, null,
					"Перемещает тебя в направлении, в которое ты смотришь. Телепортирует сквозь любое количество стен.",
					null, null),
				item =>
				{
					item.itemType = "Tool";
					item.Categories.Add("Technology");
					item.Categories.Add("Usable");
					item.Categories.Add("Stealth");
					item.itemValue = 60;
					item.initCount = 1;
					item.rewardCount = 2;
					item.stackable = true;
					item.goesInToolbar = true;
				});
			wildBypasser.UnlockCost = 3;
			wildBypasser.CostInCharacterCreation = 5;
			wildBypasser.Conflicting.Add("NoFollowers");
			wildBypasser.Prerequisites.Add(someCoolTrait2.Id);
			wildBypasser.UseItem = (item, agent) =>
			{
				Vector3 position = agent.agentHelperTr.localPosition = Vector3.zero;
				TileData tileData;
				int limit = 0;
				do
				{
					position.x += 0.64f;
					agent.agentHelperTr.localPosition = position;
					tileData = GameController.gameController.tileInfo.GetTileData(agent.agentHelperTr.position);

				} while ((GameController.gameController.tileInfo.IsOverlapping(agent.agentHelperTr.position, "Anything") || tileData.wallMaterial != wallMaterialType.None) && limit++ < 250);

				if (limit > 249) return;

				agent.SpawnParticleEffect("Spawn", agent.tr.position);
				agent.Teleport(new Vector3(agent.agentHelperTr.position.x, agent.agentHelperTr.position.y, agent.tr.position.z), false, true);
				agent.rb.velocity = Vector2.zero;

				if (!(agent.statusEffects.hasTrait("ThiefToolsMayNotSubtract2") && GameController.gameController.percentChance(agent.DetermineLuck(80, "ThiefToolsMayNotSubtract", true))) && !(agent.statusEffects.hasTrait("ThiefToolsMayNotSubtract") && GameController.gameController.percentChance(agent.DetermineLuck(40, "ThiefToolsMayNotSubtract", true))))
					item.database.SubtractFromItemCount(item, 1);

				agent.SpawnParticleEffect("Spawn", agent.tr.position, false);
				GameController.gameController.audioHandler.Play(agent, "Spawn");

				new ItemFunctions().UseItemAnim(item, agent);
			};
			#endregion

			#region Quantum Fud
			CustomItem quantumFud = RogueLibs.CreateCustomItem("QuantumFud", RogueUtilities.ConvertToSprite(Properties.Resources.QuantumFud), true,
				new CustomNameInfo("Quantum Fud",
					null, null, null, null,
					"Квантовый хафчик",
					null, null),
				new CustomNameInfo("A very complicated piece of quantum technology. When you eat it, its quantum equivalent clone is consumed, while the original thing remains intact.",
					null, null, null, null,
					"Очень сложное квантовое устройство. При его поедании, потребляется его квантово-эквивалентный клон, в то время как оригинал остаётся нетронутым.",
					null, null),
				item =>
				{
					item.itemType = "Food";
					item.Categories.Add("Food");
					item.Categories.Add("Technology");
					item.itemValue = 180;
					item.healthChange = 1;
					item.cantBeCloned = true;
					item.goesInToolbar = true;
				});

			quantumFud.UseItem = (item, agent) =>
			{
				if (agent.statusEffects.hasTrait("OilRestoresHealth"))
					agent.SayDialogue("OnlyOilGivesHealth");
				else if (agent.statusEffects.hasTrait("BloodRestoresHealth"))
					agent.SayDialogue("OnlyBloodGivesHealth");
				else if (agent.electronic)
					agent.SayDialogue("OnlyChargeGivesHealth");
				else if (agent.statusEffects.hasTrait("CannibalizeRestoresHealth"))
					agent.SayDialogue("OnlyCannibalizeGivesHealth");
				else if (agent.health == agent.healthMax)
					agent.SayDialogue("HealthFullCantUseItem");
				else
				{
					int num23 = new ItemFunctions().DetermineHealthChange(item, agent);
					agent.statusEffects.ChangeHealth(num23);
					if (agent.statusEffects.hasTrait("HealthItemsGiveFollowersExtraHealth") || agent.statusEffects.hasTrait("HealthItemsGiveFollowersExtraHealth2"))
					{
						new ItemFunctions().GiveFollowersHealth(agent, num23);
					}
					item.gc.audioHandler.Play(agent, "UseFood");
					new ItemFunctions().UseItemAnim(item, agent);
					return;
				}
				item.gc.audioHandler.Play(agent, "CantDo");
			};
			#endregion

			#region SPYTRON 3000
			CustomItem spytron3000 = RogueLibs.CreateCustomItem("SPYTRON3000", RogueUtilities.ConvertToSprite(Properties.Resources.SPYTRON3000), true,
				new CustomNameInfo("SPYTRON 3000",
					null, null, null, null,
					"Шпионотрон 3000",
					null, null),
				new CustomNameInfo("Always wanted to be someone else? Now you can!",
					null, null, null, null,
					"Всегда хотели быть кем-то другим? Теперь вы можете!",
					null, null),
				item =>
				{
					item.itemType = "Tool";
					item.Categories.Add("Social");
					item.Categories.Add("Stealth");
					item.Categories.Add("Technology");
					item.Categories.Add("Usable");
					item.itemValue = 80;
					item.initCount = 2;
					item.rewardCount = 3;
					item.stackable = true;
					item.goesInToolbar = true;
				});
			spytron3000.TargetFilter = (item, agent, obj) => obj is Agent a && !a.dead && a != agent;
			spytron3000.TargetObject = (item, agent, obj) =>
			{
				Agent target = (Agent)obj;

				string prev = agent.agentName;
				agent.agentName = target.agentName;

				agent.relationships.CopyLooks(target);

				agent.gc.audioHandler.Play(agent, "Spawn");
				agent.gc.spawnerMain.SpawnParticleEffect("Spawn", agent.tr.position, 0f);

				foreach (Relationship rel in target.relationships.RelList)
				{
					Relationship otherRel = rel.agent.relationships.GetRelationship(target);

					agent.relationships.SetRel(rel.agent, rel.relType);
					agent.relationships.SetRelHate(rel.agent, 0);
					agent.relationships.GetRelationship(rel.agent).secretHate = rel.secretHate;
					agent.relationships.GetRelationship(rel.agent).mechHate = rel.mechHate;

					rel.agent.relationships.SetRel(agent, otherRel.relType);
					rel.agent.relationships.SetRelHate(agent, 0);
					rel.agent.relationships.GetRelationship(agent).secretHate = otherRel.secretHate;
					rel.agent.relationships.GetRelationship(agent).mechHate = otherRel.mechHate;
				}

				target.relationships.SetRel(agent, "Hateful");
				target.relationships.SetRelHate(agent, 25);
				agent.agentName = prev;

				item.database.SubtractFromItemCount(item, 1);
				item.invInterface.HideTarget();
			};
			spytron3000.SetTargetText(new CustomNameInfo("Disguise",
				null, null, null, null,
				"Замаскироваться",
				null, null));
			#endregion

			#region Portable Ammo Dispenser
			Sprite sprite7 = RogueUtilities.ConvertToSprite(Properties.Resources.PortableAmmoDispenser);
			CustomItem portableAmmoDispenser = RogueLibs.CreateCustomItem("PortableAmmoDispenser", sprite7, true,
				new CustomNameInfo("Portable Ammo Dispenser",
				null, null, null, null,
				"Портативный раздатчик боеприпасов",
				null, null),
				new CustomNameInfo("Use it to refill your ranged weapons' ammo. For money, of course.",
				null, null, null, null,
				"Используйте для пополнения запаса патронов у оружия дальнего боя. За деньги, конечно же.",
				null, null),
				item =>
				{
					item.itemType = "Combine";
					item.Categories.Add("Technology");
					item.Categories.Add("GunAccessory");
					item.Categories.Add("Guns");
					item.itemValue = 80;
					item.initCount = 1;
					item.rewardCount = 1;
				});
			portableAmmoDispenser.CombineFilter = (item, agent, otherItem) => otherItem.itemType == "WeaponProjectile" && !otherItem.noRefills;
			portableAmmoDispenser.CombineItems = (item, agent, otherItem) =>
			{
				int amountToRefill = otherItem.maxAmmo - otherItem.invItemCount;
				float singleCost = (float)otherItem.itemValue / otherItem.maxAmmo;
				if (agent.oma.superSpecialAbility && (agent.agentName == "Soldier" || agent.agentName == "Doctor"))
					singleCost = 0f;
				if (otherItem.invItemCount >= otherItem.maxAmmo)
				{
					agent.SayDialogue("AmmoDispenserFull");
					agent.gc.audioHandler.Play(agent, "CantDo");
				}
				else if (agent.inventory.money.invItemCount < amountToRefill * singleCost)
				{
					int affordableAmount = (int)Mathf.Floor(agent.inventory.money.invItemCount / singleCost);

					if (affordableAmount == 0)
					{
						agent.SayDialogue("NeedCash");
						agent.gc.audioHandler.Play(agent, "CantDo");
						return;
					}
					agent.inventory.SubtractFromItemCount(agent.inventory.money, (int)Mathf.Ceil(affordableAmount * singleCost));
					otherItem.invItemCount += affordableAmount;
					agent.SayDialogue("AmmoDispenserFilled");
					agent.gc.audioHandler.Play(agent, "BuyItem");
					new ItemFunctions().UseItemAnim(item, agent);
				}
				else
				{
					agent.inventory.money.invItemCount -= (int)Mathf.Ceil(amountToRefill * singleCost);
					otherItem.invItemCount = otherItem.maxAmmo;
					agent.SayDialogue("AmmoDispenserFilled");
					agent.gc.audioHandler.Play(agent, "BuyItem");
					new ItemFunctions().UseItemAnim(item, agent);
				}

			};
			portableAmmoDispenser.CombineTooltip = (item, agent, otherItem) =>
			{
				if (otherItem.invItemName == "PortableAmmoDispenser") return null;

				int amountToRefill = otherItem.maxAmmo - otherItem.invItemCount;
				if (amountToRefill < 1) return null;

				float singleCost = (float)otherItem.itemValue / otherItem.maxAmmo;
				if (agent.oma.superSpecialAbility && (agent.agentName == "Soldier" || agent.agentName == "Doctor"))
					singleCost = 0f;
				int amount = (int)Mathf.Ceil(amountToRefill * singleCost);

				return "$" + amount;
			};
			#endregion

			#region Joke Book
			Sprite sprite9 = RogueUtilities.ConvertToSprite(Properties.Resources.JokeBook);
			CustomItem jokeBook = RogueLibs.CreateCustomItem("JokeBook", sprite9, true,
				new CustomNameInfo("Joke Book",
				null, null, null, null,
				"Сборник шуток",
				null, null),
				new CustomNameInfo("Always wanted to be a Comedian? Now you can! (kind of)",
				null, null, null, null,
				"Всегда хотели быть Комиком? Теперь вы можете! (ну, типа)",
				null, null),
				item =>
				{
					item.itemType = "Tool";
					item.Categories.Add("Usable");
					item.Categories.Add("Social");
					item.itemValue = 200;
					item.initCount = 10;
					item.rewardCount = 10;
					item.stackable = true;
					item.hasCharges = true;
					item.goesInToolbar = true;
				});
			jokeBook.UseItem = (item, agent) =>
			{
				string prev = agent.specialAbility;
				agent.specialAbility = "Joke";
				agent.statusEffects.PressedSpecialAbility();
				agent.specialAbility = prev;
				item.database.SubtractFromItemCount(item, 1);
				new ItemFunctions().UseItemAnim(item, agent);
			};
			#endregion

		}










	}

#pragma warning restore CS1591
}
