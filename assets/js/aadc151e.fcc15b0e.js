"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[7336],{3905:(e,t,n)=>{n.d(t,{Zo:()=>p,kt:()=>c});var a=n(7294);function l(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function i(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var a=Object.getOwnPropertySymbols(e);t&&(a=a.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,a)}return n}function o(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?i(Object(n),!0).forEach((function(t){l(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):i(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function r(e,t){if(null==e)return{};var n,a,l=function(e,t){if(null==e)return{};var n,a,l={},i=Object.keys(e);for(a=0;a<i.length;a++)n=i[a],t.indexOf(n)>=0||(l[n]=e[n]);return l}(e,t);if(Object.getOwnPropertySymbols){var i=Object.getOwnPropertySymbols(e);for(a=0;a<i.length;a++)n=i[a],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(l[n]=e[n])}return l}var s=a.createContext({}),u=function(e){var t=a.useContext(s),n=t;return e&&(n="function"==typeof e?e(t):o(o({},t),e)),n},p=function(e){var t=u(e.components);return a.createElement(s.Provider,{value:t},e.children)},m={inlineCode:"code",wrapper:function(e){var t=e.children;return a.createElement(a.Fragment,{},t)}},d=a.forwardRef((function(e,t){var n=e.components,l=e.mdxType,i=e.originalType,s=e.parentName,p=r(e,["components","mdxType","originalType","parentName"]),d=u(n),c=l,g=d["".concat(s,".").concat(c)]||d[c]||m[c]||i;return n?a.createElement(g,o(o({ref:t},p),{},{components:n})):a.createElement(g,o({ref:t},p))}));function c(e,t){var n=arguments,l=t&&t.mdxType;if("string"==typeof e||l){var i=n.length,o=new Array(i);o[0]=d;var r={};for(var s in t)hasOwnProperty.call(t,s)&&(r[s]=t[s]);r.originalType=e,r.mdxType="string"==typeof e?e:l,o[1]=r;for(var u=2;u<i;u++)o[u]=n[u];return a.createElement.apply(null,o)}return a.createElement.apply(null,n)}d.displayName="MDXCreateElement"},338:(e,t,n)=>{n.d(t,{Z:()=>d});var a=n(7294);const l="browserWindow_Endt",i="browserWindowHeader_fcKS",o="buttons_L6b2",r="browserWindowAddressBar_C2yQ",s="dot_qLfO",u="browserWindowMenuIcon_lKcj",p="bar_vuib",m="browserWindowBody_jqoX";function d(e){let{children:t,url:n}=e;return a.createElement("div",null,a.createElement("div",{className:l},a.createElement("div",{className:i},a.createElement("div",{className:o},a.createElement("span",{className:s,style:{background:"#f25f58"}}),a.createElement("span",{className:s,style:{background:"#fbbe3c"}}),a.createElement("span",{className:s,style:{background:"#58cb42"}})),a.createElement("div",{className:r},n),a.createElement("div",{className:u},a.createElement("div",null,a.createElement("span",{className:p}),a.createElement("span",{className:p}),a.createElement("span",{className:p})))),a.createElement("div",{className:m},t)),a.createElement("br",null))}},1016:(e,t,n)=>{n.d(t,{Z:()=>i});var a=n(7462),l=n(7294);function i(e){let{children:t,...n}=e;return l.createElement("div",(0,a.Z)({role:"tabpanel"},n),t)}},250:(e,t,n)=>{n.d(t,{Z:()=>m});var a=n(7294),l=n(7094),i=n(6010);const o="tabItem_V91s",r="tabItemActive_JsUu",s="tab_ntnM";const u=37,p=39;function m(e){const{lazy:t,defaultValue:n,values:m,groupId:d}=e,{tabGroupChoices:c,setTabGroupChoices:g}=(0,l.U)(),[h,k]=(0,a.useState)(n),b=a.Children.toArray(e.children),f=[];if(null!=d){const e=c[d];null!=e&&e!==h&&m.some((t=>t.value===e))&&k(e)}const y=e=>{const t=e.currentTarget,n=f.indexOf(t),a=m[n].value;k(a),null!=d&&(g(d,a),setTimeout((()=>{(function(e){const{top:t,left:n,bottom:a,right:l}=e.getBoundingClientRect(),{innerHeight:i,innerWidth:o}=window;return t>=0&&l<=o&&a<=i&&n>=0})(t)||(t.scrollIntoView({block:"center",behavior:"smooth"}),t.classList.add(r),setTimeout((()=>t.classList.remove(r)),2e3))}),150))},x=e=>{let t;switch(e.keyCode){case p:{const n=f.indexOf(e.target)+1;t=f[n]||f[0];break}case u:{const n=f.indexOf(e.target)-1;t=f[n]||f[f.length-1];break}default:return}t.focus()},N=(e,t)=>t.value===e||t.values&&-1!=t.values.indexOf(e);return a.createElement("div",{className:"tabs-container"},a.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:"tabs"},m.map((e=>{let{value:t,label:n}=e;return a.createElement("li",{role:"tab",tabIndex:h===t?0:-1,"aria-selected":h===t,className:(0,i.Z)("tabs__item",o,{"tabs__item--active":h===t}),key:t,ref:e=>e&&f.push(e),onKeyDown:x,onFocus:y,onClick:y},n)}))),t?a.cloneElement(b.find((e=>N(h,e.props))),{className:s}):a.createElement("div",null,b.map(((e,t)=>a.cloneElement(e,{key:t,hidden:!N(h,e.props),className:s})))),a.createElement("br",null))}},8582:(e,t,n)=>{n.r(t),n.d(t,{assets:()=>d,contentTitle:()=>p,default:()=>h,frontMatter:()=>u,metadata:()=>m,toc:()=>c});var a=n(7462),l=(n(7294),n(3905)),i=n(250),o=n(1016),r=n(4996),s=n(338);const u={},p="Installation",m={unversionedId:"user/installation",id:"user/installation",title:"Installation",description:"To start using mods, first you need to install BepInEx, the modding framework that we're using to mod Streets of Rogue. Then, install RogueLibs (both plugin and patcher - two different important files) and then any mods that you want to play with. You can find a lot of mods on SoR ModHub or GameBanana.",source:"@site/docs/user/installation.mdx",sourceDirName:"user",slug:"/user/installation",permalink:"/RogueLibs/docs/user/installation",draft:!1,editUrl:"https://github.com/SugarBarrel/RogueLibs/edit/main/website/docs/user/installation.mdx",tags:[],version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"Introduction",permalink:"/RogueLibs/docs/intro"},next:{title:"Frequently Encountered Problems",permalink:"/RogueLibs/docs/user/troubleshooting"}},d={},c=[{value:"Installing BepInEx",id:"bepinex",level:2},{value:"Downloading BepInEx",id:"bepinex-downloading",level:3},{value:"Extracting files",id:"bepinex-extract",level:3},{value:"Running the game",id:"bepinex-first-run",level:3},{value:"Running BepInEx through Steam",id:"bepinex-steam",level:3},{value:"Installing RogueLibs",id:"roguelibs",level:2},{value:"Installing plugins (mods)",id:"plugins",level:2},{value:"Where can I get mods?",id:"mod-sources",level:2}],g={toc:c};function h(e){let{components:t,...n}=e;return(0,l.kt)("wrapper",(0,a.Z)({},g,n,{components:t,mdxType:"MDXLayout"}),(0,l.kt)("h1",{id:"installation"},"Installation"),(0,l.kt)("p",null,"To start using mods, first you need to install BepInEx, the modding framework that we're using to mod Streets of Rogue. Then, install RogueLibs (both plugin and patcher - two different important files) and then any mods that you want to play with. You can find a lot of mods on ",(0,l.kt)("a",{parentName:"p",href:"https://sugarbarrel.github.io/SoRModHub"},"SoR ModHub")," or ",(0,l.kt)("a",{parentName:"p",href:"https://gamebanana.com/mods/games/8455"},"GameBanana"),"."),(0,l.kt)("h2",{id:"bepinex"},"Installing BepInEx"),(0,l.kt)("p",null,(0,l.kt)("strong",{parentName:"p"},"If you already have BepInEx installed, ",(0,l.kt)("a",{parentName:"strong",href:"#roguelibs"},"skip this step"),".")),(0,l.kt)("h3",{id:"bepinex-downloading"},"Downloading BepInEx"),(0,l.kt)("p",null,(0,l.kt)("strong",{parentName:"p"},(0,l.kt)("a",{parentName:"strong",href:"https://github.com/BepInEx/BepInEx/releases/latest"},"Go here")," and download the version for your OS:")),(0,l.kt)(i.Z,{groupId:"os",defaultValue:"win",values:[{label:"Windows",value:"win"},{label:"Linux",value:"linux"},{label:"macOS",value:"macos"}],mdxType:"Tabs"},(0,l.kt)(o.Z,{value:"win",mdxType:"TabItem"},(0,l.kt)("p",null,"Download the version of BepInEx for your game's executable's type:"),(0,l.kt)("ul",null,(0,l.kt)("li",{parentName:"ul"},(0,l.kt)("strong",{parentName:"li"},(0,l.kt)("inlineCode",{parentName:"strong"},"BepInEx_x64_5.x.y.z.zip"))," is for ",(0,l.kt)("strong",{parentName:"li"},"64-bit")," executables."),(0,l.kt)("li",{parentName:"ul"},(0,l.kt)("strong",{parentName:"li"},(0,l.kt)("inlineCode",{parentName:"strong"},"BepInEx_x86_5.x.y.z.zip"))," is for ",(0,l.kt)("strong",{parentName:"li"},"32-bit")," executables.")),(0,l.kt)("img",{src:(0,r.Z)("/img/installation/downloading-windows.png")}),(0,l.kt)("p",null,"Here's a few pointers:"),(0,l.kt)("ul",null,(0,l.kt)("li",{parentName:"ul"},"You might notice some files in the game's root directory: ",(0,l.kt)("strong",{parentName:"li"},(0,l.kt)("inlineCode",{parentName:"strong"},"Galaxy64.dll")),", ",(0,l.kt)("strong",{parentName:"li"},(0,l.kt)("inlineCode",{parentName:"strong"},"UnityCrashHandler64.exe")),". If you have these, then I'm pretty sure it means that the game's executable is also ",(0,l.kt)("strong",{parentName:"li"},"64-bit"),"."),(0,l.kt)("li",{parentName:"ul"},"Launch the game and open the Task Manager. If you see \"(32 bit)\" in the name of the game's process, then it's ",(0,l.kt)("strong",{parentName:"li"},"32-bit"),"; otherwise, it's ",(0,l.kt)("strong",{parentName:"li"},"64-bit"),"."))),(0,l.kt)(o.Z,{values:["linux","macos"],mdxType:"TabItem"},(0,l.kt)("ul",null,(0,l.kt)("li",{parentName:"ul"},"Simply download ",(0,l.kt)("strong",{parentName:"li"},(0,l.kt)("inlineCode",{parentName:"strong"},"BepInEx_unix_5.x.y.z.zip"),"."))),(0,l.kt)("img",{src:(0,r.Z)("/img/installation/downloading-unix.png")}))),(0,l.kt)("admonition",{title:"BepInEx v6",type:"caution"},(0,l.kt)("p",{parentName:"admonition"},"BepInEx v6 pre-release recently came out. Don't use it yet. All of the mods at the moment still use BepInEx v5.4.x, and if you install v6, the mods probably won't work. BepInEx developers plan on supporting older v5 plugins in the future, so once a stable v6 version comes out, you should be able to use it.")),(0,l.kt)("h3",{id:"bepinex-extract"},"Extracting files"),(0,l.kt)(i.Z,{groupId:"vendor",defaultValue:"steam",values:[{label:"I know where my game is installed!",value:"none"},{label:"Steam",value:"steam"},{label:"GOG",value:"gog"}],mdxType:"Tabs"},(0,l.kt)(o.Z,{value:"steam",mdxType:"TabItem"},(0,l.kt)("p",null,"Open Steam's game library, right-click on the game and click ",(0,l.kt)("strong",{parentName:"p"},"Properties..."),":"),(0,l.kt)("img",{src:(0,r.Z)("/img/installation/finding-the-game-1.png"),width:"300"}),(0,l.kt)("p",null,"Go to ",(0,l.kt)("strong",{parentName:"p"},"Local files")," and click ",(0,l.kt)("strong",{parentName:"p"},"Browse..."),":"),(0,l.kt)("img",{src:(0,r.Z)("/img/installation/finding-the-game-2.png"),width:"600"})),(0,l.kt)(o.Z,{value:"gog",mdxType:"TabItem"},(0,l.kt)("p",null,"Try looking at these paths:"),(0,l.kt)(i.Z,{groupId:"os",defaultValue:"win",values:[{label:"Windows",value:"win"},{label:"Linux",value:"linux"},{label:"macOS",value:"macos"}],mdxType:"Tabs"},(0,l.kt)(o.Z,{value:"win",mdxType:"TabItem"},(0,l.kt)("ul",null,(0,l.kt)("li",{parentName:"ul"},(0,l.kt)("inlineCode",{parentName:"li"},"C:\\GOG Games"),";"),(0,l.kt)("li",{parentName:"ul"},(0,l.kt)("inlineCode",{parentName:"li"},"C:\\Program Files (x86)\\GOG.com"),";"),(0,l.kt)("li",{parentName:"ul"},(0,l.kt)("inlineCode",{parentName:"li"},"C:\\Program Files\\GOGcom"),"; "))),(0,l.kt)(o.Z,{values:["linux","macos"],mdxType:"TabItem"},(0,l.kt)("ul",null,(0,l.kt)("li",{parentName:"ul"},(0,l.kt)("inlineCode",{parentName:"li"},"$HOME/GOG Games"),";")))))),(0,l.kt)("p",null,(0,l.kt)("strong",{parentName:"p"},"Extract the contents of the .zip file into the game's root directory.")),(0,l.kt)(i.Z,{groupId:"os",defaultValue:"win",values:[{label:"Windows",value:"win"},{label:"Linux",value:"linux"},{label:"macOS",value:"macos"}],mdxType:"Tabs"},(0,l.kt)(o.Z,{value:"win",mdxType:"TabItem"},(0,l.kt)("p",null,"Make sure you extract it the right way. There's a lot of wrong ways, apparently."),(0,l.kt)("ul",null,(0,l.kt)("li",{parentName:"ul"},"Make sure that ",(0,l.kt)("inlineCode",{parentName:"li"},"BepInEx")," folder is in the same directory as your game's executable (",(0,l.kt)("inlineCode",{parentName:"li"},"StreetsOfRogue.exe"),");"),(0,l.kt)("li",{parentName:"ul"},"Make sure that you extract the ",(0,l.kt)("inlineCode",{parentName:"li"},"doorstop_config.ini")," and ",(0,l.kt)("inlineCode",{parentName:"li"},"winhttp.dll")," files too;")),(0,l.kt)("img",{src:(0,r.Z)("/img/installation/extract-bepinex.png"),width:"600"})),(0,l.kt)(o.Z,{value:"linux",mdxType:"TabItem"},(0,l.kt)("p",null,"Make sure you extract it the right way. There's a lot of wrong ways, apparently."),(0,l.kt)("ul",null,(0,l.kt)("li",{parentName:"ul"},"Make sure that ",(0,l.kt)("inlineCode",{parentName:"li"},"BepInEx")," and ",(0,l.kt)("inlineCode",{parentName:"li"},"doorstop_libs")," folders are in the same directory as your game's executable (",(0,l.kt)("inlineCode",{parentName:"li"},"StreetsOfRogue.x86")," or ",(0,l.kt)("inlineCode",{parentName:"li"},"StreetsOfRogue.x86_64"),");"),(0,l.kt)("li",{parentName:"ul"},"Make sure that you extract the ",(0,l.kt)("inlineCode",{parentName:"li"},"run_bepinex.sh")," file too;"))),(0,l.kt)(o.Z,{value:"macos",mdxType:"TabItem"},(0,l.kt)("p",null,"Make sure you extract it the right way. There's a lot of wrong ways, apparently."),(0,l.kt)("ul",null,(0,l.kt)("li",{parentName:"ul"},"Make sure that ",(0,l.kt)("inlineCode",{parentName:"li"},"BepInEx")," and ",(0,l.kt)("inlineCode",{parentName:"li"},"doorstop_libs")," folders are in the same directory as your game's executable (",(0,l.kt)("inlineCode",{parentName:"li"},"StreetsOfRogue.app"),");"),(0,l.kt)("li",{parentName:"ul"},"Make sure that you extract the ",(0,l.kt)("inlineCode",{parentName:"li"},"run_bepinex.sh")," file too;")))),(0,l.kt)("h3",{id:"bepinex-first-run"},"Running the game"),(0,l.kt)("admonition",{type:"note"},(0,l.kt)("p",{parentName:"admonition"},"You need to run the game at least once, so that BepInEx can generate config files and directories!")),(0,l.kt)(i.Z,{groupId:"os",defaultValue:"win",values:[{label:"Windows",value:"win"},{label:"Linux",value:"linux"},{label:"macOS",value:"macos"}],mdxType:"Tabs"},(0,l.kt)(o.Z,{value:"win",mdxType:"TabItem"},(0,l.kt)("p",null,"Just run the game. Either through an executable, or any game launcher."),(0,l.kt)("p",null,"You can close the game once you see a logo or a loading screen.")),(0,l.kt)(o.Z,{value:"linux",mdxType:"TabItem"},(0,l.kt)("p",null,"Open the included ",(0,l.kt)("inlineCode",{parentName:"p"},"run_bepinex.sh")," script and edit the highlighted line to be the name of the executable:"),(0,l.kt)("pre",null,(0,l.kt)("code",{parentName:"pre",className:"language-bash",metastring:'title="run_bepinex.sh"',title:'"run_bepinex.sh"'},'#!/bin/sh\n# BepInEx running script\n#\n# This script is used to run a Unity game with BepInEx enabled.\n#\n# Usage: Configure the script below and simply run this script when you want to run your game modded.\n\n# -------- SETTINGS --------\n# ---- EDIT AS NEEDED ------\n\n# EDIT THIS: The name of the executable to run\n# LINUX: This is the name of the Unity game executable \n# MACOS: This is the name of the game app folder, including the .app suffix\n# highlight-next-line\nexecutable_name="StreetsOfRogue"\n\n# The rest is automatically handled by BepInEx\n# ...\n')),(0,l.kt)("p",null,"Open the terminal in the game's root directory and add execution permission to the script:"),(0,l.kt)(s.Z,{mdxType:"BrowserWindow"},(0,l.kt)("pre",null,(0,l.kt)("code",{parentName:"pre",className:"language-bash"},"chmod u+x run_bepinex.sh\n"))),(0,l.kt)("p",null,"Now you can run BepInEx by executing the script:"),(0,l.kt)(s.Z,{mdxType:"BrowserWindow"},(0,l.kt)("pre",null,(0,l.kt)("code",{parentName:"pre",className:"language-bash"},"./run_bepinex.sh\n")))),(0,l.kt)(o.Z,{value:"macos",mdxType:"TabItem"},(0,l.kt)("p",null,"Open the included ",(0,l.kt)("inlineCode",{parentName:"p"},"run_bepinex.sh")," script and edit the highlighted line to be the name of the executable ",(0,l.kt)("strong",{parentName:"p"},"(including the ",(0,l.kt)("inlineCode",{parentName:"strong"},".app")," extension)"),":"),(0,l.kt)("pre",null,(0,l.kt)("code",{parentName:"pre",className:"language-bash",metastring:'title="run_bepinex.sh"',title:'"run_bepinex.sh"'},'#!/bin/sh\n# BepInEx running script\n#\n# This script is used to run a Unity game with BepInEx enabled.\n#\n# Usage: Configure the script below and simply run this script when you want to run your game modded.\n\n# -------- SETTINGS --------\n# ---- EDIT AS NEEDED ------\n\n# EDIT THIS: The name of the executable to run\n# LINUX: This is the name of the Unity game executable \n# MACOS: This is the name of the game app folder, including the .app suffix\n# highlight-next-line\nexecutable_name="StreetsOfRogue.app"\n\n# The rest is automatically handled by BepInEx\n# ...\n')),(0,l.kt)("p",null,"Open the terminal in the game's root directory and add execution permission to the script:"),(0,l.kt)(s.Z,{mdxType:"BrowserWindow"},(0,l.kt)("pre",null,(0,l.kt)("code",{parentName:"pre",className:"language-bash"},"chmod u+x run_bepinex.sh\n"))),(0,l.kt)("p",null,"Now you can run BepInEx by executing the script:"),(0,l.kt)(s.Z,{mdxType:"BrowserWindow"},(0,l.kt)("pre",null,(0,l.kt)("code",{parentName:"pre",className:"language-bash"},"./run_bepinex.sh\n"))))),(0,l.kt)("h3",{id:"bepinex-steam"},"Running BepInEx through Steam"),(0,l.kt)(i.Z,{groupId:"os",defaultValue:"win",values:[{label:"Windows",value:"win"},{label:"Linux",value:"linux"},{label:"macOS",value:"macos"}],mdxType:"Tabs"},(0,l.kt)(o.Z,{value:"win",mdxType:"TabItem"},(0,l.kt)("p",null,"On Windows you can run BepInEx through Steam too. Nothing to worry about.")),(0,l.kt)(o.Z,{value:"linux",mdxType:"TabItem"},(0,l.kt)("p",null,"Open Steam's game library, right-click on the game and click ",(0,l.kt)("strong",{parentName:"p"},"Properties..."),":"),(0,l.kt)("admonition",{type:"note"},(0,l.kt)("p",{parentName:"admonition"},"Screenshot needed")),(0,l.kt)("p",null,"Click ",(0,l.kt)("strong",{parentName:"p"},"Set launch options..."),":"),(0,l.kt)("admonition",{type:"note"},(0,l.kt)("p",{parentName:"admonition"},"Screenshot needed")),(0,l.kt)("p",null,"And type in:"),(0,l.kt)("pre",null,(0,l.kt)("code",{parentName:"pre",className:"language-bash"},"./run_bepinex.sh %command%\n")),(0,l.kt)("p",null,"Click ",(0,l.kt)("strong",{parentName:"p"},"OK")," and run the game through Steam.")),(0,l.kt)(o.Z,{value:"macos",mdxType:"TabItem"},(0,l.kt)("p",null,"Open Steam's game library, right-click on the game and click ",(0,l.kt)("strong",{parentName:"p"},"Properties..."),":"),(0,l.kt)("admonition",{type:"note"},(0,l.kt)("p",{parentName:"admonition"},"Screenshot needed")),(0,l.kt)("p",null,"Click ",(0,l.kt)("strong",{parentName:"p"},"Set launch options..."),":"),(0,l.kt)("admonition",{type:"note"},(0,l.kt)("p",{parentName:"admonition"},"Screenshot needed")),(0,l.kt)("p",null,"Now, open a terminal in the game's root directory and run:"),(0,l.kt)(s.Z,{mdxType:"BrowserWindow"},(0,l.kt)("pre",null,(0,l.kt)("code",{parentName:"pre",className:"language-bash"},"pwd\n"))),(0,l.kt)("p",null,"You'll get the full path to the game's root directory. Copy and paste it into the launch options field and then append ",(0,l.kt)("inlineCode",{parentName:"p"},"/run_bepinex.sh %command%"),":"),(0,l.kt)("pre",null,(0,l.kt)("code",{parentName:"pre",className:"language-bash"},'"<PWD>/run_bepinex.sh" %command%\n')),(0,l.kt)("p",null,"where ",(0,l.kt)("inlineCode",{parentName:"p"},"<PWD>")," is the full path to the game's root directory."),(0,l.kt)("p",null,"Click ",(0,l.kt)("strong",{parentName:"p"},"OK")," and run the game through Steam."))),(0,l.kt)("h2",{id:"roguelibs"},"Installing RogueLibs"),(0,l.kt)(i.Z,{defaultValue:"v3",values:[{label:"RogueLibs v3.x.x",value:"v3"},{label:"RogueLibs v2.x.x",value:"v2"}],mdxType:"Tabs"},(0,l.kt)(o.Z,{value:"v3",mdxType:"TabItem"},(0,l.kt)("p",null,(0,l.kt)("strong",{parentName:"p"},(0,l.kt)("a",{parentName:"strong",href:"https://github.com/SugarBarrel/RogueLibs/releases/latest"},"Download the latest RogueLibs version"))),(0,l.kt)("p",null,"You need to download only two files: ",(0,l.kt)("inlineCode",{parentName:"p"},"RogueLibsCore.dll")," and ",(0,l.kt)("inlineCode",{parentName:"p"},"RogueLibsPatcher.dll"),"."),(0,l.kt)("img",{src:(0,r.Z)("/img/installation/download-roguelibs.png")}),(0,l.kt)("p",null,"Go to the BepInEx's directory and put ",(0,l.kt)("inlineCode",{parentName:"p"},"RogueLibsCore.dll")," file into ",(0,l.kt)("inlineCode",{parentName:"p"},"plugins")," directory:"),(0,l.kt)("img",{src:(0,r.Z)("/img/i18n/ru/installation/drag-plugins.gif"),width:"600"}),(0,l.kt)("p",null,"Put ",(0,l.kt)("inlineCode",{parentName:"p"},"RogueLibsPatcher.dll")," file into ",(0,l.kt)("inlineCode",{parentName:"p"},"patchers")," directory:"),(0,l.kt)("admonition",{type:"caution"},(0,l.kt)("p",{parentName:"admonition"},"The directory is called ",(0,l.kt)("strong",{parentName:"p"},(0,l.kt)("inlineCode",{parentName:"strong"},"patchers")),", it's different from ",(0,l.kt)("strong",{parentName:"p"},(0,l.kt)("inlineCode",{parentName:"strong"},"plugins")),".")),(0,l.kt)("img",{src:(0,r.Z)("/img/i18n/ru/installation/drag-patchers.gif"),width:"600"})),(0,l.kt)(o.Z,{value:"v2",mdxType:"TabItem"},(0,l.kt)("admonition",{type:"caution"},(0,l.kt)("p",{parentName:"admonition"},"RogueLibs v2.x.x is outdated and is not compatible with new mods!")),(0,l.kt)("p",null,(0,l.kt)("strong",{parentName:"p"},(0,l.kt)("a",{parentName:"strong",href:"https://github.com/SugarBarrel/RogueLibs/releases/tag/v2.2-pre.2"},"Download the latest RogueLibs version"))),(0,l.kt)("p",null,"You need to download only one file - ",(0,l.kt)("inlineCode",{parentName:"p"},"RogueLibs.dll"),"."),(0,l.kt)("img",{src:(0,r.Z)("/img/installation/download-roguelibs-v2.png")}),(0,l.kt)("p",null,"Go to the BepInEx's directory and put ",(0,l.kt)("inlineCode",{parentName:"p"},"RogueLibs.dll")," file into ",(0,l.kt)("inlineCode",{parentName:"p"},"plugins")," directory:"),(0,l.kt)("img",{src:(0,r.Z)("/img/i18n/ru/installation/drag-plugins.gif"),width:"600"}))),(0,l.kt)("h2",{id:"plugins"},"Installing plugins (mods)"),(0,l.kt)("p",null,"Download the mods that you want to install (",(0,l.kt)("inlineCode",{parentName:"p"},".dll")," files)."),(0,l.kt)("p",null,"And put these ",(0,l.kt)("inlineCode",{parentName:"p"},".dll")," files in the ",(0,l.kt)("inlineCode",{parentName:"p"},"BepInEx/plugins")," directory."),(0,l.kt)("img",{src:(0,r.Z)("/img/i18n/ru/installation/drag-mods.gif"),width:"600"}),(0,l.kt)("h2",{id:"mod-sources"},"Where can I get mods?"),(0,l.kt)("p",null,(0,l.kt)("strong",{parentName:"p"},(0,l.kt)("a",{parentName:"strong",href:"https://sugarbarrel.github.io/SoRModHub"},"SoR ModHub"))," is a collection of mods that use the latest RogueLibs v3 that I know about. Includes links to other mod sources as well, and is updated pretty regularly."),(0,l.kt)("p",null,(0,l.kt)("strong",{parentName:"p"},(0,l.kt)("a",{parentName:"strong",href:"https://gamebanana.com/mods/games/8455"},"GameBanana"))," - Streets of Rogue's official mod-sharing place. Some mods don't get released or updated there, since the process of setting up or updating a page is way too long and overly complicated."),(0,l.kt)("p",null,"The ",(0,l.kt)("strong",{parentName:"p"},(0,l.kt)("a",{parentName:"strong",href:"https://discord.gg/m3zuHSwQw2"},"#\ud83d\udc4d|modding-gallery\ud83d\udd27"))," channel in the official SoR's Discord. You'll find all of the latest info, updates and bugfixes there. It's kind of hard to search for specific mods though."),(0,l.kt)("p",null,"ModDB and NexusMods are barely used at all."))}h.isMDXComponent=!0}}]);