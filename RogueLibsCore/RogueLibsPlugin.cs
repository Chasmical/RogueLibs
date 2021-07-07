using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using BepInEx;
using HarmonyLib;

namespace RogueLibsCore
{
	[BepInPlugin(RogueLibs.GUID, RogueLibs.Name, RogueLibs.CompiledVersion)]
	[BepInIncompatibility("abbysssal.streetsofrogue.ectd")]
	public sealed partial class RogueLibsPlugin : BaseUnityPlugin
	{
		public RoguePatcher Patcher;
		public void Awake()
		{
			Stopwatch sw = new Stopwatch();
			sw.Start();

			RogueFramework.Plugin = this;
			RogueFramework.Logger = Logger;

			Patcher = new RoguePatcher(this) { EnableStopwatch = true };

			PatchItems();
			PatchTraitsAndStatusEffects();
			PatchMisc();
			PatchUnlocks();
			PatchScrollingMenu();
			PatchCharacterCreation();
			PatchSprites();
			PatchAbilities();

			Patcher.LogResults();

			sw.Stop();
			Logger.LogDebug($"RogueLibs took {sw.ElapsedMilliseconds,5:#####} ms to load.");
		}
	}
}
