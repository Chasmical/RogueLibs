# RogueLibs
This modding library allows you to easily add custom mutators and localization lines.

## How to use RogueLibs in your mods ##
You can find instructions on how to do that here (9. Modding Libraries, RogueLibs):
https://steamcommunity.com/sharedfiles/filedetails/?id=2106187116
## One-line patches ##
Instead of writing all of this:
```cs
public void Awake()
{
    Harmony harmony = new Harmony(pluginGuid);
    MethodInfo original = AccessTools.Method(typeof(SomeClass), "DoSomething");
    MethodInfo patch = AccessTools.Method(typeof(MyPatches), "DoSomething_Patch");
    harmony.Patch(original, patch);
}
```
You can use this.PatchPrefix(..) or this.PatchPostfix(..):
```cs
using RogueLibsCore;

public void Awake()
{
    bool success = this.PatchPrefix(typeof(SomeClass), "DoSomething", typeof(MyPatches), "DoSomething_Patch");
}
```
This method will also handle and log all exceptions. If patch was successful, returns true, otherwise - false.
## Mutators ##
To create a mutator use one of the following methods:
```cs
// Mutator SetMutator(string id, bool unlockedInitially, CustomNameInfo name, CustomNameInfo description)

CustomName name = RogueLibs.SetCustomName(..);
CustomName description = RogueLibs.SetCustomName(..);
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
    
// RogueLibs doesn't save localization strings, so this code has to run every time!
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
You can create your own custom localization strings, for your own purposes, or that will overwrite in-game default ones:
```cs
// RogueLibs only affects NameDB.GetName(string myName, string type);

// CustomName SetCustomName(string id, string type, string english, string schinese = null, string german = null, string spanish = null, string brazilian = null, string russian = null, string french = null, string koreana = null)
// CustomName SetCustomName(string id, string type, CustomNameInfo info)

CustomNameInfo info = new CustomNameInfo("english", "schinese", "german", "spanish", "brazilian", "russian", "french", "koreana");
// if string is null, English will be used instead of that string
CustomName name = RogueLibs.SetCustomName(stringId, stringType, info);
// If you don't know what type you need, use null.
```
You can get existing custom names:
```cs
// CustomName GetCustomName(string id)
CustomName found = RogueLibs.GetCustomName("MyName");
// searches by id only

// CustomName GetCustomName(string id, string type)
CustomName found = RogueLibs.GetCustomName("MyName", "Agent");
// searches by id and type
```
And, you can delete your custom names:
```cs
// bool DeleteCustomName(string id)
// bool DeleteCustomName(CustomName customName)
// bool DeleteCustomName(string id, string type)
RogueLibs.DeleteCustomName("MyCustomLine", "Description");
```
## Extra functions ##
You can get mouse cursor's in-game position:
```cs
// Vector2 MouseIngamePosition()
Vector2 cursorPos = RogueLibs.MouseIngamePosition();
```
And you can spawn agents (NPCs) and items:
```cs
// Agent SpawnAgent(Vector2 position, string agentId)
Agent spawned = RogueLibs.SpawnAgent(cursorPos, "Assassin");

// Item SpawnItem(Vector2 position, string itemId, int amount)
Item item = RogueLibs.SpawnItem(cursorPos, "Flamethrower", 9000);
```
## Plugin Example ##
```cs
using System;
using BepInEx;
using RogueLibsCore;

namespace RocketBulletsMutator
{
    [BepInPlugin(pluginGuid, pluginName, pluginVersion)]
    [BepInDependency(RogueLibs.pluginGuid, "1.0")]
    public class RocketBulletsMutator : BaseUnityPlugin
    {
        public const string pluginGuid = "abbysssal.streetsofrogue.rocketbulletsmutator";
        public const string pluginName = "Rocket Bullets Mutator";
        public const string pluginVersion = "1.0";

        public static Mutator RocketBulletsCommon { get; set; }

        protected void Awake()
        {
            RocketBulletsCommon = RogueLibs.SetMutator("RocketBulletsCommon", true,
                new MutatorInfo("Rocket Bullets (Common weapons)", "Replaces common bullets (Pistol, Shotgun, Machinegun, etc.) with rockets. Rate of fire is unchanged."),
                null,
                null,
                null,
                null,
                new MutatorInfo("Ракетные пули (Простое оружие)", "Заменяет простые пули (Пистолет, Дробовик, Автомат и т.п.) на ракеты. Скорость стрельбы не изменена."),
                null,
                null);
            RocketBulletsCommon.AddConflicting("RocketLaunchers", "NoGuns");

            this.PatchPrefix(typeof(Gun), "spawnBullet", GetType(), "Gun_spawnBullet", new Type[] { typeof(bulletStatus), typeof(InvItem), typeof(int), typeof(bool), typeof(string) });
        }
        protected static void Gun_spawnBullet(ref bulletStatus bulletType)
        {
            if (RocketBulletsCommon.IsActive && (bulletType == bulletStatus.Normal || bulletType == bulletStatus.Shotgun || bulletType == bulletStatus.Revolver))
                bulletType = bulletStatus.Rocket;
        }
    }
}
```
