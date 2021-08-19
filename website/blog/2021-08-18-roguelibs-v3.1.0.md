---
title: RogueLibs v3.1.0 released!
author: Abbysssal
author_title: Creator of RogueLibs
author_url: https://github.com/Abbysssal
author_image_url: https://avatars.githubusercontent.com/u/55982389?height=200&width=200
tags: [roguelibs, release]
description: Completely replaced the vanilla localization system.
image: https://i.imgur.com/XaNGCx7.png
hide_table_of_contents: false
---

Today a new version of RogueLibs v3.1.0 was released!

A brand new localization system will completely replace the vanilla one!

- Fancy, easy-to-use XML files, for each language separately;
- Fixed the bug with "E_" prefixes appearing in random places;
- Custom languages support;
- Community translations;
- Automatic updates;
- Live Reloading!

<!--truncate-->

### Upgrading/downgrading to XML

On one hand, we lose some of th-, I mean, the **one** advantage of CSV files:

- **Small size.**  
  Not as compact, as physically possible, but still, it has a relatively low data-to-size ratio, close to 1. The only non-data characters are commas, the surrounding quotes, double quotes inside of expressions and new lines.

But on the other hand, we gain a ton of advantages of XML:

- **Easy to read.**  
  Humans can open the file in a text editor, and it will automatically highlight the XML syntax.  
- **Easy to edit.**  
  Modern text editors check for errors in XML, making it almost impossible to corrupt the file.
- **Easy to parse.**  
  Computers can easily parse XML files with the built-in `System.Xml.Serialization` (in case of C#). There's no need for any overcomplicated regular expressions used in the game.

### Categorizing translations by language

The vanilla game loads all languages at the same time, regardless of what language is selected.

RogueLibs will load only the ones, that are actually used: the selected one and the fallback one (default: English), that will be used in case an entry is missing in the selected language.

This loading strategy allows you to select from thousands of different localizations, without loading all of them at the same time.

### Automatic updates

When you launch the game, RogueLibs will download a small "index" file with some metadata, and then it will decide what translations should be updated. Don't worry, it won't check for updates too frequently, just once every hour.

### Community translations

Speaking of translations... **The vanilla translations are terrible**. I'm not sure what the situation is like with other languages, but russian localization is really bad:

- Some words are taken out of context. "Glass", as in "a glass wall", not as in "a glass of milk".
- "Chunk Pack" was literally translated as a "pack" of "chunks". I'm not sure how to explain that, but it caused quite a lot of comotion in the russian community.
- Some words are not translated at all. "Walkie-Talkie" is still a "Walkie-Talkie". What kind of translator were they even using? Every online translator I could find translated it correctly.
- Some translation lines were shifted a couple of lines up or down, for some reason. As if someone was editing it in Excel.
- There was also a ton of different styles. Sometimes "—" was used instead of "-", "…" instead of "..." and stuff like that. As if there were at least 3 different translators, one using Word, other one - Excel and another one - Notepad.
- "Monkey Barrel" → "Обезьяна баррель". What the f\*\*\*.
- I spent about 2 days, working from morning to night, to fix all of that.

And that's why RogueLibs will use community translations instead of official ones.

Feel free to contribute by checking the localization files yourself and making any necessary changes. The localization files are located [in here](https://github.com/Abbysssal/RogueLibs/tree/main/RogueLibsCore/Resources). See more info on contributing to the project [here](https://github.com/Abbysssal/RogueLibs/blob/main/.github/CONTRIBUTING.md).

### Live Reloading

When you edit the localization files, the changes are reflected in the game immediately! Neat!
