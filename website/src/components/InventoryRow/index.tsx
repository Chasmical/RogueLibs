import React, { useState } from "react";
import useStorageArray from "../hooks/useStorageArray";
import clsx from 'clsx';
import InventorySlot, { Props as SlotProps } from "../InventorySlot";
import styles from './index.module.css';

export type Props = {
  items?: SlotProps[],
  children?: React.ReactNode,
  width?: number,

  interactable?: boolean,
  defaultValues?: string | string[],
  minChoices?: number,
  maxChoices?: number,
  lockChoices?: boolean,
  group?: string,
  type?: "normal" | "toolbar",
  onClick?: (e: RowSlotArgs) => void,
  onChange?: (values: string[]) => void,
}
export type RowSlotArgs = {
  uid: string,
  index: number,
}

export function getSlots(items?: SlotProps[], children?: React.ReactNode, width?: number) {
  let slots: SlotProps[] = items || [];

  for (let child of React.Children.toArray(children)) {
    let c = child as any;
    let type: string | null = c?.props?.mdxType;
    if (type === "InventorySlot") {
      slots.push({...c.props});
    }
  }

  if (width)
    for (let i = slots.length; i < width; i++)
      slots.push({interactable: false});

  return slots;
}

export default function ({items, children, width,
  interactable, defaultValues, minChoices, maxChoices, lockChoices, group, type, onClick, onChange}: Props): JSX.Element {

  let MinChoices = minChoices || 0;
  let MaxChoices = maxChoices || 1;

  let slots = getSlots(items, children, width);

  const [values, setValues] = useStorageArray(group ? `inventoryGroups.${group}` : undefined, () => {
    if (!interactable) return [];
    let uids: string[];

    if (defaultValues === undefined) {
      uids = [];
      let withUids = slots.filter(s => s.uid !== undefined);
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
  const clickHandler = (index: number, uid: string) => {
    if (interactable) handleChange(values.indexOf(uid), uid);
    if (onClick) onClick({ uid: uid, index: index });
  }

  return (
    <div className={clsx(styles.row, type == "toolbar" && styles.toolbar)}>
      {slots.map((slot, num) => {
        if (slot.uid && values.includes(slot.uid)) slot.type = "selected";
        if (type == "toolbar") {
          slot.tooltip = num + 1;
          slot.tooltipColor = undefined;
        }
        if (interactable && slot.interactable === undefined) slot.interactable = true;
        return <InventorySlot key={num} {...slot}
          onClick={() => slot.uid !== undefined && clickHandler(num, slot.uid)}/>;
      })}
    </div>
  );
}