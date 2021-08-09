import React, { useEffect, useState } from "react";
import useSelector, { SelectorParameters } from "../hooks/useSelector";
import InventorySlot, { Props as SlotProps } from "../InventorySlot";
import InventoryRow, { getSlots } from '../InventoryRow';
import styles from './index.module.css';

export type Props = SelectorParameters & {
  items?: (SlotProps | SlotProps[])[],
  children?: React.ReactNode,
  height?: number,
  width?: number,

  onClick?: (e: GridSlotArgs) => void,
  interactive?: boolean,
}
export type GridSlotArgs = {
  uid: string | undefined,
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
        tempRow.push({hoverable: false});
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
      tempRow.push({hoverable: false});
      flushRow();
    }

  return rows;
}

export default function ({items, children, height, width, onClick, interactive, ...selectorParameters}: Props): JSX.Element {

  let rows: RowInfo[] = getRows(items, children, height, width);

  let availableValues: (string | undefined)[] = [];
  for (let row of rows)
    for (let slot of row.items)
      availableValues.push(slot.uid);

  if (selectorParameters.group) selectorParameters.group = `inventory.${selectorParameters.group}`;
  const [values, controller] = useSelector(availableValues, selectorParameters);

  const clickHandler = (row: number, column: number, uid: string | undefined) => {
    if (interactive && uid) controller.toggle(uid);
    if (onClick) onClick({ uid: uid, row: row, column: column });
  }

  return (
    <div className={styles.container}>
      {rows.map((row, rowIndex) => {
        for (let slot of row.items) {
          if (interactive && slot.hoverable === undefined) slot.hoverable = true;
          if (slot.uid) {
            if (values.includes(slot.uid)) slot.type = "selected";
            else if (controller.isLocked(slot.uid)) slot.type = "locked";
          }
        }
        return <InventoryRow key={rowIndex} type={row.type} items={row.items}
          onClick={e => clickHandler(rowIndex, e.index, e.uid)}/>;
      })}
    </div>
  );
}