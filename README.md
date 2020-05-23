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
You can make mutators, that will automatically disable other mutators:
```cs
// void AddConflicting(params string[] conflictingMutators)
// void AddConflicting(params Mutator[] conflictingMutators)
mutator1.AddConflicting(mutator2, mutator3);
mutator2.AddConflicting(mutator3.Id, "GorillaTown");

// This way these mutators will cancel each other.
```
You can also remove these conflicts:
```cs
// void RemoveConflicting(params string[] conflictingMutators)
// void RemoveConflicting(params Mutator[] conflictingMutators)

```
