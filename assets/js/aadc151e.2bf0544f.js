(self.webpackChunkdocs=self.webpackChunkdocs||[]).push([[336],{9309:function(e,t,n){"use strict";n.d(t,{Z:function(){return s}});var a=n(2122),i=n(9756),l=n(7294),o=["children"];function s(e){var t=e.children,n=(0,i.Z)(e,o);return l.createElement("div",(0,a.Z)({role:"tabpanel"},n),t)}},9037:function(e,t,n){"use strict";n.d(t,{Z:function(){return p}});var a=n(7294),i=n(944),l=n(6010),o="tabItem_2O3c",s="tabItemActive_Fpbe",r="tab_1pgU";var d=37,m=39;var p=function(e){var t=e.lazy,n=e.block,p=e.defaultValue,c=e.values,u=e.groupId,h=e.className,k=(0,i.Z)(),g=k.tabGroupChoices,v=k.setTabGroupChoices,N=(0,a.useState)(p),b=N[0],x=N[1],w=a.Children.toArray(e.children),y=[];if(null!=u){var f=g[u];null!=f&&f!==b&&c.some((function(e){return e.value===f}))&&x(f)}var I=function(e){var t=e.currentTarget,n=y.indexOf(t),a=c[n].value;x(a),null!=u&&(v(u,a),setTimeout((function(){var e,n,a,i,l,o,r,d;(e=t.getBoundingClientRect(),n=e.top,a=e.left,i=e.bottom,l=e.right,o=window,r=o.innerHeight,d=o.innerWidth,n>=0&&l<=d&&i<=r&&a>=0)||(t.scrollIntoView({block:"center",behavior:"smooth"}),t.classList.add(s),setTimeout((function(){return t.classList.remove(s)}),2e3))}),150))},T=function(e){var t,n;switch(e.keyCode){case m:var a=y.indexOf(e.target)+1;n=y[a]||y[0];break;case d:var i=y.indexOf(e.target)-1;n=y[i]||y[y.length-1]}null==(t=n)||t.focus()},E=function(e,t){return t.value===e||t.values&&-1!=t.values.indexOf(e)};return a.createElement("div",{className:"tabs-container"},a.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:(0,l.Z)("tabs",{"tabs--block":n},h)},c.map((function(e){var t=e.value,n=e.label;return a.createElement("li",{role:"tab",tabIndex:b===t?0:-1,"aria-selected":b===t,className:(0,l.Z)("tabs__item",o,{"tabs__item--active":b===t}),key:t,ref:function(e){return y.push(e)},onKeyDown:T,onFocus:I,onClick:I},n)}))),t?(0,a.cloneElement)(w.filter((function(e){return E(b,e.props)}))[0],{curSelected:b,className:r}):a.createElement("div",null,w.map((function(e,t){return(0,a.cloneElement)(e,{key:t,hidden:!E(b,e.props),selectedValue:b,className:r})}))))}},336:function(e,t,n){"use strict";n.r(t),n.d(t,{contentTitle:function(){return T},default:function(){return z},frontMatter:function(){return I},metadata:function(){return E},toc:function(){return C}});var a=n(2122),i=n(9756),l=n(7294),o=n(3905),s=n(9037),r=n(9309),d="form_3CFn",m="button_3qAA",p=["link"];function c(e){var t=e.link,n=(0,i.Z)(e,p);return l.createElement("form",{className:d,action:t},l.createElement("button",{className:m},n.children))}var u=n(4996),h="browserWindow_1hK2",k="browserWindowHeader_3KQg",g="buttons_30GN",v="browserWindowAddressBar_3JC2",N="dot_1FQH",b="browserWindowMenuIcon_2SC9",x="bar_2gUh",w="browserWindowBody_2GyV";var y=function(e){var t=e.children,n=e.minHeight,a=e.url;return l.createElement("div",{className:h,style:{minHeight:n}},l.createElement("div",{className:k},l.createElement("div",{className:g},l.createElement("span",{className:N,style:{background:"#f25f58"}}),l.createElement("span",{className:N,style:{background:"#fbbe3c"}}),l.createElement("span",{className:N,style:{background:"#58cb42"}})),l.createElement("div",{className:v},a),l.createElement("div",{className:b},l.createElement("div",null,l.createElement("span",{className:x}),l.createElement("span",{className:x}),l.createElement("span",{className:x})))),l.createElement("div",{className:w},t))},f=["components"],I={id:"installation"},T="Installation",E={unversionedId:"user/installation",id:"user/installation",isDocsHomePage:!1,title:"Installation",description:"Installing BepInEx",source:"@site/docs/user/installation.mdx",sourceDirName:"user",slug:"/user/installation",permalink:"/RogueLibs/docs/user/installation",editUrl:"https://github.com/Abbysssal/RogueLibs/edit/master/docs/docs/user/installation.mdx",version:"current",frontMatter:{id:"installation"},sidebar:"documentationSidebar",previous:{title:"Introduction",permalink:"/RogueLibs/docs/intro"},next:{title:"Troubleshooting",permalink:"/RogueLibs/docs/user/troubleshooting"}},C=[{value:"Installing BepInEx",id:"bepinex",children:[{value:"Downloading BepInEx",id:"bepinex-downloading",children:[]},{value:"Extracting files",id:"bepinex-extract",children:[]},{value:"Running the game",id:"bepinex-first-run",children:[]},{value:"Running BepInEx through Steam",id:"running-bepinex-through-steam",children:[]}]},{value:"Installing RogueLibs",id:"roguelibs",children:[]},{value:"Installing plugins (aka. mods)",id:"plugins",children:[]}],M={toc:C};function z(e){var t=e.components,n=(0,i.Z)(e,f);return(0,o.kt)("wrapper",(0,a.Z)({},M,n,{components:t,mdxType:"MDXLayout"}),(0,o.kt)("h1",{id:"installation"},"Installation"),(0,o.kt)("h2",{id:"bepinex"},"Installing BepInEx"),(0,o.kt)("p",null,(0,o.kt)("strong",{parentName:"p"},"If you already have BepInEx installed, ",(0,o.kt)("a",{parentName:"strong",href:"#roguelibs"},"skip this step"),".")),(0,o.kt)("h3",{id:"bepinex-downloading"},"Downloading BepInEx"),(0,o.kt)("p",null,(0,o.kt)("strong",{parentName:"p"},(0,o.kt)("a",{parentName:"strong",href:"https://github.com/BepInEx/BepInEx/releases/latest"},"Go here")," and download the version for your OS:")),(0,o.kt)(s.Z,{groupId:"os",defaultValue:"win",values:[{label:"Windows",value:"win"},{label:"Linux",value:"linux"},{label:"macOS",value:"macos"}],mdxType:"Tabs"},(0,o.kt)(r.Z,{value:"win",mdxType:"TabItem"},(0,o.kt)("p",null,"Download the version of BepInEx for your system's type:"),(0,o.kt)("ul",null,(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("strong",{parentName:"li"},(0,o.kt)("inlineCode",{parentName:"strong"},"BepInEx_x64_5.x.y.z.zip"))," is for ",(0,o.kt)("strong",{parentName:"li"},"64-bit")," systems."),(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("strong",{parentName:"li"},(0,o.kt)("inlineCode",{parentName:"strong"},"BepInEx_x86_5.x.y.z.zip"))," is for ",(0,o.kt)("strong",{parentName:"li"},"32-bit")," systems.")),(0,o.kt)("p",null,"Here's a few pointers:"),(0,o.kt)("ul",null,(0,o.kt)("li",{parentName:"ul"},"If you have ",(0,o.kt)("strong",{parentName:"li"},"more than 4 Gb of RAM"),", then you definitely have a ",(0,o.kt)("strong",{parentName:"li"},"64-bit OS"),". A 32-bit version simply cannot use more than 4 Gb of RAM, because of, you know, 32 bits (2^32 bytes = 4 gigabytes)."),(0,o.kt)("li",{parentName:"ul"},"If you have Windows 10, ",(0,o.kt)(c,{link:"ms-settings:about",mdxType:"MicrosoftButton"},"Open About settings")," (or ",(0,o.kt)("inlineCode",{parentName:"li"},"\u229e Win"),"+",(0,o.kt)("inlineCode",{parentName:"li"},"I")," > ",(0,o.kt)("strong",{parentName:"li"},"System")," > ",(0,o.kt)("strong",{parentName:"li"},"About"),"). You'll see what version of Windows you're running under ",(0,o.kt)("strong",{parentName:"li"},"Device specifications: System type"),"."),(0,o.kt)("li",{parentName:"ul"},"If you have Windows 7 or 8, then ",(0,o.kt)("a",{parentName:"li",href:"https://support.microsoft.com/en-us/windows/which-version-of-windows-operating-system-am-i-running-628bec99-476a-2c13-5296-9dd081cdd808"},"go here"),"."))),(0,o.kt)(r.Z,{values:["linux","macos"],mdxType:"TabItem"},(0,o.kt)("ul",null,(0,o.kt)("li",{parentName:"ul"},"Simply download ",(0,o.kt)("strong",{parentName:"li"},(0,o.kt)("inlineCode",{parentName:"strong"},"BepInEx_unix_5.x.y.z.zip"),"."))))),(0,o.kt)("h3",{id:"bepinex-extract"},"Extracting files"),(0,o.kt)(s.Z,{groupId:"vendor",defaultValue:"steam",values:[{label:"I know where my game is installed!",value:"none"},{label:"Steam",value:"steam"},{label:"GOG",value:"gog"}],mdxType:"Tabs"},(0,o.kt)(r.Z,{value:"steam",mdxType:"TabItem"},(0,o.kt)("p",null,"Open Steam's game library, right-click on the game and click ",(0,o.kt)("strong",{parentName:"p"},"Properties..."),":"),(0,o.kt)("img",{src:(0,u.Z)("/img/installation/finding-the-game-1.png"),width:"300"}),(0,o.kt)("p",null,"Go to ",(0,o.kt)("strong",{parentName:"p"},"Local files")," and click ",(0,o.kt)("strong",{parentName:"p"},"Browse..."),":"),(0,o.kt)("img",{src:(0,u.Z)("/img/installation/finding-the-game-2.png"),width:"600"})),(0,o.kt)(r.Z,{value:"gog",mdxType:"TabItem"},(0,o.kt)("p",null,"Try looking at these paths:"),(0,o.kt)(s.Z,{groupId:"os",defaultValue:"win",values:[{label:"Windows",value:"win"},{label:"Linux",value:"linux"},{label:"macOS",value:"macos"}],mdxType:"Tabs"},(0,o.kt)(r.Z,{value:"win",mdxType:"TabItem"},(0,o.kt)("ul",null,(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("inlineCode",{parentName:"li"},"C:\\GOG Games"),";"),(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("inlineCode",{parentName:"li"},"C:\\Program Files (x86)\\GOG.com"),";"),(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("inlineCode",{parentName:"li"},"C:\\Program Files\\GOGcom"),"; "))),(0,o.kt)(r.Z,{values:["linux","macos"],mdxType:"TabItem"},(0,o.kt)("ul",null,(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("inlineCode",{parentName:"li"},"$HOME/GOG Games"),";")))))),(0,o.kt)("br",null),(0,o.kt)("p",null,(0,o.kt)("strong",{parentName:"p"},"Extract the contents of the .zip file into the game's root directory.")),(0,o.kt)(s.Z,{groupId:"os",defaultValue:"win",values:[{label:"Windows",value:"win"},{label:"Linux",value:"linux"},{label:"macOS",value:"macos"}],mdxType:"Tabs"},(0,o.kt)(r.Z,{value:"win",mdxType:"TabItem"},(0,o.kt)("p",null,"Make sure you extract it the right way. There's a lot of wrong ways, apparently."),(0,o.kt)("ul",null,(0,o.kt)("li",{parentName:"ul"},"Make sure that ",(0,o.kt)("inlineCode",{parentName:"li"},"BepInEx")," folder is extracted in the same directory as your game's executable (",(0,o.kt)("inlineCode",{parentName:"li"},"StreetsOfRogue.exe"),");"),(0,o.kt)("li",{parentName:"ul"},"Make sure that you extract the ",(0,o.kt)("inlineCode",{parentName:"li"},"doorstop_config.ini")," and ",(0,o.kt)("inlineCode",{parentName:"li"},"winhttp.dll")," files too;"))),(0,o.kt)(r.Z,{value:"linux",mdxType:"TabItem"},(0,o.kt)("p",null,"Make sure you extract it the right way. There's a lot of wrong ways, apparently."),(0,o.kt)("ul",null,(0,o.kt)("li",{parentName:"ul"},"Make sure that ",(0,o.kt)("inlineCode",{parentName:"li"},"BepInEx")," and ",(0,o.kt)("inlineCode",{parentName:"li"},"doorstop_libs")," folders are in the same directory as your game's executable (",(0,o.kt)("inlineCode",{parentName:"li"},"StreetsOfRogue.x86")," or ",(0,o.kt)("inlineCode",{parentName:"li"},"StreetsOfRogue.x86_64"),");"),(0,o.kt)("li",{parentName:"ul"},"Make sure that you extract the ",(0,o.kt)("inlineCode",{parentName:"li"},"run_bepinex.sh")," file too;"))),(0,o.kt)(r.Z,{value:"macos",mdxType:"TabItem"},(0,o.kt)("p",null,"Make sure you extract it the right way. There's a lot of wrong ways, apparently."),(0,o.kt)("ul",null,(0,o.kt)("li",{parentName:"ul"},"Make sure that ",(0,o.kt)("inlineCode",{parentName:"li"},"BepInEx")," and ",(0,o.kt)("inlineCode",{parentName:"li"},"doorstop_libs")," folders are in the same directory as your game's executable (",(0,o.kt)("inlineCode",{parentName:"li"},"StreetsOfRogue.app"),");"),(0,o.kt)("li",{parentName:"ul"},"Make sure that you extract the ",(0,o.kt)("inlineCode",{parentName:"li"},"run_bepinex.sh")," file too;")))),(0,o.kt)("h3",{id:"bepinex-first-run"},"Running the game"),(0,o.kt)("div",{className:"admonition admonition-note alert alert--secondary"},(0,o.kt)("div",{parentName:"div",className:"admonition-heading"},(0,o.kt)("h5",{parentName:"div"},(0,o.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,o.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,o.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.3 5.69a.942.942 0 0 1-.28-.7c0-.28.09-.52.28-.7.19-.18.42-.28.7-.28.28 0 .52.09.7.28.18.19.28.42.28.7 0 .28-.09.52-.28.7a1 1 0 0 1-.7.3c-.28 0-.52-.11-.7-.3zM8 7.99c-.02-.25-.11-.48-.31-.69-.2-.19-.42-.3-.69-.31H6c-.27.02-.48.13-.69.31-.2.2-.3.44-.31.69h1v3c.02.27.11.5.31.69.2.2.42.31.69.31h1c.27 0 .48-.11.69-.31.2-.19.3-.42.31-.69H8V7.98v.01zM7 2.3c-3.14 0-5.7 2.54-5.7 5.68 0 3.14 2.56 5.7 5.7 5.7s5.7-2.55 5.7-5.7c0-3.15-2.56-5.69-5.7-5.69v.01zM7 .98c3.86 0 7 3.14 7 7s-3.14 7-7 7-7-3.12-7-7 3.14-7 7-7z"}))),"note")),(0,o.kt)("div",{parentName:"div",className:"admonition-content"},(0,o.kt)("p",{parentName:"div"},"You need to run the game at least once, so that BepInEx can generate config files and directories!"))),(0,o.kt)(s.Z,{groupId:"os",defaultValue:"win",values:[{label:"Windows",value:"win"},{label:"Linux",value:"linux"},{label:"macOS",value:"macos"}],mdxType:"Tabs"},(0,o.kt)(r.Z,{value:"win",mdxType:"TabItem"},(0,o.kt)("p",null,"Just run the game. Either through an executable, or any game launcher."),(0,o.kt)("p",null,"You can close the game once you see a logo or a loading screen.")),(0,o.kt)(r.Z,{value:"linux",mdxType:"TabItem"},(0,o.kt)("p",null,"Open the included ",(0,o.kt)("inlineCode",{parentName:"p"},"run_bepinex.sh")," script and edit the highlighted line to be the name of the executable:"),(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-bash",metastring:'title="run_bepinex.sh" {14}',title:'"run_bepinex.sh"',"{14}":!0},'#!/bin/sh\n# BepInEx running script\n#\n# This script is used to run a Unity game with BepInEx enabled.\n#\n# Usage: Configure the script below and simply run this script when you want to run your game modded.\n\n# -------- SETTINGS --------\n# ---- EDIT AS NEEDED ------\n\n# EDIT THIS: The name of the executable to run\n# LINUX: This is the name of the Unity game executable \n# MACOS: This is the name of the game app folder, including the .app suffix\nexecutable_name="StreetsOfRogue"\n\n# The rest is automatically handled by BepInEx\n# ...\n')),(0,o.kt)("p",null,"Open the terminal in the game's root directory and add execution permission to the script:"),(0,o.kt)(y,{mdxType:"BrowserWindow"},(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-bash"},"chmod u+x run_bepinex.sh\n"))),(0,o.kt)("br",null),(0,o.kt)("p",null,"Now you can run BepInEx by executing the script:"),(0,o.kt)(y,{mdxType:"BrowserWindow"},(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-bash"},"./run_bepinex.sh\n"))),(0,o.kt)("br",null)),(0,o.kt)(r.Z,{value:"macos",mdxType:"TabItem"},(0,o.kt)("p",null,"Open the included ",(0,o.kt)("inlineCode",{parentName:"p"},"run_bepinex.sh")," script and edit the highlighted line to be the name of the executable ",(0,o.kt)("strong",{parentName:"p"},"(including the ",(0,o.kt)("inlineCode",{parentName:"strong"},".app")," extension)"),":"),(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-bash",metastring:'title="run_bepinex.sh" {14}',title:'"run_bepinex.sh"',"{14}":!0},'#!/bin/sh\n# BepInEx running script\n#\n# This script is used to run a Unity game with BepInEx enabled.\n#\n# Usage: Configure the script below and simply run this script when you want to run your game modded.\n\n# -------- SETTINGS --------\n# ---- EDIT AS NEEDED ------\n\n# EDIT THIS: The name of the executable to run\n# LINUX: This is the name of the Unity game executable \n# MACOS: This is the name of the game app folder, including the .app suffix\nexecutable_name="StreetsOfRogue.app"\n\n# The rest is automatically handled by BepInEx\n# ...\n')),(0,o.kt)("p",null,"Open the terminal in the game's root directory and add execution permission to the script:"),(0,o.kt)(y,{mdxType:"BrowserWindow"},(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-bash"},"chmod u+x run_bepinex.sh\n"))),(0,o.kt)("br",null),(0,o.kt)("p",null,"Now you can run BepInEx by executing the script:"),(0,o.kt)(y,{mdxType:"BrowserWindow"},(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-bash"},"./run_bepinex.sh\n"))),(0,o.kt)("br",null))),(0,o.kt)("h3",{id:"running-bepinex-through-steam"},"Running BepInEx through Steam"),(0,o.kt)(s.Z,{groupId:"os",defaultValue:"win",values:[{label:"Windows",value:"win"},{label:"Linux",value:"linux"},{label:"macOS",value:"macos"}],mdxType:"Tabs"},(0,o.kt)(r.Z,{value:"win",mdxType:"TabItem"},(0,o.kt)("p",null,"On Windows you can run BepInEx through Steam too. Nothing to worry about.")),(0,o.kt)(r.Z,{value:"linux",mdxType:"TabItem"},(0,o.kt)("p",null,"Open Steam's game library, right-click on the game and click ",(0,o.kt)("strong",{parentName:"p"},"Properties..."),":"),(0,o.kt)("div",{className:"admonition admonition-note alert alert--secondary"},(0,o.kt)("div",{parentName:"div",className:"admonition-heading"},(0,o.kt)("h5",{parentName:"div"},(0,o.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,o.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,o.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.3 5.69a.942.942 0 0 1-.28-.7c0-.28.09-.52.28-.7.19-.18.42-.28.7-.28.28 0 .52.09.7.28.18.19.28.42.28.7 0 .28-.09.52-.28.7a1 1 0 0 1-.7.3c-.28 0-.52-.11-.7-.3zM8 7.99c-.02-.25-.11-.48-.31-.69-.2-.19-.42-.3-.69-.31H6c-.27.02-.48.13-.69.31-.2.2-.3.44-.31.69h1v3c.02.27.11.5.31.69.2.2.42.31.69.31h1c.27 0 .48-.11.69-.31.2-.19.3-.42.31-.69H8V7.98v.01zM7 2.3c-3.14 0-5.7 2.54-5.7 5.68 0 3.14 2.56 5.7 5.7 5.7s5.7-2.55 5.7-5.7c0-3.15-2.56-5.69-5.7-5.69v.01zM7 .98c3.86 0 7 3.14 7 7s-3.14 7-7 7-7-3.12-7-7 3.14-7 7-7z"}))),"note")),(0,o.kt)("div",{parentName:"div",className:"admonition-content"},(0,o.kt)("p",{parentName:"div"},"Screenshot needed"))),(0,o.kt)("p",null,"Click ",(0,o.kt)("strong",{parentName:"p"},"Set launch options..."),":"),(0,o.kt)("div",{className:"admonition admonition-note alert alert--secondary"},(0,o.kt)("div",{parentName:"div",className:"admonition-heading"},(0,o.kt)("h5",{parentName:"div"},(0,o.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,o.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,o.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.3 5.69a.942.942 0 0 1-.28-.7c0-.28.09-.52.28-.7.19-.18.42-.28.7-.28.28 0 .52.09.7.28.18.19.28.42.28.7 0 .28-.09.52-.28.7a1 1 0 0 1-.7.3c-.28 0-.52-.11-.7-.3zM8 7.99c-.02-.25-.11-.48-.31-.69-.2-.19-.42-.3-.69-.31H6c-.27.02-.48.13-.69.31-.2.2-.3.44-.31.69h1v3c.02.27.11.5.31.69.2.2.42.31.69.31h1c.27 0 .48-.11.69-.31.2-.19.3-.42.31-.69H8V7.98v.01zM7 2.3c-3.14 0-5.7 2.54-5.7 5.68 0 3.14 2.56 5.7 5.7 5.7s5.7-2.55 5.7-5.7c0-3.15-2.56-5.69-5.7-5.69v.01zM7 .98c3.86 0 7 3.14 7 7s-3.14 7-7 7-7-3.12-7-7 3.14-7 7-7z"}))),"note")),(0,o.kt)("div",{parentName:"div",className:"admonition-content"},(0,o.kt)("p",{parentName:"div"},"Screenshot needed"))),(0,o.kt)("p",null,"And type in:"),(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-bash"},"./run_bepinex.sh %command%\n")),(0,o.kt)("p",null,"Click ",(0,o.kt)("strong",{parentName:"p"},"OK")," and run the game through Steam.")),(0,o.kt)(r.Z,{value:"macos",mdxType:"TabItem"},(0,o.kt)("p",null,"Open Steam's game library, right-click on the game and click ",(0,o.kt)("strong",{parentName:"p"},"Properties..."),":"),(0,o.kt)("div",{className:"admonition admonition-note alert alert--secondary"},(0,o.kt)("div",{parentName:"div",className:"admonition-heading"},(0,o.kt)("h5",{parentName:"div"},(0,o.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,o.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,o.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.3 5.69a.942.942 0 0 1-.28-.7c0-.28.09-.52.28-.7.19-.18.42-.28.7-.28.28 0 .52.09.7.28.18.19.28.42.28.7 0 .28-.09.52-.28.7a1 1 0 0 1-.7.3c-.28 0-.52-.11-.7-.3zM8 7.99c-.02-.25-.11-.48-.31-.69-.2-.19-.42-.3-.69-.31H6c-.27.02-.48.13-.69.31-.2.2-.3.44-.31.69h1v3c.02.27.11.5.31.69.2.2.42.31.69.31h1c.27 0 .48-.11.69-.31.2-.19.3-.42.31-.69H8V7.98v.01zM7 2.3c-3.14 0-5.7 2.54-5.7 5.68 0 3.14 2.56 5.7 5.7 5.7s5.7-2.55 5.7-5.7c0-3.15-2.56-5.69-5.7-5.69v.01zM7 .98c3.86 0 7 3.14 7 7s-3.14 7-7 7-7-3.12-7-7 3.14-7 7-7z"}))),"note")),(0,o.kt)("div",{parentName:"div",className:"admonition-content"},(0,o.kt)("p",{parentName:"div"},"Screenshot needed"))),(0,o.kt)("p",null,"Click ",(0,o.kt)("strong",{parentName:"p"},"Set launch options..."),":"),(0,o.kt)("div",{className:"admonition admonition-note alert alert--secondary"},(0,o.kt)("div",{parentName:"div",className:"admonition-heading"},(0,o.kt)("h5",{parentName:"div"},(0,o.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,o.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,o.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.3 5.69a.942.942 0 0 1-.28-.7c0-.28.09-.52.28-.7.19-.18.42-.28.7-.28.28 0 .52.09.7.28.18.19.28.42.28.7 0 .28-.09.52-.28.7a1 1 0 0 1-.7.3c-.28 0-.52-.11-.7-.3zM8 7.99c-.02-.25-.11-.48-.31-.69-.2-.19-.42-.3-.69-.31H6c-.27.02-.48.13-.69.31-.2.2-.3.44-.31.69h1v3c.02.27.11.5.31.69.2.2.42.31.69.31h1c.27 0 .48-.11.69-.31.2-.19.3-.42.31-.69H8V7.98v.01zM7 2.3c-3.14 0-5.7 2.54-5.7 5.68 0 3.14 2.56 5.7 5.7 5.7s5.7-2.55 5.7-5.7c0-3.15-2.56-5.69-5.7-5.69v.01zM7 .98c3.86 0 7 3.14 7 7s-3.14 7-7 7-7-3.12-7-7 3.14-7 7-7z"}))),"note")),(0,o.kt)("div",{parentName:"div",className:"admonition-content"},(0,o.kt)("p",{parentName:"div"},"Screenshot needed"))),(0,o.kt)("p",null,"Now, open a terminal in the game's root directory and run:"),(0,o.kt)(y,{mdxType:"BrowserWindow"},(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-bash"},"pwd\n"))),(0,o.kt)("br",null),(0,o.kt)("p",null,"You'll get the full path to the game's root directory. Copy and paste it into the launch options field and then append ",(0,o.kt)("inlineCode",{parentName:"p"},"/run_bepinex.sh %command%"),":"),(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-bash"},"<PWD>/run_bepinex.sh %command%\n")),(0,o.kt)("p",null,"where ",(0,o.kt)("inlineCode",{parentName:"p"},"<PWD>")," is the full path to the game's root directory."),(0,o.kt)("p",null,"Click ",(0,o.kt)("strong",{parentName:"p"},"OK")," and run the game through Steam."))),(0,o.kt)("h2",{id:"roguelibs"},"Installing RogueLibs"),(0,o.kt)(s.Z,{defaultValue:"v2",values:[{label:"RogueLibs v2.x.x",value:"v2"},{label:"RogueLibs v3.x.x",value:"v3"}],mdxType:"Tabs"},(0,o.kt)(r.Z,{value:"v2",mdxType:"TabItem"},(0,o.kt)("p",null,(0,o.kt)("strong",{parentName:"p"},(0,o.kt)("a",{parentName:"strong",href:"https://github.com/Abbysssal/RogueLibs/releases/latest"},"Download the latest RogueLibs version"))),(0,o.kt)("p",null,"You need to download only one file - ",(0,o.kt)("inlineCode",{parentName:"p"},"RogueLibs.dll"),"."),(0,o.kt)("div",{className:"admonition admonition-note alert alert--secondary"},(0,o.kt)("div",{parentName:"div",className:"admonition-heading"},(0,o.kt)("h5",{parentName:"div"},(0,o.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,o.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,o.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.3 5.69a.942.942 0 0 1-.28-.7c0-.28.09-.52.28-.7.19-.18.42-.28.7-.28.28 0 .52.09.7.28.18.19.28.42.28.7 0 .28-.09.52-.28.7a1 1 0 0 1-.7.3c-.28 0-.52-.11-.7-.3zM8 7.99c-.02-.25-.11-.48-.31-.69-.2-.19-.42-.3-.69-.31H6c-.27.02-.48.13-.69.31-.2.2-.3.44-.31.69h1v3c.02.27.11.5.31.69.2.2.42.31.69.31h1c.27 0 .48-.11.69-.31.2-.19.3-.42.31-.69H8V7.98v.01zM7 2.3c-3.14 0-5.7 2.54-5.7 5.68 0 3.14 2.56 5.7 5.7 5.7s5.7-2.55 5.7-5.7c0-3.15-2.56-5.69-5.7-5.69v.01zM7 .98c3.86 0 7 3.14 7 7s-3.14 7-7 7-7-3.12-7-7 3.14-7 7-7z"}))),"note")),(0,o.kt)("div",{parentName:"div",className:"admonition-content"},(0,o.kt)("p",{parentName:"div"},"Screenshot needed"))),(0,o.kt)("p",null,"Go to the BepInEx's directory and put ",(0,o.kt)("inlineCode",{parentName:"p"},"RogueLibs.dll")," into ",(0,o.kt)("inlineCode",{parentName:"p"},"plugins")," directory:"),(0,o.kt)("div",{className:"admonition admonition-note alert alert--secondary"},(0,o.kt)("div",{parentName:"div",className:"admonition-heading"},(0,o.kt)("h5",{parentName:"div"},(0,o.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,o.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,o.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.3 5.69a.942.942 0 0 1-.28-.7c0-.28.09-.52.28-.7.19-.18.42-.28.7-.28.28 0 .52.09.7.28.18.19.28.42.28.7 0 .28-.09.52-.28.7a1 1 0 0 1-.7.3c-.28 0-.52-.11-.7-.3zM8 7.99c-.02-.25-.11-.48-.31-.69-.2-.19-.42-.3-.69-.31H6c-.27.02-.48.13-.69.31-.2.2-.3.44-.31.69h1v3c.02.27.11.5.31.69.2.2.42.31.69.31h1c.27 0 .48-.11.69-.31.2-.19.3-.42.31-.69H8V7.98v.01zM7 2.3c-3.14 0-5.7 2.54-5.7 5.68 0 3.14 2.56 5.7 5.7 5.7s5.7-2.55 5.7-5.7c0-3.15-2.56-5.69-5.7-5.69v.01zM7 .98c3.86 0 7 3.14 7 7s-3.14 7-7 7-7-3.12-7-7 3.14-7 7-7z"}))),"note")),(0,o.kt)("div",{parentName:"div",className:"admonition-content"},(0,o.kt)("p",{parentName:"div"},"Screenshot/GIF needed")))),(0,o.kt)(r.Z,{value:"v3",mdxType:"TabItem"},(0,o.kt)("div",{className:"admonition admonition-caution alert alert--warning"},(0,o.kt)("div",{parentName:"div",className:"admonition-heading"},(0,o.kt)("h5",{parentName:"div"},(0,o.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,o.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"16",height:"16",viewBox:"0 0 16 16"},(0,o.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M8.893 1.5c-.183-.31-.52-.5-.887-.5s-.703.19-.886.5L.138 13.499a.98.98 0 0 0 0 1.001c.193.31.53.501.886.501h13.964c.367 0 .704-.19.877-.5a1.03 1.03 0 0 0 .01-1.002L8.893 1.5zm.133 11.497H6.987v-2.003h2.039v2.003zm0-3.004H6.987V5.987h2.039v4.006z"}))),"caution")),(0,o.kt)("div",{parentName:"div",className:"admonition-content"},(0,o.kt)("p",{parentName:"div"},"RogueLibs v3.x.x is still in beta! Backup your save files before installing it."))),(0,o.kt)("p",null,(0,o.kt)("strong",{parentName:"p"},(0,o.kt)("a",{parentName:"strong",href:"https://github.com/Abbysssal/RogueLibs/releases"},"Download the latest RogueLibs version"))),(0,o.kt)("p",null,"You need to download only two files: ",(0,o.kt)("inlineCode",{parentName:"p"},"RogueLibsCore.dll")," and ",(0,o.kt)("inlineCode",{parentName:"p"},"RogueLibsPatcher.dll"),"."),(0,o.kt)("div",{className:"admonition admonition-note alert alert--secondary"},(0,o.kt)("div",{parentName:"div",className:"admonition-heading"},(0,o.kt)("h5",{parentName:"div"},(0,o.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,o.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,o.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.3 5.69a.942.942 0 0 1-.28-.7c0-.28.09-.52.28-.7.19-.18.42-.28.7-.28.28 0 .52.09.7.28.18.19.28.42.28.7 0 .28-.09.52-.28.7a1 1 0 0 1-.7.3c-.28 0-.52-.11-.7-.3zM8 7.99c-.02-.25-.11-.48-.31-.69-.2-.19-.42-.3-.69-.31H6c-.27.02-.48.13-.69.31-.2.2-.3.44-.31.69h1v3c.02.27.11.5.31.69.2.2.42.31.69.31h1c.27 0 .48-.11.69-.31.2-.19.3-.42.31-.69H8V7.98v.01zM7 2.3c-3.14 0-5.7 2.54-5.7 5.68 0 3.14 2.56 5.7 5.7 5.7s5.7-2.55 5.7-5.7c0-3.15-2.56-5.69-5.7-5.69v.01zM7 .98c3.86 0 7 3.14 7 7s-3.14 7-7 7-7-3.12-7-7 3.14-7 7-7z"}))),"note")),(0,o.kt)("div",{parentName:"div",className:"admonition-content"},(0,o.kt)("p",{parentName:"div"},"Screenshot needed"))),(0,o.kt)("p",null,"Go to the BepInEx's directory and put ",(0,o.kt)("inlineCode",{parentName:"p"},"RogueLibsCore.dll")," into ",(0,o.kt)("inlineCode",{parentName:"p"},"plugins")," directory:"),(0,o.kt)("div",{className:"admonition admonition-note alert alert--secondary"},(0,o.kt)("div",{parentName:"div",className:"admonition-heading"},(0,o.kt)("h5",{parentName:"div"},(0,o.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,o.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,o.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.3 5.69a.942.942 0 0 1-.28-.7c0-.28.09-.52.28-.7.19-.18.42-.28.7-.28.28 0 .52.09.7.28.18.19.28.42.28.7 0 .28-.09.52-.28.7a1 1 0 0 1-.7.3c-.28 0-.52-.11-.7-.3zM8 7.99c-.02-.25-.11-.48-.31-.69-.2-.19-.42-.3-.69-.31H6c-.27.02-.48.13-.69.31-.2.2-.3.44-.31.69h1v3c.02.27.11.5.31.69.2.2.42.31.69.31h1c.27 0 .48-.11.69-.31.2-.19.3-.42.31-.69H8V7.98v.01zM7 2.3c-3.14 0-5.7 2.54-5.7 5.68 0 3.14 2.56 5.7 5.7 5.7s5.7-2.55 5.7-5.7c0-3.15-2.56-5.69-5.7-5.69v.01zM7 .98c3.86 0 7 3.14 7 7s-3.14 7-7 7-7-3.12-7-7 3.14-7 7-7z"}))),"note")),(0,o.kt)("div",{parentName:"div",className:"admonition-content"},(0,o.kt)("p",{parentName:"div"},"Screenshot/GIF needed"))),(0,o.kt)("p",null,"Put ",(0,o.kt)("inlineCode",{parentName:"p"},"RogueLibsPatcher.dll")," into ",(0,o.kt)("inlineCode",{parentName:"p"},"patchers")," (not ",(0,o.kt)("inlineCode",{parentName:"p"},"plugins"),"!) directory:"),(0,o.kt)("div",{className:"admonition admonition-note alert alert--secondary"},(0,o.kt)("div",{parentName:"div",className:"admonition-heading"},(0,o.kt)("h5",{parentName:"div"},(0,o.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,o.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,o.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.3 5.69a.942.942 0 0 1-.28-.7c0-.28.09-.52.28-.7.19-.18.42-.28.7-.28.28 0 .52.09.7.28.18.19.28.42.28.7 0 .28-.09.52-.28.7a1 1 0 0 1-.7.3c-.28 0-.52-.11-.7-.3zM8 7.99c-.02-.25-.11-.48-.31-.69-.2-.19-.42-.3-.69-.31H6c-.27.02-.48.13-.69.31-.2.2-.3.44-.31.69h1v3c.02.27.11.5.31.69.2.2.42.31.69.31h1c.27 0 .48-.11.69-.31.2-.19.3-.42.31-.69H8V7.98v.01zM7 2.3c-3.14 0-5.7 2.54-5.7 5.68 0 3.14 2.56 5.7 5.7 5.7s5.7-2.55 5.7-5.7c0-3.15-2.56-5.69-5.7-5.69v.01zM7 .98c3.86 0 7 3.14 7 7s-3.14 7-7 7-7-3.12-7-7 3.14-7 7-7z"}))),"note")),(0,o.kt)("div",{parentName:"div",className:"admonition-content"},(0,o.kt)("p",{parentName:"div"},"Screenshot/GIF needed"))))),(0,o.kt)("h2",{id:"plugins"},"Installing plugins (aka. mods)"),(0,o.kt)("p",null,"Download the plugins that you want to install (",(0,o.kt)("inlineCode",{parentName:"p"},".dll"),"s)."),(0,o.kt)("p",null,"And put the ",(0,o.kt)("inlineCode",{parentName:"p"},".dll")," files in the ",(0,o.kt)("inlineCode",{parentName:"p"},"BepInEx/plugins")," directory."),(0,o.kt)("div",{className:"admonition admonition-note alert alert--secondary"},(0,o.kt)("div",{parentName:"div",className:"admonition-heading"},(0,o.kt)("h5",{parentName:"div"},(0,o.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,o.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,o.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.3 5.69a.942.942 0 0 1-.28-.7c0-.28.09-.52.28-.7.19-.18.42-.28.7-.28.28 0 .52.09.7.28.18.19.28.42.28.7 0 .28-.09.52-.28.7a1 1 0 0 1-.7.3c-.28 0-.52-.11-.7-.3zM8 7.99c-.02-.25-.11-.48-.31-.69-.2-.19-.42-.3-.69-.31H6c-.27.02-.48.13-.69.31-.2.2-.3.44-.31.69h1v3c.02.27.11.5.31.69.2.2.42.31.69.31h1c.27 0 .48-.11.69-.31.2-.19.3-.42.31-.69H8V7.98v.01zM7 2.3c-3.14 0-5.7 2.54-5.7 5.68 0 3.14 2.56 5.7 5.7 5.7s5.7-2.55 5.7-5.7c0-3.15-2.56-5.69-5.7-5.69v.01zM7 .98c3.86 0 7 3.14 7 7s-3.14 7-7 7-7-3.12-7-7 3.14-7 7-7z"}))),"note")),(0,o.kt)("div",{parentName:"div",className:"admonition-content"},(0,o.kt)("p",{parentName:"div"},"Screenshot needed"))))}z.isMDXComponent=!0}}]);