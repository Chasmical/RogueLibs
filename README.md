# RogueLibs
This modding library allows you to easily add custom mutators and localization lines.

## Mutators ##
To create a mutator use one of the following methods:
```cs
// Mutator SetMutator(string id, bool unlockedInitially, CustomNameInfo name, CustomNameInfo description)
Mutator mutator = RogueLibs.SetMutator("MyMutatorId", true, name, description);

// Mutator SetMutator(string id, bool unlockedInitially, MutatorInfo english, MutatorInfo schinese = null, MutatorInfo german = null, MutatorInfo spanish = null, MutatorInfo brazilian = null, MutatorInfo russian = null, MutatorInfo french = null, MutatorInfo koreana = null)
Mutator mutator = RogueLibs.SetMutator("MyMutatorId", false,
    new MutatorInfo("English Name", "English Description"), // English
    null, // Simplified Chinese
    new MutatorInfo("Translated", "strings"), // German
    null, // Spanish
    null, // Brazilian
    new MutatorInfo("name", "description"), // Russian
    null, // French
    null); // Korean
```
You can get a custom mutator by its Id:
```cs
// Mutator GetMutator(string id);
Mutator mutator = RogueLibs.GetMutator("MyMutatorId");
```
You can do some stuff with Mutator class:
```cs
bool active = mutator.IsActive; // returns true if this mutator is enabled (can be set)
bool unlocked = mutator.Unlocked; // returns true if this mutator is enabled (can be set)
// You can set your mutator to be locked, and then unlock it.
// RogueLibs will save its unlock status and load it the next time.

mutator.ShowInMenu = false; // This property determines whether the mutator will be shown in Mutator Menu

CustomName name = mutator.Name; // You can access CustomNames of the mutator
CustomName desc = mutator.Description;

mutator.OnEnabled += DoSomething(); // Mutators also have 2 events
mutator.OnDisabled += DoSomething2();
```
You can make mutators, that will automatically disable other mutators. It is useful when you have, for example, mutator "Rocket Bullets" and don't want it to be enabled, when there's a mutator "No Guns".
```cs
// void AddConflicting(params string[] conflictingMutators)
// void AddConflicting(params Mutator[] conflictingMutators)
mutator1.AddConflicting(mutator2, mutator3);
mutator2.AddConflicting(mutator3.Id, "GorillaTown");

// if you enable mutator1, mutator2 and mutator3 will be disabled.
// if you enable mutator3, mutator1 and mutator2 will be disabled.
```
You can also remove these conflicts:
```cs
// void RemoveConflicting(params string[] conflictingMutators)
// void RemoveConflicting(params Mutator[] conflictingMutators)
```
It is also possible to make one mutator cancel another mutator, but not be cancelled by them:
```cs
// void AddCancellations(params string[] cancellations)  / void RemoveCancellations(params string[] cancellations)
// void AddCancellations(params Mutator[] cancellations) / void RemoveCancellations(params Mutator[] cancellations)
mutator1.AddCancellations(mutator2);

// if you enable mutator1, mutator2 will be disabled.
// if you enable mutator2, mutator1 WON'T be disabled.
```
```cs
// void AddCancelledBy(params string[] cancelledBy)  / void RemoveCancelledBy(params string[] cancelledBy)
// void AddCancelledBy(params Mutator[] cancelledBy) / void RemoveCancelledBy(params Mutator[] cancelledBy)
mutator1.AddCancelledBy(mutator2);

// if you enable mutator1, mutator2 WON'T be disabled.
// if you enable mutator2, mutator1 will be disabled.
```
You can delete your custom mutators (I have no idea why would you want to do that):
```cs
// bool DeleteMutator(Mutator mutator) / bool DeleteMutator(string id)
```
## Custom Names ##
You can create your own custom localization strings:
```cs

```
