using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace RogueLibsCore
{
    internal sealed partial class RogueLibsPlugin
    {
        public void PatchInteractions()
        {
            Patcher.Postfix(typeof(PlayfieldObject), "Awake");

            Type[] params1 = { typeof(string) };
            Type[] params2 = { typeof(string), typeof(int) };

            void Patch<T>(Type[] parameterTypes) where T : PlayfieldObject
            {
                Patcher.Prefix(typeof(T), nameof(PlayfieldObject.DetermineButtons), nameof(DetermineButtonsHook));
                Patcher.Prefix(typeof(T), nameof(PlayfieldObject.PressedButton), nameof(PressedButtonHook), parameterTypes);
            }
            void PatchInteract<T>() where T : PlayfieldObject
            {
                Patcher.Prefix(typeof(T), nameof(PlayfieldObject.Interact), nameof(InteractHook));
            }
            void PatchInteractFar<T>() where T : PlayfieldObject
            {
                Patcher.Prefix(typeof(T), nameof(PlayfieldObject.InteractFar), nameof(InteractFarHook));
            }
            void MakeInteractable<T>() where T : PlayfieldObject
            {
                Patcher.Postfix(typeof(T), "Awake", nameof(AwakeInteractableHook));
                Patcher.Postfix(typeof(T), nameof(PlayfieldObject.RecycleAwake), nameof(RecycleAwakeInteractableHook));
            }

            RogueInteractions.CreateProvider(h =>
            {
                if (!h.Helper.interactingFar) return;
                PlayfieldObject obj = h.Object;
                if (obj is AlarmButton or AmmoDispenser)
                {
                    if (h.Agent.oma.superSpecialAbility && h.Agent.agentName == "Hacker"
                        || h.Agent.statusEffects.hasTrait("HacksBlowUpObjects"))
                    {
                        h.AddButton("HackExplode", m => (m.Object as ObjectReal)?.HackExplode(m.Agent));
                    }
                }
            });
            RogueInteractions.CreateProvider(h =>
            {
                if (h.Object is ObjectReal objReal && objReal.CanCollectAlienPart())
                {
                    if (objReal is AmmoDispenser || objReal is ATMMachine || objReal is AugmentationBooth || objReal is CapsuleMachine
                        || objReal is CloneMachine || objReal is LoadoutMachine || objReal is PawnShopMachine)
                    {
                        h.AddButton("CollectPart", m =>
                        {
                            m.Object.StartCoroutine(m.Object.Operating(m.Agent, null, 5f, true, "Collecting"));
                            if (!m.Agent.statusEffects.hasTrait("OperateSecretly") && m.Object.functional)
                            {
                                m.gc.spawnerMain.SpawnNoise(m.Object.tr.position, 1f, m.Agent, "Normal", m.Agent);
                                m.gc.audioHandler.Play(m.Object, "Hack");
                                (m.Object as ObjectReal)?.SpawnParticleEffect("Hack", m.Object.tr.position);
                                m.gc.spawnerMain.SpawnStateIndicator(m.Object, "HighVolume");
                                m.gc.OwnCheck(m.Agent, m.Object.go, "Normal", 0);
                            }
                        });
                    }
                }
            });
            RogueInteractions.CreateProvider(h =>
            {
                h.AddButton("InteractionsPatched", m => m.StopInteraction());
            });
            RogueLibs.CreateCustomName("InteractionsPatched", NameTypes.Interface, new CustomNameInfo
            {
                English = "I am patched!",
                Russian = "Я пропатчен!",
            });

            Patch<AirConditioner>(params2);
            PatchInteract<AirConditioner>();
            RogueInteractions.CreateProvider<AirConditioner>(h =>
            {
                if (h.Helper.interactingFar) return;
                if (h.gc.gasesList.Exists(g => g.startingChunk == h.Object.startingChunk))
                {
                    h.SetStopCallback(m => m.Agent.SayDialogue("AlreadyGassing"));
                    return;
                }
                if (!h.Object.isBroken())
                {
                    if (h.Agent.inventory.InvItemList.Exists(item => h.Object.playerHasUsableItem(item)))
                        h.AddButton("InsertItem", m => m.Object.ShowUseOn("InsertItem"));
                    else h.SetStopCallback(m => m.Agent.SayDialogue("CantUseAirConditioner"));
                }
            });

            Patch<AlarmButton>(params2);
            PatchInteract<AlarmButton>();
            RogueLibs.CreateCustomName("PressAlarmButton", NameTypes.Interface, new CustomNameInfo
            {
                English = "Press",
                Russian = "Нажать",
            });
            RogueInteractions.CreateProvider<AlarmButton>(h =>
            {
                if (h.Helper.interactingFar)
                {
                    if (!h.Object.hacked)
                    {
                        h.AddButton("AllAccessAlarmButton", m =>
                        {
                            m.Object.hacked = true;
                            if (!m.gc.serverPlayer) m.gc.playerAgent.objectMult.ObjectAction(m.Object.objectNetID, "AllAccess");
                        });
                    }
                }
                else if (!h.Object.isBroken())
                {
                    h.AddImplicitButton("PressAlarmButton", m =>
                    {
                        m.Object.lastHitByAgent = m.Object.interactingAgent;
                        if (m.Agent.upperCrusty || m.Object.hacked)
                            m.Object.ToggleSwitch(m.Agent, null);
                        else m.Object.Say("CantUseAlarmButton");
                    });
                }
            });

            Patch<Altar>(params2);
            PatchInteract<Altar>();
            MakeInteractable<Altar>();
            RogueInteractions.CreateProvider<Altar>(h =>
            {
                if (h.Helper.interactingFar) return;
                h.AddButton("MakeOffering", m =>
                {
                    if (m.Object.offeringsMade >= m.Object.offeringLimit)
                    {
                        m.gc.audioHandler.Play(m.Object, "CantDo");
                        m.Object.StopInteraction();
                        return;
                    }
                    m.Agent.SayDialogue("OfferingMustBeInBuilding");
                    m.Object.commander = m.Agent;
                    m.Agent.mainGUI.invInterface.ShowTarget(m.Object, "MakeOffering");
                    m.Object.StartCoroutine("MakingOffer");
                });
            });

            Patch<AmmoDispenser>(params2);
            PatchInteract<AmmoDispenser>();
            RogueInteractions.CreateProvider<AmmoDispenser>(h =>
            {
                if (h.Helper.interactingFar)
                {
                    if (h.Object.hacked == 0)
                    {
                        h.AddButton("ReduceAmmoPrices", m =>
                        {
                            m.gc.audioHandler.Play(m.Agent, "Success");
                            m.Object.ReduceAmmoPrices(m.Agent);
                            m.StopInteraction();
                        });
                    }
                }
                else if (!h.Object.isBrokenShowButtons())
                {
                    h.SetStopCallback(m => m.Agent.SayDialogue("CantUseAmmoDispenser"));

                    if (h.Agent.inventory.InvItemList.Exists(i => i.itemType == ItemTypes.WeaponProjectile) || h.Agent.mechFilled
                        || h.Agent.bigQuest == "Alien" && h.Agent.oma.bigQuestObjectCount < 3 && !h.Agent.interactionHelper.interactingFar
                        && !h.gc.loadLevel.LevelContainsMayor())
                    {
                        h.AddButton("RefillGun", m => m.Object.ShowUseOn("RefillGun"));
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
                            h.AddButton("GiveMechOil", healCost, m =>
                            {
                                m.Object.GiveMechOil();
                                m.StopInteraction();
                            });
                        }
                    }
                }
            });








            Patch<Barbecue>(params2);
            RogueInteractions.CreateProvider<Barbecue>(h =>
            {
                if (h.Helper.interactingFar) return;
                if (h.Object.burntOut)
                {
                    h.SetStopCallback(m => m.Agent.SayDialogue("BarbecueBurntOut"));
                }
                else if (h.Object.ora.hasParticleEffect)
                {
                    if (h.Agent.inventory.HasItem(VanillaItems.Fud))
                        h.AddButton("GrillFud", m => m.Object.StartCoroutine(m.Object.Operating(m.Agent, null, 2f, true, "Grilling")));
                    else h.SetStopCallback(m => m.Agent.SayDialogue("CantGrillFud"));
                }
                else
                {
                    if (h.Agent.inventory.HasItem(VanillaItems.CigaretteLighter))
                    {
                        h.AddButton("LightBarbecue", m =>
                        {
                            m.Object.StartFireInObject();
                            m.StopInteraction();
                        });
                    }
                    else h.SetStopCallback(m => m.Agent.SayDialogue("CantOperateBarbecue"));
                }
            });










        }

        private static readonly Dictionary<Type, ConstructorInfo> interactionModelConstructors = new Dictionary<Type, ConstructorInfo>();
        public static void PlayfieldObject_Awake(PlayfieldObject __instance)
        {
            if (__instance.GetHook<InteractionModel>() is null)
            {
                Type myType = __instance.GetType();
                if (!interactionModelConstructors.TryGetValue(myType, out ConstructorInfo ctor))
                {
                    Type modelType = typeof(InteractionModel<>).MakeGenericType(__instance.GetType());
                    interactionModelConstructors.Add(myType, ctor = modelType.GetConstructor(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, CallingConventions.Any, Type.EmptyTypes, null));
                }
                if (ctor is null)
                {
                    RogueFramework.LogError($"Error patching {__instance.GetType()}. Constructor is null for some reason.");
                    return;
                }
                __instance.AddHook((InteractionModel)ctor?.Invoke(new object[0]));
            }
        }
        public static bool DetermineButtonsHook(PlayfieldObject __instance)
        {
            #region Re-implementing base.DetermineButtons()
            __instance.buttons.Clear();
            __instance.buttonPrices.Clear();
            __instance.buttonsExtra.Clear();
            #endregion

            __instance.GetHook<InteractionModel>()?.OnDetermineButtons();
            return false;
        }
        public static bool PressedButtonHook(PlayfieldObject __instance, string buttonText)
        {
            #region Re-implementing base.PressedButton()
            if (__instance.interactingAgent != null && (__instance.interactingAgent.controllerType != "Keyboard" || (__instance.interactingAgent.controllerType == "Keyboard" && __instance.gc.playerControl.keyCheck(buttonType.Interact, __instance.interactingAgent))) && __instance.interactingAgent.localPlayer)
            {
                __instance.interactingAgent.mainGUI.invInterface.justPressedInteract = true;
            }
            #endregion

            __instance.GetHook<InteractionModel>()?.OnPressedButton(buttonText);
            return false;
        }

        public static bool InteractHook(PlayfieldObject __instance, Agent agent)
        {
            #region Re-implementing base.Interact(agent)
            // PlayfieldObject.Interact
            __instance.interactingAgent = agent;
            __instance.hasInteracted = true;
            __instance.someoneInteracting = true;
            __instance.DetermineButtons();

            if (__instance.playfieldObjectReal != null)
                __instance.gc.playerAgent.SetCheckUseWithItemsAgain(__instance.playfieldObjectReal);

            float size = !__instance.gc.serverPlayer && __instance.playfieldObjectType == "Agent" ? 1.7f : 1.3f;
            agent.interactionHelper.boxCollider2D.size = new Vector2(size, size);
            agent.interactionHelper.interactingLimbo = 0f;

            if (!__instance.gc.serverPlayer && __instance.gc.clientControlling)
                agent.interactionHelper.clientInteracting = true;
            if (agent.localPlayer && !__instance.isItem && (agent.statusEffects.hasTrait("RollerSkates") || agent.statusEffects.hasTrait("RollerSkates2")))
            {
                agent.rb.velocity = Vector2.zero;
            }
            if (__instance.playfieldObjectAgent != null && __instance.gc.serverPlayer && (__instance.playfieldObjectAgent.movement.curPhysicsType == "Ice" || __instance.playfieldObjectAgent.statusEffects.hasTrait("RollerSkates") || __instance.playfieldObjectAgent.statusEffects.hasTrait("RollerSkates2")))
            {
                __instance.playfieldObjectAgent.rb.velocity = Vector2.zero;
            }
            // ObjectReal.Interact
            __instance.playerInvDatabase = agent.GetComponent<InvDatabase>();
            #endregion

            __instance.ShowObjectButtons();
            return false;
        }
        // unnecessary?
        public static bool InteractFarHook(PlayfieldObject __instance, Agent agent)
        {
            // TODO
            #region Re-implementing base.InteractFar(agent)
            #endregion
            return false;
        }
        public static void AwakeInteractableHook(PlayfieldObject __instance)
        {
            __instance.interactable = true;
        }
        public static void RecycleAwakeInteractableHook(PlayfieldObject __instance)
        {
            __instance.interactable = true;
        }

    }
}
