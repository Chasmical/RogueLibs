import React, { useState, useEffect, useContext } from 'react';
import useStorage, { context, StorageUpdatedArgs } from './useStorage';

export default function (slotName: string | null, defaultValue?: string[] | (() => string[]), onChange?: (values: string[]) => void): [string[], React.Dispatch<React.SetStateAction<string[] | null>>] {

  if (slotName && slotName.includes(";")) throw new Error("Storage slot name cannot contain ';'!");
  const controller = useContext(context);

  const [value, setValueInternal] = useState(() => {
    if (typeof defaultValue === "function") defaultValue = defaultValue();
    return defaultValue ?? [];
  });

  const setValue = (newValue: React.SetStateAction<string[] | null>) => {
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
