"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[6256],{1666:(e,n,t)=>{t.r(n),t.d(n,{assets:()=>i,contentTitle:()=>l,default:()=>d,frontMatter:()=>s,metadata:()=>a,toc:()=>c});var r=t(5893),o=t(1151);t(5878),t(1016),t(4996);const s={},l="\u041a\u0430\u0441\u0442\u043e\u043c\u043d\u044b\u0435 \u0440\u0430\u0437\u0431\u043b\u043e\u043a\u0438\u0440\u043e\u0432\u043a\u0438",a={id:"dev/unlocks/custom-unlocks",title:"\u041a\u0430\u0441\u0442\u043e\u043c\u043d\u044b\u0435 \u0440\u0430\u0437\u0431\u043b\u043e\u043a\u0438\u0440\u043e\u0432\u043a\u0438",description:"\u041a\u043b\u0430\u0441\u0441 UnlockWrapper",source:"@site/i18n/ru/docusaurus-plugin-content-docs/current/dev/unlocks/custom-unlocks.mdx",sourceDirName:"dev/unlocks",slug:"/dev/unlocks/custom-unlocks",permalink:"/RogueLibs/ru/docs/dev/unlocks/custom-unlocks",draft:!1,unlisted:!1,editUrl:"https://github.com/Chasmical/RogueLibs/edit/main/website/docs/dev/unlocks/custom-unlocks.mdx",tags:[],version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"\u0421\u043e\u0437\u0434\u0430\u0451\u043c \u043a\u0430\u0441\u0442\u043e\u043c\u043d\u0443\u044e \u043a\u0430\u0442\u0430\u0441\u0442\u0440\u043e\u0444\u0443",permalink:"/RogueLibs/ru/docs/dev/disasters/create-disaster"},next:{title:"\u041f\u0435\u0440\u0435\u0433\u0440\u0443\u0437\u043a\u0430 \u043f\u043e\u0432\u0435\u0434\u0435\u043d\u0438\u044f \u043f\u043e \u0443\u043c\u043e\u043b\u0447\u0430\u043d\u0438\u044e",permalink:"/RogueLibs/ru/docs/dev/unlocks/configuring-unlocks"}},i={},c=[{value:"\u041a\u043b\u0430\u0441\u0441 <code>UnlockWrapper</code>",id:"unlockwrapper",level:2},{value:"\u041a\u043b\u0430\u0441\u0441 <code>DisplayedUnlock</code>",id:"displayedunlock",level:2},{value:"\u041a\u043b\u0430\u0441\u0441\u044b \u0440\u0430\u0437\u0431\u043b\u043e\u043a\u0438\u0440\u043e\u0432\u043e\u043a",id:"unlock-classes",level:2},{value:"\u0418\u043d\u0438\u0446\u0438\u0430\u043b\u0438\u0437\u0430\u0446\u0438\u044f",id:"initialization",level:2}];function u(e){const n={admonition:"admonition",code:"code",h1:"h1",h2:"h2",li:"li",p:"p",pre:"pre",ul:"ul",...(0,o.a)(),...e.components};return(0,r.jsxs)(r.Fragment,{children:[(0,r.jsx)(n.h1,{id:"\u043a\u0430\u0441\u0442\u043e\u043c\u043d\u044b\u0435-\u0440\u0430\u0437\u0431\u043b\u043e\u043a\u0438\u0440\u043e\u0432\u043a\u0438",children:"\u041a\u0430\u0441\u0442\u043e\u043c\u043d\u044b\u0435 \u0440\u0430\u0437\u0431\u043b\u043e\u043a\u0438\u0440\u043e\u0432\u043a\u0438"}),"\n","\n","\n",(0,r.jsxs)(n.h2,{id:"unlockwrapper",children:["\u041a\u043b\u0430\u0441\u0441 ",(0,r.jsx)(n.code,{children:"UnlockWrapper"})]}),"\n",(0,r.jsxs)(n.p,{children:["\u0412\u0441\u0435 \u0440\u0430\u0437\u0431\u043b\u043e\u043a\u0438\u0440\u043e\u0432\u043a\u0438 \u0432 \u0438\u0433\u0440\u0435 \u043e\u0431\u0451\u0440\u043d\u0443\u0442\u044b \u0432 \u0431\u043e\u043b\u0435\u0435 \u0433\u0438\u0431\u043a\u0438\u0439 \u043a\u043b\u0430\u0441\u0441 - ",(0,r.jsx)(n.code,{children:"UnlockWrapper"}),"."]}),"\n",(0,r.jsxs)(n.p,{children:[(0,r.jsx)(n.code,{children:"UnlockWrapper"})," \u043f\u0440\u0435\u0434\u043e\u0441\u0442\u0430\u0432\u043b\u044f\u0435\u0442 \u043c\u0435\u0442\u043e\u0434\u044b \u0434\u043b\u044f \u043f\u043e\u043b\u0443\u0447\u0435\u043d\u0438\u044f \u043d\u0430\u0437\u0432\u0430\u043d\u0438\u044f, \u043e\u043f\u0438\u0441\u0430\u043d\u0438\u044f, \u0438\u0437\u043e\u0431\u0440\u0430\u0436\u0435\u043d\u0438\u044f \u0440\u0430\u0437\u0431\u043b\u043e\u043a\u0438\u0440\u043e\u0432\u043a\u0438 \u043f\u0440\u043e\u0447\u0438\u0435 \u0448\u0442\u0443\u043a\u0438."]}),"\n",(0,r.jsx)(n.admonition,{type:"caution",children:(0,r.jsxs)(n.p,{children:["\u0412\u0430\u043c \u043d\u0430\u0432\u0435\u0440\u043d\u043e\u0435 \u043d\u0435 \u0441\u0442\u043e\u0438\u0442 \u0440\u0435\u0430\u043b\u0438\u0437\u043e\u0432\u044b\u0432\u0430\u0442\u044c ",(0,r.jsx)(n.code,{children:"UnlockWrapper"})," \u043d\u0430\u043f\u0440\u044f\u043c\u0443\u044e. \u0418\u0441\u043f\u043e\u043b\u044c\u0437\u0443\u0439\u0442\u0435 \u043a\u043b\u0430\u0441\u0441\u044b, \u043e\u043f\u0438\u0441\u0430\u043d\u043d\u044b\u0435 \u043f\u043e\u0437\u0436\u0435 \u043d\u0430 \u0441\u0442\u0440\u0430\u043d\u0438\u0446\u0435."]})}),"\n",(0,r.jsxs)(n.h2,{id:"displayedunlock",children:["\u041a\u043b\u0430\u0441\u0441 ",(0,r.jsx)(n.code,{children:"DisplayedUnlock"})]}),"\n",(0,r.jsxs)(n.p,{children:[(0,r.jsx)(n.code,{children:"DisplayedUnlock"})," \u043d\u0430\u0441\u043b\u0435\u0434\u0443\u0435\u0442 \u043e\u0442 \u043a\u043b\u0430\u0441\u0441\u0430 ",(0,r.jsx)(n.code,{children:"UnlockWrapper"}),". \u041e\u043d \u043f\u0440\u0435\u0434\u043e\u0441\u0442\u0430\u0432\u043b\u044f\u0435\u0442 \u043c\u0435\u0442\u043e\u0434\u044b \u0434\u043b\u044f \u043e\u0442\u043e\u0431\u0440\u0430\u0436\u0435\u043d\u0438\u044f \u0440\u0430\u0437\u0431\u043b\u043e\u043a\u0438\u0440\u043e\u0432\u043a\u0438 \u0432 \u043c\u0435\u043d\u044e."]}),"\n",(0,r.jsx)(n.admonition,{type:"caution",children:(0,r.jsxs)(n.p,{children:["\u0412\u0430\u043c \u043d\u0430\u0432\u0435\u0440\u043d\u043e\u0435 \u043d\u0435 \u0441\u0442\u043e\u0438\u0442 \u0440\u0435\u0430\u043b\u0438\u0437\u043e\u0432\u044b\u0432\u0430\u0442\u044c ",(0,r.jsx)(n.code,{children:"DisplayedUnlock"})," \u043d\u0430\u043f\u0440\u044f\u043c\u0443\u044e. \u0418\u0441\u043f\u043e\u043b\u044c\u0437\u0443\u0439\u0442\u0435 \u043a\u043b\u0430\u0441\u0441\u044b, \u043e\u043f\u0438\u0441\u0430\u043d\u043d\u044b\u0435 \u043f\u043e\u0437\u0436\u0435 \u043d\u0430 \u0441\u0442\u0440\u0430\u043d\u0438\u0446\u0435."]})}),"\n",(0,r.jsx)(n.h2,{id:"unlock-classes",children:"\u041a\u043b\u0430\u0441\u0441\u044b \u0440\u0430\u0437\u0431\u043b\u043e\u043a\u0438\u0440\u043e\u0432\u043e\u043a"}),"\n",(0,r.jsx)(n.p,{children:"RogueLibs \u043f\u0440\u0435\u0434\u043e\u0441\u0442\u0430\u0432\u043b\u044f\u0435\u0442 \u0441\u043b\u0435\u0434\u0443\u044e\u0449\u0438\u0435 \u043a\u043b\u0430\u0441\u0441\u044b, \u043e\u0442 \u043a\u043e\u0442\u043e\u0440\u044b\u0445 \u0432\u044b \u043c\u043e\u0436\u0435\u0442\u0435 \u043d\u0430\u0441\u043b\u0435\u0434\u043e\u0432\u0430\u0442\u044c:"}),"\n",(0,r.jsxs)(n.ul,{children:["\n",(0,r.jsxs)(n.li,{children:[(0,r.jsx)(n.code,{children:"ItemUnlock"})," - \u0434\u043b\u044f \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u043e\u0432;"]}),"\n",(0,r.jsxs)(n.li,{children:[(0,r.jsx)(n.code,{children:"AbilityUnlock"})," - \u0434\u043b\u044f \u0441\u043f\u043e\u0441\u043e\u0431\u043d\u043e\u0441\u0442\u0435\u0439;"]}),"\n",(0,r.jsxs)(n.li,{children:[(0,r.jsx)(n.code,{children:"TraitUnlock"})," - \u0434\u043b\u044f \u043e\u0441\u043e\u0431\u0435\u043d\u043d\u043e\u0441\u0442\u0435\u0439;"]}),"\n",(0,r.jsxs)(n.li,{children:[(0,r.jsx)(n.code,{children:"MutatorUnlock"})," - \u0434\u043b\u044f \u043c\u0443\u0442\u0430\u0442\u043e\u0440\u043e\u0432;"]}),"\n",(0,r.jsxs)(n.li,{children:[(0,r.jsx)(n.code,{children:"AgentUnlock"})," - \u0434\u043b\u044f \u043f\u0435\u0440\u0441\u043e\u043d\u0430\u0436\u0435\u0439;"]}),"\n",(0,r.jsxs)(n.li,{children:[(0,r.jsx)(n.code,{children:"BigQuestUnlock"})," - \u0434\u043b\u044f \u0411\u043e\u043b\u044c\u0448\u0438\u0445 \u041a\u0432\u0435\u0441\u0442\u043e\u0432 \u043f\u0435\u0440\u0441\u043e\u043d\u0430\u0436\u0435\u0439;"]}),"\n",(0,r.jsxs)(n.li,{children:[(0,r.jsx)(n.code,{children:"ExtraUnlock"})," - \u0434\u043b\u044f \u0434\u043e\u0441\u0442\u0438\u0436\u0435\u043d\u0438\u0439 \u0438 \u043f\u0440\u043e\u0447\u0435\u0433\u043e;"]}),"\n",(0,r.jsxs)(n.li,{children:[(0,r.jsx)(n.code,{children:"FloorUnlock"})," - \u0434\u043b\u044f \u044d\u0442\u0430\u0436\u0435\u0439;"]}),"\n"]}),"\n",(0,r.jsx)(n.admonition,{type:"note",children:(0,r.jsx)(n.p,{children:"\u0415\u0441\u0442\u044c \u0435\u0449\u0451 \u043d\u0435\u0441\u043a\u043e\u043b\u044c\u043a\u043e \u043a\u043b\u0430\u0441\u0441\u043e\u0432, \u043d\u043e \u043e\u043d\u0438 \u0432 RogueLibs \u0442\u043e\u043b\u044c\u043a\u043e \u0440\u0430\u0434\u0438 \u0441\u043e\u0432\u043c\u0435\u0441\u0442\u0438\u043c\u043e\u0441\u0442\u0438."})}),"\n",(0,r.jsx)(n.h2,{id:"initialization",children:"\u0418\u043d\u0438\u0446\u0438\u0430\u043b\u0438\u0437\u0430\u0446\u0438\u044f"}),"\n",(0,r.jsx)(n.p,{children:"\u0412\u044b \u043c\u043e\u0436\u0435\u0442\u0435 \u0438\u043d\u0438\u0446\u0438\u0430\u043b\u0438\u0437\u0438\u0440\u043e\u0432\u0430\u0442\u044c \u0441\u0432\u043e\u0438 \u0440\u0430\u0437\u0431\u043b\u043e\u043a\u0438\u0440\u043e\u0432\u043a\u0438 \u0441\u043b\u0435\u0434\u0443\u044e\u0449\u0438\u043c \u043e\u0431\u0440\u0430\u0437\u043e\u043c:"}),"\n",(0,r.jsx)(n.pre,{children:(0,r.jsx)(n.code,{className:"language-csharp",metastring:'title="MyCustomItem.cs"',children:'public class MyCustomItem : CustomItem\n{\n    [RLSetup]\n    public static void Setup()\n    {\n        RogueLibs.CreateCustomItem<MyCustomItem>()\n            .WithName(new CustomNameInfo("My Custom Item"))\n            .WithDescription(new CustomNameInfo("My Custom Item is very cool and does a lot of great stuff"))\n            .WithSprite(Properties.Resources.MyCustomItem)\n            // highlight-next-line\n            .WithUnlock(new ItemUnlock\n            {\n                UnlockCost = 10,\n                CharacterCreationCost = 5,\n                LoadoutCost = 4,\n            });\n    }\n}\n'})}),"\n",(0,r.jsx)(n.p,{children:"\u0418\u043b\u0438 \u0432\u044b \u043c\u043e\u0436\u0435\u0442\u0435 \u0438\u043d\u0438\u0446\u0438\u0430\u043b\u0438\u0437\u0438\u0440\u043e\u0432\u0430\u0442\u044c \u0438\u0445 \u043d\u0430\u043f\u0440\u044f\u043c\u0443\u044e (\u043a\u0430\u043a \u0432 \u0441\u043b\u0443\u0447\u0430\u0435 \u043c\u0443\u0442\u0430\u0442\u043e\u0440\u043e\u0432):"}),"\n",(0,r.jsx)(n.pre,{children:(0,r.jsx)(n.code,{className:"language-csharp",children:'RogueLibs.CreateCustomUnlock(new MutatorUnlock("MyMutator"))\n    .WithName(new CustomNameInfo("Mutator Name"))\n    .WithDescription(new CustomNameInfo("Mutator Description"));\n'})})]})}function d(e={}){const{wrapper:n}={...(0,o.a)(),...e.components};return n?(0,r.jsx)(n,{...e,children:(0,r.jsx)(u,{...e})}):u(e)}},1016:(e,n,t)=>{t.d(n,{Z:()=>o});t(7294);var r=t(5893);function o(e){let{children:n,...t}=e;return(0,r.jsx)("div",{role:"tabpanel",...t,children:n})}},5878:(e,n,t)=>{t.d(n,{Z:()=>x});var r=t(7294),o=t(6550),s=t(469),l=t(1980),a=t(7392),i=t(12);function c(e){return function(e){return r.Children.toArray(e).filter((e=>"\n"!==e)).map((e=>{if(!e||(0,r.isValidElement)(e)&&function(e){const{props:n}=e;return!!n&&"object"==typeof n&&"value"in n}(e))return e;throw new Error(`Docusaurus error: Bad <Tabs> child <${"string"==typeof e.type?e.type:e.type.name}>: all children of the <Tabs> component should be <TabItem>, and every <TabItem> should have a unique "value" prop.`)}))?.filter(Boolean)??[]}(e).map((e=>{let{props:{value:n,label:t,attributes:r,default:o}}=e;return{value:n,label:t,attributes:r,default:o}}))}function u(e){const{values:n,children:t}=e;return(0,r.useMemo)((()=>{const e=n??c(t);return function(e){const n=(0,a.l)(e,((e,n)=>e.value===n.value));if(n.length>0)throw new Error(`Docusaurus error: Duplicate values "${n.map((e=>e.value)).join(", ")}" found in <Tabs>. Every value needs to be unique.`)}(e),e}),[n,t])}function d(e){let{value:n,tabValues:t}=e;return t.some((e=>e.value===n))}function h(e){let{queryString:n=!1,groupId:t}=e;const s=(0,o.k6)(),a=function(e){let{queryString:n=!1,groupId:t}=e;if("string"==typeof n)return n;if(!1===n)return null;if(!0===n&&!t)throw new Error('Docusaurus error: The <Tabs> component groupId prop is required if queryString=true, because this value is used as the search param name. You can also provide an explicit value such as queryString="my-search-param".');return t??null}({queryString:n,groupId:t});return[(0,l._X)(a),(0,r.useCallback)((e=>{if(!a)return;const n=new URLSearchParams(s.location.search);n.set(a,e),s.replace({...s.location,search:n.toString()})}),[a,s])]}function p(e){const{defaultValue:n,queryString:t=!1,groupId:o}=e,l=u(e),[a,c]=(0,r.useState)((()=>function(e){let{defaultValue:n,tabValues:t}=e;if(0===t.length)throw new Error("Docusaurus error: the <Tabs> component requires at least one <TabItem> children component");if(n){if(!d({value:n,tabValues:t}))throw new Error(`Docusaurus error: The <Tabs> has a defaultValue "${n}" but none of its children has the corresponding value. Available values are: ${t.map((e=>e.value)).join(", ")}. If you intend to show no default tab, use defaultValue={null} instead.`);return n}const r=t.find((e=>e.default))??t[0];if(!r)throw new Error("Unexpected error: 0 tabValues");return r.value}({defaultValue:n,tabValues:l}))),[p,m]=h({queryString:t,groupId:o}),[b,f]=function(e){let{groupId:n}=e;const t=function(e){return e?`docusaurus.tab.${e}`:null}(n),[o,s]=(0,i.Nk)(t);return[o,(0,r.useCallback)((e=>{t&&s.set(e)}),[t,s])]}({groupId:o}),v=(()=>{const e=p??b;return d({value:e,tabValues:l})?e:null})();(0,s.Z)((()=>{v&&c(v)}),[v]);return{selectedValue:a,selectValue:(0,r.useCallback)((e=>{if(!d({value:e,tabValues:l}))throw new Error(`Can't select invalid tab value=${e}`);c(e),m(e),f(e)}),[m,f,l]),tabValues:l}}var m=t(512);const b={tabItem:"tabItem_V91s",tabItemActive:"tabItemActive_JsUu",blink:"blink_ZPVS",tab:"tab_ntnM"};var f=t(5893);const v={left:37,right:39};function x(e){const{lazy:n,defaultValue:t,values:o,groupId:s}=e,l=r.Children.toArray(e.children),{tabValues:a,selectedValue:i,selectValue:c}=p({children:l,defaultValue:t,values:o,groupId:s}),u=[],d=e=>{const n=e.currentTarget,t=o[u.indexOf(n)].value;c(t),null!=s&&setTimeout((()=>{(function(e){const{top:n,left:t,bottom:r,right:o}=e.getBoundingClientRect(),{innerHeight:s,innerWidth:l}=window;return n>=0&&o<=l&&r<=s&&t>=0})(n)||(n.scrollIntoView({block:"center",behavior:"smooth"}),n.classList.add(b.tabItemActive),setTimeout((()=>n.classList.remove(b.tabItemActive)),2e3))}),150)},h=e=>{let n;switch(e.keyCode){case v.right:{const t=u.indexOf(e.target)+1;n=u[t]||u[0];break}case v.left:{const t=u.indexOf(e.target)-1;n=u[t]||u[u.length-1];break}default:return}n.focus()},x=(e,n)=>n.value===e||n.values&&-1!=n.values.indexOf(e);return(0,f.jsxs)("div",{className:"tabs-container",children:[(0,f.jsx)("ul",{role:"tablist","aria-orientation":"horizontal",className:"tabs",children:o.map((e=>{let{value:n,label:t}=e;return(0,f.jsx)("li",{role:"tab",tabIndex:i===n?0:-1,"aria-selected":i===n,className:(0,m.Z)("tabs__item",b.tabItem,{"tabs__item--active":i===n}),ref:e=>e&&u.push(e),onKeyDown:h,onFocus:d,onClick:d,children:t},n)}))}),n?r.cloneElement(l.find((e=>x(i,e.props))),{className:b.tab}):(0,f.jsx)("div",{children:l.map(((e,n)=>r.cloneElement(e,{key:n,hidden:!x(i,e.props),className:b.tab})))}),(0,f.jsx)("br",{})]})}},1151:(e,n,t)=>{t.d(n,{Z:()=>a,a:()=>l});var r=t(7294);const o={},s=r.createContext(o);function l(e){const n=r.useContext(s);return r.useMemo((function(){return"function"==typeof e?e(n):{...n,...e}}),[n,e])}function a(e){let n;return n=e.disableParentContext?"function"==typeof e.components?e.components(o):e.components||o:l(e.components),r.createElement(s.Provider,{value:n},e.children)}}}]);