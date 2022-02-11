import React, { useState } from 'react';
import { useTabGroupChoice } from '@docusaurus/theme-common';
import clsx from 'clsx';
import styles from './Tabs.module.css';

function isInViewport(element) {
  const {top, left, bottom, right} = element.getBoundingClientRect();
  const {innerHeight, innerWidth} = window;

  return top >= 0 && right <= innerWidth && bottom <= innerHeight && left >= 0;
}

const keys = {
  left: 37,
  right: 39,
}
export type Props = {
  children?: React.ReactNode,
  lazy?: boolean,
  defaultValue?: string,
  values: {value: string, label: string}[],
  groupId?: string,
}

export default function(props: Props) {
  const { lazy, defaultValue, values, groupId } = props;
  const {tabGroupChoices, setTabGroupChoices} = useTabGroupChoice();
  const [selectedValue, setSelectedValue] = useState(defaultValue);
  const children = React.Children.toArray(props.children);
  const tabRefs: (EventTarget | HTMLLIElement)[] = [];

  if (groupId != null) {
    const relevantTabGroupChoice = tabGroupChoices[groupId];
    if (
      relevantTabGroupChoice != null &&
      relevantTabGroupChoice !== selectedValue &&
      values.some((value) => value.value === relevantTabGroupChoice)
    ) {
      setSelectedValue(relevantTabGroupChoice);
    }
  }

  const handleTabChange = (event: React.FocusEvent<HTMLLIElement> | React.MouseEvent<HTMLLIElement>) => {
    const selectedTab = event.currentTarget;
    const selectedTabIndex = tabRefs.indexOf(selectedTab);
    const selectedTabValue = values[selectedTabIndex].value;

    setSelectedValue(selectedTabValue);

    if (groupId != null) {
      setTabGroupChoices(groupId, selectedTabValue);

      setTimeout(() => {
        if (isInViewport(selectedTab)) {
          return;
        }

        selectedTab.scrollIntoView({
          block: 'center',
          behavior: 'smooth',
        });

        selectedTab.classList.add(styles.tabItemActive);
        setTimeout(
          () => selectedTab.classList.remove(styles.tabItemActive),
          2000,
        );
      }, 150);
    }
  };

  const handleKeydown = (event: React.KeyboardEvent<HTMLLIElement>) => {
    let focusElement: EventTarget | HTMLLIElement;
    switch (event.keyCode) {
      case keys.right: {
        const nextTab = tabRefs.indexOf(event.target) + 1;
        focusElement = tabRefs[nextTab] || tabRefs[0];
        break;
      }
      case keys.left: {
        const prevTab = tabRefs.indexOf(event.target) - 1;
        focusElement = tabRefs[prevTab] || tabRefs[tabRefs.length - 1];
        break;
      }
      default:
        return;
    }
    (focusElement as any).focus();
  };

  const isShown = (selected: string | undefined, props: any) => props.value === selected || props.values && props.values.indexOf(selected) != -1;

  return (
    <div className="tabs-container">
      <ul
        role="tablist"
        aria-orientation="horizontal"
        className="tabs">
        {values.map(({value, label}) => (
          <li
            role="tab"
            tabIndex={selectedValue === value ? 0 : -1}
            aria-selected={selectedValue === value}
            className={clsx('tabs__item', styles.tabItem, {
              'tabs__item--active': selectedValue === value,
            })}
            key={value}
            ref={(tabControl) => tabControl && tabRefs.push(tabControl)}
            onKeyDown={handleKeydown}
            onFocus={handleTabChange}
            onClick={handleTabChange}>
            {label}
          </li>
        ))}
      </ul>

      {lazy ? (
        React.cloneElement(
          children.find((tabItem: any) => isShown(selectedValue, tabItem.props)) as React.ReactElement,
          {
            className: styles.tab,
          },
        )
      ) : (
        <div>
          {children.map((tabItem: any, i: number) =>
            React.cloneElement(tabItem, {
              key: i,
              hidden: !isShown(selectedValue, tabItem.props),
              className: styles.tab,
            }),
          )}
        </div>
      )}
      <br/>
    </div>
  );
}
