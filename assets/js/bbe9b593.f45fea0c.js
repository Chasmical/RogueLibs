"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[2289],{3905:function(e,t,n){n.d(t,{Zo:function(){return u},kt:function(){return d}});var a=n(7294);function o(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function r(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var a=Object.getOwnPropertySymbols(e);t&&(a=a.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,a)}return n}function i(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?r(Object(n),!0).forEach((function(t){o(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):r(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function l(e,t){if(null==e)return{};var n,a,o=function(e,t){if(null==e)return{};var n,a,o={},r=Object.keys(e);for(a=0;a<r.length;a++)n=r[a],t.indexOf(n)>=0||(o[n]=e[n]);return o}(e,t);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(e);for(a=0;a<r.length;a++)n=r[a],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(o[n]=e[n])}return o}var s=a.createContext({}),c=function(e){var t=a.useContext(s),n=t;return e&&(n="function"==typeof e?e(t):i(i({},t),e)),n},u=function(e){var t=c(e.components);return a.createElement(s.Provider,{value:t},e.children)},m={inlineCode:"code",wrapper:function(e){var t=e.children;return a.createElement(a.Fragment,{},t)}},p=a.forwardRef((function(e,t){var n=e.components,o=e.mdxType,r=e.originalType,s=e.parentName,u=l(e,["components","mdxType","originalType","parentName"]),p=c(n),d=o,k=p["".concat(s,".").concat(d)]||p[d]||m[d]||r;return n?a.createElement(k,i(i({ref:t},u),{},{components:n})):a.createElement(k,i({ref:t},u))}));function d(e,t){var n=arguments,o=t&&t.mdxType;if("string"==typeof e||o){var r=n.length,i=new Array(r);i[0]=p;var l={};for(var s in t)hasOwnProperty.call(t,s)&&(l[s]=t[s]);l.originalType=e,l.mdxType="string"==typeof e?e:o,i[1]=l;for(var c=2;c<r;c++)i[c]=n[c];return a.createElement.apply(null,i)}return a.createElement.apply(null,n)}p.displayName="MDXCreateElement"},1016:function(e,t,n){n.d(t,{Z:function(){return l}});var a=n(7462),o=n(3366),r=n(7294),i=["children"];function l(e){var t=e.children,n=(0,o.Z)(e,i);return r.createElement("div",(0,a.Z)({role:"tabpanel"},n),t)}},2099:function(e,t,n){n.d(t,{Z:function(){return p}});var a=n(7294),o=n(9443);var r=function(){var e=(0,a.useContext)(o.Z);if(null==e)throw new Error('"useUserPreferencesContext" is used outside of "Layout" component.');return e},i=n(6010),l="tabItem_OdQc",s="tabItemActive_YQWB",c="tab_tgHH";var u=37,m=39;function p(e){var t=e.lazy,n=e.defaultValue,o=e.values,p=e.groupId,d=r(),k=d.tabGroupChoices,v=d.setTabGroupChoices,f=(0,a.useState)(n),h=f[0],g=f[1],N=a.Children.toArray(e.children),b=[];if(null!=p){var y=k[p];null!=y&&y!==h&&o.some((function(e){return e.value===y}))&&g(y)}var C=function(e){var t=e.currentTarget,n=b.indexOf(t),a=o[n].value;g(a),null!=p&&(v(p,a),setTimeout((function(){var e,n,a,o,r,i,l,c;(e=t.getBoundingClientRect(),n=e.top,a=e.left,o=e.bottom,r=e.right,i=window,l=i.innerHeight,c=i.innerWidth,n>=0&&r<=c&&o<=l&&a>=0)||(t.scrollIntoView({block:"center",behavior:"smooth"}),t.classList.add(s),setTimeout((function(){return t.classList.remove(s)}),2e3))}),150))},w=function(e){var t;switch(e.keyCode){case m:var n=b.indexOf(e.target)+1;t=b[n]||b[0];break;case u:var a=b.indexOf(e.target)-1;t=b[a]||b[b.length-1];break;default:return}t.focus()},O=function(e,t){return t.value===e||t.values&&-1!=t.values.indexOf(e)};return a.createElement("div",{className:"tabs-container"},a.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:"tabs"},o.map((function(e){var t=e.value,n=e.label;return a.createElement("li",{role:"tab",tabIndex:h===t?0:-1,"aria-selected":h===t,className:(0,i.Z)("tabs__item",l,{"tabs__item--active":h===t}),key:t,ref:function(e){return e&&b.push(e)},onKeyDown:w,onFocus:C,onClick:C},n)}))),t?a.cloneElement(N.find((function(e){return O(h,e.props)})),{className:c}):a.createElement("div",null,N.map((function(e,t){return a.cloneElement(e,{key:t,hidden:!O(h,e.props),className:c})}))),a.createElement("br",null))}},1183:function(e,t,n){n.r(t),n.d(t,{frontMatter:function(){return l},contentTitle:function(){return s},metadata:function(){return c},toc:function(){return u},default:function(){return p}});var a=n(7462),o=n(3366),r=(n(7294),n(3905)),i=(n(2099),n(1016),n(4996),["components"]),l={},s="Custom Unlocks",c={unversionedId:"dev/unlocks/custom-unlocks",id:"dev/unlocks/custom-unlocks",title:"Custom Unlocks",description:"UnlockWrapper class",source:"@site/docs/dev/unlocks/custom-unlocks.mdx",sourceDirName:"dev/unlocks",slug:"/dev/unlocks/custom-unlocks",permalink:"/RogueLibs/docs/dev/unlocks/custom-unlocks",editUrl:"https://github.com/SugarBarrel/RogueLibs/edit/main/website/docs/dev/unlocks/custom-unlocks.mdx",tags:[],version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"Creating a Custom Effect",permalink:"/RogueLibs/docs/dev/traits/create-effect"},next:{title:"Overriding Default Behavior",permalink:"/RogueLibs/docs/dev/unlocks/overriding-behavior"}},u=[{value:"<code>UnlockWrapper</code> class",id:"unlockwrapper",children:[],level:2},{value:"<code>DisplayedUnlock</code> class",id:"displayedunlock",children:[],level:2},{value:"Unlock classes",id:"unlock-classes",children:[],level:2},{value:"Initialization",id:"initialization",children:[],level:2}],m={toc:u};function p(e){var t=e.components,n=(0,o.Z)(e,i);return(0,r.kt)("wrapper",(0,a.Z)({},m,n,{components:t,mdxType:"MDXLayout"}),(0,r.kt)("h1",{id:"custom-unlocks"},"Custom Unlocks"),(0,r.kt)("h2",{id:"unlockwrapper"},(0,r.kt)("inlineCode",{parentName:"h2"},"UnlockWrapper")," class"),(0,r.kt)("p",null,"All of the unlocks in the game are wrapped in a more flexible class - ",(0,r.kt)("inlineCode",{parentName:"p"},"UnlockWrapper"),"."),(0,r.kt)("p",null,(0,r.kt)("inlineCode",{parentName:"p"},"UnlockWrapper")," provides methods to get the unlock's name, description, image and other stuff."),(0,r.kt)("div",{className:"admonition admonition-caution alert alert--warning"},(0,r.kt)("div",{parentName:"div",className:"admonition-heading"},(0,r.kt)("h5",{parentName:"div"},(0,r.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,r.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"16",height:"16",viewBox:"0 0 16 16"},(0,r.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M8.893 1.5c-.183-.31-.52-.5-.887-.5s-.703.19-.886.5L.138 13.499a.98.98 0 0 0 0 1.001c.193.31.53.501.886.501h13.964c.367 0 .704-.19.877-.5a1.03 1.03 0 0 0 .01-1.002L8.893 1.5zm.133 11.497H6.987v-2.003h2.039v2.003zm0-3.004H6.987V5.987h2.039v4.006z"}))),"caution")),(0,r.kt)("div",{parentName:"div",className:"admonition-content"},(0,r.kt)("p",{parentName:"div"},"You probably shouldn't implement ",(0,r.kt)("inlineCode",{parentName:"p"},"UnlockWrapper")," directly. Use the classes described later on the page."))),(0,r.kt)("h2",{id:"displayedunlock"},(0,r.kt)("inlineCode",{parentName:"h2"},"DisplayedUnlock")," class"),(0,r.kt)("p",null,(0,r.kt)("inlineCode",{parentName:"p"},"DisplayedUnlock")," derives from the ",(0,r.kt)("inlineCode",{parentName:"p"},"UnlockWrapper")," class. It provides methods to display the unlock in the in-game menus."),(0,r.kt)("div",{className:"admonition admonition-caution alert alert--warning"},(0,r.kt)("div",{parentName:"div",className:"admonition-heading"},(0,r.kt)("h5",{parentName:"div"},(0,r.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,r.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"16",height:"16",viewBox:"0 0 16 16"},(0,r.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M8.893 1.5c-.183-.31-.52-.5-.887-.5s-.703.19-.886.5L.138 13.499a.98.98 0 0 0 0 1.001c.193.31.53.501.886.501h13.964c.367 0 .704-.19.877-.5a1.03 1.03 0 0 0 .01-1.002L8.893 1.5zm.133 11.497H6.987v-2.003h2.039v2.003zm0-3.004H6.987V5.987h2.039v4.006z"}))),"caution")),(0,r.kt)("div",{parentName:"div",className:"admonition-content"},(0,r.kt)("p",{parentName:"div"},"You shouldn't implement ",(0,r.kt)("inlineCode",{parentName:"p"},"DisplayedUnlock")," directly either. Use the classes described later on the page."))),(0,r.kt)("h2",{id:"unlock-classes"},"Unlock classes"),(0,r.kt)("p",null,"RogueLibs provides the following classes that you can derive from:"),(0,r.kt)("ul",null,(0,r.kt)("li",{parentName:"ul"},(0,r.kt)("inlineCode",{parentName:"li"},"ItemUnlock")," - for items;"),(0,r.kt)("li",{parentName:"ul"},(0,r.kt)("inlineCode",{parentName:"li"},"AbilityUnlock")," - for abilities;"),(0,r.kt)("li",{parentName:"ul"},(0,r.kt)("inlineCode",{parentName:"li"},"TraitUnlock")," - for traits;"),(0,r.kt)("li",{parentName:"ul"},(0,r.kt)("inlineCode",{parentName:"li"},"MutatorUnlock")," - for mutators;"),(0,r.kt)("li",{parentName:"ul"},(0,r.kt)("inlineCode",{parentName:"li"},"AgentUnlock")," - for agents;"),(0,r.kt)("li",{parentName:"ul"},(0,r.kt)("inlineCode",{parentName:"li"},"BigQuestUnlock")," - for agent Big Quests;"),(0,r.kt)("li",{parentName:"ul"},(0,r.kt)("inlineCode",{parentName:"li"},"ExtraUnlock")," - for achievements and other stuff;"),(0,r.kt)("li",{parentName:"ul"},(0,r.kt)("inlineCode",{parentName:"li"},"FloorUnlock")," - for floor unlocks;")),(0,r.kt)("div",{className:"admonition admonition-note alert alert--secondary"},(0,r.kt)("div",{parentName:"div",className:"admonition-heading"},(0,r.kt)("h5",{parentName:"div"},(0,r.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,r.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,r.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.3 5.69a.942.942 0 0 1-.28-.7c0-.28.09-.52.28-.7.19-.18.42-.28.7-.28.28 0 .52.09.7.28.18.19.28.42.28.7 0 .28-.09.52-.28.7a1 1 0 0 1-.7.3c-.28 0-.52-.11-.7-.3zM8 7.99c-.02-.25-.11-.48-.31-.69-.2-.19-.42-.3-.69-.31H6c-.27.02-.48.13-.69.31-.2.2-.3.44-.31.69h1v3c.02.27.11.5.31.69.2.2.42.31.69.31h1c.27 0 .48-.11.69-.31.2-.19.3-.42.31-.69H8V7.98v.01zM7 2.3c-3.14 0-5.7 2.54-5.7 5.68 0 3.14 2.56 5.7 5.7 5.7s5.7-2.55 5.7-5.7c0-3.15-2.56-5.69-5.7-5.69v.01zM7 .98c3.86 0 7 3.14 7 7s-3.14 7-7 7-7-3.12-7-7 3.14-7 7-7z"}))),"note")),(0,r.kt)("div",{parentName:"div",className:"admonition-content"},(0,r.kt)("p",{parentName:"div"},"There's also a couple of classes that are in RogueLibs only for compatibility reasons."))),(0,r.kt)("h2",{id:"initialization"},"Initialization"),(0,r.kt)("p",null,"You can initialize your unlocks like this:"),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyCustomItem.cs"',title:'"MyCustomItem.cs"'},'public class MyCustomItem : CustomItem\n{\n    [RLSetup]\n    public static void Setup()\n    {\n        RogueLibs.CreateCustomItem<MyCustomItem>();\n            .WithName(new CustomNameInfo("My Custom Item"))\n            .WithDescription(new CustomNameInfo("My Custom Item is very cool and does a lot of great stuff"));\n            .WithSprite(Properties.Resources.MyCustomItem)\n            // highlight-next-line\n            .WithUnlock(new ItemUnlock\n            {\n                UnlockCost = 10,\n                CharacterCreationCost = 5,\n                LoadoutCost = 4,\n            });\n    }\n}\n')),(0,r.kt)("p",null,"Or you can just initialize them directly (like in case of mutators):"),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},'RogueLibs.CreateCustomUnlock(new MutatorUnlock("MyMutator"))\n    .WithName(new CustomNameInfo("Mutator Name"))\n    .WithDescription(new CustomNameInfo("Mutator Description"));\n')))}p.isMDXComponent=!0}}]);