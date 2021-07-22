# Installation

import Tabs from '@site/src/components/Tabs';
import TabItem from '@site/src/components/TabItem';
import MicrosoftButton from '@site/src/components/MicrosoftButton';
import useBaseUrl from '@docusaurus/useBaseUrl';

## Installing BepInEx {#bepinex}

**If you already have BepInEx installed, [skip this step](#roguelibs).**

### Downloading BepInEx {#bepinex-downloading}

**[Go here](https://github.com/BepInEx/BepInEx/releases/latest) and download the version for your OS:**

<Tabs
    groupId="os"
    defaultValue="win"
    values={[
        {label: 'Windows', value: 'win'},
        {label: 'Linux', value: 'linux'},
        {label: 'macOS', value: 'macos'},
    ]}>
<TabItem value="win">

Download the version of BepInEx for your system's type:

- **`BepInEx_x64_5.x.y.z.zip`** is for **64-bit** systems.
- **`BepInEx_x86_5.x.y.z.zip`** is for **32-bit** systems.

Here's a few pointers:

- If you have **more than 4 Gb of RAM**, then you definitely have a **64-bit OS**. A 32-bit version simply cannot use more than 4 Gb of RAM, because of, you know, 32 bits (2^32 bytes = 4 gigabytes).
- If you have Windows 10, <MicrosoftButton link="ms-settings:about">Open About settings</MicrosoftButton> (or `⊞ Win`+`I` > **System** > **About**). You'll see what version of Windows you're running under **Device specifications: System type**.
- If you have Windows 7 or 8, then [go here](https://support.microsoft.com/en-us/windows/which-version-of-windows-operating-system-am-i-running-628bec99-476a-2c13-5296-9dd081cdd808#ID0EBBD=Windows_7).

</TabItem>
<TabItem values={["linux", "macos"]}>

- Simply download **`BepInEx_unix_5.x.y.z.zip`.**

</TabItem>
</Tabs>

### Extracting files {#bepinex-extract}

<Tabs
    groupId="vendor"
    defaultValue="steam"
    values={[
        {label: 'I know where my game is installed!', value: 'none'},
        {label: 'Steam', value: 'steam'},
        {label: 'GOG', value: 'gog'},
    ]}>
<TabItem value="steam">

Open Steam's game library, right-click on the game and click **Properties...**:

<img src={useBaseUrl('/img/installation/finding-the-game-1.png')} width='300'/>

Go to **Local files** and click **Browse...**:

<img src={useBaseUrl('/img/installation/finding-the-game-2.png')} width='600'/>

</TabItem>
<TabItem value="gog">

Try looking at these paths:

<Tabs
    groupId="os"
    defaultValue="win"
    values={[
        {label: 'Windows', value: 'win'},
        {label: 'Linux', value: 'linux'},
        {label: 'macOS', value: 'macos'},
    ]}>
<TabItem value="win">

- `C:\GOG Games`;
- `C:\Program Files (x86)\GOG.com`;
- `C:\Program Files\GOGcom`; <!-- yep, without the dot -->

</TabItem>
<TabItem values={["linux", "macos"]}>

- `$HOME/GOG Games`;

</TabItem>
</Tabs>

</TabItem>
</Tabs>

**Extract the contents of the .zip file into the game's root directory.**

<Tabs
    groupId="os"
    defaultValue="win"
    values={[
        {label: 'Windows', value: 'win'},
        {label: 'Linux', value: 'linux'},
        {label: 'macOS', value: 'macos'},
    ]}>
<TabItem value="win">

Make sure you extract it the right way. There's a lot of wrong ways, apparently.

- Make sure that `BepInEx` folder is extracted in the same directory as your game's executable (`StreetsOfRogue.exe`);
- Make sure that you extract the `doorstop_config.ini` and `winhttp.dll` files too;

</TabItem>
<TabItem value="linux">

Make sure you extract it the right way. There's a lot of wrong ways, apparently.

- Make sure that `BepInEx` and `doorstop_libs` folders are in the same directory as your game's executable (`StreetsOfRogue.x86` or `StreetsOfRogue.x86_64`);
- Make sure that you extract the `run_bepinex.sh` file too;

</TabItem>
<TabItem value="macos">

Make sure you extract it the right way. There's a lot of wrong ways, apparently.

- Make sure that `BepInEx` and `doorstop_libs` folders are in the same directory as your game's executable (`StreetsOfRogue.app`);
- Make sure that you extract the `run_bepinex.sh` file too;

</TabItem>
</Tabs>

### Running the game {#bepinex-first-run}

:::note
You need to run the game at least once, so that BepInEx can generate config files and directories!
:::

import BrowserWindow from '@site/src/components/BrowserWindow';

<Tabs
    groupId="os"
    defaultValue="win"
    values={[
        {label: 'Windows', value: 'win'},
        {label: 'Linux', value: 'linux'},
        {label: 'macOS', value: 'macos'},
    ]}>
<TabItem value="win">

Just run the game. Either through an executable, or any game launcher.

You can close the game once you see a logo or a loading screen.

</TabItem>
<TabItem value="linux">

Open the included `run_bepinex.sh` script and edit the highlighted line to be the name of the executable:

```bash title="run_bepinex.sh"
#!/bin/sh
# BepInEx running script
#
# This script is used to run a Unity game with BepInEx enabled.
#
# Usage: Configure the script below and simply run this script when you want to run your game modded.

# -------- SETTINGS --------
# ---- EDIT AS NEEDED ------

# EDIT THIS: The name of the executable to run
# LINUX: This is the name of the Unity game executable 
# MACOS: This is the name of the game app folder, including the .app suffix
# highlight-next-line
executable_name="StreetsOfRogue"

# The rest is automatically handled by BepInEx
# ...
```

Open the terminal in the game's root directory and add execution permission to the script:

<BrowserWindow>

```bash
chmod u+x run_bepinex.sh
```

</BrowserWindow>

Now you can run BepInEx by executing the script:

<BrowserWindow>

```bash
./run_bepinex.sh
```

</BrowserWindow>

</TabItem>
<TabItem value="macos">

Open the included `run_bepinex.sh` script and edit the highlighted line to be the name of the executable **(including the `.app` extension)**:

```bash title="run_bepinex.sh"
#!/bin/sh
# BepInEx running script
#
# This script is used to run a Unity game with BepInEx enabled.
#
# Usage: Configure the script below and simply run this script when you want to run your game modded.

# -------- SETTINGS --------
# ---- EDIT AS NEEDED ------

# EDIT THIS: The name of the executable to run
# LINUX: This is the name of the Unity game executable 
# MACOS: This is the name of the game app folder, including the .app suffix
# highlight-next-line
executable_name="StreetsOfRogue.app"

# The rest is automatically handled by BepInEx
# ...
```

Open the terminal in the game's root directory and add execution permission to the script:

<BrowserWindow>

```bash
chmod u+x run_bepinex.sh
```

</BrowserWindow>

Now you can run BepInEx by executing the script:

<BrowserWindow>

```bash
./run_bepinex.sh
```

</BrowserWindow>

</TabItem>
</Tabs>

### Running BepInEx through Steam {#bepinex-steam}

<Tabs
    groupId="os"
    defaultValue="win"
    values={[
        {label: 'Windows', value: 'win'},
        {label: 'Linux', value: 'linux'},
        {label: 'macOS', value: 'macos'},
    ]}>
<TabItem value='win'>

On Windows you can run BepInEx through Steam too. Nothing to worry about.

</TabItem>
<TabItem value='linux'>

Open Steam's game library, right-click on the game and click **Properties...**:

:::note
Screenshot needed
:::

Click **Set launch options...**:

:::note
Screenshot needed
:::

And type in:

```bash
./run_bepinex.sh %command%
```

Click **OK** and run the game through Steam.

</TabItem>
<TabItem value='macos'>

Open Steam's game library, right-click on the game and click **Properties...**:

:::note
Screenshot needed
:::

Click **Set launch options...**:

:::note
Screenshot needed
:::

Now, open a terminal in the game's root directory and run:

<BrowserWindow>

```bash
pwd
```

</BrowserWindow>

You'll get the full path to the game's root directory. Copy and paste it into the launch options field and then append `/run_bepinex.sh %command%`:

```bash
"<PWD>/run_bepinex.sh" %command%
```

where `<PWD>` is the full path to the game's root directory.

Click **OK** and run the game through Steam.

</TabItem>
</Tabs>

## Installing RogueLibs {#roguelibs}

<Tabs
    defaultValue="v2"
    values={[
        {label:'RogueLibs v2.x.x', value:'v2'},
        {label:'RogueLibs v3.x.x', value:'v3'},
    ]}>
<TabItem value="v2">

**[Download the latest RogueLibs version](https://github.com/Abbysssal/RogueLibs/releases/latest)**

You need to download only one file - `RogueLibs.dll`.

:::note
Screenshot needed
:::

Go to the BepInEx's directory and put `RogueLibs.dll` into `plugins` directory:

:::note
Screenshot/GIF needed
:::

</TabItem>
<TabItem value="v3">

:::caution
RogueLibs v3.x.x is still in beta! Backup your save files before installing it.
:::

**[Download the latest RogueLibs version](https://github.com/Abbysssal/RogueLibs/releases)**

You need to download only two files: `RogueLibsCore.dll` and `RogueLibsPatcher.dll`.

:::note
Screenshot needed
:::

Go to the BepInEx's directory and put `RogueLibsCore.dll` into `plugins` directory:

:::note
Screenshot/GIF needed
:::

Put `RogueLibsPatcher.dll` into `patchers` (not `plugins`!) directory:

:::note
Screenshot/GIF needed
:::

</TabItem>
</Tabs>

## Installing plugins (aka. mods) {#plugins}

Download the plugins that you want to install (`.dll`s).

And put the `.dll` files in the `BepInEx/plugins` directory.

:::note
Screenshot needed
:::
