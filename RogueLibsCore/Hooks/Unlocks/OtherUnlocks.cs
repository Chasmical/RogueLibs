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
	///   <para>Unused Home Base unlock wrapper.</para>
	/// </summary>
	public class HomeBaseUnlock : UnlockWrapper
	{
		/// <summary>
		///   <para>Initializes a new instance of <see cref="HomeBaseUnlock"/> with the specified <paramref name="name"/>.</para>
		/// </summary>
		/// <param name="name">Unlock's name/id.</param>
		/// <param name="unlockedFromStart">Determines whether the unlock is unlocked from the start.</param>
		public HomeBaseUnlock(string name, bool unlockedFromStart = false) : base(name, "HomeBase", unlockedFromStart) { }
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
	///   <para>Unused extra unlock wrapper.</para>
	/// </summary>
	public class ExtraUnlock : UnlockWrapper
	{
		/// <summary>
		///   <para>Initializes a new instance of <see cref="ExtraUnlock"/> with the specified <paramref name="name"/>.</para>
		/// </summary>
		/// <param name="name">Unlock's name/id.</param>
		/// <param name="unlockedFromStart">Determines whether the unlock is unlocked from the start.</param>
		public ExtraUnlock(string name, bool unlockedFromStart = false) : base(name, "Extra", unlockedFromStart) { }
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
	///   <para>Unused loadout unlock wrapper.</para>
	/// </summary>
	public class LoadoutUnlock : UnlockWrapper
	{
		/// <summary>
		///   <para>Initializes a new instance of <see cref="LoadoutUnlock"/> with the specified <paramref name="name"/>.</para>
		/// </summary>
		/// <param name="name">Unlock's name/id.</param>
		/// <param name="unlockedFromStart">Determines whether the unlock is unlocked from the start.</param>
		public LoadoutUnlock(string name, bool unlockedFromStart = false) : base(name, "Loadout", unlockedFromStart) { }
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
	///   <para>Agent unlock wrapper.</para>
	/// </summary>
	public class AgentUnlock : UnlockWrapper
	{
		/// <summary>
		///   <para>Initializes a new instance of <see cref="AgentUnlock"/> with the specified <paramref name="name"/>.</para>
		/// </summary>
		/// <param name="name">Unlock's name/id.</param>
		/// <param name="unlockedFromStart">Determines whether the unlock is unlocked from the start.</param>
		public AgentUnlock(string name, bool unlockedFromStart = false) : base(name, "Agent", unlockedFromStart) { }
		internal AgentUnlock(Unlock unlock) : base(unlock) { }

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
	}
}
