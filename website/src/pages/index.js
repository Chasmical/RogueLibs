import React from 'react';
import clsx from 'clsx';
import Layout from '@theme/Layout';
import Link from '@docusaurus/Link';
import useDocusaurusContext from '@docusaurus/useDocusaurusContext';
import styles from './index.module.css';
import HomepageFeatures from '../components/HomepageFeatures';
import useThemeContext from '@theme/hooks/useThemeContext';
import Logo from '@site/static/img/logo.png';
import LogoDark from '@site/static/img/logo-inverted.png';
import Translate, {translate} from '@docusaurus/Translate';

function HomepageHeader() {
  const {siteConfig} = useDocusaurusContext();
  const { isDarkTheme } = useThemeContext();
  return (
    <header className={clsx('hero hero--primary', styles.heroBanner)}>
      <div className="container">
        <img src={isDarkTheme ? LogoDark : Logo} width='50%'/>
        <p className="hero__subtitle">
          <Translate id="homepage.tagline">
            Doing the impossible.
          </Translate>
        </p>
        <div className={styles.buttons}>
          <Link
            className="button button--secondary button--lg"
            to="/docs/intro">
            <Translate id="homepage.button"
              description="The big button in the center on the home page">
              RogueLibs Documentation
            </Translate>
          </Link>
        </div>
      </div>
    </header>
  );
}

export default function Home() {
  const {siteConfig} = useDocusaurusContext();
  return (
    <Layout
      title={`${siteConfig.title}`}
      description="RogueLibs Modding Library for Streets of Rogue">
      <HomepageHeader />
      <main>
        <HomepageFeatures />
      </main>
    </Layout>
  );
}
