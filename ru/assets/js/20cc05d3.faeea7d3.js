"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[1364],{3905:function(e,t,n){n.d(t,{Zo:function(){return u},kt:function(){return m}});var o=n(7294);function r(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function i(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var o=Object.getOwnPropertySymbols(e);t&&(o=o.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,o)}return n}function a(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?i(Object(n),!0).forEach((function(t){r(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):i(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function l(e,t){if(null==e)return{};var n,o,r=function(e,t){if(null==e)return{};var n,o,r={},i=Object.keys(e);for(o=0;o<i.length;o++)n=i[o],t.indexOf(n)>=0||(r[n]=e[n]);return r}(e,t);if(Object.getOwnPropertySymbols){var i=Object.getOwnPropertySymbols(e);for(o=0;o<i.length;o++)n=i[o],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(r[n]=e[n])}return r}var s=o.createContext({}),c=function(e){var t=o.useContext(s),n=t;return e&&(n="function"==typeof e?e(t):a(a({},t),e)),n},u=function(e){var t=c(e.components);return o.createElement(s.Provider,{value:t},e.children)},p={inlineCode:"code",wrapper:function(e){var t=e.children;return o.createElement(o.Fragment,{},t)}},d=o.forwardRef((function(e,t){var n=e.components,r=e.mdxType,i=e.originalType,s=e.parentName,u=l(e,["components","mdxType","originalType","parentName"]),d=c(n),m=r,v=d["".concat(s,".").concat(m)]||d[m]||p[m]||i;return n?o.createElement(v,a(a({ref:t},u),{},{components:n})):o.createElement(v,a({ref:t},u))}));function m(e,t){var n=arguments,r=t&&t.mdxType;if("string"==typeof e||r){var i=n.length,a=new Array(i);a[0]=d;var l={};for(var s in t)hasOwnProperty.call(t,s)&&(l[s]=t[s]);l.originalType=e,l.mdxType="string"==typeof e?e:r,a[1]=l;for(var c=2;c<i;c++)a[c]=n[c];return o.createElement.apply(null,a)}return o.createElement.apply(null,n)}d.displayName="MDXCreateElement"},338:function(e,t,n){n.d(t,{Z:function(){return d}});var o=n(7294),r="browserWindow_jKcn",i="browserWindowHeader_RTeS",a="buttons_Ko+m",l="browserWindowAddressBar_pbPN",s="dot_GdWh",c="browserWindowMenuIcon_k0Eb",u="bar_MHJT",p="browserWindowBody_MhPA";function d(e){var t=e.children,n=e.url;return o.createElement("div",null,o.createElement("div",{className:r},o.createElement("div",{className:i},o.createElement("div",{className:a},o.createElement("span",{className:s,style:{background:"#f25f58"}}),o.createElement("span",{className:s,style:{background:"#fbbe3c"}}),o.createElement("span",{className:s,style:{background:"#58cb42"}})),o.createElement("div",{className:l},n),o.createElement("div",{className:c},o.createElement("div",null,o.createElement("span",{className:u}),o.createElement("span",{className:u}),o.createElement("span",{className:u})))),o.createElement("div",{className:p},t)),o.createElement("br",null))}},296:function(e,t,n){n.d(t,{Z:function(){return u}});var o=n(3366),r=n(7855),i=n(7294),a=n(7532),l=n(6095),s="container_0LFt",c=["items","children","height","width","onClick","interactive"];function u(e){for(var t,n=e.items,u=e.children,p=e.height,d=e.width,m=e.onClick,v=e.interactive,g=(0,o.Z)(e,c),y=function(e,t,n,o){var a=[],s=[],c=function(e){if(o)for(var t=s.length;t<o;t++)s.push({hoverable:!1});u(e)},u=function(e){a.push({items:s,type:e||"normal"}),s=[]};if(e)for(var p,d=(0,r.Z)(e);!(p=d()).done;){var m=p.value;if(Array.isArray(m)){s.length>0&&c();for(var v,g=(0,r.Z)(m);!(v=g()).done;){var y=v.value;s.push(y)}c()}else s.push(m),s.length===o&&c()}s.length>0&&c();for(var h,k=(0,r.Z)(i.Children.toArray(t));!(h=k()).done;){var f,x=h.value,S=null==x||null==(f=x.props)?void 0:f.mdxType;if("InventorySlot"===S)s.push(Object.assign({},x.props)),s.length===o&&c();else if("InventoryRow"===S){var Z;s.length>0&&c();var I=(0,l.F)(x.props.items,x.props.children,x.props.width||o);(Z=s).push.apply(Z,I),u(x.props.type)}}if(s.length>0&&c(),n)for(var N=a.length;N<n;N++){for(var w=0;w<(o||1);w++)s.push({hoverable:!1});c()}return a}(n,u,p,d),h=[],k=(0,r.Z)(y);!(t=k()).done;)for(var f,x=t.value,S=(0,r.Z)(x.items);!(f=S()).done;){var Z=f.value;h.push(Z.uid)}g.group&&(g.group="inventory."+g.group);var I=(0,a.Z)(h,g),N=I[0],w=I[1],b=function(e,t,n){v&&n&&w.toggle(n),m&&m({uid:n,row:e,column:t})};return i.createElement("div",{className:s},y.map((function(e,t){for(var n,o=(0,r.Z)(e.items);!(n=o()).done;){var a=n.value;if(v&&void 0===a.hoverable&&(a.hoverable=!0),a.uid){var s=N.includes(a.uid),c=w.isLocked(a.uid);s?a.type="selected":c&&(a.type="locked"),c&&(a.cantClick=!0)}}return i.createElement(l.Z,{key:t,type:e.type,items:e.items,onClick:function(e){return b(t,e.index,e.uid)}})})))}},6095:function(e,t,n){n.d(t,{Z:function(){return v},F:function(){return m}});var o=n(7462),r=n(3366),i=n(7855),a=n(7294),l=n(7532),s=n(6010),c=n(5880),u="row_eiDT",p="toolbar_2TpY",d=["items","children","width","type","onClick","interactive"];function m(e,t,n){for(var o,r=e||[],l=(0,i.Z)(a.Children.toArray(t));!(o=l()).done;){var s,c=o.value;"InventorySlot"===(null==c||null==(s=c.props)?void 0:s.mdxType)&&r.push(Object.assign({},c.props))}if(n)for(var u=r.length;u<n;u++)r.push({hoverable:!1});return r}function v(e){var t=e.items,n=e.children,i=e.width,v=e.type,g=e.onClick,y=e.interactive,h=(0,r.Z)(e,d),k=m(t,n,i);h.group&&(h.group="inventory."+h.group);var f=(0,l.Z)(k.map((function(e){return e.uid})),h),x=f[0],S=f[1],Z=function(e,t){y&&t&&S.toggle(t),g&&g({uid:t,index:e})};return a.createElement("div",{className:(0,s.Z)(u,"toolbar"==v&&p)},k.map((function(e,t){if(y&&void 0===e.hoverable&&(e.hoverable=!0),e.uid){var n=x.includes(e.uid),r=S.isLocked(e.uid);n?e.type="selected":r&&(e.type="locked"),r&&(e.cantClick=!0)}return"toolbar"==v&&(e.tooltip=t+1,e.tooltipColor=void 0),a.createElement(c.Z,(0,o.Z)({key:t},e,{onClick:function(){return Z(t,e.uid)}}))})))}},5880:function(e,t,n){n.d(t,{Z:function(){return a}});var o=n(7294),r=n(6010),i={container:"container_dbG1",cursorLocked:"cursorLocked_IxBp",normal:"normal_t5PJ",hoverable:"hoverable_DzOz",selected:"selected_ONUJ",locked:"locked_yrQa",sprite:"sprite_01VY",tooltip:"tooltip_vYS5",count:"count_m5JE"};function a(e){var t=e.sprite,n=e.tooltip,a=e.tooltipColor,l=e.count,s=e.countColor,c=e.hoverable,u=e.cantClick,p=e.type,d=void 0===p?"normal":p,m=e.onClick;return o.createElement("div",{onClick:m,className:(0,r.Z)(i.container,u&&i.cursorLocked,d&&i[d],c&&i.hoverable)},t&&o.createElement("img",{key:"sprite",className:i.sprite,src:t}),n&&o.createElement("span",{key:"tooltip",className:i.tooltip,style:{color:a||"#FFED00"}},n),l&&o.createElement("span",{key:"count",className:i.count,style:{color:s||"#FFFFFF"}},l))}},1016:function(e,t,n){n.d(t,{Z:function(){return l}});var o=n(7462),r=n(3366),i=n(7294),a=["children"];function l(e){var t=e.children,n=(0,r.Z)(e,a);return i.createElement("div",(0,o.Z)({role:"tabpanel"},n),t)}},2099:function(e,t,n){n.d(t,{Z:function(){return d}});var o=n(7294),r=n(9443);var i=function(){var e=(0,o.useContext)(r.Z);if(null==e)throw new Error('"useUserPreferencesContext" is used outside of "Layout" component.');return e},a=n(6010),l="tabItem_OdQc",s="tabItemActive_YQWB",c="tab_tgHH";var u=37,p=39;function d(e){var t=e.lazy,n=e.defaultValue,r=e.values,d=e.groupId,m=i(),v=m.tabGroupChoices,g=m.setTabGroupChoices,y=(0,o.useState)(n),h=y[0],k=y[1],f=o.Children.toArray(e.children),x=[];if(null!=d){var S=v[d];null!=S&&S!==h&&r.some((function(e){return e.value===S}))&&k(S)}var Z=function(e){var t=e.currentTarget,n=x.indexOf(t),o=r[n].value;k(o),null!=d&&(g(d,o),setTimeout((function(){var e,n,o,r,i,a,l,c;(e=t.getBoundingClientRect(),n=e.top,o=e.left,r=e.bottom,i=e.right,a=window,l=a.innerHeight,c=a.innerWidth,n>=0&&i<=c&&r<=l&&o>=0)||(t.scrollIntoView({block:"center",behavior:"smooth"}),t.classList.add(s),setTimeout((function(){return t.classList.remove(s)}),2e3))}),150))},I=function(e){var t;switch(e.keyCode){case p:var n=x.indexOf(e.target)+1;t=x[n]||x[0];break;case u:var o=x.indexOf(e.target)-1;t=x[o]||x[x.length-1];break;default:return}t.focus()},N=function(e,t){return t.value===e||t.values&&-1!=t.values.indexOf(e)};return o.createElement("div",{className:"tabs-container"},o.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:"tabs"},r.map((function(e){var t=e.value,n=e.label;return o.createElement("li",{role:"tab",tabIndex:h===t?0:-1,"aria-selected":h===t,className:(0,a.Z)("tabs__item",l,{"tabs__item--active":h===t}),key:t,ref:function(e){return e&&x.push(e)},onKeyDown:I,onFocus:Z,onClick:Z},n)}))),t?o.cloneElement(f.find((function(e){return N(h,e.props)})),{className:c}):o.createElement("div",null,f.map((function(e,t){return o.cloneElement(e,{key:t,hidden:!N(h,e.props),className:c})}))),o.createElement("br",null))}},7532:function(e,t,n){n.d(t,{Z:function(){return i}});var o=n(7294),r=n(5420);function i(e,t){var n=t.defaultValues,i=t.minChoices,a=t.maxChoices,l=t.lockChoices,s=t.group,c=t.onChange,u=null!=i?i:0,p=null!=a?a:1;-1==p&&(p=1/0);var d=function(e,t,n){var i=(0,o.useContext)(r.Do),a=(0,o.useState)((function(){var e;return"function"==typeof t&&(t=t()),null!=(e=t)?e:[]})),l=a[0],s=a[1],c=function(t){if(t.slotName==e){var o=t.value?t.value.split(";"):[];s(o),n&&n(o)}};return(0,o.useEffect)((function(){return null==e?function(){}:(i.subscribe(c),function(){return i.unsubscribe(c)})}),[]),[l,function(t){"function"==typeof t&&(t=t(l)),null!=e?null!=t?i.set(e,t.join(";")):i.delete(e):(null===t&&(t=[]),s(t),n&&n(t))}]}(null!=s?s:null,(function(){if("function"==typeof n&&(n=n()),void 0===n){if(n=[],e)for(var t=e.filter((function(e){return void 0!==e})),o=Math.min(t.length,u),r=0;r<o;r++)n.push(t[r])}else Array.isArray(n)||(n=[n]);if(n.length<u||n.length>p)throw new Error("Invalid default values count: "+u+" \u2264 "+n.length+" \u2264 "+p);if(l&&u==p)throw new Error("Cannot lock choices when Min and Max choices are equal.");return n}),(function(e){return c&&c(e)})),m=d[0],v=d[1],g=function(e){if(!(m.includes(e)||l&&m.length>=p)){for(;m.length>=p;)m.shift();var t=m.concat(e);v(t)}},y=function(e){var t=m.indexOf(e);if(-1!=t&&!(m.length<=u)){var n=m.slice();n.splice(t,1),v(n)}};return[m,{add:g,remove:y,toggle:function(e){m.includes(e)?y(e):g(e)},set:function(e){if((e=e.filter((function(e,t,n){return n.indexOf(e)==t}))).length!=m.length||!e.every((function(e,t){return m.indexOf(e)==t}))){if(e.length<u||e.length>p)throw new Error("Invalid default values count: "+u+" \u2264 "+e.length+" \u2264 "+p);v(e)}},isLocked:function(e){return m.includes(e)?m.length==u:!!l&&m.length==p}}]}},9996:function(e,t,n){n.r(t),n.d(t,{frontMatter:function(){return v},contentTitle:function(){return g},metadata:function(){return y},toc:function(){return h},default:function(){return f}});var o=n(7462),r=n(3366),i=(n(7294),n(3905)),a=n(4996),l=n(338),s=n(296),c=n(6095),u=n(5880),p=n(2099),d=n(1016),m=["components"],v={},g="useSelector",y={unversionedId:"site/hooks/useSelector",id:"site/hooks/useSelector",title:"useSelector",description:"useSelector hook is useful, when you need to add/remove/toggle certain values.",source:"@site/docs/site/hooks/useSelector.mdx",sourceDirName:"site/hooks",slug:"/site/hooks/useSelector",permalink:"/RogueLibs/ru/docs/site/hooks/useSelector",editUrl:"https://github.com/SugarBarrel/RogueLibs/edit/main/website/docs/site/hooks/useSelector.mdx",tags:[],version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"InventoryGrid",permalink:"/RogueLibs/ru/docs/site/components/InventoryGrid"},next:{title:"useStorage",permalink:"/RogueLibs/ru/docs/site/hooks/useStorage"}},h=[{value:"Props",id:"props",children:[],level:2},{value:"Usage",id:"usage",children:[],level:2},{value:"<code>minChoices</code> and <code>maxChoices</code>",id:"minchoices-maxchoices",children:[],level:2},{value:"<code>defaultValues</code>",id:"default-values",children:[],level:2},{value:"<code>lockChoices</code>",id:"lockchoices",children:[],level:2},{value:"<code>group</code>",id:"group",children:[],level:2},{value:"<code>onChange</code> event",id:"onchange-event",children:[],level:2}],k={toc:h};function f(e){var t=e.components,n=(0,r.Z)(e,m);return(0,i.kt)("wrapper",(0,o.Z)({},k,n,{components:t,mdxType:"MDXLayout"}),(0,i.kt)("h1",{id:"useselector"},(0,i.kt)("inlineCode",{parentName:"h1"},"useSelector")),(0,i.kt)("p",null,(0,i.kt)("inlineCode",{parentName:"p"},"useSelector")," hook is useful, when you need to add/remove/toggle certain values."),(0,i.kt)("p",null,"For example, it's used inside ",(0,i.kt)("inlineCode",{parentName:"p"},"InventoryRow"),", ",(0,i.kt)("inlineCode",{parentName:"p"},"InventoryGrid")," and other interactive components:"),(0,i.kt)(s.Z,{interactive:!0,minChoices:1,maxChoices:3,mdxType:"InventoryGrid"},(0,i.kt)(c.Z,{mdxType:"InventoryRow"},(0,i.kt)(u.Z,{uid:"1",sprite:(0,a.Z)("/img/Generic.png"),mdxType:"InventorySlot"}),(0,i.kt)(u.Z,{uid:"2",sprite:(0,a.Z)("/img/Generic2.png"),mdxType:"InventorySlot"}),(0,i.kt)(u.Z,{uid:"3",sprite:(0,a.Z)("/img/Generic3.png"),mdxType:"InventorySlot"})),(0,i.kt)(c.Z,{mdxType:"InventoryRow"},(0,i.kt)(u.Z,{uid:"4",sprite:(0,a.Z)("/img/Generic4.png"),mdxType:"InventorySlot"}),(0,i.kt)(u.Z,{uid:"5",sprite:(0,a.Z)("/img/Generic5.png"),mdxType:"InventorySlot"}),(0,i.kt)(u.Z,{uid:"6",sprite:(0,a.Z)("/img/Generic6.png"),mdxType:"InventorySlot"}))),(0,i.kt)("h2",{id:"props"},"Props"),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-ts"},"export type Props = SelectorParameters & {\n  availableValues: (string | undefined)[] | null,\n}\nexport interface SelectorParameters {\n  defaultValues?: string | string[] | (() => string | string[] | undefined),\n  minChoices?: number,\n  maxChoices?: number,\n  lockChoices?: boolean,\n  group?: string,\n  onChange?: (values: string[]) => void,\n}\n")),(0,i.kt)("h2",{id:"usage"},"Usage"),(0,i.kt)(p.Z,{defaultValue:"ts",values:[{value:"ts",label:"TypeScript"},{value:"js",label:"JavaScript"}],mdxType:"Tabs"},(0,i.kt)(d.Z,{value:"ts",mdxType:"TabItem"},(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-ts"},'import useSelector, { SelectorParameters } from "../hooks/useSelector";\n\nexport type Props = SelectorParameters & {\n  /* your props */\n}\n\nexport default function ({/* your props */ ...pars}: Props) {\n\n  if (pars.group) pars.group = `some.storage.slot.path.${pars.group}`;\n  const [values, controller] = useSelector(availableValues, pars);\n\n  /* ... */\n}\n'))),(0,i.kt)(d.Z,{value:"js",mdxType:"TabItem"},(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-js"},'import useSelector from "../hooks/useSelector";\n\nexport default function ({/* your props */ ...pars}) {\n\n  if (pars.group) pars.group = `some.storage.slot.path.${pars.group}`;\n  const [values, controller] = useSelector(availableValues, pars);\n\n  /* ... */\n}\n')))),(0,i.kt)("div",{className:"admonition admonition-info alert alert--info"},(0,i.kt)("div",{parentName:"div",className:"admonition-heading"},(0,i.kt)("h5",{parentName:"div"},(0,i.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,i.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,i.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M7 2.3c3.14 0 5.7 2.56 5.7 5.7s-2.56 5.7-5.7 5.7A5.71 5.71 0 0 1 1.3 8c0-3.14 2.56-5.7 5.7-5.7zM7 1C3.14 1 0 4.14 0 8s3.14 7 7 7 7-3.14 7-7-3.14-7-7-7zm1 3H6v5h2V4zm0 6H6v2h2v-2z"}))),"info")),(0,i.kt)("div",{parentName:"div",className:"admonition-content"},(0,i.kt)("p",{parentName:"div"},(0,i.kt)("inlineCode",{parentName:"p"},"group")," stores the value using the ",(0,i.kt)("a",{parentName:"p",href:"./useStorage"},(0,i.kt)("inlineCode",{parentName:"a"},"useStorage")," hook"),"."))),(0,i.kt)("p",null,(0,i.kt)("inlineCode",{parentName:"p"},"availableValues")," is the array of all possible selected values. Set it to ",(0,i.kt)("inlineCode",{parentName:"p"},"null")," if the creation of such array is not possible."),(0,i.kt)("div",{className:"admonition admonition-note alert alert--secondary"},(0,i.kt)("div",{parentName:"div",className:"admonition-heading"},(0,i.kt)("h5",{parentName:"div"},(0,i.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,i.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,i.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.3 5.69a.942.942 0 0 1-.28-.7c0-.28.09-.52.28-.7.19-.18.42-.28.7-.28.28 0 .52.09.7.28.18.19.28.42.28.7 0 .28-.09.52-.28.7a1 1 0 0 1-.7.3c-.28 0-.52-.11-.7-.3zM8 7.99c-.02-.25-.11-.48-.31-.69-.2-.19-.42-.3-.69-.31H6c-.27.02-.48.13-.69.31-.2.2-.3.44-.31.69h1v3c.02.27.11.5.31.69.2.2.42.31.69.31h1c.27 0 .48-.11.69-.31.2-.19.3-.42.31-.69H8V7.98v.01zM7 2.3c-3.14 0-5.7 2.54-5.7 5.68 0 3.14 2.56 5.7 5.7 5.7s5.7-2.55 5.7-5.7c0-3.15-2.56-5.69-5.7-5.69v.01zM7 .98c3.86 0 7 3.14 7 7s-3.14 7-7 7-7-3.12-7-7 3.14-7 7-7z"}))),"note")),(0,i.kt)("div",{parentName:"div",className:"admonition-content"},(0,i.kt)("p",{parentName:"div"},"At the moment it's used only to select default values."))),(0,i.kt)("p",null,"Then you can use ",(0,i.kt)("inlineCode",{parentName:"p"},"controller"),"'s functions:"),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-ts"},"export type SelectorController = {\n  add: (value: string) => void,     // adds a value\n  remove: (values: string) => void, // removes a value\n  toggle: (values: string) => void, // toggles a value\n  set: (values: string[]) => void,  // sets the selected values\n  isLocked: (value: string) => boolean,\n  // alias for (values.length == (values.includes(value) ? MinChoices : MaxChoices))\n}\n")),(0,i.kt)("p",null,"In the examples below we'll be using ",(0,i.kt)("inlineCode",{parentName:"p"},"InventoryRow")," to show some of the features."),(0,i.kt)("h2",{id:"minchoices-maxchoices"},(0,i.kt)("inlineCode",{parentName:"h2"},"minChoices")," and ",(0,i.kt)("inlineCode",{parentName:"h2"},"maxChoices")),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-ts"},"  minChoices?: number, // default: 0\n  maxChoices?: number, // default: 1\n")),(0,i.kt)("p",null,(0,i.kt)("inlineCode",{parentName:"p"},"minChoices")," specifies the minimum amount of selected slots.",(0,i.kt)("br",{parentName:"p"}),"\n",(0,i.kt)("inlineCode",{parentName:"p"},"maxChoices")," specifies the maximum amount of selected slots. -1 \u2261 \u221e."),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-jsx"},'<InventoryRow interactive={true} minChoices={1} maxChoices={3}>\n  <InventorySlot uid="1" sprite={useBaseUrl("/img/Generic.png")}/>\n  <InventorySlot uid="2" sprite={useBaseUrl("/img/Generic2.png")} count={25}/>\n  <InventorySlot uid="3" sprite={useBaseUrl("/img/Generic3.png")} count={25} tooltip="$13"/>\n  <InventorySlot uid="4" sprite={useBaseUrl("/img/Generic4.png")} count="$13" tooltip={25}/>\n  <InventorySlot uid="5" sprite={useBaseUrl("/img/Generic5.png")} tooltip={25}/>\n  <InventorySlot uid="6" sprite={useBaseUrl("/img/Generic6.png")}/>\n</InventoryRow>\n')),(0,i.kt)(l.Z,{mdxType:"BrowserWindow"},(0,i.kt)(c.Z,{interactive:!0,minChoices:1,maxChoices:3,mdxType:"InventoryRow"},(0,i.kt)(u.Z,{uid:"1",sprite:(0,a.Z)("/img/Generic.png"),mdxType:"InventorySlot"}),(0,i.kt)(u.Z,{uid:"2",sprite:(0,a.Z)("/img/Generic2.png"),count:25,mdxType:"InventorySlot"}),(0,i.kt)(u.Z,{uid:"3",sprite:(0,a.Z)("/img/Generic3.png"),count:25,tooltip:"$13",mdxType:"InventorySlot"}),(0,i.kt)(u.Z,{uid:"4",sprite:(0,a.Z)("/img/Generic4.png"),count:"$13",tooltip:25,mdxType:"InventorySlot"}),(0,i.kt)(u.Z,{uid:"5",sprite:(0,a.Z)("/img/Generic5.png"),tooltip:25,mdxType:"InventorySlot"}),(0,i.kt)(u.Z,{uid:"6",sprite:(0,a.Z)("/img/Generic6.png"),mdxType:"InventorySlot"}))),(0,i.kt)("h2",{id:"default-values"},(0,i.kt)("inlineCode",{parentName:"h2"},"defaultValues")),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-ts"},"  defaultValues?: string | string[] | (() => string | string[] | undefined),\n")),(0,i.kt)("p",null,(0,i.kt)("inlineCode",{parentName:"p"},"defaultValues")," can be a single string, an array of strings or a lazy function."),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-jsx"},'<InventoryRow interactive={true} maxChoices={3} defaultValues={["2", "4"]}>\n  <InventorySlot uid="1" sprite={useBaseUrl("/img/Generic.png")}/>\n  <InventorySlot uid="2" sprite={useBaseUrl("/img/Generic2.png")} count={25}/>\n  <InventorySlot uid="3" sprite={useBaseUrl("/img/Generic3.png")} count={25} tooltip="$13"/>\n  <InventorySlot uid="4" sprite={useBaseUrl("/img/Generic4.png")} count="$13" tooltip={25}/>\n  <InventorySlot uid="5" sprite={useBaseUrl("/img/Generic5.png")} tooltip={25}/>\n  <InventorySlot uid="6" sprite={useBaseUrl("/img/Generic6.png")}/>\n</InventoryRow>\n')),(0,i.kt)(l.Z,{mdxType:"BrowserWindow"},(0,i.kt)(c.Z,{interactive:!0,maxChoices:3,defaultValues:["2","4"],mdxType:"InventoryRow"},(0,i.kt)(u.Z,{uid:"1",sprite:(0,a.Z)("/img/Generic.png"),mdxType:"InventorySlot"}),(0,i.kt)(u.Z,{uid:"2",sprite:(0,a.Z)("/img/Generic2.png"),count:25,mdxType:"InventorySlot"}),(0,i.kt)(u.Z,{uid:"3",sprite:(0,a.Z)("/img/Generic3.png"),count:25,tooltip:"$13",mdxType:"InventorySlot"}),(0,i.kt)(u.Z,{uid:"4",sprite:(0,a.Z)("/img/Generic4.png"),count:"$13",tooltip:25,mdxType:"InventorySlot"}),(0,i.kt)(u.Z,{uid:"5",sprite:(0,a.Z)("/img/Generic5.png"),tooltip:25,mdxType:"InventorySlot"}),(0,i.kt)(u.Z,{uid:"6",sprite:(0,a.Z)("/img/Generic6.png"),mdxType:"InventorySlot"}))),(0,i.kt)("p",null,"If not set, or if the lazy function returns ",(0,i.kt)("inlineCode",{parentName:"p"},"undefined"),", picks the first ",(0,i.kt)("inlineCode",{parentName:"p"},"minChoices")," values:"),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-jsx"},'<InventoryRow interactive={true} minChoices={3} maxChoices={-1}>\n  <InventorySlot uid="1" sprite={useBaseUrl("/img/Generic.png")}/>\n  <InventorySlot uid="2" sprite={useBaseUrl("/img/Generic2.png")} count={25}/>\n  <InventorySlot uid="3" sprite={useBaseUrl("/img/Generic3.png")} count={25} tooltip="$13"/>\n  <InventorySlot uid="4" sprite={useBaseUrl("/img/Generic4.png")} count="$13" tooltip={25}/>\n  <InventorySlot uid="5" sprite={useBaseUrl("/img/Generic5.png")} tooltip={25}/>\n  <InventorySlot uid="6" sprite={useBaseUrl("/img/Generic6.png")}/>\n</InventoryRow>\n')),(0,i.kt)(l.Z,{mdxType:"BrowserWindow"},(0,i.kt)(c.Z,{interactive:!0,minChoices:3,maxChoices:-1,mdxType:"InventoryRow"},(0,i.kt)(u.Z,{uid:"1",sprite:(0,a.Z)("/img/Generic.png"),mdxType:"InventorySlot"}),(0,i.kt)(u.Z,{uid:"2",sprite:(0,a.Z)("/img/Generic2.png"),count:25,mdxType:"InventorySlot"}),(0,i.kt)(u.Z,{uid:"3",sprite:(0,a.Z)("/img/Generic3.png"),count:25,tooltip:"$13",mdxType:"InventorySlot"}),(0,i.kt)(u.Z,{uid:"4",sprite:(0,a.Z)("/img/Generic4.png"),count:"$13",tooltip:25,mdxType:"InventorySlot"}),(0,i.kt)(u.Z,{uid:"5",sprite:(0,a.Z)("/img/Generic5.png"),tooltip:25,mdxType:"InventorySlot"}),(0,i.kt)(u.Z,{uid:"6",sprite:(0,a.Z)("/img/Generic6.png"),mdxType:"InventorySlot"}))),(0,i.kt)("h2",{id:"lockchoices"},(0,i.kt)("inlineCode",{parentName:"h2"},"lockChoices")),(0,i.kt)("p",null,'You can "lock" the selected values with ',(0,i.kt)("inlineCode",{parentName:"p"},"lockChoices"),".",(0,i.kt)("br",{parentName:"p"}),"\n","When the maximum selectable amount is reached, non-selected slots change to ",(0,i.kt)("inlineCode",{parentName:"p"},'"locked"')," type."),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-jsx"},'<InventoryRow interactive={true} maxChoices={2} lockChoices={true}>\n  <InventorySlot uid="1" sprite={useBaseUrl("/img/Generic.png")}/>\n  <InventorySlot uid="2" sprite={useBaseUrl("/img/Generic2.png")} count={25}/>\n  <InventorySlot uid="3" sprite={useBaseUrl("/img/Generic3.png")} count={25} tooltip="$13"/>\n  <InventorySlot uid="4" sprite={useBaseUrl("/img/Generic4.png")} count="$13" tooltip={25}/>\n  <InventorySlot uid="5" sprite={useBaseUrl("/img/Generic5.png")} tooltip={25}/>\n  <InventorySlot uid="6" sprite={useBaseUrl("/img/Generic6.png")}/>\n</InventoryRow>\n')),(0,i.kt)(l.Z,{mdxType:"BrowserWindow"},(0,i.kt)(c.Z,{interactive:!0,maxChoices:2,lockChoices:!0,mdxType:"InventoryRow"},(0,i.kt)(u.Z,{uid:"1",sprite:(0,a.Z)("/img/Generic.png"),mdxType:"InventorySlot"}),(0,i.kt)(u.Z,{uid:"2",sprite:(0,a.Z)("/img/Generic2.png"),count:25,mdxType:"InventorySlot"}),(0,i.kt)(u.Z,{uid:"3",sprite:(0,a.Z)("/img/Generic3.png"),count:25,tooltip:"$13",mdxType:"InventorySlot"}),(0,i.kt)(u.Z,{uid:"4",sprite:(0,a.Z)("/img/Generic4.png"),count:"$13",tooltip:25,mdxType:"InventorySlot"}),(0,i.kt)(u.Z,{uid:"5",sprite:(0,a.Z)("/img/Generic5.png"),tooltip:25,mdxType:"InventorySlot"}),(0,i.kt)(u.Z,{uid:"6",sprite:(0,a.Z)("/img/Generic6.png"),mdxType:"InventorySlot"}))),(0,i.kt)("h2",{id:"group"},(0,i.kt)("inlineCode",{parentName:"h2"},"group")),(0,i.kt)("p",null,"You can use ",(0,i.kt)("inlineCode",{parentName:"p"},"group")," to save the selected values in the local storage.",(0,i.kt)("br",{parentName:"p"}),"\n","Try selecting some slots and then reloading the page."),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-jsx"},'<InventoryRow interactive={true} group="useSelectorDemo" maxChoices={4}>\n  <InventorySlot uid="1" sprite={useBaseUrl("/img/Generic.png")}/>\n  <InventorySlot uid="2" sprite={useBaseUrl("/img/Generic2.png")} count={25}/>\n  <InventorySlot uid="3" sprite={useBaseUrl("/img/Generic3.png")} count={25} tooltip="$13"/>\n  <InventorySlot uid="4" sprite={useBaseUrl("/img/Generic4.png")} count="$13" tooltip={25}/>\n  <InventorySlot uid="5" sprite={useBaseUrl("/img/Generic5.png")} tooltip={25}/>\n  <InventorySlot uid="6" sprite={useBaseUrl("/img/Generic6.png")}/>\n</InventoryRow>\n')),(0,i.kt)(l.Z,{mdxType:"BrowserWindow"},(0,i.kt)(c.Z,{interactive:!0,group:"useSelectorDemo",maxChoices:4,mdxType:"InventoryRow"},(0,i.kt)(u.Z,{uid:"1",sprite:(0,a.Z)("/img/Generic.png"),mdxType:"InventorySlot"}),(0,i.kt)(u.Z,{uid:"2",sprite:(0,a.Z)("/img/Generic2.png"),count:25,mdxType:"InventorySlot"}),(0,i.kt)(u.Z,{uid:"3",sprite:(0,a.Z)("/img/Generic3.png"),count:25,tooltip:"$13",mdxType:"InventorySlot"}),(0,i.kt)(u.Z,{uid:"4",sprite:(0,a.Z)("/img/Generic4.png"),count:"$13",tooltip:25,mdxType:"InventorySlot"}),(0,i.kt)(u.Z,{uid:"5",sprite:(0,a.Z)("/img/Generic5.png"),tooltip:25,mdxType:"InventorySlot"}),(0,i.kt)(u.Z,{uid:"6",sprite:(0,a.Z)("/img/Generic6.png"),mdxType:"InventorySlot"}))),(0,i.kt)("div",{className:"admonition admonition-tip alert alert--success"},(0,i.kt)("div",{parentName:"div",className:"admonition-heading"},(0,i.kt)("h5",{parentName:"div"},(0,i.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,i.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"12",height:"16",viewBox:"0 0 12 16"},(0,i.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.5 0C3.48 0 1 2.19 1 5c0 .92.55 2.25 1 3 1.34 2.25 1.78 2.78 2 4v1h5v-1c.22-1.22.66-1.75 2-4 .45-.75 1-2.08 1-3 0-2.81-2.48-5-5.5-5zm3.64 7.48c-.25.44-.47.8-.67 1.11-.86 1.41-1.25 2.06-1.45 3.23-.02.05-.02.11-.02.17H5c0-.06 0-.13-.02-.17-.2-1.17-.59-1.83-1.45-3.23-.2-.31-.42-.67-.67-1.11C2.44 6.78 2 5.65 2 5c0-2.2 2.02-4 4.5-4 1.22 0 2.36.42 3.22 1.19C10.55 2.94 11 3.94 11 5c0 .66-.44 1.78-.86 2.48zM4 14h5c-.23 1.14-1.3 2-2.5 2s-2.27-.86-2.5-2z"}))),"Pro-tip: Local Storage")),(0,i.kt)("div",{parentName:"div",className:"admonition-content"},(0,i.kt)("p",{parentName:"div"},"See the stored data in ",(0,i.kt)("strong",{parentName:"p"},"Developer Tools > Application > Storage > Local Storage"),"."))),(0,i.kt)("p",null,"You can also use ",(0,i.kt)("inlineCode",{parentName:"p"},"group")," to synchronize choices between different instances of components:"),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-jsx"},'<InventoryRow interactive={true} group="useSelectorDemo2" maxChoices={2}>\n  <InventorySlot uid="1" sprite={useBaseUrl("/img/Generic.png")}/>\n  <InventorySlot uid="2" sprite={useBaseUrl("/img/Generic2.png")} count={25}/>\n  <InventorySlot uid="3" sprite={useBaseUrl("/img/Generic3.png")} count={25} tooltip="$13"/>\n  <InventorySlot uid="4" sprite={useBaseUrl("/img/Generic4.png")} count="$13" tooltip={25}/>\n  <InventorySlot type={null}/>\n  <InventorySlot type={null}/>\n</InventoryRow>\n<InventoryRow interactive={true} group="useSelectorDemo2" maxChoices={2}>\n  <InventorySlot type={null}/>\n  <InventorySlot type={null}/>\n  <InventorySlot uid="3" sprite={useBaseUrl("/img/Generic3.png")} count={25} tooltip="$13"/>\n  <InventorySlot uid="4" sprite={useBaseUrl("/img/Generic4.png")} count="$13" tooltip={25}/>\n  <InventorySlot uid="5" sprite={useBaseUrl("/img/Generic5.png")} tooltip={25}/>\n  <InventorySlot uid="6" sprite={useBaseUrl("/img/Generic6.png")}/>\n</InventoryRow>\n')),(0,i.kt)(l.Z,{mdxType:"BrowserWindow"},(0,i.kt)(c.Z,{interactive:!0,group:"useSelectorDemo2",maxChoices:2,mdxType:"InventoryRow"},(0,i.kt)(u.Z,{uid:"1",sprite:(0,a.Z)("/img/Generic.png"),mdxType:"InventorySlot"}),(0,i.kt)(u.Z,{uid:"2",sprite:(0,a.Z)("/img/Generic2.png"),count:25,mdxType:"InventorySlot"}),(0,i.kt)(u.Z,{uid:"3",sprite:(0,a.Z)("/img/Generic3.png"),count:25,tooltip:"$13",mdxType:"InventorySlot"}),(0,i.kt)(u.Z,{uid:"4",sprite:(0,a.Z)("/img/Generic4.png"),count:"$13",tooltip:25,mdxType:"InventorySlot"}),(0,i.kt)(u.Z,{type:null,mdxType:"InventorySlot"}),(0,i.kt)(u.Z,{type:null,mdxType:"InventorySlot"})),(0,i.kt)(c.Z,{interactive:!0,group:"useSelectorDemo2",maxChoices:2,mdxType:"InventoryRow"},(0,i.kt)(u.Z,{type:null,mdxType:"InventorySlot"}),(0,i.kt)(u.Z,{type:null,mdxType:"InventorySlot"}),(0,i.kt)(u.Z,{uid:"3",sprite:(0,a.Z)("/img/Generic3.png"),count:25,tooltip:"$13",mdxType:"InventorySlot"}),(0,i.kt)(u.Z,{uid:"4",sprite:(0,a.Z)("/img/Generic4.png"),count:"$13",tooltip:25,mdxType:"InventorySlot"}),(0,i.kt)(u.Z,{uid:"5",sprite:(0,a.Z)("/img/Generic5.png"),tooltip:25,mdxType:"InventorySlot"}),(0,i.kt)(u.Z,{uid:"6",sprite:(0,a.Z)("/img/Generic6.png"),mdxType:"InventorySlot"}))),(0,i.kt)("div",{className:"admonition admonition-note alert alert--secondary"},(0,i.kt)("div",{parentName:"div",className:"admonition-heading"},(0,i.kt)("h5",{parentName:"div"},(0,i.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,i.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,i.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.3 5.69a.942.942 0 0 1-.28-.7c0-.28.09-.52.28-.7.19-.18.42-.28.7-.28.28 0 .52.09.7.28.18.19.28.42.28.7 0 .28-.09.52-.28.7a1 1 0 0 1-.7.3c-.28 0-.52-.11-.7-.3zM8 7.99c-.02-.25-.11-.48-.31-.69-.2-.19-.42-.3-.69-.31H6c-.27.02-.48.13-.69.31-.2.2-.3.44-.31.69h1v3c.02.27.11.5.31.69.2.2.42.31.69.31h1c.27 0 .48-.11.69-.31.2-.19.3-.42.31-.69H8V7.98v.01zM7 2.3c-3.14 0-5.7 2.54-5.7 5.68 0 3.14 2.56 5.7 5.7 5.7s5.7-2.55 5.7-5.7c0-3.15-2.56-5.69-5.7-5.69v.01zM7 .98c3.86 0 7 3.14 7 7s-3.14 7-7 7-7-3.12-7-7 3.14-7 7-7z"}))),"note")),(0,i.kt)("div",{parentName:"div",className:"admonition-content"},(0,i.kt)("p",{parentName:"div"},"Note the behavior, when a slot that doesn't exist in one of the rows is selected in another row."))),(0,i.kt)("h2",{id:"onchange-event"},(0,i.kt)("inlineCode",{parentName:"h2"},"onChange")," event"),(0,i.kt)("p",null,(0,i.kt)("inlineCode",{parentName:"p"},"onChange")," doesn't necessarily mean that the values changed. Just that they ",(0,i.kt)("strong",{parentName:"p"},"could")," be different."))}f.isMDXComponent=!0}}]);