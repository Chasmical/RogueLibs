import React from 'react';
import CodeBlock from '@theme/CodeBlock';

export type Props = {
  language?: string,
  children: string,
}

export default function ({children, language}: Props): JSX.Element {
  return (
    <CodeBlock className={"language-" + (language || "csharp")}>
      {children.replace(/\t/g, '    ')}
    </CodeBlock>
  );
}