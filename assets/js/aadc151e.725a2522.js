"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[7336],{3905:function(e,t,n){n.d(t,{Zo:function(){return m},kt:function(){return c}});var a=n(7294);function i(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function l(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var a=Object.getOwnPropertySymbols(e);t&&(a=a.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,a)}return n}function r(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?l(Object(n),!0).forEach((function(t){i(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):l(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function o(e,t){if(null==e)return{};var n,a,i=function(e,t){if(null==e)return{};var n,a,i={},l=Object.keys(e);for(a=0;a<l.length;a++)n=l[a],t.indexOf(n)>=0||(i[n]=e[n]);return i}(e,t);if(Object.getOwnPropertySymbols){var l=Object.getOwnPropertySymbols(e);for(a=0;a<l.length;a++)n=l[a],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(i[n]=e[n])}return i}var s=a.createContext({}),p=function(e){var t=a.useContext(s),n=t;return e&&(n="function"==typeof e?e(t):r(r({},t),e)),n},m=function(e){var t=p(e.components);return a.createElement(s.Provider,{value:t},e.children)},u={inlineCode:"code",wrapper:function(e){var t=e.children;return a.createElement(a.Fragment,{},t)}},d=a.forwardRef((function(e,t){var n=e.components,i=e.mdxType,l=e.originalType,s=e.parentName,m=o(e,["components","mdxType","originalType","parentName"]),d=p(n),c=i,h=d["".concat(s,".").concat(c)]||d[c]||u[c]||l;return n?a.createElement(h,r(r({ref:t},m),{},{components:n})):a.createElement(h,r({ref:t},m))}));function c(e,t){var n=arguments,i=t&&t.mdxType;if("string"==typeof e||i){var l=n.length,r=new Array(l);r[0]=d;var o={};for(var s in t)hasOwnProperty.call(t,s)&&(o[s]=t[s]);o.originalType=e,o.mdxType="string"==typeof e?e:i,r[1]=o;for(var p=2;p<l;p++)r[p]=n[p];return a.createElement.apply(null,r)}return a.createElement.apply(null,n)}d.displayName="MDXCreateElement"},338:function(e,t,n){n.d(t,{Z:function(){return d}});var a=n(7294),i="browserWindow_jKcn",l="browserWindowHeader_RTeS",r="buttons_Ko+m",o="browserWindowAddressBar_pbPN",s="dot_GdWh",p="browserWindowMenuIcon_k0Eb",m="bar_MHJT",u="browserWindowBody_MhPA";function d(e){var t=e.children,n=e.url;return a.createElement("div",null,a.createElement("div",{className:i},a.createElement("div",{className:l},a.createElement("div",{className:r},a.createElement("span",{className:s,style:{background:"#f25f58"}}),a.createElement("span",{className:s,style:{background:"#fbbe3c"}}),a.createElement("span",{className:s,style:{background:"#58cb42"}})),a.createElement("div",{className:o},n),a.createElement("div",{className:p},a.createElement("div",null,a.createElement("span",{className:m}),a.createElement("span",{className:m}),a.createElement("span",{className:m})))),a.createElement("div",{className:u},t)),a.createElement("br",null))}},1016:function(e,t,n){n.d(t,{Z:function(){return o}});var a=n(7462),i=n(3366),l=n(7294),r=["children"];function o(e){var t=e.children,n=(0,i.Z)(e,r);return l.createElement("div",(0,a.Z)({role:"tabpanel"},n),t)}},2099:function(e,t,n){n.d(t,{Z:function(){return d}});var a=n(7294),i=n(9443);var l=function(){var e=(0,a.useContext)(i.Z);if(null==e)throw new Error('"useUserPreferencesContext" is used outside of "Layout" component.');return e},r=n(6010),o="tabItem_OdQc",s="tabItemActive_YQWB",p="tab_tgHH";var m=37,u=39;function d(e){var t=e.lazy,n=e.defaultValue,i=e.values,d=e.groupId,c=l(),h=c.tabGroupChoices,g=c.setTabGroupChoices,k=(0,a.useState)(n),v=k[0],b=k[1],N=a.Children.toArray(e.children),x=[];if(null!=d){var f=h[d];null!=f&&f!==v&&i.some((function(e){return e.value===f}))&&b(f)}var w=function(e){var t=e.currentTarget,n=x.indexOf(t),a=i[n].value;b(a),null!=d&&(g(d,a),setTimeout((function(){var e,n,a,i,l,r,o,p;(e=t.getBoundingClientRect(),n=e.top,a=e.left,i=e.bottom,l=e.right,r=window,o=r.innerHeight,p=r.innerWidth,n>=0&&l<=p&&i<=o&&a>=0)||(t.scrollIntoView({block:"center",behavior:"smooth"}),t.classList.add(s),setTimeout((function(){return t.classList.remove(s)}),2e3))}),150))},y=function(e){var t;switch(e.keyCode){case u:var n=x.indexOf(e.target)+1;t=x[n]||x[0];break;case m:var a=x.indexOf(e.target)-1;t=x[a]||x[x.length-1];break;default:return}t.focus()},T=function(e,t){return t.value===e||t.values&&-1!=t.values.indexOf(e)};return a.createElement("div",{className:"tabs-container"},a.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:"tabs"},i.map((function(e){var t=e.value,n=e.label;return a.createElement("li",{role:"tab",tabIndex:v===t?0:-1,"aria-selected":v===t,className:(0,r.Z)("tabs__item",o,{"tabs__item--active":v===t}),key:t,ref:function(e){return e&&x.push(e)},onKeyDown:y,onFocus:w,onClick:w},n)}))),t?a.cloneElement(N.find((function(e){return T(v,e.props)})),{className:p}):a.createElement("div",null,N.map((function(e,t){return a.cloneElement(e,{key:t,hidden:!T(v,e.props),className:p})}))),a.createElement("br",null))}},8582:function(e,t,n){n.r(t),n.d(t,{frontMatter:function(){return u},contentTitle:function(){return d},metadata:function(){return c},toc:function(){return h},default:function(){return k}});var a=n(7462),i=n(3366),l=(n(7294),n(3905)),r=n(2099),o=n(1016),s=n(4996),p=n(338),m=["components"],u={},d="Installation",c={unversionedId:"user/installation",id:"user/installation",title:"Installation",description:"Installing BepInEx",source:"@site/docs/user/installation.mdx",sourceDirName:"user",slug:"/user/installation",permalink:"/RogueLibs/docs/user/installation",editUrl:"https://github.com/Abbysssal/RogueLibs/edit/main/website/docs/user/installation.mdx",tags:[],version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"Introduction",permalink:"/RogueLibs/docs/intro"},next:{title:"Frequently Encountered Problems",permalink:"/RogueLibs/docs/user/troubleshooting"}},h=[{value:"Installing BepInEx",id:"bepinex",children:[{value:"Downloading BepInEx",id:"bepinex-downloading",children:[],level:3},{value:"Extracting files",id:"bepinex-extract",children:[],level:3},{value:"Running the game",id:"bepinex-first-run",children:[],level:3},{value:"Running BepInEx through Steam",id:"bepinex-steam",children:[],level:3}],level:2},{value:"Installing RogueLibs",id:"roguelibs",children:[],level:2},{value:"Installing plugins (aka. mods)",id:"plugins",children:[],level:2}],g={toc:h};function k(e){var t=e.components,n=(0,i.Z)(e,m);return(0,l.kt)("wrapper",(0,a.Z)({},g,n,{components:t,mdxType:"MDXLayout"}),(0,l.kt)("h1",{id:"installation"},"Installation"),(0,l.kt)("h2",{id:"bepinex"},"Installing BepInEx"),(0,l.kt)("p",null,(0,l.kt)("strong",{parentName:"p"},"If you already have BepInEx installed, ",(0,l.kt)("a",{parentName:"strong",href:"#roguelibs"},"skip this step"),".")),(0,l.kt)("h3",{id:"bepinex-downloading"},"Downloading BepInEx"),(0,l.kt)("p",null,(0,l.kt)("strong",{parentName:"p"},(0,l.kt)("a",{parentName:"strong",href:"https://github.com/BepInEx/BepInEx/releases/latest"},"Go here")," and download the version for your OS:")),(0,l.kt)(r.Z,{groupId:"os",defaultValue:"win",values:[{label:"Windows",value:"win"},{label:"Linux",value:"linux"},{label:"macOS",value:"macos"}],mdxType:"Tabs"},(0,l.kt)(o.Z,{value:"win",mdxType:"TabItem"},(0,l.kt)("p",null,"Download the version of BepInEx for your game's executable's type:"),(0,l.kt)("ul",null,(0,l.kt)("li",{parentName:"ul"},(0,l.kt)("strong",{parentName:"li"},(0,l.kt)("inlineCode",{parentName:"strong"},"BepInEx_x64_5.x.y.z.zip"))," is for ",(0,l.kt)("strong",{parentName:"li"},"64-bit")," executables."),(0,l.kt)("li",{parentName:"ul"},(0,l.kt)("strong",{parentName:"li"},(0,l.kt)("inlineCode",{parentName:"strong"},"BepInEx_x86_5.x.y.z.zip"))," is for ",(0,l.kt)("strong",{parentName:"li"},"32-bit")," executables.")),(0,l.kt)("img",{src:(0,s.Z)("/img/installation/downloading-windows.png")}),(0,l.kt)("p",null,"Here's a few pointers:"),(0,l.kt)("ul",null,(0,l.kt)("li",{parentName:"ul"},"You might notice some files in the game's root directory: ",(0,l.kt)("strong",{parentName:"li"},(0,l.kt)("inlineCode",{parentName:"strong"},"Galaxy64.dll")),", ",(0,l.kt)("strong",{parentName:"li"},(0,l.kt)("inlineCode",{parentName:"strong"},"UnityCrashHandler64.exe")),". If you have these, then I'm pretty sure it means that the game's executable is also ",(0,l.kt)("strong",{parentName:"li"},"64-bit"),"."),(0,l.kt)("li",{parentName:"ul"},"Launch the game and open the Task Manager. If you see \"(32 bit)\" in the name of the game's process, then it's ",(0,l.kt)("strong",{parentName:"li"},"32-bit"),"; otherwise, it's ",(0,l.kt)("strong",{parentName:"li"},"64-bit"),"."))),(0,l.kt)(o.Z,{values:["linux","macos"],mdxType:"TabItem"},(0,l.kt)("ul",null,(0,l.kt)("li",{parentName:"ul"},"Simply download ",(0,l.kt)("strong",{parentName:"li"},(0,l.kt)("inlineCode",{parentName:"strong"},"BepInEx_unix_5.x.y.z.zip"),"."))),(0,l.kt)("img",{src:(0,s.Z)("/img/installation/downloading-unix.png")}))),(0,l.kt)("h3",{id:"bepinex-extract"},"Extracting files"),(0,l.kt)(r.Z,{groupId:"vendor",defaultValue:"steam",values:[{label:"I know where my game is installed!",value:"none"},{label:"Steam",value:"steam"},{label:"GOG",value:"gog"}],mdxType:"Tabs"},(0,l.kt)(o.Z,{value:"steam",mdxType:"TabItem"},(0,l.kt)("p",null,"Open Steam's game library, right-click on the game and click ",(0,l.kt)("strong",{parentName:"p"},"Properties..."),":"),(0,l.kt)("img",{src:(0,s.Z)("/img/installation/finding-the-game-1.png"),width:"300"}),(0,l.kt)("p",null,"Go to ",(0,l.kt)("strong",{parentName:"p"},"Local files")," and click ",(0,l.kt)("strong",{parentName:"p"},"Browse..."),":"),(0,l.kt)("img",{src:(0,s.Z)("/img/installation/finding-the-game-2.png"),width:"600"})),(0,l.kt)(o.Z,{value:"gog",mdxType:"TabItem"},(0,l.kt)("p",null,"Try looking at these paths:"),(0,l.kt)(r.Z,{groupId:"os",defaultValue:"win",values:[{label:"Windows",value:"win"},{label:"Linux",value:"linux"},{label:"macOS",value:"macos"}],mdxType:"Tabs"},(0,l.kt)(o.Z,{value:"win",mdxType:"TabItem"},(0,l.kt)("ul",null,(0,l.kt)("li",{parentName:"ul"},(0,l.kt)("inlineCode",{parentName:"li"},"C:\\GOG Games"),";"),(0,l.kt)("li",{parentName:"ul"},(0,l.kt)("inlineCode",{parentName:"li"},"C:\\Program Files (x86)\\GOG.com"),";"),(0,l.kt)("li",{parentName:"ul"},(0,l.kt)("inlineCode",{parentName:"li"},"C:\\Program Files\\GOGcom"),"; "))),(0,l.kt)(o.Z,{values:["linux","macos"],mdxType:"TabItem"},(0,l.kt)("ul",null,(0,l.kt)("li",{parentName:"ul"},(0,l.kt)("inlineCode",{parentName:"li"},"$HOME/GOG Games"),";")))))),(0,l.kt)("p",null,(0,l.kt)("strong",{parentName:"p"},"Extract the contents of the .zip file into the game's root directory.")),(0,l.kt)(r.Z,{groupId:"os",defaultValue:"win",values:[{label:"Windows",value:"win"},{label:"Linux",value:"linux"},{label:"macOS",value:"macos"}],mdxType:"Tabs"},(0,l.kt)(o.Z,{value:"win",mdxType:"TabItem"},(0,l.kt)("p",null,"Make sure you extract it the right way. There's a lot of wrong ways, apparently."),(0,l.kt)("ul",null,(0,l.kt)("li",{parentName:"ul"},"Make sure that ",(0,l.kt)("inlineCode",{parentName:"li"},"BepInEx")," folder is in the same directory as your game's executable (",(0,l.kt)("inlineCode",{parentName:"li"},"StreetsOfRogue.exe"),");"),(0,l.kt)("li",{parentName:"ul"},"Make sure that you extract the ",(0,l.kt)("inlineCode",{parentName:"li"},"doorstop_config.ini")," and ",(0,l.kt)("inlineCode",{parentName:"li"},"winhttp.dll")," files too;")),(0,l.kt)("img",{src:(0,s.Z)("/img/installation/extract-bepinex.png"),width:"600"})),(0,l.kt)(o.Z,{value:"linux",mdxType:"TabItem"},(0,l.kt)("p",null,"Make sure you extract it the right way. There's a lot of wrong ways, apparently."),(0,l.kt)("ul",null,(0,l.kt)("li",{parentName:"ul"},"Make sure that ",(0,l.kt)("inlineCode",{parentName:"li"},"BepInEx")," and ",(0,l.kt)("inlineCode",{parentName:"li"},"doorstop_libs")," folders are in the same directory as your game's executable (",(0,l.kt)("inlineCode",{parentName:"li"},"StreetsOfRogue.x86")," or ",(0,l.kt)("inlineCode",{parentName:"li"},"StreetsOfRogue.x86_64"),");"),(0,l.kt)("li",{parentName:"ul"},"Make sure that you extract the ",(0,l.kt)("inlineCode",{parentName:"li"},"run_bepinex.sh")," file too;"))),(0,l.kt)(o.Z,{value:"macos",mdxType:"TabItem"},(0,l.kt)("p",null,"Make sure you extract it the right way. There's a lot of wrong ways, apparently."),(0,l.kt)("ul",null,(0,l.kt)("li",{parentName:"ul"},"Make sure that ",(0,l.kt)("inlineCode",{parentName:"li"},"BepInEx")," and ",(0,l.kt)("inlineCode",{parentName:"li"},"doorstop_libs")," folders are in the same directory as your game's executable (",(0,l.kt)("inlineCode",{parentName:"li"},"StreetsOfRogue.app"),");"),(0,l.kt)("li",{parentName:"ul"},"Make sure that you extract the ",(0,l.kt)("inlineCode",{parentName:"li"},"run_bepinex.sh")," file too;")))),(0,l.kt)("h3",{id:"bepinex-first-run"},"Running the game"),(0,l.kt)("div",{className:"admonition admonition-note alert alert--secondary"},(0,l.kt)("div",{parentName:"div",className:"admonition-heading"},(0,l.kt)("h5",{parentName:"div"},(0,l.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,l.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,l.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.3 5.69a.942.942 0 0 1-.28-.7c0-.28.09-.52.28-.7.19-.18.42-.28.7-.28.28 0 .52.09.7.28.18.19.28.42.28.7 0 .28-.09.52-.28.7a1 1 0 0 1-.7.3c-.28 0-.52-.11-.7-.3zM8 7.99c-.02-.25-.11-.48-.31-.69-.2-.19-.42-.3-.69-.31H6c-.27.02-.48.13-.69.31-.2.2-.3.44-.31.69h1v3c.02.27.11.5.31.69.2.2.42.31.69.31h1c.27 0 .48-.11.69-.31.2-.19.3-.42.31-.69H8V7.98v.01zM7 2.3c-3.14 0-5.7 2.54-5.7 5.68 0 3.14 2.56 5.7 5.7 5.7s5.7-2.55 5.7-5.7c0-3.15-2.56-5.69-5.7-5.69v.01zM7 .98c3.86 0 7 3.14 7 7s-3.14 7-7 7-7-3.12-7-7 3.14-7 7-7z"}))),"note")),(0,l.kt)("div",{parentName:"div",className:"admonition-content"},(0,l.kt)("p",{parentName:"div"},"You need to run the game at least once, so that BepInEx can generate config files and directories!"))),(0,l.kt)(r.Z,{groupId:"os",defaultValue:"win",values:[{label:"Windows",value:"win"},{label:"Linux",value:"linux"},{label:"macOS",value:"macos"}],mdxType:"Tabs"},(0,l.kt)(o.Z,{value:"win",mdxType:"TabItem"},(0,l.kt)("p",null,"Just run the game. Either through an executable, or any game launcher."),(0,l.kt)("p",null,"You can close the game once you see a logo or a loading screen.")),(0,l.kt)(o.Z,{value:"linux",mdxType:"TabItem"},(0,l.kt)("p",null,"Open the included ",(0,l.kt)("inlineCode",{parentName:"p"},"run_bepinex.sh")," script and edit the highlighted line to be the name of the executable:"),(0,l.kt)("pre",null,(0,l.kt)("code",{parentName:"pre",className:"language-bash",metastring:'title="run_bepinex.sh"',title:'"run_bepinex.sh"'},'#!/bin/sh\n# BepInEx running script\n#\n# This script is used to run a Unity game with BepInEx enabled.\n#\n# Usage: Configure the script below and simply run this script when you want to run your game modded.\n\n# -------- SETTINGS --------\n# ---- EDIT AS NEEDED ------\n\n# EDIT THIS: The name of the executable to run\n# LINUX: This is the name of the Unity game executable \n# MACOS: This is the name of the game app folder, including the .app suffix\n# highlight-next-line\nexecutable_name="StreetsOfRogue"\n\n# The rest is automatically handled by BepInEx\n# ...\n')),(0,l.kt)("p",null,"Open the terminal in the game's root directory and add execution permission to the script:"),(0,l.kt)(p.Z,{mdxType:"BrowserWindow"},(0,l.kt)("pre",null,(0,l.kt)("code",{parentName:"pre",className:"language-bash"},"chmod u+x run_bepinex.sh\n"))),(0,l.kt)("p",null,"Now you can run BepInEx by executing the script:"),(0,l.kt)(p.Z,{mdxType:"BrowserWindow"},(0,l.kt)("pre",null,(0,l.kt)("code",{parentName:"pre",className:"language-bash"},"./run_bepinex.sh\n")))),(0,l.kt)(o.Z,{value:"macos",mdxType:"TabItem"},(0,l.kt)("p",null,"Open the included ",(0,l.kt)("inlineCode",{parentName:"p"},"run_bepinex.sh")," script and edit the highlighted line to be the name of the executable ",(0,l.kt)("strong",{parentName:"p"},"(including the ",(0,l.kt)("inlineCode",{parentName:"strong"},".app")," extension)"),":"),(0,l.kt)("pre",null,(0,l.kt)("code",{parentName:"pre",className:"language-bash",metastring:'title="run_bepinex.sh"',title:'"run_bepinex.sh"'},'#!/bin/sh\n# BepInEx running script\n#\n# This script is used to run a Unity game with BepInEx enabled.\n#\n# Usage: Configure the script below and simply run this script when you want to run your game modded.\n\n# -------- SETTINGS --------\n# ---- EDIT AS NEEDED ------\n\n# EDIT THIS: The name of the executable to run\n# LINUX: This is the name of the Unity game executable \n# MACOS: This is the name of the game app folder, including the .app suffix\n# highlight-next-line\nexecutable_name="StreetsOfRogue.app"\n\n# The rest is automatically handled by BepInEx\n# ...\n')),(0,l.kt)("p",null,"Open the terminal in the game's root directory and add execution permission to the script:"),(0,l.kt)(p.Z,{mdxType:"BrowserWindow"},(0,l.kt)("pre",null,(0,l.kt)("code",{parentName:"pre",className:"language-bash"},"chmod u+x run_bepinex.sh\n"))),(0,l.kt)("p",null,"Now you can run BepInEx by executing the script:"),(0,l.kt)(p.Z,{mdxType:"BrowserWindow"},(0,l.kt)("pre",null,(0,l.kt)("code",{parentName:"pre",className:"language-bash"},"./run_bepinex.sh\n"))))),(0,l.kt)("h3",{id:"bepinex-steam"},"Running BepInEx through Steam"),(0,l.kt)(r.Z,{groupId:"os",defaultValue:"win",values:[{label:"Windows",value:"win"},{label:"Linux",value:"linux"},{label:"macOS",value:"macos"}],mdxType:"Tabs"},(0,l.kt)(o.Z,{value:"win",mdxType:"TabItem"},(0,l.kt)("p",null,"On Windows you can run BepInEx through Steam too. Nothing to worry about.")),(0,l.kt)(o.Z,{value:"linux",mdxType:"TabItem"},(0,l.kt)("p",null,"Open Steam's game library, right-click on the game and click ",(0,l.kt)("strong",{parentName:"p"},"Properties..."),":"),(0,l.kt)("div",{className:"admonition admonition-note alert alert--secondary"},(0,l.kt)("div",{parentName:"div",className:"admonition-heading"},(0,l.kt)("h5",{parentName:"div"},(0,l.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,l.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,l.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.3 5.69a.942.942 0 0 1-.28-.7c0-.28.09-.52.28-.7.19-.18.42-.28.7-.28.28 0 .52.09.7.28.18.19.28.42.28.7 0 .28-.09.52-.28.7a1 1 0 0 1-.7.3c-.28 0-.52-.11-.7-.3zM8 7.99c-.02-.25-.11-.48-.31-.69-.2-.19-.42-.3-.69-.31H6c-.27.02-.48.13-.69.31-.2.2-.3.44-.31.69h1v3c.02.27.11.5.31.69.2.2.42.31.69.31h1c.27 0 .48-.11.69-.31.2-.19.3-.42.31-.69H8V7.98v.01zM7 2.3c-3.14 0-5.7 2.54-5.7 5.68 0 3.14 2.56 5.7 5.7 5.7s5.7-2.55 5.7-5.7c0-3.15-2.56-5.69-5.7-5.69v.01zM7 .98c3.86 0 7 3.14 7 7s-3.14 7-7 7-7-3.12-7-7 3.14-7 7-7z"}))),"note")),(0,l.kt)("div",{parentName:"div",className:"admonition-content"},(0,l.kt)("p",{parentName:"div"},"Screenshot needed"))),(0,l.kt)("p",null,"Click ",(0,l.kt)("strong",{parentName:"p"},"Set launch options..."),":"),(0,l.kt)("div",{className:"admonition admonition-note alert alert--secondary"},(0,l.kt)("div",{parentName:"div",className:"admonition-heading"},(0,l.kt)("h5",{parentName:"div"},(0,l.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,l.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,l.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.3 5.69a.942.942 0 0 1-.28-.7c0-.28.09-.52.28-.7.19-.18.42-.28.7-.28.28 0 .52.09.7.28.18.19.28.42.28.7 0 .28-.09.52-.28.7a1 1 0 0 1-.7.3c-.28 0-.52-.11-.7-.3zM8 7.99c-.02-.25-.11-.48-.31-.69-.2-.19-.42-.3-.69-.31H6c-.27.02-.48.13-.69.31-.2.2-.3.44-.31.69h1v3c.02.27.11.5.31.69.2.2.42.31.69.31h1c.27 0 .48-.11.69-.31.2-.19.3-.42.31-.69H8V7.98v.01zM7 2.3c-3.14 0-5.7 2.54-5.7 5.68 0 3.14 2.56 5.7 5.7 5.7s5.7-2.55 5.7-5.7c0-3.15-2.56-5.69-5.7-5.69v.01zM7 .98c3.86 0 7 3.14 7 7s-3.14 7-7 7-7-3.12-7-7 3.14-7 7-7z"}))),"note")),(0,l.kt)("div",{parentName:"div",className:"admonition-content"},(0,l.kt)("p",{parentName:"div"},"Screenshot needed"))),(0,l.kt)("p",null,"And type in:"),(0,l.kt)("pre",null,(0,l.kt)("code",{parentName:"pre",className:"language-bash"},"./run_bepinex.sh %command%\n")),(0,l.kt)("p",null,"Click ",(0,l.kt)("strong",{parentName:"p"},"OK")," and run the game through Steam.")),(0,l.kt)(o.Z,{value:"macos",mdxType:"TabItem"},(0,l.kt)("p",null,"Open Steam's game library, right-click on the game and click ",(0,l.kt)("strong",{parentName:"p"},"Properties..."),":"),(0,l.kt)("div",{className:"admonition admonition-note alert alert--secondary"},(0,l.kt)("div",{parentName:"div",className:"admonition-heading"},(0,l.kt)("h5",{parentName:"div"},(0,l.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,l.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,l.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.3 5.69a.942.942 0 0 1-.28-.7c0-.28.09-.52.28-.7.19-.18.42-.28.7-.28.28 0 .52.09.7.28.18.19.28.42.28.7 0 .28-.09.52-.28.7a1 1 0 0 1-.7.3c-.28 0-.52-.11-.7-.3zM8 7.99c-.02-.25-.11-.48-.31-.69-.2-.19-.42-.3-.69-.31H6c-.27.02-.48.13-.69.31-.2.2-.3.44-.31.69h1v3c.02.27.11.5.31.69.2.2.42.31.69.31h1c.27 0 .48-.11.69-.31.2-.19.3-.42.31-.69H8V7.98v.01zM7 2.3c-3.14 0-5.7 2.54-5.7 5.68 0 3.14 2.56 5.7 5.7 5.7s5.7-2.55 5.7-5.7c0-3.15-2.56-5.69-5.7-5.69v.01zM7 .98c3.86 0 7 3.14 7 7s-3.14 7-7 7-7-3.12-7-7 3.14-7 7-7z"}))),"note")),(0,l.kt)("div",{parentName:"div",className:"admonition-content"},(0,l.kt)("p",{parentName:"div"},"Screenshot needed"))),(0,l.kt)("p",null,"Click ",(0,l.kt)("strong",{parentName:"p"},"Set launch options..."),":"),(0,l.kt)("div",{className:"admonition admonition-note alert alert--secondary"},(0,l.kt)("div",{parentName:"div",className:"admonition-heading"},(0,l.kt)("h5",{parentName:"div"},(0,l.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,l.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,l.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.3 5.69a.942.942 0 0 1-.28-.7c0-.28.09-.52.28-.7.19-.18.42-.28.7-.28.28 0 .52.09.7.28.18.19.28.42.28.7 0 .28-.09.52-.28.7a1 1 0 0 1-.7.3c-.28 0-.52-.11-.7-.3zM8 7.99c-.02-.25-.11-.48-.31-.69-.2-.19-.42-.3-.69-.31H6c-.27.02-.48.13-.69.31-.2.2-.3.44-.31.69h1v3c.02.27.11.5.31.69.2.2.42.31.69.31h1c.27 0 .48-.11.69-.31.2-.19.3-.42.31-.69H8V7.98v.01zM7 2.3c-3.14 0-5.7 2.54-5.7 5.68 0 3.14 2.56 5.7 5.7 5.7s5.7-2.55 5.7-5.7c0-3.15-2.56-5.69-5.7-5.69v.01zM7 .98c3.86 0 7 3.14 7 7s-3.14 7-7 7-7-3.12-7-7 3.14-7 7-7z"}))),"note")),(0,l.kt)("div",{parentName:"div",className:"admonition-content"},(0,l.kt)("p",{parentName:"div"},"Screenshot needed"))),(0,l.kt)("p",null,"Now, open a terminal in the game's root directory and run:"),(0,l.kt)(p.Z,{mdxType:"BrowserWindow"},(0,l.kt)("pre",null,(0,l.kt)("code",{parentName:"pre",className:"language-bash"},"pwd\n"))),(0,l.kt)("p",null,"You'll get the full path to the game's root directory. Copy and paste it into the launch options field and then append ",(0,l.kt)("inlineCode",{parentName:"p"},"/run_bepinex.sh %command%"),":"),(0,l.kt)("pre",null,(0,l.kt)("code",{parentName:"pre",className:"language-bash"},'"<PWD>/run_bepinex.sh" %command%\n')),(0,l.kt)("p",null,"where ",(0,l.kt)("inlineCode",{parentName:"p"},"<PWD>")," is the full path to the game's root directory."),(0,l.kt)("p",null,"Click ",(0,l.kt)("strong",{parentName:"p"},"OK")," and run the game through Steam."))),(0,l.kt)("h2",{id:"roguelibs"},"Installing RogueLibs"),(0,l.kt)(r.Z,{defaultValue:"v3",values:[{label:"RogueLibs v3.x.x",value:"v3"},{label:"RogueLibs v2.x.x",value:"v2"}],mdxType:"Tabs"},(0,l.kt)(o.Z,{value:"v3",mdxType:"TabItem"},(0,l.kt)("div",{className:"admonition admonition-caution alert alert--warning"},(0,l.kt)("div",{parentName:"div",className:"admonition-heading"},(0,l.kt)("h5",{parentName:"div"},(0,l.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,l.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"16",height:"16",viewBox:"0 0 16 16"},(0,l.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M8.893 1.5c-.183-.31-.52-.5-.887-.5s-.703.19-.886.5L.138 13.499a.98.98 0 0 0 0 1.001c.193.31.53.501.886.501h13.964c.367 0 .704-.19.877-.5a1.03 1.03 0 0 0 .01-1.002L8.893 1.5zm.133 11.497H6.987v-2.003h2.039v2.003zm0-3.004H6.987V5.987h2.039v4.006z"}))),"caution")),(0,l.kt)("div",{parentName:"div",className:"admonition-content"},(0,l.kt)("p",{parentName:"div"},"RogueLibs v3.x.x was released very recently and not all mods use it at the moment."))),(0,l.kt)("p",null,(0,l.kt)("strong",{parentName:"p"},(0,l.kt)("a",{parentName:"strong",href:"https://github.com/Abbysssal/RogueLibs/releases/latest"},"Download the latest RogueLibs version"))),(0,l.kt)("p",null,"You need to download only two files: ",(0,l.kt)("inlineCode",{parentName:"p"},"RogueLibsCore.dll")," and ",(0,l.kt)("inlineCode",{parentName:"p"},"RogueLibsPatcher.dll"),"."),(0,l.kt)("img",{src:(0,s.Z)("/img/installation/download-roguelibs.png")}),(0,l.kt)("p",null,"Go to the BepInEx's directory and put ",(0,l.kt)("inlineCode",{parentName:"p"},"RogueLibsCore.dll")," file into ",(0,l.kt)("inlineCode",{parentName:"p"},"plugins")," directory:"),(0,l.kt)("img",{src:(0,s.Z)("/img/i18n/ru/installation/drag-plugins.gif"),width:"600"}),(0,l.kt)("p",null,"Put ",(0,l.kt)("inlineCode",{parentName:"p"},"RogueLibsPatcher.dll")," file into ",(0,l.kt)("inlineCode",{parentName:"p"},"patchers")," directory:"),(0,l.kt)("div",{className:"admonition admonition-caution alert alert--warning"},(0,l.kt)("div",{parentName:"div",className:"admonition-heading"},(0,l.kt)("h5",{parentName:"div"},(0,l.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,l.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"16",height:"16",viewBox:"0 0 16 16"},(0,l.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M8.893 1.5c-.183-.31-.52-.5-.887-.5s-.703.19-.886.5L.138 13.499a.98.98 0 0 0 0 1.001c.193.31.53.501.886.501h13.964c.367 0 .704-.19.877-.5a1.03 1.03 0 0 0 .01-1.002L8.893 1.5zm.133 11.497H6.987v-2.003h2.039v2.003zm0-3.004H6.987V5.987h2.039v4.006z"}))),"caution")),(0,l.kt)("div",{parentName:"div",className:"admonition-content"},(0,l.kt)("p",{parentName:"div"},"The directory is called ",(0,l.kt)("strong",{parentName:"p"},(0,l.kt)("inlineCode",{parentName:"strong"},"patchers")),", it's different from ",(0,l.kt)("strong",{parentName:"p"},(0,l.kt)("inlineCode",{parentName:"strong"},"plugins")),"."))),(0,l.kt)("img",{src:(0,s.Z)("/img/i18n/ru/installation/drag-patchers.gif"),width:"600"})),(0,l.kt)(o.Z,{value:"v2",mdxType:"TabItem"},(0,l.kt)("div",{className:"admonition admonition-caution alert alert--warning"},(0,l.kt)("div",{parentName:"div",className:"admonition-heading"},(0,l.kt)("h5",{parentName:"div"},(0,l.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,l.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"16",height:"16",viewBox:"0 0 16 16"},(0,l.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M8.893 1.5c-.183-.31-.52-.5-.887-.5s-.703.19-.886.5L.138 13.499a.98.98 0 0 0 0 1.001c.193.31.53.501.886.501h13.964c.367 0 .704-.19.877-.5a1.03 1.03 0 0 0 .01-1.002L8.893 1.5zm.133 11.497H6.987v-2.003h2.039v2.003zm0-3.004H6.987V5.987h2.039v4.006z"}))),"caution")),(0,l.kt)("div",{parentName:"div",className:"admonition-content"},(0,l.kt)("p",{parentName:"div"},"RogueLibs v2.x.x is outdated and is not compatible with new mods!"))),(0,l.kt)("p",null,(0,l.kt)("strong",{parentName:"p"},(0,l.kt)("a",{parentName:"strong",href:"https://github.com/Abbysssal/RogueLibs/releases/tag/v2.2-pre.2"},"Download the latest RogueLibs version"))),(0,l.kt)("p",null,"You need to download only one file - ",(0,l.kt)("inlineCode",{parentName:"p"},"RogueLibs.dll"),"."),(0,l.kt)("img",{src:(0,s.Z)("/img/installation/download-roguelibs-v2.png")}),(0,l.kt)("p",null,"Go to the BepInEx's directory and put ",(0,l.kt)("inlineCode",{parentName:"p"},"RogueLibs.dll")," file into ",(0,l.kt)("inlineCode",{parentName:"p"},"plugins")," directory:"),(0,l.kt)("img",{src:(0,s.Z)("/img/i18n/ru/installation/drag-plugins.gif"),width:"600"}))),(0,l.kt)("h2",{id:"plugins"},"Installing plugins (aka. mods)"),(0,l.kt)("p",null,"Download the plugins that you want to install (",(0,l.kt)("inlineCode",{parentName:"p"},".dll")," files)."),(0,l.kt)("p",null,"And put these ",(0,l.kt)("inlineCode",{parentName:"p"},".dll")," files in the ",(0,l.kt)("inlineCode",{parentName:"p"},"BepInEx/plugins")," directory."),(0,l.kt)("img",{src:(0,s.Z)("/img/i18n/ru/installation/drag-mods.gif"),width:"600"}))}k.isMDXComponent=!0}}]);