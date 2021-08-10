(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[2289],{215:function(e,t,n){"use strict";n.r(t),n.d(t,{frontMatter:function(){return l},contentTitle:function(){return r},metadata:function(){return c},toc:function(){return m},default:function(){return u}});var a=n(2122),i=n(9756),o=(n(7294),n(3905)),s=(n(8952),n(9309),n(4996),["components"]),l={},r="Custom Unlocks",c={unversionedId:"dev/unlocks/custom-unlocks",id:"dev/unlocks/custom-unlocks",isDocsHomePage:!1,title:"Custom Unlocks",description:"UnlockWrapper class",source:"@site/docs/dev/unlocks/custom-unlocks.mdx",sourceDirName:"dev/unlocks",slug:"/dev/unlocks/custom-unlocks",permalink:"/RogueLibs/docs/dev/unlocks/custom-unlocks",editUrl:"https://github.com/Abbysssal/RogueLibs/edit/main/website/docs/dev/unlocks/custom-unlocks.mdx",version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"Creating a Custom Effect",permalink:"/RogueLibs/docs/dev/traits/create-effect"},next:{title:"Overriding Default Behavior",permalink:"/RogueLibs/docs/dev/unlocks/overriding-behavior"}},m=[{value:"<code>UnlockWrapper</code> class",id:"unlockwrapper",children:[]},{value:"<code>DisplayedUnlock</code> class",id:"displayedunlock",children:[]},{value:"Unlock classes",id:"unlock-classes",children:[]},{value:"Initialization",id:"initialization",children:[]}],d={toc:m};function u(e){var t=e.components,n=(0,i.Z)(e,s);return(0,o.kt)("wrapper",(0,a.Z)({},d,n,{components:t,mdxType:"MDXLayout"}),(0,o.kt)("h1",{id:"custom-unlocks"},"Custom Unlocks"),(0,o.kt)("h2",{id:"unlockwrapper"},(0,o.kt)("inlineCode",{parentName:"h2"},"UnlockWrapper")," class"),(0,o.kt)("p",null,"All of the unlocks in the game are wrapped in a more flexible class - ",(0,o.kt)("inlineCode",{parentName:"p"},"UnlockWrapper"),"."),(0,o.kt)("p",null,(0,o.kt)("inlineCode",{parentName:"p"},"UnlockWrapper")," provides methods to get the unlock's name, description, image and other stuff."),(0,o.kt)("div",{className:"admonition admonition-caution alert alert--warning"},(0,o.kt)("div",{parentName:"div",className:"admonition-heading"},(0,o.kt)("h5",{parentName:"div"},(0,o.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,o.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"16",height:"16",viewBox:"0 0 16 16"},(0,o.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M8.893 1.5c-.183-.31-.52-.5-.887-.5s-.703.19-.886.5L.138 13.499a.98.98 0 0 0 0 1.001c.193.31.53.501.886.501h13.964c.367 0 .704-.19.877-.5a1.03 1.03 0 0 0 .01-1.002L8.893 1.5zm.133 11.497H6.987v-2.003h2.039v2.003zm0-3.004H6.987V5.987h2.039v4.006z"}))),"caution")),(0,o.kt)("div",{parentName:"div",className:"admonition-content"},(0,o.kt)("p",{parentName:"div"},"You probably shouldn't implement ",(0,o.kt)("inlineCode",{parentName:"p"},"UnlockWrapper")," directly. Use the classes described later on the page."))),(0,o.kt)("h2",{id:"displayedunlock"},(0,o.kt)("inlineCode",{parentName:"h2"},"DisplayedUnlock")," class"),(0,o.kt)("p",null,(0,o.kt)("inlineCode",{parentName:"p"},"DisplayedUnlock")," derives from the ",(0,o.kt)("inlineCode",{parentName:"p"},"UnlockWrapper")," class. It provides methods to display the unlock in the in-game menus."),(0,o.kt)("div",{className:"admonition admonition-caution alert alert--warning"},(0,o.kt)("div",{parentName:"div",className:"admonition-heading"},(0,o.kt)("h5",{parentName:"div"},(0,o.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,o.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"16",height:"16",viewBox:"0 0 16 16"},(0,o.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M8.893 1.5c-.183-.31-.52-.5-.887-.5s-.703.19-.886.5L.138 13.499a.98.98 0 0 0 0 1.001c.193.31.53.501.886.501h13.964c.367 0 .704-.19.877-.5a1.03 1.03 0 0 0 .01-1.002L8.893 1.5zm.133 11.497H6.987v-2.003h2.039v2.003zm0-3.004H6.987V5.987h2.039v4.006z"}))),"caution")),(0,o.kt)("div",{parentName:"div",className:"admonition-content"},(0,o.kt)("p",{parentName:"div"},"You shouldn't implement ",(0,o.kt)("inlineCode",{parentName:"p"},"DisplayedUnlock")," directly either. Use the classes described later on the page."))),(0,o.kt)("h2",{id:"unlock-classes"},"Unlock classes"),(0,o.kt)("p",null,"RogueLibs provides the following classes that you can derive from:"),(0,o.kt)("ul",null,(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("inlineCode",{parentName:"li"},"ItemUnlock")," - for items;"),(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("inlineCode",{parentName:"li"},"AbilityUnlock")," - for abilities;"),(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("inlineCode",{parentName:"li"},"TraitUnlock")," - for traits;"),(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("inlineCode",{parentName:"li"},"MutatorUnlock")," - for mutators;"),(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("inlineCode",{parentName:"li"},"AgentUnlock")," - for agents;"),(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("inlineCode",{parentName:"li"},"BigQuestUnlock")," - for agent Big Quests;"),(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("inlineCode",{parentName:"li"},"ExtraUnlock")," - for achievements and other stuff;"),(0,o.kt)("li",{parentName:"ul"},(0,o.kt)("inlineCode",{parentName:"li"},"FloorUnlock")," - for floor unlocks;")),(0,o.kt)("div",{className:"admonition admonition-note alert alert--secondary"},(0,o.kt)("div",{parentName:"div",className:"admonition-heading"},(0,o.kt)("h5",{parentName:"div"},(0,o.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,o.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,o.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.3 5.69a.942.942 0 0 1-.28-.7c0-.28.09-.52.28-.7.19-.18.42-.28.7-.28.28 0 .52.09.7.28.18.19.28.42.28.7 0 .28-.09.52-.28.7a1 1 0 0 1-.7.3c-.28 0-.52-.11-.7-.3zM8 7.99c-.02-.25-.11-.48-.31-.69-.2-.19-.42-.3-.69-.31H6c-.27.02-.48.13-.69.31-.2.2-.3.44-.31.69h1v3c.02.27.11.5.31.69.2.2.42.31.69.31h1c.27 0 .48-.11.69-.31.2-.19.3-.42.31-.69H8V7.98v.01zM7 2.3c-3.14 0-5.7 2.54-5.7 5.68 0 3.14 2.56 5.7 5.7 5.7s5.7-2.55 5.7-5.7c0-3.15-2.56-5.69-5.7-5.69v.01zM7 .98c3.86 0 7 3.14 7 7s-3.14 7-7 7-7-3.12-7-7 3.14-7 7-7z"}))),"note")),(0,o.kt)("div",{parentName:"div",className:"admonition-content"},(0,o.kt)("p",{parentName:"div"},"There's also a couple of classes that are in RogueLibs only for compatibility reasons."))),(0,o.kt)("h2",{id:"initialization"},"Initialization"),(0,o.kt)("p",null,"You can initialize your unlocks like this:"),(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyCustomItem.cs"',title:'"MyCustomItem.cs"'},'public class MyCustomItem : CustomItem\n{\n    [RLSetup]\n    public static void Setup()\n    {\n        RogueLibs.CreateCustomItem<MyCustomItem>();\n            .WithName(new CustomNameInfo("My Custom Item"))\n            .WithDescription(new CustomNameInfo("My Custom Item is very cool and does a lot of great stuff"));\n            .WithSprite(Properties.Resources.MyCustomItem)\n            // highlight-next-line\n            .WithUnlock(new ItemUnlock\n            {\n                UnlockCost = 10,\n                CharacterCreationCost = 5,\n                LoadoutCost = 4,\n            });\n    }\n}\n')),(0,o.kt)("p",null,"Or you can just initialize them directly (like in case of mutators):"),(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-csharp"},'RogueLibs.CreateCustomUnlock(new MutatorUnlock("MyMutator"))\n    .WithName(new CustomNameInfo("Mutator Name"))\n    .WithDescription(new CustomNameInfo("Mutator Description"));\n')))}u.isMDXComponent=!0}}]);