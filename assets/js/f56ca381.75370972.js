(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[4505],{3690:function(e,t,a){"use strict";a.r(t),a.d(t,{frontMatter:function(){return r},contentTitle:function(){return l},metadata:function(){return d},assets:function(){return p},toc:function(){return h},default:function(){return u}});var n=a(2122),o=a(9756),i=(a(7294),a(3905)),s=["components"],r={title:"What I hate about SoR",author:"Abbysssal",author_title:"Creator of RogueLibs",author_url:"https://github.com/Abbysssal",author_image_url:"https://avatars.githubusercontent.com/u/55982389?height=200&width=200",tags:["blog","sor2"],description:"The code is really hard and wet.",hide_table_of_contents:!1},l=void 0,d={permalink:"/RogueLibs/blog/2021/08/31/what-i-hate-about-sor",editUrl:"https://github.com/Abbysssal/RogueLibs/edit/main/website/blog/blog/2021-08-31-what-i-hate-about-sor.md",source:"@site/blog/2021-08-31-what-i-hate-about-sor.md",title:"What I hate about SoR",description:"The code is really hard and wet.",date:"2021-08-31T00:00:00.000Z",formattedDate:"August 31, 2021",tags:[{label:"blog",permalink:"/RogueLibs/blog/tags/blog"},{label:"sor2",permalink:"/RogueLibs/blog/tags/sor-2"}],readingTime:5.7,truncated:!0,authors:[{name:"Abbysssal",title:"Creator of RogueLibs",url:"https://github.com/Abbysssal",imageURL:"https://avatars.githubusercontent.com/u/55982389?height=200&width=200"}],nextItem:{title:"RogueLibs v3.1.0 released!",permalink:"/RogueLibs/blog/2021/08/18/roguelibs-v3.1.0"}},p={authorsImageUrls:[void 0]},h=[{value:"The code is really hard and wet",id:"the-code-is-really-hard-and-wet",children:[{value:"Global namespace",id:"global-namespace",children:[]},{value:"A lot of unused types and members",id:"a-lot-of-unused-types-and-members",children:[]},{value:"Bad names",id:"bad-names",children:[]},{value:"Too many string comparisons",id:"too-many-string-comparisons",children:[]},{value:"Empty strings",id:"empty-strings",children:[]},{value:"Non-flexible mechanics",id:"non-flexible-mechanics",children:[]},{value:"Hard code",id:"hard-code",children:[]},{value:"Toolkit 2D library",id:"toolkit-2d-library",children:[]},{value:"Disregard of common programming principles",id:"disregard-of-common-programming-principles",children:[]},{value:"Binary serialization",id:"binary-serialization",children:[]},{value:"Classes are used like structs",id:"classes-are-used-like-structs",children:[]},{value:"Lack of properties",id:"lack-of-properties",children:[]},{value:"Virtual methods",id:"virtual-methods",children:[]},{value:"Lack of events",id:"lack-of-events",children:[]},{value:"Giant <code>for</code> loops",id:"giant-for-loops",children:[]}]},{value:"Conclusion",id:"conclusion",children:[]}],m={toc:h};function u(e){var t=e.components,a=(0,o.Z)(e,s);return(0,i.kt)("wrapper",(0,n.Z)({},m,a,{components:t,mdxType:"MDXLayout"}),(0,i.kt)("h2",{id:"the-code-is-really-hard-and-wet"},"The code is really hard and wet"),(0,i.kt)("p",null,".. Wait- No! I mean that the game is really ",(0,i.kt)("strong",{parentName:"p"},"hard"),"coded! And the code is very ",(0,i.kt)("strong",{parentName:"p"},"WET")," - it's the opposite of the DRY (Don't Repeat Yourself) principle... It's pretty funny to say that though."),(0,i.kt)("p",null,"So, anyways, I decided to make a list of things that I hate about modding Streets of Rogue:"),(0,i.kt)("h3",{id:"global-namespace"},"Global namespace"),(0,i.kt)("p",null,"The first annoying thing that you notice, when you take a brief look into SoR modding, is that all of the game's types are in the global namespace. There's a couple of exceptions, though that's probably from the copy-pasted code."),(0,i.kt)("p",null,(0,i.kt)("img",{parentName:"p",src:"https://imgur.com/HYDcvxx.png",alt:"Global namespace (dnSpy)"})),(0,i.kt)("p",null,"I mean, come on, just organize stuff in namespaces! Like ",(0,i.kt)("inlineCode",{parentName:"p"},"StreetsOfRogue")," for main stuff, ",(0,i.kt)("inlineCode",{parentName:"p"},"StreetsOfRogue.LevelGeneration")," for stuff related to level generation, ",(0,i.kt)("inlineCode",{parentName:"p"},"StreetsOfRogue.Objects")," for all classes derived from ",(0,i.kt)("inlineCode",{parentName:"p"},"ObjectReal")," and etc."),(0,i.kt)("h3",{id:"a-lot-of-unused-types-and-members"},"A lot of unused types and members"),(0,i.kt)("p",null,"There's a lot of stuff, that's not used in the game at all. Some part of it is just some test code. The other part - is not related to Streets of Rogue at all, and probably was copy-pasted from somewhere else."),(0,i.kt)("p",null,(0,i.kt)("img",{parentName:"p",src:"https://imgur.com/XNeeF8Q.png",alt:"A lot of unused types"}),"\n",(0,i.kt)("img",{parentName:"p",src:"https://imgur.com/REhaTil.png",alt:"3 unused fields in Agent class"})),(0,i.kt)("h3",{id:"bad-names"},"Bad names"),(0,i.kt)("p",null,(0,i.kt)("del",{parentName:"p"},"Type and member names should be descriptive. I do understand that Matt was the only one developing the game and didn't expect anyone to mess with the game's code. I also understand that you would know your own code better that anyone else, but still...")," Although, nevermind, there's probably a ton of comments in the source code, that we can't see in the compiled assembly."),(0,i.kt)("h3",{id:"too-many-string-comparisons"},"Too many string comparisons"),(0,i.kt)("p",null,"After a couple of minutes of browsing through the code, you'll notice that there's way too many string comparisons. You know they're heavy on the performance. Sometimes they're in places where you don't even need strings, for example, in ",(0,i.kt)("inlineCode",{parentName:"p"},"Relationships")," where you could have just used enumerations (actually, Matt used ",(0,i.kt)("strong",{parentName:"p"},"both")," enumerations and strings, for some weird reason)."),(0,i.kt)("h3",{id:"empty-strings"},"Empty strings"),(0,i.kt)("p",null,"For some reason, ",(0,i.kt)("inlineCode",{parentName:"p"},'""')," is used instead of ",(0,i.kt)("inlineCode",{parentName:"p"},"string.Empty"),". And for some reason ",(0,i.kt)("inlineCode",{parentName:"p"},'""')," in a lot of the code is equivalent to ",(0,i.kt)("inlineCode",{parentName:"p"},"null"),". You know exactly what's wrong with that. In one case there ",(0,i.kt)("strong",{parentName:"p"},"is")," a string, that simply has zero length, in the other case - ",(0,i.kt)("strong",{parentName:"p"},"nothing"),", not even a string, just nothing. It's just plain wrong."),(0,i.kt)("p",null,(0,i.kt)("img",{parentName:"p",src:"https://imgur.com/9rDQAe7.png",alt:'"" used instead of string.Empty or null'})),(0,i.kt)("h3",{id:"non-flexible-mechanics"},"Non-flexible mechanics"),(0,i.kt)("p",null,"For example, ",(0,i.kt)("inlineCode",{parentName:"p"},"Unlock")," has three fields: ",(0,i.kt)("inlineCode",{parentName:"p"},"unavailable"),", ",(0,i.kt)("inlineCode",{parentName:"p"},"onlyInCharacterCreation"),", ",(0,i.kt)("inlineCode",{parentName:"p"},"freeItem"),". How do you make something available only in Item Teleporter and not available anywhere else? Not only the fields are not descriptive, but they also function significantly differently - ",(0,i.kt)("inlineCode",{parentName:"p"},"unavailable")," makes items unavailable anywhere, while ",(0,i.kt)("inlineCode",{parentName:"p"},"onlyInCharacterCreation")," ",(0,i.kt)("em",{parentName:"p"},"apparently")," makes an item available ",(0,i.kt)("strong",{parentName:"p"},"only")," in CC, and ",(0,i.kt)("inlineCode",{parentName:"p"},"freeItem")," makes it available in Item Teleporter. You could have just named them ",(0,i.kt)("inlineCode",{parentName:"p"},"availableInGame"),", ",(0,i.kt)("inlineCode",{parentName:"p"},"availableInCharacterCreation"),", ",(0,i.kt)("inlineCode",{parentName:"p"},"availableInItemTeleporter"),". Then their function and purpose is obvious."),(0,i.kt)("p",null,(0,i.kt)("img",{parentName:"p",src:"https://imgur.com/gjnxvNM.png",alt:"unavailable, onlyInCharacterCreation and freeItem fields"})),(0,i.kt)("p",null,"I spent ",(0,i.kt)("strong",{parentName:"p"},"dozens of hours")," converting that kind of system into something more maintainable: ",(0,i.kt)("inlineCode",{parentName:"p"},"Available"),", ",(0,i.kt)("inlineCode",{parentName:"p"},"AvailableInCC")," and ",(0,i.kt)("inlineCode",{parentName:"p"},"AvailableInItemTeleporter")," - properties that you can find in RogueLibs. And even after that, ",(0,i.kt)("a",{parentName:"p",href:"https://github.com/Abbysssal/RogueLibs/issues/40"},"there still were issues"),". ",(0,i.kt)("em",{parentName:"p"},"I'm bad at discrete mathematics, that's why I had a hard time doing that.")),(0,i.kt)("h3",{id:"hard-code"},"Hard code"),(0,i.kt)("p",null,"A lot of stuff in the game is so hardcoded, that it's almost impossible to add something completely new and unique. You'd have to modify code in a ton of places, even in places that you wouldn't even think to look in.",(0,i.kt)("br",{parentName:"p"}),"\n","I mean, why would you hardcode the amount of players in the game? Each player has a different field (",(0,i.kt)("inlineCode",{parentName:"p"},"playerAgent"),", ",(0,i.kt)("inlineCode",{parentName:"p"},"playerAgent2"),", and so on). That's the only reason why creating a multiplayer game with more than 4 players is impossible."),(0,i.kt)("h3",{id:"toolkit-2d-library"},"Toolkit 2D library"),(0,i.kt)("p",null,"I spent ",(0,i.kt)("strong",{parentName:"p"},"months")," trying to figure out how this fucking library works! There's no documentation on it. I mean, there are a couple of guides on how to use it in Unity Editor, but there's nothing on how it works internally. There are way too many unused classes, methods, properties and features, and for some reason the classes are in the global namespace. I'm surprised that Matt even figured out how to use it."),(0,i.kt)("h3",{id:"disregard-of-common-programming-principles"},"Disregard of common programming principles"),(0,i.kt)("p",null,"A lot of methods have way too many instructions in them and sometimes they do stuff that you wouldn't expect them to do. Just split these different features into different methods.",(0,i.kt)("br",{parentName:"p"}),"\n",(0,i.kt)("strong",{parentName:"p"},"KISS principle (Keep It Simple, Stupid)"),"."),(0,i.kt)("p",null,"A lot of methods have a lot of repeating code. You can put that repeating code in a separate method. That will save you a ton of time writing new methods, plus, the code will be easier to read.",(0,i.kt)("br",{parentName:"p"}),"\n",(0,i.kt)("strong",{parentName:"p"},"DRY principle (Don't Repeat Yourself)"),"."),(0,i.kt)("h3",{id:"binary-serialization"},"Binary serialization"),(0,i.kt)("p",null,(0,i.kt)("img",{parentName:"p",src:"https://imgur.com/bl0tEOj.png",alt:"Comparison of raw binary data and XML-formatted file"})),(0,i.kt)("p",null,"Why would you use binary serialization? It's completely unreadable!",(0,i.kt)("br",{parentName:"p"}),"\n","Just use XML, JSON or whatever markup language you want, anything but raw binary data!"),(0,i.kt)("h3",{id:"classes-are-used-like-structs"},"Classes are used like structs"),(0,i.kt)("p",null,"Matt clearly doesn't understand the difference between reference and value types."),(0,i.kt)("h3",{id:"lack-of-properties"},"Lack of properties"),(0,i.kt)("p",null,"Instead of constantly setting and updating fields' values in ",(0,i.kt)("inlineCode",{parentName:"p"},"Awake"),", ",(0,i.kt)("inlineCode",{parentName:"p"},"Start")," and other methods, you should just use properties. This way you won't have to constantly update fields' values, once you change one other field's value. The code will instantly become more maintainable."),(0,i.kt)("p",null,(0,i.kt)("img",{parentName:"p",src:"https://imgur.com/gI7WV4I.png",alt:"MyStart method sets up fields and is called in every other method"})),(0,i.kt)("h3",{id:"virtual-methods"},"Virtual methods"),(0,i.kt)("p",null,"Instead of putting dozens of empty virtual methods in a base class and overriding them in a couple of derived types, you should use interfaces! That's literally what they were created for."),(0,i.kt)("p",null,(0,i.kt)("img",{parentName:"p",src:"https://imgur.com/aKQA76v.png",alt:"Empty virtual methods"})),(0,i.kt)("h3",{id:"lack-of-events"},"Lack of events"),(0,i.kt)("p",null,"Instead of checking for conditions of doing something on every frame update, you should use events. That's literally what they were created for. As a bonus, there's no 1-frame delay, that you get from checking conditions every frame. And also, you know, checking event conditions every frame is a little bit excessive and definitely uses way too much CPU."),(0,i.kt)("h3",{id:"giant-for-loops"},"Giant ",(0,i.kt)("inlineCode",{parentName:"h3"},"for")," loops"),(0,i.kt)("p",null,(0,i.kt)("img",{parentName:"p",src:"https://imgur.com/kY8gtia.png",alt:"A lot of really big and inefficient loops"})),(0,i.kt)("p",null,"Why would you try to repeat the operation, if you know that the results will be exactly the same?"),(0,i.kt)("p",null,(0,i.kt)("img",{parentName:"p",src:"https://imgur.com/vjCshb5.png",alt:"An unnecessary for loop"})),(0,i.kt)("p",null,"Why the hell would you write all of these giant ",(0,i.kt)("inlineCode",{parentName:"p"},"for")," loops with a ton of conditions, ",(0,i.kt)("inlineCode",{parentName:"p"},"break"),"s and ",(0,i.kt)("inlineCode",{parentName:"p"},"continue"),"s and stuff like that, when there are already methods that do exactly that?",(0,i.kt)("br",{parentName:"p"}),"\n",(0,i.kt)("strong",{parentName:"p"},"Just use System.Linq extensions and List<T",">"," methods!")),(0,i.kt)("h2",{id:"conclusion"},"Conclusion"),(0,i.kt)("p",null,"Well, that's it. For now, at least."),(0,i.kt)("p",null,"I wish Matt would fix all of that and make SoR 2 at least slightly more moddable and maintainable. If all of that stuff gets fixed in SoR 2, I'd be really happy, and I'd definitely make sure that SoR 2 has the best modding library possible. Otherwise, I might just refuse to make mods for the sequel, when it comes out."))}u.isMDXComponent=!0}}]);