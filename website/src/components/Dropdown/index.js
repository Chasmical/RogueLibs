import React, { cloneElement, useState } from 'react';
import styles from './index.module.css';
import clsx from 'clsx';
import useFocus from '../useFocus';

export default function ({children, defaultValues, minChoices, maxChoices, fixed, onChange, ...props}) {
  if (maxChoices)
    minChoices = minChoices != null ? minChoices : 1;
  else {
    minChoices = minChoices || 0;
    maxChoices = 1;
  }
  fixed = !!fixed;
  onChange = onChange || (() => { });

  const header = children.filter(c => c.props.value == null)[0];
  const options = children.filter(c => c.props.value != null);

  const [curIndexes, setCurIndexes] = useState(() => {
    if (defaultValues) {
      let defIndexes = defaultValues.map(defValue => {
        let index = options.findIndex(o => o.props.value == defValue);
        if (index == -1) throw new Error(`Could not find ${defValue} in the options!`);
        return index;
      });
      if (defIndexes.length > maxChoices) throw new Error("You can't assign more default values than maxChoices!");
      if (defIndexes.length < minChoices) throw new Error("You can't assign less default values than minChoices!");
      return defIndexes;
    }
    else return [0];
  });

  const [ref, focused, setFocused] = useFocus(false);

  const clickHandler = myIndex => {
    let pos = curIndexes.indexOf(myIndex);
    let newIndexes = curIndexes.map(i => i);
    if (pos != -1)
    {
      newIndexes.splice(pos, 1);
      if (newIndexes.length < minChoices) return;
      let event = newIndexes.map(i => options[i].props).map(p => ({ value: p.value, label: p.label || p.value }));
      setCurIndexes(newIndexes);
      onChange(event, "removed", options[myIndex].props.value);
    }
    else
    {
      newIndexes.push(myIndex);
      if (newIndexes.length > maxChoices)
      {
        if (fixed) return;
        newIndexes.shift(1);
      }
      let event = newIndexes.map(i => options[i].props).map(p => ({ value: p.value, label: p.label || p.value }));
      setCurIndexes(newIndexes);
      onChange(event, "added", options[myIndex].props.value);
    }
  };

  return (
    <div ref={ref} className={styles.container}>
      <div className={clsx(styles.header, focused && styles.focused)} onClick={() => setFocused(!focused)}>
        {header}
      </div>
      { focused &&
        <div className={styles.contentsBack}>
          <div className={styles.contents}>
            {focused && options.map((option, i) => {
              let selected = curIndexes.includes(i);
              return cloneElement(option, {
                key: i,
                selected: selected,
                onClick: () => clickHandler(i),
                locked: fixed && (selected ? curIndexes.length == minChoices : curIndexes.length == maxChoices),
              })
            })}
          </div>
        </div>
      }
    </div>
  );
}