"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[5466],{7406:(e,t,n)=>{n.r(t),n.d(t,{assets:()=>l,contentTitle:()=>i,default:()=>c,frontMatter:()=>a,metadata:()=>r,toc:()=>d});var o=n(5893),s=n(1151);const a={title:"What I hate about SoR",author:"Abbysssal",author_title:"Creator of RogueLibs",author_url:"https://github.com/Chasmical",author_image_url:"https://github.com/Chasmical.png",tags:["blog","modding","sor","sor2"],description:"The code is really hard and wet."},i=void 0,r={permalink:"/RogueLibs/ru/blog/2021/08/31/what-i-hate-about-sor",source:"@site/blog/2021-08-31/what-i-hate-about-sor.md",title:"What I hate about SoR",description:"The code is really hard and wet.",date:"2021-08-31T00:00:00.000Z",formattedDate:"31 \u0430\u0432\u0433\u0443\u0441\u0442\u0430 2021 \u0433.",tags:[{label:"blog",permalink:"/RogueLibs/ru/blog/tags/blog"},{label:"modding",permalink:"/RogueLibs/ru/blog/tags/modding"},{label:"sor",permalink:"/RogueLibs/ru/blog/tags/sor"},{label:"sor2",permalink:"/RogueLibs/ru/blog/tags/sor-2"}],readingTime:5.988888888888889,hasTruncateMarker:!0,authors:[{name:"Abbysssal",title:"Creator of RogueLibs",url:"https://github.com/Chasmical",imageURL:"https://github.com/Chasmical.png"}],frontMatter:{title:"What I hate about SoR",author:"Abbysssal",author_title:"Creator of RogueLibs",author_url:"https://github.com/Chasmical",author_image_url:"https://github.com/Chasmical.png",tags:["blog","modding","sor","sor2"],description:"The code is really hard and wet."},unlisted:!1,prevItem:{title:"RogueLibs v3.5.0-beta",permalink:"/RogueLibs/ru/blog/2022/01/30/roguelibs-v3.5.0-beta"},nextItem:{title:"RogueLibs v3.1.0",permalink:"/RogueLibs/ru/blog/2021/08/18/roguelibs-v3.1.0"}},l={authorsImageUrls:[void 0]},d=[{value:"The code is really hard and wet",id:"the-code-is-really-hard-and-wet",level:2},{value:"Global namespace",id:"global-namespace",level:3},{value:"A lot of unused types and members",id:"a-lot-of-unused-types-and-members",level:3},{value:"Bad names",id:"bad-names",level:3},{value:"Too many string comparisons",id:"too-many-string-comparisons",level:3},{value:"Empty strings",id:"empty-strings",level:3},{value:"Non-flexible mechanics",id:"non-flexible-mechanics",level:3},{value:"Hard code",id:"hard-code",level:3},{value:"Toolkit 2D library",id:"toolkit-2d-library",level:3},{value:"Disregard of common programming principles",id:"disregard-of-common-programming-principles",level:3},{value:"Binary serialization",id:"binary-serialization",level:3},{value:"Classes are used like structs",id:"classes-are-used-like-structs",level:3},{value:"Lack of properties",id:"lack-of-properties",level:3},{value:"Virtual methods",id:"virtual-methods",level:3},{value:"Lack of events",id:"lack-of-events",level:3},{value:"Giant <code>for</code> loops",id:"giant-for-loops",level:3},{value:"Conclusion",id:"conclusion",level:2}];function h(e){const t={a:"a",br:"br",code:"code",del:"del",em:"em",h2:"h2",h3:"h3",img:"img",p:"p",strong:"strong",...(0,s.a)(),...e.components};return(0,o.jsxs)(o.Fragment,{children:[(0,o.jsx)(t.h2,{id:"the-code-is-really-hard-and-wet",children:"The code is really hard and wet"}),"\n",(0,o.jsxs)(t.p,{children:[".. Wait- No! I mean that the game is really ",(0,o.jsx)(t.strong,{children:"hard"}),"coded! And the code is very ",(0,o.jsx)(t.strong,{children:"WET"})," - it's the opposite of the DRY (Don't Repeat Yourself) principle... It's pretty funny to say that though."]}),"\n",(0,o.jsx)(t.p,{children:"So, anyways, I decided to make a list of things that I hate about modding Streets of Rogue:"}),"\n",(0,o.jsx)(t.h3,{id:"global-namespace",children:"Global namespace"}),"\n",(0,o.jsx)(t.p,{children:"The first annoying thing that you notice, when you take a brief look into SoR modding, is that all of the game's types are in the global namespace. There's a couple of exceptions, though that's probably from the copy-pasted code."}),"\n",(0,o.jsx)(t.p,{children:(0,o.jsx)(t.img,{src:"https://imgur.com/HYDcvxx.png",alt:"Global namespace (dnSpy)"})}),"\n",(0,o.jsxs)(t.p,{children:["I mean, come on, just organize stuff in namespaces! Like ",(0,o.jsx)(t.code,{children:"StreetsOfRogue"})," for main stuff, ",(0,o.jsx)(t.code,{children:"StreetsOfRogue.LevelGeneration"})," for stuff related to level generation, ",(0,o.jsx)(t.code,{children:"StreetsOfRogue.Objects"})," for all classes derived from ",(0,o.jsx)(t.code,{children:"ObjectReal"})," and etc."]}),"\n",(0,o.jsx)(t.h3,{id:"a-lot-of-unused-types-and-members",children:"A lot of unused types and members"}),"\n",(0,o.jsx)(t.p,{children:"There's a lot of stuff, that's not used in the game at all. Some part of it is just some test code. The other part - is not related to Streets of Rogue at all, and probably was copy-pasted from somewhere else."}),"\n",(0,o.jsxs)(t.p,{children:[(0,o.jsx)(t.img,{src:"https://imgur.com/XNeeF8Q.png",alt:"A lot of unused types"}),"\n",(0,o.jsx)(t.img,{src:"https://imgur.com/REhaTil.png",alt:"3 unused fields in Agent class"})]}),"\n",(0,o.jsx)(t.h3,{id:"bad-names",children:"Bad names"}),"\n",(0,o.jsxs)(t.p,{children:[(0,o.jsx)(t.del,{children:"Type and member names should be descriptive. I do understand that Matt was the only one developing the game and didn't expect anyone to mess with the game's code. I also understand that you would know your own code better that anyone else, but still..."})," Although, nevermind, there's probably a ton of comments in the source code, that we can't see in the compiled assembly."]}),"\n",(0,o.jsx)(t.h3,{id:"too-many-string-comparisons",children:"Too many string comparisons"}),"\n",(0,o.jsxs)(t.p,{children:["After a couple of minutes of browsing through the code, you'll notice that there's way too many string comparisons. You know they're heavy on the performance. Sometimes they're in places where you don't even need strings, for example, in ",(0,o.jsx)(t.code,{children:"Relationships"})," where you could have just used enumerations (actually, Matt used ",(0,o.jsx)(t.strong,{children:"both"})," enumerations and strings, for some weird reason)."]}),"\n",(0,o.jsx)(t.h3,{id:"empty-strings",children:"Empty strings"}),"\n",(0,o.jsxs)(t.p,{children:["For some reason, ",(0,o.jsx)(t.code,{children:'""'})," is used instead of ",(0,o.jsx)(t.code,{children:"string.Empty"}),". And for some reason ",(0,o.jsx)(t.code,{children:'""'})," in a lot of the code is equivalent to ",(0,o.jsx)(t.code,{children:"null"}),". You know exactly what's wrong with that. In one case there ",(0,o.jsx)(t.strong,{children:"is"})," a string, that simply has zero length, in the other case - ",(0,o.jsx)(t.strong,{children:"nothing"}),", not even a string, just nothing. It's just plain wrong."]}),"\n",(0,o.jsx)(t.p,{children:(0,o.jsx)(t.img,{src:"https://imgur.com/9rDQAe7.png",alt:'"" used instead of string.Empty or null'})}),"\n",(0,o.jsx)(t.h3,{id:"non-flexible-mechanics",children:"Non-flexible mechanics"}),"\n",(0,o.jsxs)(t.p,{children:["For example, ",(0,o.jsx)(t.code,{children:"Unlock"})," has three fields: ",(0,o.jsx)(t.code,{children:"unavailable"}),", ",(0,o.jsx)(t.code,{children:"onlyInCharacterCreation"}),", ",(0,o.jsx)(t.code,{children:"freeItem"}),". How do you make something available only in Item Teleporter and not available anywhere else? Not only the fields are not descriptive, but they also function significantly differently - ",(0,o.jsx)(t.code,{children:"unavailable"})," makes items unavailable anywhere, while ",(0,o.jsx)(t.code,{children:"onlyInCharacterCreation"})," ",(0,o.jsx)(t.em,{children:"apparently"})," makes an item available ",(0,o.jsx)(t.strong,{children:"only"})," in CC, and ",(0,o.jsx)(t.code,{children:"freeItem"})," makes it available in Item Teleporter. You could have just named them ",(0,o.jsx)(t.code,{children:"availableInGame"}),", ",(0,o.jsx)(t.code,{children:"availableInCharacterCreation"}),", ",(0,o.jsx)(t.code,{children:"availableInItemTeleporter"}),". Then their function and purpose is obvious."]}),"\n",(0,o.jsx)(t.p,{children:(0,o.jsx)(t.img,{src:"https://imgur.com/gjnxvNM.png",alt:"unavailable, onlyInCharacterCreation and freeItem fields"})}),"\n",(0,o.jsxs)(t.p,{children:["I spent ",(0,o.jsx)(t.strong,{children:"dozens of hours"})," converting that kind of system into something more maintainable: ",(0,o.jsx)(t.code,{children:"Available"}),", ",(0,o.jsx)(t.code,{children:"AvailableInCC"})," and ",(0,o.jsx)(t.code,{children:"AvailableInItemTeleporter"})," - properties that you can find in RogueLibs. And even after that, ",(0,o.jsx)(t.a,{href:"https://github.com/Chasmical/RogueLibs/issues/40",children:"there still were issues"}),". ",(0,o.jsx)(t.em,{children:"I'm bad at discrete mathematics, that's why I had a hard time doing that."})]}),"\n",(0,o.jsx)(t.h3,{id:"hard-code",children:"Hard code"}),"\n",(0,o.jsxs)(t.p,{children:["A lot of stuff in the game is so hardcoded, that it's almost impossible to add something completely new and unique. You'd have to modify code in a ton of places, even in places that you wouldn't even think to look in.",(0,o.jsx)(t.br,{}),"\n","I mean, why would you hardcode the amount of players in the game? Each player has a different field (",(0,o.jsx)(t.code,{children:"playerAgent"}),", ",(0,o.jsx)(t.code,{children:"playerAgent2"}),", and so on). That's the only reason why creating a multiplayer game with more than 4 players is impossible."]}),"\n",(0,o.jsx)(t.h3,{id:"toolkit-2d-library",children:"Toolkit 2D library"}),"\n",(0,o.jsxs)(t.p,{children:["I spent ",(0,o.jsx)(t.strong,{children:"months"})," trying to figure out how this fucking library works! There's no documentation on it. I mean, there are a couple of guides on how to use it in Unity Editor, but there's nothing on how it works internally. There are way too many unused classes, methods, properties and features, and for some reason the classes are in the global namespace. I'm surprised that Matt even figured out how to use it."]}),"\n",(0,o.jsx)(t.h3,{id:"disregard-of-common-programming-principles",children:"Disregard of common programming principles"}),"\n",(0,o.jsxs)(t.p,{children:["A lot of methods have way too many instructions in them and sometimes they do stuff that you wouldn't expect them to do. Just split these different features into different methods.",(0,o.jsx)(t.br,{}),"\n",(0,o.jsx)(t.strong,{children:"KISS principle (Keep It Simple, Stupid)"}),"."]}),"\n",(0,o.jsxs)(t.p,{children:["A lot of methods have a lot of repeating code. You can put that repeating code in a separate method. That will save you a ton of time writing new methods, plus, the code will be easier to read.",(0,o.jsx)(t.br,{}),"\n",(0,o.jsx)(t.strong,{children:"DRY principle (Don't Repeat Yourself)"}),"."]}),"\n",(0,o.jsx)(t.h3,{id:"binary-serialization",children:"Binary serialization"}),"\n",(0,o.jsx)(t.p,{children:(0,o.jsx)(t.img,{src:"https://imgur.com/bl0tEOj.png",alt:"Comparison of raw binary data and XML-formatted file"})}),"\n",(0,o.jsxs)(t.p,{children:["Why would you use binary serialization? It's completely unreadable!",(0,o.jsx)(t.br,{}),"\n","Just use XML, JSON or whatever markup language you want, anything but raw binary data!"]}),"\n",(0,o.jsx)(t.h3,{id:"classes-are-used-like-structs",children:"Classes are used like structs"}),"\n",(0,o.jsx)(t.p,{children:"Matt clearly doesn't understand the difference between reference and value types."}),"\n",(0,o.jsx)(t.h3,{id:"lack-of-properties",children:"Lack of properties"}),"\n",(0,o.jsxs)(t.p,{children:["Instead of constantly setting and updating fields' values in ",(0,o.jsx)(t.code,{children:"Awake"}),", ",(0,o.jsx)(t.code,{children:"Start"})," and other methods, you should just use properties. This way you won't have to constantly update fields' values, once you change one other field's value. The code will instantly become more maintainable."]}),"\n",(0,o.jsx)(t.p,{children:(0,o.jsx)(t.img,{src:"https://imgur.com/gI7WV4I.png",alt:"MyStart method sets up fields and is called in every other method"})}),"\n",(0,o.jsx)(t.h3,{id:"virtual-methods",children:"Virtual methods"}),"\n",(0,o.jsx)(t.p,{children:"Instead of putting dozens of empty virtual methods in a base class and overriding them in a couple of derived types, you should use interfaces! That's literally what they were created for."}),"\n",(0,o.jsx)(t.p,{children:(0,o.jsx)(t.img,{src:"https://imgur.com/aKQA76v.png",alt:"Empty virtual methods"})}),"\n",(0,o.jsx)(t.h3,{id:"lack-of-events",children:"Lack of events"}),"\n",(0,o.jsx)(t.p,{children:"Instead of checking for conditions of doing something on every frame update, you should use events. That's literally what they were created for. As a bonus, there's no 1-frame delay, that you get from checking conditions every frame. And also, you know, checking event conditions every frame is a little bit excessive and definitely uses way too much CPU."}),"\n",(0,o.jsxs)(t.h3,{id:"giant-for-loops",children:["Giant ",(0,o.jsx)(t.code,{children:"for"})," loops"]}),"\n",(0,o.jsx)(t.p,{children:(0,o.jsx)(t.img,{src:"https://imgur.com/kY8gtia.png",alt:"A lot of really big and inefficient loops"})}),"\n",(0,o.jsx)(t.p,{children:"Why would you try to repeat the operation, if you know that the results will be exactly the same?"}),"\n",(0,o.jsx)(t.p,{children:(0,o.jsx)(t.img,{src:"https://imgur.com/vjCshb5.png",alt:"An unnecessary for loop"})}),"\n",(0,o.jsxs)(t.p,{children:["Why the hell would you write all of these giant ",(0,o.jsx)(t.code,{children:"for"})," loops with a ton of conditions, ",(0,o.jsx)(t.code,{children:"break"}),"s and ",(0,o.jsx)(t.code,{children:"continue"}),"s and stuff like that, when there are already methods that do exactly that?",(0,o.jsx)(t.br,{}),"\n",(0,o.jsx)(t.strong,{children:"Just use System.Linq extensions and List<T> methods!"})]}),"\n",(0,o.jsx)(t.h2,{id:"conclusion",children:"Conclusion"}),"\n",(0,o.jsx)(t.p,{children:"Well, that's it. For now, at least..."})]})}function c(e={}){const{wrapper:t}={...(0,s.a)(),...e.components};return t?(0,o.jsx)(t,{...e,children:(0,o.jsx)(h,{...e})}):h(e)}},1151:(e,t,n)=>{n.d(t,{Z:()=>r,a:()=>i});var o=n(7294);const s={},a=o.createContext(s);function i(e){const t=o.useContext(a);return o.useMemo((function(){return"function"==typeof e?e(t):{...t,...e}}),[t,e])}function r(e){let t;return t=e.disableParentContext?"function"==typeof e.components?e.components(s):e.components||s:i(e.components),o.createElement(a.Provider,{value:t},e.children)}}}]);