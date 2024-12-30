import React from 'react';
import Link from '@docusaurus/Link';
import {useVisibleBlogSidebarItems} from '@docusaurus/theme-common/internal';
import {NavbarSecondaryMenuFiller} from '@docusaurus/theme-common';
function BlogSidebarMobileSecondaryMenu({sidebar}) {
  const items = useVisibleBlogSidebarItems(sidebar.items);
  return (
    <ul className="menu__list">

      <div>
        {"New posts (2024–)"}
      </div>
      <div style={{ marginBottom: "2rem", fontWeight: "bold", fontSize: "1.2rem", marginLeft: "1rem" }}>
        <Link to="https://chsm.dev/blog" style={{ color: "#fbb946" }}>Blog moved to chsm.dev 🢅</Link>
      </div>
      <div>
        {"Blog archive (2022–24)"}
      </div>

      {items.map((item) => (
        <li key={item.permalink} className="menu__list-item">
          <Link
            isNavLink
            to={item.permalink}
            className="menu__link"
            activeClassName="menu__link--active">
            {item.title}
          </Link>
        </li>
      ))}
    </ul>
  );
}
export default function BlogSidebarMobile(props) {
  return (
    <NavbarSecondaryMenuFiller
      component={BlogSidebarMobileSecondaryMenu}
      props={props}
    />
  );
}
