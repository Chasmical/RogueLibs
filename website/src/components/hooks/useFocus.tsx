import React, { useState, useEffect, useRef } from "react";

export default function (initialFocused: boolean): [React.MutableRefObject<any>, boolean, React.Dispatch<React.SetStateAction<boolean>>] {
  const [focused, setFocused] = useState(initialFocused);
  const ref = useRef(null as any);

  const handleHideDropdown = (event : KeyboardEvent) => {
    if (event.key === "Escape") {
      setFocused(false);
    }
  };

  const handleClickOutside = (event : MouseEvent) => {
    if (ref.current && !ref.current.contains(event.target)) {
      setFocused(false);
    }
  };

  useEffect(() => {
    document.addEventListener("click", handleClickOutside, true);
    document.addEventListener("keydown", handleHideDropdown, true);
    return () => {
      document.removeEventListener("click", handleClickOutside, true);
      document.removeEventListener("keydown", handleHideDropdown, true);
    };
  });

  return [ref, focused, setFocused];
}