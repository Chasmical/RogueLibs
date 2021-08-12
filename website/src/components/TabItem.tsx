import React from 'react';

export type Props = {
  children?: React.ReactNode,
}

export default function ({children, ...props}: Props): JSX.Element {
  return (
    <div role="tabpanel" {...props}>
      {children}
    </div>
  );
}