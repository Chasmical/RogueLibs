(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[553],{3905:function(e,t,n){"use strict";n.d(t,{Zo:function(){return l},kt:function(){return p}});var r=n(7294);function o(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function a(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(e);t&&(r=r.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,r)}return n}function i(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?a(Object(n),!0).forEach((function(t){o(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):a(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function c(e,t){if(null==e)return{};var n,r,o=function(e,t){if(null==e)return{};var n,r,o={},a=Object.keys(e);for(r=0;r<a.length;r++)n=a[r],t.indexOf(n)>=0||(o[n]=e[n]);return o}(e,t);if(Object.getOwnPropertySymbols){var a=Object.getOwnPropertySymbols(e);for(r=0;r<a.length;r++)n=a[r],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(o[n]=e[n])}return o}var u=r.createContext({}),s=function(e){var t=r.useContext(u),n=t;return e&&(n="function"==typeof e?e(t):i(i({},t),e)),n},l=function(e){var t=s(e.components);return r.createElement(u.Provider,{value:t},e.children)},m={inlineCode:"code",wrapper:function(e){var t=e.children;return r.createElement(r.Fragment,{},t)}},f=r.forwardRef((function(e,t){var n=e.components,o=e.mdxType,a=e.originalType,u=e.parentName,l=c(e,["components","mdxType","originalType","parentName"]),f=s(n),p=o,d=f["".concat(u,".").concat(p)]||f[p]||m[p]||a;return n?r.createElement(d,i(i({ref:t},l),{},{components:n})):r.createElement(d,i({ref:t},l))}));function p(e,t){var n=arguments,o=t&&t.mdxType;if("string"==typeof e||o){var a=n.length,i=new Array(a);i[0]=f;var c={};for(var u in t)hasOwnProperty.call(t,u)&&(c[u]=t[u]);c.originalType=e,c.mdxType="string"==typeof e?e:o,i[1]=c;for(var s=2;s<a;s++)i[s]=n[s];return r.createElement.apply(null,i)}return r.createElement.apply(null,n)}f.displayName="MDXCreateElement"},3919:function(e,t,n){"use strict";function r(e){return!0===/^(\w*:|\/\/)/.test(e)}function o(e){return void 0!==e&&!r(e)}n.d(t,{b:function(){return r},Z:function(){return o}})},4996:function(e,t,n){"use strict";n.d(t,{C:function(){return a},Z:function(){return i}});var r=n(2263),o=n(3919);function a(){var e=(0,r.Z)().siteConfig,t=(e=void 0===e?{}:e).baseUrl,n=void 0===t?"/":t,a=e.url;return{withBaseUrl:function(e,t){return function(e,t,n,r){var a=void 0===r?{}:r,i=a.forcePrependBaseUrl,c=void 0!==i&&i,u=a.absolute,s=void 0!==u&&u;if(!n)return n;if(n.startsWith("#"))return n;if((0,o.b)(n))return n;if(c)return t+n;var l=n.startsWith(t)?n:t+n.replace(/^\//,"");return s?e+l:l}(a,n,e,t)}}}function i(e,t){return void 0===t&&(t={}),(0,a().withBaseUrl)(e,t)}},9443:function(e,t,n){"use strict";var r=(0,n(7294).createContext)(void 0);t.Z=r},9309:function(e,t,n){"use strict";n.d(t,{Z:function(){return c}});var r=n(2122),o=n(9756),a=n(7294),i=["children"];function c(e){var t=e.children,n=(0,o.Z)(e,i);return a.createElement("div",(0,r.Z)({role:"tabpanel"},n),t)}},8952:function(e,t,n){"use strict";n.d(t,{Z:function(){return f}});var r=n(7294),o=n(9443);var a=function(){var e=(0,r.useContext)(o.Z);if(null==e)throw new Error('"useUserPreferencesContext" is used outside of "Layout" component.');return e},i=n(6010),c="tabItem_2O3c",u="tabItemActive_Fpbe",s="tab_1pgU";var l=37,m=39;var f=function(e){var t=e.lazy,n=e.block,o=e.defaultValue,f=e.values,p=e.groupId,d=e.className,v=a(),k=v.tabGroupChoices,h=v.setTabGroupChoices,y=(0,r.useState)(o),b=y[0],I=y[1],g=r.Children.toArray(e.children),w=[];if(null!=p){var C=k[p];null!=C&&C!==b&&f.some((function(e){return e.value===C}))&&I(C)}var N=function(e){var t=e.currentTarget,n=w.indexOf(t),r=f[n].value;I(r),null!=p&&(h(p,r),setTimeout((function(){var e,n,r,o,a,i,c,s;(e=t.getBoundingClientRect(),n=e.top,r=e.left,o=e.bottom,a=e.right,i=window,c=i.innerHeight,s=i.innerWidth,n>=0&&a<=s&&o<=c&&r>=0)||(t.scrollIntoView({block:"center",behavior:"smooth"}),t.classList.add(u),setTimeout((function(){return t.classList.remove(u)}),2e3))}),150))},O=function(e){var t,n;switch(e.keyCode){case m:var r=w.indexOf(e.target)+1;n=w[r]||w[0];break;case l:var o=w.indexOf(e.target)-1;n=w[o]||w[w.length-1]}null==(t=n)||t.focus()},x=function(e,t){return t.value===e||t.values&&-1!=t.values.indexOf(e)};return r.createElement("div",{className:"tabs-container"},r.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:(0,i.Z)("tabs",{"tabs--block":n},d)},f.map((function(e){var t=e.value,n=e.label;return r.createElement("li",{role:"tab",tabIndex:b===t?0:-1,"aria-selected":b===t,className:(0,i.Z)("tabs__item",c,{"tabs__item--active":b===t}),key:t,ref:function(e){return w.push(e)},onKeyDown:O,onFocus:N,onClick:N},n)}))),t?(0,r.cloneElement)(g.filter((function(e){return x(b,e.props)}))[0],{className:s}):r.createElement("div",null,g.map((function(e,t){return(0,r.cloneElement)(e,{key:t,hidden:!x(b,e.props),className:s})}))),r.createElement("br",null))}},9800:function(e,t,n){"use strict";n.r(t),n.d(t,{frontMatter:function(){return c},contentTitle:function(){return u},metadata:function(){return s},toc:function(){return l},default:function(){return f}});var r=n(2122),o=n(9756),a=(n(7294),n(3905)),i=(n(8952),n(9309),n(4996),["components"]),c={},u="\u0424\u0430\u0431\u0440\u0438\u043a\u0438 \u0445\u0443\u043a\u043e\u0432",s={unversionedId:"dev/hooks/hook-factories",id:"dev/hooks/hook-factories",isDocsHomePage:!1,title:"\u0424\u0430\u0431\u0440\u0438\u043a\u0438 \u0445\u0443\u043a\u043e\u0432",description:"\u0418\u043d\u0442\u0435\u0440\u0444\u0435\u0439\u0441 IHookFactory",source:"@site/i18n/ru/docusaurus-plugin-content-docs/current/dev/hooks/hook-factories.mdx",sourceDirName:"dev/hooks",slug:"/dev/hooks/hook-factories",permalink:"/RogueLibs/ru/docs/dev/hooks/hook-factories",editUrl:"https://github.com/Abbysssal/RogueLibs/edit/master/website/docs/dev/hooks/hook-factories.mdx",version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"\u0425\u0443\u043a\u0438",permalink:"/RogueLibs/ru/docs/dev/hooks/hooks"},next:{title:"Components Index",permalink:"/RogueLibs/ru/docs/components/index"}},l=[{value:"\u0418\u043d\u0442\u0435\u0440\u0444\u0435\u0439\u0441 <code>IHookFactory</code>",id:"ihookfactory",children:[]},{value:"\u0418\u043d\u0438\u0446\u0438\u0430\u043b\u0438\u0437\u0430\u0446\u0438\u044f",id:"initialization",children:[]},{value:"\u041f\u0440\u0438\u043c\u0435\u0440\u044b",id:"examples",children:[]}],m={toc:l};function f(e){var t=e.components,n=(0,o.Z)(e,i);return(0,a.kt)("wrapper",(0,r.Z)({},m,n,{components:t,mdxType:"MDXLayout"}),(0,a.kt)("h1",{id:"\u0444\u0430\u0431\u0440\u0438\u043a\u0438-\u0445\u0443\u043a\u043e\u0432"},"\u0424\u0430\u0431\u0440\u0438\u043a\u0438 \u0445\u0443\u043a\u043e\u0432"),(0,a.kt)("h2",{id:"ihookfactory"},"\u0418\u043d\u0442\u0435\u0440\u0444\u0435\u0439\u0441 ",(0,a.kt)("inlineCode",{parentName:"h2"},"IHookFactory")),(0,a.kt)("p",null,"\u0412\u044b \u043c\u043e\u0436\u0435\u0442\u0435 \u0441\u043e\u0437\u0434\u0430\u0442\u044c \u0444\u0430\u0431\u0440\u0438\u043a\u0438 \u0445\u0443\u043a\u043e\u0432 \u043d\u0430\u0441\u043b\u0435\u0434\u0443\u044f \u043e\u0442 ",(0,a.kt)("inlineCode",{parentName:"p"},"IHookFactory<T>")," \u0438\u043b\u0438 \u043e\u0442 ",(0,a.kt)("inlineCode",{parentName:"p"},"HookFactoryBase<T>"),":"),(0,a.kt)("pre",null,(0,a.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyCustomHookFactory.cs"',title:'"MyCustomHookFactory.cs"'},'public class MyCustomHookFactory : HookFactoryBase<InvItem>\n{\n    public override bool TryCreate(InvItem instance, out IHook<InvItem> hook)\n    {\n        if (instance.Categories.Contains("Food"))\n        {\n            hook = new MyCustomHook();\n            return true;\n        }\n        hook = null;\n        return false;\n    }\n}\n')),(0,a.kt)("div",{className:"admonition admonition-caution alert alert--warning"},(0,a.kt)("div",{parentName:"div",className:"admonition-heading"},(0,a.kt)("h5",{parentName:"div"},(0,a.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,a.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"16",height:"16",viewBox:"0 0 16 16"},(0,a.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M8.893 1.5c-.183-.31-.52-.5-.887-.5s-.703.19-.886.5L.138 13.499a.98.98 0 0 0 0 1.001c.193.31.53.501.886.501h13.964c.367 0 .704-.19.877-.5a1.03 1.03 0 0 0 .01-1.002L8.893 1.5zm.133 11.497H6.987v-2.003h2.039v2.003zm0-3.004H6.987V5.987h2.039v4.006z"}))),"caution")),(0,a.kt)("div",{parentName:"div",className:"admonition-content"},(0,a.kt)("p",{parentName:"div"},"\u0412\u0430\u043c \u043d\u0443\u0436\u043d\u043e \u0442\u043e\u043b\u044c\u043a\u043e \u0441\u043e\u0437\u0434\u0430\u0442\u044c \u043e\u0431\u044a\u0435\u043a\u0442 \u0445\u0443\u043a\u0430. \u041d\u0435 \u043f\u0440\u0438\u0446\u0435\u043f\u043b\u044f\u0439\u0442\u0435 \u0435\u0433\u043e \u043a \u043e\u0431\u044a\u0435\u043a\u0442\u0443 \u043f\u043e\u043a\u0430 \u0447\u0442\u043e."))),(0,a.kt)("p",null,"\u041e\u0442\u0432\u0435\u0442\u0441\u0442\u0432\u0435\u043d\u043d\u043e\u0441\u0442\u044c \u0437\u0430 \u043f\u0440\u0438\u0446\u0435\u043f\u043b\u0435\u043d\u0438\u0435 \u0441\u043e\u0437\u0434\u0430\u043d\u043d\u044b\u0445 \u0445\u0443\u043a\u043e\u0432 \u043b\u0435\u0436\u0438\u0442 \u043d\u0430 \u0432\u043d\u0435\u0448\u043d\u0435\u043c \u043a\u043e\u0434\u0435:"),(0,a.kt)("pre",null,(0,a.kt)("code",{parentName:"pre",className:"language-csharp"},"if (factory.TryCreate(item, out IHook<InvItem> hook))\n{\n    item.AddHook(hook);\n}\n")),(0,a.kt)("h2",{id:"initialization"},"\u0418\u043d\u0438\u0446\u0438\u0430\u043b\u0438\u0437\u0430\u0446\u0438\u044f"),(0,a.kt)("p",null,"\u0412\u044b \u043c\u043e\u0436\u0435\u0442\u0435 \u043b\u0438\u0431\u043e \u0440\u0435\u0430\u043b\u0438\u0437\u043e\u0432\u0430\u0442\u044c \u0441\u0432\u043e\u0439 \u0441\u043f\u043e\u0441\u043e\u0431 \u0438\u0441\u043f\u043e\u043b\u044c\u0437\u043e\u0432\u0430\u043d\u0438\u044f \u0444\u0430\u0431\u0440\u0438\u043a, \u0438\u043b\u0438 \u043c\u043e\u0436\u0435\u0442\u0435 \u0434\u043e\u0431\u0430\u0432\u0438\u0442\u044c \u0435\u0451 \u0432 \u043a\u043b\u0430\u0441\u0441 ",(0,a.kt)("inlineCode",{parentName:"p"},"RogueFramework"),":"),(0,a.kt)("pre",null,(0,a.kt)("code",{parentName:"pre",className:"language-csharp"},"RogueFramework.ItemFactories.Add(new MyCustomHookFactory());\n")),(0,a.kt)("h2",{id:"examples"},"\u041f\u0440\u0438\u043c\u0435\u0440\u044b"),(0,a.kt)("p",null,"RogueLibs \u0438\u0441\u043f\u043e\u043b\u044c\u0437\u0443\u0435\u0442 ",(0,a.kt)("inlineCode",{parentName:"p"},"CustomItemFactory")," \u0438 \u0434\u0440\u0443\u0433\u0438\u0435 \u043f\u043e\u0434\u043e\u0431\u043d\u044b\u0435 \u043a\u043b\u0430\u0441\u0441\u044b \u0434\u043b\u044f \u0438\u043d\u0438\u0446\u0438\u0430\u043b\u0438\u0437\u0430\u0446\u0438\u0438 \u043a\u0430\u0441\u0442\u043e\u043c\u043d\u044b\u0445 \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u043e\u0432 \u0438 \u0434\u0440\u0443\u0433\u0438\u0445 \u0445\u0443\u043a\u043e\u0432:"),(0,a.kt)("pre",null,(0,a.kt)("code",{parentName:"pre",className:"language-csharp"},"public sealed class CustomItemFactory : HookFactoryBase<InvItem>\n{\n    private readonly Dictionary<string, ItemEntry> itemsDict = new Dictionary<string, ItemEntry>();\n    \n    public override bool TryCreate(InvItem instance, out IHook<InvItem> hook)\n    {\n        if (instance != null && itemsDict.TryGetValue(instance.invItemName, out ItemEntry entry))\n        {\n            hook = entry.Initializer();\n            if (hook is CustomItem custom)\n                custom.ItemInfo = entry.ItemInfo;\n            return true;\n        }\n        hook = null;\n        return false;\n    }\n    public ItemInfo AddItem<TItem>() where TItem : CustomItem, new()\n    {\n        ItemInfo info = ItemInfo.Get<TItem>();\n        itemsDict.Add(info.Name, new ItemEntry { Initializer = () => new TItem(), ItemInfo = info });\n        return info;\n    }\n\n    private struct ItemEntry\n    {\n        public Func<IHook<InvItem>> Initializer;\n        public ItemInfo ItemInfo;\n    }\n}\n")),(0,a.kt)("pre",null,(0,a.kt)("code",{parentName:"pre",className:"language-csharp"},"public static void InvItem_SetupDetails(InvItem __instance)\n{\n    foreach (IHookFactory<InvItem> factory in RogueFramework.ItemFactories)\n        if (factory.TryCreate(__instance, out IHook<InvItem> hook))\n        {\n            __instance.AddHook(hook);\n        }\n}\n")))}f.isMDXComponent=!0},6010:function(e,t,n){"use strict";function r(e){var t,n,o="";if("string"==typeof e||"number"==typeof e)o+=e;else if("object"==typeof e)if(Array.isArray(e))for(t=0;t<e.length;t++)e[t]&&(n=r(e[t]))&&(o&&(o+=" "),o+=n);else for(t in e)e[t]&&(o&&(o+=" "),o+=t);return o}function o(){for(var e,t,n=0,o="";n<arguments.length;)(e=arguments[n++])&&(t=r(e))&&(o&&(o+=" "),o+=t);return o}n.d(t,{Z:function(){return o}})}}]);