using System;
using System.Collections;
using System.Reflection;
using HarmonyLib;
using UnityEngine;
using UnityEngine.Networking;

namespace RogueLibsCore
{
    public sealed partial class RogueLibsPlugin
    {
        public void PatchAgentInteractions()
        {
            Patcher.Prefix(typeof(Agent), nameof(Agent.Interact), nameof(AgentInteractHook));
            Patcher.Prefix(typeof(AgentInteractions), nameof(AgentInteractions.AddButton),
                           new Type[3] { typeof(string), typeof(int), typeof(string) });

            // the patches below are all side effects of AgentInteractions.DetermineButtons
#pragma warning disable CS0618
            Patcher.Prefix(typeof(Agent), nameof(Agent.SayDialogue),
                           new Type[4] { typeof(bool), typeof(string), typeof(bool), typeof(NetworkInstanceId) });
            Patcher.Prefix(typeof(AudioHandler), nameof(AudioHandler.Play),
                           new Type[4] { typeof(PlayfieldObject), typeof(string), typeof(NetworkInstanceId), typeof(bool) });
            Patcher.Prefix(typeof(Agent), nameof(Agent.Say), new Type[2] { typeof(string), typeof(bool) });
            Patcher.Prefix(typeof(Cinematics), nameof(Cinematics.DoctorAfterTutorial), new Type[1] { typeof(Agent) });
            Patcher.Prefix(typeof(StatusEffects), nameof(StatusEffects.PressedSpecialAbility),
                nameof(StatusEffects_PressedSpecialAbility_Prefix));
            Patcher.Prefix(typeof(PlayfieldObject), nameof(PlayfieldObject.Operating));
            Patcher.Prefix(typeof(Unlocks), nameof(Unlocks.DoUnlock));
            Patcher.Prefix(typeof(PlayfieldObject), nameof(PlayfieldObject.ShowObjectButtons));
            Patcher.Prefix(typeof(Relationships), nameof(Relationships.ProtectOwned));
            Patcher.Prefix(typeof(Relationships), nameof(Relationships.ProtectOwnedLight));
            Patcher.Prefix(typeof(Movement), nameof(Movement.RotateToObject), new Type[1] { typeof(Transform) });
            Patcher.Prefix(typeof(AgentInteractions), nameof(AgentInteractions.BouncerTurnOffLaserEmitter));

            MethodInfo sleepingSetter = AccessTools.PropertySetter(typeof(Agent), nameof(Agent.sleeping));
            Harmony harmony = Patcher.GetHarmony();
            harmony.Patch(sleepingSetter, new HarmonyMethod(AccessTools.Method(typeof(RogueLibsPlugin), nameof(Agent_set_sleeping))));
#pragma warning restore CS0618

        }

        public static bool AgentInteractHook(PlayfieldObject __instance, Agent otherAgent) => InteractHook(__instance, otherAgent);
        public static bool AgentInteractions_AddButton(string buttonName, int moneyCost, string extraCost)
        {
            if (VanillaInteractions.Queuing)
            {
                VanillaInteractions.PrepareButton(buttonName, moneyCost, extraCost);
                return false;
            }
            return true;
        }

        private static bool QueuePrefix(string id, Action<InteractionModel<Agent>> action)
        {
            if (VanillaInteractions.Queuing)
            {
                VanillaInteractions.QueueAction(id, action);
                return false;
            }
            return true;
        }

        // ReSharper disable InconsistentNaming
        // ReSharper disable IdentifierTypo
        // ReSharper disable StringLiteralTypo
#pragma warning disable CS0618

        public static bool Agent_SayDialogue(Agent __instance, bool playerSayToAll, string type, bool importantText,
                                             NetworkInstanceId myNetID, ref string __result)
        {
            if (!VanillaInteractions.Queuing) return true;
            VanillaInteractions.QueueAction("Agent.SayDialogue", _ => __instance.SayDialogue(playerSayToAll, type, importantText, myNetID));
            __result = string.Empty;
            return false;
        }

        public static bool AudioHandler_Play(AudioHandler __instance, PlayfieldObject playfieldObject, string clipName,
                                             NetworkInstanceId cameFromClient, bool dontPlayOnClients)
            => QueuePrefix("AudioHandler.PlaySound", _ => __instance.Play(playfieldObject, clipName, cameFromClient, dontPlayOnClients));
        public static bool Agent_Say(Agent __instance, string myMessage, bool importantText)
            => QueuePrefix("Agent.Say", _ => __instance.Say(myMessage, importantText));
        public static bool Cinematics_DoctorAfterTutorial(Cinematics __instance, Agent myAgent)
            => QueuePrefix("Cinematics.DoctorAfterTutorial", _ => __instance.DoctorAfterTutorial(myAgent));
        public static bool StatusEffects_PressedSpecialAbility_Prefix(StatusEffects __instance)
            => QueuePrefix("StatusEffects.PressedSpecialAbility", _ => __instance.PressedSpecialAbility());
        public static bool PlayfieldObject_Operating(PlayfieldObject __instance, Agent myAgent, InvItem item, float timeToUnlock,
                                                     bool makeNoise, string barType, ref IEnumerator __result)
        {
            if (!VanillaInteractions.Queuing) return true;
            static IEnumerator EmptyEnumerator() { yield break; }
            __result = EmptyEnumerator();
            VanillaInteractions.QueueAction("PlayfieldObject.Operating", _ =>
            {
                IEnumerator enumerator = __instance.Operating(myAgent, item, timeToUnlock, makeNoise, barType);
                __instance.StartCoroutine(enumerator);
            });
            return false;
        }
        public static bool Unlocks_DoUnlock(Unlocks __instance, string unlockName, string unlockType)
            => QueuePrefix("Unlocks.DoUnlock", _ => __instance.DoUnlock(unlockName, unlockType));
        public static bool PlayfieldObject_ShowObjectButtons() => !VanillaInteractions.Queuing; // when queuing actions, stop the call
        public static bool Relationships_ProtectOwned(Relationships __instance, Agent otherAgent, Relationship myRelationship)
            => QueuePrefix("Relationships.ProtectOwned", _ => __instance.ProtectOwned(otherAgent, myRelationship));
        public static bool Relationships_ProtectOwnedLight(Relationships __instance, Agent otherAgent, Relationship myRelationship)
            => QueuePrefix("Relationships.ProtectOwnedLight", _ => __instance.ProtectOwnedLight(otherAgent, myRelationship));
        public static bool Movement_RotateToObject(Movement __instance, Transform otherObjectTr)
            => QueuePrefix("Movement.RotateToObject", _ => __instance.RotateToObject(otherObjectTr));
        public static bool AgentInteractions_BouncerTurnOffLaserEmitter(AgentInteractions __instance, Agent agent, Agent interactingAgent, bool becomeLoyal)
            => QueuePrefix("AgentInteractions.BouncerTurnOffLaserEmitter", _ => __instance.BouncerTurnOffLaserEmitter(agent, interactingAgent, becomeLoyal));

        public static bool Agent_set_sleeping(Agent __instance, bool value)
            => QueuePrefix("Agent.sleeping", _ => __instance.sleeping = value);



    }
}
