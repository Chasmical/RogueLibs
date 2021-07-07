using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace RogueLibsCore
{
	public abstract class CustomEffect : HookBase<StatusEffect>
	{
		public StatusEffect Effect => Instance;
		public StatusEffects StatusEffects => Effect.GetStatusEffects();
		public Agent Owner => Effect.GetStatusEffects().agent;
		public Agent CausedBy => Effect.causingAgent;

		public int CurrentTime { get => Effect.curTime; set => Effect.curTime = value; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Usage of gc fields in SoR")]
		public static GameController gc => GameController.gameController;

		public EffectInfo EffectInfo { get; internal set; }

		protected override sealed void Initialize()
		{
			Effect.dontRemoveOnDeath = !EffectInfo.RemoveOnDeath;
			Effect.removeOnKnockout = EffectInfo.RemoveOnKnockOut;
			Effect.keepBetweenLevels = !EffectInfo.RemoveOnNextLevel;
			OnAdded();
		}

		public abstract int GetEffectTime();
		public abstract int GetEffectHate();

		public abstract void OnAdded();
		public virtual void OnRefreshed() => CurrentTime = GetEffectTime();
		public abstract void OnRemoved();
		public abstract void OnUpdated(EffectUpdatedArgs e);
	}
	public class EffectUpdatedArgs : EventArgs
	{
		public float UpdateDelay { get; set; }
		public bool ShowTextOnRemoval { get; set; }
		public bool IsFirstTick { get; set; }
	}
	public sealed class CustomEffectFactory : HookFactoryBase<StatusEffect>
	{
		private readonly Dictionary<string, EffectEntry> effectsDict = new Dictionary<string, EffectEntry>();
		public override bool TryCreate(StatusEffect instance, out IHook<StatusEffect> hook)
		{
			if (instance != null && effectsDict.TryGetValue(instance.statusEffectName, out EffectEntry entry))
			{
				hook = entry.Initializer();
				if (hook is CustomEffect custom)
					custom.EffectInfo = entry.EffectInfo;
				hook.Instance = instance;
				return true;
			}
			hook = null;
			return false;
		}
		public EffectInfo AddEffect<T>() where T : CustomEffect, new()
		{
			EffectInfo info = EffectInfo.Get<T>();
			effectsDict.Add(info.Name, new EffectEntry { Initializer = () => new T(), EffectInfo = info });
			return info;
		}

		private struct EffectEntry
		{
			public Func<IHook<StatusEffect>> Initializer;
			public EffectInfo EffectInfo;
		}
	}
}
