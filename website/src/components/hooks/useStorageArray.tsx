import React, { useState, useEffect, useContext } from 'react';
import useStorage, { context, StorageUpdatedArgs } from './useStorage';

export default function (slotName?: string, defaultValue?: string[] | (() => string[])): [string[], React.Dispatch<React.SetStateAction<string[]>>] {

  const controller = useContext(context);

  const setValue = (newValue: React.SetStateAction<string[]>) => {
    if (slotName == null) return;
    if (typeof newValue === "function") newValue = newValue(value);
    if (newValue !== null) controller.set(slotName, newValue.join(";"));
    else controller.delete(slotName);
  }

  useEffect(() => {
    if (slotName == null) return () => { };
    controller.subscribe(storageListener);
    return () => controller.unsubscribe(storageListener);
  });

  const [value, setValueInternal] = useState(() => {
    
    let stored = slotName != null ? controller.get(slotName) : null;
    let storedArray: string[];
    if (stored !== null) {
      storedArray = stored.split(";");
    }
    else {
      if (defaultValue != null) {
        if (typeof defaultValue === "function")
          defaultValue = defaultValue();
        storedArray = defaultValue;
      }
      else {
        storedArray = [];
      }
      setValue(storedArray);
    }
    return storedArray;
  });

  const storageListener = (e: StorageUpdatedArgs) => {
    if (e.slotName == slotName) {
      setValueInternal(e.value ? e.value.split(";") : []);
    }
  }

  return [value, setValue];
}