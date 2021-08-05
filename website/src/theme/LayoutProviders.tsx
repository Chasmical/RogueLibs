import React from 'react';
import OriginalLayoutProviders from '@theme-original/LayoutProviders';
import { StorageProvider } from '../components/hooks/useStorage';

export default function (props: any) {
  return (
    <StorageProvider>
      <OriginalLayoutProviders {...props}/>
    </StorageProvider>
  );
}