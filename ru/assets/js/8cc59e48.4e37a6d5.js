"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[1213],{3905:(e,t,r)=>{r.d(t,{Zo:()=>c,kt:()=>d});var n=r(7294);function a(e,t,r){return t in e?Object.defineProperty(e,t,{value:r,enumerable:!0,configurable:!0,writable:!0}):e[t]=r,e}function o(e,t){var r=Object.keys(e);if(Object.getOwnPropertySymbols){var n=Object.getOwnPropertySymbols(e);t&&(n=n.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),r.push.apply(r,n)}return r}function s(e){for(var t=1;t<arguments.length;t++){var r=null!=arguments[t]?arguments[t]:{};t%2?o(Object(r),!0).forEach((function(t){a(e,t,r[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(r)):o(Object(r)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(r,t))}))}return e}function i(e,t){if(null==e)return{};var r,n,a=function(e,t){if(null==e)return{};var r,n,a={},o=Object.keys(e);for(n=0;n<o.length;n++)r=o[n],t.indexOf(r)>=0||(a[r]=e[r]);return a}(e,t);if(Object.getOwnPropertySymbols){var o=Object.getOwnPropertySymbols(e);for(n=0;n<o.length;n++)r=o[n],t.indexOf(r)>=0||Object.prototype.propertyIsEnumerable.call(e,r)&&(a[r]=e[r])}return a}var l=n.createContext({}),u=function(e){var t=n.useContext(l),r=t;return e&&(r="function"==typeof e?e(t):s(s({},t),e)),r},c=function(e){var t=u(e.components);return n.createElement(l.Provider,{value:t},e.children)},p={inlineCode:"code",wrapper:function(e){var t=e.children;return n.createElement(n.Fragment,{},t)}},m=n.forwardRef((function(e,t){var r=e.components,a=e.mdxType,o=e.originalType,l=e.parentName,c=i(e,["components","mdxType","originalType","parentName"]),m=u(r),d=a,g=m["".concat(l,".").concat(d)]||m[d]||p[d]||o;return r?n.createElement(g,s(s({ref:t},c),{},{components:r})):n.createElement(g,s({ref:t},c))}));function d(e,t){var r=arguments,a=t&&t.mdxType;if("string"==typeof e||a){var o=r.length,s=new Array(o);s[0]=m;var i={};for(var l in t)hasOwnProperty.call(t,l)&&(i[l]=t[l]);i.originalType=e,i.mdxType="string"==typeof e?e:a,s[1]=i;for(var u=2;u<o;u++)s[u]=r[u];return n.createElement.apply(null,s)}return n.createElement.apply(null,r)}m.displayName="MDXCreateElement"},1016:(e,t,r)=>{r.d(t,{Z:()=>o});var n=r(7462),a=r(7294);function o(e){let{children:t,...r}=e;return a.createElement("div",(0,n.Z)({role:"tabpanel"},r),t)}},250:(e,t,r)=>{r.d(t,{Z:()=>p});var n=r(7294),a=r(7094),o=r(6010);const s="tabItem_V91s",i="tabItemActive_JsUu",l="tab_ntnM";const u=37,c=39;function p(e){const{lazy:t,defaultValue:r,values:p,groupId:m}=e,{tabGroupChoices:d,setTabGroupChoices:g}=(0,a.U)(),[f,y]=(0,n.useState)(r),h=n.Children.toArray(e.children),b=[];if(null!=m){const e=d[m];null!=e&&e!==f&&p.some((t=>t.value===e))&&y(e)}const k=e=>{const t=e.currentTarget,r=b.indexOf(t),n=p[r].value;y(n),null!=m&&(g(m,n),setTimeout((()=>{(function(e){const{top:t,left:r,bottom:n,right:a}=e.getBoundingClientRect(),{innerHeight:o,innerWidth:s}=window;return t>=0&&a<=s&&n<=o&&r>=0})(t)||(t.scrollIntoView({block:"center",behavior:"smooth"}),t.classList.add(i),setTimeout((()=>t.classList.remove(i)),2e3))}),150))},v=e=>{let t;switch(e.keyCode){case c:{const r=b.indexOf(e.target)+1;t=b[r]||b[0];break}case u:{const r=b.indexOf(e.target)-1;t=b[r]||b[b.length-1];break}default:return}t.focus()},S=(e,t)=>t.value===e||t.values&&-1!=t.values.indexOf(e);return n.createElement("div",{className:"tabs-container"},n.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:"tabs"},p.map((e=>{let{value:t,label:r}=e;return n.createElement("li",{role:"tab",tabIndex:f===t?0:-1,"aria-selected":f===t,className:(0,o.Z)("tabs__item",s,{"tabs__item--active":f===t}),key:t,ref:e=>e&&b.push(e),onKeyDown:v,onFocus:k,onClick:k},r)}))),t?n.cloneElement(h.find((e=>S(f,e.props))),{className:l}):n.createElement("div",null,h.map(((e,t)=>n.cloneElement(e,{key:t,hidden:!S(f,e.props),className:l})))),n.createElement("br",null))}},555:(e,t,r)=>{r.r(t),r.d(t,{assets:()=>c,contentTitle:()=>l,default:()=>d,frontMatter:()=>i,metadata:()=>u,toc:()=>p});var n=r(7462),a=(r(7294),r(3905)),o=r(250),s=r(1016);const i={},l="useStorageArray",u={unversionedId:"site/hooks/useStorageArray",id:"site/hooks/useStorageArray",title:"useStorageArray",description:"useStorageArray is used to store strings in the browser's local storage.",source:"@site/docs/site/hooks/useStorageArray.mdx",sourceDirName:"site/hooks",slug:"/site/hooks/useStorageArray",permalink:"/RogueLibs/ru/docs/site/hooks/useStorageArray",draft:!1,editUrl:"https://github.com/SugarBarrel/RogueLibs/edit/main/website/docs/site/hooks/useStorageArray.mdx",tags:[],version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"useStorage",permalink:"/RogueLibs/ru/docs/site/hooks/useStorage"}},c={},p=[{value:"Signature",id:"signature",level:2},{value:"Usage",id:"usage",level:2}],m={toc:p};function d(e){let{components:t,...r}=e;return(0,a.kt)("wrapper",(0,n.Z)({},m,r,{components:t,mdxType:"MDXLayout"}),(0,a.kt)("h1",{id:"usestoragearray"},(0,a.kt)("inlineCode",{parentName:"h1"},"useStorageArray")),(0,a.kt)("p",null,(0,a.kt)("inlineCode",{parentName:"p"},"useStorageArray")," is used to store strings in the browser's local storage.",(0,a.kt)("br",{parentName:"p"}),"\n","It also synchronizes all instances using the same storage slot."),(0,a.kt)("admonition",{type:"info"},(0,a.kt)("p",{parentName:"admonition"},"It works just like ",(0,a.kt)("a",{parentName:"p",href:"./useStorage"},(0,a.kt)("inlineCode",{parentName:"a"},"useStorage"))," but with string arrays instead of single strings.",(0,a.kt)("br",{parentName:"p"}),"\n","It joins the stored strings with a semicolon (",(0,a.kt)("inlineCode",{parentName:"p"},";"),"), like this: ",(0,a.kt)("inlineCode",{parentName:"p"},"value1;value2;value3"),".")),(0,a.kt)("h2",{id:"signature"},"Signature"),(0,a.kt)("pre",null,(0,a.kt)("code",{parentName:"pre",className:"language-ts"},"function (\n  slotName: string | null, // name of the storage slot to use\n  defaultValues?: string[] | (() => string[] | undefined), // default values of the storage slot\n  onChange?: (values: string[]) => void // change event handler\n): [\n    string[], // current values\n    React.Dispatch<React.SetStateAction<string[]>> // function to set the values\n  ]\n")),(0,a.kt)("h2",{id:"usage"},"Usage"),(0,a.kt)("admonition",{type:"info"},(0,a.kt)("p",{parentName:"admonition"},"If ",(0,a.kt)("inlineCode",{parentName:"p"},"slotName")," is ",(0,a.kt)("inlineCode",{parentName:"p"},"null"),", the hook works just like a ",(0,a.kt)("inlineCode",{parentName:"p"},"useState"),".")),(0,a.kt)(o.Z,{defaultValue:"ts",values:[{value:"ts",label:"TypeScript"},{value:"js",label:"JavaScript"}],mdxType:"Tabs"},(0,a.kt)(s.Z,{value:"ts",mdxType:"TabItem"},(0,a.kt)("pre",null,(0,a.kt)("code",{parentName:"pre",className:"language-ts"},'import useStorageArray from "../hooks/useStorageArray";\n\nexport default function ({/* your props */}: Props) {\n\n  const [values, setValues] = useStorageArray("my.storage.slot", []);\n\n  /* ... */\n}\n'))),(0,a.kt)(s.Z,{value:"js",mdxType:"TabItem"},(0,a.kt)("pre",null,(0,a.kt)("code",{parentName:"pre",className:"language-js"},'import useStorageArray from "../hooks/useStorageArray";\n\nexport default function ({/* your props */}) {\n\n  const [values, setValues] = useStorageArray("my.storage.slot", []);\n\n  /* ... */\n}\n')))),(0,a.kt)("admonition",{type:"caution"},(0,a.kt)("p",{parentName:"admonition"},"The values are read from the local storage in an ",(0,a.kt)("inlineCode",{parentName:"p"},"useEffect")," hook, so, on the first render, the values will be the default ones.")))}d.isMDXComponent=!0}}]);