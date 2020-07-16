## Contents ##

1. [Main page](https://github.com/Abbysssal/RogueLibs)
2. [RogueLibs](./RogueLibs.md)
3. [CustomMutators](./CustomMutators.md)
4. [CustomItems](./CustomItems.md)
5. [CustomNames](./CustomNames.md)
6. [Extras](./Extras.md)
7. [RogueLibs Changelog](./Changelog.md)
8. **Mod Examples**

## Rocket Bullets Mutator ##
```cs
using System;
using BepInEx;
using RogueLibsCore;

namespace RogueLibsCore.Examples
{
    [BepInPlugin(pluginGuid, pluginName, pluginVersion)]
    [BepInDependency(RogueLibs.pluginGuid, "1.1")]
    public class Example1 : BaseUnityPlugin
    {
        public const string pluginGuid = "abbysssal.streetsofrogue.example1";
        public const string pluginName = "Rocket Bullets Mutators";
        public const string pluginVersion = "1.0";

        public static CustomMutator RocketBullets { get; set; }

        protected void Awake()
        {
            RocketBullets = RogueLibs.SetMutator("RocketBullets", true,
                new CustomNameInfo("Rocket Bullets"),
                new CustomNameInfo("Replaces all bullets with rockets. Rate of fire is unchanged."));

            RocketBullets.AddConflicting("RocketLaunchers", "NoGuns");

            this.PatchPrefix(typeof(Gun), "spawnBullet", GetType(), "Gun_spawnBullet", new Type[] { typeof(bulletStatus), typeof(InvItem), typeof(int), typeof(bool), typeof(string) });
        }
        protected static void Gun_spawnBullet(ref bulletStatus bulletType)
        {
            if (RocketBullets.IsActive)
                bulletType = bulletStatus.Rocket;
        }
    }
}
```
## Example Items used in CustomItems.md ##
```cs
using System;
using BepInEx;
using RogueLibsCore;
using UnityEngine;

namespace RogueLibsCore.Examples
{
    [BepInPlugin(pluginGuid, pluginName, pluginVersion)]
    [BepInDependency(RogueLibs.pluginGuid, "1.3")]
    public class Example2 : BaseUnityPlugin
    {
        public const string pluginGuid = "abbysssal.streetsofrogue.example2";
        public const string pluginName = "Example Items";
        public const string pluginVersion = "1.0";

        public void Awake()
        {
            Sprite sprite = RogueUtilities.ConvertToSprite(Properties.Resources.MoneyContainer);
            CustomItem moneyContainer = RogueLibs.SetItem("money-container", sprite,
                new CustomNameInfo("Money Container"),
                new CustomNameInfo("Gives you some money."),
                item =>
                {
                    item.itemType = "Consumable";
                    item.Categories.Add("Technology");
                    item.itemValue = 20;
                    item.initCount = 2;
                    item.rewardCount = 4;
                    item.stackable = true;
                    item.goesInToolbar = true;
                    item.cantBeCloned = true;
                });
            
            moneyContainer.UseItem = (item, agent) =>
            {
                agent.inventory.AddItem("Money", UnityEngine.Random.Range(5, 40));
                item.database.SubtractFromItemCount(item, 1);
                new ItemFunctions().UseItemAnim(item, agent);
            };
            moneyContainer.AddSpawnList("DrugDealerSpecialInv", 10);
            moneyContainer.AddSpawnList("BartenderSpecialInv", 10);



            Sprite sprite2 = RogueUtilities.ConvertToSprite(Properties.Resources.RemoteGiantizer);
            CustomItem remoteGiantizer = RogueLibs.SetItem("remote-giantizer", sprite2,
                new CustomNameInfo("Remote Giantizer"),
                new CustomNameInfo("Turns someone into a giant. Permanently. Yeah, I know, it's OP, because you can target yourself or your companions."),
                item =>
                {
                    item.itemType = "Tool";
                    item.Categories.Add("Technology");
                    item.Categories.Add("Usable");
                    item.itemValue = 20;
                    item.initCount = 3;
                    item.rewardCount = 5;
                    item.stackable = true;
                    item.goesInToolbar = true;
                });
            remoteGiantizer.TargetFilter = (item, agent, obj) => obj is Agent a && !a.dead;
            remoteGiantizer.TargetObject = (item, agent, obj) =>
            {
                item.invInterface.HideTarget();

                Agent a = (Agent)obj;
                a.statusEffects.AddStatusEffect("Giant", true, true, 999999);
                item.database.SubtractFromItemCount(item, 1);
            };
            remoteGiantizer.SetHoverText(new CustomNameInfo("g14nt1ze"));

            remoteGiantizer.AddSpawnList("DrugDealerSpecialInv", 10);
            remoteGiantizer.AddSpawnList("BartenderSpecialInv", 10);



            Sprite sprite3 = RogueUtilities.ConvertToSprite(Properties.Resources.Repairer);
            CustomItem repairer = RogueLibs.SetItem("repairer", sprite3,
                new CustomNameInfo("Repairer"),
                new CustomNameInfo("Repairs your melee weapons. Has limited uses."),
                item =>
                {
                    item.itemType = "Combine";
                    item.Categories.Add("Technology");
                    item.itemValue = 4;
                    item.hasCharges = true;
                    item.stackable = true;
                    item.initCount = 20;
                    item.rewardCount = 20;

                });
            repairer.CombineFilter = (item, agent, otherItem) => otherItem.itemType == "WeaponMelee" && otherItem.invItemCount < otherItem.rewardCount;
            repairer.CombineItem = (item, agent, otherItem, slotNum) =>
            {
                otherItem.invItemCount += UnityEngine.Random.Range(30, 50);
                if (otherItem.invItemCount > otherItem.rewardCount)
                    otherItem.invItemCount = otherItem.rewardCount;

                if (!item.gc.challenges.Contains("NoLimits"))
                    agent.agentInvDatabase.SubtractFromItemCount(item, 1);
                    
                item.gc.audioHandler.Play(agent, "CombineItem");
            };
            repairer.CombineTooltip = (item, agent, otherItem) =>
            {
                int needRepair = otherItem.rewardCount - otherItem.invItemCount;
                if (needRepair == 0) return null;
                // the weapon doesn't need repair - do not add tooltip
                int lower = Mathf.Min(needRepair, 30);
                int upper = Mathf.Min(needRepair, 50);
                if (lower == upper) return "+" + lower.ToString();
                return "+" + lower.ToString() + "-" + upper.ToString();
                // returns a range of possible repair values
            }
            repairer.AddSpawnList("DrugDealerSpecialInv", 10);
            repairer.AddSpawnList("BartenderSpecialInv", 10);
        }
    }
}
```