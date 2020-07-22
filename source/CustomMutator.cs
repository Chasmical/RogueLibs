using System;
using System.Collections.Generic;
using System.Linq;

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

		/// <summary>
		///   <para>Determines the position of this <see cref="CustomMutator"/> in the list.</para>
		/// </summary>
		public int SortingOrder { get; set; } = -1;
		/// <summary>
		///   <para>Determines the position of this <see cref="CustomMutator"/> in the list, if its SortingOrder equals to another's SortingOrder.</para>
		/// </summary>
		public int SortingIndex { get; set; } = 0;

		int IComparable<CustomMutator>.CompareTo(CustomMutator other)
		{
			int res = SortingOrder.CompareTo(other.SortingOrder);
			return res != 0 ? res : SortingIndex.CompareTo(other.SortingIndex);
		}

		/// <summary>
		///   <para>Localizable name of this <see cref="CustomMutator"/>.</para>
		/// </summary>
		public CustomName Name { get; private set; }
		/// <summary>
		///   <para>Localizable description of this <see cref="CustomMutator"/>.</para>
		/// </summary>
		public CustomName Description { get; private set; }

		/// <summary>
		///   <para>Determines whether this <see cref="CustomMutator"/> is unlocked.</para>
		/// </summary>
		public bool Unlocked { get; set; } = true;
		/// <summary>
		///   <para>Determines whether this <see cref="CustomMutator"/> will be displayed.</para>
		/// </summary>
		public bool ShowInMenu { get; set; } = true;

		internal CustomMutator(string id, CustomName name, CustomName description)
		{
			Id = id;
			Name = name;
			Description = description;
		}

		/// <summary>
		///   <para>Array of mutator IDs that will be automatically disabled when this <see cref="CustomMutator"/> is enabled.</para>
		/// </summary>
		public List<string> Conflicting { get; set; } = new List<string>();

		/// <summary>
		///   <para>Adds <paramref name="conflicting"/> mutators.</para>
		/// </summary>
		public void AddConflicting(params string[] conflicting) => Conflicting.AddRange(conflicting);
		/// <summary>
		///   <para>Adds <paramref name="conflicting"/> mutators.</para>
		/// </summary>
		public void AddConflicting(params CustomMutator[] conflicting) => Conflicting.AddRange(conflicting.Select(m => m.Id));

		/// <summary>
		///   <para>Event that is called when this <see cref="CustomMutator"/> is enabled. Triggered only when the player turns it on in the Mutator Menu.</para>
		/// </summary>
		public event Action OnEnabled;
		/// <summary>
		///   <para>Event that is called when this <see cref="CustomMutator"/> is disabled. Triggered only when the player turns it off in the Mutator Menu.</para>
		/// </summary>
		public event Action OnDisabled;
		/// <summary>
		///   <para>Event that is called when this <see cref="CustomMutator"/> is enabled/disabled. Triggered only when the player turns it on/off in the Mutator Menu.</para>
		/// </summary>
		public event Action<bool> OnChangedState;

		internal void TriggerStateChange(bool newState)
		{
			OnChangedState?.Invoke(newState);
			if (newState) OnEnabled?.Invoke();
			else OnDisabled?.Invoke();
		}

	}
}
