(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[9336],{8173:function(e,n,t){"use strict";function r(e,n){(null==n||n>e.length)&&(n=e.length);for(var t=0,r=new Array(n);t<n;t++)r[t]=e[t];return r}function o(e,n){var t="undefined"!=typeof Symbol&&e[Symbol.iterator]||e["@@iterator"];if(t)return(t=t.call(e)).next.bind(t);if(Array.isArray(e)||(t=function(e,n){if(e){if("string"==typeof e)return r(e,n);var t=Object.prototype.toString.call(e).slice(8,-1);return"Object"===t&&e.constructor&&(t=e.constructor.name),"Map"===t||"Set"===t?Array.from(e):"Arguments"===t||/^(?:Ui|I)nt(?:8|16|32)(?:Clamped)?Array$/.test(t)?r(e,n):void 0}}(e))||n&&e&&"number"==typeof e.length){t&&(e=t);var o=0;return function(){return o>=e.length?{done:!0}:{done:!1,value:e[o++]}}}throw new TypeError("Invalid attempt to iterate non-iterable instance.\nIn order to be iterable, non-array objects must have a [Symbol.iterator]() method.")}t.d(n,{Z:function(){return o}})},6902:function(e,n,t){"use strict";t.d(n,{Z:function(){return A}});var r=t(7294),o="browserWindow_1hK2",i="browserWindowHeader_3KQg",l="buttons_30GN",a="browserWindowAddressBar_3JC2",s="dot_1FQH",c="browserWindowMenuIcon_2SC9",u="bar_2gUh",p="browserWindowBody_2GyV";function A(e){var n=e.children,t=e.minHeight,A=e.url;return r.createElement("div",null,r.createElement("div",{className:o,style:{minHeight:t}},r.createElement("div",{className:i},r.createElement("div",{className:l},r.createElement("span",{className:s,style:{background:"#f25f58"}}),r.createElement("span",{className:s,style:{background:"#fbbe3c"}}),r.createElement("span",{className:s,style:{background:"#58cb42"}})),r.createElement("div",{className:a},A),r.createElement("div",{className:c},r.createElement("div",null,r.createElement("span",{className:u}),r.createElement("span",{className:u}),r.createElement("span",{className:u})))),r.createElement("div",{className:p},n)),r.createElement("br",null))}},9937:function(e,n,t){"use strict";t.d(n,{Z:function(){return u}});var r=t(9756),o=t(8173),i=t(7294),l=t(9763),a=t(7851),s="container_1tQ_",c=["items","children","height","width","onClick","interactive"];function u(e){for(var n,t=e.items,u=e.children,p=e.height,A=e.width,d=e.onClick,m=e.interactive,g=(0,r.Z)(e,c),v=function(e,n,t,r){var l=[],s=[],c=function(e){if(r)for(var n=s.length;n<r;n++)s.push({hoverable:!1});u(e)},u=function(e){l.push({items:s,type:e||"normal"}),s=[]};if(e)for(var p,A=(0,o.Z)(e);!(p=A()).done;){var d=p.value;if(Array.isArray(d)){s.length>0&&c();for(var m,g=(0,o.Z)(d);!(m=g()).done;){var v=m.value;s.push(v)}c()}else s.push(d),s.length===r&&c()}s.length>0&&c();for(var y,h=(0,o.Z)(i.Children.toArray(n));!(y=h()).done;){var f,k=y.value,I=null==k||null==(f=k.props)?void 0:f.mdxType;if("InventorySlot"===I)s.push(Object.assign({},k.props)),s.length===r&&c();else if("InventoryRow"===I){var w;s.length>0&&c();var S=(0,a.F)(k.props.items,k.props.children,k.props.width||r);(w=s).push.apply(w,S),u(k.props.type)}}if(s.length>0&&c(),t)for(var Z=l.length;Z<t;Z++){for(var N=0;N<(r||1);N++)s.push({hoverable:!1});c()}return l}(t,u,p,A),y=[],h=(0,o.Z)(v);!(n=h()).done;)for(var f,k=n.value,I=(0,o.Z)(k.items);!(f=I()).done;){var w=f.value;y.push(w.uid)}g.group&&(g.group="inventory."+g.group);var S=(0,l.Z)(y,g),Z=S[0],N=S[1],G=function(e,n,t){m&&t&&N.toggle(t),d&&d({uid:t,row:e,column:n})};return i.createElement("div",{className:s},v.map((function(e,n){for(var t,r=(0,o.Z)(e.items);!(t=r()).done;){var l=t.value;m&&void 0===l.hoverable&&(l.hoverable=!0),l.uid&&(Z.includes(l.uid)?l.type="selected":N.isLocked(l.uid)&&(l.type="locked"))}return i.createElement(a.Z,{key:n,type:e.type,items:e.items,onClick:function(e){return G(n,e.index,e.uid)}})})))}},7851:function(e,n,t){"use strict";t.d(n,{Z:function(){return m},F:function(){return d}});var r=t(2122),o=t(9756),i=t(8173),l=t(7294),a=t(9763),s=t(6010),c=t(3445),u="row_2biz",p="toolbar_1xeL",A=["items","children","width","type","onClick","interactive"];function d(e,n,t){for(var r,o=e||[],a=(0,i.Z)(l.Children.toArray(n));!(r=a()).done;){var s,c=r.value;"InventorySlot"===(null==c||null==(s=c.props)?void 0:s.mdxType)&&o.push(Object.assign({},c.props))}if(t)for(var u=o.length;u<t;u++)o.push({hoverable:!1});return o}function m(e){var n=e.items,t=e.children,i=e.width,m=e.type,g=e.onClick,v=e.interactive,y=(0,o.Z)(e,A),h=d(n,t,i);y.group&&(y.group="inventory."+y.group);var f=(0,a.Z)(h.map((function(e){return e.uid})),y),k=f[0],I=f[1],w=function(e,n){v&&n&&I.toggle(n),g&&g({uid:n,index:e})};return l.createElement("div",{className:(0,s.Z)(u,"toolbar"==m&&p)},h.map((function(e,n){var t;v&&e.uid&&(k.includes(e.uid)?(e.type="selected",t=!0):I.isLocked(e.uid)?(e.type="locked",t=!1):t=!0,void 0===e.hoverable&&(e.hoverable=t));return"toolbar"==m&&(e.tooltip=n+1,e.tooltipColor=void 0),l.createElement(c.Z,(0,r.Z)({key:n},e,{onClick:function(){return w(n,e.uid)}}))})))}},3445:function(e,n,t){"use strict";t.d(n,{Z:function(){return p}});var r=t(7294),o="container_NKD0",i="slot_PnA2",l="hoverslot_1P8J",a="sprite_26gF",s="tooltip_o3oT",c="count_2_VC",u={normal:["data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABQAAAAUCAYAAACNiR0NAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsEAAA7BAbiRa+0AAABISURBVDhPY2RgYDgAxFQDYAO5+fggPArB10+fEAays3JARMkEP3//ABvIBOVTDYwaSDkYNZByMGog5WDwG0ibAhbCpQZgYAAATvMP5IpH1cgAAAAASUVORK5CYII=","data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABQAAAAUCAYAAACNiR0NAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsEAAA7BAbiRa+0AAABBSURBVDhPY2QQEzvAQEUAMZCHG8qlEHz5imSgAB9UlEzw4RPYQCYol2pg1EDKwaiBlINRAykHg99AGhWwVAMMDACrSwzA8UjApAAAAABJRU5ErkJggg=="],selected:["data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABQAAAAUBAMAAAB/pwA+AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJUExURTAAAEcAAGcAAPKXzmMAAAAJcEhZcwAADsEAAA7BAbiRa+0AAAAcSURBVBjTY0ACjIJQIMDAqAQFQ4WJcDoMMDAAAELxE0Nwo5RlAAAAAElFTkSuQmCC","data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABQAAAAUBAMAAAB/pwA+AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJUExURR4AAC0AAEEAAC0LgTwAAAAJcEhZcwAADsEAAA7BAbiRa+0AAAAcSURBVBjTY0ACjIJQIMDAqAQFQ4WJcDoMMDAAAELxE0Nwo5RlAAAAAElFTkSuQmCC"],locked:["data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABQAAAAUCAYAAACNiR0NAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsEAAA7BAbiRa+0AAABHSURBVDhPY2RgYDgAxFQDYAO5GfggPArBV4ZPCAPZGTggomSCnww/wAYyQflUA6MGUg5GDaQcjBpIORj8BtKmgIVwqQEYGABr5AvkVu+rDAAAAABJRU5ErkJggg==","data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABQAAAAUCAYAAACNiR0NAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsEAAA7BAbiRa+0AAABHSURBVDhPYxRiEDvAQEUANpCTgRvKpQx8Z/iKMJCHgQ8qTB74wvAJbCATlE81MGog5WDUQMrBqIGUg8FvIG0KWCifCoCBAQBgVQysLF53iwAAAABJRU5ErkJggg=="]};function p(e){var n=e.sprite,t=e.tooltip,p=e.tooltipColor,A=e.count,d=e.countColor,m=e.hoverable,g=e.type,v=void 0===g?"normal":g,y=e.onClick,h=v?u[v]:[],f=h[0],k=h[1],I="locked"==v?.15625:1;return r.createElement("div",{className:o,onClick:y,style:{cursor:m?"pointer":"inherit"}},v&&r.createElement(r.Fragment,null,m&&r.createElement("img",{key:"hoverslot",width:80,className:l,src:k}),r.createElement("img",{key:"slot",width:80,className:i,src:f})),n&&r.createElement("img",{key:"sprite",style:{opacity:I},className:a,src:n}),t&&r.createElement("span",{key:"tooltip",className:s,style:{opacity:I,color:p||"#FFED00"}},t),A&&r.createElement("span",{key:"count",className:c,style:{opacity:I,color:d||"#FFFFFF"}},A))}},9763:function(e,n,t){"use strict";t.d(n,{Z:function(){return i}});var r=t(7294),o=t(5420);function i(e,n){var t=n.defaultValues,i=n.minChoices,l=n.maxChoices,a=n.lockChoices,s=n.group,c=n.onChange,u=null!=i?i:0,p=null!=l?l:1;-1==p&&(p=1/0);var A=function(e,n,t){var i=(0,r.useContext)(o.Do),l=(0,r.useState)((function(){var e;return"function"==typeof n&&(n=n()),null!=(e=n)?e:[]})),a=l[0],s=l[1],c=function(n){if(n.slotName==e){var r=n.value?n.value.split(";"):[];s(r),t&&t(r)}};return(0,r.useEffect)((function(){return null==e?function(){}:(i.subscribe(c),function(){return i.unsubscribe(c)})}),[]),[a,function(n){"function"==typeof n&&(n=n(a)),null!=e?null!=n?i.set(e,n.join(";")):i.delete(e):(null===n&&(n=[]),s(n),t&&t(n))}]}(null!=s?s:null,(function(){if("function"==typeof t&&(t=t()),void 0===t){if(t=[],e)for(var n=e.filter((function(e){return void 0!==e})),r=Math.min(n.length,u),o=0;o<r;o++)t.push(n[o])}else Array.isArray(t)||(t=[t]);if(t.length<u||t.length>p)throw new Error("Invalid default values count: "+u+" \u2264 "+t.length+" \u2264 "+p);if(a&&u==p)throw new Error("Cannot lock choices when Min and Max choices are equal.");return t}),(function(e){return c&&c(e)})),d=A[0],m=A[1],g=function(e){if(!(d.includes(e)||a&&d.length>=p)){for(;d.length>=p;)d.shift();var n=d.concat(e);m(n)}},v=function(e){var n=d.indexOf(e);if(-1!=n&&!(d.length<=u)){var t=d.slice();t.splice(n,1),m(t)}};return[d,{add:g,remove:v,toggle:function(e){d.includes(e)?v(e):g(e)},set:function(e){if((e=e.filter((function(e,n,t){return t.indexOf(e)==n}))).length!=d.length||!e.every((function(e,n){return d.indexOf(e)==n}))){if(e.length<u||e.length>p)throw new Error("Invalid default values count: "+u+" \u2264 "+e.length+" \u2264 "+p);m(e)}},isLocked:function(e){if(!a)return!1;var n=d.includes(e);return d.length==(n?u:p)}}]}},5420:function(e,n,t){"use strict";t.d(n,{Do:function(){return a},Xq:function(){return s}});var r=t(7294),o=t(3018),i="roguestorage.";function l(){var e=(0,r.useState)(null),n=e[0],t=e[1],l=(0,r.useState)([]),a=l[0],s=(l[1],(0,r.useCallback)((function(e,r){if(null!==n){n[e]=r,(0,o.WA)("roguestorage."+e).set(r),t(n);var i={slotName:e,value:r};a.forEach((function(e){return e(i)}))}}),[n]));return(0,r.useEffect)((function(){var e={};try{(0,o._f)().forEach((function(n){if(n.startsWith(i)){var t=n.substring(i.length),r=(0,o.WA)(n).get();null!==r&&(e[t]=r);var l={slotName:t,value:r};a.forEach((function(e){return e(l)}))}})),t(e)}catch(n){console.error(n)}console.log("Storage set")}),[]),{get:function(e){return t=e,null===n?null:null!=(r=n[t])?r:null;var t,r},set:function(e,n){return s(e,n)},delete:function(e){return function(e){if(null!==n){delete n[e],(0,o.WA)("roguestorage."+e).del(),t(n);var r={slotName:e,value:null};a.forEach((function(e){return e(r)}))}}(e)},subscribe:function(e){return a.push(e)},unsubscribe:function(e){var n=a.indexOf(e);-1!=n&&a.splice(n,1)}}}var a=r.createContext({});function s(e){var n=e.children,t=l();return r.createElement(a.Provider,{key:"storageProvider",value:t},n)}},4722:function(e,n,t){"use strict";t.r(n),t.d(n,{frontMatter:function(){return A},contentTitle:function(){return d},metadata:function(){return m},toc:function(){return g},default:function(){return y}});var r=t(2122),o=t(9756),i=(t(7294),t(3905)),l=t(4996),a=t(6902),s=t(3445),c=t(7851),u=t(9937),p=["components"],A={},d="InventoryGrid",m={unversionedId:"site/components/InventoryGrid",id:"site/components/InventoryGrid",isDocsHomePage:!1,title:"InventoryGrid",description:"Props",source:"@site/docs/site/components/InventoryGrid.mdx",sourceDirName:"site/components",slug:"/site/components/InventoryGrid",permalink:"/RogueLibs/docs/site/components/InventoryGrid",editUrl:"https://github.com/Abbysssal/RogueLibs/edit/main/website/docs/site/components/InventoryGrid.mdx",version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"InventoryRow",permalink:"/RogueLibs/docs/site/components/InventoryRow"},next:{title:"useSelector",permalink:"/RogueLibs/docs/site/hooks/useSelector"}},g=[{value:"Props",id:"props",children:[]},{value:"Typical usage",id:"typical-usage",children:[]},{value:"Minimum width and height",id:"minimum-width-height",children:[]},{value:"onClick event",id:"onclick-event",children:[]},{value:"Interactive",id:"interactive",children:[]}],v={toc:g};function y(e){var n=e.components,t=(0,o.Z)(e,p);return(0,i.kt)("wrapper",(0,r.Z)({},v,t,{components:n,mdxType:"MDXLayout"}),(0,i.kt)("h1",{id:"inventorygrid"},(0,i.kt)("inlineCode",{parentName:"h1"},"InventoryGrid")),(0,i.kt)("h2",{id:"props"},"Props"),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-ts"},"import { Props as SlotProps } from '@site/src/components/InventorySlot';\nimport { SelectorParameters } from '@site/src/components/hooks/useSelector';\n\nexport type Props = SelectorParameters & {\n  items?: (SlotProps | SlotProps[])[], // (not recommended) props of slots to display\n  children?: React.ReactNode,          // InventorySlot and InventoryRow children\n  height?: number, // minimum height of the grid\n  width?: number,  // minimum width of the grid\n\n  onClick?: (e: GridSlotArgs) => void, // click event handler\n  interactive?: boolean, // determines whether slots can be selected\n}\nexport type GridSlotArgs = {\n  uid: string | undefined, // Unique Identifier of the clicked slot\n  row: number,    // index of the clicked slot's row\n  column: number, // index of the clicked slot's column\n}\n")),(0,i.kt)("h2",{id:"typical-usage"},"Typical usage"),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-jsx"},'<InventoryGrid>\n  <InventorySlot sprite={useBaseUrl("/img/Generic.png")}/>\n  <InventorySlot sprite={useBaseUrl("/img/Generic2.png")} count={25}/>\n  <InventoryRow>\n    <InventorySlot sprite={useBaseUrl("/img/Generic3.png")} count={25} tooltip="$13"/>\n    <InventorySlot sprite={useBaseUrl("/img/Generic4.png")} count="$13" tooltip={25}/>\n    <InventorySlot sprite={useBaseUrl("/img/Generic5.png")} tooltip={25}/>\n    <InventorySlot sprite={useBaseUrl("/img/Generic6.png")}/>\n  </InventoryRow>\n</InventoryGrid>\n')),(0,i.kt)(a.Z,{mdxType:"BrowserWindow"},(0,i.kt)(u.Z,{mdxType:"InventoryGrid"},(0,i.kt)(s.Z,{sprite:(0,l.Z)("/img/Generic.png"),mdxType:"InventorySlot"}),(0,i.kt)(s.Z,{sprite:(0,l.Z)("/img/Generic2.png"),count:25,mdxType:"InventorySlot"}),(0,i.kt)(c.Z,{mdxType:"InventoryRow"},(0,i.kt)(s.Z,{sprite:(0,l.Z)("/img/Generic3.png"),count:25,tooltip:"$13",mdxType:"InventorySlot"}),(0,i.kt)(s.Z,{sprite:(0,l.Z)("/img/Generic4.png"),count:"$13",tooltip:25,mdxType:"InventorySlot"}),(0,i.kt)(s.Z,{sprite:(0,l.Z)("/img/Generic5.png"),tooltip:25,mdxType:"InventorySlot"}),(0,i.kt)(s.Z,{sprite:(0,l.Z)("/img/Generic6.png"),mdxType:"InventorySlot"})))),(0,i.kt)("h2",{id:"minimum-width-height"},"Minimum width and height"),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-jsx"},'<InventoryGrid width={5} height={3}>\n  <InventorySlot sprite={useBaseUrl("/img/Generic.png")}/>\n  <InventorySlot sprite={useBaseUrl("/img/Generic2.png")} count={25}/>\n  <InventoryRow>\n    <InventorySlot sprite={useBaseUrl("/img/Generic3.png")} count={25} tooltip="$13"/>\n    <InventorySlot sprite={useBaseUrl("/img/Generic4.png")} count="$13" tooltip={25}/>\n    <InventorySlot sprite={useBaseUrl("/img/Generic5.png")} tooltip={25}/>\n    <InventorySlot sprite={useBaseUrl("/img/Generic6.png")}/>\n  </InventoryRow>\n</InventoryGrid>\n')),(0,i.kt)(a.Z,{mdxType:"BrowserWindow"},(0,i.kt)(u.Z,{width:5,height:3,mdxType:"InventoryGrid"},(0,i.kt)(s.Z,{sprite:(0,l.Z)("/img/Generic.png"),mdxType:"InventorySlot"}),(0,i.kt)(s.Z,{sprite:(0,l.Z)("/img/Generic2.png"),count:25,mdxType:"InventorySlot"}),(0,i.kt)(c.Z,{mdxType:"InventoryRow"},(0,i.kt)(s.Z,{sprite:(0,l.Z)("/img/Generic3.png"),count:25,tooltip:"$13",mdxType:"InventorySlot"}),(0,i.kt)(s.Z,{sprite:(0,l.Z)("/img/Generic4.png"),count:"$13",tooltip:25,mdxType:"InventorySlot"}),(0,i.kt)(s.Z,{sprite:(0,l.Z)("/img/Generic5.png"),tooltip:25,mdxType:"InventorySlot"}),(0,i.kt)(s.Z,{sprite:(0,l.Z)("/img/Generic6.png"),mdxType:"InventorySlot"})))),(0,i.kt)("h2",{id:"onclick-event"},"onClick event"),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-jsx"},'<InventoryGrid interactive={true} onClick={e => console.log(e)}>\n  <InventorySlot sprite={useBaseUrl("/img/Generic.png")}/>\n  <InventorySlot sprite={useBaseUrl("/img/Generic2.png")} count={25}/>\n  <InventoryRow>\n    <InventorySlot sprite={useBaseUrl("/img/Generic3.png")} count={25} tooltip="$13"/>\n    <InventorySlot sprite={useBaseUrl("/img/Generic4.png")} count="$13" tooltip={25}/>\n    <InventorySlot sprite={useBaseUrl("/img/Generic5.png")} tooltip={25}/>\n    <InventorySlot sprite={useBaseUrl("/img/Generic6.png")}/>\n  </InventoryRow>\n</InventoryGrid>\n')),(0,i.kt)(a.Z,{mdxType:"BrowserWindow"},(0,i.kt)(u.Z,{interactive:!0,onClick:function(e){return console.log(e)},mdxType:"InventoryGrid"},(0,i.kt)(s.Z,{sprite:(0,l.Z)("/img/Generic.png"),mdxType:"InventorySlot"}),(0,i.kt)(s.Z,{sprite:(0,l.Z)("/img/Generic2.png"),count:25,mdxType:"InventorySlot"}),(0,i.kt)(c.Z,{mdxType:"InventoryRow"},(0,i.kt)(s.Z,{sprite:(0,l.Z)("/img/Generic3.png"),count:25,tooltip:"$13",mdxType:"InventorySlot"}),(0,i.kt)(s.Z,{sprite:(0,l.Z)("/img/Generic4.png"),count:"$13",tooltip:25,mdxType:"InventorySlot"}),(0,i.kt)(s.Z,{sprite:(0,l.Z)("/img/Generic5.png"),tooltip:25,mdxType:"InventorySlot"}),(0,i.kt)(s.Z,{sprite:(0,l.Z)("/img/Generic6.png"),mdxType:"InventorySlot"})))),(0,i.kt)("div",{className:"admonition admonition-note alert alert--secondary"},(0,i.kt)("div",{parentName:"div",className:"admonition-heading"},(0,i.kt)("h5",{parentName:"div"},(0,i.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,i.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,i.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.3 5.69a.942.942 0 0 1-.28-.7c0-.28.09-.52.28-.7.19-.18.42-.28.7-.28.28 0 .52.09.7.28.18.19.28.42.28.7 0 .28-.09.52-.28.7a1 1 0 0 1-.7.3c-.28 0-.52-.11-.7-.3zM8 7.99c-.02-.25-.11-.48-.31-.69-.2-.19-.42-.3-.69-.31H6c-.27.02-.48.13-.69.31-.2.2-.3.44-.31.69h1v3c.02.27.11.5.31.69.2.2.42.31.69.31h1c.27 0 .48-.11.69-.31.2-.19.3-.42.31-.69H8V7.98v.01zM7 2.3c-3.14 0-5.7 2.54-5.7 5.68 0 3.14 2.56 5.7 5.7 5.7s5.7-2.55 5.7-5.7c0-3.15-2.56-5.69-5.7-5.69v.01zM7 .98c3.86 0 7 3.14 7 7s-3.14 7-7 7-7-3.12-7-7 3.14-7 7-7z"}))),"note")),(0,i.kt)("div",{parentName:"div",className:"admonition-content"},(0,i.kt)("p",{parentName:"div"},"See the output in ",(0,i.kt)("strong",{parentName:"p"},"Developer Tools > Console"),"."))),(0,i.kt)("h2",{id:"interactive"},"Interactive"),(0,i.kt)("p",null,(0,i.kt)("inlineCode",{parentName:"p"},"interactive={true}")," makes all of the slots hoverable, and allows you to use ",(0,i.kt)("inlineCode",{parentName:"p"},"useSelector")," parameters."),(0,i.kt)("p",null,"To make slots selectable you'll have to assign ",(0,i.kt)("inlineCode",{parentName:"p"},"uid"),"s to them."),(0,i.kt)("div",{className:"admonition admonition-info alert alert--info"},(0,i.kt)("div",{parentName:"div",className:"admonition-heading"},(0,i.kt)("h5",{parentName:"div"},(0,i.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,i.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,i.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M7 2.3c3.14 0 5.7 2.56 5.7 5.7s-2.56 5.7-5.7 5.7A5.71 5.71 0 0 1 1.3 8c0-3.14 2.56-5.7 5.7-5.7zM7 1C3.14 1 0 4.14 0 8s3.14 7 7 7 7-3.14 7-7-3.14-7-7-7zm1 3H6v5h2V4zm0 6H6v2h2v-2z"}))),"info")),(0,i.kt)("div",{parentName:"div",className:"admonition-content"},(0,i.kt)("p",{parentName:"div"},(0,i.kt)("strong",{parentName:"p"},"See ",(0,i.kt)("a",{parentName:"strong",href:"../hooks/useSelector"},(0,i.kt)("inlineCode",{parentName:"a"},"useSelector"))," for more info.")))),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-jsx"},'<InventoryGrid interactive={true} defaultValues={["1", "3"]}\n  minChoices={1} maxChoices={3} lockChoices={true} onChange={e => console.log(e)}>\n  <InventorySlot uid="1" sprite={useBaseUrl("/img/Generic.png")}/>\n  <InventorySlot uid="2" sprite={useBaseUrl("/img/Generic2.png")} count={25}/>\n  <InventoryRow>\n    <InventorySlot uid="3" sprite={useBaseUrl("/img/Generic3.png")} count={25} tooltip="$13"/>\n    <InventorySlot uid="4" sprite={useBaseUrl("/img/Generic4.png")} count="$13" tooltip={25}/>\n    <InventorySlot uid="5" sprite={useBaseUrl("/img/Generic5.png")} tooltip={25}/>\n    <InventorySlot uid="6" sprite={useBaseUrl("/img/Generic6.png")}/>\n  </InventoryRow>\n</InventoryGrid>\n')),(0,i.kt)(a.Z,{mdxType:"BrowserWindow"},(0,i.kt)(u.Z,{interactive:!0,defaultValues:["1","3"],minChoices:1,maxChoices:3,lockChoices:!0,onChange:function(e){return console.log(e)},mdxType:"InventoryGrid"},(0,i.kt)(s.Z,{uid:"1",sprite:(0,l.Z)("/img/Generic.png"),mdxType:"InventorySlot"}),(0,i.kt)(s.Z,{uid:"2",sprite:(0,l.Z)("/img/Generic2.png"),count:25,mdxType:"InventorySlot"}),(0,i.kt)(c.Z,{mdxType:"InventoryRow"},(0,i.kt)(s.Z,{uid:"3",sprite:(0,l.Z)("/img/Generic3.png"),count:25,tooltip:"$13",mdxType:"InventorySlot"}),(0,i.kt)(s.Z,{uid:"4",sprite:(0,l.Z)("/img/Generic4.png"),count:"$13",tooltip:25,mdxType:"InventorySlot"}),(0,i.kt)(s.Z,{uid:"5",sprite:(0,l.Z)("/img/Generic5.png"),tooltip:25,mdxType:"InventorySlot"}),(0,i.kt)(s.Z,{uid:"6",sprite:(0,l.Z)("/img/Generic6.png"),mdxType:"InventorySlot"})))))}y.isMDXComponent=!0}}]);