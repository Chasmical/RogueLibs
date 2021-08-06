import React, { useState } from "react";
import useSelector from "../hooks/useSelector";
import clsx from 'clsx';
import InventorySlot, { Props as SlotProps } from "../InventorySlot";
import styles from './index.module.css';

export type Props = {
  items?: SlotProps[],
  children?: React.ReactNode,
  width?: number,

  interactable?: boolean,
  type?: "normal" | "toolbar",
  onClick?: (e: RowSlotArgs) => void,

  defaultValues?: string | string[] | null | (() => string | string[] | null),
  minChoices?: number,
  maxChoices?: number,
  lockChoices?: boolean,
  group?: string,
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

export default function ({items, children, width, interactable, type, onClick, group, ...props}: Props): JSX.Element {

  let slots = getSlots(items, children, width);

  let Group = group ? `inventory.${group}` : undefined;
  const [values, controller] = useSelector({
    ...props,
    group: Group,
    defaultValuesLookup: () => slots.map(i => i.uid),
  });

  const clickHandler = (index: number, uid: string) => {
    if (interactable) controller.toggle(uid);
    if (onClick) onClick({ uid: uid, index: index });
  }

  return (
    <div className={clsx(styles.row, type == "toolbar" && styles.toolbar)}>
      {slots.map((slot, num) => {
        if (interactable && slot.interactable === undefined) slot.interactable = true;
        if (slot.uid) {
          if (values.includes(slot.uid)) slot.type = "selected";
          else if (controller.isLocked(slot.uid)) slot.type = "locked";
        }
        if (type == "toolbar") {
          slot.tooltip = num + 1;
          slot.tooltipColor = undefined;
        }
        return <InventorySlot key={num} {...slot}
          onClick={() => slot.uid !== undefined && clickHandler(num, slot.uid)}/>;
      })}
    </div>
  );
}