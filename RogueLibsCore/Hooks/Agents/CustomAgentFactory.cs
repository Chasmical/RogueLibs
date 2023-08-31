using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine.Profiling.Memory.Experimental;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a factory of <see cref="CustomAgent"/> hooks.</para>
    /// </summary>
    public sealed class CustomAgentFactory : HookFactoryBase<Agent>
    {
        private readonly Dictionary<string, AgentEntry> agentsDict = new Dictionary<string, AgentEntry>();
        /// <inheritdoc/>
        public override bool TryCreate(Agent? instance, [NotNullWhen(true)] out IHook<Agent>? hook)
        {
            if (instance?.agentName != null && agentsDict.TryGetValue(instance.agentName, out AgentEntry entry))
            {
                hook = entry.Initializer();
                if (hook is CustomAgent custom)
                    custom.Metadata = entry.Metadata;
                return true;
            }
            hook = null;
            return false;
        }
        /// <summary>
        ///   <para>Adds the specified <typeparamref name="TAgent"/> type to the factory.</para>
        /// </summary>
        /// <typeparam name="TAgent">The <see cref="CustomAgent"/> type to add.</typeparam>
        /// <returns>The added agent's metadata.</returns>
        public CustomAgentMetadata AddAgent<TAgent>() where TAgent : CustomAgent, new()
        {
            CustomAgentMetadata metadata = CustomAgentMetadata.Get<TAgent>();
            if (RogueFramework.IsDebugEnabled(DebugFlags.Agents))
                RogueFramework.LogDebug($"Created custom agent {typeof(TAgent)} ({metadata.Name}).");
            agentsDict.Add(metadata.Name, new AgentEntry { Initializer = static () => new TAgent(), Metadata = metadata });
            return metadata;
        }

        private struct AgentEntry
        {
            public Func<IHook<Agent>> Initializer;
            public CustomAgentMetadata Metadata;
        }
    }
}
