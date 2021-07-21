import React, { useState } from 'react';
import useBaseUrl from '@docusaurus/useBaseUrl';
import styles from './index.module.css';

export type Props = {
  sprite?: string,
  tooltip?: string,
  tooltipColor?: string,
  count?: string,
  countColor?: string,
  type?: "normal" | "selected" | "locked" | null,
  onClick?: () => void,
}

export default function ({sprite, tooltip, tooltipColor, count, countColor, type, onClick}: Props): JSX.Element {

  let interactable = type !== undefined;
  type = type || "normal";

  return (
    <div className={styles.container} onClick={onClick} style={{cursor: interactable ? "pointer" : "inherit"}}>
      {interactable &&
        <img key="hoverslot" className={styles.hoverslot} src={useBaseUrl(`/img/components/InventorySlot/${type}Hover.png`)}/>
      }
      <img key="slot" className={styles.slot} src={useBaseUrl(`/img/components/InventorySlot/${type}.png`)}/>

      {sprite &&
        <img key="sprite" className={styles.sprite} src={sprite}/>
      }

      {tooltip &&
        <span key="tooltip" className={styles.tooltip}>
          <span style={{color: tooltipColor || "#FFED00"}}>
            {tooltip}
          </span>
        </span>
      }

      {count &&
        <span key="count" className={styles.count}>
          <span style={{color: countColor || "#FFFFFF"}}>
            {count}
          </span>
        </span>
      }
    </div>
  );
}