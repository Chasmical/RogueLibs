import React, { useState } from "react";
import useStorageArray from "./useStorageArray";

export type Props = {
  defaultValues?: string | string[] | null | (() => string | string[] | null),
  defaultValuesLookup?: (string | undefined)[] | (() => (string | undefined)[]),
  minChoices?: number,
  maxChoices?: number,
  lockChoices?: boolean,
  group?: string,
  onChange?: (values: string[]) => void,
}
export type SelectorController = {
  add: (value: string) => void,
  remove: (values: string) => void,
  toggle: (values: string) => void,
  set: (values: string[]) => void,
  isLocked: (value: string) => boolean,
}

export default function ({defaultValues, defaultValuesLookup, minChoices, maxChoices, lockChoices, group, onChange}: Props) : [string[], SelectorController] {

  let MinChoices = minChoices != undefined ? minChoices : 0;
  let MaxChoices = maxChoices != undefined ? maxChoices : 1;

  const [valuesInternal, setValuesInternal] = useStorageArray(group, () => {
    if (typeof defaultValues === "function") defaultValues = defaultValues();
    if (defaultValues == null) {
      defaultValues = [];
      if (typeof defaultValuesLookup === "function") defaultValuesLookup = defaultValuesLookup();
      if (defaultValuesLookup) {
        let lookup = defaultValuesLookup.filter(v => v !== undefined) as string[];
        let len = Math.min(lookup.length, MinChoices);
        for (let i = 0; i < len; i++)
          defaultValues.push(lookup[i]);
      }
    }
    if (!Array.isArray(defaultValues)) defaultValues = [defaultValues];
    if (defaultValues.length < MinChoices || defaultValues.length > MaxChoices)
      throw new Error(`Invalid default values count: ${MinChoices} ≤ ${defaultValues.length} ≤ ${MaxChoices}`);
    if (lockChoices && MinChoices == MaxChoices)
      throw new Error(`Cannot lock choices when Min and Max choices are equal.`);
    return defaultValues;
  });

  const addValue = (value: string) => {
    if (valuesInternal.includes(value)) return;
    if (lockChoices && valuesInternal.length >= MaxChoices) return;
    while (valuesInternal.length >= MaxChoices)
      valuesInternal.shift();
    let newValues = valuesInternal.concat(value);

    setValuesInternal(newValues);
    if (onChange) onChange(newValues);
  }
  const removeValue = (value: string) => {
    let index = valuesInternal.indexOf(value);
    if (index == -1) return;
    if (valuesInternal.length <= MinChoices) return;
    let newValues = valuesInternal.slice();
    newValues.splice(index, 1);

    setValuesInternal(newValues);
    if (onChange) onChange(newValues);
  }
  const toggleValue = (value: string) => {
    let selected = valuesInternal.includes(value);
    if (selected) removeValue(value);
    else addValue(value);
  }
  const setValues = (values: string[]) => {
    values = values.filter((value, index, self) => self.indexOf(value) == index);
    if (values.length == valuesInternal.length && values.every((value, index) => valuesInternal.indexOf(value) == index)) return;
    if (values.length < MinChoices || values.length > MaxChoices)
      throw new Error(`Invalid default values count: ${MinChoices} ≤ ${values.length} ≤ ${MaxChoices}`);

    setValuesInternal(values);
    if (onChange) onChange(values);
  }
  const isLockedValue = (value: string) => {
    if (!lockChoices) return false;
    let selected = valuesInternal.includes(value);
    return valuesInternal.length == (selected ? MinChoices : MaxChoices);
  }

  return [valuesInternal, {
    add: addValue,
    remove: removeValue,
    toggle: toggleValue,
    set: setValues,
    isLocked: isLockedValue,
  }];
}