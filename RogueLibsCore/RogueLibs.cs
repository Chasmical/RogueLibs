using System.Runtime.CompilerServices;

namespace RogueLibsCore
{
    public static partial class RogueLibs
    {
        public const string GUID = "abbysssal.streetsofrogue.roguelibscore";
        public const string Name = "RogueLibsCore";

        public const string CompiledVersion = "4.0.0";
        public const string CompiledSemanticVersion = "4.0.0-alpha.1";

        public static string Version { [MethodImpl(MethodImplOptions.NoInlining)] get => CompiledVersion; }
        public static string SemanticVersion { [MethodImpl(MethodImplOptions.NoInlining)] get => CompiledSemanticVersion; }


    }
}
