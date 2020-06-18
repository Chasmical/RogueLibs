## [Contents](https://github.com/Abbysssal/RogueLibs) ##

1. [Main page](https://github.com/Abbysssal/RogueLibs/blob/master/README.md)
2. [RogueLibs](https://github.com/Abbysssal/RogueLibs/blob/master/RogueLibs.md)
3. [CustomMutators](https://github.com/Abbysssal/RogueLibs/blob/master/CustomMutators.md)
4. [CustomNames](https://github.com/Abbysssal/RogueLibs/blob/master/CustomNames.md)
5. [Extras](https://github.com/Abbysssal/RogueLibs/blob/master/Extras.md)
6. **RogueLibs Changelog**

## Changelog ##
Here you will find all updates on RogueLibs, so you can specify your RogueLibs' version dependency better.

#### RogueLibs v1.2 ####
* Added RogueUtilities.CrossConflict(params CustomMutator[] mutators) method;
* Added RogueUtilities.EachConflict(IEnumerable<string> conflicts, params CustomMutator[] mutators) method;
* Added CustomMutator.OnChangedState event;
* Added CustomMutator.SortingOrder and CustomMutator.SortingIndex properties;
* Added a small class RogueChat, more info [here](https://github.com/Abbysssal/RogueLibs/blob/master/Extras.md#roguechat);
* Fixed a bug, when custom mutators replaced original mutators in the Mutator Menu;
* Fixed a bug, when OnEnabled and OnDisabled weren't triggered;

#### RogueLibs v1.1.2 ####
* Fixed configuration loading errors;

#### RogueLibs v1.1 ####
* **Renamed Mutator class to CustomMutator!**;
* **Removed MutatorInfo class, use CustomNameInfo instead!**;
* **Removed Mutator.Cancellations and CancelledBy, use Conflicting instead!**;
* **Removed SetMutator(id, unlocked, english,..), use SetMutator(id, unlocked, name, description) instead!**;
* **Removed SetCustomName(id, type, english,..), use SetCustomName(id, type, info) instead!**;
* **Removed GetCustomName(id), use GetCustomName(id, type) instead!**;
* **Removed DeleteCustomName(id), use DeleteCustomName(id, type) instead!**;
* CustomNameInfo is now a struct;
* Changed some configuration loading code;
* Added class RoguePatcher, more info [here](https://github.com/Abbysssal/RogueLibs/blob/master/Extras.md#roguepatcher);
* Added static class RogueUtilities, more info [here](https://github.com/Abbysssal/RogueLibs/blob/master/Extras.md#rogueutilities);

#### RogueLibs v1.0.1 ####
* Fixed a bug, when deleted mods' mutators were showing in the Mutator Menu;

#### RogueLibs v1.0 ####
* Added Mutator and CustomName classes and some extra functions.