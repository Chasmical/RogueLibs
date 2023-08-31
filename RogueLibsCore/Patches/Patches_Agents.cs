using System;
using System.Net;

namespace RogueLibsCore
{
    internal sealed partial class RogueLibsPlugin
    {
        public void PatchAgents()
        {
            // GetLastFiredBullet() extension
            Patcher.Postfix(typeof(Gun), nameof(Gun.spawnBullet),
                new Type[5] { typeof(bulletStatus), typeof(InvItem), typeof(int), typeof(bool), typeof(string) });

            // Create and initialize agent hooks
            //Patcher.Postfix(typeof(Agent), nameof(Agent.SetupAgentStats));





            Patcher.AnyErrors();
        }

        public static void Gun_spawnBullet(Gun __instance, Bullet __result)
        {
            LastFiredBulletHook hook = __instance.agent.GetHook<LastFiredBulletHook>() ?? __instance.agent.AddHook<LastFiredBulletHook>();
            hook.LastFiredBullet = __result;
        }
        /*public static void Agent_SetupAgentStats(Agent __instance)
        {
            (__instance.__RogueLibsHooks as IDisposable)?.Dispose();
            __instance.__RogueLibsHooks = null;

            bool debug = RogueFramework.IsDebugEnabled(DebugFlags.Agents);
            foreach (IHookFactory<Agent> factory in RogueFramework.AgentFactories)
                if (factory.TryCreate(__instance, out IHook<Agent>? hook))
                {
                    if (debug)
                    {
                        RogueFramework.LogDebug(hook is CustomAgent
                                                    ? $"Initializing custom agent {hook} ({__instance.agentName})."
                                                    : $"Initializing agent hook {hook} for \"{__instance.agentName}\".");
                    }
                    __instance.AddHook(hook);
                }
        }*/
    }
}
