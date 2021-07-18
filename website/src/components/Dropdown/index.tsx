import React, { useState, cloneElement } from 'react';
import clsx from 'clsx';
import styles from './index.module.css';
import useFocus from '../useFocus';

type DropdownProps = {
  defaultValues?: string[],
  minChoices?: number,
  maxChoices?: number,
  lockChoices?: boolean,
  children?: React.ReactNode,
  onChange?: (e: ChangeEventData) => void,
}
type ChangeEventData = {
  changeType: "added" | "removed",
  changedValue: string,
  changedLabel: string,
  values: string[],
  labels: string[],
}

export function Dropdown({defaultValues, minChoices, maxChoices, lockChoices, children, onChange} : DropdownProps) : JSX.Element {

  let MinChoices = minChoices != undefined ? minChoices : 1;
  let MaxChoices = maxChoices != undefined ? maxChoices : MinChoices;
  if (MinChoices == MaxChoices && lockChoices) throw Error("Cannot lock choices with the minimum amount equal to the maximum!");

  let Children = React.Children.toArray(children);
  let header = Children.find((c : any) => c?.props?.mdxType == "DropdownHeader");
  let options = Children.filter((c : any) => c?.props?.mdxType == "DropdownOption");

  const [indexes, setIndexes] = useState(() => {
    if (MinChoices > options.length) throw Error("There are less options than the minimum!");
    if (!defaultValues)
    {
      let newIndexes : number[] = [];
      for (let i = 0; i < MinChoices; i++)
        newIndexes.push(i);
      return newIndexes;
    }
    if (defaultValues.length < MinChoices) throw Error("There are less default choices than the minimum!");
    if (defaultValues.length > MaxChoices) throw Error("There are more default choices than the maximum!");
    let newIndexes = defaultValues.map(v => {
      let index = options.findIndex((o: any) => o.props.value == v);
      if (index == -1) throw new Error(`Could not find default value "${v}" in the options!`);
      return index;
    });
    return newIndexes;
  });

  const clickHandler = (myIndex: number) => {
    let me = (options[myIndex] as any).props;
    let myPos = indexes.indexOf(myIndex);
    let newIndexes = indexes.map(i => i);
    let changeType: "added" | "removed";

    if (myPos == -1) {
      if (indexes.length >= MaxChoices) {
        if (lockChoices) return;
        newIndexes.shift();
      }
      newIndexes.push(myIndex);
      setIndexes(newIndexes);

      changeType = "added";
    }
    else {
      if (indexes.length <= MinChoices) return;
      newIndexes.splice(myPos, 1);
      setIndexes(newIndexes);
      changeType = "removed";
    }
    
    if (onChange) onChange({
      changeType: changeType,
      changedValue: me.value,
      changedLabel: me.label || me.value,
      values: newIndexes.map(i => (options[i] as any).props).map(p => p.value),
      labels: newIndexes.map(i => (options[i] as any).props).map(p => p.label || p.value),
    });
  };

  const [ref, focused, setFocused] = useFocus(false);

  let i = 0;
  return (
    <div ref={ref} className={clsx(styles.container, focused && styles.focused)}>
      <div onClick={() => setFocused(!focused)} className={styles.header}>
        {header || indexes.map(i => (options[i] as any).props).map(p => p.label || p.value).join(", ")}
      </div>
      <div className={styles.contentsBack}>
        {focused &&
          <div className={styles.contents}>
          {React.Children.map(children, (c, key) => {
            if (c === null || c === undefined || c === true || c === false) return null;
            let type : string = (c as any)?.props?.mdxType;
            if (type == "DropdownHeader") return null;

            if (type == "DropdownOption") {
              let myIndex = i++;
              let selected = indexes.includes(myIndex);
              return (
                <div key={myIndex} onClick={() => clickHandler(myIndex)}
                  className={clsx(styles.option,
                    selected && styles.optionSelected,
                    lockChoices && (selected ? indexes.length == MinChoices : indexes.length == MaxChoices) && styles.optionLocked,
                    selected || (c as any).props.recommended && styles.optionRecommended)}>
                  {c}
                </div>
              );
            }
            else if (type == "DropdownDivider") {
              return (
                <React.Fragment key={indexes.length + key}>
                  {c}
                </React.Fragment>
              );
            }
            else {
              return (
                <div key={indexes.length + key} className={styles.element}>
                  {c}
                </div>
              );
            }
          })}
          </div>
        }
      </div>
    </div>
  );
};

type HeaderProps = {
  children: React.ReactNode,
}

export function DropdownHeader({children} : HeaderProps) : JSX.Element {
  return (
    <>
      {children}
    </>
  );
};

type OptionProps = {
  value: string,
  label?: string,
  children?: React.ReactNode,
}

export function DropdownOption({value, label, children} : OptionProps) : JSX.Element {
  return (
    <>
      {children || label || value}
    </>
  );
};

export function DropdownDivider() : JSX.Element {
  return <div style={{width:'100%'}}/>
}