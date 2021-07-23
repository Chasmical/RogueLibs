using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents a custom status effect.</para>
	/// </summary>
	public abstract class CustomEffect : HookBase<StatusEffect>
	{
		/// <summary>
		///   <para>Gets the current <see cref="StatusEffect"/> instance.</para>
		/// </summary>
		public StatusEffect Effect => Instance;
		/// <summary>
		///   <para>Gets the status effect's <see cref="global::StatusEffects"/> instance.</para>
		/// </summary>
		public StatusEffects StatusEffects => Effect.GetStatusEffects();
		/// <summary>
		///   <para>Gets the status effect's owner.</para>
		/// </summary>
		public Agent Owner => Effect.GetStatusEffects().agent;
		/// <summary>
		///   <para>Gets the agent that caused the status effect.</para>
		/// </summary>
		public Agent CausedBy => Effect.causingAgent;

		/// <summary>
		///   <para>Gets or sets the status effect's current time.</para>
		/// </summary>
		public int CurrentTime { get => Effect.curTime; set => Effect.curTime = value; }

		/// <summary>
		///   <para>Gets the currently used instance of <see cref="GameController"/>.</para>
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Usage of gc fields in SoR")]
		public static GameController gc => GameController.gameController;

		/// <summary>
		///   <para>Gets the custom effect's metadata.</para>
		/// </summary>
		public EffectInfo EffectInfo { get; internal set; }

		/// <inheritdoc/>
		protected override sealed void Initialize()
		{
			Effect.dontRemoveOnDeath = !EffectInfo.RemoveOnDeath;
			Effect.removeOnKnockout = EffectInfo.RemoveOnKnockOut;
			Effect.keepBetweenLevels = !EffectInfo.RemoveOnNextLevel;
		}

		/// <summary>
		///   <para>Gets the default status effect time. Might get called on a partially initialized status effect.</para>
		/// </summary>
		/// <returns>The default status effect time, in seconds.</returns>
		public abstract int GetEffectTime();
		/// <summary>
		///   <para>Gets the default status effect hate. Might get called on a partially initialized status effect.
		///   <br/>Usually, it's 5 for negative effects and 0 for positive.</para>
		/// </summary>
		/// <returns>The default status effect hate.</returns>
		public abstract int GetEffectHate();

		/// <summary>
		///   <para>The method that is called when the status effect is added.</para>
		/// </summary>
		public abstract void OnAdded();
		/// <summary>
		///   <para>The method that is called when the status effect is refreshed.</para>
		/// </summary>
		public virtual void OnRefreshed() => CurrentTime = GetEffectTime();
		/// <summary>
		///   <para>The method that is called when the status effect is removed.</para>
		/// </summary>
		public abstract void OnRemoved();
		/// <summary>
		///   <para>The method that is called as a part of the status effect's update coroutine.</para>
		/// </summary>
		/// <param name="e">The custom effect's update data.</param>
		public abstract void OnUpdated(EffectUpdatedArgs e);
	}
	/// <summary>
	///   <para>Represents the custom effect's update coroutine args.</para>
	/// </summary>
	public class EffectUpdatedArgs : EventArgs
	{
		/// <summary>
		///   <para>Gets or sets the coroutine's update delay, in seconds.</para>
		/// </summary>
		public float UpdateDelay { get; set; }
		/// <summary>
		///   <para>Gets or sets whether to display the removal text, when the custom effect is removed.</para>
		/// </summary>
		public bool ShowTextOnRemoval { get; set; }
		/// <summary>
		///   <para>Gets or sets whether it's the coroutine's first tick.</para>
		/// </summary>
		public bool IsFirstTick { get; set; }
	}
	/// <summary>
	///   <para>Represents a factory of <see cref="CustomEffect"/> hooks.</para>
	/// </summary>
	public sealed class CustomEffectFactory : HookFactoryBase<StatusEffect>
	{
		private readonly Dictionary<string, EffectEntry> effectsDict = new Dictionary<string, EffectEntry>();
		/// <inheritdoc/>
		public override bool TryCreate(StatusEffect instance, out IHook<StatusEffect> hook)
		{
			if (instance != null && effectsDict.TryGetValue(instance.statusEffectName, out EffectEntry entry))
			{
				hook = entry.Initializer();
				if (hook is CustomEffect custom)
					custom.EffectInfo = entry.EffectInfo;
				return true;
			}
			hook = null;
			return false;
		}
		/// <summary>
		///   <para>Adds the specified <typeparamref name="TEffect"/> type to the factory.</para>
		/// </summary>
		/// <typeparam name="TEffect">The <see cref="CustomEffect"/> type to add.</typeparam>
		/// <returns>The added effect's metadata.</returns>
		public EffectInfo AddEffect<TEffect>() where TEffect : CustomEffect, new()
		{
			EffectInfo info = EffectInfo.Get<TEffect>();
			if (RogueFramework.IsDebugEnabled(DebugFlags.Effects))
				RogueFramework.LogDebug($"Created custom effect {typeof(TEffect)} ({info.Name}).");
			effectsDict.Add(info.Name, new EffectEntry { Initializer = () => new TEffect(), EffectInfo = info });
			return info;
		}

		private struct EffectEntry
		{
			public Func<IHook<StatusEffect>> Initializer;
			public EffectInfo EffectInfo;
		}
	}
}
