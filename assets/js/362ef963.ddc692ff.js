(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[279],{8173:function(e,t,n){"use strict";function r(e,t){(null==t||t>e.length)&&(t=e.length);for(var n=0,r=new Array(t);n<t;n++)r[n]=e[n];return r}function o(e,t){var n="undefined"!=typeof Symbol&&e[Symbol.iterator]||e["@@iterator"];if(n)return(n=n.call(e)).next.bind(n);if(Array.isArray(e)||(n=function(e,t){if(e){if("string"==typeof e)return r(e,t);var n=Object.prototype.toString.call(e).slice(8,-1);return"Object"===n&&e.constructor&&(n=e.constructor.name),"Map"===n||"Set"===n?Array.from(e):"Arguments"===n||/^(?:Ui|I)nt(?:8|16|32)(?:Clamped)?Array$/.test(n)?r(e,t):void 0}}(e))||t&&e&&"number"==typeof e.length){n&&(e=n);var o=0;return function(){return o>=e.length?{done:!0}:{done:!1,value:e[o++]}}}throw new TypeError("Invalid attempt to iterate non-iterable instance.\nIn order to be iterable, non-array objects must have a [Symbol.iterator]() method.")}n.d(t,{Z:function(){return o}})},3905:function(e,t,n){"use strict";n.d(t,{Zo:function(){return s},kt:function(){return m}});var r=n(7294);function o(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function i(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(e);t&&(r=r.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,r)}return n}function c(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?i(Object(n),!0).forEach((function(t){o(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):i(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function a(e,t){if(null==e)return{};var n,r,o=function(e,t){if(null==e)return{};var n,r,o={},i=Object.keys(e);for(r=0;r<i.length;r++)n=i[r],t.indexOf(n)>=0||(o[n]=e[n]);return o}(e,t);if(Object.getOwnPropertySymbols){var i=Object.getOwnPropertySymbols(e);for(r=0;r<i.length;r++)n=i[r],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(o[n]=e[n])}return o}var u=r.createContext({}),l=function(e){var t=r.useContext(u),n=t;return e&&(n="function"==typeof e?e(t):c(c({},t),e)),n},s=function(e){var t=l(e.components);return r.createElement(u.Provider,{value:t},e.children)},p={inlineCode:"code",wrapper:function(e){var t=e.children;return r.createElement(r.Fragment,{},t)}},f=r.forwardRef((function(e,t){var n=e.components,o=e.mdxType,i=e.originalType,u=e.parentName,s=a(e,["components","mdxType","originalType","parentName"]),f=l(n),m=o,y=f["".concat(u,".").concat(m)]||f[m]||p[m]||i;return n?r.createElement(y,c(c({ref:t},s),{},{components:n})):r.createElement(y,c({ref:t},s))}));function m(e,t){var n=arguments,o=t&&t.mdxType;if("string"==typeof e||o){var i=n.length,c=new Array(i);c[0]=f;var a={};for(var u in t)hasOwnProperty.call(t,u)&&(a[u]=t[u]);a.originalType=e,a.mdxType="string"==typeof e?e:o,c[1]=a;for(var l=2;l<i;l++)c[l]=n[l];return r.createElement.apply(null,c)}return r.createElement.apply(null,n)}f.displayName="MDXCreateElement"},3310:function(e,t,n){"use strict";n.r(t),n.d(t,{frontMatter:function(){return s},contentTitle:function(){return p},metadata:function(){return f},toc:function(){return m},default:function(){return v}});var r=n(2122),o=n(9756),i=(n(7294),n(3905)),c=n(4996),a=n(2823),u=(n(7851),n(2932)),l=["components"],s={},p="Test Page",f={type:"mdx",permalink:"/RogueLibs/test",source:"@site/src/pages/test.mdx"},m=[],y={toc:m};function v(e){var t=e.components,n=(0,o.Z)(e,l);return(0,i.kt)("wrapper",(0,r.Z)({},y,n,{components:t,mdxType:"MDXLayout"}),(0,i.kt)("h1",{id:"test-page"},"Test Page"),(0,i.kt)(u.Z,{items:[{}],interactable:!0,width:5,mdxType:"InventoryToolbar"},(0,i.kt)(a.Z,{sprite:(0,c.Z)("/img/TestItem.png"),count:"1",mdxType:"InventorySlot"}),(0,i.kt)(a.Z,{sprite:(0,c.Z)("/img/TestItem.png"),count:"77",tooltip:"$3",mdxType:"InventorySlot"}),(0,i.kt)(a.Z,{sprite:(0,c.Z)("/img/TestItem.png"),count:"13",mdxType:"InventorySlot"})))}v.isMDXComponent=!0},3919:function(e,t,n){"use strict";function r(e){return!0===/^(\w*:|\/\/)/.test(e)}function o(e){return void 0!==e&&!r(e)}n.d(t,{b:function(){return r},Z:function(){return o}})},4996:function(e,t,n){"use strict";n.d(t,{C:function(){return i},Z:function(){return c}});var r=n(2263),o=n(3919);function i(){var e=(0,r.Z)().siteConfig,t=(e=void 0===e?{}:e).baseUrl,n=void 0===t?"/":t,i=e.url;return{withBaseUrl:function(e,t){return function(e,t,n,r){var i=void 0===r?{}:r,c=i.forcePrependBaseUrl,a=void 0!==c&&c,u=i.absolute,l=void 0!==u&&u;if(!n)return n;if(n.startsWith("#"))return n;if((0,o.b)(n))return n;if(a)return t+n;var s=n.startsWith(t)?n:t+n.replace(/^\//,"");return l?e+s:s}(i,n,e,t)}}}function c(e,t){return void 0===t&&(t={}),(0,i().withBaseUrl)(e,t)}},7851:function(e,t,n){"use strict";n.d(t,{g:function(){return u},Z:function(){return l}});var r=n(2122),o=n(8173),i=n(7294),c="container_1JGz",a=n(2823);function u(e,t,n){for(var r,c=e||[],a=(0,o.Z)(i.Children.toArray(t));!(r=a()).done;){var u,l=r.value;"InventorySlot"==(null==l||null==(u=l.props)?void 0:u.mdxType)&&c.push(Object.assign({},l.props))}if(n)for(var s=c.length;s<n;s++)c.push({type:null});return c}function l(e){var t=e.items,n=e.children,o=e.width,l=e.interactable,s=e.onChange,p=u(t,n,o),f=(0,i.useState)(-1),m=f[0],y=f[1];return i.createElement("div",{className:c},p.map((function(e,t){var n=l&&null!==e.type;return n&&(e.type=l&&m==t?"selected":"normal"),i.createElement(a.Z,(0,r.Z)({key:t},e,{onClick:n?function(){return y(n=(e=t)==m?-1:e),void(s&&s(n));var e,n}:void 0}))})))}},2823:function(e,t,n){"use strict";n.d(t,{Z:function(){return p}});var r=n(7294),o=n(4996),i="container_NKD0",c="slot_PnA2",a="hoverslot_1P8J",u="sprite_26gF",l="tooltip_o3oT",s="count_2_VC";function p(e){var t=e.sprite,n=e.tooltip,p=e.tooltipColor,f=e.count,m=e.countColor,y=e.type,v=e.onClick,d=!!y;return y=y||"normal",r.createElement("div",{className:i,onClick:v,style:{cursor:d?"pointer":"inherit"}},d&&r.createElement("img",{key:"hoverslot",className:a,src:(0,o.Z)("/img/components/InventorySlot/"+y+"Hover.png")}),r.createElement("img",{key:"slot",className:c,src:(0,o.Z)("/img/components/InventorySlot/"+y+".png")}),t&&r.createElement("img",{key:"sprite",className:u,src:t}),n&&r.createElement("span",{key:"tooltip",className:l},r.createElement("span",{style:{color:p||"#FFED00"}},n)),f&&r.createElement("span",{key:"count",className:s},r.createElement("span",{style:{color:m||"#FFFFFF"}},f)))}},2932:function(e,t,n){"use strict";n.d(t,{Z:function(){return l}});var r=n(2122),o=n(9756),i=n(7294),c="toolbar_auQ6",a=n(7851),u=["items","children","width"];function l(e){for(var t=e.items,n=e.children,l=e.width,s=(0,o.Z)(e,u),p=(0,a.g)(t,n,l),f=0;f<p.length;f++)p[f].tooltip=(f+1).toString();return i.createElement("div",{className:c},i.createElement(a.Z,(0,r.Z)({items:p},s)))}}}]);