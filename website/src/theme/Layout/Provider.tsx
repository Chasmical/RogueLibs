import React from 'react';
import Provider from '@theme-original/Layout/Provider';
import { StorageProvider } from '../../components/hooks/useStorage';

export default function ProviderWrapper(props: any) {
  return (
    <StorageProvider>
      <Provider {...props}/>
    </StorageProvider>
  );
}
