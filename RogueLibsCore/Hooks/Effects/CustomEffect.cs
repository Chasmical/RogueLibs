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
			Effect.keepBetweenLevels = !EffectInfo.RemoveOnNextLevel;
			Effect.dontRemoveOnDeath = !EffectInfo.RemoveOnDeath;
			Effect.removeOnKnockout = EffectInfo.RemoveOnKnockout;
			OnAdded();
		}

		public abstract void OnAdded();
		public abstract void OnRemoved();
		public abstract void OnUpdated(ref float nextUpdateDelay);
	}
}
