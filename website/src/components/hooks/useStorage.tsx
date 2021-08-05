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
  const [storage, setStorage] = useState(null as (Storage | null));
  const [subscribers, setSubscribers] = useState([] as ((e: StorageUpdatedArgs) => void)[]);

  const getSlot = (slotName: string) => {
    if (storage === null) return null;
    let value: string | null = storage[slotName] ?? null;
    return value;
  }
  const setSlot = useCallback((slotName: string, value: string) => {
    if (storage === null) return;
    storage[slotName] = value;
    createStorageSlot(`${STORAGE_PREFIX}${slotName}`).set(value);
    setStorage(storage);
    let args = {slotName, value};
    subscribers.forEach(s => s(args));
  }, [storage]);
  const deleteSlot = (slotName: string) => {
    if (storage === null) return;
    delete storage[slotName];
    createStorageSlot(`${STORAGE_PREFIX}${slotName}`).del();
    setStorage(storage);
    let args = {slotName, value: null};
    subscribers.forEach(s => s(args));
  }

  useEffect(() => {
    let localStorage = {};
    try {
      listStorageKeys().forEach(key => {
        if (key.startsWith(STORAGE_PREFIX)) {
          let slotName = key.substring(STORAGE_PREFIX.length);
          let val = createStorageSlot(key).get();
          if (val !== null) localStorage[slotName] = val;
        }
      });
      setStorage(localStorage);
    }
    catch (err) {
      console.error(err);
    }
    console.log("Storage set");
  }, []);

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

  if (slotName && slotName.includes(";")) throw new Error("Storage slot name cannot contain ';'!");
  const controller = useContext(context);

  const setValue = (newValue: React.SetStateAction<string | null>) => {
    setValueFull(newValue, true);
  }
  const setValueFull = (newValue: React.SetStateAction<string | null>, shareState: boolean) => {
    if (typeof newValue === "function") newValue = newValue(value);
    setValueInternal(newValue);
    if (slotName == null || !shareState) return;
    if (newValue != null) controller.set(slotName, newValue);
    else controller.delete(slotName);
  }

  const [value, setValueInternal] = useState(() => {
    if (typeof defaultValue === "function") defaultValue = defaultValue();
    return defaultValue ?? null;
  });

  useEffect(() => {
    if (slotName == null) return () => { };

    let stored = controller.get(slotName);
    if (stored != null) setValueFull(stored, false);
    else setValueFull(defaultValue ?? null, true);
    
    controller.subscribe(storageListener);
    return () => controller.unsubscribe(storageListener);
  }, [controller]);

  const storageListener = (e: StorageUpdatedArgs) => {
    if (e.slotName == slotName) {
      setValueInternal(e.value);
    }
  }

  return [value, setValue];
}
