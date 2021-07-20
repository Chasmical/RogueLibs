import React from "react";
import InventorySlot, { Props as SlotProps } from "../InventorySlot";
import styles from './index.module.css';

export type Props = {
  children?: React.ReactNode,
  width?: number,
}

export function getSlots(children: React.ReactNode, width?: number): SlotProps[] {
  let items: SlotProps[] = [];

  for (let child of React.Children.toArray(children)) {
    let c = child as any;
    let type = c?.props?.mdxType;
    if (type === "InventorySlot")
      items.push(c.props);
  }

  if (width !== undefined) {
    if (items.length < width) {
      for (let i = items.length; i < width; i++)
        items.push({});
    }
    else if (items.length > width) {
      items.splice(items.length - 1, items.length - width);
    }
  }

  return items;
}

export default function ({children, width}: Props): JSX.Element {

  width = width || 5;
  let items = getSlots(children, width);

  return (
    <div className={styles.row}>
      {items.map((item, i) => <InventorySlot key={i} {...item}/>)}
    </div>
  );
}