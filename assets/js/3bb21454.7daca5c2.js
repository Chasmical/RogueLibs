(self.webpackChunkdocs=self.webpackChunkdocs||[]).push([[731],{3905:function(e,t,n){"use strict";n.d(t,{Zo:function(){return s},kt:function(){return p}});var r=n(7294);function a(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function i(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(e);t&&(r=r.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,r)}return n}function o(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?i(Object(n),!0).forEach((function(t){a(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):i(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function u(e,t){if(null==e)return{};var n,r,a=function(e,t){if(null==e)return{};var n,r,a={},i=Object.keys(e);for(r=0;r<i.length;r++)n=i[r],t.indexOf(n)>=0||(a[n]=e[n]);return a}(e,t);if(Object.getOwnPropertySymbols){var i=Object.getOwnPropertySymbols(e);for(r=0;r<i.length;r++)n=i[r],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(a[n]=e[n])}return a}var c=r.createContext({}),l=function(e){var t=r.useContext(c),n=t;return e&&(n="function"==typeof e?e(t):o(o({},t),e)),n},s=function(e){var t=l(e.components);return r.createElement(c.Provider,{value:t},e.children)},d={inlineCode:"code",wrapper:function(e){var t=e.children;return r.createElement(r.Fragment,{},t)}},f=r.forwardRef((function(e,t){var n=e.components,a=e.mdxType,i=e.originalType,c=e.parentName,s=u(e,["components","mdxType","originalType","parentName"]),f=l(n),p=a,m=f["".concat(c,".").concat(p)]||f[p]||d[p]||i;return n?r.createElement(m,o(o({ref:t},s),{},{components:n})):r.createElement(m,o({ref:t},s))}));function p(e,t){var n=arguments,a=t&&t.mdxType;if("string"==typeof e||a){var i=n.length,o=new Array(i);o[0]=f;var u={};for(var c in t)hasOwnProperty.call(t,c)&&(u[c]=t[c]);u.originalType=e,u.mdxType="string"==typeof e?e:a,o[1]=u;for(var l=2;l<i;l++)o[l]=n[l];return r.createElement.apply(null,o)}return r.createElement.apply(null,n)}f.displayName="MDXCreateElement"},3919:function(e,t,n){"use strict";function r(e){return!0===/^(\w*:|\/\/)/.test(e)}function a(e){return void 0!==e&&!r(e)}n.d(t,{b:function(){return r},Z:function(){return a}})},4996:function(e,t,n){"use strict";n.d(t,{C:function(){return i},Z:function(){return o}});var r=n(2263),a=n(3919);function i(){var e=(0,r.Z)().siteConfig,t=(e=void 0===e?{}:e).baseUrl,n=void 0===t?"/":t,i=e.url;return{withBaseUrl:function(e,t){return function(e,t,n,r){var i=void 0===r?{}:r,o=i.forcePrependBaseUrl,u=void 0!==o&&o,c=i.absolute,l=void 0!==c&&c;if(!n)return n;if(n.startsWith("#"))return n;if((0,a.b)(n))return n;if(u)return t+n;var s=n.startsWith(t)?n:t+n.replace(/^\//,"");return l?e+s:s}(i,n,e,t)}}}function o(e,t){return void 0===t&&(t={}),(0,i().withBaseUrl)(e,t)}},9443:function(e,t,n){"use strict";var r=(0,n(7294).createContext)(void 0);t.Z=r},9309:function(e,t,n){"use strict";n.d(t,{Z:function(){return u}});var r=n(2122),a=n(9756),i=n(7294),o=["children"];function u(e){var t=e.children,n=(0,a.Z)(e,o);return i.createElement("div",(0,r.Z)({role:"tabpanel"},n),t)}},8952:function(e,t,n){"use strict";n.d(t,{Z:function(){return f}});var r=n(7294),a=n(9443);var i=function(){var e=(0,r.useContext)(a.Z);if(null==e)throw new Error('"useUserPreferencesContext" is used outside of "Layout" component.');return e},o=n(6010),u="tabItem_2O3c",c="tabItemActive_Fpbe",l="tab_1pgU";var s=37,d=39;var f=function(e){var t=e.lazy,n=e.block,a=e.defaultValue,f=e.values,p=e.groupId,m=e.className,v=i(),b=v.tabGroupChoices,h=v.setTabGroupChoices,g=(0,r.useState)(a),y=g[0],x=g[1],k=r.Children.toArray(e.children),O=[];if(null!=p){var w=b[p];null!=w&&w!==y&&f.some((function(e){return e.value===w}))&&x(w)}var C=function(e){var t=e.currentTarget,n=O.indexOf(t),r=f[n].value;x(r),null!=p&&(h(p,r),setTimeout((function(){var e,n,r,a,i,o,u,l;(e=t.getBoundingClientRect(),n=e.top,r=e.left,a=e.bottom,i=e.right,o=window,u=o.innerHeight,l=o.innerWidth,n>=0&&i<=l&&a<=u&&r>=0)||(t.scrollIntoView({block:"center",behavior:"smooth"}),t.classList.add(c),setTimeout((function(){return t.classList.remove(c)}),2e3))}),150))},I=function(e){var t,n;switch(e.keyCode){case d:var r=O.indexOf(e.target)+1;n=O[r]||O[0];break;case s:var a=O.indexOf(e.target)-1;n=O[a]||O[O.length-1]}null==(t=n)||t.focus()},U=function(e,t){return t.value===e||t.values&&-1!=t.values.indexOf(e)};return r.createElement("div",{className:"tabs-container"},r.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:(0,o.Z)("tabs",{"tabs--block":n},m)},f.map((function(e){var t=e.value,n=e.label;return r.createElement("li",{role:"tab",tabIndex:y===t?0:-1,"aria-selected":y===t,className:(0,o.Z)("tabs__item",u,{"tabs__item--active":y===t}),key:t,ref:function(e){return O.push(e)},onKeyDown:I,onFocus:C,onClick:C},n)}))),t?(0,r.cloneElement)(k.filter((function(e){return U(y,e.props)}))[0],{curSelected:y,className:l}):r.createElement("div",null,k.map((function(e,t){return(0,r.cloneElement)(e,{key:t,hidden:!U(y,e.props),selectedValue:y,className:l})}))),r.createElement("br",null))}},19:function(e,t,n){"use strict";n.r(t),n.d(t,{frontMatter:function(){return l},contentTitle:function(){return s},metadata:function(){return d},toc:function(){return f},default:function(){return m}});var r=n(2122),a=n(9756),i=(n(7294),n(3905)),o=n(8952),u=n(9309),c=(n(4996),["components"]),l={},s="Extra Stuff",d={unversionedId:"extra",id:"extra",isDocsHomePage:!1,title:"Extra Stuff",description:"IDoUpdate and IDoFixedUpdate",source:"@site/docs/extra.mdx",sourceDirName:".",slug:"/extra",permalink:"/RogueLibs/docs/extra",editUrl:"https://github.com/Abbysssal/RogueLibs/edit/master/docs/docs/extra.mdx",version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"Custom Sprites",permalink:"/RogueLibs/docs/custom-sprites"},next:{title:"Patching Utilities",permalink:"/RogueLibs/docs/patching-utilities"}},f=[{value:"<code>IDoUpdate</code> and <code>IDoFixedUpdate</code>",id:"update-interfaces",children:[]}],p={toc:f};function m(e){var t=e.components,n=(0,a.Z)(e,c);return(0,i.kt)("wrapper",(0,r.Z)({},p,n,{components:t,mdxType:"MDXLayout"}),(0,i.kt)("h1",{id:"extra-stuff"},"Extra Stuff"),(0,i.kt)("h2",{id:"update-interfaces"},(0,i.kt)("inlineCode",{parentName:"h2"},"IDoUpdate")," and ",(0,i.kt)("inlineCode",{parentName:"h2"},"IDoFixedUpdate")),(0,i.kt)("p",null,"If you want to update your items/traits/unlocks with Unity's ",(0,i.kt)("inlineCode",{parentName:"p"},"Update")," or ",(0,i.kt)("inlineCode",{parentName:"p"},"FixedUpdate"),", implement these interfaces:"),(0,i.kt)(o.Z,{defaultValue:"update",values:[{label:"IDoUpdate",value:"update"},{label:"IDoFixedUpdate",value:"fixedupdate"}],mdxType:"Tabs"},(0,i.kt)(u.Z,{value:"update",mdxType:"TabItem"},(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-csharp"},"// highlight-next-line\npublic class MyCustomItem : CustomItem, IDoUpdate\n{\n    // highlight-start\n    public void Update()\n    {\n        ...\n    }\n    // highlight-end\n}\n"))),(0,i.kt)(u.Z,{value:"fixedupdate",mdxType:"TabItem"},(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-csharp"},"// highlight-next-line\npublic class MyCustomItem : CustomItem, IDoFixedUpdate\n{\n    // highlight-start\n    public void FixedUpdate()\n    {\n        ...\n    }\n    // highlight-end\n}\n")))))}m.isMDXComponent=!0},6010:function(e,t,n){"use strict";function r(e){var t,n,a="";if("string"==typeof e||"number"==typeof e)a+=e;else if("object"==typeof e)if(Array.isArray(e))for(t=0;t<e.length;t++)e[t]&&(n=r(e[t]))&&(a&&(a+=" "),a+=n);else for(t in e)e[t]&&(a&&(a+=" "),a+=t);return a}function a(){for(var e,t,n=0,a="";n<arguments.length;)(e=arguments[n++])&&(t=r(e))&&(a&&(a+=" "),a+=t);return a}n.d(t,{Z:function(){return a}})}}]);