using UnityEngine;

namespace RogueLibsCore
{
    public static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_AmmoDispenser()
        {
            Patch<AmmoDispenser>(Params2);
            PatchInteract<AmmoDispenser>();
            RogueInteractions.CreateProvider<AmmoDispenser>(static h =>
            {
                if (h.Helper.interactingFar)
                {
                    if (h.Object.hacked == 0)
                    {
                        h.AddButton("ReduceAmmoPrices", static m =>
                        {
                            m.gc.audioHandler.Play(m.Agent, "Success");
                            m.Object.ReduceAmmoPrices(m.Agent);
                            m.StopInteraction();
                        });
                    }
                }
                else if (h.Object.functional)
                {
                    h.SetStopCallback(static m => m.Agent.SayDialogue("CantUseAmmoDispenser"));

                    if (h.Agent.inventory.InvItemList.Exists(static i => i.itemType == ItemTypes.WeaponProjectile) || h.Agent.mechFilled
                        || h.Agent.bigQuest == "Alien" && h.Agent.oma.bigQuestObjectCount < 3 && !h.Agent.interactionHelper.interactingFar
                        && !h.gc.loadLevel.LevelContainsMayor())
                    {
                        h.AddButton("RefillGun", static m => m.Object.ShowUseOn("RefillGun"));
                    }
                    if (h.Agent.statusEffects.hasTrait("OilRestoresHealth"))
                    {
                        InvItem invItem = new InvItem { invItemName = "OilContainer", invItemCount = 1 };
                        invItem.ItemSetup(false);

                        float costMultiplier = h.Agent.statusEffects.hasTrait("OilRestoresMoreHealth")
                                               || h.Agent.oma.superSpecialAbility ? 3f : 1.5f;
                        invItem.itemValue = (int)(invItem.itemValue / costMultiplier);
                        float currentHealthCost = h.Agent.health / invItem.initCount * invItem.itemValue;
                        int healCost = Mathf.Clamp(h.Object.determineMoneyCost((int)(h.Agent.healthMax / invItem.initCount * invItem.itemValue - currentHealthCost), "AmmoDispenser"), 0, 9999);
                        if (healCost > 0)
                        {
                            h.AddButton("GiveMechOil", healCost, static m =>
                            {
                                m.Object.GiveMechOil();
                                m.StopInteraction();
                            });
                        }
                    }
                }
            });
        }
    }
}
