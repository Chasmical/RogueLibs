import React, { useState } from "react";
import useSelector, { SelectorParameters } from "../hooks/useSelector";
import clsx from 'clsx';
import InventorySlot, { Props as SlotProps } from "../InventorySlot";
import styles from './index.module.css';

export type Props = SelectorParameters & {
  items?: SlotProps[],
  children?: React.ReactNode,
  width?: number,

  type?: "normal" | "toolbar",
  onClick?: (e: RowSlotArgs) => void,
  interactive?: boolean,
}
export type RowSlotArgs = {
  uid: string | undefined,
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
      slots.push({hoverable: false});

  return slots;
}

export default function ({items, children, width, type, onClick, interactive, ...selectorParameters}: Props): JSX.Element {

  let slots = getSlots(items, children, width);

  if (selectorParameters.group) selectorParameters.group = `inventory.${selectorParameters.group}`;
  const [values, controller] = useSelector(slots.map(s => s.uid), selectorParameters);

  const clickHandler = (index: number, uid: string | undefined) => {
    if (interactive && uid) controller.toggle(uid);
    if (onClick) onClick({ uid: uid, index: index });
  }

  return (
    <div className={clsx(styles.row, type == "toolbar" && styles.toolbar)}>
      {slots.map((slot, num) => {
        if (interactive && slot.hoverable === undefined) slot.hoverable = true;
        if (slot.uid) {
          let selected = values.includes(slot.uid);
          let isLocked = controller.isLocked(slot.uid);
          if (selected) slot.type = "selected";
          else if (isLocked) slot.type = "locked";
          if (isLocked) slot.cantClick = true;
        }
        if (type == "toolbar") {
          slot.tooltip = num + 1;
          slot.tooltipColor = undefined;
        }
        return <InventorySlot key={num} {...slot}
          onClick={() => clickHandler(num, slot.uid)}/>;
      })}
    </div>
  );
}