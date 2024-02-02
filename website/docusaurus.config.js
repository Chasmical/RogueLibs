import { themes } from "prism-react-renderer";

/** @type {import('@docusaurus/types').DocusaurusConfig} */
export default {
  title: 'RogueLibs Documentation',
  tagline: 'Doing the impossible.',
  url: 'https://chasmical.github.io',
  baseUrl: '/RogueLibs/',
  onBrokenLinks: 'throw',
  onBrokenMarkdownLinks: 'warn',
  favicon: 'img/favicon.ico',
  organizationName: 'Chasmical',
  projectName: 'RogueLibs',
  i18n: {
    defaultLocale: 'en',
    locales: ['en', 'ru'],
    localeConfigs: {
      en: {
        label: 'English',
      },
      ru: {
        label: 'Русский',
      },
    },
  },
  plugins: ['docusaurus-plugin-sass'],
  themeConfig: {
    colorMode: {
      defaultMode: 'dark',
    },
    metadata: [
      { name: "twitter:image", content: "https://chasmical.github.io/RogueLibs/img/logo.png" },
    ],
    docs: {
      sidebar: {
        hideable: true,
      },
    },
    prism: {
      theme: themes.vsDark,
      additionalLanguages: ['clike', 'csharp', 'bash'],
    },
    announcementBar: {
      id: 'discontinued',
      isCloseable: false,
      textColor: 'var(--ifm-color-white)',
      backgroundColor: '#FF5060',
      content: (
        '<span style="font-size: 1rem;">⚰️ RogueLibs has been discontinued. See more information in <a href="/RogueLibs/blog/2024/02/03/discontinuing-roguelibs">the latest blog post</a>. ⚰️</span>'
      ),
    },
    navbar: {
      hideOnScroll: true,
      title: '',
      logo: {
        alt: 'RogueLibs Logo',
        src: 'img/logo-long.png',
      },
      items: [
        {
          to: 'docs/user/installation',
          label: 'Installation',
          position: 'left',
        },
        {
          to: 'docs/dev/getting-started',
          label: 'Documentation',
          position: 'left',
        },
        {
          to: 'blog',
          label: 'Blog',
          position: 'left'
        },
        {
          type: 'localeDropdown',
          position: 'right',
        },
        {
          href: 'https://github.com/Chasmical/RogueLibs',
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
              href: 'https://github.com/Chasmical/RogueLibs',
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
            'https://github.com/Chasmical/RogueLibs/edit/main/website/',
        },
        blog: {
          showReadingTime: true,
          readingTime: ({content, frontMatter, defaultReadingTime}) =>
            defaultReadingTime({content, options: { wordsPerMinute: 240 }}),
          editUrl:
            'https://github.com/Chasmical/RogueLibs/edit/main/website/blog/',
        },
        theme: {
          customCss: require.resolve('./src/css/custom.scss'),
        },
      },
    ],
  ],
};
