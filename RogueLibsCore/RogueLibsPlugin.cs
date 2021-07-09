﻿using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using BepInEx;
using HarmonyLib;
using System.IO;

namespace RogueLibsCore
{
	[BepInPlugin(RogueLibs.GUID, RogueLibs.Name, RogueLibs.CompiledVersion)]
	[BepInIncompatibility("abbysssal.streetsofrogue.ectd")]
	public sealed partial class RogueLibsPlugin : BaseUnityPlugin
	{
		public RoguePatcher Patcher;
		public void Awake()
		{
			Logger.LogInfo($"Running RogueLibs v{RogueLibs.CompiledSemanticVersion}.");
			Stopwatch sw = new Stopwatch();
			sw.Start();

			RogueFramework.Plugin = this;
			RogueFramework.Logger = Logger;

			RogueLibs.audioCachePath = Path.Combine(Paths.CachePath, "RogueLibs Audio");
			Directory.CreateDirectory(RogueLibs.audioCachePath);
			foreach (string file in Directory.EnumerateFiles(RogueLibs.audioCachePath))
				File.Delete(file);
			foreach (string directory in Directory.EnumerateDirectories(RogueLibs.audioCachePath))
				Directory.Delete(directory, true);

			Patcher = new RoguePatcher(this) { EnableStopwatch = true };

			PatchItems();
			PatchTraitsAndStatusEffects();
			PatchMisc();
			PatchUnlocks();
			PatchScrollingMenu();
			PatchCharacterCreation();
			PatchSprites();
			PatchAbilities();

#if DEBUG
			Patcher.LogResults();
#endif

			sw.Stop();
			Logger.LogDebug($"RogueLibs took {sw.ElapsedMilliseconds,5:#####} ms to load.");
		}
	}
}