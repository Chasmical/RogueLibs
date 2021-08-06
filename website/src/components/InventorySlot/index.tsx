import React, { useState } from 'react';
import useBaseUrl from '@docusaurus/useBaseUrl';
import styles from './index.module.css';

export type Props = {
  uid?: string,

  sprite?: string,
  tooltip?: string | number,
  tooltipColor?: string,
  count?: string | number,
  countColor?: string,

  interactable?: boolean,
  type?: "normal" | "selected" | "locked",
  onClick?: () => void,
}

export default function ({sprite, tooltip, tooltipColor, count, countColor, interactable, type, onClick}: Props): JSX.Element {

  type = type || "normal";

  return (
    <div className={styles.container} onClick={onClick} style={{cursor: interactable ? "pointer" : "inherit"}}>
      {interactable &&
        <img key="hoverslot" className={styles.hoverslot} src={useBaseUrl(`/img/components/InventorySlot/${type}Hover.png`)}/>
      }
      <img key="slot" className={styles.slot} src={useBaseUrl(`/img/components/InventorySlot/${type}.png`)}/>

      {sprite &&
        <img key="sprite" style={{opacity: type == "locked" ? 0.15625 : 1}} className={styles.sprite} src={sprite}/>
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