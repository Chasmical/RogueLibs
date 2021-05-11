using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents a base class for all custom effects.</para>
	/// </summary>
	public abstract class CustomEffect : HookBase<StatusEffect>
	{
		/// <summary>
		///   <para>Gets the associated <see cref="StatusEffect"/> object.</para>
		/// </summary>
		public StatusEffect Effect => Instance;

		/// <summary>
		///   <para>Gets the <see cref="global::StatusEffects"/>, that contains the status effect.</para>
		/// </summary>
		public StatusEffects StatusEffects => Effect.GetStatusEffects();
		/// <summary>
		///   <para>Gets the <see cref="Agent"/> that has the status effect.</para>
		/// </summary>
		public Agent Owner => Effect.GetStatusEffects().agent;

		/// <summary>
		///   <para>Gets or sets the status effect's current time.</para>
		/// </summary>
		public int CurrentTime { get => Effect.curTime; set => Effect.curTime = value; }

		/// <summary>
		///   <para>Gets the game's <see cref="GameController"/> that controls the game.</para>
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public static GameController gc => GameController.gameController;

		/// <summary>
		///   <para>Gets the default information about the status effect, defined in the type's attributes.</para>
		/// </summary>
		public CustomEffectInfo EffectInfo { get; internal set; }

		/// <inheritdoc/>
		protected override sealed void Initialize()
		{
			Effect.keepBetweenLevels = false;
			Effect.dontRemoveOnDeath = true;
			Effect.removeOnKnockout = false;
			OnAdded();
		}

		/// <summary>
		///   <para>Gets the status effect's default time. Do not initialize the hook in this method!</para>
		/// </summary>
		/// <returns>Time, in seconds, that the status effect will last for.</returns>
		public abstract int GetEffectTime();
		/// <summary>
		///   <para>Gets the status effect's default hate factor. Usually, it's either 5 or 0.</para>
		/// </summary>
		/// <returns>Hate factor, that the status effect will give to NPCs, that received this effect from the player.</returns>
		public abstract int GetEffectHate();

		/// <summary>
		///   <para>Method that is called once, when creating a new status effect. Set up your effect's fields and properties here.</para>
		/// </summary>
		public abstract void OnAdded();
		/// <summary>
		///   <para>Method that is called, when the effect is reapplied. By default, it just resets the effect's timer.</para>
		/// </summary>
		public virtual void OnRefreshed() => CurrentTime = GetEffectTime();
		/// <summary>
		///   <para>Method that is called once, when the status effect is removed. Change the character's stats and data here.</para>
		/// </summary>
		public abstract void OnRemoved();
		/// <summary>
		///   <para>Method that is called every time the effect is updated.</para>
		/// </summary>
		public abstract void OnUpdated(EffectUpdatedArgs e);
		/// <summary>
		///   <para>Method that is called once, when the effect's time is up. Use it to add new stage</para>
		/// </summary>
		public abstract void OnFinished();
	}
	public class EffectUpdatedArgs : EventArgs
	{
		public float UpdateDelay { get; set; }
		public bool Cancel { get; set; }
		public bool ShowTextOnRemoval { get; set; }
		public bool IsFirstTick { get; set; }
	}
}
