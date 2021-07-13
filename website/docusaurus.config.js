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
  },
  // plugins: ['docusaurus-plugin-fontloader'],
  themeConfig: {
    hideableSidebar: true,
    prism: {
      theme: require('prism-react-renderer/themes/dracula'),
      additionalLanguages: ['clike', 'csharp', 'bash'],
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
            'https://github.com/Abbysssal/RogueLibs/edit/master/docs/',
        },
        blog: {
          showReadingTime: true,
          editUrl:
            'https://github.com/Abbysssal/RogueLibs/edit/master/docs/blog/',
        },
        theme: {
          customCss: require.resolve('./src/css/custom.css'),
        },
      },
    ],
  ],
};
