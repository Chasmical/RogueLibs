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
  themeConfig: {
    hideableSidebar: true,
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
          to: 'docs/intro',
          label: 'Documentation',
          position: 'left',
        },
        {
          to: 'docs/intro',
          label: 'API',
          position: 'left',
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
