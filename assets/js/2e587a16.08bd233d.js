"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[543],{3905:function(e,t,n){n.d(t,{Zo:function(){return c},kt:function(){return d}});var r=n(7294);function a(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function i(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(e);t&&(r=r.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,r)}return n}function o(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?i(Object(n),!0).forEach((function(t){a(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):i(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function s(e,t){if(null==e)return{};var n,r,a=function(e,t){if(null==e)return{};var n,r,a={},i=Object.keys(e);for(r=0;r<i.length;r++)n=i[r],t.indexOf(n)>=0||(a[n]=e[n]);return a}(e,t);if(Object.getOwnPropertySymbols){var i=Object.getOwnPropertySymbols(e);for(r=0;r<i.length;r++)n=i[r],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(a[n]=e[n])}return a}var l=r.createContext({}),u=function(e){var t=r.useContext(l),n=t;return e&&(n="function"==typeof e?e(t):o(o({},t),e)),n},c=function(e){var t=u(e.components);return r.createElement(l.Provider,{value:t},e.children)},p={inlineCode:"code",wrapper:function(e){var t=e.children;return r.createElement(r.Fragment,{},t)}},m=r.forwardRef((function(e,t){var n=e.components,a=e.mdxType,i=e.originalType,l=e.parentName,c=s(e,["components","mdxType","originalType","parentName"]),m=u(n),d=a,f=m["".concat(l,".").concat(d)]||m[d]||p[d]||i;return n?r.createElement(f,o(o({ref:t},c),{},{components:n})):r.createElement(f,o({ref:t},c))}));function d(e,t){var n=arguments,a=t&&t.mdxType;if("string"==typeof e||a){var i=n.length,o=new Array(i);o[0]=m;var s={};for(var l in t)hasOwnProperty.call(t,l)&&(s[l]=t[l]);s.originalType=e,s.mdxType="string"==typeof e?e:a,o[1]=s;for(var u=2;u<i;u++)o[u]=n[u];return r.createElement.apply(null,o)}return r.createElement.apply(null,n)}m.displayName="MDXCreateElement"},1016:function(e,t,n){n.d(t,{Z:function(){return s}});var r=n(7462),a=n(3366),i=n(7294),o=["children"];function s(e){var t=e.children,n=(0,a.Z)(e,o);return i.createElement("div",(0,r.Z)({role:"tabpanel"},n),t)}},250:function(e,t,n){n.d(t,{Z:function(){return p}});var r=n(7294),a=n(5773),i=n(6010),o="tabItem_V91s",s="tabItemActive_JsUu",l="tab_ntnM";var u=37,c=39;function p(e){var t=e.lazy,n=e.defaultValue,p=e.values,m=e.groupId,d=(0,a.UB)(),f=d.tabGroupChoices,h=d.setTabGroupChoices,g=(0,r.useState)(n),v=g[0],k=g[1],y=r.Children.toArray(e.children),b=[];if(null!=m){var N=f[m];null!=N&&N!==v&&p.some((function(e){return e.value===N}))&&k(N)}var w=function(e){var t=e.currentTarget,n=b.indexOf(t),r=p[n].value;k(r),null!=m&&(h(m,r),setTimeout((function(){var e,n,r,a,i,o,l,u;(e=t.getBoundingClientRect(),n=e.top,r=e.left,a=e.bottom,i=e.right,o=window,l=o.innerHeight,u=o.innerWidth,n>=0&&i<=u&&a<=l&&r>=0)||(t.scrollIntoView({block:"center",behavior:"smooth"}),t.classList.add(s),setTimeout((function(){return t.classList.remove(s)}),2e3))}),150))},C=function(e){var t;switch(e.keyCode){case c:var n=b.indexOf(e.target)+1;t=b[n]||b[0];break;case u:var r=b.indexOf(e.target)-1;t=b[r]||b[b.length-1];break;default:return}t.focus()},S=function(e,t){return t.value===e||t.values&&-1!=t.values.indexOf(e)};return r.createElement("div",{className:"tabs-container"},r.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:"tabs"},p.map((function(e){var t=e.value,n=e.label;return r.createElement("li",{role:"tab",tabIndex:v===t?0:-1,"aria-selected":v===t,className:(0,i.Z)("tabs__item",o,{"tabs__item--active":v===t}),key:t,ref:function(e){return e&&b.push(e)},onKeyDown:C,onFocus:w,onClick:w},n)}))),t?r.cloneElement(y.find((function(e){return S(v,e.props)})),{className:l}):r.createElement("div",null,y.map((function(e,t){return r.cloneElement(e,{key:t,hidden:!S(v,e.props),className:l})}))),r.createElement("br",null))}},1904:function(e,t,n){n.r(t),n.d(t,{frontMatter:function(){return l},contentTitle:function(){return u},metadata:function(){return c},toc:function(){return p},default:function(){return d}});var r=n(7462),a=n(3366),i=(n(7294),n(3905)),o=(n(250),n(1016),n(4996)),s=["components"],l={},u="Custom Sprites and Resources",c={unversionedId:"dev/custom-sprites",id:"dev/custom-sprites",title:"Custom Sprites and Resources",description:"Adding binary resources",source:"@site/docs/dev/custom-sprites.mdx",sourceDirName:"dev",slug:"/dev/custom-sprites",permalink:"/RogueLibs/docs/dev/custom-sprites",editUrl:"https://github.com/SugarBarrel/RogueLibs/edit/main/website/docs/dev/custom-sprites.mdx",tags:[],version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"Custom Name Providers",permalink:"/RogueLibs/docs/dev/names/name-providers"},next:{title:"Extra Stuff",permalink:"/RogueLibs/docs/dev/extra"}},p=[{value:"Adding binary resources",id:"binary-resources",children:[],level:2},{value:"<code>RogueSprite</code>",id:"roguesprite",children:[],level:2},{value:"Sprite variations",id:"sprite-variations",children:[],level:2}],m={toc:p};function d(e){var t=e.components,n=(0,a.Z)(e,s);return(0,i.kt)("wrapper",(0,r.Z)({},m,n,{components:t,mdxType:"MDXLayout"}),(0,i.kt)("h1",{id:"custom-sprites-and-resources"},"Custom Sprites and Resources"),(0,i.kt)("h2",{id:"binary-resources"},"Adding binary resources"),(0,i.kt)("p",null,"First of all, encode your images in PNG or JPG format, and audioclips in MP3, OGG or WAV."),(0,i.kt)("p",null,"Then go to your project's Properties and create a resource file, if it doesn't exist already."),(0,i.kt)("img",{src:(0,o.Z)("/img/setup/resources.png"),width:"600"}),(0,i.kt)("p",null,"Open your project's ",(0,i.kt)("inlineCode",{parentName:"p"},"Resources.resx")," in an ",(0,i.kt)("strong",{parentName:"p"},"external")," editor and add the following element to the end:"),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-xml"},'  \x3c!-- ... --\x3e\n// highlight-start\n  <data name="MyAwesomeSprite" type="System.Resources.ResXFileRef, System.Windows.Forms">\n    <value>..\\Resources\\MyAwesomeSprite.png;System.Byte[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>\n  </data>\n// highlight-end\n</root>\n')),(0,i.kt)("p",null,"You only need to change the ",(0,i.kt)("inlineCode",{parentName:"p"},"name")," attribute and the first part of the ",(0,i.kt)("inlineCode",{parentName:"p"},"value")," element for your resources. Then you should be able to reference them like this: ",(0,i.kt)("inlineCode",{parentName:"p"},"Properties.Resources.MyAwesomeSprite"),". You can do the same thing with other types of files as well, like audioclips, fonts and models."),(0,i.kt)("div",{className:"admonition admonition-info alert alert--info"},(0,i.kt)("div",{parentName:"div",className:"admonition-heading"},(0,i.kt)("h5",{parentName:"div"},(0,i.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,i.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,i.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M7 2.3c3.14 0 5.7 2.56 5.7 5.7s-2.56 5.7-5.7 5.7A5.71 5.71 0 0 1 1.3 8c0-3.14 2.56-5.7 5.7-5.7zM7 1C3.14 1 0 4.14 0 8s3.14 7 7 7 7-3.14 7-7-3.14-7-7-7zm1 3H6v5h2V4zm0 6H6v2h2v-2z"}))),"info")),(0,i.kt)("div",{parentName:"div",className:"admonition-content"},(0,i.kt)("p",{parentName:"div"},"If you can't reference it right after adding it, try adding a simple string resource to the ",(0,i.kt)("inlineCode",{parentName:"p"},"Resources.resx")," using Visual Studio's default resources editor and then deleting it, or renaming an existing resource, saving, and then renaming it back."))),(0,i.kt)("h2",{id:"roguesprite"},(0,i.kt)("inlineCode",{parentName:"h2"},"RogueSprite")),(0,i.kt)("div",{className:"admonition admonition-note alert alert--secondary"},(0,i.kt)("div",{parentName:"div",className:"admonition-heading"},(0,i.kt)("h5",{parentName:"div"},(0,i.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,i.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,i.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.3 5.69a.942.942 0 0 1-.28-.7c0-.28.09-.52.28-.7.19-.18.42-.28.7-.28.28 0 .52.09.7.28.18.19.28.42.28.7 0 .28-.09.52-.28.7a1 1 0 0 1-.7.3c-.28 0-.52-.11-.7-.3zM8 7.99c-.02-.25-.11-.48-.31-.69-.2-.19-.42-.3-.69-.31H6c-.27.02-.48.13-.69.31-.2.2-.3.44-.31.69h1v3c.02.27.11.5.31.69.2.2.42.31.69.31h1c.27 0 .48-.11.69-.31.2-.19.3-.42.31-.69H8V7.98v.01zM7 2.3c-3.14 0-5.7 2.54-5.7 5.68 0 3.14 2.56 5.7 5.7 5.7s5.7-2.55 5.7-5.7c0-3.15-2.56-5.69-5.7-5.69v.01zM7 .98c3.86 0 7 3.14 7 7s-3.14 7-7 7-7-3.12-7-7 3.14-7 7-7z"}))),"note")),(0,i.kt)("div",{parentName:"div",className:"admonition-content"},(0,i.kt)("p",{parentName:"div"},"If you're wondering, why it's called ",(0,i.kt)("inlineCode",{parentName:"p"},"RogueSprite")," and not ",(0,i.kt)("inlineCode",{parentName:"p"},"CustomSprite"),", like most of the things in RogueLibs (",(0,i.kt)("inlineCode",{parentName:"p"},"CustomItem"),", ",(0,i.kt)("inlineCode",{parentName:"p"},"CustomTrait"),", ",(0,i.kt)("inlineCode",{parentName:"p"},"CustomEffect"),"), well, that's because it behaves slightly differently from others. ",(0,i.kt)("inlineCode",{parentName:"p"},"CustomItem"),", ",(0,i.kt)("inlineCode",{parentName:"p"},"CustomTrait")," and etc. are hooks, while ",(0,i.kt)("inlineCode",{parentName:"p"},"RogueSprite"),", technically, is a collection of hooks. Also, it took an incredible amount of time and work to figure out that TK2D stuff and I just wanted to distinguish it from other classes."))),(0,i.kt)("p",null,"Normally, new instances of ",(0,i.kt)("inlineCode",{parentName:"p"},"RogueSprite")," are created like this:"),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-csharp"},"RogueLibs.CreateCustomItem<MyCustomItem>()\n    ...\n    // highlight-next-line\n    .WithSprite(Properties.Resources.MyCustomItem);\n")),(0,i.kt)("p",null,"But you can create them directly too, although you'll have to specify a name and a scope. Scope of the sprite determines what areas of the game the sprite will be available in. ",(0,i.kt)("inlineCode",{parentName:"p"},"SpriteScope.Items")," will work only on items, ",(0,i.kt)("inlineCode",{parentName:"p"},"SpriteScope.Objects")," - only on objects, and etc. You can specify multiple scopes too by combining them with ",(0,i.kt)("inlineCode",{parentName:"p"},"|")," operator."),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-csharp"},'RogueLibs.CreateCustomSprite("name", SpriteScope.Items, Properties.Resources.ResourceName);\n')),(0,i.kt)("p",null,"By default, RogueLibs uses the entire file as a texture. You can specify the region of the texture to use with a ",(0,i.kt)("inlineCode",{parentName:"p"},"Rect")," parameter (for example, if you included a color palette used in the image by its side and don't want to include it):"),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-csharp"},'RogueLibs.CreateCustom("name", SpriteScope.Items, Properties.Resources.ResourceName,\n                                // highlight-next-line\n                                new Rect(0f, 0f, 64f, 64f));\n')),(0,i.kt)("p",null,"If you're going to use non-64x64 textures, then you need to specify the PPU (pixels-per-unit) parameter too:"),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-csharp"},'RogueLibs.CreateCustom("name", SpriteScope.Items, Properties.Resources.ResourceName,\n                                // highlight-next-line\n                                new Rect(64f, 64f, 128f, 128f), 128f);\n')),(0,i.kt)("h2",{id:"sprite-variations"},"Sprite variations"),(0,i.kt)("p",null,"If you have more than 1 sprite for your item, use ",(0,i.kt)("inlineCode",{parentName:"p"},"InvItem.LoadItemSprite")," in your item's ",(0,i.kt)("inlineCode",{parentName:"p"},"SetupDetails"),":"),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-csharp"},'public class Present : CustomItem, IItemUsable\n{\n    [RLSetup]\n    public static void Setup()\n    {\n        RogueLibs.CreateCustomItem<Present>()\n            /* ... */\n            .WithSprite(Properties.Resources.Present);\n\n        RogueLibs.CreateCustomSprite("Present2", SpriteScope.Items, Properties.Resources.Present2);\n        RogueLibs.CreateCustomSprite("Present3", SpriteScope.Items, Properties.Resources.Present3);\n    }\n\n    public override void SetupDetails()\n    {\n        /* ... */\n        int rnd = new Random().Next(3) + 1;\n        // random integer x, such that 1 \u2264 x \u2264 3\n\n        if (rnd != 1) // load a different sprite if it\'s 2 or 3\n            Item.LoadItemSprite($"Present{rnd}");\n\n        // if it\'s 1, then the default "Present" will be used\n    }\n}\n')),(0,i.kt)("p",null,"This example works only if an item actually exists. In the Loadout and Rewards menus it will always have the ",(0,i.kt)("inlineCode",{parentName:"p"},"Present")," sprite. If you want the sprite in the menus to be randomly selected too, you'll have to ",(0,i.kt)("a",{parentName:"p",href:"./unlocks/overriding-behavior#examples"},"override the ",(0,i.kt)("inlineCode",{parentName:"a"},"DisplayedUnlock.GetImage")," method"),"."))}d.isMDXComponent=!0}}]);