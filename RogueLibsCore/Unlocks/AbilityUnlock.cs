using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using HarmonyLib;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Ability unlock wrapper.</para>
	/// </summary>
	public class AbilityUnlock : DisplayedUnlock, IUnlockInCC
	{
		/// <summary>
		///   <para>Initializes a new instance of <see cref="AbilityUnlock"/> with the specified <paramref name="name"/>.</para>
		/// </summary>
		/// <param name="name">Unlock's name/id. Must be the same as the ability's name/id.</param>
		/// <param name="unlockedFromStart">Determines whether the unlock is unlocked from the start.</param>
		public AbilityUnlock(string name, bool unlockedFromStart = false) : base(name, "Ability", unlockedFromStart) => IsAvailableInCC = true;
		internal AbilityUnlock(Unlock unlock) : base(unlock) { }

		/// <inheritdoc/>
		public override bool IsEnabled
		{
			get => !Unlock.notActive;
			set => Unlock.notActive = !value;
		}
		/// <inheritdoc/>
		public bool IsAddedToCC
		{
			get => ((CustomCharacterCreation)Menu).CC.abilityChosen == Name;
			set
			{
				bool cur = IsAddedToCC;
				if (cur && !value) ((CustomCharacterCreation)Menu).CC.abilityChosen = "";
				else if (!cur && value) ((CustomCharacterCreation)Menu).CC.abilityChosen = Name;
			}
		}

		/// <inheritdoc/>
		public override bool IsAvailable
		{
			get => !Unlock.unavailable;
			set
			{
				Unlock.unavailable = !value;
				bool? cur = gc?.sessionDataBig?.abilityUnlocks?.Contains(Unlock);
				if (cur == true && !value) { gc.sessionDataBig.abilityUnlocks.Remove(Unlock); Unlock.abilityCount--; }
				else if (cur == false && value) { gc.sessionDataBig.abilityUnlocks.Add(Unlock); Unlock.abilityCount++; }
			}
		}
		/// <inheritdoc/>
		public bool IsAvailableInCC
		{
			get => Unlock.onlyInCharacterCreation;
			set => Unlock.onlyInCharacterCreation = value;
		}

		/// <inheritdoc/>
		public override void UpdateButton()
		{
			if (Menu.Type == UnlocksMenuType.CharacterCreation)
				UpdateButton(IsAddedToCC);
		}
		/// <inheritdoc/>
		public override void OnPushedButton()
		{
			if (IsUnlocked)
			{
				if (Menu.Type == UnlocksMenuType.CharacterCreation)
				{
					PlaySound("ClickButton");
					AbilityUnlock previous = (AbilityUnlock)Menu.Unlocks.Find(u => u is AbilityUnlock ability && ability.IsAddedToCC);
					IsAddedToCC = !IsAddedToCC;
					UpdateButton();
					previous?.UpdateButton();
					UpdateMenu();
				}
			}
			else if (Unlock.nowAvailable && UnlockCost <= gc.sessionDataBig.nuggets)
			{
				PlaySound("BuyUnlock");
				gc.unlocks.SubtractNuggets(UnlockCost);
				gc.unlocks.DoUnlock(Name, Type);
				UpdateAllUnlocks();
				UpdateMenu();
			}
			else PlaySound("CantDo");
		}

		/// <inheritdoc/>
		public override Sprite GetImage() => IsUnlocked || Unlock.nowAvailable
			? GameResources.gameResources.itemDic.TryGetValue(Name, out Sprite image) ? image : base.GetImage()
			: null;
	}
}
