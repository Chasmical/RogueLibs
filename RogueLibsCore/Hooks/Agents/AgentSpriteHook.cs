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
            if (string.IsNullOrEmpty(direction)) direction = "S";
            string headSpriteName = $"{agent.agentName}Head{direction}";
            agent.agentHitboxScript.hair.SetSprite(headSpriteName);
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
            if (string.IsNullOrEmpty(direction)) direction = "S";
            string bodydSpriteName = $"{agent.agentName}Body{direction}";
            agent.agentHitboxScript.hair.SetSprite(bodydSpriteName);
        }
    }
}