using System;
using UnityEngine;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a custom item.</para>
    /// </summary>

    public abstract class CustomAgent : HookBase<Agent>
    {
        /// <summary>
        ///   <para>Gets the current <see cref="InvItem"/> instance.</para>
        /// </summary>
        public Agent Agent => Instance;
        /// <summary>
        ///   <para>Gets the custom agent's metadata.</para>
        /// </summary>
        public AgentInfo AgentInfo { get; internal set; } = null!; // initialized immediately in CustomAgentFactory

        /// <inheritdoc/>
        protected sealed override void Initialize()
        {
            try
            {
                SetupAgentStats();
            }
            catch (Exception e)
            {
                RogueFramework.LogError(e, "SetupAgentStats", this, Agent);
            }
        }
        /// <summary>
        ///   <para>The method that is called when the agent's stats are set up.</para>
        /// </summary>
        public abstract void SetupAgentStats();
    }
}