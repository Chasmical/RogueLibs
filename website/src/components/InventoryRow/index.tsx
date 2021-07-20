import React, { useState } from 'react';
import styles from './index.module.css';
import InventorySlot, { Props as SlotProps } from '../InventorySlot';

export type Props = {
  items?: SlotProps[],
  children: React.ReactNode,
  minCount?: number,
}

export default function({items, children, minCount}: Props): JSX.Element {

  items = items || [];
  let Children = React.Children.toArray(children);
  for (let c of Children) {
    let type: string | undefined = (c as any)?.props?.mdxType;
    if (type == "InventorySlot") items.push({...(c as any).props});
  }

  minCount = minCount || 5;
  for (let i = items.length; i < minCount; i++)
    items.push({});
  for (let i = 0; i < items.length; i++) {
    items[i].tooltip = `${i + 1}`;
    items[i].tooltipColor = undefined;
  }

  return (
    <div className={styles.row}>
      {items.map((item, i) => <InventorySlot key={i} {...item}/>)}
    </div>
  );
}