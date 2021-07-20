import React, { useState } from 'react';
import styles from './index.module.css';
import InventoryRow, { Props as RowProps } from '../InventoryRow';

export default function(props: RowProps): JSX.Element {
  return (
    <div className={styles.toolbar}>
      <InventoryRow {...props}/>
    </div>
  );
}