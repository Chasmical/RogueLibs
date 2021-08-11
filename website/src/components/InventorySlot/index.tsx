import React, { useState } from 'react';
import clsx from 'clsx';
import useBaseUrl from '@docusaurus/useBaseUrl';
import styles from './index.module.css';

import normal from './assets/normal.png';
import normalHover from './assets/normalHover.png';
import selected from './assets/selected.png';
import selectedHover from './assets/selectedHover.png';
import locked from './assets/locked.png';
import lockedHover from './assets/lockedHover.png';

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
  cantClick?: boolean,
  
  uid?: string,
}

export default function ({sprite, tooltip, tooltipColor, count, countColor, hoverable, cantClick, type = "normal", onClick}: Props): JSX.Element {

  const [slotSrc, slotHoverSrc] = type ? images[type] : [];
  const opacity = type == "locked" ? 0.15625 : 1;

  const cursor = cantClick ? styles.cursorLocked : styles.cursorNormal;

  return (
    <div onClick={onClick} className={clsx(styles.container, cursor)}>
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