"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[6662],{3905:function(e,t,n){n.d(t,{Zo:function(){return u},kt:function(){return v}});var a=n(7294);function r(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function o(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var a=Object.getOwnPropertySymbols(e);t&&(a=a.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,a)}return n}function i(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?o(Object(n),!0).forEach((function(t){r(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):o(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function s(e,t){if(null==e)return{};var n,a,r=function(e,t){if(null==e)return{};var n,a,r={},o=Object.keys(e);for(a=0;a<o.length;a++)n=o[a],t.indexOf(n)>=0||(r[n]=e[n]);return r}(e,t);if(Object.getOwnPropertySymbols){var o=Object.getOwnPropertySymbols(e);for(a=0;a<o.length;a++)n=o[a],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(r[n]=e[n])}return r}var c=a.createContext({}),l=function(e){var t=a.useContext(c),n=t;return e&&(n="function"==typeof e?e(t):i(i({},t),e)),n},u=function(e){var t=l(e.components);return a.createElement(c.Provider,{value:t},e.children)},m={inlineCode:"code",wrapper:function(e){var t=e.children;return a.createElement(a.Fragment,{},t)}},d=a.forwardRef((function(e,t){var n=e.components,r=e.mdxType,o=e.originalType,c=e.parentName,u=s(e,["components","mdxType","originalType","parentName"]),d=l(n),v=r,p=d["".concat(c,".").concat(v)]||d[v]||m[v]||o;return n?a.createElement(p,i(i({ref:t},u),{},{components:n})):a.createElement(p,i({ref:t},u))}));function v(e,t){var n=arguments,r=t&&t.mdxType;if("string"==typeof e||r){var o=n.length,i=new Array(o);i[0]=d;var s={};for(var c in t)hasOwnProperty.call(t,c)&&(s[c]=t[c]);s.originalType=e,s.mdxType="string"==typeof e?e:r,i[1]=s;for(var l=2;l<o;l++)i[l]=n[l];return a.createElement.apply(null,i)}return a.createElement.apply(null,n)}d.displayName="MDXCreateElement"},1016:function(e,t,n){n.d(t,{Z:function(){return s}});var a=n(7462),r=n(3366),o=n(7294),i=["children"];function s(e){var t=e.children,n=(0,r.Z)(e,i);return o.createElement("div",(0,a.Z)({role:"tabpanel"},n),t)}},2099:function(e,t,n){n.d(t,{Z:function(){return d}});var a=n(7294),r=n(9443);var o=function(){var e=(0,a.useContext)(r.Z);if(null==e)throw new Error('"useUserPreferencesContext" is used outside of "Layout" component.');return e},i=n(6010),s="tabItem_OdQc",c="tabItemActive_YQWB",l="tab_tgHH";var u=37,m=39;function d(e){var t=e.lazy,n=e.defaultValue,r=e.values,d=e.groupId,v=o(),p=v.tabGroupChoices,g=v.setTabGroupChoices,f=(0,a.useState)(n),h=f[0],b=f[1],k=a.Children.toArray(e.children),y=[];if(null!=d){var N=p[d];null!=N&&N!==h&&r.some((function(e){return e.value===N}))&&b(N)}var w=function(e){var t=e.currentTarget,n=y.indexOf(t),a=r[n].value;b(a),null!=d&&(g(d,a),setTimeout((function(){var e,n,a,r,o,i,s,l;(e=t.getBoundingClientRect(),n=e.top,a=e.left,r=e.bottom,o=e.right,i=window,s=i.innerHeight,l=i.innerWidth,n>=0&&o<=l&&r<=s&&a>=0)||(t.scrollIntoView({block:"center",behavior:"smooth"}),t.classList.add(c),setTimeout((function(){return t.classList.remove(c)}),2e3))}),150))},O=function(e){var t;switch(e.keyCode){case m:var n=y.indexOf(e.target)+1;t=y[n]||y[0];break;case u:var a=y.indexOf(e.target)-1;t=y[a]||y[y.length-1];break;default:return}t.focus()},C=function(e,t){return t.value===e||t.values&&-1!=t.values.indexOf(e)};return a.createElement("div",{className:"tabs-container"},a.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:"tabs"},r.map((function(e){var t=e.value,n=e.label;return a.createElement("li",{role:"tab",tabIndex:h===t?0:-1,"aria-selected":h===t,className:(0,i.Z)("tabs__item",s,{"tabs__item--active":h===t}),key:t,ref:function(e){return e&&y.push(e)},onKeyDown:O,onFocus:w,onClick:w},n)}))),t?a.cloneElement(k.find((function(e){return C(h,e.props)})),{className:l}):a.createElement("div",null,k.map((function(e,t){return a.cloneElement(e,{key:t,hidden:!C(h,e.props),className:l})}))),a.createElement("br",null))}},7100:function(e,t,n){n.r(t),n.d(t,{frontMatter:function(){return s},contentTitle:function(){return c},metadata:function(){return l},toc:function(){return u},default:function(){return d}});var a=n(7462),r=n(3366),o=(n(7294),n(3905)),i=(n(2099),n(1016),n(4996),["components"]),s={},c="Custom Languages*",l={unversionedId:"dev/names/custom-languages",id:"dev/names/custom-languages",title:"Custom Languages*",description:"You can add your custom languages to the game using LanguageService.RegisterLanguageCode method:",source:"@site/docs/dev/names/custom-languages.mdx",sourceDirName:"dev/names",slug:"/dev/names/custom-languages",permalink:"/RogueLibs/docs/dev/names/custom-languages",editUrl:"https://github.com/Abbysssal/RogueLibs/edit/main/website/docs/dev/names/custom-languages.mdx",tags:[],version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"Custom Names",permalink:"/RogueLibs/docs/dev/names/custom-names"},next:{title:"Custom Name Providers",permalink:"/RogueLibs/docs/dev/names/name-providers"}},u=[{value:"<code>LanguageService</code>",id:"languageservice",children:[],level:2},{value:"Adding localizations for mods",id:"localizations",children:[],level:2}],m={toc:u};function d(e){var t=e.components,n=(0,r.Z)(e,i);return(0,o.kt)("wrapper",(0,a.Z)({},m,n,{components:t,mdxType:"MDXLayout"}),(0,o.kt)("h1",{id:"custom-languages"},"Custom Languages*"),(0,o.kt)("p",null,"You can add your custom languages to the game using ",(0,o.kt)("inlineCode",{parentName:"p"},"LanguageService.RegisterLanguageCode")," method:"),(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-csharp"},'LanguageService.RegisterLanguageCode("japanese", (LanguageCode)123);\n')),(0,o.kt)("div",{className:"admonition admonition-info alert alert--info"},(0,o.kt)("div",{parentName:"div",className:"admonition-heading"},(0,o.kt)("h5",{parentName:"div"},(0,o.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,o.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,o.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M7 2.3c3.14 0 5.7 2.56 5.7 5.7s-2.56 5.7-5.7 5.7A5.71 5.71 0 0 1 1.3 8c0-3.14 2.56-5.7 5.7-5.7zM7 1C3.14 1 0 4.14 0 8s3.14 7 7 7 7-3.14 7-7-3.14-7-7-7zm1 3H6v5h2V4zm0 6H6v2h2v-2z"}))),"Work-In-Progress")),(0,o.kt)("div",{parentName:"div",className:"admonition-content"})),(0,o.kt)("h2",{id:"languageservice"},(0,o.kt)("inlineCode",{parentName:"h2"},"LanguageService")),(0,o.kt)("p",null,(0,o.kt)("inlineCode",{parentName:"p"},"LanguageService")," is a static class, that contains all of the things related to localization."),(0,o.kt)("div",{className:"admonition admonition-info alert alert--info"},(0,o.kt)("div",{parentName:"div",className:"admonition-heading"},(0,o.kt)("h5",{parentName:"div"},(0,o.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,o.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,o.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M7 2.3c3.14 0 5.7 2.56 5.7 5.7s-2.56 5.7-5.7 5.7A5.71 5.71 0 0 1 1.3 8c0-3.14 2.56-5.7 5.7-5.7zM7 1C3.14 1 0 4.14 0 8s3.14 7 7 7 7-3.14 7-7-3.14-7-7-7zm1 3H6v5h2V4zm0 6H6v2h2v-2z"}))),"Work-In-Progress")),(0,o.kt)("div",{parentName:"div",className:"admonition-content"})),(0,o.kt)("h2",{id:"localizations"},"Adding localizations for mods"),(0,o.kt)("div",{className:"admonition admonition-info alert alert--info"},(0,o.kt)("div",{parentName:"div",className:"admonition-heading"},(0,o.kt)("h5",{parentName:"div"},(0,o.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,o.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,o.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M7 2.3c3.14 0 5.7 2.56 5.7 5.7s-2.56 5.7-5.7 5.7A5.71 5.71 0 0 1 1.3 8c0-3.14 2.56-5.7 5.7-5.7zM7 1C3.14 1 0 4.14 0 8s3.14 7 7 7 7-3.14 7-7-3.14-7-7-7zm1 3H6v5h2V4zm0 6H6v2h2v-2z"}))),"Work-In-Progress")),(0,o.kt)("div",{parentName:"div",className:"admonition-content"})))}d.isMDXComponent=!0}}]);