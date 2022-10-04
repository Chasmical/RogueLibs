"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[5497],{3905:(e,t,n)=>{n.d(t,{Zo:()=>a,kt:()=>y});var o=n(7294);function r(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function i(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var o=Object.getOwnPropertySymbols(e);t&&(o=o.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,o)}return n}function l(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?i(Object(n),!0).forEach((function(t){r(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):i(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function c(e,t){if(null==e)return{};var n,o,r=function(e,t){if(null==e)return{};var n,o,r={},i=Object.keys(e);for(o=0;o<i.length;o++)n=i[o],t.indexOf(n)>=0||(r[n]=e[n]);return r}(e,t);if(Object.getOwnPropertySymbols){var i=Object.getOwnPropertySymbols(e);for(o=0;o<i.length;o++)n=i[o],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(r[n]=e[n])}return r}var p=o.createContext({}),s=function(e){var t=o.useContext(p),n=t;return e&&(n="function"==typeof e?e(t):l(l({},t),e)),n},a=function(e){var t=s(e.components);return o.createElement(p.Provider,{value:t},e.children)},u={inlineCode:"code",wrapper:function(e){var t=e.children;return o.createElement(o.Fragment,{},t)}},d=o.forwardRef((function(e,t){var n=e.components,r=e.mdxType,i=e.originalType,p=e.parentName,a=c(e,["components","mdxType","originalType","parentName"]),d=s(n),y=r,m=d["".concat(p,".").concat(y)]||d[y]||u[y]||i;return n?o.createElement(m,l(l({ref:t},a),{},{components:n})):o.createElement(m,l({ref:t},a))}));function y(e,t){var n=arguments,r=t&&t.mdxType;if("string"==typeof e||r){var i=n.length,l=new Array(i);l[0]=d;var c={};for(var p in t)hasOwnProperty.call(t,p)&&(c[p]=t[p]);c.originalType=e,c.mdxType="string"==typeof e?e:r,l[1]=c;for(var s=2;s<i;s++)l[s]=n[s];return o.createElement.apply(null,l)}return o.createElement.apply(null,n)}d.displayName="MDXCreateElement"},296:(e,t,n)=>{n.d(t,{Z:()=>c});var o=n(7294),r=n(4774),i=n(6095);const l="container_lzUp";function c(e){let{items:t,children:n,height:c,width:p,onClick:s,interactive:a,...u}=e,d=function(e,t,n,r){let l=[],c=[];const p=e=>{if(r)for(let t=c.length;t<r;t++)c.push({hoverable:!1});s(e)},s=e=>{l.push({items:c,type:e||"normal"}),c=[]};if(e)for(let o of e)if(Array.isArray(o)){c.length>0&&p();for(let e of o)c.push(e);p()}else c.push(o),c.length===r&&p();c.length>0&&p();for(let u of o.Children.toArray(t)){var a;let e=u,t=null==e||null==(a=e.props)?void 0:a.mdxType;if("InventorySlot"===t)c.push({...e.props}),c.length===r&&p();else if("InventoryRow"===t){c.length>0&&p();let t=(0,i.F)(e.props.items,e.props.children,e.props.width||r);c.push(...t),s(e.props.type)}}if(c.length>0&&p(),n)for(let o=l.length;o<n;o++){for(let e=0;e<(r||1);e++)c.push({hoverable:!1});p()}return l}(t,n,c,p),y=[];for(let o of d)for(let e of o.items)y.push(e.uid);u.group&&(u.group=`inventory.${u.group}`);const[m,v]=(0,r.Z)(y,u);return o.createElement("div",{className:l},d.map(((e,t)=>{for(let n of e.items)if(a&&void 0===n.hoverable&&(n.hoverable=!0),n.uid){let e=m.includes(n.uid),t=v.isLocked(n.uid);e?n.type="selected":t&&(n.type="locked"),t&&(n.cantClick=!0)}return o.createElement(i.Z,{key:t,type:e.type,items:e.items,onClick:e=>((e,t,n)=>{a&&n&&v.toggle(n),s&&s({uid:n,row:e,column:t})})(t,e.index,e.uid)})})))}},6095:(e,t,n)=>{n.d(t,{Z:()=>u,F:()=>a});var o=n(7462),r=n(7294),i=n(4774),l=n(6010),c=n(5880);const p="row_nRD2",s="toolbar_sl59";function a(e,t,n){let o=e||[];for(let l of r.Children.toArray(t)){var i;let e=l;"InventorySlot"===(null==e||null==(i=e.props)?void 0:i.mdxType)&&o.push({...e.props})}if(n)for(let r=o.length;r<n;r++)o.push({hoverable:!1});return o}function u(e){let{items:t,children:n,width:u,type:d,onClick:y,interactive:m,...v}=e,f=a(t,n,u);v.group&&(v.group=`inventory.${v.group}`);const[g,h]=(0,i.Z)(f.map((e=>e.uid)),v);return r.createElement("div",{className:(0,l.Z)(p,"toolbar"==d&&s)},f.map(((e,t)=>{if(m&&void 0===e.hoverable&&(e.hoverable=!0),e.uid){let t=g.includes(e.uid),n=h.isLocked(e.uid);t?e.type="selected":n&&(e.type="locked"),n&&(e.cantClick=!0)}return"toolbar"==d&&(e.tooltip=t+1,e.tooltipColor=void 0),r.createElement(c.Z,(0,o.Z)({key:t},e,{onClick:()=>{return n=t,o=e.uid,m&&o&&h.toggle(o),void(y&&y({uid:o,index:n}));var n,o}}))})))}},5880:(e,t,n)=>{n.d(t,{Z:()=>l});var o=n(7294),r=n(6010);const i={container:"container_ek75",cursorLocked:"cursorLocked_H61i",normal:"normal_n5ah",hoverable:"hoverable_F5EM",selected:"selected_mneN",locked:"locked_H8Qp",sprite:"sprite_ZRUo",tooltip:"tooltip_QxcU",count:"count_Z8Fk"};function l(e){let{sprite:t,tooltip:n,tooltipColor:l,count:c,countColor:p,hoverable:s,cantClick:a,type:u="normal",onClick:d}=e;return o.createElement("div",{onClick:d,className:(0,r.Z)(i.container,a&&i.cursorLocked,u&&i[u],s&&i.hoverable)},t&&o.createElement("img",{key:"sprite",className:i.sprite,src:t}),n&&o.createElement("span",{key:"tooltip",className:i.tooltip,style:{color:l||"#FFED00"}},n),c&&o.createElement("span",{key:"count",className:i.count,style:{color:p||"#FFFFFF"}},c))}},4774:(e,t,n)=>{n.d(t,{Z:()=>i});var o=n(7294);const r=o.createContext({});function i(e,t){let{defaultValues:n,minChoices:i,maxChoices:l,lockChoices:c,group:p,onChange:s}=t,a=null!=i?i:0,u=null!=l?l:1;-1==u&&(u=1/0);const[d,y]=function(e,t,n){const i=(0,o.useContext)(r),[l,c]=(0,o.useState)((()=>("function"==typeof t&&(t=t()),t??[]))),p=t=>{if(t.slotName==e){let e=t.value?t.value.split(";"):[];c(e),n&&n(e)}};return(0,o.useEffect)((()=>null==e?()=>{}:(i.subscribe(p),()=>i.unsubscribe(p))),[]),[l,t=>{"function"==typeof t&&(t=t(l)),null!=e?null!=t?i.set(e,t.join(";")):i.delete(e):(null===t&&(t=[]),c(t),n&&n(t))}]}(p??null,(()=>{if("function"==typeof n&&(n=n()),void 0===n){if(n=[],e){let t=e.filter((e=>void 0!==e)),o=Math.min(t.length,a);for(let e=0;e<o;e++)n.push(t[e])}}else Array.isArray(n)||(n=[n]);if(n.length<a||n.length>u)throw new Error(`Invalid default values count: ${a} \u2264 ${n.length} \u2264 ${u}`);if(c&&a==u)throw new Error("Cannot lock choices when Min and Max choices are equal.");return n}),(e=>s&&s(e))),m=e=>{if(d.includes(e))return;if(c&&d.length>=u)return;for(;d.length>=u;)d.shift();let t=d.concat(e);y(t)},v=e=>{let t=d.indexOf(e);if(-1==t)return;if(d.length<=a)return;let n=d.slice();n.splice(t,1),y(n)};return[d,{add:m,remove:v,toggle:e=>{d.includes(e)?v(e):m(e)},set:e=>{if((e=e.filter(((e,t,n)=>n.indexOf(e)==t))).length!=d.length||!e.every(((e,t)=>d.indexOf(e)==t))){if(e.length<a||e.length>u)throw new Error(`Invalid default values count: ${a} \u2264 ${e.length} \u2264 ${u}`);y(e)}},isLocked:e=>d.includes(e)?d.length==a:!!c&&d.length==u}]}},1985:(e,t,n)=>{n.r(t),n.d(t,{assets:()=>d,contentTitle:()=>a,default:()=>v,frontMatter:()=>s,metadata:()=>u,toc:()=>y});var o=n(7462),r=(n(7294),n(3905)),i=n(4996),l=n(5880),c=n(6095),p=n(296);const s={},a="Components Index",u={unversionedId:"site/index",id:"site/index",title:"Components Index",description:"Want to add some cool SoR-styled components to your site?",source:"@site/docs/site/index.mdx",sourceDirName:"site",slug:"/site/",permalink:"/RogueLibs/ru/docs/site/",draft:!1,editUrl:"https://github.com/SugarBarrel/RogueLibs/edit/main/website/docs/site/index.mdx",tags:[],version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"Introduction",permalink:"/RogueLibs/ru/docs/site/intro"},next:{title:"InventorySlot",permalink:"/RogueLibs/ru/docs/site/components/InventorySlot"}},d={},y=[{value:"<code>InventorySlot</code>",id:"inventoryslot",level:3},{value:"<code>InventoryRow</code>",id:"inventoryrow",level:3},{value:"<code>InventoryGrid</code>",id:"inventorygrid",level:3}],m={toc:y};function v(e){let{components:t,...n}=e;return(0,r.kt)("wrapper",(0,o.Z)({},m,n,{components:t,mdxType:"MDXLayout"}),(0,r.kt)("h1",{id:"components-index"},"Components Index"),(0,r.kt)("p",null,"Want to add some cool SoR-styled components to your site?"),(0,r.kt)("h3",{id:"inventoryslot"},(0,r.kt)("a",{parentName:"h3",href:"./components/InventorySlot"},(0,r.kt)("inlineCode",{parentName:"a"},"InventorySlot"))),(0,r.kt)(l.Z,{hoverable:!0,type:"normal",mdxType:"InventorySlot"}),(0,r.kt)(l.Z,{hoverable:!0,type:"selected",mdxType:"InventorySlot"}),(0,r.kt)(l.Z,{hoverable:!0,type:"locked",mdxType:"InventorySlot"}),(0,r.kt)("br",null),(0,r.kt)("br",null),(0,r.kt)(l.Z,{hoverable:!0,type:"normal",sprite:(0,i.Z)("/img/Generic.png"),mdxType:"InventorySlot"}),(0,r.kt)(l.Z,{hoverable:!0,type:"selected",sprite:(0,i.Z)("/img/Generic2.png"),mdxType:"InventorySlot"}),(0,r.kt)(l.Z,{hoverable:!0,type:"locked",sprite:(0,i.Z)("/img/Generic3.png"),mdxType:"InventorySlot"}),(0,r.kt)("h3",{id:"inventoryrow"},(0,r.kt)("a",{parentName:"h3",href:"./components/InventoryRow"},(0,r.kt)("inlineCode",{parentName:"a"},"InventoryRow"))),(0,r.kt)(c.Z,{interactive:!0,mdxType:"InventoryRow"},(0,r.kt)(l.Z,{uid:"1",sprite:(0,i.Z)("/img/Generic.png"),mdxType:"InventorySlot"}),(0,r.kt)(l.Z,{uid:"2",sprite:(0,i.Z)("/img/Generic2.png"),count:25,mdxType:"InventorySlot"}),(0,r.kt)(l.Z,{uid:"3",sprite:(0,i.Z)("/img/Generic3.png"),count:25,tooltip:"$13",mdxType:"InventorySlot"}),(0,r.kt)(l.Z,{uid:"4",sprite:(0,i.Z)("/img/Generic4.png"),count:"$13",tooltip:25,mdxType:"InventorySlot"}),(0,r.kt)(l.Z,{uid:"5",sprite:(0,i.Z)("/img/Generic5.png"),tooltip:25,mdxType:"InventorySlot"}),(0,r.kt)(l.Z,{uid:"6",sprite:(0,i.Z)("/img/Generic6.png"),mdxType:"InventorySlot"})),(0,r.kt)("br",null),(0,r.kt)("br",null),(0,r.kt)(c.Z,{type:"toolbar",interactive:!0,mdxType:"InventoryRow"},(0,r.kt)(l.Z,{uid:"1",sprite:(0,i.Z)("/img/Generic.png"),mdxType:"InventorySlot"}),(0,r.kt)(l.Z,{uid:"2",sprite:(0,i.Z)("/img/Generic2.png"),count:25,mdxType:"InventorySlot"}),(0,r.kt)(l.Z,{uid:"3",sprite:(0,i.Z)("/img/Generic3.png"),count:25,tooltip:"$13",mdxType:"InventorySlot"}),(0,r.kt)(l.Z,{uid:"4",sprite:(0,i.Z)("/img/Generic4.png"),count:"$13",tooltip:25,mdxType:"InventorySlot"}),(0,r.kt)(l.Z,{uid:"5",sprite:(0,i.Z)("/img/Generic5.png"),tooltip:25,mdxType:"InventorySlot"}),(0,r.kt)(l.Z,{uid:"6",sprite:(0,i.Z)("/img/Generic6.png"),mdxType:"InventorySlot"})),(0,r.kt)("h3",{id:"inventorygrid"},(0,r.kt)("a",{parentName:"h3",href:"./components/InventoryGrid"},(0,r.kt)("inlineCode",{parentName:"a"},"InventoryGrid"))),(0,r.kt)(p.Z,{interactive:!0,width:4,mdxType:"InventoryGrid"},(0,r.kt)(l.Z,{uid:"1",sprite:(0,i.Z)("/img/Generic.png"),mdxType:"InventorySlot"}),(0,r.kt)(l.Z,{uid:"2",sprite:(0,i.Z)("/img/Generic2.png"),count:25,mdxType:"InventorySlot"}),(0,r.kt)(c.Z,{mdxType:"InventoryRow"}),(0,r.kt)(c.Z,{type:"toolbar",mdxType:"InventoryRow"},(0,r.kt)(l.Z,{uid:"3",sprite:(0,i.Z)("/img/Generic3.png"),count:25,tooltip:"$13",mdxType:"InventorySlot"}),(0,r.kt)(l.Z,{uid:"4",sprite:(0,i.Z)("/img/Generic4.png"),count:"$13",tooltip:25,mdxType:"InventorySlot"}),(0,r.kt)(l.Z,{uid:"5",sprite:(0,i.Z)("/img/Generic5.png"),tooltip:25,mdxType:"InventorySlot"}),(0,r.kt)(l.Z,{uid:"6",sprite:(0,i.Z)("/img/Generic6.png"),mdxType:"InventorySlot"}))))}v.isMDXComponent=!0}}]);