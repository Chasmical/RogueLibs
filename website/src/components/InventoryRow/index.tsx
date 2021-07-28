import React, { useState } from 'react';
import useBaseUrl from '@docusaurus/useBaseUrl';
import styles from './index.module.css';
import InventorySlot, { Props as SlotProps } from '../InventorySlot';

export type Props = {
  items?: SlotProps[],
  children?: React.ReactNode,
  width?: number,
  interactable?: boolean,
  onChange?: (index: number) => void,
}

export function GetSlots(items?: SlotProps[], children?: React.ReactNode, width?: number): SlotProps[] {
  let slots = items || [];

  for (let child of React.Children.toArray(children)) {
    let c = child as any;
    let type = c?.props?.mdxType;
    if (type == "InventorySlot") {
      slots.push({...c.props});
    }
  }

  if (width)
    for (let i = slots.length; i < width; i++)
      slots.push({type: null});

  return slots;
}

export default function ({items, children, width, interactable, onChange}: Props): JSX.Element {

  let slots = GetSlots(items, children, width);

  const [index, setIndex] = useState(-1);

  const clickHandler = (myIndex: number): void => {
    if (myIndex == index) setIndex(-1);
    else setIndex(myIndex);
    if (onChange) onChange(myIndex);
  }

  return (
    <div className={styles.container}>
      {slots.map((slot, i) => {

        let hoverable = interactable && slot.type !== null;
        if (hoverable) slot.type = interactable && index == i ? "selected" : "normal";

        return (
          <InventorySlot key={i} {...slot}
            onClick={hoverable ? () => clickHandler(i) : undefined}/>
        );
      })}
    </div>
  );
}