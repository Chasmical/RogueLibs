using System;

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
            Patcher.Postfix(typeof(Agent), nameof(Agent.SetupAgentStats));



            Patcher.AnyErrors();
        }

        public static void Gun_spawnBullet(Gun __instance, Bullet __result)
        {
            LastFiredBulletHook hook = __instance.agent.GetHook<LastFiredBulletHook>() ?? __instance.agent.AddHook<LastFiredBulletHook>();
            hook.LastFiredBullet = __result;
        }
        public static void Agent_SetupAgentStats(InvItem __instance)
        {
            HookSystem.DestroyHookController(__instance);

            IHookController controller = __instance.GetHookController();
            foreach (IHookFactory factory in RogueFramework.AgentFactories)
            {
                IHook? hook = factory.TryCreateHook(__instance);
                if (hook is not null) controller.AddHook(hook);
            }
        }
    }
}
