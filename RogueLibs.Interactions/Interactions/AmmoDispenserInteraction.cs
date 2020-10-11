using System.Linq;
using UnityEngine;

namespace RogueLibsCore.Interactions
{
	internal class AmmoDispenserInteraction : CustomInteractionBase<AmmoDispenser>
	{
		public override void Patch()
		{
			base.Patch();

			ObjectInteraction reduceAmmoPrices = RogueLibsInteractions.CreateOriginalInteraction("ReduceAmmoPrices", InteractionType.Button,
				(agent, obj) => obj is AmmoDispenser a && !a.isBrokenShowButtons() && agent.interactionHelper.interactingFar && a.hacked == 0);
			reduceAmmoPrices.Action = (agent, obj) =>
			{
				obj.gc.audioHandler.Play(agent, "Success");
				((AmmoDispenser)obj).ReduceAmmoPrices(agent);
				return true;
			};

			ObjectInteraction hackExplode = RogueLibsInteractions.CreateOriginalInteraction("HackExplode", InteractionType.Button,
				(agent, obj) => obj is AmmoDispenser a && !a.isBrokenShowButtons() && agent.interactionHelper.interactingFar && ((agent.oma.superSpecialAbility && agent.agentName == "Hacker") || agent.statusEffects.hasTrait("HacksBlowUpObjects")));
			// action is defined in ObjectReal.PressedButton

			ObjectInteraction refillGun = RogueLibsInteractions.CreateOriginalInteraction("RefillGun", InteractionType.Button,
				(agent, obj) => obj is AmmoDispenser a && !a.isBrokenShowButtons() && !agent.interactionHelper.interactingFar && agent.inventory.InvItemList.Any(i => i.itemType == "WeaponProjectile"));
			refillGun.Action = (_, obj) =>
			{
				obj.ShowUseOn("RefillGun");
				return false;
			};

			ObjectInteraction giveMechOil = RogueLibsInteractions.CreateOriginalInteraction("GiveMechOil", InteractionType.Button,
				(agent, obj) =>
				{
					if (!(obj is AmmoDispenser a) || a.isBrokenShowButtons() || !agent.statusEffects.hasTrait("OilRestoresHealth")) return false;

					InvItem invItem = new InvItem
					{
						invItemName = "OilContainer",
						invItemCount = 1
					};
					invItem.ItemSetup(false);
					float num = 1.5f;
					if (agent.statusEffects.hasTrait("OilRestoresMoreHealth") || agent.oma.superSpecialAbility) num = 3f;

					invItem.itemValue = (int)(invItem.itemValue / num);
					float num2 = agent.health / invItem.initCount * invItem.itemValue;
					int num3 = Mathf.Max(obj.determineMoneyCost((int)(agent.healthMax / invItem.initCount * invItem.itemValue - num2), "AmmoDispenser"), 0);
					return num3 > 0;
				});
			giveMechOil.GetButtonInfo = (agent, obj) =>
			{
				InvItem invItem = new InvItem
				{
					invItemName = "OilContainer",
					invItemCount = 1
				};
				invItem.ItemSetup(false);
				float num = 1.5f;
				if (agent.statusEffects.hasTrait("OilRestoresMoreHealth") || agent.oma.superSpecialAbility) num = 3f;

				invItem.itemValue = (int)(invItem.itemValue / num);
				float num2 = agent.health / invItem.initCount * invItem.itemValue;
				int num3 = Mathf.Max(obj.determineMoneyCost((int)(agent.healthMax / invItem.initCount * invItem.itemValue - num2), "AmmoDispenser"), 0);

				return new ObjectInteractionInfo(num3);
			};
			giveMechOil.Action = (_, obj) =>
			{
				((AmmoDispenser)obj).GiveMechOil();
				return true;
			};

			ObjectInteraction collectPart = RogueLibsInteractions.CreateOriginalInteraction("CollectPart", InteractionType.Button,
				(agent, obj) => obj is AmmoDispenser a && !a.isBrokenShowButtons() && !agent.interactionHelper.interactingFar && agent.bigQuest == "Alien" && agent.oma.bigQuestObjectCount < 3 && !agent.interactionHelper.interactingFar && !obj.gc.loadLevel.LevelContainsMayor());
			// action is defined in ObjectReal.PressedButton

		}
		public static bool Interact2(AmmoDispenser __instance, Agent agent)
		{
			Interact(__instance, agent);
			if (__instance.buttonsHaveTooltips)
			{
				__instance.buttonsHaveTooltips = false;
				agent.SayDialogue("CantUseAmmoDispenser");
				__instance.StopInteraction();
			}
			return false;
		}

	}
}
