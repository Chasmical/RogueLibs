# Usable Items

import Tabs from '@site/src/components/Tabs';
import TabItem from '@site/src/components/TabItem';
import useBaseUrl from '@docusaurus/useBaseUrl';

## Making items usable {#making-usable}

Just implement the `IItemUsable` interface in your item's class:

```csharp title="MyUsableItem.cs"
// highlight-next-line
public class MyUsableItem : CustomItem, IItemUsable
{
    // highlight-next-line
    public bool UseItem() { /* ... */ }
}
```

`UseItem`'s return value indicates whether the item was successfully used. Returning `true` will also play an animation. When returning `false`, you can play a `"CantDo"` sound, and optionally make the current owner say why the item cannot be used:

```csharp
        if (cantUse)
        {
            gc.audioHandler.Play(Owner, "CantDo");
            Owner.SayDialogue("CantUseItemBecause...");
            // don't forget to create a dialogue with that id
            return false;
        }
```

:::info
You're responsible for decrementing the item's `Count`. So, don't forget to do that.
:::

## Examples {#examples}

import CodeSnippet from '@site/src/components/CodeSnippet';

import JokeBook from '!!raw-loader!@site/../RogueLibsCore.Test/Tests/Items/JokeBook.cs';
import AdrenalineShot from '!!raw-loader!@site/../RogueLibsCore.Test/Tests/Items/AdrenalineShot.cs';
import WildBypasser from '!!raw-loader!@site/../RogueLibsCore.Test/Tests/Items/WildBypasser.cs';

<Tabs
    defaultValue="jokebook"
    values={[
        {label:'Joke Book', value:'jokebook'},
        {label:'Adrenaline Shot', value:'adrenalineshot'},
        {label:'Wild Bypasser', value:'wildbypasser'},
    ]}>
<TabItem value="jokebook">

A simple usable item that allows the player to use the Joke ability.

<CodeSnippet>{JokeBook}</CodeSnippet>

</TabItem>
<TabItem value="adrenalineshot">

A simple usable item that gives the player an effect called "Adrenaline". You can see Adrenaline effect's implementation in [Creating a Custom Effect: Examples](../traits/create-effect#examples).

<CodeSnippet>{AdrenalineShot}</CodeSnippet>

</TabItem>
<TabItem value="wildbypasser">

A more complicated usable item, based on Wall Bypasser's code (see `ItemFunctions.UseItem`).

<CodeSnippet>{WildBypasser}</CodeSnippet>

</TabItem>
</Tabs>