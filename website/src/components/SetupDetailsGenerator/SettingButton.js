import React, { useState } from 'react';
import useBaseUrl from '@docusaurus/useBaseUrl';

export default function ({values, onChange, ...props}) {
  values = values || [];
  const [curIndex, setCurIndex] = useState(0);

  const clickHandler = () => {
    let newIndex = curIndex + 1;
    if (newIndex >= values.length) newIndex = 0;
    setCurIndex(newIndex);
    onChange(values[newIndex].value);
  };

  let selected = values[curIndex];

  return (
    <div>
      <input type="button" onClick={clickHandler}>
        <img width="32" height="32" src={selected.image} alt={selected.label}/>
      </input>
    </div>
  );
}