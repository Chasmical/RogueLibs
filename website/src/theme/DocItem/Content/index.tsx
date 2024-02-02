import React from "react";
import Content from "@theme-original/DocItem/Content";
import Admonition from "@theme/Admonition";
import styles from "./index.module.scss";

export default function ContentWrapper(props: any) {
  const title = (
    <label className={styles.label}>
      {"RogueLibs has been discontinued."}
    </label>
  );
  const disclaimer = (
    <div className={styles.disclaimer}>
      <Admonition type="danger" title={title}>
        {"The project's repository is archived as part of the GitHub Archive Program. RogueLibs' code and the documentation will no longer be updated."}
      </Admonition>
    </div>
  );

  return (
    <div>
      {disclaimer}
      <Content {...props} />
      {disclaimer}
    </div>
  );
}
