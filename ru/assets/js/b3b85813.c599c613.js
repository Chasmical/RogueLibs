(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[107],{3905:function(e,n,t){"use strict";t.d(n,{Zo:function(){return p},kt:function(){return g}});var i=t(7294);function r(e,n,t){return n in e?Object.defineProperty(e,n,{value:t,enumerable:!0,configurable:!0,writable:!0}):e[n]=t,e}function a(e,n){var t=Object.keys(e);if(Object.getOwnPropertySymbols){var i=Object.getOwnPropertySymbols(e);n&&(i=i.filter((function(n){return Object.getOwnPropertyDescriptor(e,n).enumerable}))),t.push.apply(t,i)}return t}function o(e){for(var n=1;n<arguments.length;n++){var t=null!=arguments[n]?arguments[n]:{};n%2?a(Object(t),!0).forEach((function(n){r(e,n,t[n])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(t)):a(Object(t)).forEach((function(n){Object.defineProperty(e,n,Object.getOwnPropertyDescriptor(t,n))}))}return e}function l(e,n){if(null==e)return{};var t,i,r=function(e,n){if(null==e)return{};var t,i,r={},a=Object.keys(e);for(i=0;i<a.length;i++)t=a[i],n.indexOf(t)>=0||(r[t]=e[t]);return r}(e,n);if(Object.getOwnPropertySymbols){var a=Object.getOwnPropertySymbols(e);for(i=0;i<a.length;i++)t=a[i],n.indexOf(t)>=0||Object.prototype.propertyIsEnumerable.call(e,t)&&(r[t]=e[t])}return r}var s=i.createContext({}),u=function(e){var n=i.useContext(s),t=n;return e&&(t="function"==typeof e?e(n):o(o({},n),e)),t},p=function(e){var n=u(e.components);return i.createElement(s.Provider,{value:n},e.children)},c={inlineCode:"code",wrapper:function(e){var n=e.children;return i.createElement(i.Fragment,{},n)}},m=i.forwardRef((function(e,n){var t=e.components,r=e.mdxType,a=e.originalType,s=e.parentName,p=l(e,["components","mdxType","originalType","parentName"]),m=u(t),g=r,d=m["".concat(s,".").concat(g)]||m[g]||c[g]||a;return t?i.createElement(d,o(o({ref:n},p),{},{components:t})):i.createElement(d,o({ref:n},p))}));function g(e,n){var t=arguments,r=n&&n.mdxType;if("string"==typeof e||r){var a=t.length,o=new Array(a);o[0]=m;var l={};for(var s in n)hasOwnProperty.call(n,s)&&(l[s]=n[s]);l.originalType=e,l.mdxType="string"==typeof e?e:r,o[1]=l;for(var u=2;u<a;u++)o[u]=t[u];return i.createElement.apply(null,o)}return i.createElement.apply(null,t)}m.displayName="MDXCreateElement"},3919:function(e,n,t){"use strict";function i(e){return!0===/^(\w*:|\/\/)/.test(e)}function r(e){return void 0!==e&&!i(e)}t.d(n,{b:function(){return i},Z:function(){return r}})},4996:function(e,n,t){"use strict";t.d(n,{C:function(){return a},Z:function(){return o}});var i=t(2263),r=t(3919);function a(){var e=(0,i.Z)().siteConfig,n=(e=void 0===e?{}:e).baseUrl,t=void 0===n?"/":n,a=e.url;return{withBaseUrl:function(e,n){return function(e,n,t,i){var a=void 0===i?{}:i,o=a.forcePrependBaseUrl,l=void 0!==o&&o,s=a.absolute,u=void 0!==s&&s;if(!t)return t;if(t.startsWith("#"))return t;if((0,r.b)(t))return t;if(l)return n+t;var p=t.startsWith(n)?t:n+t.replace(/^\//,"");return u?e+p:p}(a,t,e,n)}}}function o(e,n){return void 0===n&&(n={}),(0,a().withBaseUrl)(e,n)}},9443:function(e,n,t){"use strict";var i=(0,t(7294).createContext)(void 0);n.Z=i},9309:function(e,n,t){"use strict";t.d(n,{Z:function(){return l}});var i=t(2122),r=t(9756),a=t(7294),o=["children"];function l(e){var n=e.children,t=(0,r.Z)(e,o);return a.createElement("div",(0,i.Z)({role:"tabpanel"},t),n)}},8952:function(e,n,t){"use strict";t.d(n,{Z:function(){return m}});var i=t(7294),r=t(9443);var a=function(){var e=(0,i.useContext)(r.Z);if(null==e)throw new Error('"useUserPreferencesContext" is used outside of "Layout" component.');return e},o=t(6010),l="tabItem_2O3c",s="tabItemActive_Fpbe",u="tab_1pgU";var p=37,c=39;var m=function(e){var n=e.lazy,t=e.block,r=e.defaultValue,m=e.values,g=e.groupId,d=e.className,k=a(),v=k.tabGroupChoices,h=k.setTabGroupChoices,N=(0,i.useState)(r),f=N[0],b=N[1],y=i.Children.toArray(e.children),C=[];if(null!=g){var w=v[g];null!=w&&w!==f&&m.some((function(e){return e.value===w}))&&b(w)}var M=function(e){var n=e.currentTarget,t=C.indexOf(n),i=m[t].value;b(i),null!=g&&(h(g,i),setTimeout((function(){var e,t,i,r,a,o,l,u;(e=n.getBoundingClientRect(),t=e.top,i=e.left,r=e.bottom,a=e.right,o=window,l=o.innerHeight,u=o.innerWidth,t>=0&&a<=u&&r<=l&&i>=0)||(n.scrollIntoView({block:"center",behavior:"smooth"}),n.classList.add(s),setTimeout((function(){return n.classList.remove(s)}),2e3))}),150))},x=function(e){var n,t;switch(e.keyCode){case c:var i=C.indexOf(e.target)+1;t=C[i]||C[0];break;case p:var r=C.indexOf(e.target)-1;t=C[r]||C[C.length-1]}null==(n=t)||n.focus()},I=function(e,n){return n.value===e||n.values&&-1!=n.values.indexOf(e)};return i.createElement("div",{className:"tabs-container"},i.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:(0,o.Z)("tabs",{"tabs--block":t},d)},m.map((function(e){var n=e.value,t=e.label;return i.createElement("li",{role:"tab",tabIndex:f===n?0:-1,"aria-selected":f===n,className:(0,o.Z)("tabs__item",l,{"tabs__item--active":f===n}),key:n,ref:function(e){return C.push(e)},onKeyDown:x,onFocus:M,onClick:M},t)}))),n?(0,i.cloneElement)(y.filter((function(e){return I(f,e.props)}))[0],{className:u}):i.createElement("div",null,y.map((function(e,n){return(0,i.cloneElement)(e,{key:n,hidden:!I(f,e.props),className:u})}))),i.createElement("br",null))}},8908:function(e,n,t){"use strict";t.r(n),t.d(n,{frontMatter:function(){return s},contentTitle:function(){return u},metadata:function(){return p},toc:function(){return c},default:function(){return g}});var i=t(2122),r=t(9756),a=(t(7294),t(3905)),o=(t(8952),t(9309),t(4996)),l=["components"],s={},u="\u041f\u0440\u0438\u0441\u0442\u0443\u043f\u0430\u0435\u043c \u043a \u0440\u0430\u0431\u043e\u0442\u0435",p={unversionedId:"dev/getting-started",id:"dev/getting-started",isDocsHomePage:!1,title:"\u041f\u0440\u0438\u0441\u0442\u0443\u043f\u0430\u0435\u043c \u043a \u0440\u0430\u0431\u043e\u0442\u0435",description:"\u0422\u0440\u0435\u0431\u0443\u0435\u043c\u044b\u0435 \u043f\u0440\u043e\u0433\u0440\u0430\u043c\u043c\u044b",source:"@site/i18n/ru/docusaurus-plugin-content-docs/current/dev/getting-started.mdx",sourceDirName:"dev",slug:"/dev/getting-started",permalink:"/RogueLibs/ru/docs/dev/getting-started",editUrl:"https://github.com/Abbysssal/RogueLibs/edit/master/website/docs/dev/getting-started.mdx",version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"\u0418\u0441\u043f\u0440\u0430\u0432\u043b\u0435\u043d\u0438\u0435 \u043d\u0435\u0438\u0441\u043f\u0440\u0430\u0432\u043d\u043e\u0441\u0442\u0435\u0439",permalink:"/RogueLibs/ru/docs/user/troubleshooting"},next:{title:"\u0421\u043e\u0437\u0434\u0430\u0451\u043c \u043a\u0430\u0441\u0442\u043e\u043c\u043d\u044b\u0439 \u043f\u0440\u0435\u0434\u043c\u0435\u0442",permalink:"/RogueLibs/ru/docs/dev/items/create-item"}},c=[{value:"\u0422\u0440\u0435\u0431\u0443\u0435\u043c\u044b\u0435 \u043f\u0440\u043e\u0433\u0440\u0430\u043c\u043c\u044b",id:"tools",children:[]},{value:"\u0421\u043e\u0437\u0434\u0430\u0451\u043c \u043f\u0440\u043e\u0435\u043a\u0442",id:"creating-project",children:[]},{value:"\u041f\u0440\u0438\u0432\u044f\u0437\u044b\u0432\u0430\u043d\u0438\u0435 RogueLibs \u0438 \u0441\u0431\u043e\u0440\u043a\u0438 \u0438\u0433\u0440\u044b",id:"references",children:[]},{value:"\u041f\u0438\u0448\u0435\u043c \u043f\u0440\u043e\u0441\u0442\u043e\u0439 \u043f\u043b\u0430\u0433\u0438\u043d",id:"basic-plugin",children:[]},{value:"\u041f\u0440\u0438\u043c\u0435\u0440 \u043f\u043b\u0430\u0433\u0438\u043d\u0430 &quot;Hello World!&quot;",id:"hello-world",children:[]}],m={toc:c};function g(e){var n=e.components,t=(0,r.Z)(e,l);return(0,a.kt)("wrapper",(0,i.Z)({},m,t,{components:n,mdxType:"MDXLayout"}),(0,a.kt)("h1",{id:"\u043f\u0440\u0438\u0441\u0442\u0443\u043f\u0430\u0435\u043c-\u043a-\u0440\u0430\u0431\u043e\u0442\u0435"},"\u041f\u0440\u0438\u0441\u0442\u0443\u043f\u0430\u0435\u043c \u043a \u0440\u0430\u0431\u043e\u0442\u0435"),(0,a.kt)("h2",{id:"tools"},"\u0422\u0440\u0435\u0431\u0443\u0435\u043c\u044b\u0435 \u043f\u0440\u043e\u0433\u0440\u0430\u043c\u043c\u044b"),(0,a.kt)("p",null,"\u0414\u043b\u044f \u043d\u0430\u0447\u0430\u043b\u0430, \u0443\u0441\u0442\u0430\u043d\u043e\u0432\u0438\u0442\u0435 \u0441\u043b\u0435\u0434\u0443\u044e\u0449\u0435\u0435 \u043f\u0440\u043e\u0433\u0440\u0430\u043c\u043c\u043d\u043e\u0435 \u043e\u0431\u0435\u0441\u043f\u0435\u0447\u0435\u043d\u0438\u0435:"),(0,a.kt)("ul",null,(0,a.kt)("li",{parentName:"ul"},(0,a.kt)("p",{parentName:"li"},(0,a.kt)("strong",{parentName:"p"},(0,a.kt)("a",{parentName:"strong",href:"https://github.com/dnSpy/dnSpy/releases/latest"},"dnSpy"))," - \u0440\u0435\u0434\u0430\u043a\u0442\u043e\u0440 \u0441\u0431\u043e\u0440\u043e\u043a .NET (\u0438 \u043e\u0442\u043b\u0430\u0434\u0447\u0438\u043a, \u043d\u043e \u0435\u0433\u043e \u0434\u043e\u0432\u043e\u043b\u044c\u043d\u043e \u0441\u043b\u043e\u0436\u043d\u043e \u043d\u0430\u0441\u0442\u0440\u043e\u0438\u0442\u044c \u043f\u043e\u0434 BepInEx \u0438 \u043f\u043b\u0430\u0433\u0438\u043d\u044b). \u0412\u044b \u043d\u0435 \u0431\u0443\u0434\u0435\u0442\u0435 \u0440\u0435\u0434\u0430\u043a\u0442\u0438\u0440\u043e\u0432\u0430\u0442\u044c \u0441\u0431\u043e\u0440\u043a\u0438, \u0430 \u0431\u0443\u0434\u0435\u0442\u0435 \u043f\u0440\u043e\u0441\u0442\u043e \u0438\u0445 \u043f\u0440\u043e\u0441\u043c\u0430\u0442\u0440\u0438\u0432\u0430\u0442\u044c, \u0447\u0442\u043e\u0431\u044b \u043f\u043e\u043d\u0438\u043c\u0430\u0442\u044c \u043a\u0430\u043a \u0440\u0430\u0431\u043e\u0442\u0430\u0435\u0442 \u0438\u0433\u0440\u0430 \u0438\u043b\u0438 \u0434\u0440\u0443\u0433\u0438\u0435 \u043f\u043b\u0430\u0433\u0438\u043d\u044b.")),(0,a.kt)("li",{parentName:"ul"},(0,a.kt)("p",{parentName:"li"},(0,a.kt)("strong",{parentName:"p"},(0,a.kt)("a",{parentName:"strong",href:"https://visualstudio.microsoft.com/downloads/"},"Visual Studio 2019 Community"))," - \u0418\u043d\u0442\u0435\u0433\u0440\u0438\u0440\u043e\u0432\u0430\u043d\u043d\u0430\u044f \u0441\u0440\u0435\u0434\u0430 \u0440\u0430\u0437\u0440\u0430\u0431\u043e\u0442\u043a\u0438 (IDE - Integrated Development Environment), \u0432 \u043a\u043e\u0442\u043e\u0440\u043e\u0439 \u043c\u044b \u0431\u0443\u0434\u0435\u043c \u0440\u0430\u0431\u043e\u0442\u0430\u0442\u044c."))),(0,a.kt)("h2",{id:"creating-project"},"\u0421\u043e\u0437\u0434\u0430\u0451\u043c \u043f\u0440\u043e\u0435\u043a\u0442"),(0,a.kt)("p",null,"\u0418\u0442\u0430\u043a, \u043e\u0442\u043a\u0440\u043e\u0439\u0442\u0435 Visual Studio \u0438 ",(0,a.kt)("strong",{parentName:"p"},"\u0421\u043e\u0437\u0434\u0430\u0439\u0442\u0435 \u043d\u043e\u0432\u044b\u0439 \u043f\u0440\u043e\u0435\u043a\u0442"),":"),(0,a.kt)("img",{src:(0,o.Z)("/img/i18n/ru/setup/creating-project.png"),width:"800"}),(0,a.kt)("p",null,"\u041d\u0430\u0439\u0434\u0438\u0442\u0435 \u0438 \u0432\u044b\u0431\u0435\u0440\u0438\u0442\u0435 \u0448\u0430\u0431\u043b\u043e\u043d ",(0,a.kt)("strong",{parentName:"p"},"\u0411\u0438\u0431\u043b\u0438\u043e\u0442\u0435\u043a\u0430 \u043a\u043b\u0430\u0441\u0441\u043e\u0432 (.NET Framework)"),", \u0438 \u043a\u043b\u0438\u043a\u043d\u0438\u0442\u0435 ",(0,a.kt)("strong",{parentName:"p"},"\u0414\u0430\u043b\u0435\u0435"),":"),(0,a.kt)("img",{src:(0,o.Z)("/img/i18n/ru/setup/selecting-template.png"),width:"800"}),(0,a.kt)("p",null,"\u0412\u0432\u0435\u0434\u0438\u0442\u0435 \u043d\u0430\u0437\u0432\u0430\u043d\u0438\u0435 \u0441\u0432\u043e\u0435\u0433\u043e \u043f\u0440\u043e\u0435\u043a\u0442\u0430, \u0431\u0435\u0437 \u043f\u0440\u043e\u0431\u0435\u043b\u043e\u0432 \u0438\u043b\u0438 \u0442\u0438\u0440\u0435, \u0442\u043e\u043b\u044c\u043a\u043e \u0431\u0443\u043a\u0432\u044b. \u0412\u044b\u0431\u0435\u0440\u0438\u0442\u0435 \u0432\u0435\u0440\u0441\u0438\u044e .NET Framework ",(0,a.kt)("strong",{parentName:"p"},"4.5.2"),", \u0438 \u043a\u043b\u0438\u043a\u043d\u0438\u0442\u0435 ",(0,a.kt)("strong",{parentName:"p"},"\u0421\u043e\u0437\u0434\u0430\u0442\u044c"),"."),(0,a.kt)("div",{className:"admonition admonition-tip alert alert--success"},(0,a.kt)("div",{parentName:"div",className:"admonition-heading"},(0,a.kt)("h5",{parentName:"div"},(0,a.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,a.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"12",height:"16",viewBox:"0 0 12 16"},(0,a.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.5 0C3.48 0 1 2.19 1 5c0 .92.55 2.25 1 3 1.34 2.25 1.78 2.78 2 4v1h5v-1c.22-1.22.66-1.75 2-4 .45-.75 1-2.08 1-3 0-2.81-2.48-5-5.5-5zm3.64 7.48c-.25.44-.47.8-.67 1.11-.86 1.41-1.25 2.06-1.45 3.23-.02.05-.02.11-.02.17H5c0-.06 0-.13-.02-.17-.2-1.17-.59-1.83-1.45-3.23-.2-.31-.42-.67-.67-1.11C2.44 6.78 2 5.65 2 5c0-2.2 2.02-4 4.5-4 1.22 0 2.36.42 3.22 1.19C10.55 2.94 11 3.94 11 5c0 .66-.44 1.78-.86 2.48zM4 14h5c-.23 1.14-1.3 2-2.5 2s-2.27-.86-2.5-2z"}))),"\u0421\u043e\u0432\u0435\u0442 \u043e\u0442 \u043f\u0440\u043e\u0444\u0438: \u041f\u0430\u043f\u043a\u0430 \u0441 \u0440\u0435\u043f\u043e\u0437\u0438\u0442\u043e\u0440\u0438\u044f\u043c\u0438")),(0,a.kt)("div",{parentName:"div",className:"admonition-content"},(0,a.kt)("p",{parentName:"div"},"\u0412\u044b \u043c\u043e\u0436\u0435\u0442\u0435 \u0441\u043e\u0437\u0434\u0430\u0442\u044c \u043f\u0430\u043f\u043a\u0443 \u0434\u043b\u044f \u0432\u0430\u0448\u0438\u0445 \u0440\u0435\u043f\u043e\u0437\u0438\u0442\u043e\u0440\u0438\u0435\u0432 \u0432 \u043a\u043e\u0440\u043d\u0435 \u043e\u0434\u043d\u043e\u0433\u043e \u0438\u0437 \u0434\u0438\u0441\u043a\u043e\u0432, \u043d\u0430\u043f\u0440\u0438\u043c\u0435\u0440, ",(0,a.kt)("inlineCode",{parentName:"p"},"D:\\repos"),". \u042d\u0442\u043e \u0433\u043e\u0440\u0430\u0437\u0434\u043e \u043a\u043e\u0440\u043e\u0447\u0435, \u0434\u043e\u0441\u0442\u0443\u043f\u043d\u0435\u0435 \u0438 \u043f\u0440\u043e\u0449\u0435, \u0447\u0435\u043c \u0441\u0442\u043e\u044f\u0449\u0438\u0439 \u043f\u043e \u0443\u043c\u043e\u043b\u0447\u0430\u043d\u0438\u044e ",(0,a.kt)("inlineCode",{parentName:"p"},"C:\\Users\\$USER\\source\\repos"),"."))),(0,a.kt)("img",{src:(0,o.Z)("/img/i18n/ru/setup/configuring-project.png"),width:"800"}),(0,a.kt)("h2",{id:"references"},"\u041f\u0440\u0438\u0432\u044f\u0437\u044b\u0432\u0430\u043d\u0438\u0435 RogueLibs \u0438 \u0441\u0431\u043e\u0440\u043a\u0438 \u0438\u0433\u0440\u044b"),(0,a.kt)("p",null,"\u0421\u043e\u0437\u0434\u0430\u0439\u0442\u0435 \u043f\u0430\u043f\u043a\u0443 ",(0,a.kt)("strong",{parentName:"p"},(0,a.kt)("inlineCode",{parentName:"strong"},"Libraries"))," \u0432 \u043f\u0430\u043f\u043a\u0435 \u0432\u0430\u0448\u0435\u0433\u043e \u0440\u0435\u0448\u0435\u043d\u0438\u044f. \u041c\u044b \u0431\u0443\u0434\u0435\u043c \u043b\u043e\u0436\u0438\u0442\u044c \u0432\u0441\u0435 ",(0,a.kt)("inlineCode",{parentName:"p"},".dll")," \u0444\u0430\u0439\u043b\u044b, \u043d\u0430 \u043a\u043e\u0442\u043e\u0440\u044b\u0435 \u0431\u0443\u0434\u0435\u043c \u0441\u0441\u044b\u043b\u0430\u0442\u044c\u0441\u044f."),(0,a.kt)("img",{src:(0,o.Z)("/img/i18n/ru/setup/libraries-folder.png"),width:"800"}),(0,a.kt)("p",null,"\u041f\u0435\u0440\u0435\u0439\u0434\u0438\u0442\u0435 \u0432 ",(0,a.kt)("inlineCode",{parentName:"p"},"<GameName>_Data/Managed")," \u0432 \u043a\u043e\u0440\u043d\u0435 \u0438\u0433\u0440\u044b, \u0432\u043e\u0437\u044c\u043c\u0438\u0442\u0435 \u0441\u043b\u0435\u0434\u0443\u044e\u0449\u0438\u0435 \u0444\u0430\u0439\u043b\u044b \u0438 \u043f\u043e\u043b\u043e\u0436\u0438\u0442\u0435 \u0438\u0445 \u0432 ",(0,a.kt)("inlineCode",{parentName:"p"},"Libraries"),":"),(0,a.kt)("ul",null,(0,a.kt)("li",{parentName:"ul"},(0,a.kt)("strong",{parentName:"li"},(0,a.kt)("inlineCode",{parentName:"strong"},"Assembly-CSharp.dll"))," - \u0441\u0431\u043e\u0440\u043a\u0430 \u0441\u043e \u0432\u0441\u0435\u043c \u043a\u043e\u0434\u043e\u043c \u0438\u0433\u0440\u044b."),(0,a.kt)("li",{parentName:"ul"},(0,a.kt)("strong",{parentName:"li"},(0,a.kt)("inlineCode",{parentName:"strong"},"netstandard.dll"))," - \u0425\u0437, \u043f\u043e \u043a\u0430\u043a\u043e\u0439-\u0442\u043e \u043f\u0440\u0438\u0447\u0438\u043d\u0435, \u043e\u043d \u0438\u043d\u043e\u0433\u0434\u0430 \u043d\u0443\u0436\u0435\u043d."),(0,a.kt)("li",{parentName:"ul"},(0,a.kt)("strong",{parentName:"li"},(0,a.kt)("inlineCode",{parentName:"strong"},"UnityEngine.dll"))," \u0438 ",(0,a.kt)("strong",{parentName:"li"},(0,a.kt)("inlineCode",{parentName:"strong"},"UnityEngine.CoreModule.dll"))," - \u0441\u0431\u043e\u0440\u043a\u0438 Unity.")),(0,a.kt)("div",{className:"admonition admonition-info alert alert--info"},(0,a.kt)("div",{parentName:"div",className:"admonition-heading"},(0,a.kt)("h5",{parentName:"div"},(0,a.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,a.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,a.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M7 2.3c3.14 0 5.7 2.56 5.7 5.7s-2.56 5.7-5.7 5.7A5.71 5.71 0 0 1 1.3 8c0-3.14 2.56-5.7 5.7-5.7zM7 1C3.14 1 0 4.14 0 8s3.14 7 7 7 7-3.14 7-7-3.14-7-7-7zm1 3H6v5h2V4zm0 6H6v2h2v-2z"}))),"info")),(0,a.kt)("div",{parentName:"div",className:"admonition-content"},(0,a.kt)("p",{parentName:"div"},"\u0415\u0441\u043b\u0438 \u0432\u044b \u043d\u0435 \u0441\u043e\u0441\u043b\u0430\u043b\u0438\u0441\u044c \u043d\u0430 \u043a\u0430\u043a\u0443\u044e-\u0442\u043e \u0441\u0431\u043e\u0440\u043a\u0443, \u0432\u044b \u0443\u0432\u0438\u0434\u0438\u0442\u0435 \u043e\u0448\u0438\u0431\u043a\u0443 \u0432 ",(0,a.kt)("strong",{parentName:"p"},"\u0421\u043f\u0438\u0441\u043a\u0435 \u043e\u0448\u0438\u0431\u043e\u043a")," Visual Studio.",(0,a.kt)("br",null),"\u0412 \u0442\u0430\u043a\u043e\u043c \u0441\u043b\u0443\u0447\u0430\u0435, \u043f\u0435\u0440\u0435\u0439\u0434\u0438\u0442\u0435 \u043a ",(0,a.kt)("inlineCode",{parentName:"p"},"<GameName>_Data/Managed")," \u0441\u043d\u043e\u0432\u0430 \u0438 \u0432\u043e\u0437\u044c\u043c\u0438\u0442\u0435 \u043d\u0435\u0434\u043e\u0441\u0442\u0430\u044e\u0449\u0443\u044e \u0441\u0431\u043e\u0440\u043a\u0443."))),(0,a.kt)("p",null,"\u0422\u0435\u043f\u0435\u0440\u044c \u043f\u0435\u0440\u0435\u0439\u0434\u0438\u0442\u0435 \u0432 ",(0,a.kt)("inlineCode",{parentName:"p"},"BepInEx/core")," \u0432 \u043a\u043e\u0440\u043d\u0435 \u0438\u0433\u0440\u044b \u0438 \u0432\u043e\u0437\u044c\u043c\u0438\u0442\u0435 \u044d\u0442\u0438 \u0442\u043e\u0436\u0435:"),(0,a.kt)("ul",null,(0,a.kt)("li",{parentName:"ul"},(0,a.kt)("strong",{parentName:"li"},(0,a.kt)("inlineCode",{parentName:"strong"},"BepInEx.dll"))," \u0438 ",(0,a.kt)("strong",{parentName:"li"},(0,a.kt)("inlineCode",{parentName:"strong"},"BepInEx.xml")),"."),(0,a.kt)("li",{parentName:"ul"},(0,a.kt)("em",{parentName:"li"},(0,a.kt)("inlineCode",{parentName:"em"},"0Harmony.dll")," \u0438 ",(0,a.kt)("inlineCode",{parentName:"em"},"0Harmony.xml")," - \u043d\u0430 \u0441\u043b\u0443\u0447\u0430\u0439 \u0435\u0441\u043b\u0438 \u0432\u044b \u0431\u0443\u0434\u0435\u0442\u0435 \u0442\u0440\u0430\u043d\u0441\u043f\u0438\u043b\u0438\u0440\u043e\u0432\u0430\u0442\u044c \u043c\u0435\u0442\u043e\u0434\u044b \u0438\u043b\u0438 \u043f\u0430\u0442\u0447\u0438\u0442\u044c \u043d\u0430\u043f\u0440\u044f\u043c\u0443\u044e \u0447\u0435\u0440\u0435\u0437 Harmony."))),(0,a.kt)("p",null,(0,a.kt)("strong",{parentName:"p"},(0,a.kt)("a",{parentName:"strong",href:"https://github.com/Abbysssal/RogueLibs/releases/latest"},"\u0421\u043a\u0430\u0447\u0430\u0439\u0442\u0435 \u043f\u043e\u0441\u043b\u0435\u0434\u043d\u044e\u044e \u0432\u0435\u0440\u0441\u0438\u044e RogueLibs"),".")),(0,a.kt)("p",null,"\u0412\u0430\u043c \u043f\u043e\u043d\u0430\u0434\u043e\u0431\u0438\u0442\u0441\u044f \u0442\u043e\u043b\u044c\u043a\u043e \u0434\u0432\u0430 \u0444\u0430\u0439\u043b\u0430: ",(0,a.kt)("strong",{parentName:"p"},(0,a.kt)("inlineCode",{parentName:"strong"},"RogueLibsCore.dll")," \u0438 ",(0,a.kt)("inlineCode",{parentName:"strong"},"RogueLibsCore.xml")),". \u041f\u043e\u043b\u043e\u0436\u0438\u0442\u0435 \u0438\u0445 \u0432 ",(0,a.kt)("inlineCode",{parentName:"p"},"Libraries")," \u0442\u043e\u0436\u0435:"),(0,a.kt)("img",{src:(0,o.Z)("/img/i18n/ru/setup/libraries-folder-2.png"),width:"800"}),(0,a.kt)("p",null,"\u0422\u0435\u043f\u0435\u0440\u044c \u043e\u0442\u043a\u0440\u043e\u0439\u0442\u0435 Visual Studio, \u043d\u0430\u0439\u0434\u0438\u0442\u0435 \u0441\u0432\u043e\u0439 \u043f\u0440\u043e\u0435\u043a\u0442 \u0432 ",(0,a.kt)("strong",{parentName:"p"},"\u041e\u0431\u043e\u0437\u0440\u0435\u0432\u0430\u0442\u0435\u043b\u0435 \u0440\u0435\u0448\u0435\u043d\u0438\u0439"),", \u043d\u0430\u0436\u043c\u0438\u0442\u0435 \u043f\u0440\u0430\u0432\u043e\u0439 \u043a\u043d\u043e\u043f\u043a\u043e\u0439 \u043f\u043e ",(0,a.kt)("strong",{parentName:"p"},"\u0421\u0441\u044b\u043b\u043a\u0438")," \u0438 \u0432\u044b\u0431\u0435\u0440\u0438\u0442\u0435 ",(0,a.kt)("strong",{parentName:"p"},"\u0414\u043e\u0431\u0430\u0432\u0438\u0442\u044c \u0441\u0441\u044b\u043b\u043a\u0443..."),":"),(0,a.kt)("div",{className:"admonition admonition-note alert alert--secondary"},(0,a.kt)("div",{parentName:"div",className:"admonition-heading"},(0,a.kt)("h5",{parentName:"div"},(0,a.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,a.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,a.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.3 5.69a.942.942 0 0 1-.28-.7c0-.28.09-.52.28-.7.19-.18.42-.28.7-.28.28 0 .52.09.7.28.18.19.28.42.28.7 0 .28-.09.52-.28.7a1 1 0 0 1-.7.3c-.28 0-.52-.11-.7-.3zM8 7.99c-.02-.25-.11-.48-.31-.69-.2-.19-.42-.3-.69-.31H6c-.27.02-.48.13-.69.31-.2.2-.3.44-.31.69h1v3c.02.27.11.5.31.69.2.2.42.31.69.31h1c.27 0 .48-.11.69-.31.2-.19.3-.42.31-.69H8V7.98v.01zM7 2.3c-3.14 0-5.7 2.54-5.7 5.68 0 3.14 2.56 5.7 5.7 5.7s5.7-2.55 5.7-5.7c0-3.15-2.56-5.69-5.7-5.69v.01zM7 .98c3.86 0 7 3.14 7 7s-3.14 7-7 7-7-3.12-7-7 3.14-7 7-7z"}))),"note")),(0,a.kt)("div",{parentName:"div",className:"admonition-content"},(0,a.kt)("p",{parentName:"div"},"\u041a\u0441\u0442\u0430\u0442\u0438, \u043c\u043e\u0436\u0435\u0442\u0435 \u0443\u0431\u0440\u0430\u0442\u044c \u0432\u0441\u0435 \u0441\u0441\u044b\u043b\u043a\u0438 \u043f\u043e \u0443\u043c\u043e\u043b\u0447\u0430\u043d\u0438\u044e."))),(0,a.kt)("img",{src:(0,o.Z)("/img/i18n/ru/setup/references.png"),width:"400"}),(0,a.kt)("p",null,"\u0412 ",(0,a.kt)("strong",{parentName:"p"},"\u041c\u0435\u043d\u0435\u0434\u0436\u0435\u0440\u0435 \u0437\u0430\u0432\u0438\u0441\u0438\u043c\u043e\u0441\u0442\u0435\u0439")," \u0432\u044b\u0431\u0435\u0440\u0438\u0442\u0435 ",(0,a.kt)("strong",{parentName:"p"},"\u041e\u0431\u0437\u043e\u0440..."),", \u0432\u044b\u0434\u0435\u043b\u0438\u0442\u0435 \u0432\u0441\u0435 ",(0,a.kt)("inlineCode",{parentName:"p"},".dll")," \u0444\u0430\u0439\u043b\u044b \u0432 \u043f\u0430\u043f\u043a\u0435 ",(0,a.kt)("inlineCode",{parentName:"p"},"Libraries")," \u0438 \u043a\u043b\u0438\u043a\u043d\u0438\u0442\u0435 ",(0,a.kt)("strong",{parentName:"p"},"\u0414\u043e\u0431\u0430\u0432\u0438\u0442\u044c"),"."),(0,a.kt)("img",{src:(0,o.Z)("/img/i18n/ru/setup/references-2.png"),width:"800"}),(0,a.kt)("h2",{id:"basic-plugin"},"\u041f\u0438\u0448\u0435\u043c \u043f\u0440\u043e\u0441\u0442\u043e\u0439 \u043f\u043b\u0430\u0433\u0438\u043d"),(0,a.kt)("p",null,"\u0414\u043e\u0431\u0430\u0432\u044c\u0442\u0435 ",(0,a.kt)("inlineCode",{parentName:"p"},"using"),", \u043a\u043e\u0442\u043e\u0440\u044b\u0435 \u043c\u043e\u0433\u0443\u0442 \u043f\u0440\u0438\u0433\u043e\u0434\u0438\u0442\u044c\u0441\u044f:"),(0,a.kt)("pre",null,(0,a.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="Class1.cs"',title:'"Class1.cs"'},"// highlight-start\nusing System;\nusing System.IO;\nusing System.Linq;\nusing System.Collections;\nusing System.Collections.Generic;\nusing System.Reflection;\nusing System.Text;\nusing BepInEx;\nusing UnityEngine;\nusing RogueLibsCore;\n// highlight-end\n\nnamespace MyCoolMod\n{\n    public class Class1\n    {\n        \n    }\n}\n")),(0,a.kt)("p",null,"\u0421\u043e\u0437\u0434\u0430\u0439\u0442\u0435 \u043a\u043b\u0430\u0441\u0441, \u043d\u0430\u0441\u043b\u0435\u0434\u0443\u044e\u0449\u0438\u0439 \u043e\u0442 ",(0,a.kt)("inlineCode",{parentName:"p"},"BaseUnityPlugin"),"."),(0,a.kt)("pre",null,(0,a.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyCoolPlugin.cs"',title:'"MyCoolPlugin.cs"'},"namespace MyCoolMod\n{\n    // highlight-next-line\n    public class MyCoolPlugin : BaseUnityPlugin\n    {\n    }\n}\n")),(0,a.kt)("p",null,"\u0414\u043e\u0431\u0430\u0432\u044c\u0442\u0435 \u043a \u043d\u0435\u043c\u0443 \u0430\u0442\u0440\u0438\u0431\u0443\u0442 ",(0,a.kt)("inlineCode",{parentName:"p"},"BepInPlugin")," \u0441 ",(0,a.kt)("abbr",{title:"Globally Unique Identifier - \u0443\u043d\u0438\u0432\u0435\u0440\u0441\u0430\u043b\u044c\u043d\u044b\u0439 \u0443\u043d\u0438\u043a\u0430\u043b\u044c\u043d\u044b\u0439 \u0438\u0434\u0435\u043d\u0442\u0438\u0444\u0438\u043a\u0430\u0442\u043e\u0440"},"GUID"),", \u043d\u0430\u0437\u0432\u0430\u043d\u0438\u0435\u043c \u0438 \u0432\u0435\u0440\u0441\u0438\u0435\u0439 \u0441\u0432\u043e\u0435\u0433\u043e \u043f\u043b\u0430\u0433\u0438\u043d\u0430.",(0,a.kt)("br",{parentName:"p"}),"\n","\u0412\u044b \u043c\u043e\u0436\u0435\u0442\u0435 \u043f\u043e\u0441\u0442\u0430\u0432\u0438\u0442\u044c \u0441\u0442\u0440\u043e\u043a\u0438 \u043f\u0440\u044f\u043c\u043e \u0432 \u0430\u0442\u0440\u0438\u0431\u0443\u0442, \u0431\u0435\u0437 \u0438\u0441\u043f\u043e\u043b\u044c\u0437\u043e\u0432\u0430\u043d\u0438\u044f \u043a\u043e\u043d\u0441\u0442\u0430\u043d\u0442, \u0435\u0441\u043b\u0438 \u0445\u043e\u0442\u0438\u0442\u0435."),(0,a.kt)("pre",null,(0,a.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyCoolPlugin.cs"',title:'"MyCoolPlugin.cs"'},'// highlight-next-line\n[BepInPlugin(pluginGUID, pluginName, pluginVersion)]\npublic class MyCoolPlugin : BaseUnityPlugin\n{\n    // highlight-start\n    public const string pluginGUID = "myusername.streetsofrogue.mycoolmod";\n    public const string pluginName = "My Cool Mod";\n    public const string pluginVersion = "0.1.0";\n    // highlight-end\n}\n')),(0,a.kt)("div",{className:"admonition admonition-caution alert alert--warning"},(0,a.kt)("div",{parentName:"div",className:"admonition-heading"},(0,a.kt)("h5",{parentName:"div"},(0,a.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,a.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"16",height:"16",viewBox:"0 0 16 16"},(0,a.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M8.893 1.5c-.183-.31-.52-.5-.887-.5s-.703.19-.886.5L.138 13.499a.98.98 0 0 0 0 1.001c.193.31.53.501.886.501h13.964c.367 0 .704-.19.877-.5a1.03 1.03 0 0 0 .01-1.002L8.893 1.5zm.133 11.497H6.987v-2.003h2.039v2.003zm0-3.004H6.987V5.987h2.039v4.006z"}))),"caution")),(0,a.kt)("div",{parentName:"div",className:"admonition-content"},(0,a.kt)("p",{parentName:"div"},"\u041a\u0430\u043a \u0442\u043e\u043b\u044c\u043a\u043e \u0432\u044b \u043e\u043f\u0443\u0431\u043b\u0438\u043a\u0443\u0435\u0442\u0435 \u0441\u0432\u043e\u0439 \u043c\u043e\u0434, ",(0,a.kt)("strong",{parentName:"p"},"\u043d\u0435 \u0438\u0437\u043c\u0435\u043d\u044f\u0439\u0442\u0435 \u0435\u0433\u043e GUID!")," \u0415\u0441\u043b\u0438 \u0432\u044b \u0438\u0437\u043c\u0435\u043d\u0438\u0442\u0435, \u0432\u0441\u0435 \u0434\u0435\u0440\u0435\u0432\u044c\u044f \u0437\u0430\u0432\u0438\u0441\u0438\u043c\u043e\u0441\u0442\u0435\u0439 \u0441 \u0432\u0430\u0448\u0438\u043c \u043c\u043e\u0434\u043e\u043c \u0441\u043b\u043e\u043c\u0430\u044e\u0442\u0441\u044f. \u0414\u0430\u0436\u0435 \u0435\u0441\u043b\u0438 \u043d\u0438\u043a\u0442\u043e \u043d\u0435 \u0438\u0441\u043f\u043e\u043b\u044c\u0437\u0443\u0435\u0442 \u0432\u0430\u0448 \u043c\u043e\u0434 \u043a\u0430\u043a \u043e\u0441\u043d\u043e\u0432\u0443, \u043d\u0435\u043a\u043e\u0442\u043e\u0440\u044b\u0435 \u0440\u0430\u0437\u0440\u0430\u0431\u043e\u0442\u0447\u0438\u043a\u0438 \u043c\u043e\u0433\u043b\u0438 \u0434\u043e\u0431\u0430\u0432\u0438\u0442\u044c \u0430\u0442\u0440\u0438\u0431\u0443\u0442 ",(0,a.kt)("inlineCode",{parentName:"p"},"BepInIncompatibility")," \u0441 GUID \u0432\u0430\u0448\u0435\u0433\u043e \u043c\u043e\u0434\u0430. \u0415\u0441\u043b\u0438 \u0445\u043e\u0442\u0438\u0442\u0435 \u0438\u0437\u043c\u0435\u043d\u0438\u0442\u044c GUID, \u0442\u043e \u0441\u043e\u0437\u0434\u0430\u0439\u0442\u0435 \u043d\u043e\u0432\u044b\u0439 \u043c\u043e\u0434 \u043d\u0430 \u0437\u0430\u043c\u0435\u043d\u0443 \u0441\u0442\u0430\u0440\u043e\u043c\u0443."))),(0,a.kt)("div",{className:"admonition admonition-tip alert alert--success"},(0,a.kt)("div",{parentName:"div",className:"admonition-heading"},(0,a.kt)("h5",{parentName:"div"},(0,a.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,a.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"12",height:"16",viewBox:"0 0 12 16"},(0,a.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.5 0C3.48 0 1 2.19 1 5c0 .92.55 2.25 1 3 1.34 2.25 1.78 2.78 2 4v1h5v-1c.22-1.22.66-1.75 2-4 .45-.75 1-2.08 1-3 0-2.81-2.48-5-5.5-5zm3.64 7.48c-.25.44-.47.8-.67 1.11-.86 1.41-1.25 2.06-1.45 3.23-.02.05-.02.11-.02.17H5c0-.06 0-.13-.02-.17-.2-1.17-.59-1.83-1.45-3.23-.2-.31-.42-.67-.67-1.11C2.44 6.78 2 5.65 2 5c0-2.2 2.02-4 4.5-4 1.22 0 2.36.42 3.22 1.19C10.55 2.94 11 3.94 11 5c0 .66-.44 1.78-.86 2.48zM4 14h5c-.23 1.14-1.3 2-2.5 2s-2.27-.86-2.5-2z"}))),"\u0421\u043e\u0432\u0435\u0442 \u043e\u0442 \u043f\u0440\u043e\u0444\u0438: \u0421\u0435\u043c\u0430\u043d\u0442\u0438\u0447\u0435\u0441\u043a\u043e\u0435 \u0432\u0435\u0440\u0441\u0438\u043e\u043d\u0438\u0440\u043e\u0432\u0430\u043d\u0438\u0435")),(0,a.kt)("div",{parentName:"div",className:"admonition-content"},(0,a.kt)("p",{parentName:"div"},"\u042f \u0440\u0435\u043a\u043e\u043c\u0435\u043d\u0434\u0443\u044e \u0438\u0441\u043f\u043e\u043b\u044c\u0437\u043e\u0432\u0430\u0442\u044c ",(0,a.kt)("a",{parentName:"p",href:"https://semver.org/lang/ru/"},"\u0441\u0435\u043c\u0430\u043d\u0442\u0438\u0447\u0435\u0441\u043a\u043e\u0435 \u0432\u0435\u0440\u0441\u0438\u043e\u043d\u0438\u0440\u043e\u0432\u0430\u043d\u0438\u0435")," \u0432 \u0432\u0430\u0448\u0438\u0445 \u043c\u043e\u0434\u0430\u0445."))),(0,a.kt)("p",null,"\u0414\u043e\u0431\u0430\u0432\u044c\u0442\u0435 \u0430\u0442\u0440\u0438\u0431\u0443\u0442 ",(0,a.kt)("inlineCode",{parentName:"p"},"BepInDependency")," \u0441 RogueLibs \u0438 \u0434\u043e\u0431\u0430\u0432\u044c\u0442\u0435 ",(0,a.kt)("inlineCode",{parentName:"p"},"Awake()")," \u043c\u0435\u0442\u043e\u0434 \u0438\u0437 Unity:"),(0,a.kt)("pre",null,(0,a.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyCoolPlugin.cs"',title:'"MyCoolPlugin.cs"'},'[BepInPlugin(pluginGUID, pluginName, pluginVersion)]\n// highlight-next-line\n[BepInDependency(RogueLibs.GUID, RogueLibs.CompiledVersion)]\npublic class MyCoolPlugin : BaseUnityPlugin\n{\n    public const string pluginGUID = "myusername.streetsofrogue.mycoolmod";\n    public const string pluginName = "My Cool Mod";\n    public const string pluginVersion = "0.1.0";\n\n    // highlight-start\n    public void Awake()\n    {\n        // \u0432\u0430\u0448 \u043a\u043e\u0434 \u0442\u0443\u0442\n    }\n    // highlight-end\n}\n')),(0,a.kt)("p",null,(0,a.kt)("strong",{parentName:"p"},"\u0422\u0435\u043f\u0435\u0440\u044c \u043f\u0440\u043e\u0441\u0442\u043e \u0438\u0437\u0443\u0447\u0430\u0439\u0442\u0435 \u0434\u043e\u043a\u0443\u043c\u0435\u043d\u0442\u0430\u0446\u0438\u044e \u0438 \u0434\u0435\u043b\u0430\u0439\u0442\u0435 \u0447\u0442\u043e-\u043d\u0438\u0431\u0443\u0434\u044c!")),(0,a.kt)("h2",{id:"hello-world"},'\u041f\u0440\u0438\u043c\u0435\u0440 \u043f\u043b\u0430\u0433\u0438\u043d\u0430 "Hello World!"'),(0,a.kt)("pre",null,(0,a.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyCoolPlugin.cs"',title:'"MyCoolPlugin.cs"'},'using System;\nusing System.IO;\nusing System.Linq;\nusing System.Collections;\nusing System.Collections.Generic;\nusing System.Reflection;\nusing System.Text;\nusing BepInEx;\nusing UnityEngine;\nusing RogueLibsCore;\n\nnamespace MyCoolMod\n{\n    [BepInPlugin(pluginGUID, pluginName, pluginVersion)]\n    [BepInDependency(RogueLibs.GUID, RogueLibs.CompiledVersion)]\n    public class MyCoolPlugin : BaseUnityPlugin\n    {\n        public const string pluginGUID = "myusername.streetsofrogue.mycoolmod";\n        public const string pluginName = "My Cool Mod";\n        public const string pluginVersion = "0.1.0";\n\n        public static BepInEx.Logging.ManualLogSource MyLogger;\n        // \u0442\u0430\u043a \u0432\u044b \u0441\u043c\u043e\u0436\u0435\u0442\u0435 \u0443\u043f\u043e\u043c\u0438\u043d\u0430\u0442\u044c \u0435\u0433\u043e \u0432 \u043f\u0430\u0442\u0447\u0430\u0445\n\n        public void Awake()\n        {\n            MyLogger = Logger;\n            Logger.LogMessage("Hello World!");\n        }\n    }\n}\n')))}g.isMDXComponent=!0},6010:function(e,n,t){"use strict";function i(e){var n,t,r="";if("string"==typeof e||"number"==typeof e)r+=e;else if("object"==typeof e)if(Array.isArray(e))for(n=0;n<e.length;n++)e[n]&&(t=i(e[n]))&&(r&&(r+=" "),r+=t);else for(n in e)e[n]&&(r&&(r+=" "),r+=n);return r}function r(){for(var e,n,t=0,r="";t<arguments.length;)(e=arguments[t++])&&(n=i(e))&&(r&&(r+=" "),r+=n);return r}t.d(n,{Z:function(){return r}})}}]);