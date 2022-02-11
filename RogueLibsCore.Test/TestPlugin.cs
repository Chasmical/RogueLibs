using BepInEx;
using BepInEx.Logging;

namespace RogueLibsCore.Test
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(RogueLibs.GUID, RogueLibs.CompiledVersion)]
    public class TestPlugin : BaseUnityPlugin
    {
        public const string PluginGUID = "abbysssal.streetsofrogue.roguelibscore.test";
        public const string PluginName = "RogueLibsCore Test";
        public const string PluginVersion = RogueLibs.CompiledVersion;

        public static ManualLogSource Log { get; private set; } = null!;
        public static TestPlugin Instance { get; private set; } = null!;

        public void Awake()
        {
            Log = Logger;
            Instance = this;

            RogueLibs.LoadFromAssembly();
        }
    }
}
