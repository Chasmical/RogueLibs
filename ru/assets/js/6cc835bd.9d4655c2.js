"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[6256],{3905:(e,t,n)=>{n.d(t,{Zo:()=>u,kt:()=>d});var a=n(7294);function o(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function r(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var a=Object.getOwnPropertySymbols(e);t&&(a=a.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,a)}return n}function i(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?r(Object(n),!0).forEach((function(t){o(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):r(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function l(e,t){if(null==e)return{};var n,a,o=function(e,t){if(null==e)return{};var n,a,o={},r=Object.keys(e);for(a=0;a<r.length;a++)n=r[a],t.indexOf(n)>=0||(o[n]=e[n]);return o}(e,t);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(e);for(a=0;a<r.length;a++)n=r[a],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(o[n]=e[n])}return o}var c=a.createContext({}),s=function(e){var t=a.useContext(c),n=t;return e&&(n="function"==typeof e?e(t):i(i({},t),e)),n},u=function(e){var t=s(e.components);return a.createElement(c.Provider,{value:t},e.children)},m={inlineCode:"code",wrapper:function(e){var t=e.children;return a.createElement(a.Fragment,{},t)}},p=a.forwardRef((function(e,t){var n=e.components,o=e.mdxType,r=e.originalType,c=e.parentName,u=l(e,["components","mdxType","originalType","parentName"]),p=s(n),d=o,k=p["".concat(c,".").concat(d)]||p[d]||m[d]||r;return n?a.createElement(k,i(i({ref:t},u),{},{components:n})):a.createElement(k,i({ref:t},u))}));function d(e,t){var n=arguments,o=t&&t.mdxType;if("string"==typeof e||o){var r=n.length,i=new Array(r);i[0]=p;var l={};for(var c in t)hasOwnProperty.call(t,c)&&(l[c]=t[c]);l.originalType=e,l.mdxType="string"==typeof e?e:o,i[1]=l;for(var s=2;s<r;s++)i[s]=n[s];return a.createElement.apply(null,i)}return a.createElement.apply(null,n)}p.displayName="MDXCreateElement"},1016:(e,t,n)=>{n.d(t,{Z:()=>r});var a=n(7462),o=n(7294);function r(e){let{children:t,...n}=e;return o.createElement("div",(0,a.Z)({role:"tabpanel"},n),t)}},250:(e,t,n)=>{n.d(t,{Z:()=>m});var a=n(7294),o=n(7094),r=n(6010);const i="tabItem_V91s",l="tabItemActive_JsUu",c="tab_ntnM";const s=37,u=39;function m(e){const{lazy:t,defaultValue:n,values:m,groupId:p}=e,{tabGroupChoices:d,setTabGroupChoices:k}=(0,o.U)(),[v,h]=(0,a.useState)(n),N=a.Children.toArray(e.children),g=[];if(null!=p){const e=d[p];null!=e&&e!==v&&m.some((t=>t.value===e))&&h(e)}const f=e=>{const t=e.currentTarget,n=g.indexOf(t),a=m[n].value;h(a),null!=p&&(k(p,a),setTimeout((()=>{(function(e){const{top:t,left:n,bottom:a,right:o}=e.getBoundingClientRect(),{innerHeight:r,innerWidth:i}=window;return t>=0&&o<=i&&a<=r&&n>=0})(t)||(t.scrollIntoView({block:"center",behavior:"smooth"}),t.classList.add(l),setTimeout((()=>t.classList.remove(l)),2e3))}),150))},b=e=>{let t;switch(e.keyCode){case u:{const n=g.indexOf(e.target)+1;t=g[n]||g[0];break}case s:{const n=g.indexOf(e.target)-1;t=g[n]||g[g.length-1];break}default:return}t.focus()},y=(e,t)=>t.value===e||t.values&&-1!=t.values.indexOf(e);return a.createElement("div",{className:"tabs-container"},a.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:"tabs"},m.map((e=>{let{value:t,label:n}=e;return a.createElement("li",{role:"tab",tabIndex:v===t?0:-1,"aria-selected":v===t,className:(0,r.Z)("tabs__item",i,{"tabs__item--active":v===t}),key:t,ref:e=>e&&g.push(e),onKeyDown:b,onFocus:f,onClick:f},n)}))),t?a.cloneElement(N.find((e=>y(v,e.props))),{className:c}):a.createElement("div",null,N.map(((e,t)=>a.cloneElement(e,{key:t,hidden:!y(v,e.props),className:c})))),a.createElement("br",null))}},3704:(e,t,n)=>{n.r(t),n.d(t,{assets:()=>c,contentTitle:()=>i,default:()=>m,frontMatter:()=>r,metadata:()=>l,toc:()=>s});var a=n(7462),o=(n(7294),n(3905));n(250),n(1016),n(4996);const r={},i="\u041a\u0430\u0441\u0442\u043e\u043c\u043d\u044b\u0435 \u0440\u0430\u0437\u0431\u043b\u043e\u043a\u0438\u0440\u043e\u0432\u043a\u0438",l={unversionedId:"dev/unlocks/custom-unlocks",id:"dev/unlocks/custom-unlocks",title:"\u041a\u0430\u0441\u0442\u043e\u043c\u043d\u044b\u0435 \u0440\u0430\u0437\u0431\u043b\u043e\u043a\u0438\u0440\u043e\u0432\u043a\u0438",description:"\u041a\u043b\u0430\u0441\u0441 UnlockWrapper",source:"@site/i18n/ru/docusaurus-plugin-content-docs/current/dev/unlocks/custom-unlocks.mdx",sourceDirName:"dev/unlocks",slug:"/dev/unlocks/custom-unlocks",permalink:"/RogueLibs/ru/docs/dev/unlocks/custom-unlocks",draft:!1,editUrl:"https://github.com/SugarBarrel/RogueLibs/edit/main/website/docs/dev/unlocks/custom-unlocks.mdx",tags:[],version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"\u0421\u043e\u0437\u0434\u0430\u0451\u043c \u043a\u0430\u0441\u0442\u043e\u043c\u043d\u043e\u0435 \u0432\u0437\u0430\u0438\u043c\u043e\u0434\u0435\u0439\u0441\u0442\u0432\u0438\u0435",permalink:"/RogueLibs/ru/docs/dev/interactions/create-interaction"},next:{title:"\u041f\u0435\u0440\u0435\u0433\u0440\u0443\u0437\u043a\u0430 \u043f\u043e\u0432\u0435\u0434\u0435\u043d\u0438\u044f \u043f\u043e \u0443\u043c\u043e\u043b\u0447\u0430\u043d\u0438\u044e",permalink:"/RogueLibs/ru/docs/dev/unlocks/overriding-behavior"}},c={},s=[{value:"\u041a\u043b\u0430\u0441\u0441 <code>UnlockWrapper</code>",id:"unlockwrapper",level:2},{value:"\u041a\u043b\u0430\u0441\u0441 <code>DisplayedUnlock</code>",id:"displayedunlock",level:2},{value:"\u041a\u043b\u0430\u0441\u0441\u044b \u0440\u0430\u0437\u0431\u043b\u043e\u043a\u0438\u0440\u043e\u0432\u043e\u043a",id:"unlock-classes",level:2},{value:"\u0418\u043d\u0438\u0446\u0438\u0430\u043b\u0438\u0437\u0430\u0446\u0438\u044f",id:"initialization",level:2}],u={toc:s};function m(e){let{components:t,...n}=e;return(0,o.kt)("wrapper",(0,a.Z)({},u,n,{components:t,mdxType:"MDXLayout"}),(0,o.kt)("h1",{id:"\u043a\u0430\u0441\u0442\u043e\u043c\u043d\u044b\u0435-\u0440\u0430\u0437\u0431\u043b\u043e\u043a\u0438\u0440\u043e\u0432\u043a\u0438"},"\u041a\u0430\u0441\u0442\u043e\u043c\u043d\u044b\u0435 \u0440\u0430\u0437\u0431\u043b\u043e\u043a\u0438\u0440\u043e\u0432\u043a\u0438"),(0,o.kt)("h2",{id:"unlockwrapper"},"\u041a\u043b\u0430\u0441\u0441 ",(0,o.kt)("inlineCode",{parentName:"h2"},"UnlockWrapper")),(0,o.kt)("p",null,"\u0412\u0441\u0435 \u0440\u0430\u0437\u0431\u043b\u043e\u043a\u0438\u0440\u043e\u0432\u043a\u0438 \u0432 \u0438\u0433\u0440\u0435 \u043e\u0431\u0451\u0440\u043d\u0443\u0442\u044b \u0432 \u0431\u043e\u043b\u0435\u0435 \u0433\u0438\u0431\u043a\u0438\u0439 \u043a\u043b\u0430\u0441\u0441 - ",(0,o.kt)("inlineCode",{parentName:"p"},"UnlockWrapper"),"."),(0,o.kt)("p",null,(0,o.kt)("inlineCode",{parentName:"p"},"UnlockWrapper")," \u043f\u0440\u0435\u0434\u043e\u0441\u0442\u0430\u0432\u043b\u044f\u0435\u0442 \u043c\u0435\u0442\u043e\u0434\u044b \u0434\u043b\u044f \u043f\u043e\u043b\u0443\u0447\u0435\u043d\u0438\u044f \u043d\u0430\u0437\u0432\u0430\u043d\u0438\u044f, \u043e\u043f\u0438\u0441\u0430\u043d\u0438\u044f, \u0438\u0437\u043e\u0431\u0440\u0430\u0436\u0435\u043d\u0438\u044f \u0440\u0430\u0437\u0431\u043b\u043e\u043a\u0438\u0440\u043e\u0432\u043a\u0438 \u043f\u0440\u043e\u0447\u0438\u0435 \u0448\u0442\u0443\u043a\u0438."),(0,o.kt)("div",{className:"admonition admonition-caution alert alert--warning"},(0,o.kt)("div",{parentName:"div",className:"admonition-heading"},(0,o.kt)("h5",{parentName:"div"},(0,o.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,o.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"16",height:"16",viewBox:"0 0 16 16"},(0,o.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M8.893 1.5c-.183-.31-.52-.5-.887-.5s-.703.19-.886.5L.138 13.499a.98.98 0 0 0 0 1.001c.193.31.53.501.886.501h13.964c.367 0 .704-.19.877-.5a1.03 1.03 0 0 0 .01-1.002L8.893 1.5zm.133 11.497H6.987v-2.003h2.039v2.003zm0-3.004H6.987V5.987h2.039v4.006z"}))),"caution")),(0,o.kt)("div",{parentName:"div",className:"admonition-content"},(0,o.kt)("p",{parentName:"div"},"\u0412\u0430\u043c \u043d\u0430\u0432\u0435\u0440\u043d\u043e\u0435 \u043d\u0435 \u0441\u0442\u043e\u0438\u0442 \u0440\u0435\u0430\u043b\u0438\u0437\u043e\u0432\u044b\u0432\u0430\u0442\u044c ",(0,o.kt)("inlineCode",{parentName:"p"},"UnlockWrapper")," \u043d\u0430\u043f\u0440\u044f\u043c\u0443\u044e. \u0418\u0441\u043f\u043e\u043b\u044c\u0437\u0443\u0439\u0442\u0435 \u043a\u043b\u0430\u0441\u0441\u044b, \u043e\u043f\u0438\u0441\u0430\u043d\u043d\u044b\u0435 \u043f\u043e\u0437\u0436\u0435 \u043d\u0430 \u0441\u0442\u0440\u0430\u043d\u0438\u0446\u0435."))),(0,o.kt)("h2",{id:"displayedunlock"},"\u041a\u043b\u0430\u0441\u0441 ",(0,o.kt)("inlineCode",{parentName:"h2"},"DisplayedUnlock")),(0,o.kt)("p",null,(0,o.kt)("inlineCode",{parentName:"p"},"DisplayedUnlock")," \u043d\u0430\u0441\u043b\u0435\u0434\u0443\u0435\u0442 \u043e\u0442 \u043a\u043b\u0430\u0441\u0441\u0430 ",(0,o.kt)("inlineCode",{parentName:"p"},"UnlockWrapper"),". \u041e\u043d \u043f\u0440\u0435\u0434\u043e\u0441\u0442\u0430\u0432\u043b\u044f\u0435\u0442 \u043c\u0435\u0442\u043e\u0434\u044b \u0434\u043b\u044f \u043e\u0442\u043e\u0431\u0440\u0430\u0436\u0435\u043d\u0438\u044f \u0440\u0430\u0437\u0431\u043b\u043e\u043a\u0438\u0440\u043e\u0432\u043a\u0438 \u0432 \u043c\u0435\u043d\u044e."),(0,o.kt)("div",{className:"admonition admonition-caution alert alert--warning"},(0,o.kt)("div",{parentName:"div",className:"admonition-heading"},(0,o.kt)("h5",{parentName:"div"},(0,o.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,o.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"16",height:"16",viewBox:"0 0 16 16"},(0,o.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M8.893 1.5c-.183-.31-.52-.5-.887-.5s-.703.19-.886.5L.138 13.499a.98.98 0 0 0 0 1.001c.193.31.53.501.886.501h13.964c.367 0 .704-.19.877-.5a1.03 1.03 0 0 0 .01-1.002L8.893 1.5zm.133 11.497H6.987v-2.003h2.039v2.003zm0-3.004H6.987V5.987h2.039v4.006z"}))),"caution")),(0,o.kt)("div",{parentName:"div",className:"admonition-content"},(0,o.kt)("p",{parentName:"div"},"\u0412\u0430\u043c \u043d\u0430\u0432\u0435\u0440\u043d\u043e\u0435 \u043d\u0435 \u0441\u0442\u043e\u0438\u0442 \u0440\u0435\u0430\u043b\u0438\u0437\u043e\u0432\u044b\u0432\u0430\u0442\u044c ",(0,o.kt)("inlineCode",{parentName:"p"},"DisplayedUnlock")," \u043d\u0430\u043f\u0440\u044f\u043c\u0443\u044e. \u0418\u0441\u043f\u043e\u043b\u044c\u0437\u0443\u0439\u0442\u0435 \u043a\u043b\u0430\u0441\u0441\u044b, \u043e\u043f\u0438\u0441\u0430\u043d\u043d\u044b\u0435 \u043f\u043e\u0437\u0436\u0435 \u043d\u0430 \u0441\u0442\u0440\u0430\u043d\u0438\u0446\u0435."))),(0,o.kt)("h2",{id:"unlock-classes"},"\u041a\u043b\u0430\u0441\u0441\u044b \u0440\u0430\u0437\u0431\u043b\u043e\u043a\u0438\u0440\u043e\u0432\u043e\u043a"),(0,o.kt)("p",null,"RogueLibs \u043f\u0440\u0435\u0434\u043e\u0441\u0442\u0430\u0432\u043b\u044f\u0435\u0442 \u0441\u043b\u0435\u0434\u0443\u044e\u0449\u0438\u0435 \u043a\u043b\u0430\u0441\u0441\u044b, \u043e\u0442 \u043a\u043e\u0442\u043e\u0440\u044b\u0445 \u0432\u044b \u043c\u043e\u0436\u0435\u0442\u0435 \u043d\u0430\u0441\u043b\u0435\u0434\u043e\u0432\u0430\u0442\u044c:"),(0,o.kt)("ul",null,(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("inlineCode",{parentName:"li"},"ItemUnlock")," - \u0434\u043b\u044f \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u043e\u0432;"),(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("inlineCode",{parentName:"li"},"AbilityUnlock")," - \u0434\u043b\u044f \u0441\u043f\u043e\u0441\u043e\u0431\u043d\u043e\u0441\u0442\u0435\u0439;"),(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("inlineCode",{parentName:"li"},"TraitUnlock")," - \u0434\u043b\u044f \u043e\u0441\u043e\u0431\u0435\u043d\u043d\u043e\u0441\u0442\u0435\u0439;"),(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("inlineCode",{parentName:"li"},"MutatorUnlock")," - \u0434\u043b\u044f \u043c\u0443\u0442\u0430\u0442\u043e\u0440\u043e\u0432;"),(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("inlineCode",{parentName:"li"},"AgentUnlock")," - \u0434\u043b\u044f \u043f\u0435\u0440\u0441\u043e\u043d\u0430\u0436\u0435\u0439;"),(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("inlineCode",{parentName:"li"},"BigQuestUnlock")," - \u0434\u043b\u044f \u0411\u043e\u043b\u044c\u0448\u0438\u0445 \u041a\u0432\u0435\u0441\u0442\u043e\u0432 \u043f\u0435\u0440\u0441\u043e\u043d\u0430\u0436\u0435\u0439;"),(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("inlineCode",{parentName:"li"},"ExtraUnlock")," - \u0434\u043b\u044f \u0434\u043e\u0441\u0442\u0438\u0436\u0435\u043d\u0438\u0439 \u0438 \u043f\u0440\u043e\u0447\u0435\u0433\u043e;"),(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("inlineCode",{parentName:"li"},"FloorUnlock")," - \u0434\u043b\u044f \u044d\u0442\u0430\u0436\u0435\u0439;")),(0,o.kt)("div",{className:"admonition admonition-note alert alert--secondary"},(0,o.kt)("div",{parentName:"div",className:"admonition-heading"},(0,o.kt)("h5",{parentName:"div"},(0,o.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,o.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,o.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.3 5.69a.942.942 0 0 1-.28-.7c0-.28.09-.52.28-.7.19-.18.42-.28.7-.28.28 0 .52.09.7.28.18.19.28.42.28.7 0 .28-.09.52-.28.7a1 1 0 0 1-.7.3c-.28 0-.52-.11-.7-.3zM8 7.99c-.02-.25-.11-.48-.31-.69-.2-.19-.42-.3-.69-.31H6c-.27.02-.48.13-.69.31-.2.2-.3.44-.31.69h1v3c.02.27.11.5.31.69.2.2.42.31.69.31h1c.27 0 .48-.11.69-.31.2-.19.3-.42.31-.69H8V7.98v.01zM7 2.3c-3.14 0-5.7 2.54-5.7 5.68 0 3.14 2.56 5.7 5.7 5.7s5.7-2.55 5.7-5.7c0-3.15-2.56-5.69-5.7-5.69v.01zM7 .98c3.86 0 7 3.14 7 7s-3.14 7-7 7-7-3.12-7-7 3.14-7 7-7z"}))),"note")),(0,o.kt)("div",{parentName:"div",className:"admonition-content"},(0,o.kt)("p",{parentName:"div"},"\u0415\u0441\u0442\u044c \u0435\u0449\u0451 \u043d\u0435\u0441\u043a\u043e\u043b\u044c\u043a\u043e \u043a\u043b\u0430\u0441\u0441\u043e\u0432, \u043d\u043e \u043e\u043d\u0438 \u0432 RogueLibs \u0442\u043e\u043b\u044c\u043a\u043e \u0440\u0430\u0434\u0438 \u0441\u043e\u0432\u043c\u0435\u0441\u0442\u0438\u043c\u043e\u0441\u0442\u0438."))),(0,o.kt)("h2",{id:"initialization"},"\u0418\u043d\u0438\u0446\u0438\u0430\u043b\u0438\u0437\u0430\u0446\u0438\u044f"),(0,o.kt)("p",null,"\u0412\u044b \u043c\u043e\u0436\u0435\u0442\u0435 \u0438\u043d\u0438\u0446\u0438\u0430\u043b\u0438\u0437\u0438\u0440\u043e\u0432\u0430\u0442\u044c \u0441\u0432\u043e\u0438 \u0440\u0430\u0437\u0431\u043b\u043e\u043a\u0438\u0440\u043e\u0432\u043a\u0438 \u0441\u043b\u0435\u0434\u0443\u044e\u0449\u0438\u043c \u043e\u0431\u0440\u0430\u0437\u043e\u043c:"),(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyCustomItem.cs"',title:'"MyCustomItem.cs"'},'public class MyCustomItem : CustomItem\n{\n    [RLSetup]\n    public static void Setup()\n    {\n        RogueLibs.CreateCustomItem<MyCustomItem>()\n            .WithName(new CustomNameInfo("My Custom Item"))\n            .WithDescription(new CustomNameInfo("My Custom Item is very cool and does a lot of great stuff"))\n            .WithSprite(Properties.Resources.MyCustomItem)\n            // highlight-next-line\n            .WithUnlock(new ItemUnlock\n            {\n                UnlockCost = 10,\n                CharacterCreationCost = 5,\n                LoadoutCost = 4,\n            });\n    }\n}\n')),(0,o.kt)("p",null,"\u0418\u043b\u0438 \u0432\u044b \u043c\u043e\u0436\u0435\u0442\u0435 \u0438\u043d\u0438\u0446\u0438\u0430\u043b\u0438\u0437\u0438\u0440\u043e\u0432\u0430\u0442\u044c \u0438\u0445 \u043d\u0430\u043f\u0440\u044f\u043c\u0443\u044e (\u043a\u0430\u043a \u0432 \u0441\u043b\u0443\u0447\u0430\u0435 \u043c\u0443\u0442\u0430\u0442\u043e\u0440\u043e\u0432):"),(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-csharp"},'RogueLibs.CreateCustomUnlock(new MutatorUnlock("MyMutator"))\n    .WithName(new CustomNameInfo("Mutator Name"))\n    .WithDescription(new CustomNameInfo("Mutator Description"));\n')))}m.isMDXComponent=!0}}]);