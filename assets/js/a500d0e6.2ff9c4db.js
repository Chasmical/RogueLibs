"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[5680],{3905:function(e,t,n){n.d(t,{Zo:function(){return u},kt:function(){return m}});var o=n(7294);function r(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function i(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var o=Object.getOwnPropertySymbols(e);t&&(o=o.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,o)}return n}function l(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?i(Object(n),!0).forEach((function(t){r(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):i(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function a(e,t){if(null==e)return{};var n,o,r=function(e,t){if(null==e)return{};var n,o,r={},i=Object.keys(e);for(o=0;o<i.length;o++)n=i[o],t.indexOf(n)>=0||(r[n]=e[n]);return r}(e,t);if(Object.getOwnPropertySymbols){var i=Object.getOwnPropertySymbols(e);for(o=0;o<i.length;o++)n=i[o],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(r[n]=e[n])}return r}var s=o.createContext({}),p=function(e){var t=o.useContext(s),n=t;return e&&(n="function"==typeof e?e(t):l(l({},t),e)),n},u=function(e){var t=p(e.components);return o.createElement(s.Provider,{value:t},e.children)},d={inlineCode:"code",wrapper:function(e){var t=e.children;return o.createElement(o.Fragment,{},t)}},c=o.forwardRef((function(e,t){var n=e.components,r=e.mdxType,i=e.originalType,s=e.parentName,u=a(e,["components","mdxType","originalType","parentName"]),c=p(n),m=r,h=c["".concat(s,".").concat(m)]||c[m]||d[m]||i;return n?o.createElement(h,l(l({ref:t},u),{},{components:n})):o.createElement(h,l({ref:t},u))}));function m(e,t){var n=arguments,r=t&&t.mdxType;if("string"==typeof e||r){var i=n.length,l=new Array(i);l[0]=c;var a={};for(var s in t)hasOwnProperty.call(t,s)&&(a[s]=t[s]);a.originalType=e,a.mdxType="string"==typeof e?e:r,l[1]=a;for(var p=2;p<i;p++)l[p]=n[p];return o.createElement.apply(null,l)}return o.createElement.apply(null,n)}c.displayName="MDXCreateElement"},7181:function(e,t,n){n.r(t),n.d(t,{contentTitle:function(){return k},default:function(){return b},frontMatter:function(){return A},metadata:function(){return g},toc:function(){return f}});var o=n(7462),r=n(3366),i=n(7294),l=n(3905),a="faq_48+3",s="question_xve-",p="answer_d3gX",u="questionBody_lr5j",d="answerBody_4cjC";function c(e){var t=e.children;return i.createElement("div",{className:s},i.createElement("img",{width:"24",height:"32",src:"data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAADAAAABACAMAAABr/gR0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAASUExURWsTE8cARv8AAE8PD5sASQAAAPrhDmIAAAAGdFJOU///////ALO/pL8AAAAJcEhZcwAADsIAAA7CARUoSoAAAACNSURBVEhL1ZPLDoAgDAR98f+/LENasyAxejBp5wJddi42LuUjN2EZsPgiukBhrWzCKEUWZmVHpajCWN4NGxsuRRYsb2UyUCm6oA/cyUDz6ALwCDa2WZeZQVC0zOllyCB42dEyZBGOyqwMmQTIKgAS2NiRQaDI0vh5Xn+lgAJLQ8oqABLY2JFFeOJvoZQTD08rUeqmk1IAAAAASUVORK5CYII="}),i.createElement("div",{className:u},t))}function m(e){var t=e.children,n=(0,i.useState)(!1),o=n[0],r=n[1],l=i.Children.toArray(t),s=l.filter((function(e){var t;return"Question"===(null==e||null==(t=e.props)?void 0:t.mdxType)})),u=l.filter((function(e){var t;return"Question"!==(null==e||null==(t=e.props)?void 0:t.mdxType)}));return i.createElement("div",{className:a,onClick:function(){return r(!o)}},s,o&&i.createElement("div",{className:p},i.createElement("img",{width:"24",height:"32",src:"data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAADAAAABACAMAAABr/gR0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAVUExURWpHEv/MAP/yAP/8wE8uD/+cAAAAAFIJHX0AAAAHdFJOU////////wAaSwNGAAAACXBIWXMAAA7CAAAOwgEVKEqAAAAAdUlEQVRIS9XSQQrAIAxEUWtb739k8yWFKFJwl/kbEeattLTDVEDx/DqlABheVrV2KDuI468VKQDf1dviVAOPNdYhRXD0cIkBMeZUBK81hAVSAxTROiYlQKqAQOTXKQXAkEfbfTxSATwaSBUQiPw6pQL+Sgda68blOFEnm6HSAAAAAElFTkSuQmCC"}),i.createElement("div",{className:d},u)))}var h=["components"],A={},k="Frequently Encountered Problems",g={unversionedId:"user/troubleshooting",id:"user/troubleshooting",title:"Frequently Encountered Problems",description:"BepInEx is not working",source:"@site/docs/user/troubleshooting.mdx",sourceDirName:"user",slug:"/user/troubleshooting",permalink:"/RogueLibs/docs/user/troubleshooting",editUrl:"https://github.com/Abbysssal/RogueLibs/edit/main/website/docs/user/troubleshooting.mdx",tags:[],version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"Installation",permalink:"/RogueLibs/docs/user/installation"},next:{title:"Getting Started",permalink:"/RogueLibs/docs/dev/getting-started"}},f=[{value:"BepInEx is not working",id:"bepinex-is-not-working",children:[],level:2},{value:"RogueLibs is not working",id:"roguelibs-is-not-working",children:[],level:2},{value:"Plugins are not working",id:"plugins-are-not-working",children:[],level:2}],y={toc:f};function b(e){var t=e.components,n=(0,r.Z)(e,h);return(0,l.kt)("wrapper",(0,o.Z)({},y,n,{components:t,mdxType:"MDXLayout"}),(0,l.kt)("h1",{id:"frequently-encountered-problems"},"Frequently Encountered Problems"),(0,l.kt)("h2",{id:"bepinex-is-not-working"},"BepInEx is not working"),(0,l.kt)(m,{mdxType:"FAQ"},(0,l.kt)(c,{mdxType:"Question"},(0,l.kt)("p",null,"I only extracted the ",(0,l.kt)("inlineCode",{parentName:"p"},"BepInEx")," folder from the archive, and BepInEx doesn't work.")),(0,l.kt)("p",null,"Pay more attention to the instructions.",(0,l.kt)("br",{parentName:"p"}),"\n","It says ",(0,l.kt)("em",{parentName:"p"},'"Extract the contents of the .zip file into the game\'s root directory."'),".",(0,l.kt)("br",{parentName:"p"}),"\n","And by ",(0,l.kt)("em",{parentName:"p"},'"the contents"')," I mean ",(0,l.kt)("strong",{parentName:"p"},"all")," folders and ",(0,l.kt)("strong",{parentName:"p"},"all")," files in the archive.")),(0,l.kt)(m,{mdxType:"FAQ"},(0,l.kt)(c,{mdxType:"Question"},(0,l.kt)("p",null,"I have Windows and I installed BepInEx for Linux/macOS (",(0,l.kt)("inlineCode",{parentName:"p"},"unix"),").")),(0,l.kt)("p",null,"Uninstall the Linux/macOS version by deleting the following:"),(0,l.kt)("ul",null,(0,l.kt)("li",{parentName:"ul"},(0,l.kt)("inlineCode",{parentName:"li"},"BepInEx")," folder;"),(0,l.kt)("li",{parentName:"ul"},(0,l.kt)("inlineCode",{parentName:"li"},"doorstop_libs")," folder;"),(0,l.kt)("li",{parentName:"ul"},(0,l.kt)("inlineCode",{parentName:"li"},"changelog.txt")," file;"),(0,l.kt)("li",{parentName:"ul"},(0,l.kt)("inlineCode",{parentName:"li"},"run_bepinex.sh")," file;")),(0,l.kt)("p",null,"And install the correct version of BepInEx for your OS.")),(0,l.kt)(m,{mdxType:"FAQ"},(0,l.kt)(c,{mdxType:"Question"},(0,l.kt)("p",null,"I have Linux/macOS and I installed BepInEx for Windows (",(0,l.kt)("inlineCode",{parentName:"p"},"x64"),"/",(0,l.kt)("inlineCode",{parentName:"p"},"x86"),").")),(0,l.kt)("p",null,"Uninstall the Windows version by deleting the following:"),(0,l.kt)("ul",null,(0,l.kt)("li",{parentName:"ul"},(0,l.kt)("inlineCode",{parentName:"li"},"BepInEx")," folder;"),(0,l.kt)("li",{parentName:"ul"},(0,l.kt)("inlineCode",{parentName:"li"},"changelog.txt")," file;"),(0,l.kt)("li",{parentName:"ul"},(0,l.kt)("inlineCode",{parentName:"li"},"doorstop_config.ini")," file;"),(0,l.kt)("li",{parentName:"ul"},(0,l.kt)("inlineCode",{parentName:"li"},"winhttp.dll")," file;")),(0,l.kt)("p",null,"And install the correct version of BepInEx for your OS.")),(0,l.kt)(m,{mdxType:"FAQ"},(0,l.kt)(c,{mdxType:"Question"},"I have Windows and the game's executable is x32/x64 and I installed BepInEx for the wrong version (x64/x32)."),(0,l.kt)("p",null,"Simply install the correct version of BepInEx for your executable's type.",(0,l.kt)("br",{parentName:"p"}),"\n",'When copying over new files, select "Replace the file in the destination".')),(0,l.kt)(m,{mdxType:"FAQ"},(0,l.kt)(c,{mdxType:"Question"},"I installed BepInEx correctly, but it still doesn't work."),(0,l.kt)("p",null,"Ask in the ",(0,l.kt)("a",{parentName:"p",href:"https://discord.gg/m3zuHSwQw2"},"#\ud83d\udcacmodding\ud83d\udd27")," channel first. Maybe you did something wrong."),(0,l.kt)("p",null,"If it still doesn't work, you'll have to contact the ",(0,l.kt)("a",{parentName:"p",href:"https://github.com/BepInEx/BepInEx/issues/new/choose"},"BepInEx's developers"),".")),(0,l.kt)("h2",{id:"roguelibs-is-not-working"},"RogueLibs is not working"),(0,l.kt)(m,{mdxType:"FAQ"},(0,l.kt)(c,{mdxType:"Question"},(0,l.kt)("p",null,"I put both ",(0,l.kt)("inlineCode",{parentName:"p"},"RogueLibsCore.dll")," and ",(0,l.kt)("inlineCode",{parentName:"p"},"RogueLibsPatcher.dll")," in ",(0,l.kt)("inlineCode",{parentName:"p"},"BepInEx/plugins")," and RogueLibs doesn't work.")),(0,l.kt)("p",null,(0,l.kt)("inlineCode",{parentName:"p"},"RogueLibsPatcher.dll")," is not a plugin, it's a patcher. You need to put it in ",(0,l.kt)("inlineCode",{parentName:"p"},"BepInEx/patchers"),".")),(0,l.kt)(m,{mdxType:"FAQ"},(0,l.kt)(c,{mdxType:"Question"},"I also have ECTD (Edit Characters Through Description) mod installed."),(0,l.kt)("p",null,"Sorry, but at the moment, RogueLibs v3 is not compatible with ECTD.",(0,l.kt)("br",{parentName:"p"}),"\n","I'm working on that and will fix the issue in one of the updates.")),(0,l.kt)(m,{mdxType:"FAQ"},(0,l.kt)(c,{mdxType:"Question"},"I have both v2 and v3 versions of RogueLibs installed."),(0,l.kt)("p",null,"Why the hell would you do that? You have to choose either v2 or v3."),(0,l.kt)("p",null,"You know, you can't just install two different versions of the same software and expect them to work normally.")),(0,l.kt)(m,{mdxType:"FAQ"},(0,l.kt)(c,{mdxType:"Question"},"I installed RogueLibs correctly and it still doesn't work."),(0,l.kt)("p",null,"In that case, go to ",(0,l.kt)("inlineCode",{parentName:"p"},"BepInEx")," folder and grab a file called ",(0,l.kt)("inlineCode",{parentName:"p"},"LogOutput.log"),".",(0,l.kt)("br",{parentName:"p"}),"\n",(0,l.kt)("a",{parentName:"p",href:"https://discord.com/users/511178002277597185"},"Send it to me")," or share it in the ",(0,l.kt)("a",{parentName:"p",href:"https://discord.gg/m3zuHSwQw2"},"#\ud83d\udcacmodding\ud83d\udd27")," channel. You'll get help.")),(0,l.kt)("h2",{id:"plugins-are-not-working"},"Plugins are not working"),(0,l.kt)(m,{mdxType:"FAQ"},(0,l.kt)(c,{mdxType:"Question"},"I have mods that were made with RogueLibs v2 and they're not working with RogueLibs v3."),(0,l.kt)("p",null,"Well, duh. v3 is not compatible with v2 mods."),(0,l.kt)("p",null,"Here's what you can do:"),(0,l.kt)("ul",null,(0,l.kt)("li",{parentName:"ul"},"Use RogueLibs v2 (although you won't be able to use v3 mods);"),(0,l.kt)("li",{parentName:"ul"},"Wait until the mod developers update your mods to v3.",(0,l.kt)("br",{parentName:"li"}),"You should probably contact them (",(0,l.kt)("a",{parentName:"li",href:"https://discord.gg/m3zuHSwQw2"},"#\ud83d\udcacmodding\ud83d\udd27"),") to make sure they're working on it."))),(0,l.kt)(m,{mdxType:"FAQ"},(0,l.kt)(c,{mdxType:"Question"},"I installed the mods without paying attention to their dependencies, and they don't work."),(0,l.kt)("p",null,"In that case, go to the ",(0,l.kt)("inlineCode",{parentName:"p"},"BepInEx")," folder and open a file called ",(0,l.kt)("inlineCode",{parentName:"p"},"LogOutput.log"),":"),(0,l.kt)("pre",null,(0,l.kt)("code",{parentName:"pre"},"[Error  :   BepInEx] Could not load [RogueLibsCore Test 3.0.2] because it has missing dependencies: abbysssal.streetsofrogue.roguelibscore (v3.0.2 or newer)\n[Error  :   BepInEx] Could not load [SpritePackLoader 0.3] because it has missing dependencies: abbysssal.streetsofrogue.roguelibscore (v3.0 or newer)\n")),(0,l.kt)("p",null,"You'll see the missing dependencies. Go and install them.",(0,l.kt)("br",{parentName:"p"}),"\n","There will be mods' GUIDs instead of their actual names, but you should be able to figure them out.")),(0,l.kt)(m,{mdxType:"FAQ"},(0,l.kt)(c,{mdxType:"Question"},"I installed the mods correctly but they don't work."),(0,l.kt)("p",null,"In that case, go to ",(0,l.kt)("inlineCode",{parentName:"p"},"BepInEx")," folder and grab a file called ",(0,l.kt)("inlineCode",{parentName:"p"},"LogOutput.log"),".",(0,l.kt)("br",{parentName:"p"}),"\n","Share it in the ",(0,l.kt)("a",{parentName:"p",href:"https://discord.gg/m3zuHSwQw2"},"#\ud83d\udcacmodding\ud83d\udd27")," channel, or with the mod's developer. They'll help you out.")))}b.isMDXComponent=!0}}]);