using System;
using System.Collections.Generic;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents a custom in-game mutator (also known as challenge).</para>
	/// </summary>
	public class CustomMutator : IComparable<CustomMutator>
	{
		/// <summary>
		///   <para>Id of this <see cref="CustomMutator"/>.</para>
		/// </summary>
		public string Id { get; }

		private bool unlocked;

		/// <summary>
		///   <para>Determines whether this <see cref="CustomMutator"/> is unlocked in the Mutator Menu.</para>
		///   <para>This value is saved in <see cref="RogueLibs"/> configuration file.</para>
		/// </summary>
		public bool Unlocked
		{
			get => unlocked;
			set
			{
				unlocked = value;
				RogueLibs.Instance.SaveData();
			}
		}
		/// <summary>
		///   <para>Determines whether this <see cref="CustomMutator"/> is active in-game.</para>
		/// </summary>
		public bool IsActive
		{
			get => GameController.gameController.challenges.Contains(Id);
			set
			{
				bool i = GameController.gameController.challenges.Contains(Id);
				bool j = GameController.gameController.originalChallenges.Contains(Id);
				if (value && !i)
					GameController.gameController.challenges.Add(Id);
				else if (!value && i)
					GameController.gameController.challenges.Remove(Id);

				if (value && !j)
					GameController.gameController.originalChallenges.Add(Id);
				else if (!value && j)
					GameController.gameController.originalChallenges.Remove(Id);
			}
		}
		/// <summary>
		///   <para>Determines whether this <see cref="CustomMutator"/> will be displayed in the Mutator Menu.</para>
		/// </summary>
		public bool ShowInMenu { get; set; } = true;

		/// <summary>
		///   <para><see cref="CustomMutator"/> IDs that will be automatically disabled, when this <see cref="CustomMutator"/> is enabled.</para>
		/// </summary>
		public string[] Conflicting { get; set; } = new string[0];

		private CustomName name, description;

		/// <summary>
		///   <para>Determines the position of this <see cref="CustomMutator"/> in the list.</para>
		/// </summary>
		public int SortingOrder { get; set; }
		/// <summary>
		///   <para>Determines the position of this <see cref="CustomMutator"/> in the list if the SortingOrder equals to another <see cref="CustomMutator"/>'s SortingOrder.</para>
		/// </summary>
		public int SortingIndex { get; set; }

		/// <summary>
		///   <para>Localizable Name of this <see cref="CustomMutator"/>.</para>
		/// </summary>
		public CustomName Name
		{
			get => name = name ?? RogueLibs.GetCustomName(Id, "Unlock");
			set => name = value;
		}
		/// <summary>
		///   <para>Localizable Description of this <see cref="CustomMutator"/>.</para>
		/// </summary>
		public CustomName Description
		{
			get => description = description ?? RogueLibs.GetCustomName("D_" + Id, "Unlock");
			set => description = value;
		}

		internal CustomMutator(string newId, bool newUnlocked)
		{
			Id = newId;
			unlocked = newUnlocked;
		}

		/// <summary>
		///   <para>Add conflicting <see cref="CustomMutator"/> IDs, so that it won't be possible to enable both them and this <see cref="CustomMutator"/> at the same time.</para>
		/// </summary>
		public void AddConflicting(params string[] conflictingMutators)
		{
			List<string> conflicts = new List<string>(Conflicting);
			foreach (string id in conflictingMutators)
				if (!conflicts.Contains(id))
					conflicts.Add(id);
			Conflicting = conflicts.ToArray();
		}
		/// <summary>
		///   <para>Add conflicting <see cref="CustomMutator"/>s, so that it won't be possible to enable both them and this <see cref="CustomMutator"/> at the same time.</para>
		/// </summary>
		public void AddConflicting(params CustomMutator[] conflictingMutators)
		{
			List<string> conflicts = new List<string>(Conflicting);
			foreach (CustomMutator mutator in conflictingMutators)
				if (!conflicts.Contains(mutator.Id))
					conflicts.Add(mutator.Id);
			Conflicting = conflicts.ToArray();
		}

		/// <summary>
		///   <para>Remove conflicting <see cref="CustomMutator"/> IDs, so that it will be possible to enable both them and this <see cref="CustomMutator"/> at the same time.</para>
		/// </summary>
		public void RemoveConflicting(params string[] conflictingMutators)
		{
			List<string> conflicts = new List<string>(Conflicting);
			foreach (string id in conflictingMutators)
				if (!conflicts.Contains(id))
					conflicts.Add(id);
			Conflicting = conflicts.ToArray();
		}
		/// <summary>
		///   <para>Remove conflicting <see cref="CustomMutator"/>s, so that it will be possible to enable both them and this <see cref="CustomMutator"/> at the same time.</para>
		/// </summary>
		public void RemoveConflicting(params CustomMutator[] conflictingMutators)
		{
			List<string> conflicts = new List<string>(Conflicting);
			foreach (CustomMutator mutator in conflictingMutators)
				if (!conflicts.Contains(mutator.Id))
					conflicts.Add(mutator.Id);
			Conflicting = conflicts.ToArray();
		}

		/// <summary>
		///   <para>An <see langword="event"/> that is called when this <see cref="CustomMutator"/> is enabled. Triggers only when a player turns on the mutator in the Mutator Menu.</para>
		/// </summary>
		public event Action OnEnabled;
		/// <summary>
		///   <para>An <see langword="event"/> that is called when this <see cref="CustomMutator"/> is disabled. Triggers only when a player turns off the mutator in the Mutator Menu.</para>
		/// </summary>
		public event Action OnDisabled;
		/// <summary>
		///   <para>An event that is called when this <see cref="CustomMutator"/> is enabled or disabled. Triggers only when a player turns on/off the mutator in the Mutator Menu.</para>
		///   <para><see cref="bool"/> obj determines whether the mutator is enabled.</para>
		/// </summary>
		public event Action<bool> OnChangedState;

		internal void TriggerStateChange(bool newState)
		{
			OnChangedState?.Invoke(newState);
			if (newState) OnEnabled?.Invoke();
			else OnDisabled?.Invoke();
		}

		int IComparable<CustomMutator>.CompareTo(CustomMutator other)
		{
			int res = SortingOrder.CompareTo(other.SortingOrder);
			if (res == 0)
			{
				res = SortingIndex.CompareTo(other.SortingIndex);
				if (res == 0) return Id.CompareTo(other.Id);
			}
			return res;
		}
	}
}
