# Extra Stuff

import Tabs from '@site/src/components/Tabs';
import TabItem from '@site/src/components/TabItem';
import useBaseUrl from '@docusaurus/useBaseUrl';

## `IDoUpdate` and `IDoFixedUpdate` {#update-interfaces}

If you want to update your items/traits/unlocks with Unity's `Update` or `FixedUpdate`, implement these interfaces:

<Tabs
    defaultValue="update"
    values={[
        {label:'IDoUpdate', value:'update'},
        {label:'IDoFixedUpdate', value:'fixedupdate'},
    ]}>
<TabItem value="update">

```csharp
// highlight-next-line
public class MyCustomItem : CustomItem, IDoUpdate
{
    // highlight-start
    public void Update()
    {
        /* ... */
    }
    // highlight-end
}
```

</TabItem>
<TabItem value="fixedupdate">

```csharp
// highlight-next-line
public class MyCustomItem : CustomItem, IDoFixedUpdate
{
    // highlight-start
    public void FixedUpdate()
    {
        /* ... */
    }
    // highlight-end
}
```

</TabItem>
</Tabs>

## PluginBuildEvents {#pluginbuildevents}

### Copying plugin files {#copying-plugin-files}

Tired of copying your plugin's files over to `BepInEx/plugins`? Well, there's a solution.

First of all, download the latest version of PluginBuildEvents:

:::note
Screenshot needed.
:::

Unpack the `.events` folder in your repositories directory:

:::note
Screenshot needed.
:::

Open your project, go into its Properties > Build Events:

:::note
Screenshot needed.
:::

And specify these post-build events:

```bash
"D:\repos\.events\PluginBuildEvents.exe" "$(TargetPath)" "Streets of Rogue"
```

Where `D:\repos\.events` is the path where you put PluginBuildEvents.

:::note
If you haven't purchased the Steam version of the game (or if you somehow messed up the Steam's installation path in the registry), then specify the full path to the game instead of just the name:

```bash
"D:\repos\.events\PluginBuildEvents.exe" "$(TargetPath)" "C:\GOG Games\Streets of Rogue"
```
:::

Then just build your plugin, and its files will be moved to `BepInEx/plugins` automatically.

### Launching the game {#launching-game}

Wanna launch the game when the build's complete?

Add this to your build events on the new line:

```bash
"D:\repos\.events\PluginBuildEvents.exe" --launch 512900
```

:::note
`512900` is Streets of Rogue's id in Steam. If you're developing plugins for another game, go to its store page in Steam - the number in the URL is the id: `https://store.steampowered.com/app/512900/Streets_of_Rogue/`.
:::

:::note
If you haven't purchased the Steam version of the game, then just put the path to the game's executable in there:

```bash
"C:\GOG Games\Streets of Rogue\StreetsOfRogue.exe"
```
:::

Use this only on one of the projects in your solution. Otherwise, the game's executable will be launched more than one time, and you'll get *"Another instance of the game is already running!"* warnings or something like that.
