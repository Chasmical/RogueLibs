(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[647],{3905:function(e,t,n){"use strict";n.d(t,{Zo:function(){return u},kt:function(){return m}});var a=n(7294);function o(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function r(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var a=Object.getOwnPropertySymbols(e);t&&(a=a.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,a)}return n}function i(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?r(Object(n),!0).forEach((function(t){o(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):r(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function s(e,t){if(null==e)return{};var n,a,o=function(e,t){if(null==e)return{};var n,a,o={},r=Object.keys(e);for(a=0;a<r.length;a++)n=r[a],t.indexOf(n)>=0||(o[n]=e[n]);return o}(e,t);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(e);for(a=0;a<r.length;a++)n=r[a],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(o[n]=e[n])}return o}var c=a.createContext({}),l=function(e){var t=a.useContext(c),n=t;return e&&(n="function"==typeof e?e(t):i(i({},t),e)),n},u=function(e){var t=l(e.components);return a.createElement(c.Provider,{value:t},e.children)},p={inlineCode:"code",wrapper:function(e){var t=e.children;return a.createElement(a.Fragment,{},t)}},d=a.forwardRef((function(e,t){var n=e.components,o=e.mdxType,r=e.originalType,c=e.parentName,u=s(e,["components","mdxType","originalType","parentName"]),d=l(n),m=o,f=d["".concat(c,".").concat(m)]||d[m]||p[m]||r;return n?a.createElement(f,i(i({ref:t},u),{},{components:n})):a.createElement(f,i({ref:t},u))}));function m(e,t){var n=arguments,o=t&&t.mdxType;if("string"==typeof e||o){var r=n.length,i=new Array(r);i[0]=d;var s={};for(var c in t)hasOwnProperty.call(t,c)&&(s[c]=t[c]);s.originalType=e,s.mdxType="string"==typeof e?e:o,i[1]=s;for(var l=2;l<r;l++)i[l]=n[l];return a.createElement.apply(null,i)}return a.createElement.apply(null,n)}d.displayName="MDXCreateElement"},3919:function(e,t,n){"use strict";function a(e){return!0===/^(\w*:|\/\/)/.test(e)}function o(e){return void 0!==e&&!a(e)}n.d(t,{b:function(){return a},Z:function(){return o}})},4996:function(e,t,n){"use strict";n.d(t,{C:function(){return r},Z:function(){return i}});var a=n(2263),o=n(3919);function r(){var e=(0,a.Z)().siteConfig,t=(e=void 0===e?{}:e).baseUrl,n=void 0===t?"/":t,r=e.url;return{withBaseUrl:function(e,t){return function(e,t,n,a){var r=void 0===a?{}:a,i=r.forcePrependBaseUrl,s=void 0!==i&&i,c=r.absolute,l=void 0!==c&&c;if(!n)return n;if(n.startsWith("#"))return n;if((0,o.b)(n))return n;if(s)return t+n;var u=n.startsWith(t)?n:t+n.replace(/^\//,"");return l?e+u:u}(r,n,e,t)}}}function i(e,t){return void 0===t&&(t={}),(0,r().withBaseUrl)(e,t)}},9443:function(e,t,n){"use strict";var a=(0,n(7294).createContext)(void 0);t.Z=a},9309:function(e,t,n){"use strict";n.d(t,{Z:function(){return s}});var a=n(2122),o=n(9756),r=n(7294),i=["children"];function s(e){var t=e.children,n=(0,o.Z)(e,i);return r.createElement("div",(0,a.Z)({role:"tabpanel"},n),t)}},8952:function(e,t,n){"use strict";n.d(t,{Z:function(){return d}});var a=n(7294),o=n(9443);var r=function(){var e=(0,a.useContext)(o.Z);if(null==e)throw new Error('"useUserPreferencesContext" is used outside of "Layout" component.');return e},i=n(6010),s="tabItem_2O3c",c="tabItemActive_Fpbe",l="tab_1pgU";var u=37,p=39;var d=function(e){var t=e.lazy,n=e.block,o=e.defaultValue,d=e.values,m=e.groupId,f=e.className,h=r(),g=h.tabGroupChoices,v=h.setTabGroupChoices,y=(0,a.useState)(o),b=y[0],C=y[1],k=a.Children.toArray(e.children),I=[];if(null!=m){var N=g[m];null!=N&&N!==b&&d.some((function(e){return e.value===N}))&&C(N)}var w=function(e){var t=e.currentTarget,n=I.indexOf(t),a=d[n].value;C(a),null!=m&&(v(m,a),setTimeout((function(){var e,n,a,o,r,i,s,l;(e=t.getBoundingClientRect(),n=e.top,a=e.left,o=e.bottom,r=e.right,i=window,s=i.innerHeight,l=i.innerWidth,n>=0&&r<=l&&o<=s&&a>=0)||(t.scrollIntoView({block:"center",behavior:"smooth"}),t.classList.add(c),setTimeout((function(){return t.classList.remove(c)}),2e3))}),150))},E=function(e){var t,n;switch(e.keyCode){case p:var a=I.indexOf(e.target)+1;n=I[a]||I[0];break;case u:var o=I.indexOf(e.target)-1;n=I[o]||I[I.length-1]}null==(t=n)||t.focus()},P=function(e,t){return t.value===e||t.values&&-1!=t.values.indexOf(e)};return a.createElement("div",{className:"tabs-container"},a.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:(0,i.Z)("tabs",{"tabs--block":n},f)},d.map((function(e){var t=e.value,n=e.label;return a.createElement("li",{role:"tab",tabIndex:b===t?0:-1,"aria-selected":b===t,className:(0,i.Z)("tabs__item",s,{"tabs__item--active":b===t}),key:t,ref:function(e){return I.push(e)},onKeyDown:E,onFocus:w,onClick:w},n)}))),t?(0,a.cloneElement)(k.filter((function(e){return P(b,e.props)}))[0],{className:l}):a.createElement("div",null,k.map((function(e,t){return(0,a.cloneElement)(e,{key:t,hidden:!P(b,e.props),className:l})}))),a.createElement("br",null))}},3851:function(e,t,n){"use strict";n.r(t),n.d(t,{frontMatter:function(){return l},contentTitle:function(){return u},metadata:function(){return p},toc:function(){return d},default:function(){return f}});var a=n(2122),o=n(9756),r=(n(7294),n(3905)),i=n(8952),s=n(9309),c=(n(4996),["components"]),l={},u="\u0423\u0442\u0438\u043b\u0438\u0442\u044b \u0434\u043b\u044f \u043f\u0430\u0442\u0447\u0435\u0439",p={unversionedId:"patching-utilities",id:"patching-utilities",isDocsHomePage:!1,title:"\u0423\u0442\u0438\u043b\u0438\u0442\u044b \u0434\u043b\u044f \u043f\u0430\u0442\u0447\u0435\u0439",description:"\u0410\u0442\u0440\u0438\u0431\u0443\u0442 RLSetup",source:"@site/i18n/ru/docusaurus-plugin-content-docs/current/patching-utilities.mdx",sourceDirName:".",slug:"/patching-utilities",permalink:"/RogueLibs/ru/docs/patching-utilities",editUrl:"https://github.com/Abbysssal/RogueLibs/edit/master/website/docs/patching-utilities.mdx",version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"\u0414\u043e\u043f\u043e\u043b\u043d\u0438\u0442\u0435\u043b\u044c\u043d\u043e",permalink:"/RogueLibs/ru/docs/extra"},next:{title:"\u0425\u0443\u043a\u0438",permalink:"/RogueLibs/ru/docs/hooks/hooks"}},d=[{value:"\u0410\u0442\u0440\u0438\u0431\u0443\u0442 <code>RLSetup</code>",id:"rlsetup",children:[]},{value:"<code>RoguePatcher</code>",id:"roguepatcher",children:[]},{value:"\u0412\u0441\u043f\u043e\u043c\u043e\u0433\u0430\u0442\u0435\u043b\u044c\u043d\u044b\u0435 \u043c\u0435\u0442\u043e\u0434\u044b \u0434\u043b\u044f \u0442\u0440\u0430\u043d\u0441\u043f\u0438\u043b\u0438\u0440\u043e\u0432\u0430\u043d\u0438\u044f",id:"transpiler-helper-methods",children:[]}],m={toc:d};function f(e){var t=e.components,n=(0,o.Z)(e,c);return(0,r.kt)("wrapper",(0,a.Z)({},m,n,{components:t,mdxType:"MDXLayout"}),(0,r.kt)("h1",{id:"\u0443\u0442\u0438\u043b\u0438\u0442\u044b-\u0434\u043b\u044f-\u043f\u0430\u0442\u0447\u0435\u0439"},"\u0423\u0442\u0438\u043b\u0438\u0442\u044b \u0434\u043b\u044f \u043f\u0430\u0442\u0447\u0435\u0439"),(0,r.kt)("h2",{id:"rlsetup"},"\u0410\u0442\u0440\u0438\u0431\u0443\u0442 ",(0,r.kt)("inlineCode",{parentName:"h2"},"RLSetup")),(0,r.kt)("p",null,"\u0422\u0430\u043a \u043a\u0430\u043a RogueLibs \u043e\u0431\u0440\u0430\u0431\u0430\u0442\u044b\u0432\u0430\u0435\u0442 \u0432\u0441\u0451 \u043a\u0430\u0441\u0442\u043e\u043c\u043d\u043e\u0435 \u043a\u0430\u043a \u043a\u043b\u0430\u0441\u0441\u044b, \u0432\u044b \u043c\u043e\u0436\u0435\u0442\u0435 \u0437\u0430\u0431\u044b\u0442\u044c \u0438\u043d\u0438\u0446\u0438\u0430\u043b\u0438\u0437\u0438\u0440\u043e\u0432\u0430\u0442\u044c \u043d\u043e\u0432\u044b\u0439 \u043a\u043b\u0430\u0441\u0441 \u0432 ",(0,r.kt)("inlineCode",{parentName:"p"},"Awake")," \u0432\u0430\u0448\u0435\u0433\u043e \u043f\u043b\u0430\u0433\u0438\u043d\u0430. \u0418\u043c\u0435\u043d\u043d\u043e \u043f\u043e\u044d\u0442\u043e\u043c\u0443 \u0442\u0443\u0442 \u0435\u0441\u0442\u044c \u0430\u0442\u0440\u0438\u0431\u0443\u0442 ",(0,r.kt)("inlineCode",{parentName:"p"},"RLSetup"),". \u0412\u044b \u043c\u043e\u0436\u0435\u0442\u0435 \u0434\u043e\u0431\u0430\u0432\u0438\u0442\u044c \u0435\u0433\u043e \u043a \u0441\u0442\u0430\u0442\u0438\u0447\u0435\u0441\u043a\u043e\u043c\u0443 \u043c\u0435\u0442\u043e\u0434\u0443 \u0438 \u0438\u043d\u0438\u0446\u0438\u0430\u043b\u0438\u0437\u0438\u0440\u043e\u0432\u0430\u0442\u044c \u0432\u0430\u0448 \u043a\u0430\u0441\u0442\u043e\u043c\u043d\u044b\u0439 \u043a\u043b\u0430\u0441\u0441 \u0442\u0430\u043c."),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyCustomItem.cs"',title:'"MyCustomItem.cs"'},'public class MyCustomItem : CustomItem\n{\n    // highlight-start\n    [RLSetup]\n    public static void Setup()\n    // highlight-end\n    {\n        RogueLibs.CreateCustomItem<MyCustomItem>()\n            .WithName(new CustomNameInfo("Name"))\n            .WithDescription(new CustomNameInfo("Description"))\n            .WithSprite(Properties.Resources.Sprite)\n            .WithUnlock(new ItemUnlock());\n        \n        RogueLibs.CreateCustomName("SomeName", "Dialogue", new CustomNameInfo("Text"));\n    }\n}\n')),(0,r.kt)("p",null,"\u0412\u0430\u043c \u043f\u0440\u043e\u0441\u0442\u043e \u043d\u0430\u0434\u043e \u0431\u0443\u0434\u0435\u0442 \u0432\u044b\u0437\u0432\u0430\u0442\u044c \u0441\u043b\u0435\u0434\u0443\u044e\u0449\u0438\u0439 \u043c\u0435\u0442\u043e\u0434 \u0432 ",(0,r.kt)("inlineCode",{parentName:"p"},"Awake")," \u0432\u0430\u0448\u0435\u0433\u043e \u043f\u043b\u0430\u0433\u0438\u043d\u0430:"),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyCoolPlugin.cs"',title:'"MyCoolPlugin.cs"'},"    public void Awake()\n    {\n        // highlight-next-line\n        RogueLibs.LoadFromAssembly();\n        /* ... */\n    }\n")),(0,r.kt)("div",{className:"admonition admonition-tip alert alert--success"},(0,r.kt)("div",{parentName:"div",className:"admonition-heading"},(0,r.kt)("h5",{parentName:"div"},(0,r.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,r.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"12",height:"16",viewBox:"0 0 12 16"},(0,r.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.5 0C3.48 0 1 2.19 1 5c0 .92.55 2.25 1 3 1.34 2.25 1.78 2.78 2 4v1h5v-1c.22-1.22.66-1.75 2-4 .45-.75 1-2.08 1-3 0-2.81-2.48-5-5.5-5zm3.64 7.48c-.25.44-.47.8-.67 1.11-.86 1.41-1.25 2.06-1.45 3.23-.02.05-.02.11-.02.17H5c0-.06 0-.13-.02-.17-.2-1.17-.59-1.83-1.45-3.23-.2-.31-.42-.67-.67-1.11C2.44 6.78 2 5.65 2 5c0-2.2 2.02-4 4.5-4 1.22 0 2.36.42 3.22 1.19C10.55 2.94 11 3.94 11 5c0 .66-.44 1.78-.86 2.48zM4 14h5c-.23 1.14-1.3 2-2.5 2s-2.27-.86-2.5-2z"}))),"\u0421\u043e\u0432\u0435\u0442 \u043e\u0442 \u043f\u0440\u043e\u0444\u0438")),(0,r.kt)("div",{parentName:"div",className:"admonition-content"},(0,r.kt)("p",{parentName:"div"},"\u0421\u0435\u0440\u044c\u0451\u0437\u043d\u043e, \u0438\u0441\u043f\u043e\u043b\u044c\u0437\u0443\u0439\u0442\u0435 \u0435\u0433\u043e. \u042d\u0442\u043e \u0442\u0430\u043a\u0436\u0435 \u043f\u043e\u043c\u043e\u0433\u0430\u0435\u0442 \u0441 \u0432\u0435\u0440\u0441\u0438\u043e\u043d\u0438\u043d\u0433\u043e\u043c. \u0412\u0441\u0451 \u0432 \u043e\u0434\u043d\u043e\u043c \u043c\u0435\u0441\u0442\u0435."))),(0,r.kt)("h2",{id:"roguepatcher"},(0,r.kt)("inlineCode",{parentName:"h2"},"RoguePatcher")),(0,r.kt)("p",null,(0,r.kt)("inlineCode",{parentName:"p"},"RoguePatcher")," - \u043c\u0430\u043b\u0435\u043d\u044c\u043a\u0438\u0439 \u0432\u0441\u043f\u043e\u043c\u043e\u0433\u0430\u0442\u0435\u043b\u044c\u043d\u044b\u0439 \u043a\u043b\u0430\u0441\u0441, \u0434\u0435\u043b\u0430\u044e\u0449\u0438\u0439 \u043d\u0430\u043f\u0438\u0441\u0430\u043d\u0438\u0435 \u043f\u0430\u0442\u0447\u0435\u0439 \u043d\u0435\u043c\u043d\u043e\u0433\u043e \u0431\u044b\u0441\u0442\u0440\u0435\u0435 \u0438 \u043f\u0440\u043e\u0449\u0435. \u0415\u0441\u043b\u0438 \u0432\u0430\u043c \u043d\u0430\u0434\u043e \u0431\u043e\u043b\u044c\u0448\u0435 \u043a\u043e\u043d\u0442\u0440\u043e\u043b\u044f (\u043f\u043e\u0440\u044f\u0434\u043e\u043a \u043f\u0430\u0442\u0447\u0435\u0439, \u043f\u0440\u0438\u043e\u0440\u0438\u0442\u0435\u0442 \u0438 \u0442.\u043f.), \u0442\u043e\u0433\u0434\u0430 \u0438\u0441\u043f\u043e\u043b\u044c\u0437\u0443\u0439\u0442\u0435 \u043e\u0440\u0438\u0433\u0438\u043d\u0430\u043b\u044c\u043d\u044b\u0435 \u043c\u0435\u0442\u043e\u0434\u044b Harmony."),(0,r.kt)(i.Z,{defaultValue:"roguepatcher",values:[{label:"RoguePatcher",value:"roguepatcher"},{label:"Harmony",value:"harmony"}],mdxType:"Tabs"},(0,r.kt)(s.Z,{value:"roguepatcher",mdxType:"TabItem"},(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},"RoguePatcher patcher = new RoguePatcher(this);\n\npatcher.Postfix(typeof(StatusEffects), nameof(StatusEffects.hasStatusEffect));\n\npatcher.Postfix(typeof(InvDatabase), nameof(InvDatabase.ChooseArmor), new Type[1] { typeof(string) });\n"))),(0,r.kt)(s.Z,{value:"harmony",mdxType:"TabItem"},(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},"Harmony harmony = new Harmony(pluginGUID);\n\nMethodInfo original = AccessTools.Method(typeof(StatusEffects), nameof(StatusEffects.hasStatusEffect));\nMethodInfo patch = AccessTools.Method(GetType(), nameof(MyPatchMethod));\nharmony.Patch(original, new HarmonyMethod(patch));\n\noriginal = AccessTools.Method(typeof(InvDatabase), nameof(InvDatabase.ChooseArmor), new Type[1] { typeof(string) });\npatch = AccessTools.Method(GetType(), nameof(MyPatchMethod2));\nharmony.Patch(original, new HarmonyMethod(patch));\n")))),(0,r.kt)("div",{className:"admonition admonition-tip alert alert--success"},(0,r.kt)("div",{parentName:"div",className:"admonition-heading"},(0,r.kt)("h5",{parentName:"div"},(0,r.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,r.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"12",height:"16",viewBox:"0 0 12 16"},(0,r.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.5 0C3.48 0 1 2.19 1 5c0 .92.55 2.25 1 3 1.34 2.25 1.78 2.78 2 4v1h5v-1c.22-1.22.66-1.75 2-4 .45-.75 1-2.08 1-3 0-2.81-2.48-5-5.5-5zm3.64 7.48c-.25.44-.47.8-.67 1.11-.86 1.41-1.25 2.06-1.45 3.23-.02.05-.02.11-.02.17H5c0-.06 0-.13-.02-.17-.2-1.17-.59-1.83-1.45-3.23-.2-.31-.42-.67-.67-1.11C2.44 6.78 2 5.65 2 5c0-2.2 2.02-4 4.5-4 1.22 0 2.36.42 3.22 1.19C10.55 2.94 11 3.94 11 5c0 .66-.44 1.78-.86 2.48zM4 14h5c-.23 1.14-1.3 2-2.5 2s-2.27-.86-2.5-2z"}))),"\u0421\u043e\u0432\u0435\u0442 \u043e\u0442 \u043f\u0440\u043e\u0444\u0438")),(0,r.kt)("div",{parentName:"div",className:"admonition-content"},(0,r.kt)("p",{parentName:"div"},"\u0412\u043c\u0435\u0441\u0442\u043e \u0443\u043a\u0430\u0437\u044b\u0432\u0430\u043d\u0438\u044f \u043d\u0430\u0437\u0432\u0430\u043d\u0438\u0439 \u043c\u0435\u0442\u043e\u0434\u043e\u0432 \u0441 \u043f\u043e\u043c\u043e\u0449\u044c\u044e \u0441\u0442\u0440\u043e\u043a, \u0443\u043a\u0430\u0437\u044b\u0432\u0430\u0439\u0442\u0435 \u0438\u0445 \u0441 \u043f\u043e\u043c\u043e\u0449\u044c\u044e \u043a\u043b\u044e\u0447\u0435\u0432\u043e\u0433\u043e \u0441\u043b\u043e\u0432\u0430 ",(0,r.kt)("inlineCode",{parentName:"p"},"nameof"),". \u0418\u0441\u043f\u043e\u043b\u044c\u0437\u0443\u0439\u0442\u0435 \u0441\u0442\u0440\u043e\u043a\u043e\u0432\u044b\u0435 \u043d\u0430\u0437\u0432\u0430\u043d\u0438\u044f \u0442\u043e\u043b\u044c\u043a\u043e \u0435\u0441\u043b\u0438 \u043c\u0435\u0442\u043e\u0434, \u043a\u043e\u0442\u043e\u0440\u044b\u0439 \u0432\u044b \u0445\u043e\u0442\u0438\u0442\u0435 \u043f\u0440\u043e\u043f\u0430\u0442\u0447\u0438\u0442\u044c, \u043d\u0435 \u043f\u0443\u0431\u043b\u0438\u0447\u043d\u044b\u0439."))),(0,r.kt)("p",null,"\u041c\u0435\u0442\u043e\u0434\u044b-\u043f\u0430\u0442\u0447\u0438 \u0434\u043e\u043b\u0436\u043d\u044b \u0438\u043c\u0435\u0442\u044c \u0441\u043b\u0435\u0434\u0443\u044e\u0449\u0435\u0435 \u0438\u043c\u044f: ",(0,r.kt)("inlineCode",{parentName:"p"},"<\u0426\u0435\u043b\u0435\u0432\u043e\u0439\u0422\u0438\u043f>_<\u0426\u0435\u043b\u0435\u0432\u043e\u0439\u041c\u0435\u0442\u043e\u0434>"),". \u0412 \u043f\u0440\u0438\u043c\u0435\u0440\u0435 \u0432\u044b\u0448\u0435, ",(0,r.kt)("inlineCode",{parentName:"p"},"RoguePatcher")," \u0431\u0443\u0434\u0435\u0442 \u0438\u0441\u043a\u0430\u0442\u044c \u043c\u0435\u0442\u043e\u0434\u044b-\u043f\u0430\u0442\u0447\u0438 \u0441 \u043d\u0430\u0437\u0432\u0430\u043d\u0438\u044f\u043c\u0438 ",(0,r.kt)("inlineCode",{parentName:"p"},"StatusEffects_hasStatusEffect")," \u0438 ",(0,r.kt)("inlineCode",{parentName:"p"},"InvDatabase_ChooseArmor")," \u0432 \u043a\u043b\u0430\u0441\u0441\u0435 \u0432\u0430\u0448\u0435\u0433\u043e \u043f\u043b\u0430\u0433\u0438\u043d\u0430."),(0,r.kt)("p",null,"\u0412\u044b \u043c\u043e\u0436\u0435\u0442\u0435 \u0438\u0437\u043c\u0435\u043d\u0438\u0442\u044c \u0442\u0438\u043f, \u0432 \u043a\u043e\u0442\u043e\u0440\u043e\u043c \u0431\u0443\u0434\u0443\u0442 \u0438\u0441\u043a\u0430\u0442\u044c\u0441\u044f \u043c\u0435\u0442\u043e\u0434\u044b-\u043f\u0430\u0442\u0447\u0438. \u0423\u043a\u0430\u0436\u0438\u0442\u0435 \u0435\u0433\u043e \u0432 \u043a\u043e\u043d\u0441\u0442\u0440\u0443\u043a\u0442\u043e\u0440\u0435 \u0438\u043b\u0438 \u0432\u044b\u0441\u0442\u0430\u0432\u044c\u0442\u0435 \u0441\u0432\u043e\u0439\u0441\u0442\u0432\u043e \u043c\u0435\u0436\u0434\u0443 \u043f\u0430\u0442\u0447\u0430\u043c\u0438:"),(0,r.kt)(i.Z,{defaultValue:"roguepatcher",values:[{label:"RoguePatcher",value:"roguepatcher"},{label:"Harmony",value:"harmony"}],mdxType:"Tabs"},(0,r.kt)(s.Z,{value:"roguepatcher",mdxType:"TabItem"},(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},"public class MyCoolPlugin : BaseUnityPlugin\n{\n    public void Awake()\n    {\n        // highlight-next-line\n        RoguePatcher patcher = new RoguePatcher(this, typeof(MyCoolPatches));\n\n        patcher.Postfix(typeof(StatusEffects), nameof(StatusEffects.hasStatusEffect));\n\n        // highlight-next-line\n        patcher.TypeWithPatches = typeof(MyEvenCoolerPatches);\n\n        patcher.Postfix(typeof(InvDatabase), nameof(InvDatabase.ChooseArmor), new Type[1] { typeof(string) });\n    }\n}\npublic class MyCoolPatches\n{\n    public static void StatusEffects_hasStatusEffect(StatusEffects __instance)\n    {\n        /* ... */\n    }\n}\npublic class MyEvenCoolerPatches\n{\n    public static void InvDatabase_ChooseArmor(InvDatabase __instance, string previousArmorName)\n    {\n        /* ... */\n    }\n}\n"))),(0,r.kt)(s.Z,{value:"harmony",mdxType:"TabItem"},(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},"public class MyCoolPlugin : BaseUnityPlugin\n{\n    public void Awake()\n    {\n        Harmony harmony = new Harmony(pluginGUID);\n\n        MethodInfo original = AccessTools.Method(typeof(StatusEffects), nameof(StatusEffects.hasStatusEffect));\n        MethodInfo patch = AccessTools.Method(typeof(MyCoolPatches), nameof(MyPatchMethod));\n        harmony.Patch(original, new HarmonyMethod(patch));\n\n        original = AccessTools.Method(typeof(InvDatabase), nameof(InvDatabase.ChooseArmor), new Type[1] { typeof(string) });\n        patch = AccessTools.Method(typeof(MyEvenCoolerPatches), nameof(MyPatchMethod2));\n        harmony.Patch(original, new HarmonyMethod(patch));\n    }\n}\npublic class MyCoolPatches\n{\n    public static void MyPatchMethod(StatusEffects __instance)\n    {\n        /* ... */\n    }\n}\npublic class MyEvenCoolerPatches\n{\n    public static void MyPatchMethod2(InvDatabase __instance, string previousArmorName)\n    {\n        /* ... */\n    }\n}\n")))),(0,r.kt)("h2",{id:"transpiler-helper-methods"},"\u0412\u0441\u043f\u043e\u043c\u043e\u0433\u0430\u0442\u0435\u043b\u044c\u043d\u044b\u0435 \u043c\u0435\u0442\u043e\u0434\u044b \u0434\u043b\u044f \u0442\u0440\u0430\u043d\u0441\u043f\u0438\u043b\u0438\u0440\u043e\u0432\u0430\u043d\u0438\u044f"),(0,r.kt)("p",null,"\u0422\u0440\u0430\u043d\u0441\u043f\u0438\u043b\u044f\u0442\u043e\u0440\u044b \u0434\u043e\u0432\u043e\u043b\u044c\u043d\u043e \u0441\u043b\u043e\u0436\u043d\u044b\u0435."),(0,r.kt)("p",null,"\u0412\u043e\u0442 \u043f\u0440\u0438\u043c\u0435\u0440 \u0438\u0437 RogueLibs:"),(0,r.kt)(i.Z,{defaultValue:"helper",values:[{label:"\u0412\u0441\u043f\u043e\u043c\u043e\u0433\u0430\u0442\u0435\u043b\u044c\u043d\u044b\u0435 \u043c\u0435\u0442\u043e\u0434\u044b",value:"helper"},{label:"Harmony",value:"harmony"}],mdxType:"Tabs"},(0,r.kt)(s.Z,{value:"helper",mdxType:"TabItem"},(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},"public static IEnumerable<CodeInstruction> StatusEffects_AddStatusEffect(IEnumerable<CodeInstruction> codeEnumerable)\n    => codeEnumerable.AddRegionAfter(\n        new Func<CodeInstruction, bool>[]\n        {\n            i => i.IsLdloc(),\n            i => i.opcode == OpCodes.Ldarg_3,\n            i => i.opcode == OpCodes.Stfld && i.StoresField(causingAgentField),\n        },\n        new Func<CodeInstruction[], CodeInstruction>[]\n        {\n            a => a[0],\n            _ => new CodeInstruction(OpCodes.Ldarg_0),\n            _ => new CodeInstruction(OpCodes.Call, typeof(RogueLibsPlugin).GetMethod(nameof(SetupEffectHook))),\n        });\n\nprivate static readonly FieldInfo causingAgentField = typeof(StatusEffect).GetField(nameof(StatusEffect.causingAgent));\n"))),(0,r.kt)(s.Z,{value:"harmony",mdxType:"TabItem"},(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},"public static IEnumerable<CodeInstruction> StatusEffects_AddStatusEffect(IEnumerable<CodeInstruction> code)\n{\n    bool searching = true;\n    int current = 0;\n    CodeInstruction[] matches = new CodeInstruction[after.Length];\n    foreach (CodeInstruction instr in code)\n    {\n        yield return instr;\n        if (searching)\n        {\n            if (current is 0 ? instr.IsLdloc()\n                : current is 1 ? instr.opcode == OpCodes.Ldarg_3\n                : instr.opcode == OpCodes.Stfld && instr.StoresField(causingAgentField))\n            {\n                matches[current] = instr;\n                if (++current is 3)\n                {\n                    searching = false;\n                    yield return matches[0];\n                    yield return new CodeInstruction(OpCodes.Ldarg_0);\n                    yield return new CodeInstruction(OpCodes.Call, typeof(RogueLibsPlugin).GetMethod(nameof(SetupEffectHook)));\n                }\n            }\n            else current = 0;\n        }\n    }\n}\n\nprivate static readonly FieldInfo causingAgentField = typeof(StatusEffect).GetField(nameof(StatusEffect.causingAgent));\n")),(0,r.kt)("p",null,"\u0414\u0430, \u0432\u044b\u0433\u043b\u044f\u0434\u0438\u0442 \u043f\u0440\u043e\u0441\u0442\u043e. \u041d\u043e \u044d\u0442\u043e \u0442\u043e\u043b\u044c\u043a\u043e \u043f\u043e\u0442\u043e\u043c\u0443 \u0447\u0442\u043e \u044d\u0442\u043e \u043e\u0447\u0435\u043d\u044c \u043f\u0440\u043e\u0441\u0442\u043e\u0439 \u043f\u0440\u0438\u043c\u0435\u0440."))),(0,r.kt)("div",{className:"admonition admonition-tip alert alert--success"},(0,r.kt)("div",{parentName:"div",className:"admonition-heading"},(0,r.kt)("h5",{parentName:"div"},(0,r.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,r.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"12",height:"16",viewBox:"0 0 12 16"},(0,r.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.5 0C3.48 0 1 2.19 1 5c0 .92.55 2.25 1 3 1.34 2.25 1.78 2.78 2 4v1h5v-1c.22-1.22.66-1.75 2-4 .45-.75 1-2.08 1-3 0-2.81-2.48-5-5.5-5zm3.64 7.48c-.25.44-.47.8-.67 1.11-.86 1.41-1.25 2.06-1.45 3.23-.02.05-.02.11-.02.17H5c0-.06 0-.13-.02-.17-.2-1.17-.59-1.83-1.45-3.23-.2-.31-.42-.67-.67-1.11C2.44 6.78 2 5.65 2 5c0-2.2 2.02-4 4.5-4 1.22 0 2.36.42 3.22 1.19C10.55 2.94 11 3.94 11 5c0 .66-.44 1.78-.86 2.48zM4 14h5c-.23 1.14-1.3 2-2.5 2s-2.27-.86-2.5-2z"}))),"\u0418\u0437\u0431\u0435\u0433\u0430\u0439\u0442\u0435 \u0442\u044f\u0436\u0451\u043b\u044b\u0445 \u0432\u044b\u0447\u0438\u0441\u043b\u0435\u043d\u0438\u0439")),(0,r.kt)("div",{parentName:"div",className:"admonition-content"},(0,r.kt)("p",{parentName:"div"},"\u041f\u0440\u0438 \u043d\u0430\u043f\u0438\u0441\u0430\u043d\u0438\u0438 \u043f\u0440\u0435\u0434\u0438\u043a\u0430\u0442\u043e\u0432, \u043f\u043e\u043c\u043d\u0438\u0442\u0435, \u0447\u0442\u043e \u043e\u043d\u0438 \u043c\u043e\u0433\u0443\u0442 \u0431\u044b\u0442\u044c \u0432\u044b\u0437\u0432\u0430\u043d\u044b \u0441\u043e\u0442\u043d\u0438 \u0438\u043b\u0438 \u0442\u044b\u0441\u044f\u0447\u0438 \u0440\u0430\u0437. \u041d\u0430\u043f\u0440\u0438\u043c\u0435\u0440, \u0432\u044b \u043c\u043e\u0436\u0435\u0442\u0435 \u0437\u0430\u0440\u0430\u043d\u0435\u0435 \u0432\u044b\u0447\u0438\u0441\u043b\u0438\u0442\u044c \u0437\u043d\u0430\u0447\u0435\u043d\u0438\u0435 ",(0,r.kt)("inlineCode",{parentName:"p"},"FieldInfo"),", \u0438\u0441\u043f\u043e\u043b\u044c\u0437\u0443\u0435\u043c\u043e\u0435 \u0432\u0430\u0448\u0438\u043c \u043f\u0440\u0435\u0434\u0438\u043a\u0430\u0442\u043e\u043c, \u043f\u0440\u043e\u0441\u0442\u043e \u043f\u043e\u043b\u043e\u0436\u0438\u0442\u0435 \u0435\u0433\u043e \u0432 \u0441\u0442\u0430\u0442\u0438\u0447\u0435\u0441\u043a\u043e\u0435 \u043f\u043e\u043b\u0435, \u043a\u0430\u043a \u0432 \u043f\u0440\u0438\u043c\u0435\u0440\u0435 \u0432\u044b\u0448\u0435."),(0,r.kt)("p",{parentName:"div"},"\u0422\u0430\u043a\u0438\u0435 \u0442\u044f\u0436\u0451\u043b\u044b\u0435 \u0432\u044b\u0447\u0438\u0441\u043b\u0435\u043d\u0438\u044f \u043c\u043e\u0433\u0443\u0442 \u0441\u0442\u043e\u0438\u0442\u044c \u0432\u0430\u043c ",(0,r.kt)("strong",{parentName:"p"},"\u0441\u043e\u0442\u0435\u043d \u043c\u0438\u043b\u043b\u0438\u0441\u0435\u043a\u0443\u043d\u0434")," \u0432\u0440\u0435\u043c\u0435\u043d\u0438 \u0437\u0430\u043f\u0443\u0441\u043a\u0430 (\u0438\u043b\u0438 \u0434\u0430\u0436\u0435 \u0446\u0435\u043b\u044b\u0435 \u0441\u0435\u043a\u0443\u043d\u0434\u044b, \u0435\u0441\u043b\u0438 \u0432\u044b \u0440\u0430\u0431\u043e\u0442\u0430\u0435\u0442\u0435 \u043d\u0430\u0434 \u043a\u0440\u0443\u043f\u043d\u044b\u043c \u043f\u0440\u043e\u0435\u043a\u0442\u043e\u043c)."))),(0,r.kt)("p",null,"\u0412\u043e\u0442 \u0435\u0449\u0451 \u043e\u0434\u0438\u043d \u043f\u0440\u0438\u043c\u0435\u0440 \u0438\u0437 RogueLibs:"),(0,r.kt)(i.Z,{defaultValue:"helper",values:[{label:"\u0412\u0441\u043f\u043e\u043c\u043e\u0433\u0430\u0442\u0435\u043b\u044c\u043d\u044b\u0435 \u043c\u0435\u0442\u043e\u0434\u044b",value:"helper"},{label:"Harmony",value:"harmony"}],mdxType:"Tabs"},(0,r.kt)(s.Z,{value:"helper",mdxType:"TabItem"},(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},'public static IEnumerable<CodeInstruction> Unlocks_LoadInitialUnlocks(IEnumerable<CodeInstruction> codeEnumerable)\n    => codeEnumerable.ReplaceRegion(\n        new Func<CodeInstruction, bool>[]\n        {\n            i => i.opcode == OpCodes.Callvirt && i.Calls(List_Unlock_GetEnumerator),\n            i => i.IsStloc(),\n        },\n        new Func<CodeInstruction, bool>[]\n        {\n            i => i.opcode == OpCodes.Callvirt,\n            i => i.opcode == OpCodes.Endfinally,\n            i => i.opcode == OpCodes.Ldarg_0,\n        },\n        new CodeInstruction[]\n        {\n            new CodeInstruction(OpCodes.Pop),\n            new CodeInstruction(OpCodes.Pop),\n            new CodeInstruction(OpCodes.Call, typeof(RogueLibsPlugin).GetMethod(nameof(LoadUnlockWrappersAndCategorize)))\n        });\n\nprivate static readonly MethodInfo List_Unlock_GetEnumerator = typeof(List<Unlock>).GetMethod("GetEnumerator");\n'))),(0,r.kt)(s.Z,{value:"harmony",mdxType:"TabItem"},(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},'public static IEnumerable<CodeInstruction> Unlocks_LoadInitialUnlocks(IEnumerable<CodeInstruction> code)\n{\n    int state = 0;\n    int current = 0;\n    CodeInstruction[] beginCache = new CodeInstruction[2];\n    foreach (CodeInstruction instr in code)\n    {\n        if (state is 2)\n            yield return instr;\n        else if (state is 0)\n        {\n            if (current is 0 ? instr.opcode == OpCodes.Callvirt && instr.Calls(List_Unlock_GetEnumerator)\n                : instr.IsStloc())\n            {\n                beginCache[current] = instr;\n                if (++current == 2)\n                {\n                    state = 1;\n                    current = 0;\n                }\n            }\n            else\n            {\n                if (current > 0)\n                {\n                    for (int i = 0; i < current; i++)\n                        yield return beginCache[i];\n                    current = 0;\n                }\n                yield return instr;\n            }\n        }\n        else\n        {\n            if (current is 0 ? instr.opcode == OpCodes.Callvirt\n                : current is 1 ? instr.opcode == OpCodes.Endfinally\n                : instr.opcode == OpCodes.Ldarg_0)\n            {\n                if (++current == 3)\n                {\n                    yield return new CodeInstruction(OpCodes.Pop);\n                    yield return new CodeInstruction(OpCodes.Pop);\n                    yield return new CodeInstruction(OpCodes.Call, typeof(RogueLibsPlugin).GetMethod(nameof(LoadUnlockWrappersAndCategorize)));\n                }\n            }\n            else current = 0;\n        }\n    }\n}\n\nprivate static readonly MethodInfo List_Unlock_GetEnumerator = typeof(List<Unlock>).GetMethod("GetEnumerator");\n')),(0,r.kt)("p",null,"\u0412\u0441\u0451 \u0435\u0449\u0451 \u043e\u0442\u043d\u043e\u0441\u0438\u0442\u0435\u043b\u044c\u043d\u043e \u043f\u0440\u043e\u0441\u0442\u043e. \u042f \u043f\u0440\u043e\u0441\u0442\u043e \u043d\u0435 \u0445\u043e\u0447\u0443 \u0442\u0440\u0430\u0442\u0438\u0442\u044c \u0441\u0432\u043e\u0451 \u0432\u0440\u0435\u043c\u044f \u043d\u0430 \u043d\u0430\u043f\u0438\u0441\u0430\u043d\u0438\u0435 \u0434\u0435\u0439\u0441\u0442\u0432\u0438\u0442\u0435\u043b\u044c\u043d\u043e \u0441\u043b\u043e\u0436\u043d\u043e\u0433\u043e \u043f\u0440\u0438\u043c\u0435\u0440\u0430."))))}f.isMDXComponent=!0},6010:function(e,t,n){"use strict";function a(e){var t,n,o="";if("string"==typeof e||"number"==typeof e)o+=e;else if("object"==typeof e)if(Array.isArray(e))for(t=0;t<e.length;t++)e[t]&&(n=a(e[t]))&&(o&&(o+=" "),o+=n);else for(t in e)e[t]&&(o&&(o+=" "),o+=t);return o}function o(){for(var e,t,n=0,o="";n<arguments.length;)(e=arguments[n++])&&(t=a(e))&&(o&&(o+=" "),o+=t);return o}n.d(t,{Z:function(){return o}})}}]);