"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[8320],{3905:(e,t,n)=>{n.d(t,{Zo:()=>c,kt:()=>p});var a=n(7294);function r(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function i(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var a=Object.getOwnPropertySymbols(e);t&&(a=a.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,a)}return n}function o(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?i(Object(n),!0).forEach((function(t){r(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):i(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function s(e,t){if(null==e)return{};var n,a,r=function(e,t){if(null==e)return{};var n,a,r={},i=Object.keys(e);for(a=0;a<i.length;a++)n=i[a],t.indexOf(n)>=0||(r[n]=e[n]);return r}(e,t);if(Object.getOwnPropertySymbols){var i=Object.getOwnPropertySymbols(e);for(a=0;a<i.length;a++)n=i[a],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(r[n]=e[n])}return r}var l=a.createContext({}),m=function(e){var t=a.useContext(l),n=t;return e&&(n="function"==typeof e?e(t):o(o({},t),e)),n},c=function(e){var t=m(e.components);return a.createElement(l.Provider,{value:t},e.children)},u={inlineCode:"code",wrapper:function(e){var t=e.children;return a.createElement(a.Fragment,{},t)}},d=a.forwardRef((function(e,t){var n=e.components,r=e.mdxType,i=e.originalType,l=e.parentName,c=s(e,["components","mdxType","originalType","parentName"]),d=m(n),p=r,g=d["".concat(l,".").concat(p)]||d[p]||u[p]||i;return n?a.createElement(g,o(o({ref:t},c),{},{components:n})):a.createElement(g,o({ref:t},c))}));function p(e,t){var n=arguments,r=t&&t.mdxType;if("string"==typeof e||r){var i=n.length,o=new Array(i);o[0]=d;var s={};for(var l in t)hasOwnProperty.call(t,l)&&(s[l]=t[l]);s.originalType=e,s.mdxType="string"==typeof e?e:r,o[1]=s;for(var m=2;m<i;m++)o[m]=n[m];return a.createElement.apply(null,o)}return a.createElement.apply(null,n)}d.displayName="MDXCreateElement"},1016:(e,t,n)=>{n.d(t,{Z:()=>i});var a=n(7462),r=n(7294);function i(e){let{children:t,...n}=e;return r.createElement("div",(0,a.Z)({role:"tabpanel"},n),t)}},250:(e,t,n)=>{n.d(t,{Z:()=>u});var a=n(7294),r=n(7094),i=n(6010);const o="tabItem_V91s",s="tabItemActive_JsUu",l="tab_ntnM";const m=37,c=39;function u(e){const{lazy:t,defaultValue:n,values:u,groupId:d}=e,{tabGroupChoices:p,setTabGroupChoices:g}=(0,r.U)(),[v,f]=(0,a.useState)(n),N=a.Children.toArray(e.children),h=[];if(null!=d){const e=p[d];null!=e&&e!==v&&u.some((t=>t.value===e))&&f(e)}const b=e=>{const t=e.currentTarget,n=h.indexOf(t),a=u[n].value;f(a),null!=d&&(g(d,a),setTimeout((()=>{(function(e){const{top:t,left:n,bottom:a,right:r}=e.getBoundingClientRect(),{innerHeight:i,innerWidth:o}=window;return t>=0&&r<=o&&a<=i&&n>=0})(t)||(t.scrollIntoView({block:"center",behavior:"smooth"}),t.classList.add(s),setTimeout((()=>t.classList.remove(s)),2e3))}),150))},y=e=>{let t;switch(e.keyCode){case c:{const n=h.indexOf(e.target)+1;t=h[n]||h[0];break}case m:{const n=h.indexOf(e.target)-1;t=h[n]||h[h.length-1];break}default:return}t.focus()},k=(e,t)=>t.value===e||t.values&&-1!=t.values.indexOf(e);return a.createElement("div",{className:"tabs-container"},a.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:"tabs"},u.map((e=>{let{value:t,label:n}=e;return a.createElement("li",{role:"tab",tabIndex:v===t?0:-1,"aria-selected":v===t,className:(0,i.Z)("tabs__item",o,{"tabs__item--active":v===t}),key:t,ref:e=>e&&h.push(e),onKeyDown:y,onFocus:b,onClick:b},n)}))),t?a.cloneElement(N.find((e=>k(v,e.props))),{className:l}):a.createElement("div",null,N.map(((e,t)=>a.cloneElement(e,{key:t,hidden:!k(v,e.props),className:l})))),a.createElement("br",null))}},8019:(e,t,n)=>{n.r(t),n.d(t,{assets:()=>l,contentTitle:()=>o,default:()=>u,frontMatter:()=>i,metadata:()=>s,toc:()=>m});var a=n(7462),r=(n(7294),n(3905));n(250),n(1016),n(4996);const i={},o="Custom Name Providers",s={unversionedId:"dev/names/name-providers",id:"dev/names/name-providers",title:"Custom Name Providers",description:"If you have some kind of complicated naming strategy, then you might want to use INameProvider. This way you can control what strings are returned by NameDB.GetName in a more generic way. Just create a class implementing INameProvider and add it to RogueFramework.",source:"@site/docs/dev/names/name-providers.mdx",sourceDirName:"dev/names",slug:"/dev/names/name-providers",permalink:"/RogueLibs/docs/dev/names/name-providers",draft:!1,editUrl:"https://github.com/SugarBarrel/RogueLibs/edit/main/website/docs/dev/names/name-providers.mdx",tags:[],version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"Custom Languages*",permalink:"/RogueLibs/docs/dev/names/custom-languages"},next:{title:"Custom Sprites and Resources",permalink:"/RogueLibs/docs/dev/custom-sprites"}},l={},m=[],c={toc:m};function u(e){let{components:t,...n}=e;return(0,r.kt)("wrapper",(0,a.Z)({},c,n,{components:t,mdxType:"MDXLayout"}),(0,r.kt)("h1",{id:"custom-name-providers"},"Custom Name Providers"),(0,r.kt)("p",null,"If you have some kind of complicated naming strategy, then you might want to use ",(0,r.kt)("inlineCode",{parentName:"p"},"INameProvider"),". This way you can control what strings are returned by ",(0,r.kt)("inlineCode",{parentName:"p"},"NameDB.GetName")," in a more generic way. Just create a class implementing ",(0,r.kt)("inlineCode",{parentName:"p"},"INameProvider")," and add it to ",(0,r.kt)("inlineCode",{parentName:"p"},"RogueFramework"),"."),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyNameProvider.cs"',title:'"MyNameProvider.cs"'},'public class MyNameProvider : INameProvider\n{\n    public void GetName(string name, string type, ref string? result)\n    {\n        if (name.StartsWith("fake_"))\n        {\n            string sub = name.Substring("fake_".Length);\n            result = LanguageService.NameDB.GetName(sub, type);\n        }\n    }\n}\n')),(0,r.kt)("div",{className:"admonition admonition-note alert alert--secondary"},(0,r.kt)("div",{parentName:"div",className:"admonition-heading"},(0,r.kt)("h5",{parentName:"div"},(0,r.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,r.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,r.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.3 5.69a.942.942 0 0 1-.28-.7c0-.28.09-.52.28-.7.19-.18.42-.28.7-.28.28 0 .52.09.7.28.18.19.28.42.28.7 0 .28-.09.52-.28.7a1 1 0 0 1-.7.3c-.28 0-.52-.11-.7-.3zM8 7.99c-.02-.25-.11-.48-.31-.69-.2-.19-.42-.3-.69-.31H6c-.27.02-.48.13-.69.31-.2.2-.3.44-.31.69h1v3c.02.27.11.5.31.69.2.2.42.31.69.31h1c.27 0 .48-.11.69-.31.2-.19.3-.42.31-.69H8V7.98v.01zM7 2.3c-3.14 0-5.7 2.54-5.7 5.68 0 3.14 2.56 5.7 5.7 5.7s5.7-2.55 5.7-5.7c0-3.15-2.56-5.69-5.7-5.69v.01zM7 .98c3.86 0 7 3.14 7 7s-3.14 7-7 7-7-3.12-7-7 3.14-7 7-7z"}))),"note")),(0,r.kt)("div",{parentName:"div",className:"admonition-content"},(0,r.kt)("p",{parentName:"div"},"If the original ",(0,r.kt)("inlineCode",{parentName:"p"},"NameDB.GetName")," returned an error string (with ",(0,r.kt)("inlineCode",{parentName:"p"},"E_")," prefix), ",(0,r.kt)("inlineCode",{parentName:"p"},"result")," is set to ",(0,r.kt)("inlineCode",{parentName:"p"},"null"),"."))),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},"RogueFramework.NameProviders.Add(new MyNameProvider());\n")),(0,r.kt)("p",null,"Here's a more practical and useful example, that is already implemented in RogueLibs:"),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},'public class DialogueNameProvider : INameProvider\n{\n    public void GetName(string name, string type, ref string? result)\n    {\n        if (result is null && type == "Dialogue" && name.StartsWith("NA_"))\n        {\n            string sub = name.Substring("NA_".Length);\n            string newResult = LanguageService.NameDB.GetName(sub, type);\n            if (!newResult.StartsWith("E_")) result = newResult;\n        }\n    }\n}\n')),(0,r.kt)("p",null,"Normally, the game looks for dialogue names of the following format: ",(0,r.kt)("inlineCode",{parentName:"p"},"<AgentName>_<DialogueName>"),". If such a name doesn't exist, then ",(0,r.kt)("inlineCode",{parentName:"p"},"NA_<DialogueName>")," (NA - No Agent) is used instead. This name provider will also look for a name with just the dialogue name. This allows the developers to write dialogue names without that annoying ",(0,r.kt)("inlineCode",{parentName:"p"},"NA_")," prefix."))}u.isMDXComponent=!0}}]);