import React, { useState } from 'react';

export type Props = {
  color: string,
  size?: number,
}

export default function ({color, size}: Props): JSX.Element {
  let Size: string = (size || 14) + 'px';
  return (
    <div style={{display:'inline'}}>
      <div style={{
        display: 'inline-block',
        width: Size,
        height: Size,
        background: color,
        marginRight: '2px',
      }}/>
      <div style={{display:'inline'}}>
        {color}
      </div>
    </div>
  );
}