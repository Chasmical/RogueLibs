import React, { useState } from 'react';
import useBaseUrl from '@docusaurus/useBaseUrl';
import styles from './InventorySlot.module.css';

export default function ({sprite, tooltip, count, countColor, ...props}) {
  return (
    <div className={styles.container}>
      <img key="slot" className={styles.slot} src={useBaseUrl("/img/SetupDetailsGenerator/ToolbarSlot.png")}/>

      {sprite == null ? [] :
        <img key="sprite" className={styles.sprite} src={sprite}/>
      }

      {tooltip == null ? [] :
        <span key="tooltip" className={styles.tooltip}>{tooltip}</span>
      }

      {count == null ? [] :
        <span key="count" className={styles.count}>
          <span style={{color: countColor || "#FFFFFF"}}>
            {count}
          </span>
        </span>
      }

    </div>
  );
};