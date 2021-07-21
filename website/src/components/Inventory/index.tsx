import React, { useState } from 'react';
import InventorySlot, { Props as SlotProps } from "../InventorySlot";
import { getSlots } from '../InventoryRow';
import styles from './index.module.css';

export type Props = {
  children?: React.ReactNode,
  width?: number,
  height?: number,
  onClick?: (e: ClickEventData) => void,
}
export type ClickEventData = {
  x: number,
  y: number,
  item: SlotProps,
}

export function getContents(children: React.ReactNode, width?: number, height?: number): SlotProps[] {
  let items: SlotProps[] = [];
  let extraRow: SlotProps[] | null = null;

  for (let child of React.Children.toArray(children)) {
    let c = child as any;
    let type = c?.props?.mdxType;
    if (type === "InventoryRow") {
      if (extraRow !== null) {
        items.push(...extraRow);
        if (width !== undefined)
          for (let i = extraRow.length; i < width; i++)
            items.push({type: null});
        extraRow = null;
      }
      let rowItems = getSlots(c.props.children, width);
      items.push(...rowItems);
    }
    else if (type === "InventorySlot") {
      if (extraRow === null) extraRow = [];
      extraRow.push(c.props);
      
      if (width !== undefined && extraRow.length == width) {
        items.push(...extraRow);
        extraRow = null;
      }
    }
  }

  if (extraRow !== null) {
    items.push(...extraRow);
    if (width !== undefined)
      for (let i = extraRow.length; i < width; i++)
        items.push({type: null});
    extraRow = null;
  }

  if (height !== undefined && width !== undefined) {
    let total = height * width;
    if (items.length < total) {
      for (let i = items.length; i < total; i++)
        items.push({type: null});
    }
    else if (items.length > total) {
      items.splice(total - 1, items.length - total);
    }
  }

  return items;
}

export default function ({children, width, height}: Props): JSX.Element {

  width = width || 5;
  height = height || 4;
  let items = getContents(children, width, height);

  const [index, setIndex] = useState(-1);

  const clickHandler = (myIndex: number): void => {
    if (index == myIndex) setIndex(-1);
    else setIndex(myIndex);
  }

  return (
    <div className={styles.inventory} style={{
      gridTemplateColumns: `repeat(${width}, auto)`,
      gridTemplateRows: `repeat(${height}, auto)`,
    }}>
      {items.map((item, i) => <InventorySlot type={item.type !== undefined ? item.type : (index == i ? "selected" : "normal")}
        onClick={() => clickHandler(i)} key={i} {...item}/>)}
    </div>
  );
}