(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[434],{8173:function(e,t,n){"use strict";function r(e,t){(null==t||t>e.length)&&(t=e.length);for(var n=0,r=new Array(t);n<t;n++)r[n]=e[n];return r}function o(e,t){var n="undefined"!=typeof Symbol&&e[Symbol.iterator]||e["@@iterator"];if(n)return(n=n.call(e)).next.bind(n);if(Array.isArray(e)||(n=function(e,t){if(e){if("string"==typeof e)return r(e,t);var n=Object.prototype.toString.call(e).slice(8,-1);return"Object"===n&&e.constructor&&(n=e.constructor.name),"Map"===n||"Set"===n?Array.from(e):"Arguments"===n||/^(?:Ui|I)nt(?:8|16|32)(?:Clamped)?Array$/.test(n)?r(e,t):void 0}}(e))||t&&e&&"number"==typeof e.length){n&&(e=n);var o=0;return function(){return o>=e.length?{done:!0}:{done:!1,value:e[o++]}}}throw new TypeError("Invalid attempt to iterate non-iterable instance.\nIn order to be iterable, non-array objects must have a [Symbol.iterator]() method.")}n.d(t,{Z:function(){return o}})},3905:function(e,t,n){"use strict";n.d(t,{Zo:function(){return u},kt:function(){return d}});var r=n(7294);function o(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function i(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(e);t&&(r=r.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,r)}return n}function a(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?i(Object(n),!0).forEach((function(t){o(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):i(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function l(e,t){if(null==e)return{};var n,r,o=function(e,t){if(null==e)return{};var n,r,o={},i=Object.keys(e);for(r=0;r<i.length;r++)n=i[r],t.indexOf(n)>=0||(o[n]=e[n]);return o}(e,t);if(Object.getOwnPropertySymbols){var i=Object.getOwnPropertySymbols(e);for(r=0;r<i.length;r++)n=i[r],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(o[n]=e[n])}return o}var c=r.createContext({}),s=function(e){var t=r.useContext(c),n=t;return e&&(n="function"==typeof e?e(t):a(a({},t),e)),n},u=function(e){var t=s(e.components);return r.createElement(c.Provider,{value:t},e.children)},p={inlineCode:"code",wrapper:function(e){var t=e.children;return r.createElement(r.Fragment,{},t)}},m=r.forwardRef((function(e,t){var n=e.components,o=e.mdxType,i=e.originalType,c=e.parentName,u=l(e,["components","mdxType","originalType","parentName"]),m=s(n),d=o,f=m["".concat(c,".").concat(d)]||m[d]||p[d]||i;return n?r.createElement(f,a(a({ref:t},u),{},{components:n})):r.createElement(f,a({ref:t},u))}));function d(e,t){var n=arguments,o=t&&t.mdxType;if("string"==typeof e||o){var i=n.length,a=new Array(i);a[0]=m;var l={};for(var c in t)hasOwnProperty.call(t,c)&&(l[c]=t[c]);l.originalType=e,l.mdxType="string"==typeof e?e:o,a[1]=l;for(var s=2;s<i;s++)a[s]=n[s];return r.createElement.apply(null,a)}return r.createElement.apply(null,n)}m.displayName="MDXCreateElement"},3919:function(e,t,n){"use strict";function r(e){return!0===/^(\w*:|\/\/)/.test(e)}function o(e){return void 0!==e&&!r(e)}n.d(t,{b:function(){return r},Z:function(){return o}})},4996:function(e,t,n){"use strict";n.d(t,{C:function(){return i},Z:function(){return a}});var r=n(2263),o=n(3919);function i(){var e=(0,r.Z)().siteConfig,t=(e=void 0===e?{}:e).baseUrl,n=void 0===t?"/":t,i=e.url;return{withBaseUrl:function(e,t){return function(e,t,n,r){var i=void 0===r?{}:r,a=i.forcePrependBaseUrl,l=void 0!==a&&a,c=i.absolute,s=void 0!==c&&c;if(!n)return n;if(n.startsWith("#"))return n;if((0,o.b)(n))return n;if(l)return t+n;var u=n.startsWith(t)?n:t+n.replace(/^\//,"");return s?e+u:u}(i,n,e,t)}}}function a(e,t){return void 0===t&&(t={}),(0,i().withBaseUrl)(e,t)}},6902:function(e,t,n){"use strict";n.d(t,{Z:function(){return m}});var r=n(7294),o="browserWindow_1hK2",i="browserWindowHeader_3KQg",a="buttons_30GN",l="browserWindowAddressBar_3JC2",c="dot_1FQH",s="browserWindowMenuIcon_2SC9",u="bar_2gUh",p="browserWindowBody_2GyV";function m(e){var t=e.children,n=e.minHeight,m=e.url;return r.createElement("div",null,r.createElement("div",{className:o,style:{minHeight:n}},r.createElement("div",{className:i},r.createElement("div",{className:a},r.createElement("span",{className:c,style:{background:"#f25f58"}}),r.createElement("span",{className:c,style:{background:"#fbbe3c"}}),r.createElement("span",{className:c,style:{background:"#58cb42"}})),r.createElement("div",{className:l},m),r.createElement("div",{className:s},r.createElement("div",null,r.createElement("span",{className:u}),r.createElement("span",{className:u}),r.createElement("span",{className:u})))),r.createElement("div",{className:p},t)),r.createElement("br",null))}},9937:function(e,t,n){"use strict";n.d(t,{Z:function(){return u}});var r=n(2122),o=n(8173),i=n(7294),a="container_1tQ_",l="row_2Asb",c=n(2823),s=n(7851);function u(e){var t=e.items,n=e.children,u=e.width,p=e.height,m=e.interactable,d=e.onChange,f=function(e,t,n,r){var a=[],l=[];if(e)for(var c,u=(0,o.Z)(e);!(c=u()).done;){var p=c.value;if(Array.isArray(p)){if(l.length>0){if(n)for(var m=l.length;m<n;m++)l.push({type:null});a.push(l),l=[]}var d=[].concat(p);if(n)for(var f=d.length;f<n;f++)d.push({type:null});a.push(d)}else null!=p&&!1!==p&&!0!==p&&(l.push(p),l.length===n&&(a.push(l),l=[]))}if(l.length>0){if(n)for(var v=l.length;v<n;v++)l.push({type:null});a.push(l),l=[]}for(var y,h=(0,o.Z)(i.Children.toArray(t));!(y=h()).done;){var g,b=y.value,k=null==b||null==(g=b.props)?void 0:g.mdxType;if("InventoryRow"==k){if(l.length>0){if(n)for(var w=l.length;w<n;w++)l.push({type:null});a.push(l),l=[]}var I=(0,s.g)(b.props.items,b.props.children,b.props.width||n);a.push(I)}else"InventorySlot"==k&&(l.push(Object.assign({},b.props)),l.length===n&&(a.push(l),l=[]))}if(l.length>0){if(n)for(var Z=l.length;Z<n;Z++)l.push({type:null});a.push(l),l=[]}if(r)for(var E=a.length;E<r;E++){var x=[];if(n)for(var T=0;T<n;T++)x.push({type:null});else x.push({type:null});a.push(x)}return a}(t,n,u,p),v=(0,i.useState)(-1),y=v[0],h=v[1],g=0;return i.createElement("div",{className:a},f.map((function(e,t){return i.createElement("div",{className:l},e.map((function(e,n){var o=g++,a=m&&null!==e.type;return a&&(e.type=m&&y==o?"selected":"normal"),i.createElement(c.Z,(0,r.Z)({key:o},e,{onClick:a?function(){return function(e,t,n){h(e==y?-1:e),d&&d({index:e,row:t,column:n})}(o,t,n)}:void 0}))})))})))}},7851:function(e,t,n){"use strict";n.d(t,{g:function(){return c},Z:function(){return s}});var r=n(2122),o=n(8173),i=n(7294),a="container_1JGz",l=n(2823);function c(e,t,n){for(var r,a=e||[],l=(0,o.Z)(i.Children.toArray(t));!(r=l()).done;){var c,s=r.value;"InventorySlot"==(null==s||null==(c=s.props)?void 0:c.mdxType)&&a.push(Object.assign({},s.props))}if(n)for(var u=a.length;u<n;u++)a.push({type:null});return a}function s(e){var t=e.items,n=e.children,o=e.width,s=e.interactable,u=e.onChange,p=c(t,n,o),m=(0,i.useState)(-1),d=m[0],f=m[1];return i.createElement("div",{className:a},p.map((function(e,t){var n=s&&null!==e.type;return n&&(e.type=s&&d==t?"selected":"normal"),i.createElement(l.Z,(0,r.Z)({key:t},e,{onClick:n?function(){return f(n=(e=t)==d?-1:e),void(u&&u(n));var e,n}:void 0}))})))}},2823:function(e,t,n){"use strict";n.d(t,{Z:function(){return p}});var r=n(7294),o=n(4996),i="container_NKD0",a="slot_PnA2",l="hoverslot_1P8J",c="sprite_26gF",s="tooltip_o3oT",u="count_2_VC";function p(e){var t=e.sprite,n=e.tooltip,p=e.tooltipColor,m=e.count,d=e.countColor,f=e.type,v=e.onClick,y=!!f;return f=f||"normal",r.createElement("div",{className:i,onClick:v,style:{cursor:y?"pointer":"inherit"}},y&&r.createElement("img",{key:"hoverslot",className:l,src:(0,o.Z)("/img/components/InventorySlot/"+f+"Hover.png")}),r.createElement("img",{key:"slot",className:a,src:(0,o.Z)("/img/components/InventorySlot/"+f+".png")}),t&&r.createElement("img",{key:"sprite",className:c,src:t}),n&&r.createElement("span",{key:"tooltip",className:s},r.createElement("span",{style:{color:p||"#FFED00"}},n)),m&&r.createElement("span",{key:"count",className:u},r.createElement("span",{style:{color:d||"#FFFFFF"}},m)))}},2932:function(e,t,n){"use strict";n.d(t,{Z:function(){return s}});var r=n(2122),o=n(9756),i=n(7294),a="toolbar_auQ6",l=n(7851),c=["items","children","width"];function s(e){for(var t=e.items,n=e.children,s=e.width,u=(0,o.Z)(e,c),p=(0,l.g)(t,n,s),m=0;m<p.length;m++)p[m].tooltip=(m+1).toString();return i.createElement("div",{className:a},i.createElement(l.Z,(0,r.Z)({items:p},u)))}},3679:function(e,t,n){"use strict";n.r(t),n.d(t,{frontMatter:function(){return m},contentTitle:function(){return d},metadata:function(){return f},toc:function(){return v},default:function(){return h}});var r=n(2122),o=n(9756),i=(n(7294),n(3905)),a=n(4996),l=(n(6902),n(2823)),c=n(7851),s=n(2932),u=n(9937),p=["components"],m={},d="Components Index",f={unversionedId:"components/index",id:"components/index",isDocsHomePage:!1,title:"Components Index",description:"InventorySlot",source:"@site/docs/components/index.mdx",sourceDirName:"components",slug:"/components/index",permalink:"/RogueLibs/docs/components/index",editUrl:"https://github.com/Abbysssal/RogueLibs/edit/master/website/docs/components/index.mdx",version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"Hook Factories",permalink:"/RogueLibs/docs/dev/hooks/hook-factories"},next:{title:"InventorySlot",permalink:"/RogueLibs/docs/components/inventoryslot"}},v=[{value:"InventorySlot",id:"inventoryslot",children:[]},{value:"InventoryRow",id:"inventoryrow",children:[]},{value:"InventoryToolbar",id:"inventorytoolbar",children:[]},{value:"InventoryGrid",id:"inventorygrid",children:[]}],y={toc:v};function h(e){var t=e.components,n=(0,o.Z)(e,p);return(0,i.kt)("wrapper",(0,r.Z)({},y,n,{components:t,mdxType:"MDXLayout"}),(0,i.kt)("h1",{id:"components-index"},"Components Index"),(0,i.kt)("h3",{id:"inventoryslot"},(0,i.kt)("a",{parentName:"h3",href:"./inventoryslot"},(0,i.kt)("inlineCode",{parentName:"a"},"InventorySlot"))),(0,i.kt)(l.Z,{sprite:(0,a.Z)("/img/TestItem.png"),count:13,tooltip:"$70",type:"normal",mdxType:"InventorySlot"}),(0,i.kt)("h3",{id:"inventoryrow"},(0,i.kt)("a",{parentName:"h3",href:"./inventoryrow"},(0,i.kt)("inlineCode",{parentName:"a"},"InventoryRow"))),(0,i.kt)(c.Z,{width:5,interactable:!0,mdxType:"InventoryRow"},(0,i.kt)(l.Z,{sprite:(0,a.Z)("/img/TestItem.png"),tooltip:"$70",mdxType:"InventorySlot"}),(0,i.kt)(l.Z,{sprite:(0,a.Z)("/img/TestItem.png"),count:13,mdxType:"InventorySlot"}),(0,i.kt)(l.Z,{sprite:(0,a.Z)("/img/TestItem.png"),count:77,countColor:"#55BB11",mdxType:"InventorySlot"})),(0,i.kt)("h3",{id:"inventorytoolbar"},(0,i.kt)("a",{parentName:"h3",href:"./inventorytoolbar"},(0,i.kt)("inlineCode",{parentName:"a"},"InventoryToolbar"))),(0,i.kt)(s.Z,{width:5,interactable:!0,mdxType:"InventoryToolbar"},(0,i.kt)(l.Z,{sprite:(0,a.Z)("/img/TestItem.png"),tooltip:"$70",mdxType:"InventorySlot"}),(0,i.kt)(l.Z,{sprite:(0,a.Z)("/img/TestItem.png"),count:13,mdxType:"InventorySlot"}),(0,i.kt)(l.Z,{sprite:(0,a.Z)("/img/TestItem.png"),count:77,countColor:"#55BB11",mdxType:"InventorySlot"})),(0,i.kt)("h3",{id:"inventorygrid"},(0,i.kt)("a",{parentName:"h3",href:"./inventorygrid"},(0,i.kt)("inlineCode",{parentName:"a"},"InventoryGrid"))),(0,i.kt)(u.Z,{width:5,height:4,interactable:!0,mdxType:"InventoryGrid"},(0,i.kt)(l.Z,{sprite:(0,a.Z)("/img/TestItem.png"),tooltip:"$70",mdxType:"InventorySlot"}),(0,i.kt)(c.Z,{mdxType:"InventoryRow"},(0,i.kt)(l.Z,{sprite:(0,a.Z)("/img/TestItem.png"),count:13,mdxType:"InventorySlot"}),(0,i.kt)(l.Z,{sprite:(0,a.Z)("/img/TestItem.png"),count:77,countColor:"#55BB11",mdxType:"InventorySlot"}))))}h.isMDXComponent=!0}}]);