using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using UnityEngine;
using RogueLibsCore;
using HarmonyLib;

namespace DebugPlugin
{
	[BepInPlugin(pluginGUID, pluginName, pluginVersion)]
	[BepInDependency(RogueLibs.GUID, RogueLibs.CompiledVersion)]
	public class DebugPlugin : BaseUnityPlugin
	{
		public const string pluginGUID = "abbysssal.streetsofrogue.debugplugin";
		public const string pluginName = "Debug Plugin";
		public const string pluginVersion = "0.1.0";

		private static bool started;

		public void Awake()
		{
			RoguePatcher patcher = new RoguePatcher(this);
			patcher.Prefix(typeof(GameController), "Awake");
			patcher.Prefix(typeof(GameController), "RealStart");
			patcher.Postfix(typeof(MenuGUI), "Start");
			patcher.Finalizer(typeof(MenuGUI), nameof(MenuGUI.CloseDailyRunScreen));
		}
		public static void GameController_Awake(GameController __instance)
		{
			__instance.logoAnimationOn = false;
		}
		public static void GameController_RealStart(GameController __instance)
		{
			__instance.menuGUI.enabled = true;
			__instance.menuGUI.gameObject.SetActive(true);
			__instance.mainGUI.enabled = true;
			__instance.mainGUI.gameObject.SetActive(true);
		}
		public static void MenuGUI_Start(MenuGUI __instance)
		{
			if (!started)
			{
				StartGame();
				started = true;
			}
		}
		private static void StartGame()
		{
			MenuGUI m = GameController.gameController.menuGUI;
			Traverse tr = new Traverse(m);
			GameController gc = tr.Field("gc").GetValue<GameController>();
			gc.sessionDataBig.dailyRun = true;
			gc.sessionDataBig.dailyRunDate = DateTime.UtcNow.ToString("yyyy/MM/dd HH:mm:ss.fffffff");
			gc.sessionDataBig.dailyRunSeed = gc.sessionDataBig.dailyRunDate;
			gc.sessionDataBig.newCharacter = "Courier";
			gc.sessionDataBig.dailyRunInitialCharacter = "Courier";

			gc.challenges.Add("Sandbox");
			gc.originalChallenges.Add("Sandbox");
			gc.sessionDataBig.challenges = gc.challenges;
			gc.sessionDataBig.originalChallenges = gc.originalChallenges;
			gc.loadLevel.waitingForCompletedRebuildChangedObjectsOverTime = true;
			gc.SetDailyRunText();
			m.PressedStartGame(1);
		}
		public static Exception MenuGUI_CloseDailyRunScreen() => null;
	}
}
