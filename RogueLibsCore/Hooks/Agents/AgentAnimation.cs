using RogueLibsCore;
using System;
using System.Collections.Generic;
using UnityEngine;
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