"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[4912],{3905:function(e,t,n){n.d(t,{Zo:function(){return c},kt:function(){return m}});var o=n(7294);function r(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function i(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var o=Object.getOwnPropertySymbols(e);t&&(o=o.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,o)}return n}function a(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?i(Object(n),!0).forEach((function(t){r(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):i(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function l(e,t){if(null==e)return{};var n,o,r=function(e,t){if(null==e)return{};var n,o,r={},i=Object.keys(e);for(o=0;o<i.length;o++)n=i[o],t.indexOf(n)>=0||(r[n]=e[n]);return r}(e,t);if(Object.getOwnPropertySymbols){var i=Object.getOwnPropertySymbols(e);for(o=0;o<i.length;o++)n=i[o],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(r[n]=e[n])}return r}var s=o.createContext({}),p=function(e){var t=o.useContext(s),n=t;return e&&(n="function"==typeof e?e(t):a(a({},t),e)),n},c=function(e){var t=p(e.components);return o.createElement(s.Provider,{value:t},e.children)},d={inlineCode:"code",wrapper:function(e){var t=e.children;return o.createElement(o.Fragment,{},t)}},u=o.forwardRef((function(e,t){var n=e.components,r=e.mdxType,i=e.originalType,s=e.parentName,c=l(e,["components","mdxType","originalType","parentName"]),u=p(n),m=r,h=u["".concat(s,".").concat(m)]||u[m]||d[m]||i;return n?o.createElement(h,a(a({ref:t},c),{},{components:n})):o.createElement(h,a({ref:t},c))}));function m(e,t){var n=arguments,r=t&&t.mdxType;if("string"==typeof e||r){var i=n.length,a=new Array(i);a[0]=u;var l={};for(var s in t)hasOwnProperty.call(t,s)&&(l[s]=t[s]);l.originalType=e,l.mdxType="string"==typeof e?e:r,a[1]=l;for(var p=2;p<i;p++)a[p]=n[p];return o.createElement.apply(null,a)}return o.createElement.apply(null,n)}u.displayName="MDXCreateElement"},86:function(e,t,n){n.r(t),n.d(t,{frontMatter:function(){return l},contentTitle:function(){return s},metadata:function(){return p},toc:function(){return c},default:function(){return u}});var o=n(7462),r=n(3366),i=(n(7294),n(3905)),a=["components"],l={},s="Introduction",p={unversionedId:"site/intro",id:"site/intro",title:"Introduction",description:"So, you want to create a cool-looking website for your mod/plugin?",source:"@site/docs/site/intro.mdx",sourceDirName:"site",slug:"/site/intro",permalink:"/RogueLibs/docs/site/intro",editUrl:"https://github.com/Abbysssal/RogueLibs/edit/main/website/docs/site/intro.mdx",tags:[],version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"Hook Factories",permalink:"/RogueLibs/docs/dev/hooks/hook-factories"},next:{title:"Components Index",permalink:"/RogueLibs/docs/site/"}},c=[{value:"Using the template",id:"using-my-template",children:[],level:2},{value:"Deploying the website",id:"deploying-website",children:[{value:"Generate a SSH key",id:"generate-ssh-key",children:[],level:3},{value:"Create a deploy key on GitHub",id:"create-deploy-key",children:[],level:3},{value:"Create a GitHub secret",id:"create-secret",children:[],level:3},{value:"Trigger the workflow",id:"trigger-workflow",children:[],level:3}],level:2},{value:"Adding components",id:"adding-components",children:[],level:2}],d={toc:c};function u(e){var t=e.components,n=(0,r.Z)(e,a);return(0,i.kt)("wrapper",(0,o.Z)({},d,n,{components:t,mdxType:"MDXLayout"}),(0,i.kt)("h1",{id:"introduction"},"Introduction"),(0,i.kt)("p",null,"So, you want to create a cool-looking website for your mod/plugin?"),(0,i.kt)("p",null,"In this tutorial we'll be using Docusaurus, and we'll be deploying the site using GitHub Pages."),(0,i.kt)("div",{className:"admonition admonition-info alert alert--info"},(0,i.kt)("div",{parentName:"div",className:"admonition-heading"},(0,i.kt)("h5",{parentName:"div"},(0,i.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,i.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,i.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M7 2.3c3.14 0 5.7 2.56 5.7 5.7s-2.56 5.7-5.7 5.7A5.71 5.71 0 0 1 1.3 8c0-3.14 2.56-5.7 5.7-5.7zM7 1C3.14 1 0 4.14 0 8s3.14 7 7 7 7-3.14 7-7-3.14-7-7-7zm1 3H6v5h2V4zm0 6H6v2h2v-2z"}))),"info")),(0,i.kt)("div",{parentName:"div",className:"admonition-content"},(0,i.kt)("p",{parentName:"div"},"You can follow the Docusaurus instructions ",(0,i.kt)("a",{parentName:"p",href:"https://docusaurus.io/docs/next/installation"},"here"),", or you can use the template below."))),(0,i.kt)("h2",{id:"using-my-template"},"Using the template"),(0,i.kt)("p",null,"This template is like the default ",(0,i.kt)("inlineCode",{parentName:"p"},"classic"),", but without any unnecessary stuff."),(0,i.kt)("p",null,(0,i.kt)("a",{parentName:"p",href:"https://drive.google.com/file/d/18jw5SKAGdxes-WKaze3n44x98Inn8Ksh/view?usp=sharing"},"Download the template")," and extract the ",(0,i.kt)("inlineCode",{parentName:"p"},"website")," folder into your solution's folder."),(0,i.kt)("p",null,"You'll see a file called ",(0,i.kt)("inlineCode",{parentName:"p"},"[[PROJECT-NAME]] (website).code-workspace")," in the ",(0,i.kt)("inlineCode",{parentName:"p"},"website")," directory.",(0,i.kt)("br",{parentName:"p"}),"\n","Replace ",(0,i.kt)("inlineCode",{parentName:"p"},"[[PROJECT-NAME]]")," with the name of your project."),(0,i.kt)("p",null,"Then open that workspace file, go to Search and replace the following in all files:"),(0,i.kt)("ul",null,(0,i.kt)("li",{parentName:"ul"},(0,i.kt)("inlineCode",{parentName:"li"},"[[PROJECT-NAME]]")," - the name of your project."),(0,i.kt)("li",{parentName:"ul"},(0,i.kt)("inlineCode",{parentName:"li"},"[[USERNAME]]")," - your username on GitHub."),(0,i.kt)("li",{parentName:"ul"},(0,i.kt)("inlineCode",{parentName:"li"},"[[REPOSITORY]]")," - your project's repository name on GitHub."),(0,i.kt)("li",{parentName:"ul"},(0,i.kt)("inlineCode",{parentName:"li"},"[[MAIN-BRANCH]]")," - your repository's default branch (",(0,i.kt)("inlineCode",{parentName:"li"},"master")," or ",(0,i.kt)("inlineCode",{parentName:"li"},"main"),")."),(0,i.kt)("li",{parentName:"ul"},(0,i.kt)("inlineCode",{parentName:"li"},"[[LOGO-ALT-TEXT]]")," - ",(0,i.kt)("inlineCode",{parentName:"li"},"alt")," text, describing your logo."),(0,i.kt)("li",{parentName:"ul"},(0,i.kt)("inlineCode",{parentName:"li"},"[[EMAIL]]")," - your e-mail (required for the workflow).")),(0,i.kt)("p",null,"Also replace the images in ",(0,i.kt)("inlineCode",{parentName:"p"},"static/img"),": ",(0,i.kt)("inlineCode",{parentName:"p"},"favicon.ico"),", ",(0,i.kt)("inlineCode",{parentName:"p"},"logo.png")," and ",(0,i.kt)("inlineCode",{parentName:"p"},"logo-dark.png"),". (",(0,i.kt)("a",{parentName:"p",href:"https://convertio.co/ico-converter"},".ico converter"),")"),(0,i.kt)("p",null,"Then move the ",(0,i.kt)("inlineCode",{parentName:"p"},".github")," directory up one level, so it's in the root of your repository and push the changes."),(0,i.kt)("h2",{id:"deploying-website"},"Deploying the website"),(0,i.kt)("div",{className:"admonition admonition-note alert alert--secondary"},(0,i.kt)("div",{parentName:"div",className:"admonition-heading"},(0,i.kt)("h5",{parentName:"div"},(0,i.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,i.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,i.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.3 5.69a.942.942 0 0 1-.28-.7c0-.28.09-.52.28-.7.19-.18.42-.28.7-.28.28 0 .52.09.7.28.18.19.28.42.28.7 0 .28-.09.52-.28.7a1 1 0 0 1-.7.3c-.28 0-.52-.11-.7-.3zM8 7.99c-.02-.25-.11-.48-.31-.69-.2-.19-.42-.3-.69-.31H6c-.27.02-.48.13-.69.31-.2.2-.3.44-.31.69h1v3c.02.27.11.5.31.69.2.2.42.31.69.31h1c.27 0 .48-.11.69-.31.2-.19.3-.42.31-.69H8V7.98v.01zM7 2.3c-3.14 0-5.7 2.54-5.7 5.68 0 3.14 2.56 5.7 5.7 5.7s5.7-2.55 5.7-5.7c0-3.15-2.56-5.69-5.7-5.69v.01zM7 .98c3.86 0 7 3.14 7 7s-3.14 7-7 7-7-3.12-7-7 3.14-7 7-7z"}))),"note")),(0,i.kt)("div",{parentName:"div",className:"admonition-content"},(0,i.kt)("p",{parentName:"div"},"I find ",(0,i.kt)("a",{parentName:"p",href:"https://docusaurus.io/docs/next/deployment#triggering-deployment-with-github-actions"},"Docusaurus docs on that")," a little bit confusing, so here's my version of these instructions."))),(0,i.kt)("h3",{id:"generate-ssh-key"},"Generate a SSH key"),(0,i.kt)("ol",null,(0,i.kt)("li",{parentName:"ol"},"Open the command line and generate a SSH key:\n",(0,i.kt)("inlineCode",{parentName:"li"},'ssh-keygen -t ed25519 -C "[[EMAIL]]"'),";"),(0,i.kt)("li",{parentName:"ol"},'When you\'re prompted to "Enter a file in which to save the key," press Enter. This accepts the default file location;'),(0,i.kt)("li",{parentName:"ol"},'When you\'re prompted to "Enter a passphrase," press Enter (no passphrase);'),(0,i.kt)("li",{parentName:"ol"},"When you're prompted to repeat the passphrase, press Enter again;")),(0,i.kt)("p",null,"You'll find the keys in your profile's directory (",(0,i.kt)("inlineCode",{parentName:"p"},"C:\\Users\\[[UserName]]\\.ssh")," or ",(0,i.kt)("inlineCode",{parentName:"p"},"~/.ssh"),")."),(0,i.kt)("h3",{id:"create-deploy-key"},"Create a deploy key on GitHub"),(0,i.kt)("ol",null,(0,i.kt)("li",{parentName:"ol"},"Go to your GitHub repository's ",(0,i.kt)("strong",{parentName:"li"},"Settings > Deploy Keys > Add deploy key"),";"),(0,i.kt)("li",{parentName:"ol"},"Paste the contents of the ",(0,i.kt)("inlineCode",{parentName:"li"},"id_ed25519.pub")," file;"),(0,i.kt)("li",{parentName:"ol"},'Check the "Allow write access" box;'),(0,i.kt)("li",{parentName:"ol"},"Save (the key's name doesn't matter, you can call it ",(0,i.kt)("inlineCode",{parentName:"li"},"DeployKey1")," or something like that);")),(0,i.kt)("h3",{id:"create-secret"},"Create a GitHub secret"),(0,i.kt)("ol",null,(0,i.kt)("li",{parentName:"ol"},"Go to your GitHub repository's ",(0,i.kt)("strong",{parentName:"li"},"Settings > Secrets > New repository secret"),";"),(0,i.kt)("li",{parentName:"ol"},"Paste the contents of the ",(0,i.kt)("inlineCode",{parentName:"li"},"id_ed25519")," file;"),(0,i.kt)("li",{parentName:"ol"},"Call the secret ",(0,i.kt)("inlineCode",{parentName:"li"},"GH_PAGES_DEPLOY"),";"),(0,i.kt)("li",{parentName:"ol"},"Save your secret;")),(0,i.kt)("h3",{id:"trigger-workflow"},"Trigger the workflow"),(0,i.kt)("ol",null,(0,i.kt)("li",{parentName:"ol"},"Push the website to the repository, if you didn't already;"),(0,i.kt)("li",{parentName:"ol"},"Go to your GitHub repository's ",(0,i.kt)("strong",{parentName:"li"},"Actions > documentation.yml"),";"),(0,i.kt)("li",{parentName:"ol"},"If the workflow didn't trigger on its own, start it.")),(0,i.kt)("div",{className:"admonition admonition-note alert alert--secondary"},(0,i.kt)("div",{parentName:"div",className:"admonition-heading"},(0,i.kt)("h5",{parentName:"div"},(0,i.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,i.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,i.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.3 5.69a.942.942 0 0 1-.28-.7c0-.28.09-.52.28-.7.19-.18.42-.28.7-.28.28 0 .52.09.7.28.18.19.28.42.28.7 0 .28-.09.52-.28.7a1 1 0 0 1-.7.3c-.28 0-.52-.11-.7-.3zM8 7.99c-.02-.25-.11-.48-.31-.69-.2-.19-.42-.3-.69-.31H6c-.27.02-.48.13-.69.31-.2.2-.3.44-.31.69h1v3c.02.27.11.5.31.69.2.2.42.31.69.31h1c.27 0 .48-.11.69-.31.2-.19.3-.42.31-.69H8V7.98v.01zM7 2.3c-3.14 0-5.7 2.54-5.7 5.68 0 3.14 2.56 5.7 5.7 5.7s5.7-2.55 5.7-5.7c0-3.15-2.56-5.69-5.7-5.69v.01zM7 .98c3.86 0 7 3.14 7 7s-3.14 7-7 7-7-3.12-7-7 3.14-7 7-7z"}))),"note")),(0,i.kt)("div",{parentName:"div",className:"admonition-content"},(0,i.kt)("p",{parentName:"div"},"If there aren't any errors, the website will be deployed at ",(0,i.kt)("inlineCode",{parentName:"p"},"[[USERNAME]].github.io/[[REPOSITORY]]/"),".",(0,i.kt)("br",{parentName:"p"}),"\n","If there are errors, you'll see them in the details of the workflow run."))),(0,i.kt)("h2",{id:"adding-components"},"Adding components"),(0,i.kt)("p",null,"Clone or download the RogueLibs' repository and copy-paste the components from there into your website."),(0,i.kt)("p",null,"Components probably won't be versioned, so you'll have to look for updates yourself."))}u.isMDXComponent=!0}}]);