using System;
using System.Collections.Generic;
using System.Linq;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Base unlock wrapper class.</para>
	/// </summary>
	public abstract class UnlockWrapper : IHook<Unlock>
	{
		/// <summary>
		///   <para>Initializes a new instance of the current type with the specified <paramref name="name"/> and <paramref name="type"/>.</para>
		/// </summary>
		/// <param name="name">Unlock's name/id.</param>
		/// <param name="type">Unlock's type.</param>
		/// <param name="unlockedFromStart">Determines whether the unlock is unlocked from the start.</param>
		protected UnlockWrapper(string name, string type, bool unlockedFromStart)
		{
			Unlock = new Unlock(name, type, unlockedFromStart) { __RogueLibsCustom = this };
			Name = name;
			Type = type;
		}
		internal UnlockWrapper(Unlock unlock)
		{
			Unlock = unlock;
			unlock.__RogueLibsCustom = this;
			Name = unlock.unlockName;
			Type = unlock.unlockType;
		}

		private string name;
		/// <summary>
		///   <para>Gets the unlock's name.</para>
		/// </summary>
		public string Name
		{
			get => name;
			internal set
			{
				name = value;
				Unlock.unlockName = value;
			}
		}
		/// <summary>
		///   <para>Gets the unlock's type.</para>
		/// </summary>
		public string Type { get; }

		/// <summary>
		///   <para>Gets the <see cref="Unlock"/> associated with the wrapper.</para>
		/// </summary>
		public Unlock Unlock { get; internal set; }
		Unlock IHook<Unlock>.Instance { get => Unlock; set => Unlock = value; }
		object IHook.Instance { get => Unlock; set => Unlock = (Unlock)value; }

		/// <summary>
		///   <para>Gets/sets whether the unlock is unlocked.</para>
		/// </summary>
		public virtual bool IsUnlocked { get => Unlock.unlocked; set => Unlock.unlocked = value; }
		/// <summary>
		///   <para>Gets/sets the unlock's unlock cost, in nuggets. Set to 0, if you want the unlock to be unlocked immediately after meeting its unlock conditions.</para>
		/// </summary>
		public int UnlockCost { get => Unlock.cost; set => Unlock.cost = value; }
		/// <summary>
		///   <para>Gets/sets the unlock's loadout cost, in nuggets.</para>
		/// </summary>
		public int LoadoutCost { get => Unlock.cost2; set => Unlock.cost2 = value; }
		/// <summary>
		///   <para>Gets/sets the unlock's character creation cost, in custom character points.</para>
		/// </summary>
		public int CharacterCreationCost { get => Unlock.cost3; set => Unlock.cost3 = value; }

		/// <summary>
		///   <para>Gets/sets whether the unlock is enabled and active in the game.</para>
		/// </summary>
		public abstract bool IsEnabled { get; set; }
		/// <summary>
		///   <para>Gets/sets whether the unlock is available in the menus.</para>
		/// </summary>
		public abstract bool IsAvailable { get; set; }

		/// <summary>
		///   <para>Gets/sets the unlock's cancellations - unlocks that are disabled/removed, when this unlock is enabled/added.</para>
		/// </summary>
		public List<string> Cancellations { get => Unlock.cancellations; set => Unlock.cancellations = value; }
		/// <summary>
		///   <para>Gets/sets the unlock's recommended unlocks.</para>
		/// </summary>
		public List<string> Recommendations { get => Unlock.recommendations; set => Unlock.recommendations = value; }
		/// <summary>
		///   <para>Gets/sets the unlock's prerequisites. If any of them is not unlocked, the unlock won't be purchasable.</para>
		/// </summary>
		public List<string> Prerequisites { get => Unlock.prerequisites; set => Unlock.prerequisites = value; }

		void IHook.Initialize() => SetupUnlock();
		/// <summary>
		///   <para>Sets up the unlock's variables.</para>
		/// </summary>
		public virtual void SetupUnlock() { }
		/// <summary>
		///   <para>Determines whether the unlock can be unlocked right now.</para>
		/// </summary>
		/// <returns><see langword="true"/>, if the unlock can be unlocked right now; otherwise, <see langword="false"/>.</returns>
		public virtual bool CanBeUnlocked() => UnlockCost > -1
			&& Unlock.prerequisites.All(c => gc.sessionDataBig.unlocks.Exists(u => u.unlockName == c && u.unlocked));
		/// <summary>
		///   <para>Updates the unlock's unlock conditions.</para>
		/// </summary>
		public virtual void UpdateUnlock()
		{
			if ((Unlock.nowAvailable = !Unlock.unlocked && CanBeUnlocked()) && UnlockCost == 0)
				IsUnlocked = true;
		}

		/// <summary>
		///   <para>The game's <see cref="GameController"/> that controls the game.</para>
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public static GameController gc => GameController.gameController;
	}
	/// <summary>
	///   <para>Base interface for unlocks that are available in the Character Creation.</para>
	/// </summary>
	public interface IUnlockInCC
	{
		/// <summary>
		///   <para>Gets/sets whether the unlock is added to the current custom character.</para>
		/// </summary>
		bool IsAddedToCC { get; set; }
		/// <summary>
		///   <para>Gets/sets whether the unlock is available in the Character Creation menu.</para>
		/// </summary>
		bool IsAvailableInCC { get; set; }
	}
}
