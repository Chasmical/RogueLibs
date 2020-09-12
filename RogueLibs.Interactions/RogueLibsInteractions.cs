using System;
using System.Collections.Generic;
using BepInEx;
using BepInEx.Logging;
using UnityEngine;

namespace RogueLibsCore.Interactions
{
    public static class RogueLibsInteractions
    {
        public const string pluginGuid = "abbysssal.streetsofrogue.roguelibs.interactions";
        public const string pluginName = "RogueLibs Interactions";
        public const string pluginVersion = "2.1.1";

        public static RogueLibsInteractionsPlugin PluginInstance;
        internal static ManualLogSource Logger;

        public static List<CustomInteraction> CustomInteractions { get; } = new List<CustomInteraction>();

        public static CustomInteraction GetCustomInteraction(string id) => CustomInteractions.Find(i => i.Id == id);
        public static CustomInteraction CreateCustomInteraction(string id, InteractionType type, CustomNameInfo? buttonName, Func<Agent, PlayfieldObject, bool> condition)
		{
            CustomInteraction customInteraction = GetCustomInteraction(id);
            if (customInteraction != null)
            {
                string message = string.Concat("A CustomInteraction with Id \"", id, "\" already exists!");
                Logger.LogError(message);
                throw new ArgumentException(message, nameof(id));
            }
            CustomInteractions.Add(customInteraction = new CustomInteraction(id, type,
                buttonName.HasValue ? RogueLibs.CreateCustomName(id, "Interface", buttonName.Value) : null));
            customInteraction.Condition = condition;

            Logger.LogDebug(string.Concat("A CustomInteraction with Id \"", id, "\" (", type.ToString(), ") was created."));

            return customInteraction;
		}




    }
    [Flags] public enum InteractionType
    {
        // Interact only
        Interact = 0b_01,
        // Button only
        Button = 0b_10,
        // Button if Interact is not possible; otherwise, Interact
        InteractOrButton = 0b_11
	}
}
