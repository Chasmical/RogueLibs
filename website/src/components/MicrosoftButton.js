import React from 'react';
import styles from './MicrosoftButton.module.css';

export default function ({link, ...props}) {
    return (
        <form className={styles.form} action={link}>
            <button className={styles.button}>
                {props.children}
            </button>
        </form>
    );
}