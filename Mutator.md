### Contents ###

## Creating a Mutator ##
```cs
public static Mutator SetMutator(string id, bool unlockedInitially, CustomNameInfo name, CustomNameInfo description);
```
```cs
Mutator myMutator = RogueLibs.SetMutator("RocketBullets", true,
    new CustomNameInfo("english name", "schinese", null, null, null, null, null, null),
	new CustomNameInfo("description", null, null, null, null, null, null, null));

// null strings will default to english.
// After doing that your mutator will appear in Mutator Menu at Home Base.
```
```cs
public static Mutator SetMutator(string id, bool unlockedInitially, MutatorInfo english, MutatorInfo schinese = null, MutatorInfo german = null, MutatorInfo spanish = null, MutatorInfo brazilian = null, MutatorInfo russian = null, MutatorInfo french = null, MutatorInfo koreana = null);
```
```cs
Mutator myMutator2 = RogueLibs.SetMutator("RocketBullets2", false,
    new MutatorInfo("english name", "english description"),
	new MutatorInfo("schinese", null),
	null,
	null,
	new MutatorInfo(),
	null,
	null,
	null);

// null strings will default to english.
// After doing that your mutator will appear in Mutator Menu at Home Base.
```