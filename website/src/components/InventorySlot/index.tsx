import React, { useState } from 'react';
import useBaseUrl from '@docusaurus/useBaseUrl';
import styles from './index.module.css';

export type Props = {
  sprite?: string,
  tooltip?: string | number,
  tooltipColor?: string,
  count?: string | number,
  countColor?: string,

  type?: "normal" | "selected" | "locked",
  onClick?: () => void,
  hoverable?: boolean,
  
  uid?: string,
}

export default function ({sprite, tooltip, tooltipColor, count, countColor, hoverable, type, onClick}: Props): JSX.Element {

  type = type || "normal";

  return (
    <div className={styles.container} onClick={onClick} style={{cursor: hoverable ? "pointer" : "inherit"}}>
      {hoverable &&
        <img key="hoverslot" className={styles.hoverslot} src={useBaseUrl(`/img/components/InventorySlot/${type}Hover.png`)}/>
      }
      <img key="slot" className={styles.slot} src={useBaseUrl(`/img/components/InventorySlot/${type}.png`)}/>

      {sprite &&
        <img key="sprite" style={{opacity: type == "locked" ? 0.15625 : 1}} className={styles.sprite} src={sprite}/>
      }

      {tooltip &&
        <span key="tooltip" className={styles.tooltip} style={{color: tooltipColor || "#FFED00"}}>
          {tooltip}
        </span>
      }

      {count &&
        <span key="count" className={styles.count} style={{color: countColor || "#FFFFFF"}}>
          {count}
        </span>
      }
    </div>
  );
}