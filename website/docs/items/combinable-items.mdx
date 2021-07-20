# Combinable Items

import Tabs from '@site/src/components/Tabs';
import TabItem from '@site/src/components/TabItem';
import useBaseUrl from '@docusaurus/useBaseUrl';
import ColorSquare from '@site/src/components/ColorSquare';

## Making items combinable {#making-combinable}

Just implement the `IItemCombinable` interface in your item's class:

```csharp title="MyCombinableItem.cs"
// highlight-next-line
public class MyCombinableItem : CustomItem, IItemCombinable
{
    // highlight-start
    public bool CombineFilter(InvItem other) { /* ... */ }
    public bool CombineItems(InvItem other) { /* ... */ }
    public CustomTooltip CombineTooltip(InvItem other) { /* ... */ }
    public CustomTooltip CombineCursorText(InvItem other) { /* ... */ }
    // highlight-end
}
```

Plus, your item's type must be `"Combine"`:

```csharp
    public override void SetupDetails()
    {
        // highlight-next-line
        Item.itemType = ItemTypes.Combine;
        /* ... */
    }
```

`CombineFilter` determines what items will be highlighted, when combining the current item.

`CombineItems` combines the current item with the other one. The return value indicates whether it was a success or not. Usually you'd just play a `"CantDo"` sound, if the items cannot be combined. Returning `true` will also play an animation.

`CombineTooltip` determines the tooltip in the upper-left corner of the inventory slot. Text set to `null` will default to an empty string, and Color set to `null` will default to <ColorSquare color='#FFED00'/>. [See the tool below](#slot-preview).

`CombineCursorText` determines the cursor text when hovering over the item. You can also specify the cursor text's color. Text set to `null` will default to "Combine", and Color set to `null` will default to <ColorSquare color='#FFFFFF'/>.

### Inventory Slot Preview {#slot-preview}

Wanna see how your `CombineTooltip` will look in the game? Check out this small tool:

import InventorySlot from '@site/src/components/InventorySlot';
import { useState } from 'react';

export function PreviewTooltip ({props}) {
  const [sprite, setSprite] = useState(useBaseUrl(`/img/TestItem.png`));
  const [tooltipColor, setTooltipColor] = useState("#FFED00");
  const spriteHandler = e => {
    if (e.target.files[0]) {
      const reader = new FileReader();
      reader.addEventListener("load", () => setSprite(reader.result));
      reader.readAsDataURL(e.target.files[0]);
    }
  };
  const [text, setText] = useState("$123");
  return (
    <div style={{padding: '10px', border: '5px dashed var(--ifm-menu-color-background-hover)', width: 'max-content'}}>
      <input type="file" accept="image/*"
        onChange={spriteHandler} style={{margin: '5px'}}/>
      <div style={{margin: '5px'}}>
        <InventorySlot sprite={sprite} tooltip={text} tooltipColor={tooltipColor}/>
      </div>
      <input type="text" placeholder="$123" onChange={e => setText(e.target.value)} style={{fontSize: '22px', margin: '5px'}}/>
      <input type="color" value={tooltipColor} onChange={e => setTooltipColor(e.target.value)}/>
    </div>
  );
};

<PreviewTooltip/>

## Examples {#examples}

import CodeSnippet from '@site/src/components/CodeSnippet';

import AmmoBox from '!!raw-loader!@site/../RogueLibsCore.Test/Tests/Items/AmmoBox.cs';
import SpiceRack from '!!raw-loader!@site/../RogueLibsCore.Test/Tests/Items/SpiceRack.cs';

<Tabs
    defaultValue="ammobox"
    values={[
        {label:'Ammo Box', value:'ammobox'},
        {label:'Spice Rack', value:'spicerack'},
    ]}>
<TabItem value="ammobox">

A pretty complicated example with a lot of math.

<CodeSnippet>{AmmoBox}</CodeSnippet>

</TabItem>
<TabItem value="spicerack">

A simple example, with custom hooks to keep track of seasoned items.

<CodeSnippet>{SpiceRack}</CodeSnippet>

</TabItem>
</Tabs>