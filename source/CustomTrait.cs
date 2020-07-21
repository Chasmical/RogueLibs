using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents a custom in-game trait.</para>
	/// </summary>
	public class CustomTrait
	{
		/// <summary>
		///   <para>Id of this <see cref="CustomTrait"/>.</para>
		/// </summary>
		public string Id { get; }

		internal CustomTrait(string id) => Id = id;

		private CustomTrait upgrade, downgrade;

		public CustomTrait Upgrade
		{
			get => upgrade;
			set
			{
				upgrade = value;
				value.downgrade = this;
			}
		}
		public CustomTrait Downgrade
		{
			get => downgrade;
			set
			{
				downgrade = value;
				value.upgrade = this;
			}
		}

		public CustomTrait[] Conflicting { get; set; }
		public CustomAbility MustHaveAbility { get; set; }

		public void AddConflicting(params CustomTrait[] conflictingTraits)
		{
			List<CustomTrait> list = new List<CustomTrait>(Conflicting);
			foreach (CustomTrait trait in conflictingTraits)
				if (!list.Contains(trait))
					list.Add(trait);
			Conflicting = list.ToArray();
		}
	}
}
