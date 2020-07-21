using BepInEx;
using BepInEx.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace RogueLibsCore
{
#pragma warning disable CS1591
	[BepInPlugin(RogueLibs.pluginGuid, RogueLibs.pluginName, RogueLibs.pluginVersion)]
	public class RogueLibsPlugin : BaseUnityPlugin
	{
		protected static ManualLogSource MyLogger;

		protected void Awake()
		{
			RogueLibs.PluginInstance = this;
			

		}




	}
#pragma warning restore CS1591
}
