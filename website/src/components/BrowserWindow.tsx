import React from 'react';
import styles from './BrowserWindow.module.css';

export type Props = {
  children?: React.ReactNode,
  url?: string,
}

export default function ({children, url}: Props): JSX.Element {
  return (
    <div>
      <div className={styles.browserWindow}>
        <div className={styles.browserWindowHeader}>
          <div className={styles.buttons}>
            <span className={styles.dot} style={{background: '#f25f58'}}/>
            <span className={styles.dot} style={{background: '#fbbe3c'}}/>
            <span className={styles.dot} style={{background: '#58cb42'}}/>
          </div>
          <div className={styles.browserWindowAddressBar}>{url}</div>
          <div className={styles.browserWindowMenuIcon}>
            <div>
              <span className={styles.bar}/>
              <span className={styles.bar}/>
              <span className={styles.bar}/>
            </div>
          </div>
        </div>
        <div className={styles.browserWindowBody}>{children}</div>
      </div>
      <br/>
    </div>
  );
}
