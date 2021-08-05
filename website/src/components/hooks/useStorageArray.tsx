import React, { useState, useEffect, useContext } from 'react';
import useStorage, { context, StorageUpdatedArgs } from './useStorage';

export default function (slotName?: string, defaultValue?: string[] | (() => string[])): [string[], React.Dispatch<React.SetStateAction<string[]>>] {

  if (slotName && slotName.includes(";")) throw new Error("Storage slot name cannot contain ';'!");
  const controller = useContext(context);

  const setValue = (newValue: React.SetStateAction<string[]>) => {
    setValueFull(newValue, true);
  }
  const setValueFull = (newValue: React.SetStateAction<string[]>, shareState: boolean) => {
    if (typeof newValue === "function") newValue = newValue(value);
    setValueInternal(newValue);
    if (slotName == null || !shareState) return;
    if (newValue != null) controller.set(slotName, newValue.join(";"));
    else controller.delete(slotName);
  }

  const [value, setValueInternal] = useState(() => {
    if (typeof defaultValue === "function") defaultValue = defaultValue();
    return defaultValue ?? [];
  });

  useEffect(() => {
    if (slotName == null) return () => { };

    let stored = controller.get(slotName);
    if (stored != null) setValueFull(stored.split(";"), false);
    else setValueFull(defaultValue ?? [], true);
    
    controller.subscribe(storageListener);
    return () => controller.unsubscribe(storageListener);
  }, [controller]);

  const storageListener = (e: StorageUpdatedArgs) => {
    if (e.slotName == slotName) {
      setValueInternal(e.value ? e.value.split(";") : []);
    }
  }

  return [value, setValue];
}
