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
            VanillaInteractions.PatchAll();

            RogueInteractions.CreateProvider(static h =>
            {
                if (!h.Helper.interactingFar) return;
                PlayfieldObject obj = h.Object;
                if (obj is AlarmButton or AmmoDispenser or ArcadeGame or ATMMachine)
                {
                    if (h.Agent.oma.superSpecialAbility && h.Agent.agentName == "Hacker"
                        || h.Agent.statusEffects.hasTrait("HacksBlowUpObjects"))
                    {
                        h.AddButton("HackExplode", static m => (m.Object as ObjectReal)?.HackExplode(m.Agent));
                    }
                }
            });
            RogueInteractions.CreateProvider(static h =>
            {
                if (h.Object is ObjectReal objReal && objReal.CanCollectAlienPart())
                {
                    if (objReal is AmmoDispenser or ATMMachine or AugmentationBooth
                        or CapsuleMachine or CloneMachine or LoadoutMachine or PawnShopMachine)
                    {
                        h.AddButton("CollectPart", static m =>
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

            Patcher.AnyErrors();
        }

        private static readonly Dictionary<Type, ConstructorInfo> interactionModelConstructors = new Dictionary<Type, ConstructorInfo>();
        public static void PlayfieldObject_Awake(PlayfieldObject __instance)
        {
            if (__instance.GetHook<InteractionModel>() is null)
            {
                Type myType = __instance.GetType();
                if (!interactionModelConstructors.TryGetValue(myType, out ConstructorInfo? ctor))
                {
                    Type modelType = typeof(InteractionModel<>).MakeGenericType(__instance.GetType());
                    interactionModelConstructors.Add(myType, ctor = modelType.GetConstructor(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, CallingConventions.Any, Type.EmptyTypes, null));
                }
                if (ctor is null)
                {
                    RogueFramework.LogError($"Error patching {__instance.GetType()}. Constructor is null for some reason.");
                    return;
                }
                __instance.AddHook((InteractionModel)ctor.Invoke(new object[0]));
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
            if (__instance.interactingAgent != null && (__instance.interactingAgent.controllerType != "Keyboard" || __instance.interactingAgent.controllerType == "Keyboard" && __instance.gc.playerControl.keyCheck(buttonType.Interact, __instance.interactingAgent)) && __instance.interactingAgent.localPlayer)
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

            if (__instance.buttons.Count > 0)
                __instance.ShowObjectButtons();
            return false;
        }
        // unnecessary?
        public static bool InteractFarHook(PlayfieldObject __instance, Agent agent)
        {
            #region Re-implementing base.InteractFar(agent)
            // PlayfieldObject.InteractFar
            __instance.interactingAgent = agent;
            if (__instance.gc.multiplayerMode && !__instance.gc.serverPlayer)
            {
                agent.interactionHelper.clientInteracting = true;
                Debug.Log("CmdInteractFar");
                agent.objectMult.CallCmdInteractFar(__instance.objectNetID);
            }
            __instance.someoneInteracting = true;
            agent.interactionHelper.interactingFar = true;
            __instance.DetermineButtons();
            if (__instance.playfieldObjectReal != null)
                __instance.gc.playerAgent.SetCheckUseWithItemsAgain(__instance.playfieldObjectReal);
            agent.interactionHelper.interactionObject = __instance.objectSprite.go;
            agent.worldSpaceGUI.ShowObjectNameDisplay();
            if (__instance.playfieldObjectType == "ObjectReal")
                agent.worldSpaceGUI.objectNameDisplayText.text = __instance.GetComponent<ObjectReal>().objectRealRealName;
            else if (__instance.playfieldObjectType == "Agent")
                agent.worldSpaceGUI.objectNameDisplayText.text = __instance.GetComponent<Agent>().agentRealName;
            agent.interactionHelper.interactingLimbo = 0f;
            // ObjectReal.InteractFar
            __instance.playerInvDatabase = agent.GetComponent<InvDatabase>();
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
