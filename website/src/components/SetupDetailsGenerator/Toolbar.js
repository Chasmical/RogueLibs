import React, { useState } from 'react';
import useBaseUrl from '@docusaurus/useBaseUrl';
import styles from './Toolbar.module.css';

import InventorySlot from './InventorySlot';

export default function ({items, ...props}) {
  items = items || [];
  return (
    <div className={styles.toolbar}>
      <img className={styles.outline} src={useBaseUrl("/img/SetupDetailsGenerator/ToolbarOutline.png")}/>
      <div className={styles.slots}>
        <InventorySlot tooltip="1" {...items[0]}/>
        <InventorySlot tooltip="2" {...items[1]}/>
        <InventorySlot tooltip="3" {...items[2]}/>
        <InventorySlot tooltip="4" {...items[3]}/>
        <InventorySlot tooltip="5" {...items[4]}/>
      </div>
    </div>
  );
};