import React from 'react';
import CodeBlock from '@theme/CodeBlock';

export default function ({children, language, ...props}) {
  return (
    <CodeBlock className={language || "language-csharp"} {...props}>
      {children.replace(/\t/g, '    ')}
    </CodeBlock>
  )
};