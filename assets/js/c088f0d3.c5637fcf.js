"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[6750],{3905:function(e,n,t){t.d(n,{Zo:function(){return u},kt:function(){return d}});var a=t(7294);function o(e,n,t){return n in e?Object.defineProperty(e,n,{value:t,enumerable:!0,configurable:!0,writable:!0}):e[n]=t,e}function r(e,n){var t=Object.keys(e);if(Object.getOwnPropertySymbols){var a=Object.getOwnPropertySymbols(e);n&&(a=a.filter((function(n){return Object.getOwnPropertyDescriptor(e,n).enumerable}))),t.push.apply(t,a)}return t}function i(e){for(var n=1;n<arguments.length;n++){var t=null!=arguments[n]?arguments[n]:{};n%2?r(Object(t),!0).forEach((function(n){o(e,n,t[n])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(t)):r(Object(t)).forEach((function(n){Object.defineProperty(e,n,Object.getOwnPropertyDescriptor(t,n))}))}return e}function s(e,n){if(null==e)return{};var t,a,o=function(e,n){if(null==e)return{};var t,a,o={},r=Object.keys(e);for(a=0;a<r.length;a++)t=r[a],n.indexOf(t)>=0||(o[t]=e[t]);return o}(e,n);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(e);for(a=0;a<r.length;a++)t=r[a],n.indexOf(t)>=0||Object.prototype.propertyIsEnumerable.call(e,t)&&(o[t]=e[t])}return o}var l=a.createContext({}),m=function(e){var n=a.useContext(l),t=n;return e&&(t="function"==typeof e?e(n):i(i({},n),e)),t},u=function(e){var n=m(e.components);return a.createElement(l.Provider,{value:n},e.children)},c={inlineCode:"code",wrapper:function(e){var n=e.children;return a.createElement(a.Fragment,{},n)}},p=a.forwardRef((function(e,n){var t=e.components,o=e.mdxType,r=e.originalType,l=e.parentName,u=s(e,["components","mdxType","originalType","parentName"]),p=m(t),d=o,f=p["".concat(l,".").concat(d)]||p[d]||c[d]||r;return t?a.createElement(f,i(i({ref:n},u),{},{components:t})):a.createElement(f,i({ref:n},u))}));function d(e,n){var t=arguments,o=n&&n.mdxType;if("string"==typeof e||o){var r=t.length,i=new Array(r);i[0]=p;var s={};for(var l in n)hasOwnProperty.call(n,l)&&(s[l]=n[l]);s.originalType=e,s.mdxType="string"==typeof e?e:o,i[1]=s;for(var m=2;m<r;m++)i[m]=t[m];return a.createElement.apply(null,i)}return a.createElement.apply(null,t)}p.displayName="MDXCreateElement"},1016:function(e,n,t){t.d(n,{Z:function(){return s}});var a=t(7462),o=t(3366),r=t(7294),i=["children"];function s(e){var n=e.children,t=(0,o.Z)(e,i);return r.createElement("div",(0,a.Z)({role:"tabpanel"},t),n)}},2099:function(e,n,t){t.d(n,{Z:function(){return p}});var a=t(7294),o=t(9443);var r=function(){var e=(0,a.useContext)(o.Z);if(null==e)throw new Error('"useUserPreferencesContext" is used outside of "Layout" component.');return e},i=t(6010),s="tabItem_OdQc",l="tabItemActive_YQWB",m="tab_tgHH";var u=37,c=39;function p(e){var n=e.lazy,t=e.defaultValue,o=e.values,p=e.groupId,d=r(),f=d.tabGroupChoices,g=d.setTabGroupChoices,N=(0,a.useState)(t),h=N[0],v=N[1],k=a.Children.toArray(e.children),C=[];if(null!=p){var y=f[p];null!=y&&y!==h&&o.some((function(e){return e.value===y}))&&v(y)}var b=function(e){var n=e.currentTarget,t=C.indexOf(n),a=o[t].value;v(a),null!=p&&(g(p,a),setTimeout((function(){var e,t,a,o,r,i,s,m;(e=n.getBoundingClientRect(),t=e.top,a=e.left,o=e.bottom,r=e.right,i=window,s=i.innerHeight,m=i.innerWidth,t>=0&&r<=m&&o<=s&&a>=0)||(n.scrollIntoView({block:"center",behavior:"smooth"}),n.classList.add(l),setTimeout((function(){return n.classList.remove(l)}),2e3))}),150))},w=function(e){var n;switch(e.keyCode){case c:var t=C.indexOf(e.target)+1;n=C[t]||C[0];break;case u:var a=C.indexOf(e.target)-1;n=C[a]||C[C.length-1];break;default:return}n.focus()},I=function(e,n){return n.value===e||n.values&&-1!=n.values.indexOf(e)};return a.createElement("div",{className:"tabs-container"},a.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:"tabs"},o.map((function(e){var n=e.value,t=e.label;return a.createElement("li",{role:"tab",tabIndex:h===n?0:-1,"aria-selected":h===n,className:(0,i.Z)("tabs__item",s,{"tabs__item--active":h===n}),key:n,ref:function(e){return e&&C.push(e)},onKeyDown:w,onFocus:b,onClick:b},t)}))),n?a.cloneElement(k.find((function(e){return I(h,e.props)})),{className:m}):a.createElement("div",null,k.map((function(e,n){return a.cloneElement(e,{key:n,hidden:!I(h,e.props),className:m})}))),a.createElement("br",null))}},6903:function(e,n,t){t.r(n),t.d(n,{frontMatter:function(){return m},contentTitle:function(){return u},metadata:function(){return c},toc:function(){return p},default:function(){return f}});var a=t(7462),o=t(3366),r=(t(7294),t(3905)),i=t(2099),s=t(1016),l=(t(4996),["components"]),m={},u="Custom Names",c={unversionedId:"dev/names/custom-names",id:"dev/names/custom-names",title:"Custom Names",description:"CustomNameInfo",source:"@site/docs/dev/names/custom-names.mdx",sourceDirName:"dev/names",slug:"/dev/names/custom-names",permalink:"/RogueLibs/docs/dev/names/custom-names",editUrl:"https://github.com/SugarBarrel/RogueLibs/edit/main/website/docs/dev/names/custom-names.mdx",tags:[],version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"Overriding Default Behavior",permalink:"/RogueLibs/docs/dev/unlocks/overriding-behavior"},next:{title:"Custom Languages*",permalink:"/RogueLibs/docs/dev/names/custom-languages"}},p=[{value:"<code>CustomNameInfo</code>",id:"customnameinfo",children:[],level:2},{value:"<code>CustomName</code>",id:"customname",children:[],level:2},{value:"Usage",id:"usage",children:[],level:2}],d={toc:p};function f(e){var n=e.components,t=(0,o.Z)(e,l);return(0,r.kt)("wrapper",(0,a.Z)({},d,t,{components:n,mdxType:"MDXLayout"}),(0,r.kt)("h1",{id:"custom-names"},"Custom Names"),(0,r.kt)("h2",{id:"customnameinfo"},(0,r.kt)("inlineCode",{parentName:"h2"},"CustomNameInfo")),(0,r.kt)("p",null,(0,r.kt)("inlineCode",{parentName:"p"},"CustomNameInfo")," structure is used to create custom names and transfer localizations data."),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},'CustomNameInfo emptyInfo = new CustomNameInfo();\nCustomNameInfo nameInfo = new CustomNameInfo("english text");\n')),(0,r.kt)("p",null,"You can add more translations to the custom names too:"),(0,r.kt)(i.Z,{defaultValue:"indexer",values:[{label:"Indexer property",value:"indexer"},{label:"Named properties",value:"named"}],mdxType:"Tabs"},(0,r.kt)(s.Z,{value:"indexer",mdxType:"TabItem"},(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},'nameInfo = new CustomNameInfo\n{\n    [LanguageCode.French] = "texte fran\xe7ais",\n    [LanguageCode.Spanish] = "texto en espa\xf1ol",\n};\n// or\nnameInfo[LanguageCode.French] = "texte fran\xe7ais";\nnameInfo[LanguageCode.Spanish] = "texto en espa\xf1ol";\n')),(0,r.kt)("p",null,"You can also use your own language codes:"),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},'nameInfo[(LanguageCode)123] = "\u65e5\u672c\u8a9e\u30c6\u30ad\u30b9\u30c8";\n')),(0,r.kt)("div",{className:"admonition admonition-info alert alert--info"},(0,r.kt)("div",{parentName:"div",className:"admonition-heading"},(0,r.kt)("h5",{parentName:"div"},(0,r.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,r.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,r.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M7 2.3c3.14 0 5.7 2.56 5.7 5.7s-2.56 5.7-5.7 5.7A5.71 5.71 0 0 1 1.3 8c0-3.14 2.56-5.7 5.7-5.7zM7 1C3.14 1 0 4.14 0 8s3.14 7 7 7 7-3.14 7-7-3.14-7-7-7zm1 3H6v5h2V4zm0 6H6v2h2v-2z"}))),"info")),(0,r.kt)("div",{parentName:"div",className:"admonition-content"},(0,r.kt)("p",{parentName:"div"},"See more info in ",(0,r.kt)("a",{parentName:"p",href:"./custom-languages"},"Custom Languages"),".")))),(0,r.kt)(s.Z,{value:"named",mdxType:"TabItem"},(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},'nameInfo = new CustomNameInfo\n{\n    French = "texte fran\xe7ais",\n    Spanish = "texto en espa\xf1ol",\n};\n// or\nnameInfo.French = "texte fran\xe7ais";\nnameInfo.Spanish = "texto en espa\xf1ol";\n')))),(0,r.kt)("p",null,"Unlike dictionaries, both ",(0,r.kt)("inlineCode",{parentName:"p"},"CustomName")," and ",(0,r.kt)("inlineCode",{parentName:"p"},"CustomNameInfo")," return ",(0,r.kt)("inlineCode",{parentName:"p"},"null"),", if they don't contain the specified ",(0,r.kt)("inlineCode",{parentName:"p"},"LanguageCode"),":"),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},"string translation = nameInfo[(LanguageCode)123];\n// returns null, if that language is not specified\nstring display = translation ?? nameInfo.English;\n")),(0,r.kt)("h2",{id:"customname"},(0,r.kt)("inlineCode",{parentName:"h2"},"CustomName")),(0,r.kt)("p",null,"Usually, ",(0,r.kt)("inlineCode",{parentName:"p"},"CustomName"),"s are created automatically, when you add names and descriptions to your items, traits, abilities and etc.:"),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},'RogueLibs.CreateCustomItem<MyCustomItem>()\n    .WithName(new CustomNameInfo("English name")\n    {\n        French = "nom fran\xe7ais",\n        Spanish = "nombre espa\xf1ol",\n    })\n    .WithDescription(new CustomNameInfo("English description")\n    {\n        French = "description fran\xe7aise",\n        Spanish = "descripci\xf3n en espa\xf1ol",\n    });\n')),(0,r.kt)("p",null,"You can initialize them yourself too, although you have to provide the name and type of the ",(0,r.kt)("inlineCode",{parentName:"p"},"CustomName")," yourself:"),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},'CustomName name = RogueLibs.CreateCustomName("Name", "Type", new CustomNameInfo("Info"));\n')),(0,r.kt)("p",null,"If you're going to use the second method, here's the list of types used in the game:"),(0,r.kt)("ul",null,(0,r.kt)("li",{parentName:"ul"},(0,r.kt)("inlineCode",{parentName:"li"},"Item")," - item and special ability names;"),(0,r.kt)("li",{parentName:"ul"},(0,r.kt)("inlineCode",{parentName:"li"},"Description")," - item, special ability, trait, status effect and agent descriptions;"),(0,r.kt)("li",{parentName:"ul"},(0,r.kt)("inlineCode",{parentName:"li"},"StatusEffect")," - trait and status effect names;"),(0,r.kt)("li",{parentName:"ul"},(0,r.kt)("inlineCode",{parentName:"li"},"Interface")," - interface buttons, labels and stuff;"),(0,r.kt)("li",{parentName:"ul"},(0,r.kt)("inlineCode",{parentName:"li"},"Unlock")," - mutator and Big Quest names and descriptions;"),(0,r.kt)("li",{parentName:"ul"},(0,r.kt)("inlineCode",{parentName:"li"},"Object")," - object and chunk type names;"),(0,r.kt)("li",{parentName:"ul"},(0,r.kt)("inlineCode",{parentName:"li"},"Agent")," - agent names;"),(0,r.kt)("li",{parentName:"ul"},(0,r.kt)("inlineCode",{parentName:"li"},"Dialogue")," - agent dialogue lines;")),(0,r.kt)("div",{className:"admonition admonition-tip alert alert--success"},(0,r.kt)("div",{parentName:"div",className:"admonition-heading"},(0,r.kt)("h5",{parentName:"div"},(0,r.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,r.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"12",height:"16",viewBox:"0 0 12 16"},(0,r.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.5 0C3.48 0 1 2.19 1 5c0 .92.55 2.25 1 3 1.34 2.25 1.78 2.78 2 4v1h5v-1c.22-1.22.66-1.75 2-4 .45-.75 1-2.08 1-3 0-2.81-2.48-5-5.5-5zm3.64 7.48c-.25.44-.47.8-.67 1.11-.86 1.41-1.25 2.06-1.45 3.23-.02.05-.02.11-.02.17H5c0-.06 0-.13-.02-.17-.2-1.17-.59-1.83-1.45-3.23-.2-.31-.42-.67-.67-1.11C2.44 6.78 2 5.65 2 5c0-2.2 2.02-4 4.5-4 1.22 0 2.36.42 3.22 1.19C10.55 2.94 11 3.94 11 5c0 .66-.44 1.78-.86 2.48zM4 14h5c-.23 1.14-1.3 2-2.5 2s-2.27-.86-2.5-2z"}))),"Pro-tip: Name type const strings")),(0,r.kt)("div",{parentName:"div",className:"admonition-content"},(0,r.kt)("p",{parentName:"div"},"Use string consts in the ",(0,r.kt)("inlineCode",{parentName:"p"},"NameTypes")," static class to avoid typos."))),(0,r.kt)("h2",{id:"usage"},"Usage"),(0,r.kt)("p",null,"If you want to use your custom names in the game, use ",(0,r.kt)("inlineCode",{parentName:"p"},"NameDB.GetName()")," or any other methods that use it:"),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},'string dialogue = gc.nameDB.GetName("CryForHelp", NameTypes.Dialogue);\n')),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},'Owner.SayDialogue("CryForHelp");\n')),(0,r.kt)("p",null,(0,r.kt)("inlineCode",{parentName:"p"},"CustomName"),"s and ",(0,r.kt)("inlineCode",{parentName:"p"},"CustomNameInfo"),"s also can be implicitly converted into ",(0,r.kt)("inlineCode",{parentName:"p"},"CustomTooltip"),":"),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},'public class Recycler : CustomItem, IItemCombinable\n{\n    [RLSetup]\n    public static void Setup()\n    {\n        recycleTooltip = RogueLibs.CreateCustomName("Recycle", NameTypes.Interface, new CustomNameInfo\n        {\n            English = "Recycle",\n            Russian = "\u041f\u0435\u0440\u0435\u0440\u0430\u0431\u043e\u0442\u0430\u0442\u044c",\n        });\n    }\n    private static CustomName recycleTooltip;\n\n    /* ... */\n    public CustomTooltip CombineTooltip(InvItem _) => recycleTooltip;\n}\n')))}f.isMDXComponent=!0}}]);