using System;
using System.Collections.Generic;
using System.Linq;

namespace RogueLibsCore
{
	public abstract class UnlockWrapper
	{
		protected UnlockWrapper(string name, string type, bool unlockedFromStart)
		{
			Name = name;
			Type = type;
			Unlock = new Unlock(name, type, unlockedFromStart) { __RogueLibsCustom = this };
		}
		internal UnlockWrapper(Unlock unlock)
		{
			Unlock = unlock;
			unlock.__RogueLibsCustom = this;
			Name = unlock.unlockName;
			Type = unlock.unlockType;
		}

		public string Name { get; }
		public string Type { get; }

		public Unlock Unlock { get; internal set; }
		public virtual bool IsUnlocked { get => Unlock.unlocked; set => Unlock.unlocked = value; }
		public int UnlockCost { get => Unlock.cost; set => Unlock.cost = value; }
		public int LoadoutCost { get => Unlock.cost2; set => Unlock.cost2 = value; }
		public int CharacterCreationCost { get => Unlock.cost3; set => Unlock.cost3 = value; }

		public abstract bool IsEnabled { get; set; }
		public abstract bool IsAvailable { get; set; }

		public List<string> Cancellations { get => Unlock.cancellations; set => Unlock.cancellations = value; }
		public List<string> Recommendations { get => Unlock.recommendations; set => Unlock.recommendations = value; }
		public List<string> Prerequisites { get => Unlock.prerequisites; set => Unlock.prerequisites = value; }

		public virtual void SetupUnlock() { }
		public virtual bool CanBeUnlocked() => UnlockCost > -1
			&& Unlock.prerequisites.All(c => gc.sessionDataBig.unlocks.Exists(u => u.unlockName == c && u.unlocked));
		public virtual void UpdateUnlock()
		{
			if ((Unlock.nowAvailable = !Unlock.unlocked && CanBeUnlocked()) && UnlockCost == 0)
				IsUnlocked = true;
		}

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public static GameController gc => GameController.gameController;
	}
	public interface IUnlockInCC
	{
		bool IsAddedToCC { get; set; }
		bool IsAvailableInCC { get; set; }
	}
}
