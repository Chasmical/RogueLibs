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

		/// <summary>
		///   <para>Determines the position of this <see cref="CustomMutator"/> in the list.</para>
		/// </summary>
		public int SortingOrder { get; set; }
		/// <summary>
		///   <para>Determines the position of this <see cref="CustomMutator"/> in the list, if its SortingOrder equals to another's SortingOrder.</para>
		/// </summary>
		public int SortingIndex { get; set; }

		int IComparable<CustomMutator>.CompareTo(CustomMutator other)
		{
			int res = SortingOrder.CompareTo(other.SortingOrder);
			return res != 0 ? res : SortingIndex.CompareTo(other.SortingIndex);
		}

		/// <summary>
		///   <para>Localizable name of this <see cref="CustomMutator"/>.</para>
		/// </summary>
		public CustomName Name { get; }
		/// <summary>
		///   <para>Localizable description of this <see cref="CustomMutator"/>.</para>
		/// </summary>
		public CustomName Description { get; }

		/// <summary>
		///   <para>Array of mutator IDs that will be automatically disabled when this <see cref="CustomMutator"/> is enabled.</para>
		/// </summary>
		public string[] ConflictingMutators { get; set; }

		/// <summary>
		///   <para>Adds <paramref name="conflicting"/> mutators.</para>
		/// </summary>
		public void AddConflicting(params string[] conflicting)
		{
			int length = conflicting.Length;
			int length2 = ConflictingMutators.Length;
			string[] newArr = new string[length2 + length];
			Array.Copy(ConflictingMutators, 0, newArr, 0, length2);
			Array.Copy(conflicting, 0, newArr, length2, length);
			ConflictingMutators = newArr;
		}
		/// <summary>
		///   <para>Adds <paramref name="conflicting"/> mutators.</para>
		/// </summary>
		public void AddConflicting(params CustomMutator[] conflicting)
		{
			int length = conflicting.Length;
			int length2 = ConflictingMutators.Length;
			string[] newArr = new string[length2 + length];
			Array.Copy(ConflictingMutators, 0, newArr, 0, length2);
			for (int i = 0; i < length; i++)
				newArr[length2 + i] = conflicting[i].Id;
			ConflictingMutators = newArr;
		}

		internal CustomMutator(string id, CustomName name, CustomName description)
		{
			Id = id;
			Name = name;
			Description = description;
		}
	}
}
