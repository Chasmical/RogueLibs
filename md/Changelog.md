## Contents ##

1. [Main page](https://github.com/Abbysssal/RogueLibs)
2. [RogueLibs](./RogueLibs.md)
3. [CustomNames](./CustomNames.md)
4. [CustomMutators](./CustomMutators.md)
5. [CustomItems](./CustomItems.md)
6. [CustomAbilities](./CustomAbilities.md)
7. [Extras](./Extras.md)
8. **RogueLibs Changelog**
9. [Mod Examples](./Examples.md)

## Changelog ##

#### RogueLibs v1.3.3 ####
* Optimized and cleaned up the code;
* Now RogueLibs will check if the combinable/targetable item was depleted after usage, so there is no need to check that at the end of `InvItem.TargetObject`/`InvItem.CombineItem`;

#### RogueLibs v1.3.2 ####
* RogueLibs source code is now available on [GitHub](https://github.com/Abbysssal/RogueLibs)!;
* Added `RogueUtilities.ConvertToSprite(string filePath, int ppu)` and `RogueUtilities.ConvertToSprite(byte[] data, int ppu)`, so you can specify your image's pixel-per-unit scale;

#### RogueLibs v1.3.1 ####
* Added `InvItem.CombineTooltip` delegate to determine the tooltip text when combining items;

#### RogueLibs v1.3 ####
* **Added `CustomItem` class, more info [here](./CustomItems.md)**;
* Added [Examples.md](./Examples.md) section;
* Added missing XML comments;

#### RogueLibs v1.2 ####
* Added `RogueUtilities.CrossConflict(params CustomMutator[] mutators)` method;
* Added `RogueUtilities.EachConflict(IEnumerable\<string\> conflicts, params CustomMutator[] mutators)` method;
* Added `CustomMutator.OnChangedState` event;
* Added `CustomMutator.SortingOrder` and `CustomMutator.SortingIndex` properties;
* Added a small class `RogueChat`, more info [here](./Extras.md#roguechat);
* Fixed a bug, when custom mutators replaced original mutators in the Mutator Menu;
* Fixed a bug, when `CustomMutator`'s `OnEnabled` and `OnDisabled` weren't triggered;

#### RogueLibs v1.1.2 ####
* Fixed configuration loading errors;

#### RogueLibs v1.1 ####
* **Renamed `Mutator` class to `CustomMutator`!**;
* **Removed `MutatorInfo` class, use `CustomNameInfo` instead!**;
* **Removed `Mutator.Cancellations` and `CancelledBy`, use `Conflicting` instead!**;
* **Removed `SetMutator(id, unlocked, english,..)`, use `SetMutator(id, unlocked, name, description)` instead!**;
* **Removed `SetCustomName(id, type, english,..)`, use `SetCustomName(id, type, info)` instead!**;
* **Removed `GetCustomName(id)`, use `GetCustomName(id, type)` instead!**;
* **Removed `DeleteCustomName(id)`, use `DeleteCustomName(id, type)` instead!**;
* `CustomNameInfo` is now a `struct`;
* Changed some configuration loading code;
* Added class `RoguePatcher`, more info [here](./Extras.md#roguepatcher);
* Added static class `RogueUtilities`, more info [here](./Extras.md#rogueutilities);

#### RogueLibs v1.0.1 ####
* Fixed a bug, when deleted mods' mutators were showing in the Mutator Menu;

#### RogueLibs v1.0 ####
* **Added `Mutator` and `CustomName` classes and some extra functions.**