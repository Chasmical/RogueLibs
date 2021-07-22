# Inventory Checks

import Tabs from '@site/src/components/Tabs';
import TabItem from '@site/src/components/TabItem';
import useBaseUrl from '@docusaurus/useBaseUrl';

## `InventoryChecks` {#inventorychecks}

So, with inventory checks, you can omit code like this:

```csharp
if (Owner.statusEffects.hasTrait("BloodRestoresHealth"))
{
    Owner.SayDialogue("WontEatThis");
    return;
}
if (Owner.statusEffects.hasTrait("OilRestoresHealth"))
{
    Owner.SayDialogue("WontEatThat");
    return;
}
if (Owner.health == Owner.maxHealth)
{
    Owner.SayDialogue("NoImFull");
    return;
}
...
```

RogueLibs allows you to make **inventory checks**, that will work on all items in the game that meet a certain criteria (for example, have "Food" type and an "Alcohol" category). These inventory checks also implement some usual stuff, that modders sometimes forget to implement. For example, removing an item from the inventory or stopping the interaction, when the item's count reaches 0.

## Ignoring inventory checks {#ignoring-checks}

Inventory checks can be ignored by using an `IgnoreChecks` attribute.

You can put `IgnoreChecks` attributes on your item's class or on any of the interface methods.

```csharp
[ItemCategories(RogueCategories.Food, RogueCategories.Weird, "Meat")]
public class MysteryFood : CustomItem, IItemUsable
{
    // highlight-next-line
    [IgnoreChecks("VegetarianCheck")]
    public bool UseItem()
    {
        e.User.ChangeHealth(Item.healthChange);
        Count--;
        e.User.Say("Huh, tasty. I wonder what that was..."); // O_o
        return true;
    }
}
```

See the table of inventory checks implemented by RogueLibs [later on this page](#default-checks).

## Adding inventory checks {#adding-checks}

`RogueEventArgs` class has two properties: `Cancel` and `Handled`. If you set `Handled` to `true`, then all other checks will be skipped. If you set `Cancel` to `true`, then the action that was going to happen will not happen. Usually, they are set to `true` at the same time.

For example, there's a trait called `"Vegetarian"` that should prohibit the player from consuming food with `"Meat"` category:

```csharp
InventoryChecks.AddItemUsingCheck("VegetarianCheck", VegetarianCheck);
...
public static void VegetarianCheck(OnItemUsingArgs e)
{
    if (e.Item.itemType == ItemTypes.Food && e.User.HasTrait("Vegetarian") && e.Item.Categories.Contains("Meat"))
    {
        // do something to indicate why the item cannot be used
        e.User.gc.audioHandler.Play(e.User, "CantDo");
        e.User.SayDialogue("WontEatMeat");
        // set Cancel and Handled to true
        e.Cancel = e.Handled = true;
    }
};
```

If you want to override an inventory check from another mod, then you'll have to patch it with Harmony.

## Table of default checks {#default-checks}

### `IItemUsable` checks {#iitemusable-checks}

Name | Criteria | Dialogue
-----|----------|---------
`Ghost` | Player is a ghost. | -
`PeaBrained` | "Pea-Brained" trait, **NOT** Food type. | "GRRRRRRRR!!!!!"
`OnlyOil` | "Oil Reliant" trait, Food type and (Food or Alcohol category). | "I'm gonna need some oil..."
`OnlyOilMedicine` | "Oil Reliant" trait, Consumable type and Health category. | "I'm gonna need some oil..."
`OnlyBlood` | "Jugularious" trait, Food type and (Food or Alcohol category). | "Ew gross, I'm not putting that in my mouth!"
`OnlyBloodMedicine` | "Jugularious" trait, Consumable type and Health category. | "Modern medicine is for humans, I want BLOOD!"
`OnlyCharge` | "Electronic" trait, Food type and Food category. | "I don't exactly have a stomach."
`OnlyHumanFlesh` | "Strict Cannibal" trait, Food type and Food category. | "Ew gross, I'm not putting that in my mouth!"
`FullHealth` | Player's health is full and the item's `healthChange` is greater than 0. | "No need, I'm feelin' good!"

These checks are exposed via `DefaultInventoryChecks`. The rest are implemented inside RogueLibs' patches.

### `IItemCombinable` checks {#iitemcombinable-checks}

Name | Criteria | What will happen
-----|----------|-----------------
`AutoStacking` | Items have the same name | They will be highlighted, and once combined, they will be stacked together
`StopOnZero` | The current item's count is 0, or it's no longer in the inventory | Interaction/combining will be stopped

### `IItemTargetable` checks {#iitemtargetable-checks}

Name | Criteria | What will happen
-----|----------|-----------------
`Distance` | The target object is over 15 units away | `false`
`ButlerBot` | The target is a Butler Bot | `false`
`EmptyMech` | The target is an Empty Mech | `false`
`StopOnZero` | The current item's count is 0, or it's no longer in the inventory | Interaction/targeting will be stopped
