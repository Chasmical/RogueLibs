using System;
using BepInEx;
using BepInEx.Logging;

namespace RogueLibsCore.Interactions
{
	[BepInPlugin(RogueLibsInteractions.pluginGuid, RogueLibsInteractions.pluginName, RogueLibsInteractions.pluginVersion)]
	[BepInDependency(RogueLibs.pluginGuid, RogueLibsInteractions.pluginVersion)]
	public partial class RogueLibsInteractionsPlugin : BaseUnityPlugin
	{
		protected static ManualLogSource MyLogger;

		public void Awake()
		{
			RogueLibsInteractions.PluginInstance = this;
			RogueLibsInteractions.Logger = MyLogger = Logger;

			RoguePatcher patcher = new RoguePatcher(this, GetType());

			new AirConditionerInteraction().Patch();
			new AlarmButtonInteraction().Patch();
			new BarbecueInteraction().Patch();

			



		}

	}
}
