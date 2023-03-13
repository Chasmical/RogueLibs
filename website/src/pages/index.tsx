import React, { useState, useEffect } from 'react';
import clsx from 'clsx';
import Layout from '@theme/Layout';
import Link from '@docusaurus/Link';
import useDocusaurusContext from '@docusaurus/useDocusaurusContext';
import styles from './index.module.css';
import HomepageFeatures from '../components/HomepageFeatures';
import Logo from '@site/static/img/logo.png';
import LogoPokemon from '@site/static/img/logo-pokemon.png';
import LogoLegacy from '@site/static/img/logo-legacy.png';
import Translate from '@docusaurus/Translate';
import { useLocation } from '@docusaurus/router';
import { parse as queryParse } from 'query-string';
import Head from '@docusaurus/Head';
import BrowserOnly from '@docusaurus/BrowserOnly';

function getLogo(location) {
  const params = queryParse(location.search);
  if (params.pokemon !== undefined) return LogoPokemon;
  if (params.legacy !== undefined) return LogoLegacy;
  return Logo;
}

function HomepageHeader() {
  const location = useLocation();
  const [logo, setLogo] = useState(() => getLogo(location));

  useEffect(() => {
    setLogo(getLogo(location));
  }, [location]);

  return (
    <header className={clsx('hero hero--primary', styles.heroBanner)}>
      <div className="container">
        <BrowserOnly>
          {() => {
            return <img src={logo} width='50%'/>;
          }}
        </BrowserOnly>
        <p className="hero__subtitle">
          <Translate id="homepage.tagline">
            Redefining Limits.
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

  const title = `RogueLibs - SoR Modding Library`;
  const description = `This modding library does nothing on its own, but it provides methods for other mods to easily create custom mutators, items, traits, status effects, abilities, unlocks, menus and even integrate custom sounds and sprites (yep, even TK2D ones)!`;

  return (
    <Layout
      title={`${siteConfig.title}`}
      description="RogueLibs Modding Library for Streets of Rogue">
      <Head>
        <title>{title}</title>

        <meta property="title" content={title}/>
        <meta name="description" content={description}/>

        <meta property="og:title" content={title}/>
        <meta property="og:description" content={description}/>

        <meta name="twitter:title" content={title}/>
        <meta name="twitter:description" content={description}/>
      </Head>
      <HomepageHeader/>
      <main>
        <HomepageFeatures/>
      </main>
    </Layout>
  );
}
