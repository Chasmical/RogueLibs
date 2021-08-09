import React, { useState } from 'react';
import useBaseUrl from '@docusaurus/useBaseUrl';
import styles from './index.module.css';

export type Props = {
  sprite?: string,
  tooltip?: string | number,
  tooltipColor?: string,
  count?: string | number,
  countColor?: string,

  type?: "normal" | "selected" | "locked" | null,
  onClick?: () => void,
  hoverable?: boolean,
  
  uid?: string,
}

export default function ({sprite, tooltip, tooltipColor, count, countColor, hoverable, type = "normal", onClick}: Props): JSX.Element {

  const slotSrc = type ? useBaseUrl(`/img/components/InventorySlot/${type}.png`) : undefined;
  const slotHoverSrc = type ? useBaseUrl(`/img/components/InventorySlot/${type}Hover.png`) : undefined;
  const opacity = type == "locked" ? 0.15625 : 1;

  return (
    <div className={styles.container} onClick={onClick} style={{cursor: hoverable ? "pointer" : "inherit"}}>
      {type &&
        <>
          {hoverable &&
            <img key="hoverslot" className={styles.hoverslot} src={slotHoverSrc}/>
          }
          <img key="slot" className={styles.slot} src={slotSrc}/>
        </>
      }

      {sprite &&
        <img key="sprite" style={{opacity}} className={styles.sprite} src={sprite}/>
      }

      {tooltip &&
        <span key="tooltip" className={styles.tooltip} style={{opacity, color: tooltipColor || "#FFED00"}}>
          {tooltip}
        </span>
      }

      {count &&
        <span key="count" className={styles.count} style={{opacity, color: countColor || "#FFFFFF"}}>
          {count}
        </span>
      }
    </div>
  );
}