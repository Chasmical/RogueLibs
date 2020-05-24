## [Contents](https://github.com/Abbysssal/RogueLibs) ##

1. [Main page](https://github.com/Abbysssal/RogueLibs/blob/master/README.md)
2. [RogueLibs](https://github.com/Abbysssal/RogueLibs/blob/master/RogueLibs.md)
3. [Mutators](https://github.com/Abbysssal/RogueLibs/blob/master/Mutators.md)
4. **CustomNames**
5. [RogueLibs Changelog](https://github.com/Abbysssal/RogueLibs/blob/master/Changelog.md)

## Creating CustomNames ##
```cs
public static CustomName SetCustomName(string id, string type, CustomNameInfo info);
```
```cs
CustomName name = RogueLibs.SetCustomName("myId", "Agent", new CustomNameInfo(
    "english",
	"schinese",
	null,
	null,
	null,
	null,
	null,
	null));
// null strings will default to english.

// If you don't know which type you need, use null.
```
```cs
public static CustomName SetCustomName(string id, string type, string english, string schinese = null, string german = null, string spanish = null, string brazilian = null, string russian = null, string french = null, string koreana = null);
```
```cs
CustomName name2 = RogueLibs.SetCustomName("myId", null,
    "english",
	"schinese",
	null,
	null,
	null,
	null,
	null,
	null);
// null strings will default to english.

// If you don't know which type you need, use null.
```
You can also get CustomName by its Id (or both Id and type):
```cs
public static CustomName GetCustomName(string id);
public static CustomName GetCustomName(string id, string type);
```
```cs
CustomName found = RogueLibs.GetCustomName("MyNameId");
CustomName found2 = RogueLibs.GetCustomName("MyNameId", "MyType");
```
## Deleting CustomNames ##
Just in case you don't need your CustomNames anymore:
```cs
public static bool DeleteCustomName(string id);
public static bool DeleteCustomName(CustomName customName);
public static bool DeleteCustomName(string id, string type);
```
## Using CustomNames ##
You can get your CustomName's Id and Type:
```cs
public string Id { get; }
public string Type { get; }
```
```cs
string myId = myCustomName.Id;
string myType = myCustomName.Type;
```
You can access different localization lines:
```cs
public string English { get; set; }
public string SChinese { get; set; }
public string German { get; set; }
public string Spanish { get; set; }
public string Brazilian { get; set; }
public string Russian { get; set; }
public string French { get; set; }
public string KoreanA { get; set; }
```
```cs
string englishString = myCustomName.English;

myCustomName.English = "newName";
```
Or you can access the translations array itself:
```cs
public string[] Translations { get; set; }
```
```cs
string randomString = myCustomName.Translations[Random.NextInt(8)];
myCustomName.Translations[3] = "NewName";
```















