import React, { useState } from 'react';
import useBaseUrl from '@docusaurus/useBaseUrl';
import CodeBlock from '@theme/CodeBlock';
import styles from './index.module.css';

import SettingButton from './SettingButton';
import InventorySlot from './InventorySlot';
import Toolbar from './Toolbar';
import Dropdown from '../Dropdown';
import DropdownHeader from '../DropdownHeader';
import DropdownOption from '../DropdownOption';

export default function ({...props}) {
  const [itemSprite, setItemSprite] = useState(useBaseUrl(`/img/SetupDetailsGenerator/TestItem.png`));
  const [itemSpriteFileName, setItemSpriteFileName] = useState("TestItem.png");
  const spriteHandler = e => {
    if (e.target.files[0]) {
      const reader = new FileReader();
      reader.addEventListener("load", () => {
        setItemSprite(reader.result);
        setItemSpriteFileName(e.target.files[0].name);
      });
      reader.readAsDataURL(e.target.files[0]);
    }
  };

  const [itemType, setItemType] = useState("Food");
  const [displayItemType, setDisplayItemType] = useState("Food");
  const [itemCategories, setItemCategories] = useState([]);

  const [initCount, setInitCount] = useState(1);
  const [rewardCount, setRewardCount] = useState(null);
  const initCountHandler = e => {
    if (e.target.valueAsNumber > 99999) e.target.valueAsNumber = 99999;
    if (isNaN(e.target.valueAsNumber)) setInitCount(1);
    else setInitCount(e.target.valueAsNumber);
  };
  const rewardCountHandler = e => {
    if (e.target.valueAsNumber > 99999) e.target.valueAsNumber = 99999;
    if (isNaN(e.target.valueAsNumber)) setRewardCount(null);
    else setRewardCount(e.target.valueAsNumber);
  };

  const codeGen = () => {
    let ops = [];
    ops.push(`itemType = ItemTypes.${itemType}`);
    if (initCount != 1) ops.push(`initCount = ${initCount}`);
    if (rewardCount !== null && rewardCount != initCount)
      ops.push(`rewardCount = ${rewardCount}`);

    return ops.map(line => `    Item.${line};\n`).join('');
  };

  return (
    <div>
      <div className={styles.wrapper}>
        <div className={styles.general}>
          <Dropdown minChoices={1} onChange={(values, action, value) => { setItemType(values[0].value); setDisplayItemType(values[0].label); }}>
            <DropdownHeader>
              {"Item Type: " + displayItemType}
            </DropdownHeader>
            <DropdownOption value="Food"/>
            <DropdownOption value="Consumable"/>
            <DropdownOption value="Tool"/>
            <DropdownOption value="Combine" label="Combinable"/>
            <DropdownOption value="Wearable"/>
            <DropdownOption value="WeaponMelee" label="Melee Weapon"/>
            <DropdownOption value="WeaponThrown" label="Thrown Weapon"/>
            <DropdownOption value="WeaponProjectile" label="Projectile Weapon"/>
          </Dropdown>
          <br/>
          <Dropdown minChoices={0} maxChoices={999} defaultValues={[]} onChange={(values) => setItemCategories(values.map(v => v.value))}>
            <DropdownHeader>
              {"Item Categories (expand):"}
            </DropdownHeader>
            <DropdownOption value="Social"
              tooltip={"Any kind of social interactions and manipulation."}/>
            <DropdownOption value="Stealth"
              tooltip={"Stealth and stuff."}/>
            <DropdownOption value="Movement"
              tooltip={"Everything related to movement."}/>
            <DropdownOption value="Defense"
              tooltip={"Everything that increases the player's survivability."}/>
            <DropdownOption value="Melee"
              tooltip={"Everything that's related to melee weapons, but not the melee weapons themselves."}/>
            <DropdownOption value="Guns"
              tooltip={"Everything that's related to guns, but not the guns themselves."}/>
            <DropdownOption value="Trade"
              tooltip={"Everything that's related to trading."}/>
            <DropdownOption value="Weird"
              tooltip={"Magic, religion and occult."}/>

            <DropdownOption value="Food" recommended={itemType == "Food"}
              tooltip={"Food and items related to food."}/>
            <DropdownOption value="Drugs" recommended={itemType == "Consumable"}
              tooltip={"Drugs and ingestible/inhalable non-drugs."}/>
            <DropdownOption value="Alcohol" recommended={itemType == "Food"}
              tooltip={"Alcohol and items related to alcohol."}/>
            <DropdownOption value="Health" recommended={itemType == "Consumable"}
              tooltip={"Medicine and stuff related to medicine."}/>
            <DropdownOption value="Technology" recommended={itemType == "Tool" || itemType == "Combine"}
              tooltip={"Anything related to the technological or scientific progress."}/>
            <DropdownOption value="Usable" recommended={itemType == "Tool"}
              tooltip={"Items and tools that are usable directly."}/>
            <DropdownOption value="NonUsableTool" label="Non-Usable Tool" recommended={itemType == "Tool"}
              tooltip="Tools that are not usable directly, but rather on certain objects, like doors, windows or safes."/>

            <DropdownOption value="Weapons" recommended={itemType.startsWith("Weapon") || itemType == "Wearable"}
              tooltip={"Weapons and armor."}/>
            <DropdownOption value="NonStandardWeapons" label="Non-Standard Weapons" recommended={itemType.startsWith("Weapon")}
              tooltip={"\"Unusual\" weapons, that you wouldn't normally find on the streets, like Freeze Rays and Rocket Launchers."}/>
            <DropdownOption value="NonStandardWeapons2" label="Non-Standard Weapons 2" recommended={itemType.startsWith("Weapon")}
              tooltip={"\"Unusual\" weapons, but the ones that can be harmless, like Leaf Blowers, Water Pistols and Tranquilizer Guns."}/>
            <DropdownOption value="NonViolent" label="Non-Violent" recommended={itemType.startsWith("Weapon")}
              tooltip={"Harmless weapons, plus, thrown weapons that don't cause explosive damage."}/>
            <DropdownOption value="NotRealWeapons" label="Not Real Weapons" recommended={itemType.startsWith("Weapon")}
              tooltip={"\"Weapons\" that are not supposed to be used as weapons, like Oil Container and Research Gun."}/>

            <DropdownOption value="MeleeAccessory" label="Melee Accessory"
              tooltip={"Items that affect or are affected by melee weapons."}/>
            <DropdownOption value="GunAccessory" label="Gun Accessory"
              tooltip={"Items that affect or are affected by ranged weapons."}/>
          </Dropdown>
        </div>
        <div className={styles.uploadSprite}>
          <input type="file" accept="image/*"
            onChange={spriteHandler}/>
        </div>
        <div className={styles.downloadSprite}>
          <a href={itemSprite} download={itemSpriteFileName}>Download current image</a>
        </div>
        <div className={styles.inventoryPreview}>
          <div className={styles['inventoryPreview-zoom']}>
            <InventorySlot sprite={itemSprite} tooltip="1" count={initCount}/>
          </div>
          <div className={styles['inventoryPreview-view']}>
            <InventorySlot sprite={itemSprite} tooltip="1" count={initCount}/>
          </div>
          <div className={styles['inventoryPreview-settings']}>
            <input type="button" value="cfg"/>
            <input type="button" value="cfg"/>
            <input type="button" value="cfg"/>
            <input type="button" value="cfg"/>
          </div>
        </div>
        <div className={styles.counts}>
          <span>Initial count: </span>
          <input className={styles.numInput} type="number" min='0' max='99999' placeholder={initCount} onChange={initCountHandler}/>
          <span>Reward count: </span>
          <input className={styles.numInput} type="number" min='0' max='99999' placeholder={initCount} onChange={rewardCountHandler}/>
        </div>
      </div>
      <div>
        <Toolbar items={[
          {sprite: itemSprite, tooltip: '1', count: initCount},
          {sprite: itemSprite, tooltip: '2', count: rewardCount !== null ? rewardCount : initCount},
          {sprite: itemSprite, tooltip: '3'},
          {sprite: itemSprite, tooltip: '4'},
          {sprite: itemSprite, tooltip: '5'},
        ]}/>
      </div>
      <br/>
      {itemCategories.length > 0 &&
        <CodeBlock className="csharp">
          {`[ItemCategories(${itemCategories.map(c => 'RogueCategories.' + c).join(', ')})]`}
        </CodeBlock>
      }
      <CodeBlock className="csharp">
        {"pubic override void SetupDetails()\n"}
        {"{\n"}
        {codeGen()}
        {"}"}
      </CodeBlock>
    </div>
  );
}