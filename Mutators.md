## [Contents](https://github.com/Abbysssal/RogueLibs) ##

1. [Main page](https://github.com/Abbysssal/RogueLibs/blob/master/README.md)
2. [RogueLibs](https://github.com/Abbysssal/RogueLibs/blob/master/RogueLibs.md)
3. **Mutators**
4. [CustomNames](https://github.com/Abbysssal/RogueLibs/blob/master/CustomNames.md)

## Creating Mutators ##
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
Mutator myMutator2 = RogueLibs.SetMutator("WaterBullets", false,
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
## Deleting Mutators ##
You can delete your custom Mutators:
```cs
public static bool DeleteMutator(Mutator mutator);
public static bool DeleteMutator(string id);
```
You can use these in case you rename your mutator:
```cs
Mutator newMutator = RogueLibs.CreateMutator(...);
Mutator oldMutator = RogueLibs.GetMutator("oldName");
if (oldMutator.Unlocked)
    newMutator.Unlocked = true;
RogueLibs.DeleteMutator("oldName");
// This will delete oldMutator's state from RogueLibs config file.
```
## Using Mutators ##
You can get your Mutator's Id:
```cs
public string Id { get; }
```
```cs
string myId = myMutator.Id;
```
You can get/set IsActive property of the Mutator:
```cs
public bool IsActive { get; set; }
```
```cs
if (myMutator.IsActive)
    DoYourMutatorStuff();

myMutator.IsActive = true;
// This will add your mutator to the active mutators list.
```
You can get/set Unlocked property of the Mutator:
```cs
public bool Unlocked { get; set; }
```
```cs
if (!myMutator.Unlocked)
    Logger.LogInfo("The mutator is not unlocked yet!");
	
...
myMutator.Unlocked = true;
// This state will be saved in RogueLibs config file,
// so the next time the game is loaded, this mutator will be already unlocked.
Logger.LogInfo("Player unlocked the mutator!");
```
You can also get/set ShowInMenu property of the Mutator:
```cs
public bool ShowInMenu { get; set; }
```
```cs
myMutator.ShowInMenu = false;
// Your mutator won't show in Mutator Menu at Home Base.

if (myMutator.ShowInMenu)
    Logger.LogWarn("The mutator is not showing in the menu!");
```
## Cancellations ##
You can add Conflicting Mutators - Mutators, that when enabled will automatically disable your Mutator, and will be automatically disabled when your Mutator is enabled.
<br/>Basically, you won't be able to enable both of them at the same time:
```cs
public void AddConflicting(params string[] conflictingMutators);
public void AddConflicting(params Mutator[] conflictingMutators);
```
```cs
rocketBulletsMutator.AddConflicting(waterBulletsMutator, noBulletsMutator);
rocketBulletsMutator.AddConflicting("NoGuns", "GorillaTown");
// This way you won't be able to enable both RocketBullets and WaterBullets or NoGuns and RocketBullets,
// but you WILL be able to enable both WaterBullets and NoBullets mutators.
```
And of course, you can remove these Conflicting Mutators:
```cs
public void RemoveConflicting(params string[] conflictingMutators);
public void RemoveConflicting(params Mutator[] conflictingMutators);
```
There are also Cancellations and CancelledBy Mutators:
```cs
public void AddCancellations(params string[] cancellations);
public void AddCancellations(params Mutator[] cancellations);
public void AddCancelledBy(params string[] cancellations);
public void AddCancelledBy(params Mutator[] cancellations);
```
```cs
mutatorOne.AddCancellations(mutatorTwo);
// If you enable mutatorOne, mutatorTwo will be automatically disabled.
// But if you enable mutatorTwo, mutatorOne WON'T be disabled.

mutatorTwo.AddCancelledBy(mutatorThree);
// if you enable mutatorTwo, mutatorThree WON'T be automatically disabled.
// But if you enabled mutatorThree, mutatorTwo will be disabled.
```
There are Remove methods for these too:
```cs
public void RemoveCancellations(params string[] cancellations);
public void RemoveCancellations(params Mutator[] cancellations);
public void RemoveCancelledBy(params string[] cancellations);
public void RemoveCancelledBy(params Mutator[] cancellations);
```
By the way, you can access Cancellations and CancelledBy arrays yourself:
```cs
public string[] Cancellations { get; set; }
public string[] CancelledBy { get; set; }
```
```cs
// Conflicting methods just add the mutators to both of these arrays.
```
## Custom Names ##
You can access your Mutator's CustomNames:
```cs
public CustomName Name { get; set; }
public CustomName Description { get; set; }
```
```cs
myMutator.Name.English = "My new Name";
myMutator.Description = new CustomName(...);
```
## Events ##
There are two events that you can listen to:
```cs
public event OnEnabledMethod OnEnabled;
public event OnDisabledMethod OnDisabled;
```
```cs
myMutator.OnEnabled += MyListener;
myMutator.OnDisabled += MyListener2;

myMutator.OnEnabled -= MyListener;
```