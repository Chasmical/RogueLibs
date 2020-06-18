## [Contents](https://github.com/Abbysssal/RogueLibs) ##

1. [Main page](https://github.com/Abbysssal/RogueLibs/blob/master/README.md)
2. [RogueLibs](https://github.com/Abbysssal/RogueLibs/blob/master/RogueLibs.md)
3. **CustomMutators**
4. [CustomNames](https://github.com/Abbysssal/RogueLibs/blob/master/CustomNames.md)
5. [Extras](https://github.com/Abbysssal/RogueLibs/blob/master/Extras.md)
6. [RogueLibs Changelog](https://github.com/Abbysssal/RogueLibs/blob/master/Changelog.md)

## Creating CustomMutators ##
```cs
public static CustomMutator SetMutator(string id, bool unlockedFromStart, CustomNameInfo name, CustomNameInfo description);
```
```cs
CustomMutator myMutator = RogueLibs.SetMutator("RocketBullets", true,
    new CustomNameInfo("english name", "schinese", null, null, null, null, null, null),
	new CustomNameInfo("description", null, null, null, null, null, null, null));

// null strings will default to english.
// After doing that your mutator will appear in Mutator Menu at Home Base.
```
## Deleting CustomMutators ##
You can delete your custom CustomMutators:
```cs
public static bool DeleteMutator(CustomMutator mutator);
public static bool DeleteMutator(string id);
```
You can use these in case you rename your mutator:
```cs
CustomMutator newMutator = RogueLibs.CreateMutator(...);
CustomMutator oldMutator = RogueLibs.GetMutator("oldName");
if (oldMutator.Unlocked)
    newMutator.Unlocked = true;
RogueLibs.DeleteMutator("oldName");
// This will delete oldMutator's state from RogueLibs config file.
```
If the removal of a CustomMutator was successful, methods return true, otherwise - false.
## Using CustomMutators ##
You can get your CustomMutator's Id:
```cs
public string Id { get; }
```
```cs
string myId = myMutator.Id;
```
You can get/set IsActive property of the CustomMutator:
```cs
public bool IsActive { get; set; }
```
```cs
if (myMutator.IsActive)
    DoYourMutatorStuff();

myMutator.IsActive = true;
// This will add your mutator to the active mutators list.
```
You can get/set Unlocked property of the CustomMutator:
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
You can also get/set ShowInMenu property of the CustomMutator:
```cs
public bool ShowInMenu { get; set; }
```
```cs
myMutator.ShowInMenu = false;
// Your mutator won't show in Mutator Menu at Home Base.

if (!myMutator.ShowInMenu)
    Logger.LogWarning("The mutator is not shown in the menu!");
```
You can also set your custom sorting order for CustomMutators:
```cs
firstMutator.SortingOrder = 60;
secondMutator.SortingOrder = 70;
thirdMutator.SortingOrder = 80;
```
If SortingOrder values are the same for two mutators, then SortingIndex values are used instead:
```cs
firstMutator.SortingOrder = 5;
firstMutator.SortingIndex = 1;
secondMutator.SortingOrder = 5;
secondMutator.SortingIndex = 2;
thirdMutator.SortingOrder = 5;
thirdMutator.SortingIndex = 3;
```
## Conflicting Mutators ##
You can add Conflicting mutators - mutators, that when enabled will automatically disable your mutator, and will be automatically disabled when your mutator is enabled.
<br/>Basically, you won't be able to enable both of them at the same time:
```cs
public void AddConflicting(params string[] conflictingMutators);
public void AddConflicting(params CustomMutator[] conflictingMutators);
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
public void RemoveConflicting(params CustomMutator[] conflictingMutators);
```
## CustomNames ##
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
There are three events that you can listen to:
```cs
public event OnChangeState OnEnabled; // delegate void OnChangeState();
public event OnChangeState OnDisabled; // delegate void OnChangeState();
public event OnState OnChangedState; // delegate void OnState(bool newState);
```
```cs
myMutator.OnEnabled += MyListener;
myMutator.OnDisabled += MyListener2;
myMutator.OnChangedState += MyListener3;
```