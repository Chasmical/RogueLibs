import React from 'react';
import clsx from 'clsx';
import styles from './HomepageFeatures.module.css';
import Translate from '@docusaurus/Translate';
import svg1 from '@site/static/img/undraw_docusaurus_mountain.png';
import svg2 from '@site/static/img/undraw_docusaurus_tree.png';

const FeatureList: FeatureProps[] = [
  {
    title: (
      <Translate id="features.easy.title">
        Easy to Use
      </Translate>
    ),
    svg: svg1,
    description: (
      <Translate id="features.easy.description">
        RogueLibs does all of the patching for you!
      </Translate>
    ),
  },
  {
    title: (
      <Translate id="features.focus.title">
        Focus on What Matters
      </Translate>
    ),
    svg: svg2,
    description: (
      <span>
        <Translate id="features.focus.description">
          Let RogueLibs handle the hard work, and
        </Translate>
        {' '}
        <b>
          <Translate id="features.focus.description.bold">
            you just focus on the content!
          </Translate>
        </b>
      </span>
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
