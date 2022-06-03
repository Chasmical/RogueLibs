﻿using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace RogueLibsCore
{
    public sealed partial class RogueLibsPlugin
    {
        public void PatchInteractions()
        {
            Patcher.Postfix(typeof(PlayfieldObject), "Awake");

            Patcher.Prefix(typeof(ObjectReal), nameof(ObjectReal.DetermineButtons), nameof(DetermineButtonsHook));
            Patcher.Prefix(typeof(ObjectReal), nameof(ObjectReal.PressedButton), nameof(PressedButtonHook),
                           new Type[2] { typeof(string), typeof(int) });
            Patcher.Prefix(typeof(ObjectReal), nameof(ObjectReal.Interact), nameof(InteractHook));
            Patcher.Prefix(typeof(ObjectReal), nameof(ObjectReal.InteractFar), nameof(InteractFarHook));

            Patcher.Prefix(typeof(PlayfieldObject), nameof(PlayfieldObject.StopInteraction), new Type[1] { typeof(bool) });

            VanillaInteractions.PatchAll();

            Patcher.AnyErrors();
        }

        private static InteractionModel GetOrCreateModel(PlayfieldObject __instance)
        {
            InteractionModel? model = __instance.GetHook<InteractionModel>();
            if (model is null)
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
                    return null!;
                }
                __instance.AddHook(model = (InteractionModel)ctor.Invoke(new object[0]));
            }
            return model;
        }

        private static readonly Dictionary<Type, ConstructorInfo> interactionModelConstructors = new Dictionary<Type, ConstructorInfo>();
        public static void PlayfieldObject_Awake(PlayfieldObject __instance)
        {
            GetOrCreateModel(__instance);
        }
        public static bool DetermineButtonsHook(PlayfieldObject __instance)
        {
            #region Re-implementing base.DetermineButtons()
            __instance.buttons.Clear();
            __instance.buttonPrices.Clear();
            __instance.buttonsExtra.Clear();
            #endregion

            GetOrCreateModel(__instance).OnDetermineButtons();
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

            GetOrCreateModel(__instance).OnPressedButton(buttonText);
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
            // agent.worldSpaceGUI.ShowObjectNameDisplay();
            if (__instance.playfieldObjectType == "ObjectReal")
                agent.worldSpaceGUI.objectNameDisplayText.text = __instance.GetComponent<ObjectReal>().objectRealRealName;
            else if (__instance.playfieldObjectType == "Agent")
                agent.worldSpaceGUI.objectNameDisplayText.text = __instance.GetComponent<Agent>().agentRealName;
            agent.interactionHelper.interactingLimbo = 0f;
            // ObjectReal.InteractFar
            __instance.playerInvDatabase = agent.GetComponent<InvDatabase>();
            #endregion

            RecentTargetItemHook? hook = agent.GetHook<RecentTargetItemHook>();
            if (hook?.Item?.Categories.Contains("Internal:HackInteract") is true)
            {
                if ((__instance.functional || __instance is SecurityCam or Turret)
                    && !__instance.tempNoOperating && __instance is ObjectReal real)
                    real.HackObject(agent);
            }
            else if (__instance.buttons.Count > 0)
                __instance.ShowObjectButtons();
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

        public static bool PlayfieldObject_StopInteraction(PlayfieldObject __instance)
        {
            GetOrCreateModel(__instance).shouldStop = true;
            return false;
        }


    }
}
