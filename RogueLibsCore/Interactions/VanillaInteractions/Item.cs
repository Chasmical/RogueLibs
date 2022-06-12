namespace RogueLibsCore
{
    public static partial class VanillaInteractions
    {
        [Include]
        private static void Patch_Item()
        {
            PatchInteract<Item>();

            RogueLibs.CreateCustomName("PickUp", "Interface", new CustomNameInfo
            {
                English = "Pick up",
                Russian = @"Подобрать",
            });

            RogueInteractions.CreateProvider<Item>(static h =>
            {
                if (h.Object.cantPickUp || h.Object.invItem.itemType is "NonItem" || h.Object.airborne) return;

                h.AddImplicitButton("PickUp", static m =>
                {
                    bool flag = m.Agent.isPlayer != 0 && !m.Agent.localPlayer;
                    bool flag2 = !m.Agent.inventory.AddItemAtEmptySlot(m.Object.invItem, true, false)
                                 && (!m.gc.serverPlayer || m.Agent.isPlayer == 0 || m.Agent.localPlayer);

                    UnityEngine.Debug.Log(
                        $"Attempted Add Item: {m.Object.invItem.invItemName} - {flag2} - {m.Agent.inventory.HasItem(m.Object.invItem.invItemName)}");

                    if (flag2 && !flag)
                    {
                        m.Agent.inventory.PlayerFullResponse(m.Agent);
                        m.Object.interactingAgent = null;
                        m.Object.someoneInteracting = false;
                        return;
                    }
                    if (flag2 && flag)
                    {
                        UnityEngine.Debug.LogError(@"Added item to failsafe list: " + m.Object.invItem.invItemName);
                        m.Agent.inventory.failsafeItemList.Add(m.Object.invItem);
                        m.Agent.objectMult.AddItem(m.Object.invItem, 0);
                    }
                    m.Object.invItem.agent = m.Agent;
                    m.Object.invItem.database = m.Agent.inventory;
                    if (m.gc.serverPlayer)
                    {
                        m.Object.invItem.ShowPickingUpText(m.Agent);
                    }
                    if (m.Agent.localPlayer)
                    {
                        m.gc.playerControl.pressedInteractTime[m.Agent.isPlayer - 1] = 0f;
                    }
                    if (!m.Object.invItem.CanSteal(m.Agent))
                    {
                        m.Object.invItem.stealable = false;
                        m.Object.invItem.treasureVal = 0;
                    }
                    else if (m.Object.invItem.treasureVal > 1)
                    {
                        if (!m.Object.invItem.questItem)
                        {
                            m.Agent.skillPoints.AddPoints("FindTreasure", m.Object.invItem.treasureVal);
                            m.Agent.skillPoints.RemoveTreasureVal(m.Object.invItem.treasureVal);
                        }
                        m.Object.invItem.treasureVal = 1;
                        m.Object.invItem.stealable = false;
                        m.gc.stats.AddToStat(m.Agent, "StoleItems", 1);
                    }
                    else if (m.Object.invItem.stealable && m.Object.invItem.treasureVal == 0)
                    {
                        m.Object.invItem.stealable = false;
                        if (!m.Object.invItem.questItem)
                        {
                            string type = m.Object.invItem.StealFromInnocent(m.Agent) ? "StealPointsNegative" : "StealPoints";
                            m.Agent.skillPoints.AddPoints(type, 1);
                        }
                        m.gc.stats.AddToStat(m.Agent, "StoleItems", 1);
                    }
                    m.Object.pickingUp = true;
                    if (m.Object.startingOwner != 0 && !m.Agent.statusEffects.hasTrait("NoStealPenalty")
                                                    && (m.Object.startingOwner != 888
                                                        || !m.Agent.statusEffects.hasStatusEffect("AboveTheLaw")))
                    {
                        m.gc.OwnCheck(m.Agent, m.Object.go, "Normal", 0);
                    }
                    m.Object.DestroyMe();
                    m.Agent.inventory.PlayPickupSound(m.Agent, m.Object.invItem);

                    m.StopInteraction();
                });
            });
        }
    }
}
