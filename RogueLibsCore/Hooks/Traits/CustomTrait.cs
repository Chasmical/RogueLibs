using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents a base class for all custom traits.</para>
	/// </summary>
	public abstract class CustomTrait : HookBase<Trait>
	{
		/// <summary>
		///   <para>Gets the associated <see cref="global::Trait"/> object.</para>
		/// </summary>
		public Trait Trait => Instance;

		/// <summary>
		///   <para>Gets the <see cref="global::StatusEffects"/>, that contains the trait.</para>
		/// </summary>
		public StatusEffects StatusEffects => Trait.GetStatusEffects();
		/// <summary>
		///   <para>Gets the <see cref="Agent"/> that has the trait.</para>
		/// </summary>
		public Agent Owner => Trait.GetStatusEffects().agent;

		/// <summary>
		///   <para>Gets the game's <see cref="GameController"/> that controls the game.</para>
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public static GameController gc => GameController.gameController;

		/// <summary>
		///   <para>Gets the default information about the trait, defined in the type's attributes.</para>
		/// </summary>
		public CustomTraitInfo TraitInfo { get; internal set; }

		/// <inheritdoc/>
		protected override sealed void Initialize() => OnAdded();

		public abstract void OnAdded();
		public abstract void OnRemoved();
		public abstract void OnUpdated(TraitUpdatedArgs e);
	}
	public class TraitUpdatedArgs : EventArgs
	{
		public float UpdateDelay { get; set; }
	}
}
