"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[241],{3905:function(e,t,a){a.d(t,{Zo:function(){return c},kt:function(){return g}});var n=a(7294);function l(e,t,a){return t in e?Object.defineProperty(e,t,{value:a,enumerable:!0,configurable:!0,writable:!0}):e[t]=a,e}function o(e,t){var a=Object.keys(e);if(Object.getOwnPropertySymbols){var n=Object.getOwnPropertySymbols(e);t&&(n=n.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),a.push.apply(a,n)}return a}function i(e){for(var t=1;t<arguments.length;t++){var a=null!=arguments[t]?arguments[t]:{};t%2?o(Object(a),!0).forEach((function(t){l(e,t,a[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(a)):o(Object(a)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(a,t))}))}return e}function r(e,t){if(null==e)return{};var a,n,l=function(e,t){if(null==e)return{};var a,n,l={},o=Object.keys(e);for(n=0;n<o.length;n++)a=o[n],t.indexOf(a)>=0||(l[a]=e[a]);return l}(e,t);if(Object.getOwnPropertySymbols){var o=Object.getOwnPropertySymbols(e);for(n=0;n<o.length;n++)a=o[n],t.indexOf(a)>=0||Object.prototype.propertyIsEnumerable.call(e,a)&&(l[a]=e[a])}return l}var s=n.createContext({}),u=function(e){var t=n.useContext(s),a=t;return e&&(a="function"==typeof e?e(t):i(i({},t),e)),a},c=function(e){var t=u(e.components);return n.createElement(s.Provider,{value:t},e.children)},m={inlineCode:"code",wrapper:function(e){var t=e.children;return n.createElement(n.Fragment,{},t)}},p=n.forwardRef((function(e,t){var a=e.components,l=e.mdxType,o=e.originalType,s=e.parentName,c=r(e,["components","mdxType","originalType","parentName"]),p=u(a),g=l,d=p["".concat(s,".").concat(g)]||p[g]||m[g]||o;return a?n.createElement(d,i(i({ref:t},c),{},{components:a})):n.createElement(d,i({ref:t},c))}));function g(e,t){var a=arguments,l=t&&t.mdxType;if("string"==typeof e||l){var o=a.length,i=new Array(o);i[0]=p;var r={};for(var s in t)hasOwnProperty.call(t,s)&&(r[s]=t[s]);r.originalType=e,r.mdxType="string"==typeof e?e:l,i[1]=r;for(var u=2;u<o;u++)i[u]=a[u];return n.createElement.apply(null,i)}return n.createElement.apply(null,a)}p.displayName="MDXCreateElement"},1108:function(e,t,a){a.r(t),a.d(t,{frontMatter:function(){return r},contentTitle:function(){return s},metadata:function(){return u},assets:function(){return c},toc:function(){return m},default:function(){return g}});var n=a(7462),l=a(3366),o=(a(7294),a(3905)),i=["components"],r={title:"RogueLibs v3.1.0 released!",author:"Abbysssal",author_title:"Creator of RogueLibs",author_url:"https://github.com/Abbysssal",author_image_url:"https://avatars.githubusercontent.com/u/55982389?height=200&width=200",tags:["roguelibs","release"],description:"Completely replaced the vanilla localization system.",image:"https://i.imgur.com/XaNGCx7.png",hide_table_of_contents:!1},s=void 0,u={permalink:"/RogueLibs/blog/2021/08/18/roguelibs-v3.1.0",editUrl:"https://github.com/SugarBarrel/RogueLibs/edit/main/website/blog/blog/2021-08-18-roguelibs-v3.1.0.md",source:"@site/blog/2021-08-18-roguelibs-v3.1.0.md",title:"RogueLibs v3.1.0 released!",description:"Completely replaced the vanilla localization system.",date:"2021-08-18T00:00:00.000Z",formattedDate:"August 18, 2021",tags:[{label:"roguelibs",permalink:"/RogueLibs/blog/tags/roguelibs"},{label:"release",permalink:"/RogueLibs/blog/tags/release"}],readingTime:2.9,truncated:!0,authors:[{name:"Abbysssal",title:"Creator of RogueLibs",url:"https://github.com/Abbysssal",imageURL:"https://avatars.githubusercontent.com/u/55982389?height=200&width=200"}],prevItem:{title:"What I hate about SoR",permalink:"/RogueLibs/blog/2021/08/31/what-i-hate-about-sor"}},c={authorsImageUrls:[void 0]},m=[{value:"Upgrading/downgrading to XML",id:"upgradingdowngrading-to-xml",children:[],level:3},{value:"Categorizing translations by language",id:"categorizing-translations-by-language",children:[],level:3},{value:"Automatic updates",id:"automatic-updates",children:[],level:3},{value:"Community translations",id:"community-translations",children:[],level:3},{value:"Live Reloading",id:"live-reloading",children:[],level:3}],p={toc:m};function g(e){var t=e.components,a=(0,l.Z)(e,i);return(0,o.kt)("wrapper",(0,n.Z)({},p,a,{components:t,mdxType:"MDXLayout"}),(0,o.kt)("p",null,"Today a new version of RogueLibs v3.1.0 was released!"),(0,o.kt)("p",null,"A brand new localization system will completely replace the vanilla one!"),(0,o.kt)("ul",null,(0,o.kt)("li",{parentName:"ul"},"Fancy, easy-to-use XML files, for each language separately;"),(0,o.kt)("li",{parentName:"ul"},'Fixed the bug with "E_" prefixes appearing in random places;'),(0,o.kt)("li",{parentName:"ul"},"Custom languages support;"),(0,o.kt)("li",{parentName:"ul"},"Community translations;"),(0,o.kt)("li",{parentName:"ul"},"Automatic updates;"),(0,o.kt)("li",{parentName:"ul"},"Live Reloading!")),(0,o.kt)("p",null,(0,o.kt)("img",{parentName:"p",src:"https://i.imgur.com/XaNGCx7.png",alt:"Locales opened in VSCode"})),(0,o.kt)("h3",{id:"upgradingdowngrading-to-xml"},"Upgrading/downgrading to XML"),(0,o.kt)("p",null,"On one hand, we lose some of th-, I mean, the ",(0,o.kt)("strong",{parentName:"p"},"one")," advantage of CSV files:"),(0,o.kt)("ul",null,(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("strong",{parentName:"li"},"Small size."),(0,o.kt)("br",{parentName:"li"}),"Not as compact, as physically possible, but still, it has a relatively low data-to-size ratio, close to 1. The only non-data characters are commas, the surrounding quotes, double quotes inside of expressions and new lines.")),(0,o.kt)("p",null,"But on the other hand, we gain a ton of advantages of XML:"),(0,o.kt)("ul",null,(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("strong",{parentName:"li"},"Easy to read."),(0,o.kt)("br",{parentName:"li"}),"Humans can open the file in a text editor, and it will automatically highlight the XML syntax.  "),(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("strong",{parentName:"li"},"Easy to edit."),(0,o.kt)("br",{parentName:"li"}),"Modern text editors check for errors in XML, making it almost impossible to corrupt the file."),(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("strong",{parentName:"li"},"Easy to parse."),(0,o.kt)("br",{parentName:"li"}),"Computers can easily parse XML files with the built-in ",(0,o.kt)("inlineCode",{parentName:"li"},"System.Xml.Serialization")," (in case of C#). There's no need for any overcomplicated regular expressions used in the game.")),(0,o.kt)("h3",{id:"categorizing-translations-by-language"},"Categorizing translations by language"),(0,o.kt)("p",null,"The vanilla game loads all languages at the same time, regardless of what language is selected."),(0,o.kt)("p",null,"RogueLibs will load only the ones, that are actually used: the selected one and the fallback one (default: English), that will be used in case an entry is missing in the selected language."),(0,o.kt)("p",null,"This loading strategy allows you to select from thousands of different localizations, without loading all of them at the same time."),(0,o.kt)("h3",{id:"automatic-updates"},"Automatic updates"),(0,o.kt)("p",null,"When you launch the game, RogueLibs will download a small \"index\" file with some metadata, and then it will decide what translations should be updated. Don't worry, it won't check for updates too frequently, just once every hour."),(0,o.kt)("h3",{id:"community-translations"},"Community translations"),(0,o.kt)("p",null,"Speaking of translations... ",(0,o.kt)("strong",{parentName:"p"},"The vanilla translations are terrible"),". I'm not sure what the situation is like with other languages, but russian localization is really bad:"),(0,o.kt)("ul",null,(0,o.kt)("li",{parentName:"ul"},'Some words are taken out of context. "Glass", as in "a glass wall", not as in "a glass of milk".'),(0,o.kt)("li",{parentName:"ul"},'"Chunk Pack" was literally translated as a "pack" of "chunks". I\'m not sure how to explain that, but it caused quite a lot of comotion in the russian community.'),(0,o.kt)("li",{parentName:"ul"},'Some words are not translated at all. "Walkie-Talkie" is still a "Walkie-Talkie". What kind of translator were they even using? Every online translator I could find translated it correctly.'),(0,o.kt)("li",{parentName:"ul"},"Some translation lines were shifted a couple of lines up or down, for some reason. As if someone was editing it in Excel."),(0,o.kt)("li",{parentName:"ul"},'There was also a ton of different styles. Sometimes "\u2014" was used instead of "-", "\u2026" instead of "..." and stuff like that. As if there were at least 3 different translators, one using Word, other one - Excel and another one - Notepad.'),(0,o.kt)("li",{parentName:"ul"},'"Monkey Barrel" \u2192 "\u041e\u0431\u0435\u0437\u044c\u044f\u043d\u0430 \u0431\u0430\u0440\u0440\u0435\u043b\u044c". What the f',"*","*","*","."),(0,o.kt)("li",{parentName:"ul"},"I spent about 2 days, working from morning to night, to fix all of that.")),(0,o.kt)("p",null,"And that's why RogueLibs will use community translations instead of official ones."),(0,o.kt)("p",null,"Feel free to contribute by checking the localization files yourself and making any necessary changes. The localization files are located ",(0,o.kt)("a",{parentName:"p",href:"https://github.com/Abbysssal/RogueLibs/tree/main/RogueLibsCore/Resources"},"in here"),". See more info on contributing to the project ",(0,o.kt)("a",{parentName:"p",href:"https://github.com/Abbysssal/RogueLibs/blob/main/.github/CONTRIBUTING.md"},"here"),"."),(0,o.kt)("h3",{id:"live-reloading"},"Live Reloading"),(0,o.kt)("p",null,"When you edit the localization files, the changes are reflected in the game immediately! Neat!"))}g.isMDXComponent=!0}}]);