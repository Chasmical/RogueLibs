import React, { useState } from 'react';
import styles from './index.module.css';
import InventoryRow, { Props as RowProps, GetSlots } from '../InventoryRow';

export default function ({items, children, width, ...props}: RowProps): JSX.Element {

  let slots = GetSlots(items, children, width);
  for (let i = 0; i < slots.length; i++)
    slots[i].tooltip = (i + 1).toString();

  return (
    <div className={styles.toolbar}>
      <InventoryRow items={slots} {...props}/>
    </div>
  );
}
