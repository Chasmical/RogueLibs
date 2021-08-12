/**
 * Copyright (c) Facebook, Inc. and its affiliates.
 *
 * This source code is licensed under the MIT license found in the
 * LICENSE file in the root directory of this source tree.
 */
import ExecutionEnvironment from '@docusaurus/ExecutionEnvironment';
import siteConfig from '@generated/docusaurus.config';

export default function(PrismObject: any) {
  if (ExecutionEnvironment.canUseDOM) {
    const {
      themeConfig: {prism: {additionalLanguages = []} = {}},
    } = siteConfig;

    (window as any).Prism = PrismObject;
    additionalLanguages.forEach((lang: string) => {
      require(`prismjs/components/prism-${lang}`);
    });
    delete (window as any).Prism;
  }
}
