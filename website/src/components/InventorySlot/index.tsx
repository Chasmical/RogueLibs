import React, { useState } from 'react';
import useBaseUrl from '@docusaurus/useBaseUrl';
import styles from './index.module.css';

import normal from './normal.png';
import normalHover from './normalHover.png';
import selected from './selected.png';
import selectedHover from './selectedHover.png';
import locked from './locked.png';
import lockedHover from './lockedHover.png';

const images: {readonly [type: string]: [slot: string, slotHover: string]} = {
  normal: [normal, normalHover],
  selected: [selected, selectedHover],
  locked: [locked, lockedHover],
}

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

  const [slotSrc, slotHoverSrc] = type ? images[type] : [];
  const opacity = type == "locked" ? 0.15625 : 1;

  return (
    <div className={styles.container} onClick={onClick} style={{cursor: hoverable ? "pointer" : "inherit"}}>
      {type &&
        <>
          {hoverable &&
            <img key="hoverslot" width={80} className={styles.hoverslot} src={slotHoverSrc}/>
          }
          <img key="slot" width={80} className={styles.slot} src={slotSrc}/>
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