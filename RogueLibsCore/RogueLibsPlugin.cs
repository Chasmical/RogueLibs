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
	[BepInPlugin(RogueLibs.GUID, RogueLibs.Name, RogueLibs.Version)]
	public partial class RogueLibsPlugin : BaseUnityPlugin
	{
		public RoguePatcher Patcher;
		public void Awake()
		{
			RogueLibs.Plugin = this;
			RogueLibs.Logger = Logger;
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
