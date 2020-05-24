## [Contents](https://github.com/Abbysssal/RogueLibs) ##

1. [Main page](https://github.com/Abbysssal/RogueLibs/blob/master/README.md)
2. [RogueLibs](https://github.com/Abbysssal/RogueLibs/blob/master/RogueLibs.md)
3. [Mutators](https://github.com/Abbysssal/RogueLibs/blob/master/Mutators.md)
4. [CustomNames](https://github.com/Abbysssal/RogueLibs/blob/master/CustomNames.md)
5. **Extras**
6. [RogueLibs Changelog](https://github.com/Abbysssal/RogueLibs/blob/master/Changelog.md)

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
And convert .mp3, .ogg, .wav, .aiff files into Audioclips:
```cs
public static AudioClip ConvertToAudioClip(string filePath);
```
```cs
AudioClip clip = RogueUtilities.ConvertToAudioClip("D:\Sounds\MySound.ogg");
```
It is recommended to use .ogg, because other formats might not load properly.
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








