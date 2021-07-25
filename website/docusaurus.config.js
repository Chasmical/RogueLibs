/** @type {import('@docusaurus/types').DocusaurusConfig} */
module.exports = {
  title: 'RogueLibs Documentation',
  tagline: 'Doing the impossible.',
  url: 'https://abbysssal.github.io',
  baseUrl: '/RogueLibs/',
  onBrokenLinks: 'throw',
  onBrokenMarkdownLinks: 'warn',
  favicon: 'img/favicon.ico',
  organizationName: 'Abbysssal',
  projectName: 'RogueLibs',
  i18n: {
    defaultLocale: 'en',
    locales: ['en', 'ru'],
    localeConfigs: {
      'en': {
        label: 'English',
      },
      'ru': {
        label: 'Русский',
      },
    },
  },
  // plugins: ['docusaurus-plugin-fontloader'],
  themeConfig: {
    hideableSidebar: true,
    prism: {
      theme: require('prism-react-renderer/themes/dracula'),
      additionalLanguages: ['clike', 'csharp', 'bash'],
    },
    announcementBar: {
      id: 'star',
      content:
        '<span style="font-size: 1rem;">⭐️ If you like RogueLibs, give it a star on <a target="_blank" href="https://github.com/Abbysssal/RogueLibs">GitHub</a>! ⭐️</span>',
    },
    navbar: {
      hideOnScroll: true,
      title: '',
      logo: {
        alt: 'RogueLibs Logo',
        src: 'img/logo.png',
        srcDark: 'img/logo-inverted.png',
      },
      items: [
        {
          to: 'docs/intro',
          label: 'Introduction',
          position: 'left',
        },
        {
          to: 'docs/getting-started',
          label: 'Documentation',
          position: 'left',
        },
        {
          to: 'docs/intro',
          label: 'API',
          position: 'left',
        },
        {
          type: 'localeDropdown',
          position: 'right',
        },
        {
          href: 'https://github.com/Abbysssal/RogueLibs',
          position: 'right',
          className: 'header-github-link',
          'aria-label': 'GitHub repository',
        },
      ],
    },
    footer: {
      style: 'dark',
      links: [
        {
          title: 'Docs',
          items: [
            {
              label: 'Introduction',
              to: 'docs/intro',
            },
          ],
        },
        {
          title: 'Community',
          items: [
            {
              label: 'Streets of Rogue Discord',
              href: 'https://discord.com/invite/streetsofrogue',
            }
          ],
        },
        {
          title: 'More',
          items: [
            {
              label: 'GitHub',
              href: 'https://github.com/Abbysssal/RogueLibs',
            },
          ],
        },
      ],
      copyright: `Copyright © ${new Date().getFullYear()} RogueLibs. Built with Docusaurus.`,
    },
  },
  presets: [
    [
      '@docusaurus/preset-classic',
      {
        docs: {
          sidebarPath: require.resolve('./sidebars.js'),
          editUrl:
            'https://github.com/Abbysssal/RogueLibs/edit/master/website/',
        },
        blog: {
          showReadingTime: true,
          editUrl:
            'https://github.com/Abbysssal/RogueLibs/edit/master/website/blog/',
        },
        theme: {
          customCss: require.resolve('./src/css/custom.css'),
        },
      },
    ],
  ],
};
