import clsx from "clsx";
import React, { useState } from "react";
import styles from './index.module.css';

import QuestionSrc from './QuestionRed.png';
import AnswerSrc from './Exclamation.png';

export type QuestionProps = {
  children?: React.ReactNode,
}

export function Question({children}: QuestionProps): JSX.Element {

  return (
    <div className={styles.question}>
      <img width="24" height="32" src={QuestionSrc}/>
      <div className={styles.questionBody}>
        {children}
      </div>
    </div>
  );
}

export type Props = {
  children?: React.ReactNode,
}

export default function ({children}: Props): JSX.Element {

  const [expanded, setExpanded] = useState(false);

  const childrenArr = React.Children.toArray(children);
  const questions = childrenArr.filter(c => (c as any)?.props?.mdxType === "Question");
  const answer = childrenArr.filter(c => (c as any)?.props?.mdxType !== "Question");

  return (
    <div className={styles.faq} onClick={() => setExpanded(!expanded)}>
      {questions}
      {expanded &&
        <div className={styles.answer}>
          <img width="24" height="32" src={AnswerSrc}/>
          <div className={styles.answerBody}>
            {answer}
          </div>
        </div>
      }
    </div>
  );
}