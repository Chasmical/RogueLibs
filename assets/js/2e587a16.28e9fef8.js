"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[543],{3905:function(e,t,n){n.d(t,{Zo:function(){return p},kt:function(){return d}});var a=n(7294);function r(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function i(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var a=Object.getOwnPropertySymbols(e);t&&(a=a.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,a)}return n}function o(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?i(Object(n),!0).forEach((function(t){r(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):i(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function s(e,t){if(null==e)return{};var n,a,r=function(e,t){if(null==e)return{};var n,a,r={},i=Object.keys(e);for(a=0;a<i.length;a++)n=i[a],t.indexOf(n)>=0||(r[n]=e[n]);return r}(e,t);if(Object.getOwnPropertySymbols){var i=Object.getOwnPropertySymbols(e);for(a=0;a<i.length;a++)n=i[a],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(r[n]=e[n])}return r}var c=a.createContext({}),l=function(e){var t=a.useContext(c),n=t;return e&&(n="function"==typeof e?e(t):o(o({},t),e)),n},p=function(e){var t=l(e.components);return a.createElement(c.Provider,{value:t},e.children)},u={inlineCode:"code",wrapper:function(e){var t=e.children;return a.createElement(a.Fragment,{},t)}},m=a.forwardRef((function(e,t){var n=e.components,r=e.mdxType,i=e.originalType,c=e.parentName,p=s(e,["components","mdxType","originalType","parentName"]),m=l(n),d=r,h=m["".concat(c,".").concat(d)]||m[d]||u[d]||i;return n?a.createElement(h,o(o({ref:t},p),{},{components:n})):a.createElement(h,o({ref:t},p))}));function d(e,t){var n=arguments,r=t&&t.mdxType;if("string"==typeof e||r){var i=n.length,o=new Array(i);o[0]=m;var s={};for(var c in t)hasOwnProperty.call(t,c)&&(s[c]=t[c]);s.originalType=e,s.mdxType="string"==typeof e?e:r,o[1]=s;for(var l=2;l<i;l++)o[l]=n[l];return a.createElement.apply(null,o)}return a.createElement.apply(null,n)}m.displayName="MDXCreateElement"},1016:function(e,t,n){n.d(t,{Z:function(){return s}});var a=n(7462),r=n(3366),i=n(7294),o=["children"];function s(e){var t=e.children,n=(0,r.Z)(e,o);return i.createElement("div",(0,a.Z)({role:"tabpanel"},n),t)}},2099:function(e,t,n){n.d(t,{Z:function(){return m}});var a=n(7294),r=n(9443);var i=function(){var e=(0,a.useContext)(r.Z);if(null==e)throw new Error('"useUserPreferencesContext" is used outside of "Layout" component.');return e},o=n(6010),s="tabItem_OdQc",c="tabItemActive_YQWB",l="tab_tgHH";var p=37,u=39;function m(e){var t=e.lazy,n=e.defaultValue,r=e.values,m=e.groupId,d=i(),h=d.tabGroupChoices,v=d.setTabGroupChoices,f=(0,a.useState)(n),g=f[0],k=f[1],N=a.Children.toArray(e.children),b=[];if(null!=m){var y=h[m];null!=y&&y!==g&&r.some((function(e){return e.value===y}))&&k(y)}var w=function(e){var t=e.currentTarget,n=b.indexOf(t),a=r[n].value;k(a),null!=m&&(v(m,a),setTimeout((function(){var e,n,a,r,i,o,s,l;(e=t.getBoundingClientRect(),n=e.top,a=e.left,r=e.bottom,i=e.right,o=window,s=o.innerHeight,l=o.innerWidth,n>=0&&i<=l&&r<=s&&a>=0)||(t.scrollIntoView({block:"center",behavior:"smooth"}),t.classList.add(c),setTimeout((function(){return t.classList.remove(c)}),2e3))}),150))},C=function(e){var t;switch(e.keyCode){case u:var n=b.indexOf(e.target)+1;t=b[n]||b[0];break;case p:var a=b.indexOf(e.target)-1;t=b[a]||b[b.length-1];break;default:return}t.focus()},S=function(e,t){return t.value===e||t.values&&-1!=t.values.indexOf(e)};return a.createElement("div",{className:"tabs-container"},a.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:"tabs"},r.map((function(e){var t=e.value,n=e.label;return a.createElement("li",{role:"tab",tabIndex:g===t?0:-1,"aria-selected":g===t,className:(0,o.Z)("tabs__item",s,{"tabs__item--active":g===t}),key:t,ref:function(e){return e&&b.push(e)},onKeyDown:C,onFocus:w,onClick:w},n)}))),t?a.cloneElement(N.find((function(e){return S(g,e.props)})),{className:l}):a.createElement("div",null,N.map((function(e,t){return a.cloneElement(e,{key:t,hidden:!S(g,e.props),className:l})}))),a.createElement("br",null))}},1904:function(e,t,n){n.r(t),n.d(t,{frontMatter:function(){return c},contentTitle:function(){return l},metadata:function(){return p},toc:function(){return u},default:function(){return d}});var a=n(7462),r=n(3366),i=(n(7294),n(3905)),o=(n(2099),n(1016),n(4996)),s=["components"],c={},l="Custom Sprites",p={unversionedId:"dev/custom-sprites",id:"dev/custom-sprites",title:"Custom Sprites",description:"Adding sprites as resources",source:"@site/docs/dev/custom-sprites.mdx",sourceDirName:"dev",slug:"/dev/custom-sprites",permalink:"/RogueLibs/docs/dev/custom-sprites",editUrl:"https://github.com/Abbysssal/RogueLibs/edit/main/website/docs/dev/custom-sprites.mdx",tags:[],version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"Custom Name Providers",permalink:"/RogueLibs/docs/dev/names/name-providers"},next:{title:"Extra Stuff",permalink:"/RogueLibs/docs/dev/extra"}},u=[{value:"Adding sprites as resources",id:"sprites-as-resources",children:[],level:2},{value:"<code>RogueSprite</code>",id:"roguesprite",children:[],level:2},{value:"Sprite variations",id:"sprite-variations",children:[],level:2}],m={toc:u};function d(e){var t=e.components,n=(0,r.Z)(e,s);return(0,i.kt)("wrapper",(0,a.Z)({},m,n,{components:t,mdxType:"MDXLayout"}),(0,i.kt)("h1",{id:"custom-sprites"},"Custom Sprites"),(0,i.kt)("h2",{id:"sprites-as-resources"},"Adding sprites as resources"),(0,i.kt)("p",null,"First of all, get your sprites and convert them to PNG or JPEG, if they're not already PNG- or JPEG-encoded."),(0,i.kt)("p",null,"Then, change the files' extensions to ",(0,i.kt)("inlineCode",{parentName:"p"},".bin"),". This way Visual Studio will recognize the files as binary data instead of bitmaps."),(0,i.kt)("div",{className:"admonition admonition-note alert alert--secondary"},(0,i.kt)("div",{parentName:"div",className:"admonition-heading"},(0,i.kt)("h5",{parentName:"div"},(0,i.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,i.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,i.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.3 5.69a.942.942 0 0 1-.28-.7c0-.28.09-.52.28-.7.19-.18.42-.28.7-.28.28 0 .52.09.7.28.18.19.28.42.28.7 0 .28-.09.52-.28.7a1 1 0 0 1-.7.3c-.28 0-.52-.11-.7-.3zM8 7.99c-.02-.25-.11-.48-.31-.69-.2-.19-.42-.3-.69-.31H6c-.27.02-.48.13-.69.31-.2.2-.3.44-.31.69h1v3c.02.27.11.5.31.69.2.2.42.31.69.31h1c.27 0 .48-.11.69-.31.2-.19.3-.42.31-.69H8V7.98v.01zM7 2.3c-3.14 0-5.7 2.54-5.7 5.68 0 3.14 2.56 5.7 5.7 5.7s5.7-2.55 5.7-5.7c0-3.15-2.56-5.69-5.7-5.69v.01zM7 .98c3.86 0 7 3.14 7 7s-3.14 7-7 7-7-3.12-7-7 3.14-7 7-7z"}))),"note")),(0,i.kt)("div",{parentName:"div",className:"admonition-content"},(0,i.kt)("p",{parentName:"div"},"Unfortunately, we can't import images from bitmaps, because Unity's System.Drawing.dll is just filled with stubs. So, we'll have to import images as binary data, until someone finds a better solution."))),(0,i.kt)("div",{className:"admonition admonition-note alert alert--secondary"},(0,i.kt)("div",{parentName:"div",className:"admonition-heading"},(0,i.kt)("h5",{parentName:"div"},(0,i.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,i.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,i.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.3 5.69a.942.942 0 0 1-.28-.7c0-.28.09-.52.28-.7.19-.18.42-.28.7-.28.28 0 .52.09.7.28.18.19.28.42.28.7 0 .28-.09.52-.28.7a1 1 0 0 1-.7.3c-.28 0-.52-.11-.7-.3zM8 7.99c-.02-.25-.11-.48-.31-.69-.2-.19-.42-.3-.69-.31H6c-.27.02-.48.13-.69.31-.2.2-.3.44-.31.69h1v3c.02.27.11.5.31.69.2.2.42.31.69.31h1c.27 0 .48-.11.69-.31.2-.19.3-.42.31-.69H8V7.98v.01zM7 2.3c-3.14 0-5.7 2.54-5.7 5.68 0 3.14 2.56 5.7 5.7 5.7s5.7-2.55 5.7-5.7c0-3.15-2.56-5.69-5.7-5.69v.01zM7 .98c3.86 0 7 3.14 7 7s-3.14 7-7 7-7-3.12-7-7 3.14-7 7-7z"}))),"note")),(0,i.kt)("div",{parentName:"div",className:"admonition-content"},(0,i.kt)("p",{parentName:"div"},"Screenshot needed (/img/custom-sprites/rename-bin.png)"))),(0,i.kt)("p",null,"Right-click on your project, go a-a-all the way down and click ",(0,i.kt)("strong",{parentName:"p"},"Properties"),":"),(0,i.kt)("img",{src:(0,o.Z)("/img/custom-sprites/project-properties.png"),width:"300"}),(0,i.kt)("p",null,"Go to ",(0,i.kt)("strong",{parentName:"p"},"Resources")," tab and click on ",(0,i.kt)("em",{parentName:"p"},"that")," button to create a resources file:"),(0,i.kt)("img",{src:(0,o.Z)("/img/custom-sprites/create-resources.png"),width:"800"}),(0,i.kt)("p",null,"Select ",(0,i.kt)("strong",{parentName:"p"},"Add resource")," at the top of the menu and click ",(0,i.kt)("strong",{parentName:"p"},"Add Existing File..."),":"),(0,i.kt)("img",{src:(0,o.Z)("/img/custom-sprites/add-resources.png"),width:"600"}),(0,i.kt)("p",null,"Now just find your images (with ",(0,i.kt)("inlineCode",{parentName:"p"},".bin")," extension) and add them as resources:"),(0,i.kt)("div",{className:"admonition admonition-note alert alert--secondary"},(0,i.kt)("div",{parentName:"div",className:"admonition-heading"},(0,i.kt)("h5",{parentName:"div"},(0,i.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,i.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,i.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.3 5.69a.942.942 0 0 1-.28-.7c0-.28.09-.52.28-.7.19-.18.42-.28.7-.28.28 0 .52.09.7.28.18.19.28.42.28.7 0 .28-.09.52-.28.7a1 1 0 0 1-.7.3c-.28 0-.52-.11-.7-.3zM8 7.99c-.02-.25-.11-.48-.31-.69-.2-.19-.42-.3-.69-.31H6c-.27.02-.48.13-.69.31-.2.2-.3.44-.31.69h1v3c.02.27.11.5.31.69.2.2.42.31.69.31h1c.27 0 .48-.11.69-.31.2-.19.3-.42.31-.69H8V7.98v.01zM7 2.3c-3.14 0-5.7 2.54-5.7 5.68 0 3.14 2.56 5.7 5.7 5.7s5.7-2.55 5.7-5.7c0-3.15-2.56-5.69-5.7-5.69v.01zM7 .98c3.86 0 7 3.14 7 7s-3.14 7-7 7-7-3.12-7-7 3.14-7 7-7z"}))),"note")),(0,i.kt)("div",{parentName:"div",className:"admonition-content"},(0,i.kt)("p",{parentName:"div"},"Screenshot needed (/img/custom-sprites/select-resources.png)"))),(0,i.kt)("p",null,"Now you should be able to reference your sprites' data from the code like this: ",(0,i.kt)("inlineCode",{parentName:"p"},"Properties.Resources.<ResourceName>"),"."),(0,i.kt)("div",{className:"admonition admonition-note alert alert--secondary"},(0,i.kt)("div",{parentName:"div",className:"admonition-heading"},(0,i.kt)("h5",{parentName:"div"},(0,i.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,i.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,i.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.3 5.69a.942.942 0 0 1-.28-.7c0-.28.09-.52.28-.7.19-.18.42-.28.7-.28.28 0 .52.09.7.28.18.19.28.42.28.7 0 .28-.09.52-.28.7a1 1 0 0 1-.7.3c-.28 0-.52-.11-.7-.3zM8 7.99c-.02-.25-.11-.48-.31-.69-.2-.19-.42-.3-.69-.31H6c-.27.02-.48.13-.69.31-.2.2-.3.44-.31.69h1v3c.02.27.11.5.31.69.2.2.42.31.69.31h1c.27 0 .48-.11.69-.31.2-.19.3-.42.31-.69H8V7.98v.01zM7 2.3c-3.14 0-5.7 2.54-5.7 5.68 0 3.14 2.56 5.7 5.7 5.7s5.7-2.55 5.7-5.7c0-3.15-2.56-5.69-5.7-5.69v.01zM7 .98c3.86 0 7 3.14 7 7s-3.14 7-7 7-7-3.12-7-7 3.14-7 7-7z"}))),"note")),(0,i.kt)("div",{parentName:"div",className:"admonition-content"},(0,i.kt)("p",{parentName:"div"},"If you get an error, then make sure that the default namespace, that is specified in project's properties in ",(0,i.kt)("strong",{parentName:"p"},"Application")," tab, is the same as the one you're using."))),(0,i.kt)("h2",{id:"roguesprite"},(0,i.kt)("inlineCode",{parentName:"h2"},"RogueSprite")),(0,i.kt)("div",{className:"admonition admonition-note alert alert--secondary"},(0,i.kt)("div",{parentName:"div",className:"admonition-heading"},(0,i.kt)("h5",{parentName:"div"},(0,i.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,i.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,i.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.3 5.69a.942.942 0 0 1-.28-.7c0-.28.09-.52.28-.7.19-.18.42-.28.7-.28.28 0 .52.09.7.28.18.19.28.42.28.7 0 .28-.09.52-.28.7a1 1 0 0 1-.7.3c-.28 0-.52-.11-.7-.3zM8 7.99c-.02-.25-.11-.48-.31-.69-.2-.19-.42-.3-.69-.31H6c-.27.02-.48.13-.69.31-.2.2-.3.44-.31.69h1v3c.02.27.11.5.31.69.2.2.42.31.69.31h1c.27 0 .48-.11.69-.31.2-.19.3-.42.31-.69H8V7.98v.01zM7 2.3c-3.14 0-5.7 2.54-5.7 5.68 0 3.14 2.56 5.7 5.7 5.7s5.7-2.55 5.7-5.7c0-3.15-2.56-5.69-5.7-5.69v.01zM7 .98c3.86 0 7 3.14 7 7s-3.14 7-7 7-7-3.12-7-7 3.14-7 7-7z"}))),"note")),(0,i.kt)("div",{parentName:"div",className:"admonition-content"},(0,i.kt)("p",{parentName:"div"},"If you're wondering, why it's called ",(0,i.kt)("inlineCode",{parentName:"p"},"RogueSprite")," and not ",(0,i.kt)("inlineCode",{parentName:"p"},"CustomSprite"),", like most of the things in RogueLibs (",(0,i.kt)("inlineCode",{parentName:"p"},"CustomItem"),", ",(0,i.kt)("inlineCode",{parentName:"p"},"CustomTrait"),", ",(0,i.kt)("inlineCode",{parentName:"p"},"CustomEffect"),"), well, that's because it behaves slightly differently from others. ",(0,i.kt)("inlineCode",{parentName:"p"},"CustomItem"),", ",(0,i.kt)("inlineCode",{parentName:"p"},"CustomTrait")," and etc. are hooks, while ",(0,i.kt)("inlineCode",{parentName:"p"},"RogueSprite"),", technically, is a collection of hooks. Also, it took an incredible amount of time and work to figure out that TK2D stuff and I just wanted to distinguish it from other classes."))),(0,i.kt)("p",null,"Normally, new instances of ",(0,i.kt)("inlineCode",{parentName:"p"},"RogueSprite")," are created like this:"),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-csharp"},"RogueLibs.CreateCustomItem<MyCustomItem>()\n    ...\n    // highlight-next-line\n    .WithSprite(Properties.Resources.MyCustomItem);\n")),(0,i.kt)("p",null,"But you can create them directly too, although you'll have to specify a name and a scope. Scope of the sprite determines what areas of the game the sprite will be available in. ",(0,i.kt)("inlineCode",{parentName:"p"},"SpriteScope.Items")," will work only on items, ",(0,i.kt)("inlineCode",{parentName:"p"},"SpriteScope.Objects")," - only on objects, and etc. You can specify multiple scopes too by combining them with ",(0,i.kt)("inlineCode",{parentName:"p"},"|")," operator."),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-csharp"},'RogueLibs.CreateCustomSprite("name", SpriteScope.Items, Properties.Resources.ResourceName);\n')),(0,i.kt)("p",null,"By default, RogueLibs uses the entire file as a texture. You can specify the region of the texture to use with a ",(0,i.kt)("inlineCode",{parentName:"p"},"Rect")," parameter:"),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-csharp"},'RogueLibs.CreateCustom("name", SpriteScope.Items, Properties.Resources.ResourceName,\n                                // highlight-next-line\n                                new Rect(32f, 32f, 64f, 64f));\n')),(0,i.kt)("p",null,"If you're going to use non-64x64 textures, then you need to specify the PPU (pixels-per-unit) parameter too:"),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-csharp"},'RogueLibs.CreateCustom("name", SpriteScope.Items, Properties.Resources.ResourceName,\n                                // highlight-next-line\n                                new Rect(64f, 64f, 128f, 128f), 128f);\n')),(0,i.kt)("h2",{id:"sprite-variations"},"Sprite variations"),(0,i.kt)("p",null,"If you have more than 1 sprite for your item, use ",(0,i.kt)("inlineCode",{parentName:"p"},"InvItem.LoadItemSprite")," in your item's ",(0,i.kt)("inlineCode",{parentName:"p"},"SetupDetails"),":"),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-csharp"},'public class Present : CustomItem, IItemUsable\n{\n    [RLSetup]\n    public static void Setup()\n    {\n        RogueLibs.CreateCustomItem<Present>()\n            /* ... */\n            .WithSprite(Properties.Resources.Present);\n\n        RogueLibs.CreateCustomSprite("Present2", SpriteScope.Items, Properties.Resources.Present2);\n        RogueLibs.CreateCustomSprite("Present3", SpriteScope.Items, Properties.Resources.Present3);\n    }\n\n    public override void SetupDetails()\n    {\n        /* ... */\n        int rnd = new Random().Next(3) + 1;\n        // random integer x, such that 1 \u2264 x \u2264 3\n\n        if (rnd != 1) // load a different sprite if it\'s 2 or 3\n            Item.LoadItemSprite($"Present{rnd}");\n\n        // if it\'s 1, then the default "Present" will be used\n    }\n}\n')),(0,i.kt)("p",null,"This example works only if an item actually exists. In the Loadout and Rewards menus it will always have the ",(0,i.kt)("inlineCode",{parentName:"p"},"Present")," sprite. If you want the sprite in the menus to be randomly selected too, you'll have to ",(0,i.kt)("a",{parentName:"p",href:"./unlocks/overriding-behavior#examples"},"override the ",(0,i.kt)("inlineCode",{parentName:"a"},"DisplayedUnlock.GetImage")," method"),"."))}d.isMDXComponent=!0}}]);