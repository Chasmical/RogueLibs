"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[4929],{3905:function(e,t,n){n.d(t,{Zo:function(){return c},kt:function(){return m}});var a=n(7294);function i(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function r(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var a=Object.getOwnPropertySymbols(e);t&&(a=a.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,a)}return n}function o(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?r(Object(n),!0).forEach((function(t){i(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):r(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function l(e,t){if(null==e)return{};var n,a,i=function(e,t){if(null==e)return{};var n,a,i={},r=Object.keys(e);for(a=0;a<r.length;a++)n=r[a],t.indexOf(n)>=0||(i[n]=e[n]);return i}(e,t);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(e);for(a=0;a<r.length;a++)n=r[a],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(i[n]=e[n])}return i}var s=a.createContext({}),u=function(e){var t=a.useContext(s),n=t;return e&&(n="function"==typeof e?e(t):o(o({},t),e)),n},c=function(e){var t=u(e.components);return a.createElement(s.Provider,{value:t},e.children)},p={inlineCode:"code",wrapper:function(e){var t=e.children;return a.createElement(a.Fragment,{},t)}},d=a.forwardRef((function(e,t){var n=e.components,i=e.mdxType,r=e.originalType,s=e.parentName,c=l(e,["components","mdxType","originalType","parentName"]),d=u(n),m=i,h=d["".concat(s,".").concat(m)]||d[m]||p[m]||r;return n?a.createElement(h,o(o({ref:t},c),{},{components:n})):a.createElement(h,o({ref:t},c))}));function m(e,t){var n=arguments,i=t&&t.mdxType;if("string"==typeof e||i){var r=n.length,o=new Array(r);o[0]=d;var l={};for(var s in t)hasOwnProperty.call(t,s)&&(l[s]=t[s]);l.originalType=e,l.mdxType="string"==typeof e?e:i,o[1]=l;for(var u=2;u<r;u++)o[u]=n[u];return a.createElement.apply(null,o)}return a.createElement.apply(null,n)}d.displayName="MDXCreateElement"},1016:function(e,t,n){n.d(t,{Z:function(){return l}});var a=n(7462),i=n(3366),r=n(7294),o=["children"];function l(e){var t=e.children,n=(0,i.Z)(e,o);return r.createElement("div",(0,a.Z)({role:"tabpanel"},n),t)}},2099:function(e,t,n){n.d(t,{Z:function(){return d}});var a=n(7294),i=n(9443);var r=function(){var e=(0,a.useContext)(i.Z);if(null==e)throw new Error('"useUserPreferencesContext" is used outside of "Layout" component.');return e},o=n(6010),l="tabItem_OdQc",s="tabItemActive_YQWB",u="tab_tgHH";var c=37,p=39;function d(e){var t=e.lazy,n=e.defaultValue,i=e.values,d=e.groupId,m=r(),h=m.tabGroupChoices,v=m.setTabGroupChoices,g=(0,a.useState)(n),f=g[0],k=g[1],b=a.Children.toArray(e.children),y=[];if(null!=d){var N=h[d];null!=N&&N!==f&&i.some((function(e){return e.value===N}))&&k(N)}var w=function(e){var t=e.currentTarget,n=y.indexOf(t),a=i[n].value;k(a),null!=d&&(v(d,a),setTimeout((function(){var e,n,a,i,r,o,l,u;(e=t.getBoundingClientRect(),n=e.top,a=e.left,i=e.bottom,r=e.right,o=window,l=o.innerHeight,u=o.innerWidth,n>=0&&r<=u&&i<=l&&a>=0)||(t.scrollIntoView({block:"center",behavior:"smooth"}),t.classList.add(s),setTimeout((function(){return t.classList.remove(s)}),2e3))}),150))},x=function(e){var t;switch(e.keyCode){case p:var n=y.indexOf(e.target)+1;t=y[n]||y[0];break;case c:var a=y.indexOf(e.target)-1;t=y[a]||y[y.length-1];break;default:return}t.focus()},O=function(e,t){return t.value===e||t.values&&-1!=t.values.indexOf(e)};return a.createElement("div",{className:"tabs-container"},a.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:"tabs"},i.map((function(e){var t=e.value,n=e.label;return a.createElement("li",{role:"tab",tabIndex:f===t?0:-1,"aria-selected":f===t,className:(0,o.Z)("tabs__item",l,{"tabs__item--active":f===t}),key:t,ref:function(e){return e&&y.push(e)},onKeyDown:x,onFocus:w,onClick:w},n)}))),t?a.cloneElement(b.find((function(e){return O(f,e.props)})),{className:u}):a.createElement("div",null,b.map((function(e,t){return a.cloneElement(e,{key:t,hidden:!O(f,e.props),className:u})}))),a.createElement("br",null))}},5451:function(e,t,n){n.r(t),n.d(t,{frontMatter:function(){return c},contentTitle:function(){return p},metadata:function(){return d},toc:function(){return m},default:function(){return v}});var a=n(7462),i=n(3366),r=(n(7294),n(3905)),o=n(2099),l=n(1016),s=n(4996),u=["components"],c={},p="Extra Stuff",d={unversionedId:"dev/extra",id:"dev/extra",title:"Extra Stuff",description:"IDoUpdate and IDoFixedUpdate",source:"@site/docs/dev/extra.mdx",sourceDirName:"dev",slug:"/dev/extra",permalink:"/RogueLibs/docs/dev/extra",editUrl:"https://github.com/SugarBarrel/RogueLibs/edit/main/website/docs/dev/extra.mdx",tags:[],version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"Custom Sprites",permalink:"/RogueLibs/docs/dev/custom-sprites"},next:{title:"Patching Utilities",permalink:"/RogueLibs/docs/dev/patching-utilities"}},m=[{value:"<code>IDoUpdate</code> and <code>IDoFixedUpdate</code>",id:"update-interfaces",children:[],level:2},{value:"PluginBuildEvents",id:"pluginbuildevents",children:[{value:"Copying plugin files",id:"copying-plugin-files",children:[],level:3},{value:"Launching the game",id:"launching-game",children:[],level:3}],level:2}],h={toc:m};function v(e){var t=e.components,n=(0,i.Z)(e,u);return(0,r.kt)("wrapper",(0,a.Z)({},h,n,{components:t,mdxType:"MDXLayout"}),(0,r.kt)("h1",{id:"extra-stuff"},"Extra Stuff"),(0,r.kt)("h2",{id:"update-interfaces"},(0,r.kt)("inlineCode",{parentName:"h2"},"IDoUpdate")," and ",(0,r.kt)("inlineCode",{parentName:"h2"},"IDoFixedUpdate")),(0,r.kt)("p",null,"If you want to update your items/traits/unlocks with Unity's ",(0,r.kt)("inlineCode",{parentName:"p"},"Update")," or ",(0,r.kt)("inlineCode",{parentName:"p"},"FixedUpdate"),", implement these interfaces:"),(0,r.kt)(o.Z,{defaultValue:"update",values:[{label:"IDoUpdate",value:"update"},{label:"IDoFixedUpdate",value:"fixedupdate"}],mdxType:"Tabs"},(0,r.kt)(l.Z,{value:"update",mdxType:"TabItem"},(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},"// highlight-next-line\npublic class MyCustomItem : CustomItem, IDoUpdate\n{\n    // highlight-start\n    public void Update()\n    {\n        /* ... */\n    }\n    // highlight-end\n}\n"))),(0,r.kt)(l.Z,{value:"fixedupdate",mdxType:"TabItem"},(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},"// highlight-next-line\npublic class MyCustomItem : CustomItem, IDoFixedUpdate\n{\n    // highlight-start\n    public void FixedUpdate()\n    {\n        /* ... */\n    }\n    // highlight-end\n}\n")))),(0,r.kt)("h2",{id:"pluginbuildevents"},"PluginBuildEvents"),(0,r.kt)("h3",{id:"copying-plugin-files"},"Copying plugin files"),(0,r.kt)("p",null,"Tired of copying your plugin's files over to ",(0,r.kt)("inlineCode",{parentName:"p"},"BepInEx/plugins"),"? Well, there's a solution."),(0,r.kt)("p",null,"First of all, ",(0,r.kt)("a",{parentName:"p",href:"https://drive.google.com/file/d/1gbh5hTF3IK-ewKwlWA7CImrQQXvRjq2e/view?usp=sharing"},"download the PluginBuildEvents"),":"),(0,r.kt)("img",{src:(0,s.Z)("/img/i18/ru/extra/download-pluginbuildevents.png"),width:"800"}),(0,r.kt)("p",null,"Unpack the ",(0,r.kt)("inlineCode",{parentName:"p"},".events")," folder in your repositories directory:"),(0,r.kt)("img",{src:(0,s.Z)("/img/i18/ru/extra/move-pluginbuildevents.gif"),width:"800"}),(0,r.kt)("p",null,"Open your project, go into its Properties > Build Events:"),(0,r.kt)("img",{src:(0,s.Z)("/img/i18/ru/extra/set-build-events.png"),width:"600"}),(0,r.kt)("p",null,"And specify these post-build events:"),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-bash"},'"D:\\repos\\.events\\PluginBuildEvents.exe" "$(TargetPath)" "Streets of Rogue"\n')),(0,r.kt)("p",null,"Where ",(0,r.kt)("inlineCode",{parentName:"p"},"D:\\repos\\.events")," is the path where you put PluginBuildEvents."),(0,r.kt)("div",{className:"admonition admonition-note alert alert--secondary"},(0,r.kt)("div",{parentName:"div",className:"admonition-heading"},(0,r.kt)("h5",{parentName:"div"},(0,r.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,r.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,r.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.3 5.69a.942.942 0 0 1-.28-.7c0-.28.09-.52.28-.7.19-.18.42-.28.7-.28.28 0 .52.09.7.28.18.19.28.42.28.7 0 .28-.09.52-.28.7a1 1 0 0 1-.7.3c-.28 0-.52-.11-.7-.3zM8 7.99c-.02-.25-.11-.48-.31-.69-.2-.19-.42-.3-.69-.31H6c-.27.02-.48.13-.69.31-.2.2-.3.44-.31.69h1v3c.02.27.11.5.31.69.2.2.42.31.69.31h1c.27 0 .48-.11.69-.31.2-.19.3-.42.31-.69H8V7.98v.01zM7 2.3c-3.14 0-5.7 2.54-5.7 5.68 0 3.14 2.56 5.7 5.7 5.7s5.7-2.55 5.7-5.7c0-3.15-2.56-5.69-5.7-5.69v.01zM7 .98c3.86 0 7 3.14 7 7s-3.14 7-7 7-7-3.12-7-7 3.14-7 7-7z"}))),"note")),(0,r.kt)("div",{parentName:"div",className:"admonition-content"},(0,r.kt)("p",{parentName:"div"},"If you haven't purchased the Steam version of the game (or if you somehow messed up the Steam's installation path in the registry), then specify the full path to the game instead of just the name:"),(0,r.kt)("pre",{parentName:"div"},(0,r.kt)("code",{parentName:"pre",className:"language-bash"},'"D:\\repos\\.events\\PluginBuildEvents.exe" "$(TargetPath)" "C:\\GOG Games\\Streets of Rogue"\n')))),(0,r.kt)("p",null,"Then just build your plugin, and its files will be moved to ",(0,r.kt)("inlineCode",{parentName:"p"},"BepInEx/plugins")," automatically."),(0,r.kt)("h3",{id:"launching-game"},"Launching the game"),(0,r.kt)("p",null,"Wanna launch the game when the build's complete?"),(0,r.kt)("p",null,"Add this to your post-build events on the new line:"),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-bash"},'"D:\\repos\\.events\\PluginBuildEvents.exe" --launch 512900\n')),(0,r.kt)("div",{className:"admonition admonition-note alert alert--secondary"},(0,r.kt)("div",{parentName:"div",className:"admonition-heading"},(0,r.kt)("h5",{parentName:"div"},(0,r.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,r.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,r.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.3 5.69a.942.942 0 0 1-.28-.7c0-.28.09-.52.28-.7.19-.18.42-.28.7-.28.28 0 .52.09.7.28.18.19.28.42.28.7 0 .28-.09.52-.28.7a1 1 0 0 1-.7.3c-.28 0-.52-.11-.7-.3zM8 7.99c-.02-.25-.11-.48-.31-.69-.2-.19-.42-.3-.69-.31H6c-.27.02-.48.13-.69.31-.2.2-.3.44-.31.69h1v3c.02.27.11.5.31.69.2.2.42.31.69.31h1c.27 0 .48-.11.69-.31.2-.19.3-.42.31-.69H8V7.98v.01zM7 2.3c-3.14 0-5.7 2.54-5.7 5.68 0 3.14 2.56 5.7 5.7 5.7s5.7-2.55 5.7-5.7c0-3.15-2.56-5.69-5.7-5.69v.01zM7 .98c3.86 0 7 3.14 7 7s-3.14 7-7 7-7-3.12-7-7 3.14-7 7-7z"}))),"note")),(0,r.kt)("div",{parentName:"div",className:"admonition-content"},(0,r.kt)("p",{parentName:"div"},(0,r.kt)("inlineCode",{parentName:"p"},"512900")," is Streets of Rogue's id in Steam. If you're developing plugins for another game, go to its store page in Steam - the number in the URL is the id: ",(0,r.kt)("inlineCode",{parentName:"p"},"https://store.steampowered.com/app/512900/Streets_of_Rogue/"),"."))),(0,r.kt)("div",{className:"admonition admonition-note alert alert--secondary"},(0,r.kt)("div",{parentName:"div",className:"admonition-heading"},(0,r.kt)("h5",{parentName:"div"},(0,r.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,r.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,r.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.3 5.69a.942.942 0 0 1-.28-.7c0-.28.09-.52.28-.7.19-.18.42-.28.7-.28.28 0 .52.09.7.28.18.19.28.42.28.7 0 .28-.09.52-.28.7a1 1 0 0 1-.7.3c-.28 0-.52-.11-.7-.3zM8 7.99c-.02-.25-.11-.48-.31-.69-.2-.19-.42-.3-.69-.31H6c-.27.02-.48.13-.69.31-.2.2-.3.44-.31.69h1v3c.02.27.11.5.31.69.2.2.42.31.69.31h1c.27 0 .48-.11.69-.31.2-.19.3-.42.31-.69H8V7.98v.01zM7 2.3c-3.14 0-5.7 2.54-5.7 5.68 0 3.14 2.56 5.7 5.7 5.7s5.7-2.55 5.7-5.7c0-3.15-2.56-5.69-5.7-5.69v.01zM7 .98c3.86 0 7 3.14 7 7s-3.14 7-7 7-7-3.12-7-7 3.14-7 7-7z"}))),"note")),(0,r.kt)("div",{parentName:"div",className:"admonition-content"},(0,r.kt)("p",{parentName:"div"},"If you haven't purchased the Steam version of the game, then just put the path to the game's executable in there:"),(0,r.kt)("pre",{parentName:"div"},(0,r.kt)("code",{parentName:"pre",className:"language-bash"},'"C:\\GOG Games\\Streets of Rogue\\StreetsOfRogue.exe"\n')))),(0,r.kt)("p",null,"Use this only on one of the projects in your solution. Otherwise, the game's executable will be launched more than one time, and you'll get ",(0,r.kt)("em",{parentName:"p"},'"Another instance of the game is already running!"')," warnings or something like that."))}v.isMDXComponent=!0}}]);