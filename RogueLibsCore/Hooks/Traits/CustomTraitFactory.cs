using System;
using System.Collections.Generic;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents a factory of <see cref="CustomTrait"/> hooks.</para>
	/// </summary>
	public sealed class CustomTraitFactory : HookFactoryBase<Trait>
	{
		private readonly Dictionary<string, TraitEntry> traitsDict = new Dictionary<string, TraitEntry>();
		/// <inheritdoc/>
		public override bool TryCreate(Trait instance, out IHook<Trait> hook)
		{
			if (instance != null && traitsDict.TryGetValue(instance.traitName, out TraitEntry entry))
			{
				hook = entry.Initializer();
				if (hook is CustomTrait custom)
					custom.TraitInfo = entry.TraitInfo;
				return true;
			}
			hook = null;
			return false;
		}
		/// <summary>
		///   <para>Adds the specified <typeparamref name="TTrait"/> type to the factory.</para>
		/// </summary>
		/// <typeparam name="TTrait">The <see cref="CustomTrait"/> type to add.</typeparam>
		/// <returns>The added trait's metadata.</returns>
		public TraitInfo AddTrait<TTrait>() where TTrait : CustomTrait, new()
		{
			TraitInfo info = TraitInfo.Get<TTrait>();
			if (RogueFramework.IsDebugEnabled(DebugFlags.Traits))
				RogueFramework.LogDebug($"Created custom trait {typeof(TTrait)} ({info.Name}).");
			traitsDict.Add(info.Name, new TraitEntry { Initializer = () => new TTrait(), TraitInfo = info });
			return info;
		}

		private struct TraitEntry
		{
			public Func<IHook<Trait>> Initializer;
			public TraitInfo TraitInfo;
		}
	}
}
