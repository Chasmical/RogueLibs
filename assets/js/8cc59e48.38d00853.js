"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[1213],{3905:(e,t,a)=>{a.d(t,{Zo:()=>c,kt:()=>d});var n=a(7294);function r(e,t,a){return t in e?Object.defineProperty(e,t,{value:a,enumerable:!0,configurable:!0,writable:!0}):e[t]=a,e}function o(e,t){var a=Object.keys(e);if(Object.getOwnPropertySymbols){var n=Object.getOwnPropertySymbols(e);t&&(n=n.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),a.push.apply(a,n)}return a}function s(e){for(var t=1;t<arguments.length;t++){var a=null!=arguments[t]?arguments[t]:{};t%2?o(Object(a),!0).forEach((function(t){r(e,t,a[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(a)):o(Object(a)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(a,t))}))}return e}function i(e,t){if(null==e)return{};var a,n,r=function(e,t){if(null==e)return{};var a,n,r={},o=Object.keys(e);for(n=0;n<o.length;n++)a=o[n],t.indexOf(a)>=0||(r[a]=e[a]);return r}(e,t);if(Object.getOwnPropertySymbols){var o=Object.getOwnPropertySymbols(e);for(n=0;n<o.length;n++)a=o[n],t.indexOf(a)>=0||Object.prototype.propertyIsEnumerable.call(e,a)&&(r[a]=e[a])}return r}var l=n.createContext({}),u=function(e){var t=n.useContext(l),a=t;return e&&(a="function"==typeof e?e(t):s(s({},t),e)),a},c=function(e){var t=u(e.components);return n.createElement(l.Provider,{value:t},e.children)},m={inlineCode:"code",wrapper:function(e){var t=e.children;return n.createElement(n.Fragment,{},t)}},p=n.forwardRef((function(e,t){var a=e.components,r=e.mdxType,o=e.originalType,l=e.parentName,c=i(e,["components","mdxType","originalType","parentName"]),p=u(a),d=r,g=p["".concat(l,".").concat(d)]||p[d]||m[d]||o;return a?n.createElement(g,s(s({ref:t},c),{},{components:a})):n.createElement(g,s({ref:t},c))}));function d(e,t){var a=arguments,r=t&&t.mdxType;if("string"==typeof e||r){var o=a.length,s=new Array(o);s[0]=p;var i={};for(var l in t)hasOwnProperty.call(t,l)&&(i[l]=t[l]);i.originalType=e,i.mdxType="string"==typeof e?e:r,s[1]=i;for(var u=2;u<o;u++)s[u]=a[u];return n.createElement.apply(null,s)}return n.createElement.apply(null,a)}p.displayName="MDXCreateElement"},1016:(e,t,a)=>{a.d(t,{Z:()=>o});var n=a(7462),r=a(7294);function o(e){let{children:t,...a}=e;return r.createElement("div",(0,n.Z)({role:"tabpanel"},a),t)}},250:(e,t,a)=>{a.d(t,{Z:()=>m});var n=a(7294),r=a(7094),o=a(6010);const s="tabItem_V91s",i="tabItemActive_JsUu",l="tab_ntnM";const u=37,c=39;function m(e){const{lazy:t,defaultValue:a,values:m,groupId:p}=e,{tabGroupChoices:d,setTabGroupChoices:g}=(0,r.U)(),[v,h]=(0,n.useState)(a),f=n.Children.toArray(e.children),k=[];if(null!=p){const e=d[p];null!=e&&e!==v&&m.some((t=>t.value===e))&&h(e)}const y=e=>{const t=e.currentTarget,a=k.indexOf(t),n=m[a].value;h(n),null!=p&&(g(p,n),setTimeout((()=>{(function(e){const{top:t,left:a,bottom:n,right:r}=e.getBoundingClientRect(),{innerHeight:o,innerWidth:s}=window;return t>=0&&r<=s&&n<=o&&a>=0})(t)||(t.scrollIntoView({block:"center",behavior:"smooth"}),t.classList.add(i),setTimeout((()=>t.classList.remove(i)),2e3))}),150))},b=e=>{let t;switch(e.keyCode){case c:{const a=k.indexOf(e.target)+1;t=k[a]||k[0];break}case u:{const a=k.indexOf(e.target)-1;t=k[a]||k[k.length-1];break}default:return}t.focus()},N=(e,t)=>t.value===e||t.values&&-1!=t.values.indexOf(e);return n.createElement("div",{className:"tabs-container"},n.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:"tabs"},m.map((e=>{let{value:t,label:a}=e;return n.createElement("li",{role:"tab",tabIndex:v===t?0:-1,"aria-selected":v===t,className:(0,o.Z)("tabs__item",s,{"tabs__item--active":v===t}),key:t,ref:e=>e&&k.push(e),onKeyDown:b,onFocus:y,onClick:y},a)}))),t?n.cloneElement(f.find((e=>N(v,e.props))),{className:l}):n.createElement("div",null,f.map(((e,t)=>n.cloneElement(e,{key:t,hidden:!N(v,e.props),className:l})))),n.createElement("br",null))}},555:(e,t,a)=>{a.r(t),a.d(t,{assets:()=>c,contentTitle:()=>l,default:()=>d,frontMatter:()=>i,metadata:()=>u,toc:()=>m});var n=a(7462),r=(a(7294),a(3905)),o=a(250),s=a(1016);const i={},l="useStorageArray",u={unversionedId:"site/hooks/useStorageArray",id:"site/hooks/useStorageArray",title:"useStorageArray",description:"useStorageArray is used to store strings in the browser's local storage.",source:"@site/docs/site/hooks/useStorageArray.mdx",sourceDirName:"site/hooks",slug:"/site/hooks/useStorageArray",permalink:"/RogueLibs/docs/site/hooks/useStorageArray",draft:!1,editUrl:"https://github.com/SugarBarrel/RogueLibs/edit/main/website/docs/site/hooks/useStorageArray.mdx",tags:[],version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"useStorage",permalink:"/RogueLibs/docs/site/hooks/useStorage"}},c={},m=[{value:"Signature",id:"signature",level:2},{value:"Usage",id:"usage",level:2}],p={toc:m};function d(e){let{components:t,...a}=e;return(0,r.kt)("wrapper",(0,n.Z)({},p,a,{components:t,mdxType:"MDXLayout"}),(0,r.kt)("h1",{id:"usestoragearray"},(0,r.kt)("inlineCode",{parentName:"h1"},"useStorageArray")),(0,r.kt)("p",null,(0,r.kt)("inlineCode",{parentName:"p"},"useStorageArray")," is used to store strings in the browser's local storage.",(0,r.kt)("br",{parentName:"p"}),"\n","It also synchronizes all instances using the same storage slot."),(0,r.kt)("div",{className:"admonition admonition-info alert alert--info"},(0,r.kt)("div",{parentName:"div",className:"admonition-heading"},(0,r.kt)("h5",{parentName:"div"},(0,r.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,r.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,r.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M7 2.3c3.14 0 5.7 2.56 5.7 5.7s-2.56 5.7-5.7 5.7A5.71 5.71 0 0 1 1.3 8c0-3.14 2.56-5.7 5.7-5.7zM7 1C3.14 1 0 4.14 0 8s3.14 7 7 7 7-3.14 7-7-3.14-7-7-7zm1 3H6v5h2V4zm0 6H6v2h2v-2z"}))),"info")),(0,r.kt)("div",{parentName:"div",className:"admonition-content"},(0,r.kt)("p",{parentName:"div"},"It works just like ",(0,r.kt)("a",{parentName:"p",href:"./useStorage"},(0,r.kt)("inlineCode",{parentName:"a"},"useStorage"))," but with string arrays instead of single strings.",(0,r.kt)("br",{parentName:"p"}),"\n","It joins the stored strings with a semicolon (",(0,r.kt)("inlineCode",{parentName:"p"},";"),"), like this: ",(0,r.kt)("inlineCode",{parentName:"p"},"value1;value2;value3"),"."))),(0,r.kt)("h2",{id:"signature"},"Signature"),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-ts"},"function (\n  slotName: string | null, // name of the storage slot to use\n  defaultValues?: string[] | (() => string[] | undefined), // default values of the storage slot\n  onChange?: (values: string[]) => void // change event handler\n): [\n    string[], // current values\n    React.Dispatch<React.SetStateAction<string[]>> // function to set the values\n  ]\n")),(0,r.kt)("h2",{id:"usage"},"Usage"),(0,r.kt)("div",{className:"admonition admonition-info alert alert--info"},(0,r.kt)("div",{parentName:"div",className:"admonition-heading"},(0,r.kt)("h5",{parentName:"div"},(0,r.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,r.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,r.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M7 2.3c3.14 0 5.7 2.56 5.7 5.7s-2.56 5.7-5.7 5.7A5.71 5.71 0 0 1 1.3 8c0-3.14 2.56-5.7 5.7-5.7zM7 1C3.14 1 0 4.14 0 8s3.14 7 7 7 7-3.14 7-7-3.14-7-7-7zm1 3H6v5h2V4zm0 6H6v2h2v-2z"}))),"info")),(0,r.kt)("div",{parentName:"div",className:"admonition-content"},(0,r.kt)("p",{parentName:"div"},"If ",(0,r.kt)("inlineCode",{parentName:"p"},"slotName")," is ",(0,r.kt)("inlineCode",{parentName:"p"},"null"),", the hook works just like a ",(0,r.kt)("inlineCode",{parentName:"p"},"useState"),"."))),(0,r.kt)(o.Z,{defaultValue:"ts",values:[{value:"ts",label:"TypeScript"},{value:"js",label:"JavaScript"}],mdxType:"Tabs"},(0,r.kt)(s.Z,{value:"ts",mdxType:"TabItem"},(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-ts"},'import useStorageArray from "../hooks/useStorageArray";\n\nexport default function ({/* your props */}: Props) {\n\n  const [values, setValues] = useStorageArray("my.storage.slot", []);\n\n  /* ... */\n}\n'))),(0,r.kt)(s.Z,{value:"js",mdxType:"TabItem"},(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-js"},'import useStorageArray from "../hooks/useStorageArray";\n\nexport default function ({/* your props */}) {\n\n  const [values, setValues] = useStorageArray("my.storage.slot", []);\n\n  /* ... */\n}\n')))),(0,r.kt)("div",{className:"admonition admonition-caution alert alert--warning"},(0,r.kt)("div",{parentName:"div",className:"admonition-heading"},(0,r.kt)("h5",{parentName:"div"},(0,r.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,r.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"16",height:"16",viewBox:"0 0 16 16"},(0,r.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M8.893 1.5c-.183-.31-.52-.5-.887-.5s-.703.19-.886.5L.138 13.499a.98.98 0 0 0 0 1.001c.193.31.53.501.886.501h13.964c.367 0 .704-.19.877-.5a1.03 1.03 0 0 0 .01-1.002L8.893 1.5zm.133 11.497H6.987v-2.003h2.039v2.003zm0-3.004H6.987V5.987h2.039v4.006z"}))),"caution")),(0,r.kt)("div",{parentName:"div",className:"admonition-content"},(0,r.kt)("p",{parentName:"div"},"The values are read from the local storage in an ",(0,r.kt)("inlineCode",{parentName:"p"},"useEffect")," hook, so, on the first render, the values will be the default ones."))))}d.isMDXComponent=!0}}]);