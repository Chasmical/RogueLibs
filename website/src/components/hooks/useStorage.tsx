import React, { useState, useCallback, useContext, useEffect } from 'react';
import { createStorageSlot, listStorageKeys } from '@docusaurus/theme-common';

export type Storage = {
  [slotName: string]: string,
}
export type StorageController = {
  get: (slotName: string) => string | null,
  set: (slotName: string, value: string) => void,
  delete: (slotName: string) => void,
  subscribe: (callback: (e: StorageUpdatedArgs) => void) => void,
  unsubscribe: (callback: (e: StorageUpdatedArgs) => void) => void,
}
export type StorageUpdatedArgs = {
  slotName: string,
  value: string | null,
}

export type Props = {
  children?: React.ReactNode,
}

const STORAGE_PREFIX = "roguestorage.";

function useStorageInternal(): StorageController {
  const [storage, setStorage] = useState({} as Storage);
  const [subscribers, setSubscribers] = useState([] as ((e: StorageUpdatedArgs) => void)[]);

  const getSlot = (slotName: string) => {
    let value: string | null = storage[slotName] ?? null;
    console.log(`Retrieved ${slotName}: ${value}`);
    return value;
  }
  const setSlot = useCallback((slotName: string, value: string) => {
    storage[slotName] = value;
    createStorageSlot(`${STORAGE_PREFIX}${slotName}`).set(value);
    setStorage(storage);
    let args = {slotName, value};
    subscribers.forEach(s => s(args));
    console.log(`Stored ${slotName}: ${value}`);
  }, []);
  const deleteSlot = (slotName: string) => {
    delete storage[slotName];
    createStorageSlot(`${STORAGE_PREFIX}${slotName}`).del();
    setStorage(storage);
    let args = {slotName, value: null};
    subscribers.forEach(s => s(args));
  }

  let [ready, setReady] = useState(false);
  if (!ready) {
    let localStorage = {};
    try {
      listStorageKeys().forEach(key => {
        if (key.startsWith(STORAGE_PREFIX)) {
          let slotName = key.substring(STORAGE_PREFIX.length);
          localStorage[slotName] = createStorageSlot(key).get();
        }
      });
      setStorage(localStorage);
    }
    catch (err) {
      console.error(err);
    }
    setReady(true);
  }

  return {
    get: slot => getSlot(slot),
    set: (slot, value) => setSlot(slot, value),
    delete: slot => deleteSlot(slot),
    subscribe: cb => subscribers.push(cb),
    unsubscribe: cb => { let index = subscribers.indexOf(cb); if (index != -1) subscribers.splice(index, 1); },
  };
}

export const context = React.createContext({} as StorageController);

export function StorageProvider ({children}: Props): JSX.Element {
  const controller = useStorageInternal();
  return (
    <context.Provider value={controller}>
      {children}
    </context.Provider>
  );
}

export default function (slotName?: string, defaultValue?: string | (() => string)): [string | null, React.Dispatch<React.SetStateAction<string | null>>] {

  const controller = useContext(context);

  const setValue = (newValue: React.SetStateAction<string | null>) => {
    if (slotName == null) return;
    if (typeof newValue === "function") newValue = newValue(value);
    if (newValue !== null) controller.set(slotName, newValue);
    else controller.delete(slotName);
  }

  useEffect(() => {
    if (slotName == null) return () => { };
    controller.subscribe(storageListener);
    return () => controller.unsubscribe(storageListener);
  });

  const [value, setValueInternal] = useState(() => {
    
    let stored = slotName != null ? controller.get(slotName) : null;
    if (stored === null && defaultValue != null) {
      if (typeof defaultValue === "function") defaultValue = defaultValue();
      setValue(defaultValue);
      return defaultValue;
    }
    return stored;
  });

  const storageListener = (e: StorageUpdatedArgs) => {
    if (e.slotName == slotName) {
      setValueInternal(e.value);
    }
  }

  return [value, setValue];
}