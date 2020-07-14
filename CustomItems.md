## [Contents](https://github.com/Abbysssal/RogueLibs) ##

1. [Main page](/README.md)
2. [RogueLibs](/RogueLibs.md)
3. [CustomMutators](/CustomMutators.md)
4. **CustomItems**
5. [CustomNames](/CustomNames.md)
6. [Extras](/Extras.md)
7. [RogueLibs Changelog](/Changelog.md)
8. [Mod Examples](/Examples.md)

## Creating CustomItems ##
```cs
public static CustomItem SetItem(string id, Sprite sprite, CustomNameInfo name, CustomNameInfo description, Action<InvItem> setupDetails);
```
```cs
// Creating a sprite from byte[] (.png image)
Sprite sprite = RogueUtilities.ConvertToSprite(Properties.Resources.MoneyContainer);

CustomItem moneyContainer = RogueLibs.SetItem("money-container", sprite,
    new CustomNameInfo("Money Container"),
    new CustomNameInfo("Gives you some money."),
    item =>
    { // See InvItem.SetupDetails() for more info
        item.itemType = "Consumable";
        item.Categories.Add("Technology");
        item.itemValue = 20;
        item.initCount = 10;
        item.rewardCount = 10;
        item.stackable = true;
        item.goesInToolbar = true;
        item.cantBeCloned = true;
        // item.LoadItemSprite("my-item"); - RogueLibs loads the sprite automatically
    });
```
## Deleting CustomItems ##
```cs
public static bool DeleteItem(string id);
public static bool DeleteItem(CustomItem customItem);
```
You probably won't need these.
## Properties ##
You can get your CustomItem's Id:
```cs
public string Id { get; }
```
You can get/set your CustomItem's SetupDetails delegate:
```cs
public Action<InvItem> SetupDetails { get; set; }
```
You can get/set your CustomItem's Sprite:
```cs
public Sprite Sprite { get; set; }
```
And your CustomItem's Name and Description:
```cs
public CustomName Name { get; set; }
public CustomName Description { get; set; }
```
## Making Consumable Items ##
```cs
public Action<InvItem, Agent> UseItem { get; set; }
```
```cs
CustomItem moneyContainer = RogueLibs.SetItem(...);

moneyContainer.UseItem = (item, agent) =>
{
    agent.inventory.AddItem("Money", UnityEngine.Random.Range(5, 40));
    item.database.SubtractFromItemCount(item, 1);
    new ItemFunctions().UseItemAnim(item, agent);
};
```
## Making Combinable Items ##
```cs
public Func<InvItem, Agent, InvItem, bool> CombineFilter { get; set; }
public Action<InvItem, Agent, InvItem, int> CombineItem { get; set; }
```
```cs
CustomItem repairer = RogueLibs.SetItem(...);

repairer.CombineFilter = (item, agent, otherItem) => otherItem.itemType == "WeaponMelee" && otherItem.invItemCount < otherItem.rewardCount;
// Item can be repaired only if it is a melee weapon and has less than 200 (default) durability

repairer.CombineItem = (item, agent, otherItem, slotNum) =>
{
    otherItem.invItemCount += UnityEngine.Random.Range(30, 50); // Repair by a random amount
    if (otherItem.invItemCount > otherItem.rewardCount)
        otherItem.invItemCount = otherItem.rewardCount;

    if (!item.gc.challenges.Contains("NoLimits"))
        agent.agentInvDatabase.SubtractFromItemCount(item, 1);

    item.gc.audioHandler.Play(agent, "CombineItem");

    if (item.invItemCount < 1) // Stop combining if the repairer has 0 uses left
    {
        agent.mainGUI.invInterface.HideDraggedItem();
        agent.mainGUI.invInterface.HideTarget();
    }
};
```
## Making Targeting Items ##
```cs
public Func<InvItem, Agent, PlayfieldObject, bool> TargetFilter { get; set; }
public Action<InvItem, Agent, PlayfieldObject> TargetObject { get; set; }
```
```cs
public CustomName HoverText { get; set; }
public void SetHoverText(CustomNameInfo info);
```
```cs
CustomItem remoteGiantizer = RogueLibs.SetItem(...);

remoteGiantizer.TargetFilter = (item, agent, target) => target is Agent a && !a.dead;
// Object can be targeted only if it is an Agent and is not dead

remoteGiantizer.TargetObject = (item, agent, target) =>
{
    item.invInterface.HideTarget();

    Agent a = (Agent)target;
    a.statusEffects.AddStatusEffect("Giant", true, true, 999999);
    item.database.SubtractFromItemCount(item, 1);
}

remoteGiantizer.SetHoverText(new CustomNameInfo("Giantize!"));
```
## Making Items Spawnable ##
```cs
public Dictionary<string, int> SpawnDictionary { get; set; }
public void AddSpawnList(string listName, int spawnChance);
```
```cs
CustomItem vodka = RogueLibs.SetItem(...);

vodka.AddSpawnList("Alcohol2", 3);
vodka.AddSpawnList("DefaultChallenge", 3);

// For more info, see RandomItems.fillItems()
```
Or, you can edit SpawnDictionary directly:
```cs
CustomItem vodka = RogueLibs.SetItem(...);

vodka.SpawnDictionary.Add("Alcohol2", 3);
vodka.SpawnDictionary.Add("DefaultChallenge", 1);
```
You can also use [ECTD (Edit Characters Through Description)](https://github.com/Abbysssal/ECTD) mod to quickly test your items, just type `++<Your Item ID>` in your custom character's description.