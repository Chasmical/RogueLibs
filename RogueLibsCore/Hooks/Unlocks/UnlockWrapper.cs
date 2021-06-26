using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RogueLibsCore
{
	public abstract class UnlockWrapper : HookBase<Unlock>
	{
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

		public string Name
		{
			get => Unlock.unlockName;
			internal set => Unlock.unlockName = value;
		}
		public string Type { get; }

		public Unlock Unlock => Instance;

		public virtual bool IsUnlocked { get => Unlock.unlocked; set => Unlock.unlocked = value; }
		public int UnlockCost { get => Unlock.cost; set => Unlock.cost = value; }
		public int LoadoutCost { get => Unlock.cost2; set => Unlock.cost2 = value; }
		public int CharacterCreationCost { get => Unlock.cost3; set => Unlock.cost3 = value; }

		public abstract bool IsEnabled { get; set; }
		public abstract bool IsAvailable { get; set; }

		public List<string> Cancellations { get => Unlock.cancellations; set => Unlock.cancellations = value; }
		public List<string> Recommendations { get => Unlock.recommendations; set => Unlock.recommendations = value; }
		public List<string> Prerequisites { get => Unlock.prerequisites; set => Unlock.prerequisites = value; }

		protected sealed override void Initialize() => SetupUnlock();
		public virtual void SetupUnlock() { }
		public virtual bool CanBeUnlocked() => UnlockCost > -1
			&& Unlock.prerequisites.All(c => gc.sessionDataBig.unlocks.Exists(u => u.unlockName == c && u.unlocked));
		public virtual void UpdateUnlock()
		{
			if ((Unlock.nowAvailable = !Unlock.unlocked && CanBeUnlocked()) && UnlockCost is 0)
				IsUnlocked = true;
		}

		public virtual string GetName() => IsUnlocked || Unlock.nowAvailable ? gc.nameDB.GetName(Name, Unlock.unlockNameType) : "?????";
		public virtual string GetDescription()
		{
			if (IsUnlocked || Unlock.nowAvailable)
			{
				string text = gc.nameDB.GetName(Name, Unlock.unlockDescriptionType);
				AddCancellationsTo(ref text);
				AddRecommendationsTo(ref text);
				if (!IsUnlocked) AddPrerequisitesTo(ref text);
				return text.Trim('\n');
			}
			else
			{
				string text = "?????";
				AddPrerequisitesTo(ref text);
				return text.Trim('\n');
			}
		}
		public virtual Sprite GetImage() => (IsUnlocked || Unlock.nowAvailable)
			&& RogueFramework.ExtraSprites.TryGetValue(Name, out Sprite image) ? image : null;

		protected void AddCancellationsTo(ref string description)
		{
			if (Unlock.cancellations.Count > 0)
			{
				description += $"\n\n<color=orange>{gc.nameDB.GetName("Cancels", "Interface")}:</color>\n" +
					string.Join(", ", Unlock.cancellations.ConvertAll(unlockName =>
					{
						DisplayedUnlock unlock = (DisplayedUnlock)gc.sessionDataBig.unlocks.Find(u => u.unlockName == unlockName)?.__RogueLibsCustom;
						return unlock?.GetName();
					}));
			}
		}
		protected void AddRecommendationsTo(ref string description)
		{
			if (Unlock.recommendations.Count > 0)
			{
				description += $"\n\n<color=cyan>{gc.nameDB.GetName("Recommends", "Interface")}:</color>\n" +
					string.Join(", ", Unlock.recommendations.ConvertAll(unlockName =>
					{
						DisplayedUnlock unlock = (DisplayedUnlock)gc.sessionDataBig.unlocks.Find(u => u.unlockName == unlockName)?.__RogueLibsCustom;
						return unlock?.GetName();
					}));
			}
		}
		protected void AddPrerequisitesTo(ref string description)
		{
			List<string> prereqs = new List<string>();
			if (Unlock.prerequisites.Count > 0 || UnlockCost != 0)
			{
				prereqs.Add(string.Join(", ", Unlock.prerequisites.ConvertAll(unlockName =>
				{
					Unlock un = gc.sessionDataBig.unlocks.Find(u => u.unlockName == unlockName);
					if (un.__RogueLibsCustom is UnlockWrapper unlock)
					{
						string name = unlock.GetName();
						if (unlock.IsUnlocked) name = $"<color=#EEEEEE55>{name}</color>";
						return name;
					}
					else return "?????";
				})));
			}
			if (Unlock.cost is -2)
			{
				prereqs.Add(gc.unlocks.GetSpecialUnlockInfo(Name, Unlock));
			}
			if (Unlock.cost > 0)
			{
				string costColor = gc.sessionDataBig.nuggets >= Unlock.cost ? "cyan" : "red";
				prereqs.Add($"{gc.nameDB.GetName("UnlockFor", "Unlock")} <color={costColor}>${Unlock.cost}</color>");
			}
			if (prereqs.Count > 0)
				description += $"\n<color=cyan>{gc.nameDB.GetName("Prerequisites", "Unlock")}:</color>\n" + string.Join("\n", prereqs);
		}

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Usage of gc fields in SoR")]
		public static GameController gc => GameController.gameController;
	}
	public interface IUnlockInCC
	{
		bool IsAddedToCC { get; set; }
		bool IsAvailableInCC { get; set; }
	}
}
