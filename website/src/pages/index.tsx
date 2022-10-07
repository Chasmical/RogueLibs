import React from 'react';
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

function HomepageHeader() {
  const params = queryParse(useLocation().search);
  let logo = Logo;
  if (params.pokemon !== undefined) logo = LogoPokemon;
  if (params.legacy !== undefined) logo = LogoLegacy;
  return (
    <header className={clsx('hero hero--primary', styles.heroBanner)}>
      <div className="container">
        <img src={logo} width='50%'/>
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
