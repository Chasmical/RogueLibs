using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;

namespace RogueLibsCore.Test
{
    public class TestPlugin : BaseUnityPlugin
    {
        public const string pluginGUID = "abbysssal.streetsofrogue.roguelibscore.test";
        public const string pluginName = "RogueLibsCore Test";
        public const string pluginVesion = RogueLibs.CompiledVersion;

        public void Awake()
		{
            LootBox.Test();
            Recycler.Test();
            Duplicator.Test();
		}
    }
}
