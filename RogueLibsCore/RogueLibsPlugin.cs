using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using BepInEx;
using HarmonyLib;
using System.IO;
using System.Threading;

namespace RogueLibsCore
{
	[BepInPlugin(RogueLibs.GUID, RogueLibs.Name, RogueLibs.CompiledVersion)]
	[BepInIncompatibility("abbysssal.streetsofrogue.ectd")]
	[BepInIncompatibility("abbysssal.streetsofrogue.roguelibs")]
	internal sealed partial class RogueLibsPlugin : BaseUnityPlugin
	{
		public RoguePatcher Patcher;

		private static int awoken;
		public void Awake()
		{
			if (Interlocked.Exchange(ref awoken, 1) == 1)
			{
				Logger.LogError("A second instance of RogueLibs was awaken, so it was terminated immediately.");
				return;
			}
			Logger.LogInfo($"Running RogueLibs v{RogueLibs.CompiledSemanticVersion}.");
			Stopwatch sw = new Stopwatch();
			sw.Start();

			RogueFramework.Plugin = this;
			RogueFramework.Logger = Logger;

			Patcher = new RoguePatcher(this);
#if DEBUG
			Patcher.EnableStopwatch = true;
#endif
			PatchAbilities();
			PatchCharacterCreation();
			PatchItems();
			PatchMisc();
			PatchScrollingMenu();
			PatchSprites();
			PatchTraitsAndStatusEffects();
			PatchUnlocks();
#if DEBUG
			Patcher.SortResults();
			Patcher.LogResults();
#endif
			sw.Stop();
			Logger.LogDebug($"RogueLibs took {sw.ElapsedMilliseconds,5:#####} ms to load.");
		}
	}
}
