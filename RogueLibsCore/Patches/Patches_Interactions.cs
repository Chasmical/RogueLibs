using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            Patch<Barbecue>(params2);

            RogueInteractions.Factories.Add(new VanillaInteractionFactory()
                                                .With<Interaction_Barbecue>());




        }

        public static void PlayfieldObject_Awake(PlayfieldObject __instance)
        {
            if (__instance.GetHook<InteractionModel>() is null)
                __instance.AddHook<InteractionModel>();
        }
        public static bool DetermineButtonsHook(PlayfieldObject __instance)
        {
            __instance.buttons.Clear();
            __instance.buttonPrices.Clear();
            __instance.buttonsExtra.Clear();

            __instance.GetHook<InteractionModel>()?.OnDetermineButtons();
            return false;
        }
        public static bool PressedButtonHook(PlayfieldObject __instance, string buttonText)
        {
            if (__instance.interactingAgent != null && (__instance.interactingAgent.controllerType != "Keyboard" || (__instance.interactingAgent.controllerType == "Keyboard" && __instance.gc.playerControl.keyCheck(buttonType.Interact, __instance.interactingAgent))) && __instance.interactingAgent.localPlayer)
            {
                __instance.interactingAgent.mainGUI.invInterface.justPressedInteract = true;
            }

            __instance.GetHook<InteractionModel>()?.OnPressedButton(buttonText);
            return false;
        }

    }
    internal class Interaction_Barbecue : VanillaInteraction<Barbecue>
    {
        public override bool SetupButton()
        {
            if (Object.burntOut)
                return CancelSelf(() => Agent.SayDialogue("BarbecueBurntOut"));

            if (Object.ora.hasParticleEffect)
            {
                RogueFramework.Logger.LogWarning($"Current interacting agent is {Agent} ({Agent.agentName}. {Agent.isPlayer})");
                RogueFramework.Logger.LogWarning($"Has Fud: {Agent.inventory.HasItem("Fud")}");
                if (Agent.inventory.HasItem("Fud"))
                    return SetButton("GrillFud");
                return CancelSelf(() => Agent.SayDialogue("CantGrillFud"));
            }
            else
            {
                if (Agent.inventory.HasItem("CigaretteLighter"))
                    return SetButton("LightBarbecue");
                return CancelSelf(() => Agent.SayDialogue("CantOperateBarbecue"));
            }
        }
        public override void OnPressed()
        {
            if (ButtonName == "LightBarbecue")
            {
                Object.StartFireInObject();
                StopInteraction();
            }
			else if (ButtonName == "GrillFud")
            {
                Object.StartCoroutine(Object.Operating(Agent, null, 2f, true, "Grilling"));
            }
        }
    }
}
