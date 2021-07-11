using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace RogueLibsCore.Test
{
	public class Duplicator : CustomItem, IItemTargetable
	{
		public static void Test()
		{
			RogueLibs.CreateCustomItem<Duplicator>()
				.WithName(new CustomNameInfo("Duplicator"))
				.WithDescription(new CustomNameInfo("Duplicates anything. Yep, definitely overpowered."))
				.WithSprite(Properties.Resources.Duplicator)
				.WithUnlock(new ItemUnlock { UnlockCost = 10, CharacterCreationCost = 5, LoadoutCost = 5 });
			RogueLibs.CreateCustomName("Duplicate", "Interface", new CustomNameInfo("Duplicate"));
		}

		public override void SetupDetails()
		{
			Item.itemType = ItemTypes.Tool;
			Item.itemValue = 50;
			Item.initCount = 2;
			Item.rewardCount = 3;
			Item.stackable = true;
			Item.goesInToolbar = true;
			Item.cantBeCloned = true;
		}
		public bool TargetFilter(PlayfieldObject obj) => obj is Agent agent && !agent.mechFilled
			|| obj is ObjectReal || obj is Item item && !item.invItem.cantBeCloned;
		public bool TargetObject(PlayfieldObject obj)
		{
			if (!TargetFilter(obj)) return false;

			Vector2 offset = UnityEngine.Random.insideUnitCircle;
			PlayfieldObject cloneObj = null;
			if (obj is Agent agent)
			{
				Agent clone = gc.spawnerMain.SpawnAgent(agent.curPosition + offset, null, agent.agentName, string.Empty, agent);
				cloneObj = clone;
				clone.clonedAgent = true;
				clone.relationships.CopyRelationships(agent);
				clone.relationships.CopyImportantStats(agent);
				clone.relationships.CopyLooks(agent);
				clone.relationships.CopySpecialInvDatabase(agent);
				// clone.agentHitboxScript.UpdateAnim();
				// clone.agentHitboxScript.MustRefresh();
			}
			else if (obj is ObjectReal objectReal)
			{
				cloneObj = gc.spawnerMain.spawnObjectReal(objectReal.curPosition + offset, null, objectReal.objectName);
			}
			else if (obj is Item item)
			{
				InvItem copy = (InvItem)memberwiseCloneMethod.Invoke(item.invItem, new object[0]);
				cloneObj = gc.spawnerMain.SpawnItem(item.curPosition + offset, copy);
			}

			Count--;
			gc.audioHandler.Play(Owner, "Spawn");
			gc.audioHandler.Play(cloneObj, "Spawn");
			gc.spawnerMain.SpawnParticleEffect("Spawn", cloneObj.curPosition, 0f);

			return true;
		}
		private static readonly MethodInfo memberwiseCloneMethod = typeof(object).GetMethod(nameof(MemberwiseClone),
			BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
		public CustomTooltip TargetCursorText(PlayfieldObject obj) => gc.nameDB.GetName("Duplicate", "Interface");
	}
}
