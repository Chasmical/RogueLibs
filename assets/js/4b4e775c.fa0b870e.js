"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[6895],{3905:(e,t,n)=>{n.d(t,{Zo:()=>d,kt:()=>m});var o=n(7294);function r(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function a(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var o=Object.getOwnPropertySymbols(e);t&&(o=o.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,o)}return n}function i(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?a(Object(n),!0).forEach((function(t){r(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):a(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function l(e,t){if(null==e)return{};var n,o,r=function(e,t){if(null==e)return{};var n,o,r={},a=Object.keys(e);for(o=0;o<a.length;o++)n=a[o],t.indexOf(n)>=0||(r[n]=e[n]);return r}(e,t);if(Object.getOwnPropertySymbols){var a=Object.getOwnPropertySymbols(e);for(o=0;o<a.length;o++)n=a[o],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(r[n]=e[n])}return r}var s=o.createContext({}),u=function(e){var t=o.useContext(s),n=t;return e&&(n="function"==typeof e?e(t):i(i({},t),e)),n},d=function(e){var t=u(e.components);return o.createElement(s.Provider,{value:t},e.children)},p={inlineCode:"code",wrapper:function(e){var t=e.children;return o.createElement(o.Fragment,{},t)}},c=o.forwardRef((function(e,t){var n=e.components,r=e.mdxType,a=e.originalType,s=e.parentName,d=l(e,["components","mdxType","originalType","parentName"]),c=u(n),m=r,h=c["".concat(s,".").concat(m)]||c[m]||p[m]||a;return n?o.createElement(h,i(i({ref:t},d),{},{components:n})):o.createElement(h,i({ref:t},d))}));function m(e,t){var n=arguments,r=t&&t.mdxType;if("string"==typeof e||r){var a=n.length,i=new Array(a);i[0]=c;var l={};for(var s in t)hasOwnProperty.call(t,s)&&(l[s]=t[s]);l.originalType=e,l.mdxType="string"==typeof e?e:r,i[1]=l;for(var u=2;u<a;u++)i[u]=n[u];return o.createElement.apply(null,i)}return o.createElement.apply(null,n)}c.displayName="MDXCreateElement"},1016:(e,t,n)=>{n.d(t,{Z:()=>a});var o=n(7462),r=n(7294);function a(e){let{children:t,...n}=e;return r.createElement("div",(0,o.Z)({role:"tabpanel"},n),t)}},250:(e,t,n)=>{n.d(t,{Z:()=>p});var o=n(7294),r=n(7094),a=n(6010);const i="tabItem_V91s",l="tabItemActive_JsUu",s="tab_ntnM";const u=37,d=39;function p(e){const{lazy:t,defaultValue:n,values:p,groupId:c}=e,{tabGroupChoices:m,setTabGroupChoices:h}=(0,r.U)(),[f,g]=(0,o.useState)(n),y=o.Children.toArray(e.children),k=[];if(null!=c){const e=m[c];null!=e&&e!==f&&p.some((t=>t.value===e))&&g(e)}const b=e=>{const t=e.currentTarget,n=k.indexOf(t),o=p[n].value;g(o),null!=c&&(h(c,o),setTimeout((()=>{(function(e){const{top:t,left:n,bottom:o,right:r}=e.getBoundingClientRect(),{innerHeight:a,innerWidth:i}=window;return t>=0&&r<=i&&o<=a&&n>=0})(t)||(t.scrollIntoView({block:"center",behavior:"smooth"}),t.classList.add(l),setTimeout((()=>t.classList.remove(l)),2e3))}),150))},v=e=>{let t;switch(e.keyCode){case d:{const n=k.indexOf(e.target)+1;t=k[n]||k[0];break}case u:{const n=k.indexOf(e.target)-1;t=k[n]||k[k.length-1];break}default:return}t.focus()},w=(e,t)=>t.value===e||t.values&&-1!=t.values.indexOf(e);return o.createElement("div",{className:"tabs-container"},o.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:"tabs"},p.map((e=>{let{value:t,label:n}=e;return o.createElement("li",{role:"tab",tabIndex:f===t?0:-1,"aria-selected":f===t,className:(0,a.Z)("tabs__item",i,{"tabs__item--active":f===t}),key:t,ref:e=>e&&k.push(e),onKeyDown:v,onFocus:b,onClick:b},n)}))),t?o.cloneElement(y.find((e=>w(f,e.props))),{className:s}):o.createElement("div",null,y.map(((e,t)=>o.cloneElement(e,{key:t,hidden:!w(f,e.props),className:s})))),o.createElement("br",null))}},2573:(e,t,n)=>{n.r(t),n.d(t,{assets:()=>u,contentTitle:()=>l,default:()=>c,frontMatter:()=>i,metadata:()=>s,toc:()=>d});var o=n(7462),r=(n(7294),n(3905)),a=(n(250),n(1016),n(4996));const i={},l="Getting Started (new!)",s={unversionedId:"dev/getting-started",id:"dev/getting-started",title:"Getting Started (new!)",description:"Required software",source:"@site/docs/dev/getting-started.mdx",sourceDirName:"dev",slug:"/dev/getting-started",permalink:"/RogueLibs/docs/dev/getting-started",draft:!1,editUrl:"https://github.com/SugarBarrel/RogueLibs/edit/main/website/docs/dev/getting-started.mdx",tags:[],version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"Frequently Encountered Problems",permalink:"/RogueLibs/docs/user/troubleshooting"},next:{title:"Creating a Custom Item",permalink:"/RogueLibs/docs/dev/items/create-item"}},u={},d=[{value:"Required software",id:"tools",level:2},{value:"New Way of Modding",id:"new-way-of-modding",level:2},{value:"Workspace Structure",id:"workspace-structure",level:2},{value:"<code>.ref</code> - References",id:"references",level:3},{value:"<code>.events</code> - PluginBuildEvents",id:"pluginbuildevents",level:3},{value:"Solution Folders",id:"solution-folders",level:3}],p={toc:d};function c(e){let{components:t,...n}=e;return(0,r.kt)("wrapper",(0,o.Z)({},p,n,{components:t,mdxType:"MDXLayout"}),(0,r.kt)("h1",{id:"getting-started-new"},"Getting Started (new!)"),(0,r.kt)("h2",{id:"tools"},"Required software"),(0,r.kt)("p",null,"First of all, you'll need to install these tools:"),(0,r.kt)("ul",null,(0,r.kt)("li",{parentName:"ul"},(0,r.kt)("p",{parentName:"li"},(0,r.kt)("strong",{parentName:"p"},(0,r.kt)("a",{parentName:"strong",href:"https://github.com/dnSpy/dnSpy/releases/latest"},"dnSpy"))," - a .NET assembly editor (and a debugger, but it's way too tedious to make it work for BepInEx and plugins). You're not gonna edit assemblies, just view them to see how the game and/or other plugins work.")),(0,r.kt)("li",{parentName:"ul"},(0,r.kt)("p",{parentName:"li"},(0,r.kt)("strong",{parentName:"p"},(0,r.kt)("a",{parentName:"strong",href:"https://visualstudio.microsoft.com/downloads/"},"Visual Studio 2019 Community"))," - the Integrated Development Environment (IDE for short) that you'll be working in."))),(0,r.kt)("h2",{id:"new-way-of-modding"},"New Way of Modding"),(0,r.kt)("p",null,"Instead of creating a project manually, we'll be using a ",(0,r.kt)("strong",{parentName:"p"},"special template")," with a ton of advantages!"),(0,r.kt)("ul",null,(0,r.kt)("li",{parentName:"ul"},"The template is SDK-style, which means that:",(0,r.kt)("ul",{parentName:"li"},(0,r.kt)("li",{parentName:"ul"},"You'll be able to use most of the features of the latest C# versions!"),(0,r.kt)("li",{parentName:"ul"},"Less messing around with the settings and configurations!"))),(0,r.kt)("li",{parentName:"ul"},"No DLL Hell. All of the references are in a single designated folder!"),(0,r.kt)("li",{parentName:"ul"},"PluginBuildEvents utility will move your mods to BepInEx/plugins automatically!"),(0,r.kt)("li",{parentName:"ul"},"The template contains the base code to quickly start developing your mod!"),(0,r.kt)("li",{parentName:"ul"},"Most of the stuff you could possibly need is already in the template!")),(0,r.kt)("p",null,"You can just copy-paste the template, and start working on your mod in less than a minute!"),(0,r.kt)("blockquote",null,(0,r.kt)("p",{parentName:"blockquote"},(0,r.kt)("em",{parentName:"p"},"Before that template was created, you had to create a project and some folders, copy-paste dlls, add references, set up some settings, write the base code, then write some of your mod's content, then realize that you forgot to add a reference, then continue working on your mod, then again, you forgot to add something really fundamental and you have to rewrite the entire thing, and then when you almost got it to a stable release, you remember \"that cool feature in C# 8.0 and later\", start the project from scratch to try and add that feature, fail and then cry in your bed because you really need that feature and you can't imagine modding the game without it, and also because you scratched the entire project and you don't care enough to start over...")," True story.")),(0,r.kt)("h2",{id:"workspace-structure"},"Workspace Structure"),(0,r.kt)("p",null,"First of all, ",(0,r.kt)("strong",{parentName:"p"},(0,r.kt)("a",{parentName:"strong",href:"https://drive.google.com/file/d/1d1FH0Gh7egp7Z4QugsCF4aCE4-NgWD1X/view?usp=sharing"},"download the workspace template"))," and extract the ",(0,r.kt)("inlineCode",{parentName:"p"},"sor-repos")," folder."),(0,r.kt)("admonition",{title:"Pro-tip: Managing repository directories",type:"tip"},(0,r.kt)("p",{parentName:"admonition"},"You should put your repositories close to the root of the drive, so that they have much shorter and more manageable paths, like ",(0,r.kt)("inlineCode",{parentName:"p"},"D:\\sor-repos"),", ",(0,r.kt)("inlineCode",{parentName:"p"},"F:\\rim-repos")," (for Rimworld mods), ",(0,r.kt)("inlineCode",{parentName:"p"},"E:\\uni-repos")," (for university stuff) and etc. This way you'll always know the exact path to your projects, and all errors and warnings regarding the files will be much shorter and will contain less unnecessary information.")),(0,r.kt)("p",null,"Now let's see what this workspace has to offer!"),(0,r.kt)("h3",{id:"references"},(0,r.kt)("inlineCode",{parentName:"h3"},".ref")," - References"),(0,r.kt)("p",null,(0,r.kt)("inlineCode",{parentName:"p"},".ref")," directory will contain all of the references for your mods. There are two kinds of them:"),(0,r.kt)("p",null,(0,r.kt)("strong",{parentName:"p"},(0,r.kt)("em",{parentName:"strong"},"Static references"))," (that is, the ones that aren't updated frequently and mostly remain the same) are stored in the ",(0,r.kt)("inlineCode",{parentName:"p"},"static")," subdirectory. Most of the stuff that you can find in the ",(0,r.kt)("inlineCode",{parentName:"p"},"/StreetsOfRogue_Data/Managed")," directory goes here."),(0,r.kt)("img",{src:(0,a.Z)("/img/setup/ref-static.png"),width:"600"}),(0,r.kt)("p",null,(0,r.kt)("strong",{parentName:"p"},(0,r.kt)("em",{parentName:"strong"},"Dynamic references"))," (the ones that change often) are ",(0,r.kt)("inlineCode",{parentName:"p"},"Assembly-CSharp.dll")," (that contains the game code) and ",(0,r.kt)("inlineCode",{parentName:"p"},"RogueLibsCore.dll")," (RogueLibs library). They are stored in the ",(0,r.kt)("inlineCode",{parentName:"p"},".ref")," directory itself, so you can update them more easily."),(0,r.kt)("img",{src:(0,a.Z)("/img/setup/ref.png"),width:"600"}),(0,r.kt)("admonition",{title:"Pro-tip: Documentation files",type:"tip"},(0,r.kt)("p",{parentName:"admonition"},"Some references have documentation as a separate file, like ",(0,r.kt)("inlineCode",{parentName:"p"},"RogueLibsCore.xml"),". Make sure that you place it next to the .dll in the same folder. If you do, you'll be able to look up documentation on types and members right in Visual Studio!")),(0,r.kt)("h3",{id:"pluginbuildevents"},(0,r.kt)("inlineCode",{parentName:"h3"},".events")," - PluginBuildEvents"),(0,r.kt)("p",null,"PluginBuildEvents is a simple utility for copying your mods over to the BepInEx/plugins directory. The default project template includes it as a post-build event, so you just need to build your mod, and its file will be automatically moved!"),(0,r.kt)("admonition",{title:"Non-Steam versions of the game",type:"note"},(0,r.kt)("p",{parentName:"admonition"},"If you haven't purchased the Steam version of the game (or if you somehow messed up the Steam's installation path in the registry), then specify the full path to the game's root directory in the properties of your project (right-click on it in the Solution Explorer and select Properties > Build > Events):"),(0,r.kt)("pre",{parentName:"admonition"},(0,r.kt)("code",{parentName:"pre",className:"language-sh"},'"$(SolutionDir)\\..\\.events\\PluginBuildEvents.exe" "$(TargetPath)" "D:\\Games\\Streets of Rogue"\n'))),(0,r.kt)("h3",{id:"solution-folders"},"Solution Folders"),(0,r.kt)("p",null,"All other folders should contain solutions with your projects:"),(0,r.kt)("img",{src:(0,a.Z)("/img/setup/solutions.png"),width:"600"}),(0,r.kt)("p",null,"To create a new one, just copy-paste the template one. You can also modify the template to fit your specific needs."))}c.isMDXComponent=!0}}]);