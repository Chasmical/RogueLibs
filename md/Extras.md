## [Contents](https://github.com/Abbysssal/RogueLibs) ##

1. [Main page](../README.md)
2. [RogueLibs](./RogueLibs.md)
3. [CustomMutators](./CustomMutators.md)
4. [CustomItems](./CustomItems.md)
5. [CustomNames](./CustomNames.md)
6. **Extras**
7. [RogueLibs Changelog](./Changelog.md)
8. [Mod Examples](./Examples.md)

## RogueUtilities ##
With RogueUtilities class you can convert .png or .jpg files into Sprites:
```cs
public static Sprite ConvertToSprite(string filePath);
public static Sprite ConvertToSprite(byte[] data);
```
```cs
Sprite sprite = RogueUtilities.ConvertToSprite("D:\Images\MyImage.png");

byte[] data = File.ReadAllBytes("D:\Images\MyImage.png");
Sprite sprite2 = RogueUtilities.ConvertToSprite(data);
```
And convert .mp3, .ogg, .wav, .aiff files into Audioclips. It is recommended to use .ogg, because other formats might not load properly:
```cs
public static AudioClip ConvertToAudioClip(string filePath);
```
```cs
AudioClip clip = RogueUtilities.ConvertToAudioClip("D:\Sounds\MySound.ogg");
```
You can also use this method to add conflicting CustomMutators:
```cs
public static void CrossConflict(params CustomMutator[] mutators);
```
```cs
CrossConflict(rocketBulletsMutator, waterBulletsMutator, lavaBulletsMutator);
// It's a shortcut for:
// rocketBulletsMutator.AddConflicting(waterBulletsMutator, lavaBulletsMutator);
// waterBulletsMutator.AddConflicting(rocketBulletsMutator, lavaBulletsMutator);
// lavaBulletsMutator.AddConflicting(rocketBulletsMutator, waterBulletsMutator);
```
And this to add conflicting original mutators to your CustomMutators:
```cs
public static void EachConflict(IEnumerable<string> conflicts, params CustomMutator[] mutators);
```
```cs
List<string> list = new List<string>() { "NoGuns", "InfiniteAmmo" };
EachConflict(list, rocketBulletsMutator, waterBulletsMutator, lavaBulletsMutator);
// It's a shortcut for:
// rocketBulletsMutator.AddConflicting(list.ToArray());
// waterBulletsMutator.AddConflicting(list.ToArray());
// lavaBulletsMutator.AddConflicting(list.ToArray());
```
## RogueChat ##
This class has OnCommand event, that is triggered every time a player enters a command (message starting with a slash '/'):
```cs
public static event OnMessageEvent OnCommand; // delegate void OnMessageEvent(MessageArgs a);
```
```cs
RogueChat.OnCommand += MyListener;
```
MessageArgs class consists only of one property:
```cs
public string Text { get; set; }
```
```cs
public void MyListener(MessageArgs e)
{
    if (e.Text.StartsWith("/spawn-npc "))
    {
        ...
    }
    else if (e.Text == "/heal")
    {
        ...
    }
}
```
## RoguePatcher ##
This class allows you to further simplify this code:
```cs
// Harmony harmony = new Harmony(pluginGuid);
// MethodInfo original = AccessTools.Method(typeof(SomeClass), "DoSomething");
// MethodInfo patch = AccessTools.Method(typeof(MyPatches), "DoSomething_Patch");
// harmony.Patch(original, patch);
// 
// original = AccessTools.Method(typeof(SomeOtherClass), "Start");
// patch = AccessTools.Method(typeof(MyPatches), "Start_Patch");
// harmony.Patch(original, null, patch);

this.PatchPrefix(typeof(SomeClass), "DoSomething", typeof(MyPatches), "DoSomething_Patch");
this.PatchPostfix(typeof(SomeOtherClass), "Start", typeof(MyPatches), "Start_Patch");
```
To this:
```cs
RoguePatcher patcher = new RoguePatcher(this, typeof(MyPatches));
patcher.Prefix(typeof(SomeClass), "DoSomething");
patcher.Postfix(typeof(SomeOtherClass), "Start");

// It will search for a patch method named "<TypeName>_<MethodName>" in class MyPatches.
// For example: Method "DoSomething" in "SomeClass" class will be patched
// by a method "SomeClass_DoSomething" in class "MyPatches".
```
It uses this.PatchPrefix(..) and this.PatchPostfix(..) methods for patching, so it will catch and log all exceptions that can happen during patching. If the patch was successful, methods return true, otherwise - false.

You can also switch to a different patches class:
```cs
RoguePatcher patcher = new RoguePatcher(this, typeof(MyPatches1));
patcher.Patch(..);
patcher.SwitchTo(typeof(MyPatches2));
// OR: patcher.TypeWithPatches = typeof(MyPatches2);
patcher.Patch(..);
```
This class is probably not very useful, but I think it makes writing code for manual patching a little bit faster.








