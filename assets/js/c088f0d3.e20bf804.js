"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[6750],{3905:(e,t,n)=>{n.d(t,{Zo:()=>u,kt:()=>d});var a=n(7294);function o(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function r(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var a=Object.getOwnPropertySymbols(e);t&&(a=a.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,a)}return n}function i(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?r(Object(n),!0).forEach((function(t){o(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):r(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function s(e,t){if(null==e)return{};var n,a,o=function(e,t){if(null==e)return{};var n,a,o={},r=Object.keys(e);for(a=0;a<r.length;a++)n=r[a],t.indexOf(n)>=0||(o[n]=e[n]);return o}(e,t);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(e);for(a=0;a<r.length;a++)n=r[a],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(o[n]=e[n])}return o}var l=a.createContext({}),m=function(e){var t=a.useContext(l),n=t;return e&&(n="function"==typeof e?e(t):i(i({},t),e)),n},u=function(e){var t=m(e.components);return a.createElement(l.Provider,{value:t},e.children)},c={inlineCode:"code",wrapper:function(e){var t=e.children;return a.createElement(a.Fragment,{},t)}},p=a.forwardRef((function(e,t){var n=e.components,o=e.mdxType,r=e.originalType,l=e.parentName,u=s(e,["components","mdxType","originalType","parentName"]),p=m(n),d=o,g=p["".concat(l,".").concat(d)]||p[d]||c[d]||r;return n?a.createElement(g,i(i({ref:t},u),{},{components:n})):a.createElement(g,i({ref:t},u))}));function d(e,t){var n=arguments,o=t&&t.mdxType;if("string"==typeof e||o){var r=n.length,i=new Array(r);i[0]=p;var s={};for(var l in t)hasOwnProperty.call(t,l)&&(s[l]=t[l]);s.originalType=e,s.mdxType="string"==typeof e?e:o,i[1]=s;for(var m=2;m<r;m++)i[m]=n[m];return a.createElement.apply(null,i)}return a.createElement.apply(null,n)}p.displayName="MDXCreateElement"},1016:(e,t,n)=>{n.d(t,{Z:()=>r});var a=n(7462),o=n(7294);function r(e){let{children:t,...n}=e;return o.createElement("div",(0,a.Z)({role:"tabpanel"},n),t)}},250:(e,t,n)=>{n.d(t,{Z:()=>c});var a=n(7294),o=n(7094),r=n(6010);const i="tabItem_V91s",s="tabItemActive_JsUu",l="tab_ntnM";const m=37,u=39;function c(e){const{lazy:t,defaultValue:n,values:c,groupId:p}=e,{tabGroupChoices:d,setTabGroupChoices:g}=(0,o.U)(),[f,N]=(0,a.useState)(n),h=a.Children.toArray(e.children),k=[];if(null!=p){const e=d[p];null!=e&&e!==f&&c.some((t=>t.value===e))&&N(e)}const v=e=>{const t=e.currentTarget,n=k.indexOf(t),a=c[n].value;N(a),null!=p&&(g(p,a),setTimeout((()=>{(function(e){const{top:t,left:n,bottom:a,right:o}=e.getBoundingClientRect(),{innerHeight:r,innerWidth:i}=window;return t>=0&&o<=i&&a<=r&&n>=0})(t)||(t.scrollIntoView({block:"center",behavior:"smooth"}),t.classList.add(s),setTimeout((()=>t.classList.remove(s)),2e3))}),150))},C=e=>{let t;switch(e.keyCode){case u:{const n=k.indexOf(e.target)+1;t=k[n]||k[0];break}case m:{const n=k.indexOf(e.target)-1;t=k[n]||k[k.length-1];break}default:return}t.focus()},y=(e,t)=>t.value===e||t.values&&-1!=t.values.indexOf(e);return a.createElement("div",{className:"tabs-container"},a.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:"tabs"},c.map((e=>{let{value:t,label:n}=e;return a.createElement("li",{role:"tab",tabIndex:f===t?0:-1,"aria-selected":f===t,className:(0,r.Z)("tabs__item",i,{"tabs__item--active":f===t}),key:t,ref:e=>e&&k.push(e),onKeyDown:C,onFocus:v,onClick:v},n)}))),t?a.cloneElement(h.find((e=>y(f,e.props))),{className:l}):a.createElement("div",null,h.map(((e,t)=>a.cloneElement(e,{key:t,hidden:!y(f,e.props),className:l})))),a.createElement("br",null))}},6903:(e,t,n)=>{n.r(t),n.d(t,{assets:()=>u,contentTitle:()=>l,default:()=>d,frontMatter:()=>s,metadata:()=>m,toc:()=>c});var a=n(7462),o=(n(7294),n(3905)),r=n(250),i=n(1016);n(4996);const s={},l="Custom Names",m={unversionedId:"dev/names/custom-names",id:"dev/names/custom-names",title:"Custom Names",description:"CustomNameInfo",source:"@site/docs/dev/names/custom-names.mdx",sourceDirName:"dev/names",slug:"/dev/names/custom-names",permalink:"/RogueLibs/docs/dev/names/custom-names",draft:!1,editUrl:"https://github.com/SugarBarrel/RogueLibs/edit/main/website/docs/dev/names/custom-names.mdx",tags:[],version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"Overriding Default Behavior",permalink:"/RogueLibs/docs/dev/unlocks/overriding-behavior"},next:{title:"Custom Languages*",permalink:"/RogueLibs/docs/dev/names/custom-languages"}},u={},c=[{value:"<code>CustomNameInfo</code>",id:"customnameinfo",level:2},{value:"<code>CustomName</code>",id:"customname",level:2},{value:"Usage",id:"usage",level:2}],p={toc:c};function d(e){let{components:t,...n}=e;return(0,o.kt)("wrapper",(0,a.Z)({},p,n,{components:t,mdxType:"MDXLayout"}),(0,o.kt)("h1",{id:"custom-names"},"Custom Names"),(0,o.kt)("h2",{id:"customnameinfo"},(0,o.kt)("inlineCode",{parentName:"h2"},"CustomNameInfo")),(0,o.kt)("p",null,(0,o.kt)("inlineCode",{parentName:"p"},"CustomNameInfo")," structure is used to create custom names and transfer localizations data."),(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-csharp"},'CustomNameInfo emptyInfo = new CustomNameInfo();\nCustomNameInfo nameInfo = new CustomNameInfo("english text");\n')),(0,o.kt)("p",null,"You can add more translations to the custom names too:"),(0,o.kt)(r.Z,{defaultValue:"indexer",values:[{label:"Indexer property",value:"indexer"},{label:"Named properties",value:"named"}],mdxType:"Tabs"},(0,o.kt)(i.Z,{value:"indexer",mdxType:"TabItem"},(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-csharp"},'nameInfo = new CustomNameInfo\n{\n    [LanguageCode.French] = "texte fran\xe7ais",\n    [LanguageCode.Spanish] = "texto en espa\xf1ol",\n};\n// or\nnameInfo[LanguageCode.French] = "texte fran\xe7ais";\nnameInfo[LanguageCode.Spanish] = "texto en espa\xf1ol";\n')),(0,o.kt)("p",null,"You can also use your own language codes:"),(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-csharp"},'nameInfo[(LanguageCode)123] = "\u65e5\u672c\u8a9e\u30c6\u30ad\u30b9\u30c8";\n')),(0,o.kt)("div",{className:"admonition admonition-info alert alert--info"},(0,o.kt)("div",{parentName:"div",className:"admonition-heading"},(0,o.kt)("h5",{parentName:"div"},(0,o.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,o.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,o.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M7 2.3c3.14 0 5.7 2.56 5.7 5.7s-2.56 5.7-5.7 5.7A5.71 5.71 0 0 1 1.3 8c0-3.14 2.56-5.7 5.7-5.7zM7 1C3.14 1 0 4.14 0 8s3.14 7 7 7 7-3.14 7-7-3.14-7-7-7zm1 3H6v5h2V4zm0 6H6v2h2v-2z"}))),"info")),(0,o.kt)("div",{parentName:"div",className:"admonition-content"},(0,o.kt)("p",{parentName:"div"},"See more info in ",(0,o.kt)("a",{parentName:"p",href:"./custom-languages"},"Custom Languages"),".")))),(0,o.kt)(i.Z,{value:"named",mdxType:"TabItem"},(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-csharp"},'nameInfo = new CustomNameInfo\n{\n    French = "texte fran\xe7ais",\n    Spanish = "texto en espa\xf1ol",\n};\n// or\nnameInfo.French = "texte fran\xe7ais";\nnameInfo.Spanish = "texto en espa\xf1ol";\n')))),(0,o.kt)("p",null,"Unlike dictionaries, both ",(0,o.kt)("inlineCode",{parentName:"p"},"CustomName")," and ",(0,o.kt)("inlineCode",{parentName:"p"},"CustomNameInfo")," return ",(0,o.kt)("inlineCode",{parentName:"p"},"null"),", if they don't contain the specified ",(0,o.kt)("inlineCode",{parentName:"p"},"LanguageCode"),":"),(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-csharp"},"string translation = nameInfo[(LanguageCode)123];\n// returns null, if that language is not specified\nstring display = translation ?? nameInfo.English;\n")),(0,o.kt)("h2",{id:"customname"},(0,o.kt)("inlineCode",{parentName:"h2"},"CustomName")),(0,o.kt)("p",null,"Usually, ",(0,o.kt)("inlineCode",{parentName:"p"},"CustomName"),"s are created automatically, when you add names and descriptions to your items, traits, abilities and etc.:"),(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-csharp"},'RogueLibs.CreateCustomItem<MyCustomItem>()\n    .WithName(new CustomNameInfo("English name")\n    {\n        French = "nom fran\xe7ais",\n        Spanish = "nombre espa\xf1ol",\n    })\n    .WithDescription(new CustomNameInfo("English description")\n    {\n        French = "description fran\xe7aise",\n        Spanish = "descripci\xf3n en espa\xf1ol",\n    });\n')),(0,o.kt)("p",null,"You can initialize them yourself too, although you have to provide the name and type of the ",(0,o.kt)("inlineCode",{parentName:"p"},"CustomName")," yourself:"),(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-csharp"},'CustomName name = RogueLibs.CreateCustomName("Name", "Type", new CustomNameInfo("Info"));\n')),(0,o.kt)("p",null,"If you're going to use the second method, here's the list of types used in the game:"),(0,o.kt)("ul",null,(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("inlineCode",{parentName:"li"},"Item")," - item and special ability names;"),(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("inlineCode",{parentName:"li"},"Description")," - item, special ability, trait, status effect and agent descriptions;"),(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("inlineCode",{parentName:"li"},"StatusEffect")," - trait and status effect names;"),(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("inlineCode",{parentName:"li"},"Interface")," - interface buttons, labels and stuff;"),(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("inlineCode",{parentName:"li"},"Unlock")," - mutator and Big Quest names and descriptions;"),(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("inlineCode",{parentName:"li"},"Object")," - object and chunk type names;"),(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("inlineCode",{parentName:"li"},"Agent")," - agent names;"),(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("inlineCode",{parentName:"li"},"Dialogue")," - agent dialogue lines;")),(0,o.kt)("div",{className:"admonition admonition-tip alert alert--success"},(0,o.kt)("div",{parentName:"div",className:"admonition-heading"},(0,o.kt)("h5",{parentName:"div"},(0,o.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,o.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"12",height:"16",viewBox:"0 0 12 16"},(0,o.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.5 0C3.48 0 1 2.19 1 5c0 .92.55 2.25 1 3 1.34 2.25 1.78 2.78 2 4v1h5v-1c.22-1.22.66-1.75 2-4 .45-.75 1-2.08 1-3 0-2.81-2.48-5-5.5-5zm3.64 7.48c-.25.44-.47.8-.67 1.11-.86 1.41-1.25 2.06-1.45 3.23-.02.05-.02.11-.02.17H5c0-.06 0-.13-.02-.17-.2-1.17-.59-1.83-1.45-3.23-.2-.31-.42-.67-.67-1.11C2.44 6.78 2 5.65 2 5c0-2.2 2.02-4 4.5-4 1.22 0 2.36.42 3.22 1.19C10.55 2.94 11 3.94 11 5c0 .66-.44 1.78-.86 2.48zM4 14h5c-.23 1.14-1.3 2-2.5 2s-2.27-.86-2.5-2z"}))),"Pro-tip: Name type const strings")),(0,o.kt)("div",{parentName:"div",className:"admonition-content"},(0,o.kt)("p",{parentName:"div"},"Use string consts in the ",(0,o.kt)("inlineCode",{parentName:"p"},"NameTypes")," static class to avoid typos."))),(0,o.kt)("h2",{id:"usage"},"Usage"),(0,o.kt)("p",null,"If you want to use your custom names in the game, use ",(0,o.kt)("inlineCode",{parentName:"p"},"NameDB.GetName()")," or any other methods that use it:"),(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-csharp"},'string dialogue = gc.nameDB.GetName("CryForHelp", NameTypes.Dialogue);\n')),(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-csharp"},'Owner.SayDialogue("CryForHelp");\n')),(0,o.kt)("p",null,(0,o.kt)("inlineCode",{parentName:"p"},"CustomName"),"s and ",(0,o.kt)("inlineCode",{parentName:"p"},"CustomNameInfo"),"s also can be implicitly converted into ",(0,o.kt)("inlineCode",{parentName:"p"},"CustomTooltip"),":"),(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-csharp"},'public class Recycler : CustomItem, IItemCombinable\n{\n    [RLSetup]\n    public static void Setup()\n    {\n        recycleTooltip = RogueLibs.CreateCustomName("Recycle", NameTypes.Interface, new CustomNameInfo\n        {\n            English = "Recycle",\n            Russian = "\u041f\u0435\u0440\u0435\u0440\u0430\u0431\u043e\u0442\u0430\u0442\u044c",\n        });\n    }\n    private static CustomName recycleTooltip;\n\n    /* ... */\n    public CustomTooltip CombineTooltip(InvItem _) => recycleTooltip;\n}\n')))}d.isMDXComponent=!0}}]);