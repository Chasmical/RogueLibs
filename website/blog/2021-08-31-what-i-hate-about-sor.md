---
title: What I hate about SoR
author: Abbysssal
author_title: Creator of RogueLibs
author_url: https://github.com/SugarBarrel
author_image_url: https://github.com/SugarBarrel.png
tags: [blog, sor2]
description: The code is really hard and wet.
hide_table_of_contents: false
---

## The code is really hard and wet

.. Wait- No! I mean that the game is really **hard**coded! And the code is very **WET** - it's the opposite of the DRY (Don't Repeat Yourself) principle... It's pretty funny to say that though.

So, anyways, I decided to make a list of things that I hate about modding Streets of Rogue:

<!--truncate-->

### Global namespace

The first annoying thing that you notice, when you take a brief look into SoR modding, is that all of the game's types are in the global namespace. There's a couple of exceptions, though that's probably from the copy-pasted code.

![Global namespace (dnSpy)](https://imgur.com/HYDcvxx.png)

I mean, come on, just organize stuff in namespaces! Like `StreetsOfRogue` for main stuff, `StreetsOfRogue.LevelGeneration` for stuff related to level generation, `StreetsOfRogue.Objects` for all classes derived from `ObjectReal` and etc.

### A lot of unused types and members

There's a lot of stuff, that's not used in the game at all. Some part of it is just some test code. The other part - is not related to Streets of Rogue at all, and probably was copy-pasted from somewhere else.

![A lot of unused types](https://imgur.com/XNeeF8Q.png)
![3 unused fields in Agent class](https://imgur.com/REhaTil.png)

### Bad names

~~Type and member names should be descriptive. I do understand that Matt was the only one developing the game and didn't expect anyone to mess with the game's code. I also understand that you would know your own code better that anyone else, but still...~~ Although, nevermind, there's probably a ton of comments in the source code, that we can't see in the compiled assembly.

### Too many string comparisons

After a couple of minutes of browsing through the code, you'll notice that there's way too many string comparisons. You know they're heavy on the performance. Sometimes they're in places where you don't even need strings, for example, in `Relationships` where you could have just used enumerations (actually, Matt used **both** enumerations and strings, for some weird reason).

### Empty strings

For some reason, `""` is used instead of `string.Empty`. And for some reason `""` in a lot of the code is equivalent to `null`. You know exactly what's wrong with that. In one case there **is** a string, that simply has zero length, in the other case - **nothing**, not even a string, just nothing. It's just plain wrong.

!["" used instead of string.Empty or null](https://imgur.com/9rDQAe7.png)

### Non-flexible mechanics

For example, `Unlock` has three fields: `unavailable`, `onlyInCharacterCreation`, `freeItem`. How do you make something available only in Item Teleporter and not available anywhere else? Not only the fields are not descriptive, but they also function significantly differently - `unavailable` makes items unavailable anywhere, while `onlyInCharacterCreation` *apparently* makes an item available **only** in CC, and `freeItem` makes it available in Item Teleporter. You could have just named them `availableInGame`, `availableInCharacterCreation`, `availableInItemTeleporter`. Then their function and purpose is obvious.

![unavailable, onlyInCharacterCreation and freeItem fields](https://imgur.com/gjnxvNM.png)

I spent **dozens of hours** converting that kind of system into something more maintainable: `Available`, `AvailableInCC` and `AvailableInItemTeleporter` - properties that you can find in RogueLibs. And even after that, [there still were issues](https://github.com/SugarBarrel/RogueLibs/issues/40). *I'm bad at discrete mathematics, that's why I had a hard time doing that.*

### Hard code

A lot of stuff in the game is so hardcoded, that it's almost impossible to add something completely new and unique. You'd have to modify code in a ton of places, even in places that you wouldn't even think to look in.  
I mean, why would you hardcode the amount of players in the game? Each player has a different field (`playerAgent`, `playerAgent2`, and so on). That's the only reason why creating a multiplayer game with more than 4 players is impossible.

### Toolkit 2D library

I spent **months** trying to figure out how this fucking library works! There's no documentation on it. I mean, there are a couple of guides on how to use it in Unity Editor, but there's nothing on how it works internally. There are way too many unused classes, methods, properties and features, and for some reason the classes are in the global namespace. I'm surprised that Matt even figured out how to use it.

### Disregard of common programming principles

A lot of methods have way too many instructions in them and sometimes they do stuff that you wouldn't expect them to do. Just split these different features into different methods.  
**KISS principle (Keep It Simple, Stupid)**.

A lot of methods have a lot of repeating code. You can put that repeating code in a separate method. That will save you a ton of time writing new methods, plus, the code will be easier to read.  
**DRY principle (Don't Repeat Yourself)**.

### Binary serialization

![Comparison of raw binary data and XML-formatted file](https://imgur.com/bl0tEOj.png)

Why would you use binary serialization? It's completely unreadable!  
Just use XML, JSON or whatever markup language you want, anything but raw binary data!

### Classes are used like structs

Matt clearly doesn't understand the difference between reference and value types.

### Lack of properties

Instead of constantly setting and updating fields' values in `Awake`, `Start` and other methods, you should just use properties. This way you won't have to constantly update fields' values, once you change one other field's value. The code will instantly become more maintainable.

![MyStart method sets up fields and is called in every other method](https://imgur.com/gI7WV4I.png)

### Virtual methods

Instead of putting dozens of empty virtual methods in a base class and overriding them in a couple of derived types, you should use interfaces! That's literally what they were created for.

![Empty virtual methods](https://imgur.com/aKQA76v.png)

### Lack of events

Instead of checking for conditions of doing something on every frame update, you should use events. That's literally what they were created for. As a bonus, there's no 1-frame delay, that you get from checking conditions every frame. And also, you know, checking event conditions every frame is a little bit excessive and definitely uses way too much CPU.

### Giant `for` loops

![A lot of really big and inefficient loops](https://imgur.com/kY8gtia.png)

Why would you try to repeat the operation, if you know that the results will be exactly the same?

![An unnecessary for loop](https://imgur.com/vjCshb5.png)

Why the hell would you write all of these giant `for` loops with a ton of conditions, `break`s and `continue`s and stuff like that, when there are already methods that do exactly that?  
**Just use System.Linq extensions and List<T\> methods!**

## Conclusion

Well, that's it. For now, at least.

I wish Matt would fix all of that and make SoR 2 at least slightly more moddable and maintainable. If all of that stuff gets fixed in SoR 2, I'd be really happy, and I'd definitely make sure that SoR 2 has the best modding library possible. Otherwise, I might just refuse to make mods for the sequel, when it comes out.
