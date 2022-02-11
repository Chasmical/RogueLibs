using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Logging;

namespace RogueLibsCore.Test
{
    [BepInPlugin(pluginGUID, pluginName, pluginVesion)]
    [BepInDependency(RogueLibs.GUID, RogueLibs.CompiledVersion)]
    public class TestPlugin : BaseUnityPlugin
    {
        public const string pluginGUID = "abbysssal.streetsofrogue.roguelibscore.test";
        public const string pluginName = "RogueLibsCore Test";
        public const string pluginVesion = RogueLibs.CompiledVersion;

        public static ManualLogSource Log { get; private set; }
        public static TestPlugin Instance { get; private set; }

        public void Awake()
        {
            Log = Logger;
            Instance = this;

            RogueLibs.LoadFromAssembly();
        }
    }
}
