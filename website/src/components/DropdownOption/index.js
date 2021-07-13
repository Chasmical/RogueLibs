import React, { useState } from 'react';
import styles from './index.module.css';
import clsx from 'clsx';

export default function ({children, onClick, value, label, tooltip, recommended, selected, locked, ...props}) {
  label = label || value;
  return (
    <div className={clsx(styles.option,
        selected && styles.optionSelected,
        locked && styles.optionLocked,
        (recommended && !selected) && styles.optionRecommended)}
      onClick={onClick} {...props}>
      <span>
        {children != null && children.length > 0
          ? children
          : label}
      </span>
      {tooltip &&
        <div className={styles.tooltip}>
          <span>{tooltip}</span>
        </div>
      }
    </div>
  );
}