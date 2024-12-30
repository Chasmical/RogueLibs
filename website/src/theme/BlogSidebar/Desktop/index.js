import React from 'react';
import clsx from 'clsx';
import Link from '@docusaurus/Link';
import {translate} from '@docusaurus/Translate';
import {useVisibleBlogSidebarItems} from '@docusaurus/theme-common/internal';
import styles from './styles.module.css';
export default function BlogSidebarDesktop({sidebar}) {
  const items = useVisibleBlogSidebarItems(sidebar.items);
  return (
    <aside className="col col--3">
      <nav
        className={clsx(styles.sidebar, 'thin-scrollbar')}
        aria-label={translate({
          id: 'theme.blog.sidebar.navAriaLabel',
          message: 'Blog recent posts navigation',
          description: 'The ARIA label for recent posts in the blog sidebar',
        })}>

        <div className={styles.sidebarItemTitle}>
          {"New posts (2024–)"}
        </div>
        <div style={{ marginBottom: "2rem", fontWeight: "bold", fontSize: "1.2rem" }}>
          <Link to="https://chsm.dev/blog" style={{ color: "#fbb946" }}>Blog moved to chsm.dev 🢅</Link>
        </div>
        <div className={clsx(styles.sidebarItemTitle, 'margin-bottom--md')}>
          {"Blog archive (2022–24)"}
        </div>

        <ul className={clsx(styles.sidebarItemList, 'clean-list')}>
          {items.map((item) => (
            <li key={item.permalink} className={styles.sidebarItem}>
              <Link
                isNavLink
                to={item.permalink}
                className={styles.sidebarItemLink}
                activeClassName={styles.sidebarItemLinkActive}>
                {item.title}
              </Link>
            </li>
          ))}
        </ul>
      </nav>
    </aside>
  );
}
