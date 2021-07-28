import React, { useState } from 'react';
import styles from './index.module.css';
import InventorySlot, { Props as SlotProps } from '../InventorySlot';
import InventoryRow, { GetSlots } from '../InventoryRow';

export type Props = {
  items?: (SlotProps | SlotProps[])[],
  children?: React.ReactNode,
  width?: number,
  height?: number,
  interactable?: boolean,
  onChange?: (e: InventoryChangeProps) => void,
}
export type InventoryChangeProps = {
  index: number,
  row: number,
  column: number,
}

export function GetSlotsInRows(items?: (SlotProps | SlotProps[])[], children?: React.ReactNode, width?: number, height?: number): SlotProps[][] {
  let slots: SlotProps[][] = [];
  let newRow: SlotProps[] = [];

  if (items)
    for (let item of items) {
      if (Array.isArray(item)) {
        if (newRow.length > 0) {
          if (width)
            for (let i = newRow.length; i < width; i++)
              newRow.push({type: null});
          slots.push(newRow);
          newRow = [];
        }
        let row = [...item];
        if (width)
          for (let i = row.length; i < width; i++)
            row.push({type: null});
        slots.push(row);
      }
      else if (item !== null && item !== undefined && item !== false && item !== true) {
        newRow.push(item);
        if (newRow.length === width) {
          slots.push(newRow);
          newRow = [];
        }
      }
    }

  if (newRow.length > 0) {
    if (width)
      for (let i = newRow.length; i < width; i++)
        newRow.push({type: null});
    slots.push(newRow);
    newRow = [];
  }

  for (let child of React.Children.toArray(children)) {
    let c = child as any;
    let type = c?.props?.mdxType;
    if (type == "InventoryRow") {
      if (newRow.length > 0) {
        if (width)
          for (let i = newRow.length; i < width; i++)
            newRow.push({type: null});
        slots.push(newRow);
        newRow = [];
      }
      let row = GetSlots(c.props.items, c.props.children, c.props.width || width);
      slots.push(row);
    }
    else if (type == "InventorySlot") {
      newRow.push({...c.props});
      if (newRow.length === width) {
        slots.push(newRow);
        newRow = [];
      }
    }
  }

  if (newRow.length > 0) {
    if (width)
      for (let i = newRow.length; i < width; i++)
        newRow.push({type: null});
    slots.push(newRow);
    newRow = [];
  }

  if (height)
    for (let i = slots.length; i < height; i++) {
      let row: SlotProps[] = [];
      if (width)
        for (let j = 0; j < width; j++)
          row.push({type: null});
      else row.push({type: null});
      slots.push(row);
    }

  return slots;
}

export default function ({items, children, width, height, interactable, onChange}: Props): JSX.Element {

  let rows = GetSlotsInRows(items, children, width, height);

  const [index, setIndex] = useState(-1);

  const clickHandler = (myIndex: number, rowIndex: number, columnIndex: number): void => {
    let newIndex = myIndex == index ? -1 : myIndex;
    setIndex(newIndex);
    if (onChange) onChange({
      index: myIndex,
      row: rowIndex,
      column: columnIndex,
    })
  }

  let slotIndex = 0;
  return (
    <div className={styles.container}>
      {rows.map((row, rowIndex) => (
        <div className={styles.row}>
          {row.map((slot, columnIndex) => {
            let i = slotIndex++;

            let hoverable = interactable && slot.type !== null;
            if (hoverable) slot.type = interactable && index == i ? "selected" : "normal";

            return (
              <InventorySlot key={i} {...slot}
                onClick={hoverable ? () => clickHandler(i, rowIndex, columnIndex) : undefined}/>
            );
          })}
        </div>
      ))}
    </div>
  );
}