import React, { useState, useEffect, useContext } from 'react';
import useStorage, { context, StorageUpdatedArgs } from './useStorage';

export default function (slotName: string | null, defaultValues?: string[] | (() => string[] | undefined), onChange?: (values: string[]) => void): [string[], React.Dispatch<React.SetStateAction<string[]>>] {

  const controller = useContext(context);

  const [value, setValueInternal] = useState(() => {
    if (typeof defaultValues === "function") defaultValues = defaultValues();
    return defaultValues ?? [];
  });

  const setValue = (newValue: React.SetStateAction<string[]>) => {
    if (typeof newValue === "function") newValue = newValue(value);
    if (slotName != null) {
      if (newValue != null) controller.set(slotName, newValue.join(";"));
      else controller.delete(slotName);
    }
    else {
      if (newValue === null) newValue = [];
      setValueInternal(newValue);
      onChange && onChange(newValue);
    }
  }

  const storageListener = (e: StorageUpdatedArgs) => {
    if (e.slotName == slotName) {
      let newValue = e.value ? e.value.split(";") : [];
      setValueInternal(newValue);
      onChange && onChange(newValue);
    }
  }

  useEffect(() => {
    if (slotName == null) return () => { };
    
    controller.subscribe(storageListener);
    return () => controller.unsubscribe(storageListener);
  }, []);

  return [value, setValue];
}
