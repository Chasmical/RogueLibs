using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;

namespace RogueLibsPatcher
{
    public static class RogueLibsPatcher
    {
        // ReSharper disable once InconsistentNaming
        public static IEnumerable<string> TargetDLLs { get; } = new string[1] { "Assembly-CSharp.dll" };

        private static ModuleDefinition? module;
        private static TypeReference? objRef;

        public static void Patch(AssemblyDefinition assembly)
        {
            module = assembly.MainModule;

            if (!module.TryGetTypeReference(typeof(object).FullName, out objRef))
                objRef = module.ImportReference(typeof(object));

            TypeDefinition invItem = module.GetType("InvItem");
            PatchHooks(invItem);

            TypeDefinition playfieldObject = module.GetType("PlayfieldObject");
            PatchHooks(playfieldObject);

            TypeDefinition statusEffect = module.GetType("StatusEffect");
            PatchHooks(statusEffect);
            PatchContainer(statusEffect);

            TypeDefinition trait = module.GetType("Trait");
            PatchHooks(trait);
            PatchContainer(trait);

            TypeDefinition buttonData = module.GetType("ButtonData");
            PatchCustom(buttonData);

            TypeDefinition unlock = module.GetType("Unlock");
            PatchCustom(unlock);

            TypeDefinition tk2dDef = module.GetType("tk2dSpriteDefinition");
            PatchCustom(tk2dDef);
        }

        public static void PatchHooks(TypeDefinition type) => Patch(type, "__RogueLibsHooks");
        public static void PatchContainer(TypeDefinition type) => Patch(type, "__RogueLibsContainer");
        public static void PatchCustom(TypeDefinition type) => Patch(type, "__RogueLibsCustom");
        public static void Patch(TypeDefinition type, string fieldName)
        {
            for (int i = 0, count = type.Fields.Count; i < count; i++)
				if (type.Fields[i].Name == fieldName)
					return;
			FieldDefinition container = new FieldDefinition(fieldName,
                                                            FieldAttributes.Public | FieldAttributes.NotSerialized, objRef);
            type.Fields.Add(container);
        }
    }
}
