"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[9336],{3905:function(e,n,t){t.d(n,{Zo:function(){return p},kt:function(){return m}});var r=t(7294);function o(e,n,t){return n in e?Object.defineProperty(e,n,{value:t,enumerable:!0,configurable:!0,writable:!0}):e[n]=t,e}function i(e,n){var t=Object.keys(e);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(e);n&&(r=r.filter((function(n){return Object.getOwnPropertyDescriptor(e,n).enumerable}))),t.push.apply(t,r)}return t}function l(e){for(var n=1;n<arguments.length;n++){var t=null!=arguments[n]?arguments[n]:{};n%2?i(Object(t),!0).forEach((function(n){o(e,n,t[n])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(t)):i(Object(t)).forEach((function(n){Object.defineProperty(e,n,Object.getOwnPropertyDescriptor(t,n))}))}return e}function a(e,n){if(null==e)return{};var t,r,o=function(e,n){if(null==e)return{};var t,r,o={},i=Object.keys(e);for(r=0;r<i.length;r++)t=i[r],n.indexOf(t)>=0||(o[t]=e[t]);return o}(e,n);if(Object.getOwnPropertySymbols){var i=Object.getOwnPropertySymbols(e);for(r=0;r<i.length;r++)t=i[r],n.indexOf(t)>=0||Object.prototype.propertyIsEnumerable.call(e,t)&&(o[t]=e[t])}return o}var c=r.createContext({}),s=function(e){var n=r.useContext(c),t=n;return e&&(t="function"==typeof e?e(n):l(l({},n),e)),t},p=function(e){var n=s(e.components);return r.createElement(c.Provider,{value:n},e.children)},u={inlineCode:"code",wrapper:function(e){var n=e.children;return r.createElement(r.Fragment,{},n)}},d=r.forwardRef((function(e,n){var t=e.components,o=e.mdxType,i=e.originalType,c=e.parentName,p=a(e,["components","mdxType","originalType","parentName"]),d=s(t),m=o,v=d["".concat(c,".").concat(m)]||d[m]||u[m]||i;return t?r.createElement(v,l(l({ref:n},p),{},{components:t})):r.createElement(v,l({ref:n},p))}));function m(e,n){var t=arguments,o=n&&n.mdxType;if("string"==typeof e||o){var i=t.length,l=new Array(i);l[0]=d;var a={};for(var c in n)hasOwnProperty.call(n,c)&&(a[c]=n[c]);a.originalType=e,a.mdxType="string"==typeof e?e:o,l[1]=a;for(var s=2;s<i;s++)l[s]=t[s];return r.createElement.apply(null,l)}return r.createElement.apply(null,t)}d.displayName="MDXCreateElement"},338:function(e,n,t){t.d(n,{Z:function(){return d}});var r=t(7294),o="browserWindow_jKcn",i="browserWindowHeader_RTeS",l="buttons_Ko+m",a="browserWindowAddressBar_pbPN",c="dot_GdWh",s="browserWindowMenuIcon_k0Eb",p="bar_MHJT",u="browserWindowBody_MhPA";function d(e){var n=e.children,t=e.url;return r.createElement("div",null,r.createElement("div",{className:o},r.createElement("div",{className:i},r.createElement("div",{className:l},r.createElement("span",{className:c,style:{background:"#f25f58"}}),r.createElement("span",{className:c,style:{background:"#fbbe3c"}}),r.createElement("span",{className:c,style:{background:"#58cb42"}})),r.createElement("div",{className:a},t),r.createElement("div",{className:s},r.createElement("div",null,r.createElement("span",{className:p}),r.createElement("span",{className:p}),r.createElement("span",{className:p})))),r.createElement("div",{className:u},n)),r.createElement("br",null))}},296:function(e,n,t){t.d(n,{Z:function(){return p}});var r=t(3366),o=t(7855),i=t(7294),l=t(7532),a=t(6095),c="container_0LFt",s=["items","children","height","width","onClick","interactive"];function p(e){for(var n,t=e.items,p=e.children,u=e.height,d=e.width,m=e.onClick,v=e.interactive,g=(0,r.Z)(e,s),y=function(e,n,t,r){var l=[],c=[],s=function(e){if(r)for(var n=c.length;n<r;n++)c.push({hoverable:!1});p(e)},p=function(e){l.push({items:c,type:e||"normal"}),c=[]};if(e)for(var u,d=(0,o.Z)(e);!(u=d()).done;){var m=u.value;if(Array.isArray(m)){c.length>0&&s();for(var v,g=(0,o.Z)(m);!(v=g()).done;){var y=v.value;c.push(y)}s()}else c.push(m),c.length===r&&s()}c.length>0&&s();for(var h,f=(0,o.Z)(i.Children.toArray(n));!(h=f()).done;){var k,I=h.value,w=null==I||null==(k=I.props)?void 0:k.mdxType;if("InventorySlot"===w)c.push(Object.assign({},I.props)),c.length===r&&s();else if("InventoryRow"===w){var b;c.length>0&&s();var Z=(0,a.F)(I.props.items,I.props.children,I.props.width||r);(b=c).push.apply(b,Z),p(I.props.type)}}if(c.length>0&&s(),t)for(var S=l.length;S<t;S++){for(var x=0;x<(r||1);x++)c.push({hoverable:!1});s()}return l}(t,p,u,d),h=[],f=(0,o.Z)(y);!(n=f()).done;)for(var k,I=n.value,w=(0,o.Z)(I.items);!(k=w()).done;){var b=k.value;h.push(b.uid)}g.group&&(g.group="inventory."+g.group);var Z=(0,l.Z)(h,g),S=Z[0],x=Z[1],G=function(e,n,t){v&&t&&x.toggle(t),m&&m({uid:t,row:e,column:n})};return i.createElement("div",{className:c},y.map((function(e,n){for(var t,r=(0,o.Z)(e.items);!(t=r()).done;){var l=t.value;if(v&&void 0===l.hoverable&&(l.hoverable=!0),l.uid){var c=S.includes(l.uid),s=x.isLocked(l.uid);c?l.type="selected":s&&(l.type="locked"),s&&(l.cantClick=!0)}}return i.createElement(a.Z,{key:n,type:e.type,items:e.items,onClick:function(e){return G(n,e.index,e.uid)}})})))}},6095:function(e,n,t){t.d(n,{Z:function(){return v},F:function(){return m}});var r=t(7462),o=t(3366),i=t(7855),l=t(7294),a=t(7532),c=t(6010),s=t(5880),p="row_eiDT",u="toolbar_2TpY",d=["items","children","width","type","onClick","interactive"];function m(e,n,t){for(var r,o=e||[],a=(0,i.Z)(l.Children.toArray(n));!(r=a()).done;){var c,s=r.value;"InventorySlot"===(null==s||null==(c=s.props)?void 0:c.mdxType)&&o.push(Object.assign({},s.props))}if(t)for(var p=o.length;p<t;p++)o.push({hoverable:!1});return o}function v(e){var n=e.items,t=e.children,i=e.width,v=e.type,g=e.onClick,y=e.interactive,h=(0,o.Z)(e,d),f=m(n,t,i);h.group&&(h.group="inventory."+h.group);var k=(0,a.Z)(f.map((function(e){return e.uid})),h),I=k[0],w=k[1],b=function(e,n){y&&n&&w.toggle(n),g&&g({uid:n,index:e})};return l.createElement("div",{className:(0,c.Z)(p,"toolbar"==v&&u)},f.map((function(e,n){if(y&&void 0===e.hoverable&&(e.hoverable=!0),e.uid){var t=I.includes(e.uid),o=w.isLocked(e.uid);t?e.type="selected":o&&(e.type="locked"),o&&(e.cantClick=!0)}return"toolbar"==v&&(e.tooltip=n+1,e.tooltipColor=void 0),l.createElement(s.Z,(0,r.Z)({key:n},e,{onClick:function(){return b(n,e.uid)}}))})))}},5880:function(e,n,t){t.d(n,{Z:function(){return l}});var r=t(7294),o=t(6010),i={container:"container_dbG1",cursorLocked:"cursorLocked_IxBp",normal:"normal_t5PJ",hoverable:"hoverable_DzOz",selected:"selected_ONUJ",locked:"locked_yrQa",sprite:"sprite_01VY",tooltip:"tooltip_vYS5",count:"count_m5JE"};function l(e){var n=e.sprite,t=e.tooltip,l=e.tooltipColor,a=e.count,c=e.countColor,s=e.hoverable,p=e.cantClick,u=e.type,d=void 0===u?"normal":u,m=e.onClick;return r.createElement("div",{onClick:m,className:(0,o.Z)(i.container,p&&i.cursorLocked,d&&i[d],s&&i.hoverable)},n&&r.createElement("img",{key:"sprite",className:i.sprite,src:n}),t&&r.createElement("span",{key:"tooltip",className:i.tooltip,style:{color:l||"#FFED00"}},t),a&&r.createElement("span",{key:"count",className:i.count,style:{color:c||"#FFFFFF"}},a))}},7532:function(e,n,t){t.d(n,{Z:function(){return i}});var r=t(7294),o=t(5420);function i(e,n){var t=n.defaultValues,i=n.minChoices,l=n.maxChoices,a=n.lockChoices,c=n.group,s=n.onChange,p=null!=i?i:0,u=null!=l?l:1;-1==u&&(u=1/0);var d=function(e,n,t){var i=(0,r.useContext)(o.Do),l=(0,r.useState)((function(){var e;return"function"==typeof n&&(n=n()),null!=(e=n)?e:[]})),a=l[0],c=l[1],s=function(n){if(n.slotName==e){var r=n.value?n.value.split(";"):[];c(r),t&&t(r)}};return(0,r.useEffect)((function(){return null==e?function(){}:(i.subscribe(s),function(){return i.unsubscribe(s)})}),[]),[a,function(n){"function"==typeof n&&(n=n(a)),null!=e?null!=n?i.set(e,n.join(";")):i.delete(e):(null===n&&(n=[]),c(n),t&&t(n))}]}(null!=c?c:null,(function(){if("function"==typeof t&&(t=t()),void 0===t){if(t=[],e)for(var n=e.filter((function(e){return void 0!==e})),r=Math.min(n.length,p),o=0;o<r;o++)t.push(n[o])}else Array.isArray(t)||(t=[t]);if(t.length<p||t.length>u)throw new Error("Invalid default values count: "+p+" \u2264 "+t.length+" \u2264 "+u);if(a&&p==u)throw new Error("Cannot lock choices when Min and Max choices are equal.");return t}),(function(e){return s&&s(e)})),m=d[0],v=d[1],g=function(e){if(!(m.includes(e)||a&&m.length>=u)){for(;m.length>=u;)m.shift();var n=m.concat(e);v(n)}},y=function(e){var n=m.indexOf(e);if(-1!=n&&!(m.length<=p)){var t=m.slice();t.splice(n,1),v(t)}};return[m,{add:g,remove:y,toggle:function(e){m.includes(e)?y(e):g(e)},set:function(e){if((e=e.filter((function(e,n,t){return t.indexOf(e)==n}))).length!=m.length||!e.every((function(e,n){return m.indexOf(e)==n}))){if(e.length<p||e.length>u)throw new Error("Invalid default values count: "+p+" \u2264 "+e.length+" \u2264 "+u);v(e)}},isLocked:function(e){return m.includes(e)?m.length==p:!!a&&m.length==u}}]}},3001:function(e,n,t){t.r(n),t.d(n,{frontMatter:function(){return d},contentTitle:function(){return m},metadata:function(){return v},toc:function(){return g},default:function(){return h}});var r=t(7462),o=t(3366),i=(t(7294),t(3905)),l=t(4996),a=t(338),c=t(5880),s=t(6095),p=t(296),u=["components"],d={},m="InventoryGrid",v={unversionedId:"site/components/InventoryGrid",id:"site/components/InventoryGrid",title:"InventoryGrid",description:"Props",source:"@site/docs/site/components/InventoryGrid.mdx",sourceDirName:"site/components",slug:"/site/components/InventoryGrid",permalink:"/RogueLibs/docs/site/components/InventoryGrid",editUrl:"https://github.com/Abbysssal/RogueLibs/edit/main/website/docs/site/components/InventoryGrid.mdx",tags:[],version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"InventoryRow",permalink:"/RogueLibs/docs/site/components/InventoryRow"},next:{title:"useSelector",permalink:"/RogueLibs/docs/site/hooks/useSelector"}},g=[{value:"Props",id:"props",children:[],level:2},{value:"Typical usage",id:"typical-usage",children:[],level:2},{value:"Minimum width and height",id:"minimum-width-height",children:[],level:2},{value:"onClick event",id:"onclick-event",children:[],level:2},{value:"Interactive",id:"interactive",children:[],level:2}],y={toc:g};function h(e){var n=e.components,t=(0,o.Z)(e,u);return(0,i.kt)("wrapper",(0,r.Z)({},y,t,{components:n,mdxType:"MDXLayout"}),(0,i.kt)("h1",{id:"inventorygrid"},(0,i.kt)("inlineCode",{parentName:"h1"},"InventoryGrid")),(0,i.kt)("h2",{id:"props"},"Props"),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-ts"},"import { Props as SlotProps } from '@site/src/components/InventorySlot';\nimport { SelectorParameters } from '@site/src/components/hooks/useSelector';\n\nexport type Props = SelectorParameters & {\n  items?: (SlotProps | SlotProps[])[], // (not recommended) props of slots to display\n  children?: React.ReactNode,          // InventorySlot and InventoryRow children\n  height?: number, // minimum height of the grid\n  width?: number,  // minimum width of the grid\n\n  onClick?: (e: GridSlotArgs) => void, // click event handler\n  interactive?: boolean, // determines whether slots can be selected\n}\nexport type GridSlotArgs = {\n  uid: string | undefined, // Unique Identifier of the clicked slot\n  row: number,    // index of the clicked slot's row\n  column: number, // index of the clicked slot's column\n}\n")),(0,i.kt)("h2",{id:"typical-usage"},"Typical usage"),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-jsx"},'<InventoryGrid>\n  <InventorySlot sprite={useBaseUrl("/img/Generic.png")}/>\n  <InventorySlot sprite={useBaseUrl("/img/Generic2.png")} count={25}/>\n  <InventoryRow>\n    <InventorySlot sprite={useBaseUrl("/img/Generic3.png")} count={25} tooltip="$13"/>\n    <InventorySlot sprite={useBaseUrl("/img/Generic4.png")} count="$13" tooltip={25}/>\n    <InventorySlot sprite={useBaseUrl("/img/Generic5.png")} tooltip={25}/>\n    <InventorySlot sprite={useBaseUrl("/img/Generic6.png")}/>\n  </InventoryRow>\n</InventoryGrid>\n')),(0,i.kt)(a.Z,{mdxType:"BrowserWindow"},(0,i.kt)(p.Z,{mdxType:"InventoryGrid"},(0,i.kt)(c.Z,{sprite:(0,l.Z)("/img/Generic.png"),mdxType:"InventorySlot"}),(0,i.kt)(c.Z,{sprite:(0,l.Z)("/img/Generic2.png"),count:25,mdxType:"InventorySlot"}),(0,i.kt)(s.Z,{mdxType:"InventoryRow"},(0,i.kt)(c.Z,{sprite:(0,l.Z)("/img/Generic3.png"),count:25,tooltip:"$13",mdxType:"InventorySlot"}),(0,i.kt)(c.Z,{sprite:(0,l.Z)("/img/Generic4.png"),count:"$13",tooltip:25,mdxType:"InventorySlot"}),(0,i.kt)(c.Z,{sprite:(0,l.Z)("/img/Generic5.png"),tooltip:25,mdxType:"InventorySlot"}),(0,i.kt)(c.Z,{sprite:(0,l.Z)("/img/Generic6.png"),mdxType:"InventorySlot"})))),(0,i.kt)("h2",{id:"minimum-width-height"},"Minimum width and height"),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-jsx"},'<InventoryGrid width={5} height={3}>\n  <InventorySlot sprite={useBaseUrl("/img/Generic.png")}/>\n  <InventorySlot sprite={useBaseUrl("/img/Generic2.png")} count={25}/>\n  <InventoryRow>\n    <InventorySlot sprite={useBaseUrl("/img/Generic3.png")} count={25} tooltip="$13"/>\n    <InventorySlot sprite={useBaseUrl("/img/Generic4.png")} count="$13" tooltip={25}/>\n    <InventorySlot sprite={useBaseUrl("/img/Generic5.png")} tooltip={25}/>\n    <InventorySlot sprite={useBaseUrl("/img/Generic6.png")}/>\n  </InventoryRow>\n</InventoryGrid>\n')),(0,i.kt)(a.Z,{mdxType:"BrowserWindow"},(0,i.kt)(p.Z,{width:5,height:3,mdxType:"InventoryGrid"},(0,i.kt)(c.Z,{sprite:(0,l.Z)("/img/Generic.png"),mdxType:"InventorySlot"}),(0,i.kt)(c.Z,{sprite:(0,l.Z)("/img/Generic2.png"),count:25,mdxType:"InventorySlot"}),(0,i.kt)(s.Z,{mdxType:"InventoryRow"},(0,i.kt)(c.Z,{sprite:(0,l.Z)("/img/Generic3.png"),count:25,tooltip:"$13",mdxType:"InventorySlot"}),(0,i.kt)(c.Z,{sprite:(0,l.Z)("/img/Generic4.png"),count:"$13",tooltip:25,mdxType:"InventorySlot"}),(0,i.kt)(c.Z,{sprite:(0,l.Z)("/img/Generic5.png"),tooltip:25,mdxType:"InventorySlot"}),(0,i.kt)(c.Z,{sprite:(0,l.Z)("/img/Generic6.png"),mdxType:"InventorySlot"})))),(0,i.kt)("h2",{id:"onclick-event"},"onClick event"),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-jsx"},'<InventoryGrid interactive={true} onClick={e => console.log(e)}>\n  <InventorySlot sprite={useBaseUrl("/img/Generic.png")}/>\n  <InventorySlot sprite={useBaseUrl("/img/Generic2.png")} count={25}/>\n  <InventoryRow>\n    <InventorySlot sprite={useBaseUrl("/img/Generic3.png")} count={25} tooltip="$13"/>\n    <InventorySlot sprite={useBaseUrl("/img/Generic4.png")} count="$13" tooltip={25}/>\n    <InventorySlot sprite={useBaseUrl("/img/Generic5.png")} tooltip={25}/>\n    <InventorySlot sprite={useBaseUrl("/img/Generic6.png")}/>\n  </InventoryRow>\n</InventoryGrid>\n')),(0,i.kt)(a.Z,{mdxType:"BrowserWindow"},(0,i.kt)(p.Z,{interactive:!0,onClick:function(e){return console.log(e)},mdxType:"InventoryGrid"},(0,i.kt)(c.Z,{sprite:(0,l.Z)("/img/Generic.png"),mdxType:"InventorySlot"}),(0,i.kt)(c.Z,{sprite:(0,l.Z)("/img/Generic2.png"),count:25,mdxType:"InventorySlot"}),(0,i.kt)(s.Z,{mdxType:"InventoryRow"},(0,i.kt)(c.Z,{sprite:(0,l.Z)("/img/Generic3.png"),count:25,tooltip:"$13",mdxType:"InventorySlot"}),(0,i.kt)(c.Z,{sprite:(0,l.Z)("/img/Generic4.png"),count:"$13",tooltip:25,mdxType:"InventorySlot"}),(0,i.kt)(c.Z,{sprite:(0,l.Z)("/img/Generic5.png"),tooltip:25,mdxType:"InventorySlot"}),(0,i.kt)(c.Z,{sprite:(0,l.Z)("/img/Generic6.png"),mdxType:"InventorySlot"})))),(0,i.kt)("div",{className:"admonition admonition-note alert alert--secondary"},(0,i.kt)("div",{parentName:"div",className:"admonition-heading"},(0,i.kt)("h5",{parentName:"div"},(0,i.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,i.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,i.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.3 5.69a.942.942 0 0 1-.28-.7c0-.28.09-.52.28-.7.19-.18.42-.28.7-.28.28 0 .52.09.7.28.18.19.28.42.28.7 0 .28-.09.52-.28.7a1 1 0 0 1-.7.3c-.28 0-.52-.11-.7-.3zM8 7.99c-.02-.25-.11-.48-.31-.69-.2-.19-.42-.3-.69-.31H6c-.27.02-.48.13-.69.31-.2.2-.3.44-.31.69h1v3c.02.27.11.5.31.69.2.2.42.31.69.31h1c.27 0 .48-.11.69-.31.2-.19.3-.42.31-.69H8V7.98v.01zM7 2.3c-3.14 0-5.7 2.54-5.7 5.68 0 3.14 2.56 5.7 5.7 5.7s5.7-2.55 5.7-5.7c0-3.15-2.56-5.69-5.7-5.69v.01zM7 .98c3.86 0 7 3.14 7 7s-3.14 7-7 7-7-3.12-7-7 3.14-7 7-7z"}))),"note")),(0,i.kt)("div",{parentName:"div",className:"admonition-content"},(0,i.kt)("p",{parentName:"div"},"See the output in ",(0,i.kt)("strong",{parentName:"p"},"Developer Tools > Console"),"."))),(0,i.kt)("h2",{id:"interactive"},"Interactive"),(0,i.kt)("p",null,(0,i.kt)("inlineCode",{parentName:"p"},"interactive={true}")," makes all of the slots hoverable, and allows you to use ",(0,i.kt)("inlineCode",{parentName:"p"},"useSelector")," parameters."),(0,i.kt)("p",null,"To make slots selectable you'll have to assign ",(0,i.kt)("inlineCode",{parentName:"p"},"uid"),"s to them."),(0,i.kt)("div",{className:"admonition admonition-info alert alert--info"},(0,i.kt)("div",{parentName:"div",className:"admonition-heading"},(0,i.kt)("h5",{parentName:"div"},(0,i.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,i.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,i.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M7 2.3c3.14 0 5.7 2.56 5.7 5.7s-2.56 5.7-5.7 5.7A5.71 5.71 0 0 1 1.3 8c0-3.14 2.56-5.7 5.7-5.7zM7 1C3.14 1 0 4.14 0 8s3.14 7 7 7 7-3.14 7-7-3.14-7-7-7zm1 3H6v5h2V4zm0 6H6v2h2v-2z"}))),"info")),(0,i.kt)("div",{parentName:"div",className:"admonition-content"},(0,i.kt)("p",{parentName:"div"},(0,i.kt)("strong",{parentName:"p"},"See ",(0,i.kt)("a",{parentName:"strong",href:"../hooks/useSelector"},(0,i.kt)("inlineCode",{parentName:"a"},"useSelector"))," for more info.")))),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-jsx"},'<InventoryGrid interactive={true} defaultValues={["1", "3"]}\n  minChoices={1} maxChoices={3} lockChoices={true} onChange={e => console.log(e)}>\n  <InventorySlot uid="1" sprite={useBaseUrl("/img/Generic.png")}/>\n  <InventorySlot uid="2" sprite={useBaseUrl("/img/Generic2.png")} count={25}/>\n  <InventoryRow>\n    <InventorySlot uid="3" sprite={useBaseUrl("/img/Generic3.png")} count={25} tooltip="$13"/>\n    <InventorySlot uid="4" sprite={useBaseUrl("/img/Generic4.png")} count="$13" tooltip={25}/>\n    <InventorySlot uid="5" sprite={useBaseUrl("/img/Generic5.png")} tooltip={25}/>\n    <InventorySlot uid="6" sprite={useBaseUrl("/img/Generic6.png")}/>\n  </InventoryRow>\n</InventoryGrid>\n')),(0,i.kt)(a.Z,{mdxType:"BrowserWindow"},(0,i.kt)(p.Z,{interactive:!0,defaultValues:["1","3"],minChoices:1,maxChoices:3,lockChoices:!0,onChange:function(e){return console.log(e)},mdxType:"InventoryGrid"},(0,i.kt)(c.Z,{uid:"1",sprite:(0,l.Z)("/img/Generic.png"),mdxType:"InventorySlot"}),(0,i.kt)(c.Z,{uid:"2",sprite:(0,l.Z)("/img/Generic2.png"),count:25,mdxType:"InventorySlot"}),(0,i.kt)(s.Z,{mdxType:"InventoryRow"},(0,i.kt)(c.Z,{uid:"3",sprite:(0,l.Z)("/img/Generic3.png"),count:25,tooltip:"$13",mdxType:"InventorySlot"}),(0,i.kt)(c.Z,{uid:"4",sprite:(0,l.Z)("/img/Generic4.png"),count:"$13",tooltip:25,mdxType:"InventorySlot"}),(0,i.kt)(c.Z,{uid:"5",sprite:(0,l.Z)("/img/Generic5.png"),tooltip:25,mdxType:"InventorySlot"}),(0,i.kt)(c.Z,{uid:"6",sprite:(0,l.Z)("/img/Generic6.png"),mdxType:"InventorySlot"})))))}h.isMDXComponent=!0}}]);