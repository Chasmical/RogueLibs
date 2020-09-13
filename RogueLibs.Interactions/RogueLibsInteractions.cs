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

        public static List<ObjectInteraction> ObjectInteractions { get; } = new List<ObjectInteraction>();
        
        public static ObjectInteraction GetObjectInteraction(string id) => ObjectInteractions.Find(i => i.Id == id);
        public static ObjectInteraction CreateObjectInteraction(string id, InteractionType type, CustomNameInfo? buttonName, Func<Agent, PlayfieldObject, bool> condition)
            => CreateObjectInteractionInternal(id, type, buttonName, condition, false);
        internal static ObjectInteraction CreateOriginalInteraction(string id, InteractionType type, Func<Agent, PlayfieldObject, bool> condition)
            => CreateObjectInteraction(id, type, null, condition);
        internal static ObjectInteraction CreateObjectInteractionInternal(string id, InteractionType type, CustomNameInfo? buttonName, Func<Agent, PlayfieldObject, bool> condition, bool orig)
		{
            ObjectInteraction objectInteraction = GetObjectInteraction(id);
            if (objectInteraction != null)
            {
                string message = string.Concat("An ObjectInteraction with Id \"", id, "\" already exists!");
                Logger.LogError(message);
                throw new ArgumentException(message, nameof(id));
            }
            ObjectInteractions.Add(objectInteraction = new ObjectInteraction(id, type,
                buttonName.HasValue && !orig ? RogueLibs.CreateCustomName(id, "Interface", buttonName.Value) : null, orig));
            objectInteraction.Condition = condition;

            Logger.LogDebug(string.Concat("An ObjectInteraction with Id \"", id, "\" (", type.ToString(), ") was created."));

            return objectInteraction;
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
