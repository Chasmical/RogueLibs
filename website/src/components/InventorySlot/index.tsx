import React, { useState } from 'react';
import useBaseUrl from '@docusaurus/useBaseUrl';
import styles from './index.module.css';

export type Props = {
  sprite?: string,
  tooltip?: string,
  tooltipColor?: string,
  count?: string,
  countColor?: string,
}

export default function ({sprite, tooltip, tooltipColor, count, countColor}: Props): JSX.Element {
  return (
    <div className={styles.container}>
      <img key="slot" className={styles.slot} src={useBaseUrl("/img/components/InventorySlot/Normal.png")}/>

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