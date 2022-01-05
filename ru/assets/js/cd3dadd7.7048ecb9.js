"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[6950],{3905:function(e,t,n){n.d(t,{Zo:function(){return c},kt:function(){return d}});var i=n(7294);function a(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function r(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var i=Object.getOwnPropertySymbols(e);t&&(i=i.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,i)}return n}function l(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?r(Object(n),!0).forEach((function(t){a(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):r(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function o(e,t){if(null==e)return{};var n,i,a=function(e,t){if(null==e)return{};var n,i,a={},r=Object.keys(e);for(i=0;i<r.length;i++)n=r[i],t.indexOf(n)>=0||(a[n]=e[n]);return a}(e,t);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(e);for(i=0;i<r.length;i++)n=r[i],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(a[n]=e[n])}return a}var s=i.createContext({}),u=function(e){var t=i.useContext(s),n=t;return e&&(n="function"==typeof e?e(t):l(l({},t),e)),n},c=function(e){var t=u(e.components);return i.createElement(s.Provider,{value:t},e.children)},m={inlineCode:"code",wrapper:function(e){var t=e.children;return i.createElement(i.Fragment,{},t)}},p=i.forwardRef((function(e,t){var n=e.components,a=e.mdxType,r=e.originalType,s=e.parentName,c=o(e,["components","mdxType","originalType","parentName"]),p=u(n),d=a,b=p["".concat(s,".").concat(d)]||p[d]||m[d]||r;return n?i.createElement(b,l(l({ref:t},c),{},{components:n})):i.createElement(b,l({ref:t},c))}));function d(e,t){var n=arguments,a=t&&t.mdxType;if("string"==typeof e||a){var r=n.length,l=new Array(r);l[0]=p;var o={};for(var s in t)hasOwnProperty.call(t,s)&&(o[s]=t[s]);o.originalType=e,o.mdxType="string"==typeof e?e:a,l[1]=o;for(var u=2;u<r;u++)l[u]=n[u];return i.createElement.apply(null,l)}return i.createElement.apply(null,n)}p.displayName="MDXCreateElement"},1016:function(e,t,n){n.d(t,{Z:function(){return o}});var i=n(7462),a=n(3366),r=n(7294),l=["children"];function o(e){var t=e.children,n=(0,a.Z)(e,l);return r.createElement("div",(0,i.Z)({role:"tabpanel"},n),t)}},2099:function(e,t,n){n.d(t,{Z:function(){return p}});var i=n(7294),a=n(9443);var r=function(){var e=(0,i.useContext)(a.Z);if(null==e)throw new Error('"useUserPreferencesContext" is used outside of "Layout" component.');return e},l=n(6010),o="tabItem_OdQc",s="tabItemActive_YQWB",u="tab_tgHH";var c=37,m=39;function p(e){var t=e.lazy,n=e.defaultValue,a=e.values,p=e.groupId,d=r(),b=d.tabGroupChoices,k=d.setTabGroupChoices,y=(0,i.useState)(n),v=y[0],h=y[1],g=i.Children.toArray(e.children),N=[];if(null!=p){var f=b[p];null!=f&&f!==v&&a.some((function(e){return e.value===f}))&&h(f)}var C=function(e){var t=e.currentTarget,n=N.indexOf(t),i=a[n].value;h(i),null!=p&&(k(p,i),setTimeout((function(){var e,n,i,a,r,l,o,u;(e=t.getBoundingClientRect(),n=e.top,i=e.left,a=e.bottom,r=e.right,l=window,o=l.innerHeight,u=l.innerWidth,n>=0&&r<=u&&a<=o&&i>=0)||(t.scrollIntoView({block:"center",behavior:"smooth"}),t.classList.add(s),setTimeout((function(){return t.classList.remove(s)}),2e3))}),150))},A=function(e){var t;switch(e.keyCode){case m:var n=N.indexOf(e.target)+1;t=N[n]||N[0];break;case c:var i=N.indexOf(e.target)-1;t=N[i]||N[N.length-1];break;default:return}t.focus()},w=function(e,t){return t.value===e||t.values&&-1!=t.values.indexOf(e)};return i.createElement("div",{className:"tabs-container"},i.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:"tabs"},a.map((function(e){var t=e.value,n=e.label;return i.createElement("li",{role:"tab",tabIndex:v===t?0:-1,"aria-selected":v===t,className:(0,l.Z)("tabs__item",o,{"tabs__item--active":v===t}),key:t,ref:function(e){return e&&N.push(e)},onKeyDown:A,onFocus:C,onClick:C},n)}))),t?i.cloneElement(g.find((function(e){return w(v,e.props)})),{className:u}):i.createElement("div",null,g.map((function(e,t){return i.cloneElement(e,{key:t,hidden:!w(v,e.props),className:u})}))),i.createElement("br",null))}},7222:function(e,t,n){n.r(t),n.d(t,{frontMatter:function(){return u},contentTitle:function(){return c},metadata:function(){return m},toc:function(){return p},default:function(){return b}});var i=n(7462),a=n(3366),r=(n(7294),n(3905)),l=n(2099),o=n(1016),s=(n(4996),["components"]),u={},c="\u0421\u043e\u0437\u0434\u0430\u0451\u043c \u043a\u0430\u0441\u0442\u043e\u043c\u043d\u0443\u044e \u0441\u043f\u043e\u0441\u043e\u0431\u043d\u043e\u0441\u0442\u044c",m={unversionedId:"dev/items/abilities/create-ability",id:"dev/items/abilities/create-ability",title:"\u0421\u043e\u0437\u0434\u0430\u0451\u043c \u043a\u0430\u0441\u0442\u043e\u043c\u043d\u0443\u044e \u0441\u043f\u043e\u0441\u043e\u0431\u043d\u043e\u0441\u0442\u044c",description:"\u041a\u043b\u0430\u0441\u0441 CustomAbility",source:"@site/i18n/ru/docusaurus-plugin-content-docs/current/dev/items/abilities/create-ability.mdx",sourceDirName:"dev/items/abilities",slug:"/dev/items/abilities/create-ability",permalink:"/RogueLibs/ru/docs/dev/items/abilities/create-ability",editUrl:"https://github.com/Abbysssal/RogueLibs/edit/main/website/docs/dev/items/abilities/create-ability.mdx",tags:[],version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"\u0418\u043d\u0432\u0435\u043d\u0442\u0430\u0440\u043d\u044b\u0435 \u043f\u0440\u043e\u0432\u0435\u0440\u043a\u0438",permalink:"/RogueLibs/ru/docs/dev/items/inventory-checks"},next:{title:"\u041f\u0435\u0440\u0435\u0437\u0430\u0440\u044f\u0436\u0430\u0435\u043c\u044b\u0435 \u0441\u043f\u043e\u0441\u043e\u0431\u043d\u043e\u0441\u0442\u0438",permalink:"/RogueLibs/ru/docs/dev/items/abilities/rechargeable-abilities"}},p=[{value:"\u041a\u043b\u0430\u0441\u0441 <code>CustomAbility</code>",id:"customability",children:[{value:"<code>SetupDetails</code>",id:"setupdetails",children:[],level:3}],level:2},{value:"\u0418\u043d\u0438\u0446\u0438\u0430\u043b\u0438\u0437\u0430\u0446\u0438\u044f",id:"initialization",children:[],level:2},{value:"\u0421\u0432\u043e\u0439\u0441\u0442\u0432\u0430 \u0440\u0430\u0437\u0431\u043b\u043e\u043a\u0438\u0440\u043e\u0432\u043e\u043a",id:"unlock-properties",children:[],level:2},{value:"\u041f\u0440\u0438\u043c\u0435\u0440\u044b",id:"examples",children:[],level:2}],d={toc:p};function b(e){var t=e.components,n=(0,a.Z)(e,s);return(0,r.kt)("wrapper",(0,i.Z)({},d,n,{components:t,mdxType:"MDXLayout"}),(0,r.kt)("h1",{id:"\u0441\u043e\u0437\u0434\u0430\u0451\u043c-\u043a\u0430\u0441\u0442\u043e\u043c\u043d\u0443\u044e-\u0441\u043f\u043e\u0441\u043e\u0431\u043d\u043e\u0441\u0442\u044c"},"\u0421\u043e\u0437\u0434\u0430\u0451\u043c \u043a\u0430\u0441\u0442\u043e\u043c\u043d\u0443\u044e \u0441\u043f\u043e\u0441\u043e\u0431\u043d\u043e\u0441\u0442\u044c"),(0,r.kt)("h2",{id:"customability"},"\u041a\u043b\u0430\u0441\u0441 ",(0,r.kt)("inlineCode",{parentName:"h2"},"CustomAbility")),(0,r.kt)("p",null,"\u0421\u043f\u0435\u0446\u0438\u0430\u043b\u044c\u043d\u044b\u0435 \u0441\u043f\u043e\u0441\u043e\u0431\u043d\u043e\u0441\u0442\u0438 \u043d\u0430 \u0441\u0430\u043c\u043e\u043c \u0434\u0435\u043b\u0435 \u043e\u0447\u0435\u043d\u044c \u043f\u043e\u0445\u043e\u0436\u0438 \u043d\u0430 \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u044b. \u0423 \u043d\u0438\u0445 \u0435\u0441\u0442\u044c ",(0,r.kt)("inlineCode",{parentName:"p"},"SetupDetails"),", ",(0,r.kt)("inlineCode",{parentName:"p"},"Count")," \u0438 \u043e\u043d\u0438 \u0441\u0443\u0449\u0435\u0441\u0442\u0432\u0443\u044e\u0442 \u0432 \u0438\u043d\u0432\u0435\u043d\u0442\u0430\u0440\u0435 \u0441\u0432\u043e\u0435\u0433\u043e \u0432\u043b\u0430\u0434\u0435\u043b\u044c\u0446\u0430, \u0442\u0430\u043a \u0436\u0435 \u043a\u0430\u043a \u0438 \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u044b. \u0427\u0442\u043e\u0431\u044b \u0441\u043e\u0437\u0434\u0430\u0442\u044c \u043a\u0430\u0441\u0442\u043e\u043c\u043d\u0443\u044e \u0441\u043f\u043e\u0441\u043e\u0431\u043d\u043e\u0441\u0442\u044c, \u0432\u0430\u043c \u043d\u0430\u0434\u043e \u043f\u0440\u043e\u0441\u0442\u043e \u0441\u043e\u0437\u0434\u0430\u0442\u044c \u043a\u043b\u0430\u0441\u0441 \u043d\u0430\u0441\u043b\u0435\u0434\u0443\u044e\u0449\u0438\u0439 \u043e\u0442 ",(0,r.kt)("inlineCode",{parentName:"p"},"CustomAbility")," (\u043a\u043e\u0442\u043e\u0440\u044b\u0439 \u043d\u0430\u0441\u043b\u0435\u0434\u0443\u0435\u0442 \u043e\u0442 ",(0,r.kt)("inlineCode",{parentName:"p"},"CustomItem"),"):"),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyCustomAbility.cs"',title:'"MyCustomAbility.cs"'},"// highlight-next-line\npublic class MyCustomAbility : CustomAbility\n{\n    /* ... */\n}\n")),(0,r.kt)("p",null,"\u0412\u0430\u043c \u043d\u0430\u0434\u043e \u0440\u0435\u0430\u043b\u0438\u0437\u043e\u0432\u0430\u0442\u044c 2 \u043c\u0435\u0442\u043e\u0434\u0430: ",(0,r.kt)("inlineCode",{parentName:"p"},"OnAdded")," \u0432\u044b\u0437\u044b\u0432\u0430\u0435\u0442\u0441\u044f \u043a\u043e\u0433\u0434\u0430 \u043f\u0435\u0440\u0441\u043e\u043d\u0430\u0436 \u043f\u043e\u043b\u0443\u0447\u0430\u0435\u0442 \u044d\u0442\u0443 \u0441\u043f\u043e\u0441\u043e\u0431\u043d\u043e\u0441\u0442\u044c, \u0438 ",(0,r.kt)("inlineCode",{parentName:"p"},"OnPressed")," \u0432\u044b\u0437\u044b\u0432\u0430\u0435\u0442\u0441\u044f \u043a\u043e\u0433\u0434\u0430 \u0438\u0433\u0440\u043e\u043a \u0438\u0441\u043f\u043e\u043b\u044c\u0437\u0443\u0435\u0442 \u0441\u043f\u043e\u0441\u043e\u0431\u043d\u043e\u0441\u0442\u044c. \u0422\u0443\u0442 \u043d\u0435\u0442\u0443 ",(0,r.kt)("inlineCode",{parentName:"p"},"OnRemoved")," \u043d\u0430 \u0434\u0430\u043d\u043d\u044b\u0439 \u043c\u043e\u043c\u0435\u043d\u0442, \u0442\u0430\u043a \u043a\u0430\u043a \u044d\u0442\u043e \u043d\u0435 \u0440\u0435\u0430\u043b\u0438\u0437\u043e\u0432\u0430\u043d\u043e \u0432 \u0421\u043e\u0420\u0435."),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyCustomAbility.cs"',title:'"MyCustomAbility.cs"'},"public class MyCustomAbility : CustomAbility\n{\n    // highlight-start\n    public override void OnAdded() { /* ... */ }\n    public override void OnPressed() { /* ... */ }\n    // highlight-end\n}\n")),(0,r.kt)("h3",{id:"setupdetails"},(0,r.kt)("inlineCode",{parentName:"h3"},"SetupDetails")),(0,r.kt)("p",null,(0,r.kt)("inlineCode",{parentName:"p"},"SetupDetails")," \u043f\u0435\u0440\u0435\u0433\u0440\u0443\u0436\u0435\u043d ",(0,r.kt)("inlineCode",{parentName:"p"},"CustomAbility")," \u0438 \u0432\u043e\u0442 \u0435\u0433\u043e \u0440\u0435\u0430\u043b\u0438\u0437\u0430\u0446\u0438\u044f:"),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},"    public override void SetupDetails()\n    {\n        Item.stackable = true;\n        Item.initCount = 0;\n        Item.lowCountThreshold = 100;\n    }\n")),(0,r.kt)("p",null,"\u042d\u0442\u043e\u0442 \u043c\u0435\u0442\u043e\u0434 \u0434\u043e\u043b\u0436\u0435\u043d \u0440\u0430\u0431\u043e\u0442\u0430\u0442\u044c \u0434\u043b\u044f \u0431\u043e\u043b\u044c\u0448\u0438\u043d\u0441\u0442\u0432\u0430 \u0441\u043f\u043e\u0441\u043e\u0431\u043d\u043e\u0441\u0442\u0435\u0439, \u043d\u043e \u0435\u0441\u043b\u0438 \u0432\u0430\u043c \u043d\u0430\u0434\u043e \u0447\u0442\u043e-\u0442\u043e \u0431\u043e\u043b\u0435\u0435 \u0441\u043b\u043e\u0436\u043d\u043e\u0435, \u0442\u043e \u043f\u0435\u0440\u0435\u0433\u0440\u0443\u0437\u0438\u0442\u0435 \u0435\u0433\u043e \u0441\u0430\u043c\u0438."),(0,r.kt)("h2",{id:"initialization"},"\u0418\u043d\u0438\u0446\u0438\u0430\u043b\u0438\u0437\u0430\u0446\u0438\u044f"),(0,r.kt)("p",null,"\u041f\u0440\u043e\u0441\u0442\u043e \u0432\u044b\u0437\u043e\u0432\u0438\u0442\u0435 \u043c\u0435\u0442\u043e\u0434 ",(0,r.kt)("inlineCode",{parentName:"p"},"CreateCustomAbility")," \u0441 \u0442\u0438\u043f\u043e\u043c \u0432\u0430\u0448\u0435\u0439 \u0441\u043f\u043e\u0441\u043e\u0431\u043d\u043e\u0441\u0442\u0438 \u0432 \u043a\u0430\u0447\u0435\u0441\u0442\u0432\u0435 \u043f\u0430\u0440\u0430\u043c\u0435\u0442\u0440\u0430:"),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyCustomAbility.cs"',title:'"MyCustomAbility.cs"'},"public class MyCustomAbility : CustomAbility\n{\n    [RLSetup]\n    public static void Setup()\n    {\n        // highlight-next-line\n        RogueLibs.CreateCustomAbility<MyCustomAbility>();\n    }\n}\n")),(0,r.kt)("div",{className:"admonition admonition-note alert alert--secondary"},(0,r.kt)("div",{parentName:"div",className:"admonition-heading"},(0,r.kt)("h5",{parentName:"div"},(0,r.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,r.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,r.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.3 5.69a.942.942 0 0 1-.28-.7c0-.28.09-.52.28-.7.19-.18.42-.28.7-.28.28 0 .52.09.7.28.18.19.28.42.28.7 0 .28-.09.52-.28.7a1 1 0 0 1-.7.3c-.28 0-.52-.11-.7-.3zM8 7.99c-.02-.25-.11-.48-.31-.69-.2-.19-.42-.3-.69-.31H6c-.27.02-.48.13-.69.31-.2.2-.3.44-.31.69h1v3c.02.27.11.5.31.69.2.2.42.31.69.31h1c.27 0 .48-.11.69-.31.2-.19.3-.42.31-.69H8V7.98v.01zM7 2.3c-3.14 0-5.7 2.54-5.7 5.68 0 3.14 2.56 5.7 5.7 5.7s5.7-2.55 5.7-5.7c0-3.15-2.56-5.69-5.7-5.69v.01zM7 .98c3.86 0 7 3.14 7 7s-3.14 7-7 7-7-3.12-7-7 3.14-7 7-7z"}))),"note")),(0,r.kt)("div",{parentName:"div",className:"admonition-content"},(0,r.kt)("p",{parentName:"div"},"\u0421\u043c\u043e\u0442\u0440\u0438\u0442\u0435 \u043f\u043e\u0434\u0440\u043e\u0431\u043d\u0435\u0435 \u043e\u0431 \u0430\u0442\u0440\u0438\u0431\u0443\u0442\u0435 ",(0,r.kt)("inlineCode",{parentName:"p"},"RLSetup")," ",(0,r.kt)("a",{parentName:"p",href:"../../patching-utilities#rlsetup"},"\u0437\u0434\u0435\u0441\u044c"),"."))),(0,r.kt)("p",null,"\u0412\u044b \u043c\u043e\u0436\u0435\u0442\u0435 \u0432\u044b\u0441\u0442\u0430\u0432\u0438\u0442\u044c \u043d\u0430\u0437\u0432\u0430\u043d\u0438\u0435 \u0438 \u043e\u043f\u0438\u0441\u0430\u043d\u0438\u0435 \u0441\u0432\u043e\u0435\u0439 \u0441\u043f\u043e\u0441\u043e\u0431\u043d\u043e\u0441\u0442\u0438 \u0441 \u043f\u043e\u043c\u043e\u0449\u044c\u044e \u043c\u0435\u0442\u043e\u0434\u043e\u0432 ",(0,r.kt)("inlineCode",{parentName:"p"},"WithName")," \u0438 ",(0,r.kt)("inlineCode",{parentName:"p"},"WithDescription"),":"),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyCustomAbility.cs"',title:'"MyCustomAbility.cs"'},'public class MyCustomAbility : CustomAbility\n{\n    [RLSetup]\n    public static void Setup()\n    {\n        RogueLibs.CreateCustomAbility<MyCustomAbility>();\n            // highlight-start\n            .WithName(new CustomNameInfo("My Custom Ability"))\n            .WithDescription(new CustomNameInfo("My Custom Ability is very cool and does a lot of great stuff"));\n            // highlight-end\n    }\n}\n')),(0,r.kt)("p",null,"\u0422\u043e \u0436\u0435 \u0441\u0430\u043c\u043e\u0435 \u043c\u043e\u0436\u043d\u043e \u0441\u0434\u0435\u043b\u0430\u0442\u044c \u0438 \u0441\u043e \u0441\u043f\u0440\u0430\u0439\u0442\u0430\u043c\u0438 \u0438 \u0440\u0430\u0437\u0431\u043b\u043e\u043a\u0438\u0440\u043e\u0432\u043a\u0430\u043c\u0438:"),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyCustomAbility.cs"',title:'"MyCustomAbility.cs"'},'public class MyCustomAbility : CustomAbility\n{\n    [RLSetup]\n    public static void Setup()\n    {\n        RogueLibs.CreateCustomAbility<MyCustomAbility>();\n            .WithName(new CustomNameInfo("My Custom Ability"))\n            .WithDescription(new CustomNameInfo("My Custom Ability is very cool and does a lot of great stuff"));\n            // highlight-start\n            .WithSprite(Properties.Resources.MyCustomAbility)\n            .WithUnlock(new AbilityUnlock { UnlockCost = 10, CharacterCreationCost = 5 });\n            // highlight-end\n    }\n}\n')),(0,r.kt)("div",{className:"admonition admonition-info alert alert--info"},(0,r.kt)("div",{parentName:"div",className:"admonition-heading"},(0,r.kt)("h5",{parentName:"div"},(0,r.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,r.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,r.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M7 2.3c3.14 0 5.7 2.56 5.7 5.7s-2.56 5.7-5.7 5.7A5.71 5.71 0 0 1 1.3 8c0-3.14 2.56-5.7 5.7-5.7zM7 1C3.14 1 0 4.14 0 8s3.14 7 7 7 7-3.14 7-7-3.14-7-7-7zm1 3H6v5h2V4zm0 6H6v2h2v-2z"}))),"info")),(0,r.kt)("div",{parentName:"div",className:"admonition-content"},(0,r.kt)("p",{parentName:"div"},"\u0421\u043c\u043e\u0442\u0440\u0438\u0442\u0435 ",(0,r.kt)("a",{parentName:"p",href:"../../names/custom-names"},"\u041a\u0430\u0441\u0442\u043e\u043c\u043d\u044b\u0435 \u0438\u043c\u0435\u043d\u0430"),", ",(0,r.kt)("a",{parentName:"p",href:"../../custom-sprites"},"\u041a\u0430\u0441\u0442\u043e\u043c\u043d\u044b\u0435 \u0441\u043f\u0440\u0430\u0439\u0442\u044b"),"."))),(0,r.kt)("h2",{id:"unlock-properties"},"\u0421\u0432\u043e\u0439\u0441\u0442\u0432\u0430 \u0440\u0430\u0437\u0431\u043b\u043e\u043a\u0438\u0440\u043e\u0432\u043e\u043a"),(0,r.kt)("p",null,"\u0412\u044b \u043c\u043e\u0436\u0435\u0442\u0435 \u0438\u0441\u043f\u043e\u043b\u044c\u0437\u043e\u0432\u0430\u0442\u044c \u0441\u043b\u0435\u0434\u0443\u044e\u0449\u0438\u0435 \u0441\u0432\u043e\u0439\u0441\u0442\u0432\u0430 \u043f\u0440\u0438 \u0438\u043d\u0438\u0446\u0438\u0430\u043b\u0438\u0437\u0430\u0446\u0438\u0438 ",(0,r.kt)("inlineCode",{parentName:"p"},"AbilityUnlock"),":"),(0,r.kt)("table",null,(0,r.kt)("thead",{parentName:"table"},(0,r.kt)("tr",{parentName:"thead"},(0,r.kt)("th",{parentName:"tr",align:null},"\u0421\u0432\u043e\u0439\u0441\u0442\u0432\u043e"),(0,r.kt)("th",{parentName:"tr",align:null},"\u041f\u043e \u0443\u043c\u043e\u043b\u0447\u0430\u043d\u0438\u044e"),(0,r.kt)("th",{parentName:"tr",align:null},"\u041e\u043f\u0438\u0441\u0430\u043d\u0438\u0435"))),(0,r.kt)("tbody",{parentName:"table"},(0,r.kt)("tr",{parentName:"tbody"},(0,r.kt)("td",{parentName:"tr",align:null},(0,r.kt)("inlineCode",{parentName:"td"},"UnlockCost")),(0,r.kt)("td",{parentName:"tr",align:null},(0,r.kt)("inlineCode",{parentName:"td"},"0")),(0,r.kt)("td",{parentName:"tr",align:null},"\u0421\u0442\u043e\u0438\u043c\u043e\u0441\u0442\u044c \u0440\u0430\u0437\u0431\u043b\u043e\u043a\u0438\u0440\u043e\u0432\u043a\u0438 \u0441\u043f\u043e\u0441\u043e\u0431\u043d\u043e\u0441\u0442\u0438, \u0432 \u043d\u0430\u0433\u0433\u0435\u0442\u0441\u0430\u0445. \u0415\u0441\u043b\u0438 \u0432\u044b\u0441\u0442\u0430\u0432\u043b\u0435\u043d\u043e \u043d\u0430 0, \u0440\u0430\u0437\u0431\u043b\u043e\u043a\u0438\u0440\u0443\u0435\u0442\u0441\u044f \u0430\u0432\u0442\u043e\u043c\u0430\u0442\u0438\u0447\u0435\u0441\u043a\u0438, \u043a\u0430\u043a \u0442\u043e\u043b\u044c\u043a\u043e \u0432\u0441\u0435 \u0442\u0440\u0435\u0431\u043e\u0432\u0430\u043d\u0438\u044f \u043e\u0442\u043a\u0440\u044b\u0442\u044b.")),(0,r.kt)("tr",{parentName:"tbody"},(0,r.kt)("td",{parentName:"tr",align:null},(0,r.kt)("inlineCode",{parentName:"td"},"CharacterCreationCost")),(0,r.kt)("td",{parentName:"tr",align:null},(0,r.kt)("inlineCode",{parentName:"td"},"1")),(0,r.kt)("td",{parentName:"tr",align:null},"\u0421\u0442\u043e\u0438\u043c\u043e\u0441\u0442\u044c \u0441\u043f\u043e\u0441\u043e\u0431\u043d\u043e\u0441\u0442\u0438 \u0432 \u0420\u0435\u0434\u0430\u043a\u0442\u043e\u0440\u0435 \u043f\u0435\u0440\u0441\u043e\u043d\u0430\u0436\u0435\u0439, \u0432 \u043e\u0447\u043a\u0430\u0445.")),(0,r.kt)("tr",{parentName:"tbody"},(0,r.kt)("td",{parentName:"tr",align:null},(0,r.kt)("inlineCode",{parentName:"td"},"IsAvailable")),(0,r.kt)("td",{parentName:"tr",align:null},(0,r.kt)("inlineCode",{parentName:"td"},"true")),(0,r.kt)("td",{parentName:"tr",align:null},"\u041e\u043f\u0440\u0435\u0434\u0435\u043b\u044f\u0435\u0442, \u0434\u043e\u0441\u0442\u0443\u043f\u043d\u0430 \u0441\u043f\u043e\u0441\u043e\u0431\u043d\u043e\u0441\u0442\u044c \u0432 ... \u041d\u0443, \u0432 \u0438\u0433\u0440\u0435 \u043d\u0435\u0442\u0443 \u043c\u0435\u043d\u044e \u0434\u043b\u044f \u043a\u0430\u0441\u0442\u043e\u043c\u043d\u044b\u0445 \u0441\u043f\u043e\u0441\u043e\u0431\u043d\u043e\u0441\u0442\u0435\u0439 \u043d\u0430 \u0434\u0430\u043d\u043d\u044b\u0439 \u043c\u043e\u043c\u0435\u043d\u0442, \u043d\u043e \u0435\u0441\u043b\u0438 \u0431\u044b \u0431\u044b\u043b\u043e, \u0442\u043e \u044d\u0442\u043e \u0441\u0432\u043e\u0439\u0441\u0442\u0432\u043e \u043e\u043f\u0440\u0435\u0434\u0435\u043b\u044f\u043b\u043e \u0431\u044b, \u0434\u043e\u0441\u0442\u0443\u043f\u043d\u0430 \u043b\u0438 \u0441\u043f\u043e\u0441\u043e\u0431\u043d\u043e\u0441\u0442\u044c \u0442\u0430\u043c \u0438\u043b\u0438 \u043d\u0435\u0442.")),(0,r.kt)("tr",{parentName:"tbody"},(0,r.kt)("td",{parentName:"tr",align:null},(0,r.kt)("inlineCode",{parentName:"td"},"IsAvailableInCC")),(0,r.kt)("td",{parentName:"tr",align:null},(0,r.kt)("inlineCode",{parentName:"td"},"true")),(0,r.kt)("td",{parentName:"tr",align:null},"\u041e\u043f\u0440\u0435\u0434\u0435\u043b\u044f\u0435\u0442, \u0434\u043e\u0441\u0442\u0443\u043f\u043d\u0430 \u043b\u0438 \u0441\u043f\u043e\u0441\u043e\u0431\u043d\u043e\u0441\u0442\u044c \u0432 \u0420\u0435\u0434\u0430\u043a\u0442\u043e\u0440\u0435 \u043f\u0435\u0440\u0441\u043e\u043d\u0430\u0436\u0435\u0439.")),(0,r.kt)("tr",{parentName:"tbody"},(0,r.kt)("td",{parentName:"tr",align:null},(0,r.kt)("inlineCode",{parentName:"td"},"Prerequisites")),(0,r.kt)("td",{parentName:"tr",align:null}),(0,r.kt)("td",{parentName:"tr",align:null},"\u041e\u043f\u0440\u0435\u0434\u0435\u043b\u044f\u0435\u0442 \u043a\u0430\u043a\u0438\u0435 \u0440\u0430\u0437\u0431\u043b\u043e\u043a\u0438\u0440\u043e\u0432\u043a\u0438 \u0434\u043e\u043b\u0436\u043d\u044b \u0431\u044b\u0442\u044c \u0440\u0430\u0437\u0431\u043b\u043e\u043a\u0438\u0440\u043e\u0432\u0430\u043d\u044b, \u0447\u0442\u043e\u0431\u044b \u043e\u0442\u043a\u0440\u044b\u0442\u044c \u044d\u0442\u0443 \u0441\u043f\u043e\u0441\u043e\u0431\u043d\u043e\u0441\u0442\u044c.")),(0,r.kt)("tr",{parentName:"tbody"},(0,r.kt)("td",{parentName:"tr",align:null},(0,r.kt)("inlineCode",{parentName:"td"},"Recommendations")),(0,r.kt)("td",{parentName:"tr",align:null}),(0,r.kt)("td",{parentName:"tr",align:null},"\u041f\u0440\u043e\u0441\u0442\u043e \u043f\u043e\u043a\u0430\u0437\u044b\u0432\u0430\u0435\u0442 \u044d\u0442\u0438 \u0440\u0430\u0437\u0431\u043b\u043e\u043a\u0438\u0440\u043e\u0432\u043a\u0438 \u0432 \u043e\u0442\u0434\u0435\u043b\u044c\u043d\u043e\u043c \u0440\u0430\u0437\u0434\u0435\u043b\u0435 \u0420\u0435\u043a\u043e\u043c\u0435\u043d\u0434\u0430\u0446\u0438\u0438 \u0432 \u043c\u0435\u043d\u044e.")))),(0,r.kt)("p",null,"\u0414\u0440\u0443\u0433\u0438\u0435 \u0441\u0432\u043e\u0439\u0441\u0442\u0432\u0430 \u043d\u0435 \u0434\u043e\u043b\u0436\u043d\u044b \u0438\u0441\u043f\u043e\u043b\u044c\u0437\u043e\u0432\u0430\u0442\u044c\u0441\u044f \u0432\u043e \u0432\u0440\u0435\u043c\u044f \u0438\u043d\u0438\u0446\u0438\u0430\u043b\u0438\u0437\u0430\u0446\u0438\u0438."),(0,r.kt)("h2",{id:"examples"},"\u041f\u0440\u0438\u043c\u0435\u0440\u044b"),(0,r.kt)(l.Z,{defaultValue:"",values:[{label:"",value:""}],mdxType:"Tabs"},(0,r.kt)(o.Z,{value:"",mdxType:"TabItem"},(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title=""',title:'""'},"")))))}b.isMDXComponent=!0}}]);