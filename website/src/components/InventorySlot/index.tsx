import React, { useState } from 'react';
import clsx from 'clsx';
import styles from './index.module.scss';

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

  return (
    <div onClick={onClick} className={clsx(
      styles.container,
      cantClick && styles.cursorLocked,
      type && styles[type],
      hoverable && styles.hoverable,
    )}>
      {sprite &&
        <img key="sprite" className={styles.sprite} src={sprite}/>
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