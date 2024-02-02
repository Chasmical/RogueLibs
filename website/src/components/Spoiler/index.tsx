import React, { useState } from "react";
import styles from "./index.module.scss";
import clsx from "clsx";

export interface SpoilerProps {
  children: React.ReactNode;
}
export default function Spoiler({ children }: SpoilerProps) {
  const [isOpen, setIsOpen] = useState(false);

  return (
    <span onClick={() => setIsOpen(v => !v)} className={clsx(styles.spoiler, isOpen && styles.open)}>
      <span className={styles.contents}>{children}</span>
    </span>
  );
}
