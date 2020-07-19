## Contents ##

1. [Main page](https://github.com/Abbysssal/RogueLibs)
2. [RogueLibs](./RogueLibs.md)
3. [CustomNames](./CustomNames.md)
4. [CustomMutators](./CustomMutators.md)
5. [CustomItems](./CustomItems.md)
6. **CustomAbilities**
7. [Extras](./Extras.md)
8. [RogueLibs Changelog](./Changelog.md)
9. [Mod Examples](./Examples.md)

## Creating CustomAbilities ##
```cs
public static CustomAbility SetAbility(CustomItem item);
```
```cs
CustomItem item = RogueLibs.SetItem(..., item =>
{
    // don't put anything here if your ability doesn't recharge

    item.lowCountThreshold = 200; // item count text will be red if below this amount
    item.initCount = 0; // ability is recharged from start
    item.stackable = true;
});
CustomAbility ability = RogueLibs.SetAbility(item);
// the ability is basically a usable item in the inventory,
// so you have to make a CustomItem first, and then make CustomAbility
```
## Deleting CustomAbilities ##
```cs
public static bool DeleteAbility(string id);
public static bool DeleteAbility(CustomAbility customAbility);
```
You probably won't need these, but I added them just in case you need them for some reason.
## Properties ##

## Using CustomAbilities ##
You can get your CustomAbility's CustomItem:
```cs
public CustomItem Item { get; }
```
You can get your CustomAbility's Id:
```cs
public string Id { get; set; }
```
You can get/set your CustomAbility's Sprite:
```cs
public Sprite Sprite { get; set; }
```
You can get/set your CustomAbility's Name and Description:
```cs
public CustomName Name { get; set; }
public CustomName Description { get; set; }
```
## Chargeable Abilities ##
```cs
public Action<InvItem, Agent> OnPressed { get; set; }
public Action<InvItem, Agent> OnHeld { get; set; }
public Action<InvItem, Agent> OnReleased { get; set; }
```
```cs
CustomItem cItem = RogueLibs.SetItem(...);
CustomAbility regeneration = RogueLibs.SetAbility(cItem);

regeneration.OnPressed = (item, agent)
    => item.invItemCount = 1;
    // see StatusEffects.PressedSpecialAbility() for more info
regeneration.OnHeld = (item, agent) =>
{
    if (agent.gc.playerControl.pressedSpecialAbilityTime[agent.isPlayer - 1] * 2f > item.invItemCount)
    {
        if (item.invItemCount < 10)
            item.invItemCount++;
        // each half second the item count is incremented
    }
    // see StatusEffects.HeldSpecialAbility() for more info
};
regeneration.OnReleased = (item, agent) =>
{
    agent.statusEffects.ChangeHealth(item.invItemCount);
    item.invItemCount = 0;
    agent.gc.audioHandler.Play(agent, "Heal");

    // see StatusEffects.ReleasedSpecialAbility() for more info
};
```
## Rechargeable CustomAbilities ##
```cs
public Func<Agent, InvItem, WaitForSeconds> RechargePeriod { get; set; }
public Action<Agent, InvItem> Recharge { get; set; }
```
```cs
CustomItem cItem = RogueLibs.SetItem(...);
CustomAbility giantAbility = RogueLibs.SetAbility(cItem);

giantAbility.OnPressed = (item, agent) =>
{
    if (item.invItemCount > 0) // is recharging
        agent.gc.audioHandler.Play(agent, "CantDo");
    else
    {
        agent.statusEffects.AddStatusEffect("Giant", true, true, 3);
        agent.inventory.buffDisplay.specialAbilitySlot.MakeNotUsable();
        // make special ability slot half-transparent
        item.invItemCount = 100; // 100 x 0.13f = 13 seconds to recharge
        // or you can replace 100 with 13, and 0.13 with 1 to make it simpler
    }
};

giantAbility.RechargePeriod = (item, agent)
    => item.invItemCount > 0 ? new WaitForSeconds(0.13f) : null;

giantAbility.Recharge = (item, agent) =>
{
    if (item.invItemCount > 0 && agent.statusEffects.CanRecharge())
    { // if can recharge
        item.invItemCount--;
        if (item.invItemCount == 0) // ability recharged
        {
            agent.statusEffects.CreateBuffText("Recharged", agent.objectNetID);
            agent.gc.audioHandler.Play(agent, "Recharge");
            agent.inventory.buffDisplay.specialAbilitySlot.MakeUsable();
            // make special ability slot fully visible
        }
    }
};
```
## Targetable CustomAbilities ##
```cs
public Action<InvItem, Agent> InterfaceCheck { get; set; }
```
```cs
CustomItem cItem = RogueLibs.SetItem(...);
CustomAbility silentKill = RogueLibs.SetAbility(cItem);

// you will need to write a function to determine the target object;
// for more info, see StatusEffects.FindSpecialAbilityObject()
Func<InvItem, Agent, PlayfieldObject> FindTarget = ...

silentKill.InterfaceCheck = (item, agent) =>
{
    Agent target = (Agent)FindTarget(item, agent);
    if (target != null && item.invItemCount == 0 && agent.statusEffects.CanShowSpecialAbilityIndicator())
        agent.specialAbilityIndicator.ShowIndicator(target, item.invItemName);
    else
        agent.specialAbilityIndicator.Revert();
};
silentKill.OnPressed = (item, agent) =>
{
    Agent target = (Agent)FindTarget(item, agent);
    if (target != null && item.invItemCount == 0)
    {
        target.statusEffects.ChangeHealth(-200f, null);
        item.invItemCount = 10;
    }
    else
        agent.gc.audioHandler.Play(agent, "CantDo");
};

// Don't forget to do RechargePeriod and Recharge functions too
```






