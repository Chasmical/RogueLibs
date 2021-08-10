import React, { useState } from "react";
import useStorageArray from "./useStorageArray";

export interface SelectorParameters {
  defaultValues?: string | string[] | (() => string | string[] | undefined),
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

export default function (availableValues: (string | undefined)[] | null, pars: SelectorParameters) : [string[], SelectorController] {

  let {defaultValues, minChoices, maxChoices, lockChoices, group, onChange} = pars;

  let MinChoices = minChoices != undefined ? minChoices : 0;
  let MaxChoices = maxChoices != undefined ? maxChoices : 1;
  if (MaxChoices == -1) MaxChoices = Infinity;

  const [valuesInternal, setValuesInternal] = useStorageArray(group ?? null, () => {
    if (typeof defaultValues === "function") defaultValues = defaultValues();
    if (defaultValues === undefined) {
      defaultValues = [];
      if (availableValues) {
        let lookup = availableValues.filter(v => v !== undefined) as string[];
        let len = Math.min(lookup.length, MinChoices);
        for (let i = 0; i < len; i++)
          defaultValues.push(lookup[i]);
      }
    }
    else if (!Array.isArray(defaultValues)) defaultValues = [defaultValues];

    if (defaultValues.length < MinChoices || defaultValues.length > MaxChoices)
      throw new Error(`Invalid default values count: ${MinChoices} ≤ ${defaultValues.length} ≤ ${MaxChoices}`);
    if (lockChoices && MinChoices == MaxChoices)
      throw new Error(`Cannot lock choices when Min and Max choices are equal.`);
    return defaultValues;
  }, e => onChange && onChange(e));

  const addValue = (value: string) => {
    if (valuesInternal.includes(value)) return;
    if (lockChoices && valuesInternal.length >= MaxChoices) return;
    while (valuesInternal.length >= MaxChoices)
      valuesInternal.shift();
    let newValues = valuesInternal.concat(value);

    setValuesInternal(newValues);
  }
  const removeValue = (value: string) => {
    let index = valuesInternal.indexOf(value);
    if (index == -1) return;
    if (valuesInternal.length <= MinChoices) return;
    let newValues = valuesInternal.slice();
    newValues.splice(index, 1);

    setValuesInternal(newValues);
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