# Getting Started

import Tabs from '@site/src/components/Tabs';
import TabItem from '@site/src/components/TabItem';
import useBaseUrl from '@docusaurus/useBaseUrl';

## Required software {#tools}

First of all, you'll need to install these tools:

- **[dnSpy](https://github.com/dnSpy/dnSpy/releases/latest)** - a .NET assembly editor (and a debugger, but it's way too tedious to make it work for BepInEx and plugins). You're not gonna edit assemblies, just view them to see how the game and/or other plugins works.

- **[Visual Studio 2019 Community](https://visualstudio.microsoft.com/downloads/)** - the Integrated Development Environment (IDE for short) that you'll be working in.

## Creating a project {#creating-project}

Alright, open Visual Studio and **Create a new project**:

<img src={useBaseUrl('/img/setup/creating-project.png')} width='800'/>

Find and select a template called **Class Library (.NET Framework)**, then click **Next**:

<img src={useBaseUrl('/img/setup/selecting-template.png')} width='800'/>

Enter your project's name, without spaces or hyphens, just letters. Select .NET Framework **version 4.5.2**, then click **Create**.

:::tip Pro-tip: Repositories directory
You can create a directory for your repositories in the root of one of your drives, for example, `D:\repos`. It's way shorter, more accessible and simpler to use than the default `C:\Users\$USER\source\repos`.
:::

<img src={useBaseUrl('/img/setup/configuring-project.png')} width='800'/>

## Referencing RogueLibs and game's assembly {#references}

Create a folder called **`Libraries`** in your solution's directory. We'll put all referenced `.dll`s in there.

<img src={useBaseUrl('/img/setup/libraries-folder.png')} width='800'/>

Go to `<GameName>_Data/Managed`, grab the following files and put them in `Libraries`:

- **`Assembly-CSharp.dll`** - assembly with all of the game's code.
- **`netstandard.dll`** - Idk, for some reason, it's required sometimes.
- **`UnityEngine.dll`** and **`UnityEngine.CoreModule.dll`** - Unity assemblies.

:::info
If you don't have a required assembly referenced, you'll see an error in Visual Studio's **Error List**.<br/>In that case, go to `<GameName>_Data/Managed` again and grab the missing assembly.
:::

Then go to `BepInEx/core` in the game's root and grab these too:

- **`BepInEx.dll`** and **`BepInEx.xml`**.
- *`0Harmony.dll` and `0Harmony.xml` - in case you want to transpile-patch or do the patching yourself.*

**[Download the latest RogueLibs version](https://github.com/Abbysssal/RogueLibs/releases).**

You'll need only two files: **`RogueLibsCore.dll` and `RogueLibsCore.xml`**. Put them in `Libraries` too:

<img src={useBaseUrl('/img/setup/libraries-folder-2.png')} width='800'/>

Now open Visual Studio, find your project in **Solution Explorer**, right-click on **References** and click **Add Reference...**:

:::note
Btw, you can remove all of the default references.
:::

<img src={useBaseUrl('/img/setup/references.png')} width='400'/>

In the **Reference Manager** click **Browse...**, select all `.dll`s in your `Libraries` folder and click **Add**.

<img src={useBaseUrl('/img/setup/references-2.png')} width='800'/>

## Writing a basic plugin {#basic-plugin}

Add all necessary `using`s:

```csharp title="Class1.cs"
// highlight-start
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using BepInEx;
using UnityEngine;
using RogueLibsCore;
// highlight-end

namespace MyCoolMod
{
    public class Class1
    {
        
    }
}
```

Add a class deriving from `BaseUnityPlugin`.

```csharp title="MyCoolPlugin.cs"
namespace MyCoolMod
{
    // highlight-next-line
    public class MyCoolPlugin : BaseUnityPlugin
    {
    }
}
```

Add a `BepInPlugin` attribute to it with your plugin's <abbr title="Globally Unique Identifier">GUID</abbr>, name and version.<br/>You can also put `string`s right into the attribute, without using `const`s, if you want.

```csharp title="MyCoolPlugin.cs"
// highlight-next-line
[BepInPlugin(pluginGUID, pluginName, pluginVersion)]
public class MyCoolPlugin : BaseUnityPlugin
{
    // highlight-start
    public const string pluginGUID = "myusername.streetsofrogue.mycoolmod";
    public const string pluginName = "My Cool Mod";
    public const string pluginVersion = "0.1.0";
    // highlight-end
}
```

:::caution
Once you've published your mod, **do not change its GUID!** If you do, all dependency trees related to your mod will break. Even if no one uses your mod as a framework, some developers might have added `BepInIncompatibility` with your mod's GUID. If you want to change the GUID, then create a new mod, replacing the old one.
:::

:::tip Pro-tip: Semantic versioning
I recommend using [semantic versioning](https://semver.org) in your mods.
:::

Add a `BepInDependency` attribute with RogueLibs and add Unity's `Awake()` method:

```csharp title="MyCoolPlugin.cs"
[BepInPlugin(pluginGUID, pluginName, pluginVersion)]
// highlight-next-line
[BepInDependency(RogueLibs.GUID, RogueLibs.CompiledVersion)]
public class MyCoolPlugin : BaseUnityPlugin
{
    public const string pluginGUID = "myusername.streetsofrogue.mycoolmod";
    public const string pluginName = "My Cool Mod";
    public const string pluginVersion = "0.1.0";

    // highlight-start
    public void Awake()
    {
        // your code goes here
    }
    // highlight-end
}
```

**Now just explore the docs and make stuff!**

## "Hello World!" plugin example {#hello-world}

```csharp title="MyCoolPlugin.cs"
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using BepInEx;
using UnityEngine;
using RogueLibsCore;

namespace MyCoolMod
{
    [BepInPlugin(pluginGUID, pluginName, pluginVersion)]
    [BepInDependency(RogueLibs.GUID, RogueLibs.CompiledVersion)]
    public class MyCoolPlugin : BaseUnityPlugin
    {
        public const string pluginGUID = "myusername.streetsofrogue.mycoolmod";
        public const string pluginName = "My Cool Mod";
        public const string pluginVersion = "0.1.0";

        public static ManualLogSource MyLogger;
        // so you can reference it in patches

        public void Awake()
        {
            MyLogger = Logger;
            Logger.LogMessage("Hello World!");
        }
    }
}
```