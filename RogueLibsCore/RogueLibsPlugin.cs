using System.Diagnostics;
using System.Threading;
using BepInEx;

namespace RogueLibsCore
{
    [BepInPlugin(RogueLibs.GUID, RogueLibs.Name, RogueLibs.CompiledVersion)]
    public sealed partial class RogueLibsPlugin : BaseUnityPlugin
    {
        private static int awoken;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051", Justification = "That's a Unity method")]
        private void Awake()
        {
            if (Interlocked.Exchange(ref awoken, 1) == 1)
            {
                Logger.LogError("RogueLibs multi-instancing is not supported!");
                return;
            }

            // TODO: check if RogueLibsPatcher is installed

            Logger.LogInfo($"Running RogueLibs v{RogueLibs.CompiledSemanticVersion}.");
            Stopwatch sw = new Stopwatch();
            sw.Start();

            RogueFramework.Plugin = this;
            RogueFramework.Logger = Logger;

            // TODO: apply patches

            sw.Stop();
            Logger.LogDebug($"RogueLibs took {sw.ElapsedMilliseconds,5:#####} ms to initialize.");
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051", Justification = "That's a Unity method")]
        private void OnDestroy()
        {
            awoken = 0;
        }

    }
}
