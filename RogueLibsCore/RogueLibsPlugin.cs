using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BepInEx;
using HarmonyLib;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>RogueLibs plugin type.</para>
	/// </summary>
	[BepInPlugin(RogueLibs.GUID, RogueLibs.Name, RogueLibs.CompiledVersion)]
	public sealed partial class RogueLibsPlugin : BaseUnityPlugin
	{
		/// <summary>
		///   <para><see cref="RoguePatcher"/> instance, used by the <see cref="RogueLibsPlugin"/>.</para>
		/// </summary>
		public RoguePatcher Patcher;
		/// <summary>
		///   <para>Unity's Awake method.</para>
		/// </summary>
		public void Awake()
		{
			RogueLibsInternals.Plugin = this;
			RogueLibsInternals.Logger = Logger;
			Patcher = new RoguePatcher(this);

			PatchItems();
			PatchMisc();
			PatchUnlocks();
			PatchScrollingMenu();
			PatchCharacterCreation();
			PatchSprites();
		}
	}
}
