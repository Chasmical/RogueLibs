import React from 'react';
import styles from './TabItemWithBorder.module.css';
import TabItem from '@theme/TabItem';

export default function ({children, ...props}) {
    return (
        <TabItem {...props}>
            <div className={styles.tab}>
                {children}
            </div>
        </TabItem>
    );
}