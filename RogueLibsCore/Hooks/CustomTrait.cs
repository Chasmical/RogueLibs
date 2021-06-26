using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLibsCore
{
	public abstract class CustomTrait : HookBase<Trait>
	{
		public Trait Trait => Instance;
		public StatusEffects StatusEffects => Trait.GetStatusEffects();
		public Agent Owner => Trait.GetStatusEffects().agent;

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Usage of gc fields in SoR")]
		public static GameController gc => GameController.gameController;

		public TraitInfo TraitInfo { get; internal set; }

		protected override sealed void Initialize() => OnAdded();

		public abstract void OnAdded();
		public abstract void OnRemoved();
		public abstract void OnUpdated(TraitUpdatedArgs e);
	}
	public class TraitUpdatedArgs : EventArgs
	{
		public float UpdateDelay { get; set; }
	}
	public sealed class CustomTraitFactory : HookFactoryBase<Trait>
	{
		private readonly Dictionary<string, TraitEntry> traitsDict = new Dictionary<string, TraitEntry>();
		public override bool TryCreate(Trait instance, out IHook<Trait> hook)
		{
			if (instance != null && traitsDict.TryGetValue(instance.traitName, out TraitEntry entry))
			{
				hook = entry.Initializer();
				if (hook is CustomTrait custom)
					custom.TraitInfo = entry.TraitInfo;
				hook.Instance = instance;
				return true;
			}
			hook = null;
			return false;
		}
		public TraitInfo AddTrait<T>() where T : CustomTrait, new()
		{
			TraitInfo info = TraitInfo.Get<T>();
			traitsDict.Add(info.Name, new TraitEntry { Initializer = () => new T(), TraitInfo = info });
			return info;
		}

		private struct TraitEntry
		{
			public Func<IHook<Trait>> Initializer;
			public TraitInfo TraitInfo;
		}
	}
}
