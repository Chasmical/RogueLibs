using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Mono.Cecil;

namespace RogueLibsPatcher
{
    // ReSharper disable once InconsistentNaming
    public static class RogueLibsPatcher_Gen2
    {
        public static IEnumerable<string> TargetDLLs { get; } = new string[1] { "Assembly-CSharp.dll" };

        private static ModuleDefinition module = null!;
        private static TypeReference objRef = null!;

        private static int flow;
        [DoesNotReturn]
        private static void Error(int num, string? extra = null)
            => throw new InvalidOperationException($"ERROR CODE {num}:{extra}. Consult RogueLibs' developers about this.");
        public static void Patch(AssemblyDefinition assembly)
        {
            try
            {
                flow = 0;
                Patch2(assembly);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Error(-flow);
            }
        }
        public static void Patch2(AssemblyDefinition assembly)
        {
            if (assembly is null) Error(1);
            flow++; // flow = 1
            module = assembly.MainModule;
            if (module is null) Error(2);

            flow++; // flow = 2
            if (!module.TryGetTypeReference(typeof(object).FullName, out objRef))
                objRef = module.ImportReference(typeof(object));
            if (objRef is null) Error(3);

            const string rlHooks = "__RogueLibsHooks";
            const string rlContainer = "__RogueLibsContainer";
            const string rlCustom = "__RogueLibsCustom";

            // flow = 3 and onward
            PatchField(nameof(InvItem), rlHooks);

            PatchField(nameof(PlayfieldObject), rlHooks);

            PatchField(nameof(StatusEffect), rlHooks);
            PatchField(nameof(StatusEffect), rlContainer);

            PatchField(nameof(Trait), rlHooks);
            PatchField(nameof(Trait), rlContainer);

            PatchField(nameof(Unlock), rlCustom);

            PatchField(nameof(ButtonData), rlCustom);

            PatchField(nameof(tk2dSpriteDefinition), rlCustom);

            // 2nd generation of patches

            PatchField(nameof(MainGUI), rlHooks);
            PatchField(nameof(WorldSpaceGUI), rlHooks);
        }

        public static void PatchField(string typeName, string fieldName)
        {
            flow++;
            TypeDefinition type = module.GetType(typeName);
            if (type is null) Error(4, typeName);

            if (type.Fields is null) Error(5, typeName);
            // Note: Do not use LINQ here. Apparently, some versions of Mono may be missing System.Func and System.Action.
            // (see https://github.com/SugarBarrel/ECTD/issues/4)
            for (int i = 0, count = type.Fields.Count; i < count; i++)
                if (type.Fields[i].Name == fieldName)
                    return;

            const FieldAttributes attr = FieldAttributes.Public | FieldAttributes.NotSerialized;
            type.Fields.Add(new FieldDefinition(fieldName, attr, objRef));
        }

    }
}
namespace System.Diagnostics.CodeAnalysis
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class DoesNotReturnAttribute : Attribute { }
}
