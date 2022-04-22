import React from 'react';
import clsx from 'clsx';
import styles from './HomepageFeatures.module.css';
import Translate from '@docusaurus/Translate';
import SpritesImage from '@site/static/img/features/Sprites.jpg';
import InteractionsImage from '@site/static/img/features/Interactions.gif';
import MutatorsImage from '@site/static/img/features/Mutators.jpg';
import AbilitiesImage from '@site/static/img/features/Abilities.jpg';
import ItemsImage from '@site/static/img/features/Items.jpg';
import TraitsImage from '@site/static/img/features/Traits.jpg';

const FeatureList: FeatureProps[] = [
  {
    title: (
      <Translate id="features.sprites.title">
        {"Custom Sprites"}
      </Translate>
    ),
    svg: SpritesImage,
    description: (
      <Translate id="features.sprites.description">
        {"RogueLibs allows you to add your own and modify existing tk2d/Unity sprites!"}
      </Translate>
    ),
  },
  {
    title: (
      <Translate id="features.interactions.title">
        {"Custom Interactions"}
      </Translate>
    ),
    svg: InteractionsImage,
    description: (
      <Translate id="features.interactions.description">
        {"Ever wondered why SoR doesn't have certain interactions? It's time for you to fill in the blanks!"}
      </Translate>
    ),
  },
  {
    title: (
      <Translate id="features.items.title">
        {"Custom Items"}
      </Translate>
    ),
    svg: ItemsImage,
    description: (
      <Translate id="features.items.description">
        {"Adding custom items with various usages and effects could not be easier with RogueLibs!"}
      </Translate>
    ),
  },
  {
    title: (
      <Translate id="features.mutators.title">
        {"Custom Mutators"}
      </Translate>
    ),
    svg: MutatorsImage,
    description: (
      <Translate id="features.mutators.description">
        {"Mutators are pretty cool!"}
      </Translate>
    ),
  },
  {
    title: (
      <Translate id="features.abilities.title">
        {"Custom Abilities"}
      </Translate>
    ),
    svg: AbilitiesImage,
    description: (
      <Translate id="features.abilities.description">
        {"Yep, RogueLibs also has custom abilities!"}
      </Translate>
    ),
  },
  {
    title: (
      <Translate id="features.traits.title">
        {"Custom Traits"}
      </Translate>
    ),
    svg: TraitsImage,
    description: (
      <Translate id="features.traits.description">
        {"And traits too!"}
      </Translate>
    ),
  },
];

type FeatureProps = {
  title: React.ReactNode,
  description: React.ReactNode,
  svg?: string,
}

function Feature({svg, title, description}: FeatureProps): JSX.Element {
  return (
    <div className={clsx('col col--4')}>
      <div className="text--center">
        <img src={svg} className={styles.featureSvg} alt={typeof title === "string" ? title : undefined}/>
      </div>
      <div className="text--center padding-horiz--md">
        <h3>{title}</h3>
        <p>{description}</p>
      </div>
    </div>
  );
}

export default function HomepageFeatures(): JSX.Element {
  return (
    <section className={styles.features}>
      <div className="container">
        <div className="row">
          {FeatureList.map((props, idx) => (
            <Feature key={idx} {...props}/>
          ))}
        </div>
      </div>
    </section>
  );
}
