using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents a generic unlock in the game.</para>
	/// </summary>
	public abstract class UnlockWrapper : HookBase<Unlock>
	{
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="UnlockWrapper"/> class with the specified <paramref name="name"/> and <paramref name="type"/>.</para>
		/// </summary>
		/// <param name="name">The name of the unlock.</param>
		/// <param name="type">The type of the unlock.</param>
		/// <param name="unlockedFromStart">Determines whether the unlock is unlocked by default.</param>
		protected UnlockWrapper(string name, string type, bool unlockedFromStart)
		{
			Instance = new Unlock(name, type, unlockedFromStart) { __RogueLibsCustom = this };
			Name = name;
			Type = type;
		}
		internal UnlockWrapper(Unlock unlock)
		{
			Instance = unlock;
			unlock.__RogueLibsCustom = this;
			Name = unlock.unlockName;
			Type = unlock.unlockType;
		}

		/// <summary>
		///   <para>Gets the unlock's name.</para>
		/// </summary>
		public string Name
		{
			get => Unlock.unlockName;
			internal set => Unlock.unlockName = value;
		}
		/// <summary>
		///   <para>Gets the unlock's type.</para>
		/// </summary>
		public string Type { get; }

		/// <summary>
		///   <para>Gets the unlock that the wrapper is attached to.</para>
		/// </summary>
		public Unlock Unlock => Instance;

		/// <summary>
		///   <para>Gets or sets whether the unlock is unlocked.</para>
		/// </summary>
		public virtual bool IsUnlocked { get => Unlock.unlocked; set => Unlock.unlocked = value; }
		/// <summary>
		///   <para>Gets or sets the unlock's unlock cost, in nuggets.</para>
		/// </summary>
		public int UnlockCost { get => Unlock.cost; set => Unlock.cost = value; }
		/// <summary>
		///   <para>Gets or sets the unlock's loadout cost, in nuggets.</para>
		/// </summary>
		public int LoadoutCost { get => Unlock.cost2; set => Unlock.cost2 = value; }
		/// <summary>
		///   <para>Gets or sets the unlock's character creation cost, in points.</para>
		/// </summary>
		public int CharacterCreationCost { get => Unlock.cost3; set => Unlock.cost3 = value; }

		/// <summary>
		///   <para>Gets or sets whether the unlock is enabled and active in the game.</para>
		/// </summary>
		public abstract bool IsEnabled { get; set; }
		/// <summary>
		///   <para>Gets or sets whether the unlock is available in the primary menus.</para>
		/// </summary>
		public abstract bool IsAvailable { get; set; }

		/// <summary>
		///   <para>Gets or sets the list containing the unlock's cancellations - conflicting unlocks.</para>
		/// </summary>
		public List<string> Cancellations { get => Unlock.cancellations; set => Unlock.cancellations = value; }
		/// <summary>
		///   <para>Gets or sets the list containing the unlock's recommendations - purely aesthetic.</para>
		/// </summary>
		public List<string> Recommendations { get => Unlock.recommendations; set => Unlock.recommendations = value; }
		/// <summary>
		///   <para>Gets or sets the list containing the unlock's prerequisites - unlocks that must be unlocked in order to unlock this one.</para>
		/// </summary>
		public List<string> Prerequisites { get => Unlock.prerequisites; set => Unlock.prerequisites = value; }

		/// <inheritdoc/>
		protected sealed override void Initialize() => SetupUnlock();
		/// <summary>
		///   <para>Sets up the unlock.</para>
		/// </summary>
		public virtual void SetupUnlock() { }
		/// <summary>
		///   <para>Determines whether the unlock can be unlocked right now, in terms of prerequisites and other requirements.</para>
		/// </summary>
		/// <returns><see langword="true"/>, if the unlock can be unlocked right now; otherwise, <see langword="false"/>.</returns>
		public virtual bool CanBeUnlocked() => UnlockCost > -1
			&& Unlock.prerequisites.All(c => gc.sessionDataBig.unlocks.Exists(u => u.unlockName == c && u.unlocked));
		/// <summary>
		///   <para>Updates the unlock's unlock information. When overriden, you must set the <see cref="Unlock.nowAvailable"/> field.</para>
		/// </summary>
		public virtual void UpdateUnlock()
		{
			if ((Unlock.nowAvailable = !Unlock.unlocked && CanBeUnlocked()) && UnlockCost is 0)
				gc.unlocks.DoUnlockForced(Name, Type);
		}

		/// <summary>
		///   <para>Gets the unlock's displayed name.</para>
		/// </summary>
		/// <returns>The unlock's localized name.</returns>
		public virtual string GetName() => gc.nameDB.GetName(Name, Unlock.unlockNameType);
		/// <summary>
		///   <para>Gets the unlock's displayed description.</para>
		/// </summary>
		/// <returns>The unlock's localized description.</returns>
		public virtual string GetDescription() => gc.nameDB.GetName(Name, Unlock.unlockDescriptionType);
		/// <summary>
		///   <para>Gets the unlock's displayed image.</para>
		/// </summary>
		/// <returns>The unlock's image, if it's unlocked or can be unlocked; otherwise, <see langword="null"/>.</returns>
		public virtual Sprite GetImage() => RogueFramework.ExtraSprites.TryGetValue(Name, out Sprite image) ? image : null;

		/// <summary>
		///   <para>Gets the currently used instance of <see cref="GameController"/>.</para>
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Usage of gc fields in SoR")]
		public static GameController gc => GameController.gameController;

        public virtual bool ShowInPrerequisites => false;

    }
}
