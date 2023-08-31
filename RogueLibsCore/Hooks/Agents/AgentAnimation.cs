using System;
using UnityEngine;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>The base agent head two-frame animation hook. Need agent's name <see cref="RogueSprite"/>'s with two animation frames (0 and 1).</para>
    /// </summary>
    public class AgentAnimatedHead_Hook : HookBase<PlayfieldObject>, IDoUpdate
    {
        protected override void Initialize() { }
        public void Update()
        {
            Agent agent = (Agent)Instance;
            int animIndex = (int)Math.Floor(Time.time * 8f % 2f);
            string direction = agent.playerDir;
            if (string.IsNullOrEmpty(direction)) direction = "S";
            string headSpriteName = $"{agent.agentName}{animIndex + 1}{direction}";
            agent.agentHitboxScript.hair.SetSprite(headSpriteName);
        }
    }
    /// <summary>
    ///   <para>The base agent body two-frame animation hook. Need agent's name <see cref="RogueSprite"/>'s with two animation frames (0 and 1).</para>
    /// </summary>
    public class AgentAnimatedBody_Hook : HookBase<PlayfieldObject>, IDoUpdate
    {
        protected override void Initialize() { }
        public void Update()
        {
            Agent agent = (Agent)Instance;
            int animIndex = (int)Math.Floor(Time.time * 8f % 2f);
            string direction = agent.playerDir;
            if (string.IsNullOrEmpty(direction)) direction = "S";
            string headSpriteName = $"{agent.agentName}{animIndex + 1}{direction}";
            agent.agentHitboxScript.hair.SetSprite(headSpriteName);
        }
    }
}