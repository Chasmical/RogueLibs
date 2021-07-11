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
	///   <para>Represents a Home Base unlock.</para>
	/// </summary>
	[Obsolete("This class is not used in the game.")]
	public class HomeBaseUnlock : UnlockWrapper
	{
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="HomeBaseUnlock"/> class without a name.</para>
		/// </summary>
		public HomeBaseUnlock() : this(null, false) { }
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="HomeBaseUnlock"/> class without a name.</para>
		/// </summary>
		/// <param name="unlockedFromStart">Determines whether the unlock is unlocked by default.</param>
		public HomeBaseUnlock(bool unlockedFromStart) : this(null, unlockedFromStart) { }
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="HomeBaseUnlock"/> class with the specified <paramref name="name"/>.</para>
		/// </summary>
		/// <param name="name">The unlock's name.</param>
		public HomeBaseUnlock(string name) : this(name, false) { }
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="HomeBaseUnlock"/> class with the specified <paramref name="name"/>.</para>
		/// </summary>
		/// <param name="name">The unlock's name.</param>
		/// <param name="unlockedFromStart">Determines whether the unlock is unlocked by default.</param>
		public HomeBaseUnlock(string name, bool unlockedFromStart) : base(name, "HomeBase", unlockedFromStart) { }
		internal HomeBaseUnlock(Unlock unlock) : base(unlock) { }

		/// <inheritdoc/>
		public override bool IsEnabled
		{
			get => !Unlock.notActive;
			set => Unlock.notActive = !value;
		}
		/// <inheritdoc/>
		public override bool IsAvailable
		{
			get => !Unlock.unavailable;
			set
			{
				Unlock.unavailable = !value;
				bool? cur = gc?.sessionDataBig?.homeBaseUnlocks?.Contains(Unlock);
				if (cur == true && !value) { gc.sessionDataBig.homeBaseUnlocks.Remove(Unlock); Unlock.homeBaseCount--; }
				else if (cur == false && value) { gc.sessionDataBig.homeBaseUnlocks.Add(Unlock); Unlock.homeBaseCount++; }
			}
		}
	}
	/// <summary>
	///   <para>Represents an extra unlock, that is used for achievements in the game.</para>
	/// </summary>
	public class ExtraUnlock : UnlockWrapper
	{
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="ExtraUnlock"/> class without a name.</para>
		/// </summary>
		public ExtraUnlock() : this(null, false) { }
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="ExtraUnlock"/> class without a name.</para>
		/// </summary>
		public ExtraUnlock(bool unlockedFromStart) : this(null, unlockedFromStart) { }
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="ExtraUnlock"/> class with the specified <paramref name="name"/>.</para>
		/// </summary>
		/// <param name="name">The unlock's and achievement's name.</param>
		public ExtraUnlock(string name) : this(name, false) { }
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="ExtraUnlock"/> class with the specified <paramref name="name"/>.</para>
		/// </summary>
		/// <param name="name">The unlock's and achievement's name.</param>
		/// <param name="unlockedFromStart">Determines whether the unlock is unlocked by default.</param>
		public ExtraUnlock(string name, bool unlockedFromStart) : base(name, "Extra", unlockedFromStart) { }
		internal ExtraUnlock(Unlock unlock) : base(unlock) { }

		/// <inheritdoc/>
		public override bool IsEnabled
		{
			get => !Unlock.notActive;
			set => Unlock.notActive = !value;
		}
		/// <inheritdoc/>
		public override bool IsAvailable
		{
			get => !Unlock.unavailable;
			set
			{
				Unlock.unavailable = !value;
				bool? cur = gc?.sessionDataBig?.extraUnlocks?.Contains(Unlock);
				if (cur == true && !value) { gc.sessionDataBig.extraUnlocks.Remove(Unlock); Unlock.extraCount--; }
				else if (cur == false && value) { gc.sessionDataBig.extraUnlocks.Add(Unlock); Unlock.extraCount++; }
			}
		}
	}
	/// <summary>
	///   <para>Represents a Loadout unlock.</para>
	/// </summary>
	[Obsolete("This class is not used in the game.")]
	public class LoadoutUnlock : UnlockWrapper
	{
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="LoadoutUnlock"/> class without a name.</para>
		/// </summary>
		public LoadoutUnlock() : this(null, false) { }
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="LoadoutUnlock"/> class without a name.</para>
		/// </summary>
		public LoadoutUnlock(bool unlockedFromStart) : this(null, unlockedFromStart) { }
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="LoadoutUnlock"/> class with the specified <paramref name="name"/>.</para>
		/// </summary>
		/// <param name="name">The unlock's name.</param>
		public LoadoutUnlock(string name) : this(name, false) { }
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="LoadoutUnlock"/> class with the specified <paramref name="name"/>.</para>
		/// </summary>
		/// <param name="name">The unlock's name.</param>
		/// <param name="unlockedFromStart">Determines whether the unlock is unlocked by default.</param>
		public LoadoutUnlock(string name, bool unlockedFromStart) : base(name, "Loadout", unlockedFromStart) { }
		internal LoadoutUnlock(Unlock unlock) : base(unlock) { }

		/// <inheritdoc/>
		public override bool IsEnabled
		{
			get => !Unlock.notActive;
			set => Unlock.notActive = !value;
		}
		/// <inheritdoc/>
		public override bool IsAvailable
		{
			get => !Unlock.unavailable;
			set
			{
				Unlock.unavailable = !value;
				bool? cur = gc?.sessionDataBig?.loadoutUnlocks?.Contains(Unlock);
				if (cur == true && !value) { gc.sessionDataBig.loadoutUnlocks.Remove(Unlock); Unlock.loadoutCount--; }
				else if (cur == false && value) { gc.sessionDataBig.loadoutUnlocks.Add(Unlock); Unlock.loadoutCount++; }
			}
		}
	}
	/// <summary>
	///   <para>Represents an agent unlock.</para>
	/// </summary>
	public class AgentUnlock : UnlockWrapper
	{
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="AgentUnlock"/> class without a name.</para>
		/// </summary>
		public AgentUnlock() : this(null, false) { }
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="AgentUnlock"/> class without a name.</para>
		/// </summary>
		/// <param name="unlockedFromStart">Determines whether the unlock is unlocked by default.</param>
		public AgentUnlock(bool unlockedFromStart) : this(null, unlockedFromStart) { }
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="AgentUnlock"/> class with the specified <paramref name="name"/>.</para>
		/// </summary>
		/// <param name="name">The unlock's and agent's name.</param>
		public AgentUnlock(string name) : this(name, false) { }
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="AgentUnlock"/> class with the specified <paramref name="name"/>.</para>
		/// </summary>
		/// <param name="name">The unlock's and agent's name.</param>
		/// <param name="unlockedFromStart">Determines whether the unlock is unlocked by default.</param>
		public AgentUnlock(string name, bool unlockedFromStart) : base(name, "Agent", unlockedFromStart) { }
		internal AgentUnlock(Unlock unlock) : base(unlock) { }

		/// <summary>
		///   <para>Gets the <see cref="BigQuestUnlock"/> associated with this agent.</para>
		/// </summary>
		public BigQuestUnlock BigQuest { get; internal set; }

		/// <inheritdoc/>
		public override bool IsEnabled
		{
			get => !Unlock.notActive;
			set => Unlock.notActive = !value;
		}
		/// <inheritdoc/>
		public override bool IsAvailable
		{
			get => !Unlock.unavailable;
			set
			{
				Unlock.unavailable = !value;
				bool? cur = gc?.sessionDataBig?.agentUnlocks?.Contains(Unlock);
				if (cur == true && !value) { gc.sessionDataBig.agentUnlocks.Remove(Unlock); Unlock.agentCount--; }
				else if (cur == false && value) { gc.sessionDataBig.agentUnlocks.Add(Unlock); Unlock.agentCount++; }
			}
		}

		/// <summary>
		///   <para>Gets or sets whether this unlock's agent is a Super Special Abilities variant of another agent.</para>
		/// </summary>
		public bool IsSSA
		{
			get => Unlock.isUpgrade;
			set => Unlock.isUpgrade = value;
		}

		/// <summary>
		///   <para>Sets up the Agent's associated <see cref="BigQuestUnlock"/>.</para>
		/// </summary>
		public override void SetupUnlock()
		{
			string bigQuest = Name + "_BQ";
			BigQuest = (BigQuestUnlock)RogueFramework.Unlocks.Find(u => u is BigQuestUnlock bq && bq.Name == bigQuest);
			if (BigQuest != null)
			{
				BigQuest.Agent = this;
				BigQuest.IsAvailableInCC = !IsSSA;
			}
		}
	}
}
