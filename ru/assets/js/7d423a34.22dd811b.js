"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[1191],{3905:function(e,t,n){n.d(t,{Zo:function(){return p},kt:function(){return u}});var o=n(7294);function r(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function l(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var o=Object.getOwnPropertySymbols(e);t&&(o=o.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,o)}return n}function i(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?l(Object(n),!0).forEach((function(t){r(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):l(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function a(e,t){if(null==e)return{};var n,o,r=function(e,t){if(null==e)return{};var n,o,r={},l=Object.keys(e);for(o=0;o<l.length;o++)n=l[o],t.indexOf(n)>=0||(r[n]=e[n]);return r}(e,t);if(Object.getOwnPropertySymbols){var l=Object.getOwnPropertySymbols(e);for(o=0;o<l.length;o++)n=l[o],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(r[n]=e[n])}return r}var c=o.createContext({}),s=function(e){var t=o.useContext(c),n=t;return e&&(n="function"==typeof e?e(t):i(i({},t),e)),n},p=function(e){var t=s(e.components);return o.createElement(c.Provider,{value:t},e.children)},m={inlineCode:"code",wrapper:function(e){var t=e.children;return o.createElement(o.Fragment,{},t)}},d=o.forwardRef((function(e,t){var n=e.components,r=e.mdxType,l=e.originalType,c=e.parentName,p=a(e,["components","mdxType","originalType","parentName"]),d=s(n),u=r,v=d["".concat(c,".").concat(u)]||d[u]||m[u]||l;return n?o.createElement(v,i(i({ref:t},p),{},{components:n})):o.createElement(v,i({ref:t},p))}));function u(e,t){var n=arguments,r=t&&t.mdxType;if("string"==typeof e||r){var l=n.length,i=new Array(l);i[0]=d;var a={};for(var c in t)hasOwnProperty.call(t,c)&&(a[c]=t[c]);a.originalType=e,a.mdxType="string"==typeof e?e:r,i[1]=a;for(var s=2;s<l;s++)i[s]=n[s];return o.createElement.apply(null,i)}return o.createElement.apply(null,n)}d.displayName="MDXCreateElement"},338:function(e,t,n){n.d(t,{Z:function(){return d}});var o=n(7294),r="browserWindow_jKcn",l="browserWindowHeader_RTeS",i="buttons_Ko+m",a="browserWindowAddressBar_pbPN",c="dot_GdWh",s="browserWindowMenuIcon_k0Eb",p="bar_MHJT",m="browserWindowBody_MhPA";function d(e){var t=e.children,n=e.url;return o.createElement("div",null,o.createElement("div",{className:r},o.createElement("div",{className:l},o.createElement("div",{className:i},o.createElement("span",{className:c,style:{background:"#f25f58"}}),o.createElement("span",{className:c,style:{background:"#fbbe3c"}}),o.createElement("span",{className:c,style:{background:"#58cb42"}})),o.createElement("div",{className:a},n),o.createElement("div",{className:s},o.createElement("div",null,o.createElement("span",{className:p}),o.createElement("span",{className:p}),o.createElement("span",{className:p})))),o.createElement("div",{className:m},t)),o.createElement("br",null))}},5880:function(e,t,n){n.d(t,{Z:function(){return i}});var o=n(7294),r=n(6010),l={container:"container_dbG1",cursorLocked:"cursorLocked_IxBp",normal:"normal_t5PJ",hoverable:"hoverable_DzOz",selected:"selected_ONUJ",locked:"locked_yrQa",sprite:"sprite_01VY",tooltip:"tooltip_vYS5",count:"count_m5JE"};function i(e){var t=e.sprite,n=e.tooltip,i=e.tooltipColor,a=e.count,c=e.countColor,s=e.hoverable,p=e.cantClick,m=e.type,d=void 0===m?"normal":m,u=e.onClick;return o.createElement("div",{onClick:u,className:(0,r.Z)(l.container,p&&l.cursorLocked,d&&l[d],s&&l.hoverable)},t&&o.createElement("img",{key:"sprite",className:l.sprite,src:t}),n&&o.createElement("span",{key:"tooltip",className:l.tooltip,style:{color:i||"#FFED00"}},n),a&&o.createElement("span",{key:"count",className:l.count,style:{color:c||"#FFFFFF"}},a))}},8405:function(e,t,n){n.r(t),n.d(t,{frontMatter:function(){return p},contentTitle:function(){return m},metadata:function(){return d},toc:function(){return u},default:function(){return y}});var o=n(7462),r=n(3366),l=(n(7294),n(3905)),i=n(4996),a=n(338),c=n(5880),s=["components"],p={},m="InventorySlot",d={unversionedId:"site/components/InventorySlot",id:"site/components/InventorySlot",title:"InventorySlot",description:"Props",source:"@site/docs/site/components/InventorySlot.mdx",sourceDirName:"site/components",slug:"/site/components/InventorySlot",permalink:"/RogueLibs/ru/docs/site/components/InventorySlot",editUrl:"https://github.com/Abbysssal/RogueLibs/edit/main/website/docs/site/components/InventorySlot.mdx",tags:[],version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"Components Index",permalink:"/RogueLibs/ru/docs/site/"},next:{title:"InventoryRow",permalink:"/RogueLibs/ru/docs/site/components/InventoryRow"}},u=[{value:"Props",id:"props",children:[],level:2},{value:"Typical usages",id:"typical-usages",children:[],level:2},{value:"With colors",id:"with-colors",children:[],level:2},{value:"Slot types",id:"slot-types",children:[],level:2},{value:"onClick event",id:"onclick-event",children:[],level:2},{value:"Hoverable",id:"hoverable",children:[],level:2},{value:"Cant click",id:"cantclick",children:[],level:2}],v={toc:u};function y(e){var t=e.components,n=(0,r.Z)(e,s);return(0,l.kt)("wrapper",(0,o.Z)({},v,n,{components:t,mdxType:"MDXLayout"}),(0,l.kt)("h1",{id:"inventoryslot"},(0,l.kt)("inlineCode",{parentName:"h1"},"InventorySlot")),(0,l.kt)("h2",{id:"props"},"Props"),(0,l.kt)("pre",null,(0,l.kt)("code",{parentName:"pre",className:"language-ts"},'export type Props = {\n  sprite?: string,           // sprite of the item\n  tooltip?: string | number, // tooltip text\n  tooltipColor?: string,     // tooltip text color (default: #FFED00)\n  count?: string | number,   // count text\n  countColor?: string,       // count text color (default: #FFFFFF)\n\n  type?: "normal" | "selected" | "locked" | null, // type of the slot\n  onClick?: () => void, // click event handler\n  hoverable?: boolean, // determines whether to change the slot image, when hovered over\n  cantClick?: boolean, // determines whether the slot cannot be clicked/interacted with\n  \n  uid?: string, // Unique Identifier (see InventoryRow and InventoryGrid for more info)\n}\n')),(0,l.kt)("h2",{id:"typical-usages"},"Typical usages"),(0,l.kt)("pre",null,(0,l.kt)("code",{parentName:"pre",className:"language-jsx"},'<InventorySlot sprite={useBaseUrl("/img/Generic.png")}/>\n<InventorySlot sprite={useBaseUrl("/img/Generic2.png")} count={25}/>\n<InventorySlot sprite={useBaseUrl("/img/Generic3.png")} count={25} tooltip="$13"/>\n')),(0,l.kt)(a.Z,{mdxType:"BrowserWindow"},(0,l.kt)(c.Z,{sprite:(0,i.Z)("/img/Generic.png"),mdxType:"InventorySlot"}),(0,l.kt)(c.Z,{sprite:(0,i.Z)("/img/Generic2.png"),count:25,mdxType:"InventorySlot"}),(0,l.kt)(c.Z,{sprite:(0,i.Z)("/img/Generic3.png"),count:25,tooltip:"$13",mdxType:"InventorySlot"})),(0,l.kt)("h2",{id:"with-colors"},"With colors"),(0,l.kt)("pre",null,(0,l.kt)("code",{parentName:"pre",className:"language-jsx"},'<InventorySlot sprite={useBaseUrl("/img/Generic5.png")}\n  count={25} countColor="#552299"\n  tooltip="$13" tooltipColor="#9922BB77"/>\n')),(0,l.kt)(a.Z,{mdxType:"BrowserWindow"},(0,l.kt)(c.Z,{sprite:(0,i.Z)("/img/Generic5.png"),count:25,countColor:"#BB2211",tooltip:"$13",tooltipColor:"#FFFFFF77",mdxType:"InventorySlot"})),(0,l.kt)("h2",{id:"slot-types"},"Slot types"),(0,l.kt)("pre",null,(0,l.kt)("code",{parentName:"pre",className:"language-jsx"},'<InventorySlot type="normal"/>\n<InventorySlot type="selected"/>\n<InventorySlot type="locked"/>\n<InventorySlot type={null}/>\n<br/>\n<InventorySlot type="normal" sprite={useBaseUrl("/img/Generic.png")}/>\n<InventorySlot type="selected" sprite={useBaseUrl("/img/Generic2.png")}/>\n<InventorySlot type="locked" sprite={useBaseUrl("/img/Generic3.png")}/>\n<InventorySlot type={null} sprite={useBaseUrl("/img/Generic4.png")}/>\n')),(0,l.kt)(a.Z,{mdxType:"BrowserWindow"},(0,l.kt)(c.Z,{type:"normal",mdxType:"InventorySlot"}),(0,l.kt)(c.Z,{type:"selected",mdxType:"InventorySlot"}),(0,l.kt)(c.Z,{type:"locked",mdxType:"InventorySlot"}),(0,l.kt)(c.Z,{type:null,mdxType:"InventorySlot"}),(0,l.kt)("br",null),(0,l.kt)(c.Z,{type:"normal",sprite:(0,i.Z)("/img/Generic.png"),mdxType:"InventorySlot"}),(0,l.kt)(c.Z,{type:"selected",sprite:(0,i.Z)("/img/Generic2.png"),mdxType:"InventorySlot"}),(0,l.kt)(c.Z,{type:"locked",sprite:(0,i.Z)("/img/Generic3.png"),mdxType:"InventorySlot"}),(0,l.kt)(c.Z,{type:null,sprite:(0,i.Z)("/img/Generic4.png"),mdxType:"InventorySlot"})),(0,l.kt)("h2",{id:"onclick-event"},"onClick event"),(0,l.kt)("pre",null,(0,l.kt)("code",{parentName:"pre",className:"language-jsx"},'<InventorySlot sprite={useBaseUrl("/img/Generic4.png")} hoverable={true} count={25} tooltip="$13"\n  onClick={() => console.log("Just clicked on the inventory slot!")}/>\n')),(0,l.kt)(a.Z,{mdxType:"BrowserWindow"},(0,l.kt)(c.Z,{sprite:(0,i.Z)("/img/Generic4.png"),hoverable:!0,count:25,tooltip:"$13",onClick:function(){return console.log("Just clicked on the inventory slot!")},mdxType:"InventorySlot"})),(0,l.kt)("div",{className:"admonition admonition-note alert alert--secondary"},(0,l.kt)("div",{parentName:"div",className:"admonition-heading"},(0,l.kt)("h5",{parentName:"div"},(0,l.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,l.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,l.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.3 5.69a.942.942 0 0 1-.28-.7c0-.28.09-.52.28-.7.19-.18.42-.28.7-.28.28 0 .52.09.7.28.18.19.28.42.28.7 0 .28-.09.52-.28.7a1 1 0 0 1-.7.3c-.28 0-.52-.11-.7-.3zM8 7.99c-.02-.25-.11-.48-.31-.69-.2-.19-.42-.3-.69-.31H6c-.27.02-.48.13-.69.31-.2.2-.3.44-.31.69h1v3c.02.27.11.5.31.69.2.2.42.31.69.31h1c.27 0 .48-.11.69-.31.2-.19.3-.42.31-.69H8V7.98v.01zM7 2.3c-3.14 0-5.7 2.54-5.7 5.68 0 3.14 2.56 5.7 5.7 5.7s5.7-2.55 5.7-5.7c0-3.15-2.56-5.69-5.7-5.69v.01zM7 .98c3.86 0 7 3.14 7 7s-3.14 7-7 7-7-3.12-7-7 3.14-7 7-7z"}))),"note")),(0,l.kt)("div",{parentName:"div",className:"admonition-content"},(0,l.kt)("p",{parentName:"div"},"See the output in ",(0,l.kt)("strong",{parentName:"p"},"Developer Tools > Console"),"."))),(0,l.kt)("h2",{id:"hoverable"},"Hoverable"),(0,l.kt)("div",{className:"admonition admonition-info alert alert--info"},(0,l.kt)("div",{parentName:"div",className:"admonition-heading"},(0,l.kt)("h5",{parentName:"div"},(0,l.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,l.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,l.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M7 2.3c3.14 0 5.7 2.56 5.7 5.7s-2.56 5.7-5.7 5.7A5.71 5.71 0 0 1 1.3 8c0-3.14 2.56-5.7 5.7-5.7zM7 1C3.14 1 0 4.14 0 8s3.14 7 7 7 7-3.14 7-7-3.14-7-7-7zm1 3H6v5h2V4zm0 6H6v2h2v-2z"}))),"info")),(0,l.kt)("div",{parentName:"div",className:"admonition-content"},(0,l.kt)("p",{parentName:"div"},"It's usually used inside other components to make them look nicer, but you can use it yourself too."))),(0,l.kt)("pre",null,(0,l.kt)("code",{parentName:"pre",className:"language-jsx"},'<InventorySlot hoverable={true} type="normal"/>\n<InventorySlot hoverable={true} type="selected"/>\n<InventorySlot hoverable={true} type="locked"/>\n<InventorySlot hoverable={true} type={null}/>\n<br/>\n<InventorySlot hoverable={true} type="normal" sprite={useBaseUrl("/img/Generic.png")}/>\n<InventorySlot hoverable={true} type="selected" sprite={useBaseUrl("/img/Generic2.png")}/>\n<InventorySlot hoverable={true} type="locked" sprite={useBaseUrl("/img/Generic3.png")}/>\n<InventorySlot hoverable={true} type={null} sprite={useBaseUrl("/img/Generic4.png")}/>\n')),(0,l.kt)(a.Z,{mdxType:"BrowserWindow"},(0,l.kt)(c.Z,{hoverable:!0,type:"normal",mdxType:"InventorySlot"}),(0,l.kt)(c.Z,{hoverable:!0,type:"selected",mdxType:"InventorySlot"}),(0,l.kt)(c.Z,{hoverable:!0,type:"locked",mdxType:"InventorySlot"}),(0,l.kt)(c.Z,{hoverable:!0,type:null,mdxType:"InventorySlot"}),(0,l.kt)("br",null),(0,l.kt)(c.Z,{hoverable:!0,type:"normal",sprite:(0,i.Z)("/img/Generic.png"),mdxType:"InventorySlot"}),(0,l.kt)(c.Z,{hoverable:!0,type:"selected",sprite:(0,i.Z)("/img/Generic2.png"),mdxType:"InventorySlot"}),(0,l.kt)(c.Z,{hoverable:!0,type:"locked",sprite:(0,i.Z)("/img/Generic3.png"),mdxType:"InventorySlot"}),(0,l.kt)(c.Z,{hoverable:!0,type:null,sprite:(0,i.Z)("/img/Generic4.png"),mdxType:"InventorySlot"})),(0,l.kt)("h2",{id:"cantclick"},"Cant click"),(0,l.kt)("div",{className:"admonition admonition-info alert alert--info"},(0,l.kt)("div",{parentName:"div",className:"admonition-heading"},(0,l.kt)("h5",{parentName:"div"},(0,l.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,l.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,l.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M7 2.3c3.14 0 5.7 2.56 5.7 5.7s-2.56 5.7-5.7 5.7A5.71 5.71 0 0 1 1.3 8c0-3.14 2.56-5.7 5.7-5.7zM7 1C3.14 1 0 4.14 0 8s3.14 7 7 7 7-3.14 7-7-3.14-7-7-7zm1 3H6v5h2V4zm0 6H6v2h2v-2z"}))),"info")),(0,l.kt)("div",{parentName:"div",className:"admonition-content"},(0,l.kt)("p",{parentName:"div"},"It's usually used inside other components to make them look nicer, but you can use it yourself too."))),(0,l.kt)("pre",null,(0,l.kt)("code",{parentName:"pre",className:"language-jsx"},'<InventorySlot hoverable={true} type="selected"/>\n<InventorySlot hoverable={true} cantClick={true} type="selected"/>\n<InventorySlot hoverable={true} type="locked"/>\n<InventorySlot hoverable={true} cantClick={true} type="locked"/>\n<br/>\n<InventorySlot hoverable={true} type="selected" sprite={useBaseUrl("/img/Generic.png")}/>\n<InventorySlot hoverable={true} cantClick={true} type="selected" sprite={useBaseUrl("/img/Generic2.png")}/>\n<InventorySlot hoverable={true} type="locked" sprite={useBaseUrl("/img/Generic3.png")}/>\n<InventorySlot hoverable={true} cantClick={true} type="locked" sprite={useBaseUrl("/img/Generic4.png")}/>\n')),(0,l.kt)(a.Z,{mdxType:"BrowserWindow"},(0,l.kt)(c.Z,{hoverable:!0,type:"selected",mdxType:"InventorySlot"}),(0,l.kt)(c.Z,{hoverable:!0,cantClick:!0,type:"selected",mdxType:"InventorySlot"}),(0,l.kt)(c.Z,{hoverable:!0,type:"locked",mdxType:"InventorySlot"}),(0,l.kt)(c.Z,{hoverable:!0,cantClick:!0,type:"locked",mdxType:"InventorySlot"}),(0,l.kt)("br",null),(0,l.kt)(c.Z,{hoverable:!0,type:"selected",sprite:(0,i.Z)("/img/Generic.png"),mdxType:"InventorySlot"}),(0,l.kt)(c.Z,{hoverable:!0,cantClick:!0,type:"selected",sprite:(0,i.Z)("/img/Generic2.png"),mdxType:"InventorySlot"}),(0,l.kt)(c.Z,{hoverable:!0,type:"locked",sprite:(0,i.Z)("/img/Generic3.png"),mdxType:"InventorySlot"}),(0,l.kt)(c.Z,{hoverable:!0,cantClick:!0,type:"locked",sprite:(0,i.Z)("/img/Generic4.png"),mdxType:"InventorySlot"})))}y.isMDXComponent=!0}}]);