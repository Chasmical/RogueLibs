import React, { useState } from 'react';

export default function ({color, size, ...props}) {
  size = (size || 14) + 'px';
  return (
    <div style={{display:'inline'}}>
      <div style={{
        display: 'inline-block',
        width: size,
        height: size,
        background: color,
        marginRight: '2px',
      }}/>
      <div style={{display:'inline'}}>
        {color}
      </div>
    </div>
  );
};