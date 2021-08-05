import React, { useEffect, useState } from "react";
import useStorageArray from '../hooks/useStorageArray';
import InventorySlot, { Props as SlotProps } from "../InventorySlot";
import InventoryRow, { getSlots } from '../InventoryRow';
import styles from './index.module.css';

export type Props = {
  items?: (SlotProps | SlotProps[])[],
  children?: React.ReactNode,
  height?: number,
  width?: number,

  interactable?: boolean,
  defaultValues?: string | string[],
  minChoices?: number,
  maxChoices?: number,
  lockChoices?: boolean,
  group?: string,
  onClick?: (e: GridSlotArgs) => void,
  onChange?: (values: string[]) => void,
}
export type GridSlotArgs = {
  uid: string,
  row: number,
  column: number,
}

export type RowInfo = {
  items: SlotProps[],
  type: "normal" | "toolbar",
}

export function getRows(items?: (SlotProps | SlotProps[])[], children?: React.ReactNode, height?: number, width?: number) {
  let rows: RowInfo[] = [];
  let tempRow: SlotProps[] = [];

  const flushRow = (type?: "normal" | "toolbar") => {
    if (width)
      for (let i = tempRow.length; i < width; i++)
        tempRow.push({interactable: false});
    flushRowWithoutFill(type);
  }
  const flushRowWithoutFill = (type?: "normal" | "toolbar") => {
    rows.push({
      items: tempRow,
      type: type || "normal",
    });
    tempRow = [];
  }

  if (items)
    for (let item of items) {
      if (Array.isArray(item)) {
        if (tempRow.length > 0) flushRow();
        for (let subitem of item)
          tempRow.push(subitem);
        flushRow();
      }
      else {
        tempRow.push(item);
        if (tempRow.length === width) flushRow();
      }
    }

  if (tempRow.length > 0) flushRow();

  for (let child of React.Children.toArray(children)) {
    let c = child as any;
    let type: string | null = c?.props?.mdxType;
    if (type === "InventorySlot") {
      tempRow.push({...c.props});
      if (tempRow.length === width) flushRow();
    }
    else if (type === "InventoryRow") {
      if (tempRow.length > 0) flushRow();
      let rowSlots = getSlots(c.props.items, c.props.children, c.props.width || width);
      tempRow.push(...rowSlots);
      flushRowWithoutFill(c.props.type);
    }
  }

  if (tempRow.length > 0) flushRow();

  if (height)
    for (let i = rows.length; i < height; i++) {
      for (let j = 0; j < (width || 1); j++)
      tempRow.push({interactable: false});
      flushRow();
    }

  return rows;
}

export default function ({items, children, height, width,
  interactable, defaultValues, minChoices, maxChoices, lockChoices, group, onClick, onChange}: Props): JSX.Element {

  let MinChoices = minChoices || 0;
  let MaxChoices = maxChoices || 1;

  let rows: RowInfo[] = getRows(items, children, height, width);

  let [values, setValues] = useStorageArray(group ? `inventoryGroups.${group}` : undefined, () => {
    if (!interactable) return [];
    let uids: string[];

    if (defaultValues === undefined) {
      uids = [];
      let withUids = rows.map(r => r.items).reduce((a, b) => a.concat(b)).filter(s => s.uid !== undefined);
      for (let i = 0; i < Math.min(MinChoices, withUids.length); i++)
        uids.push(withUids[i].uid!);
    }
    else {
      uids = Array.isArray(defaultValues) ? defaultValues : [defaultValues];
    }

    if (MinChoices > uids.length || MaxChoices < uids.length)
      throw new Error(`Invalid amount of default values: ${MinChoices} ≤ *${uids.length}* ≤ ${MaxChoices}.`);
    return uids;
  });
  
  const handleChange = (index: number, uid: string) => {
    let newValues: string[];
    if (index == -1) {
      if (lockChoices && values.length >= MaxChoices) return;
      newValues = values.slice();
      while (newValues.length >= MaxChoices)
        newValues.shift();
      newValues.push(uid);
      setValues(newValues);
    }
    else {
      if (values.length <= MinChoices) return;
      newValues = values.slice();
      newValues.splice(index, 1);
      setValues(newValues);
    }
    if (onChange) onChange(newValues);
  }
  const clickHandler = (row: number, column: number, uid: string) => {
    if (interactable) handleChange(values.indexOf(uid), uid);
    if (onClick) onClick({ uid: uid, row: row, column: column });
  }

  return (
    <div className={styles.container}>
      {rows.map((row, rowIndex) => {
        for (let slot of row.items) {
          if (interactable && slot.interactable === undefined) slot.interactable = true;
          let selected = slot.uid && values.includes(slot.uid);
          if (selected) slot.type = "selected";
        }
        return <InventoryRow key={rowIndex} type={row.type} items={row.items}
          onClick={e => clickHandler(rowIndex, e.index, e.uid)}/>;
      })}
    </div>
  );
}