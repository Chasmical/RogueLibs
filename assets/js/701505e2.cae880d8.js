"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[5683],{7719:function(e){e.exports=JSON.parse('{"blogPosts":[{"id":"/2022/01/30/roguelibs-v3.5.0-beta","metadata":{"permalink":"/RogueLibs/blog/2022/01/30/roguelibs-v3.5.0-beta","editUrl":"https://github.com/SugarBarrel/RogueLibs/edit/main/website/blog/blog/2022-01-30/roguelibs-v3.5.0-beta.mdx","source":"@site/blog/2022-01-30/roguelibs-v3.5.0-beta.mdx","title":"RogueLibs v3.5.0 enters beta","description":"Information about the v3.5.0-beta","date":"2022-01-30T00:00:00.000Z","formattedDate":"January 30, 2022","tags":[{"label":"roguelibs","permalink":"/RogueLibs/blog/tags/roguelibs"}],"readingTime":1.305,"truncated":true,"authors":[{"name":"Abbysssal","title":"Creator of RogueLibs","url":"https://github.com/SugarBarrel","imageURL":"https://github.com/SugarBarrel.png"}],"nextItem":{"title":"What I hate about SoR","permalink":"/RogueLibs/blog/2021/08/31/what-i-hate-about-sor"}},"content":"Today RogueLibs v3.5.0 enters a long beta, because there\'s a huge list of stuff that needs to be done before the release, mainly adding new custom interactions without adding more patches. You\'ll be able to download the beta version on [RogueLibs\' releases page](https://github.com/SugarBarrel/RogueLibs/releases).\\n\\nJust like the localization system in v3.1.0, v3.5.0 will completely replace the vanilla interactions system. The original code in these places is absolutely awful and inconsistent. So, we\'ll have to rewrite every single vanilla interaction to be moddable.\\n\\n![](./screenshot.png)\\n\\n:::note\\nIn RogueLibs v3.5.0-beta.X all of the objects will have this button. And by \\"that button\\" I mean the \\"I am patched!\\" one, not \\"Make Offering of Human Body\\" one. It will be removed from the v3.5.0 full release, of course.\\n:::\\n\\nClick \\"Read More\\" to see the entire to-do list.\\n\\n\x3c!--truncate--\x3e\\n\\n\u274c`Agent`, \u2705`AirConditioner`, \u2705`AlarmButton`, \u2705`Altar`, \u2705`AmmoDispenser`, \u274c`ArcadeGame`, \u274c`ATMMachine`, \u274c`AugmentationBooth`, \u2705`Barbecue`, \u274c`BarbedWire`, \u274c`Bars`, \u274c(?)`BarStool`, \u274c(?)`Bathtub`, \u274c`Bed`, \u274c(?)`Boulder`, \u274c(?)`BoulderSmall`, \u274c(?)`Bush`, \u274c`CapsuleMachine`, \u274c(?)`Chair`, \u274c(?)`ChestBasic`, \u274c`CloneMachine`, \u274c`Computer`, \u274c(?)`Counter`, \u274c`Crate`, \u274c(?)`Desk`, \u274c`Door`, \u274c`Elevator`, \u274c(?)`ExplodingBarrel`, \u274c`FireHydrant`, \u274c(?)`FirePlace`, \u274c(?)`FireSpewer`, \u274c(?)`FlameGrate`, \u274c(?)`FlamingBarrel`, \u274c(?)`GasVent`, \u274c`Generator`, \u274c`Generator2`, \u274c(?)`Gravestone`, \u274c(?)`Item`, \u274c`Jukebox`, \u274c(?)`KillerPlant`, \u274c(?)`Lamp`, \u274c`LaserEmitter`, \u274c`LoadoutMachine`, \u274c(?)`LockdownWall`, \u274c(?)`Manhole`, \u274c(?)`MineCart`, \u274c(?)`MovieScreen`, \u274c`PawnShopMachine`, \u274c(?)`Plant`, \u274c`Podium`, \u274c`PoliceBox`, \u274c(?)`PoolTable`, \u274c`PowerBox`, \u274c`Refrigerator`, \u274c`Safe`, \u274c`SatelliteDish`, \u274c(?)`SawBlade`, \u274c`SecurityCam`, \u274c(?)`Shelf`, \u274c(?)`Sign`, \u274c(?)`SlimeBarrel`, \u274c(?)`SlimePuddle`, \u274c`SlotMachine`, \u274c(?)`Speaker`, \u274c(?)`StartingPoint`, \u274c(?)`Stove`, \u274c(?)`SwitchBasic`, \u274c(?)`Table`, \u274c(?)`TableBig`, \u274c(?)`Television`, \u274c`Toilet`, \u274c(?)`Train`, \u274c`TrapDoor`, \u274c(?)`TrashCan`, \u274c(?)`Tree`, \u274c(?)`Tube`, \u274c`Turntables`, \u274c`Turret`, \u274c(?)`VendorCart`, \u274c(?)`WasteBasket`, \u274c`WaterPump`, \u274c`Well`, \u274c`Window`.\\n\\n:::note Legend\\n\u274c - not implemented, \ud83d\udd39 - not tested, \u2705 - implemented, (?) - may be tricky to implement.\\n:::\\nSee the [#modding channel](https://discord.gg/m3zuHSwQw2) on the [official SoR\'s Discord server](https://discord.com/invite/streetsofrogue) for an up-to-date information. The list in this article will not be updated."},{"id":"/2021/08/31/what-i-hate-about-sor","metadata":{"permalink":"/RogueLibs/blog/2021/08/31/what-i-hate-about-sor","editUrl":"https://github.com/SugarBarrel/RogueLibs/edit/main/website/blog/blog/2021-08-31-what-i-hate-about-sor.md","source":"@site/blog/2021-08-31-what-i-hate-about-sor.md","title":"What I hate about SoR","description":"The code is really hard and wet.","date":"2021-08-31T00:00:00.000Z","formattedDate":"August 31, 2021","tags":[{"label":"blog","permalink":"/RogueLibs/blog/tags/blog"},{"label":"sor2","permalink":"/RogueLibs/blog/tags/sor-2"}],"readingTime":5.7,"truncated":true,"authors":[{"name":"Abbysssal","title":"Creator of RogueLibs","url":"https://github.com/SugarBarrel","imageURL":"https://github.com/SugarBarrel.png"}],"prevItem":{"title":"RogueLibs v3.5.0 enters beta","permalink":"/RogueLibs/blog/2022/01/30/roguelibs-v3.5.0-beta"},"nextItem":{"title":"RogueLibs v3.1.0 released!","permalink":"/RogueLibs/blog/2021/08/18/roguelibs-v3.1.0"}},"content":"## The code is really hard and wet\\n\\n.. Wait- No! I mean that the game is really **hard**coded! And the code is very **WET** - it\'s the opposite of the DRY (Don\'t Repeat Yourself) principle... It\'s pretty funny to say that though.\\n\\nSo, anyways, I decided to make a list of things that I hate about modding Streets of Rogue:\\n\\n\x3c!--truncate--\x3e\\n\\n### Global namespace\\n\\nThe first annoying thing that you notice, when you take a brief look into SoR modding, is that all of the game\'s types are in the global namespace. There\'s a couple of exceptions, though that\'s probably from the copy-pasted code.\\n\\n![Global namespace (dnSpy)](https://imgur.com/HYDcvxx.png)\\n\\nI mean, come on, just organize stuff in namespaces! Like `StreetsOfRogue` for main stuff, `StreetsOfRogue.LevelGeneration` for stuff related to level generation, `StreetsOfRogue.Objects` for all classes derived from `ObjectReal` and etc.\\n\\n### A lot of unused types and members\\n\\nThere\'s a lot of stuff, that\'s not used in the game at all. Some part of it is just some test code. The other part - is not related to Streets of Rogue at all, and probably was copy-pasted from somewhere else.\\n\\n![A lot of unused types](https://imgur.com/XNeeF8Q.png)\\n![3 unused fields in Agent class](https://imgur.com/REhaTil.png)\\n\\n### Bad names\\n\\n~~Type and member names should be descriptive. I do understand that Matt was the only one developing the game and didn\'t expect anyone to mess with the game\'s code. I also understand that you would know your own code better that anyone else, but still...~~ Although, nevermind, there\'s probably a ton of comments in the source code, that we can\'t see in the compiled assembly.\\n\\n### Too many string comparisons\\n\\nAfter a couple of minutes of browsing through the code, you\'ll notice that there\'s way too many string comparisons. You know they\'re heavy on the performance. Sometimes they\'re in places where you don\'t even need strings, for example, in `Relationships` where you could have just used enumerations (actually, Matt used **both** enumerations and strings, for some weird reason).\\n\\n### Empty strings\\n\\nFor some reason, `\\"\\"` is used instead of `string.Empty`. And for some reason `\\"\\"` in a lot of the code is equivalent to `null`. You know exactly what\'s wrong with that. In one case there **is** a string, that simply has zero length, in the other case - **nothing**, not even a string, just nothing. It\'s just plain wrong.\\n\\n![\\"\\" used instead of string.Empty or null](https://imgur.com/9rDQAe7.png)\\n\\n### Non-flexible mechanics\\n\\nFor example, `Unlock` has three fields: `unavailable`, `onlyInCharacterCreation`, `freeItem`. How do you make something available only in Item Teleporter and not available anywhere else? Not only the fields are not descriptive, but they also function significantly differently - `unavailable` makes items unavailable anywhere, while `onlyInCharacterCreation` *apparently* makes an item available **only** in CC, and `freeItem` makes it available in Item Teleporter. You could have just named them `availableInGame`, `availableInCharacterCreation`, `availableInItemTeleporter`. Then their function and purpose is obvious.\\n\\n![unavailable, onlyInCharacterCreation and freeItem fields](https://imgur.com/gjnxvNM.png)\\n\\nI spent **dozens of hours** converting that kind of system into something more maintainable: `Available`, `AvailableInCC` and `AvailableInItemTeleporter` - properties that you can find in RogueLibs. And even after that, [there still were issues](https://github.com/SugarBarrel/RogueLibs/issues/40). *I\'m bad at discrete mathematics, that\'s why I had a hard time doing that.*\\n\\n### Hard code\\n\\nA lot of stuff in the game is so hardcoded, that it\'s almost impossible to add something completely new and unique. You\'d have to modify code in a ton of places, even in places that you wouldn\'t even think to look in.  \\nI mean, why would you hardcode the amount of players in the game? Each player has a different field (`playerAgent`, `playerAgent2`, and so on). That\'s the only reason why creating a multiplayer game with more than 4 players is impossible.\\n\\n### Toolkit 2D library\\n\\nI spent **months** trying to figure out how this fucking library works! There\'s no documentation on it. I mean, there are a couple of guides on how to use it in Unity Editor, but there\'s nothing on how it works internally. There are way too many unused classes, methods, properties and features, and for some reason the classes are in the global namespace. I\'m surprised that Matt even figured out how to use it.\\n\\n### Disregard of common programming principles\\n\\nA lot of methods have way too many instructions in them and sometimes they do stuff that you wouldn\'t expect them to do. Just split these different features into different methods.  \\n**KISS principle (Keep It Simple, Stupid)**.\\n\\nA lot of methods have a lot of repeating code. You can put that repeating code in a separate method. That will save you a ton of time writing new methods, plus, the code will be easier to read.  \\n**DRY principle (Don\'t Repeat Yourself)**.\\n\\n### Binary serialization\\n\\n![Comparison of raw binary data and XML-formatted file](https://imgur.com/bl0tEOj.png)\\n\\nWhy would you use binary serialization? It\'s completely unreadable!  \\nJust use XML, JSON or whatever markup language you want, anything but raw binary data!\\n\\n### Classes are used like structs\\n\\nMatt clearly doesn\'t understand the difference between reference and value types.\\n\\n### Lack of properties\\n\\nInstead of constantly setting and updating fields\' values in `Awake`, `Start` and other methods, you should just use properties. This way you won\'t have to constantly update fields\' values, once you change one other field\'s value. The code will instantly become more maintainable.\\n\\n![MyStart method sets up fields and is called in every other method](https://imgur.com/gI7WV4I.png)\\n\\n### Virtual methods\\n\\nInstead of putting dozens of empty virtual methods in a base class and overriding them in a couple of derived types, you should use interfaces! That\'s literally what they were created for.\\n\\n![Empty virtual methods](https://imgur.com/aKQA76v.png)\\n\\n### Lack of events\\n\\nInstead of checking for conditions of doing something on every frame update, you should use events. That\'s literally what they were created for. As a bonus, there\'s no 1-frame delay, that you get from checking conditions every frame. And also, you know, checking event conditions every frame is a little bit excessive and definitely uses way too much CPU.\\n\\n### Giant `for` loops\\n\\n![A lot of really big and inefficient loops](https://imgur.com/kY8gtia.png)\\n\\nWhy would you try to repeat the operation, if you know that the results will be exactly the same?\\n\\n![An unnecessary for loop](https://imgur.com/vjCshb5.png)\\n\\nWhy the hell would you write all of these giant `for` loops with a ton of conditions, `break`s and `continue`s and stuff like that, when there are already methods that do exactly that?  \\n**Just use System.Linq extensions and List<T\\\\> methods!**\\n\\n## Conclusion\\n\\nWell, that\'s it. For now, at least.\\n\\nI wish Matt would fix all of that and make SoR 2 at least slightly more moddable and maintainable. If all of that stuff gets fixed in SoR 2, I\'d be really happy, and I\'d definitely make sure that SoR 2 has the best modding library possible. Otherwise, I might just refuse to make mods for the sequel, when it comes out."},{"id":"/2021/08/18/roguelibs-v3.1.0","metadata":{"permalink":"/RogueLibs/blog/2021/08/18/roguelibs-v3.1.0","editUrl":"https://github.com/SugarBarrel/RogueLibs/edit/main/website/blog/blog/2021-08-18-roguelibs-v3.1.0.md","source":"@site/blog/2021-08-18-roguelibs-v3.1.0.md","title":"RogueLibs v3.1.0 released!","description":"Completely replaced the vanilla localization system.","date":"2021-08-18T00:00:00.000Z","formattedDate":"August 18, 2021","tags":[{"label":"roguelibs","permalink":"/RogueLibs/blog/tags/roguelibs"},{"label":"release","permalink":"/RogueLibs/blog/tags/release"}],"readingTime":2.9,"truncated":true,"authors":[{"name":"Abbysssal","title":"Creator of RogueLibs","url":"https://github.com/SugarBarrel","imageURL":"https://github.com/SugarBarrel.png"}],"prevItem":{"title":"What I hate about SoR","permalink":"/RogueLibs/blog/2021/08/31/what-i-hate-about-sor"}},"content":"Today a new version of RogueLibs v3.1.0 was released!\\n\\nA brand new localization system will completely replace the vanilla one!\\n\\n- Fancy, easy-to-use XML files, for each language separately;\\n- Fixed the bug with \\"E_\\" prefixes appearing in random places;\\n- Custom languages support;\\n- Community translations;\\n- Automatic updates;\\n- Live Reloading!\\n\\n![Locales opened in VSCode](https://i.imgur.com/XaNGCx7.png)\\n\\n\x3c!--truncate--\x3e\\n\\n### Upgrading/downgrading to XML\\n\\nOn one hand, we lose some of th-, I mean, the **one** advantage of CSV files:\\n\\n- **Small size.**  \\n  Not as compact, as physically possible, but still, it has a relatively low data-to-size ratio, close to 1. The only non-data characters are commas, the surrounding quotes, double quotes inside of expressions and new lines.\\n\\nBut on the other hand, we gain a ton of advantages of XML:\\n\\n- **Easy to read.**  \\n  Humans can open the file in a text editor, and it will automatically highlight the XML syntax.  \\n- **Easy to edit.**  \\n  Modern text editors check for errors in XML, making it almost impossible to corrupt the file.\\n- **Easy to parse.**  \\n  Computers can easily parse XML files with the built-in `System.Xml.Serialization` (in case of C#). There\'s no need for any overcomplicated regular expressions used in the game.\\n\\n### Categorizing translations by language\\n\\nThe vanilla game loads all languages at the same time, regardless of what language is selected.\\n\\nRogueLibs will load only the ones, that are actually used: the selected one and the fallback one (default: English), that will be used in case an entry is missing in the selected language.\\n\\nThis loading strategy allows you to select from thousands of different localizations, without loading all of them at the same time.\\n\\n### Automatic updates\\n\\nWhen you launch the game, RogueLibs will download a small \\"index\\" file with some metadata, and then it will decide what translations should be updated. Don\'t worry, it won\'t check for updates too frequently, just once every hour.\\n\\n### Community translations\\n\\nSpeaking of translations... **The vanilla translations are terrible**. I\'m not sure what the situation is like with other languages, but russian localization is really bad:\\n\\n- Some words are taken out of context. \\"Glass\\", as in \\"a glass wall\\", not as in \\"a glass of milk\\".\\n- \\"Chunk Pack\\" was literally translated as a \\"pack\\" of \\"chunks\\". I\'m not sure how to explain that, but it caused quite a lot of comotion in the russian community.\\n- Some words are not translated at all. \\"Walkie-Talkie\\" is still a \\"Walkie-Talkie\\". What kind of translator were they even using? Every online translator I could find translated it correctly.\\n- Some translation lines were shifted a couple of lines up or down, for some reason. As if someone was editing it in Excel.\\n- There was also a ton of different styles. Sometimes \\"\u2014\\" was used instead of \\"-\\", \\"\u2026\\" instead of \\"...\\" and stuff like that. As if there were at least 3 different translators, one using Word, other one - Excel and another one - Notepad.\\n- \\"Monkey Barrel\\" \u2192 \\"\u041e\u0431\u0435\u0437\u044c\u044f\u043d\u0430 \u0431\u0430\u0440\u0440\u0435\u043b\u044c\\". What the f\\\\*\\\\*\\\\*.\\n- I spent about 2 days, working from morning to night, to fix all of that.\\n\\nAnd that\'s why RogueLibs will use community translations instead of official ones.\\n\\nFeel free to contribute by checking the localization files yourself and making any necessary changes. The localization files are located [in here](https://github.com/SugarBarrel/RogueLibs/tree/main/RogueLibsCore/Resources). See more info on contributing to the project [here](https://github.com/SugarBarrel/RogueLibs/blob/main/.github/CONTRIBUTING.md).\\n\\n### Live Reloading\\n\\nWhen you edit the localization files, the changes are reflected in the game immediately! Neat!"}]}')}}]);