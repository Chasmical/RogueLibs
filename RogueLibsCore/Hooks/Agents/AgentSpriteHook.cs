using UnityEngine;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>The base agent head hook. Need agent's name <see cref="RogueSprite"/>'s.</para>
    /// </summary>
    public class AgentHeadSprite_Hook : HookBase<PlayfieldObject>, IDoUpdate
    {
        protected override void Initialize() { }
        public void Update()
        {
            Agent agent = (Agent)Instance;
            string direction = agent.playerDir;
            if (string.IsNullOrEmpty(direction))
                direction = "S";
            string headSpriteName = $"{agent.agentName}Head{direction}";
            agent.agentHitboxScript.head.SetSprite(headSpriteName);

            agent.agentHitboxScript.head.color = new Color32(255, 255, 255, 255);

            agent.agentHitboxScript.headH.SetSprite("Clear");
            agent.agentHitboxScript.headWBH.SetSprite("Clear");
        }
    }
    /// <summary>
    ///   <para>The agent hair hook, remove hair and facial hair.</para>
    /// </summary>
    public class AgentHairSprite_Hook : HookBase<PlayfieldObject>, IDoUpdate
    {
        protected override void Initialize() { }
        public void Update()
        {
            Agent agent = (Agent)Instance;

            agent.agentHitboxScript.canHaveFacialHair = false;
            agent.agentHitboxScript.hairClear = true;

            agent.agentHitboxScript.hair.SetSprite("Clear");
            agent.agentHitboxScript.hairH.SetSprite("Clear");
            agent.agentHitboxScript.hairWB.SetSprite("Clear");
            agent.agentHitboxScript.hairWBH.SetSprite("Clear");

            agent.agentHitboxScript.facialHair.SetSprite("Clear");
            agent.agentHitboxScript.facialHairH.SetSprite("Clear");
            agent.agentHitboxScript.facialHairWB.SetSprite("Clear");
            agent.agentHitboxScript.facialHairWBH.SetSprite("Clear");
        }
    }
    /// <summary>
    ///   <para>The agent arms and legs hook, remove H, WBH for arms and legs.</para>
    /// </summary>
    public class AgentWBHSprite_Hook : HookBase<PlayfieldObject>, IDoUpdate
    {
        protected override void Initialize() { }
        public void Update()
        {
            Agent agent = (Agent)Instance;

            agent.agentHitboxScript.arm1H.SetSprite("Clear");
            agent.agentHitboxScript.arm1WBH.SetSprite("Clear");

            agent.agentHitboxScript.arm2H.SetSprite("Clear");
            agent.agentHitboxScript.arm2WBH.SetSprite("Clear");

            agent.agentHitboxScript.leg1H.SetSprite("Clear");
            agent.agentHitboxScript.leg1WBH.SetSprite("Clear");

            agent.agentHitboxScript.leg2H.SetSprite("Clear");
            agent.agentHitboxScript.leg2WBH.SetSprite("Clear");
        }
    }
    /// <summary>
    ///   <para>The agent eyes hook, remove eyes.</para>
    /// </summary>
    public class AgentEyesSprite_Hook : HookBase<PlayfieldObject>, IDoUpdate
    {
        protected override void Initialize() { }
        public void Update()
        {
            Agent agent = (Agent)Instance;

            agent.agentHitboxScript.eyes.SetSprite("Clear");
            agent.agentHitboxScript.eyesH.SetSprite("Clear");
            agent.agentHitboxScript.eyesWB.SetSprite("Clear");
            agent.agentHitboxScript.eyesWBH.SetSprite("Clear");
        }
    }
    /// <summary>
    ///   <para>The base agent body hook. Need agent's name <see cref="RogueSprite"/>'s.</para>
    /// </summary>
    public class AgentBodySprite_Hook : HookBase<PlayfieldObject>, IDoUpdate
    {
        protected override void Initialize() { }
        public void Update()
        {
            Agent agent = (Agent)Instance;
            string direction = agent.playerDir;
            if (string.IsNullOrEmpty(direction))
                direction = "S";
            string bodySpriteName = $"{agent.agentName}Body{direction}";
            agent.agentHitboxScript.body.SetSprite(bodySpriteName);

            agent.agentHitboxScript.bodyH.SetSprite("Clear");
            agent.agentHitboxScript.bodyWBH.SetSprite("Clear");
        }
    }
}
