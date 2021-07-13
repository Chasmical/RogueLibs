import React, { useState } from 'react';

export default function ({children, ...props}) {
  return (
    <div>
      {children}
    </div>
  );
}