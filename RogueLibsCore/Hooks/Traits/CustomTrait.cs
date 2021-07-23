using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents a custom trait.</para>
	/// </summary>
	public abstract class CustomTrait : HookBase<Trait>
	{
		/// <summary>
		///   <para>Gets the current <see cref="global::Trait"/> instance.</para>
		/// </summary>
		public Trait Trait => Instance;
		/// <summary>
		///   <para>Gets the trait's <see cref="StatusEffects"/> instance.</para>
		/// </summary>
		public StatusEffects StatusEffects => Trait.GetStatusEffects();
		/// <summary>
		///   <para>Gets the trait's owner.</para>
		/// </summary>
		public Agent Owner => Trait.GetStatusEffects().agent;

		/// <summary>
		///   <para>Gets the currently used instance of <see cref="GameController"/>.</para>
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Usage of gc fields in SoR")]
		public static GameController gc => GameController.gameController;

		/// <summary>
		///   <para>Gets the custom trait's metadata.</para>
		/// </summary>
		public TraitInfo TraitInfo { get; internal set; }

		/// <inheritdoc/>
		protected override sealed void Initialize() => OnAdded();

		/// <summary>
		///   <para>The method that is called when the trait is added.</para>
		/// </summary>
		public abstract void OnAdded();
		/// <summary>
		///   <para>The method that is called when the trait is removed.</para>
		/// </summary>
		public abstract void OnRemoved();
	}
	/// <summary>
	///   <para>Indicates that a custom trait has an update coroutine.</para>
	/// </summary>
	public interface ITraitUpdateable
	{
		/// <summary>
		///   <para>The method that is called as a part of the trait's update coroutine.</para>
		/// </summary>
		/// <param name="e">The custom trait's update data.</param>
		void OnUpdated(TraitUpdatedArgs e);
	}
	/// <summary>
	///   <para>Represents the custom trait's update coroutine args.</para>
	/// </summary>
	public class TraitUpdatedArgs : EventArgs
	{
		/// <summary>
		///   <para>Gets or sets the coroutine's update delay, in seconds.</para>
		/// </summary>
		public float UpdateDelay { get; set; }
	}
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
