import React from 'react';

export default function ({children, ...props}) {
  return (
    <div role="tabpanel" {...props}>
      {children}
    </div>
  );
}