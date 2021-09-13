(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[7863],{4214:function(e,t,n){"use strict";n.d(t,{Z:function(){return s}});var a=n(7294),i=n(1756);function s(e){var t=e.children,n=e.language;return a.createElement(i.Z,{className:"language-"+(n||"csharp")},t.replace(/\t/g,"    "))}},8764:function(e,t,n){"use strict";n.r(t),n.d(t,{contentTitle:function(){return m},default:function(){return h},frontMatter:function(){return l},metadata:function(){return f},toc:function(){return p}});var a=n(2122),i=n(9756),s=(n(7294),n(3905)),o=n(1429),r=n(1016),c=(n(4996),n(4214)),d=["components"],l={},m="Creating a Custom Effect",f={unversionedId:"dev/traits/create-effect",id:"dev/traits/create-effect",isDocsHomePage:!1,title:"Creating a Custom Effect",description:"CustomEffect class",source:"@site/docs/dev/traits/create-effect.mdx",sourceDirName:"dev/traits",slug:"/dev/traits/create-effect",permalink:"/RogueLibs/docs/dev/traits/create-effect",editUrl:"https://github.com/Abbysssal/RogueLibs/edit/main/website/docs/dev/traits/create-effect.mdx",tags:[],version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"Creating a Custom Trait",permalink:"/RogueLibs/docs/dev/traits/create-trait"},next:{title:"Custom Unlocks",permalink:"/RogueLibs/docs/dev/unlocks/custom-unlocks"}},p=[{value:"<code>CustomEffect</code> class",id:"customeffect",children:[]},{value:"Initialization",id:"initialization",children:[]},{value:"Examples",id:"examples",children:[]}],u={toc:p};function h(e){var t=e.components,n=(0,i.Z)(e,d);return(0,s.kt)("wrapper",(0,a.Z)({},u,n,{components:t,mdxType:"MDXLayout"}),(0,s.kt)("h1",{id:"creating-a-custom-effect"},"Creating a Custom Effect"),(0,s.kt)("h2",{id:"customeffect"},(0,s.kt)("inlineCode",{parentName:"h2"},"CustomEffect")," class"),(0,s.kt)("p",null,"To make a custom effect, you need to create a class deriving from ",(0,s.kt)("inlineCode",{parentName:"p"},"CustomEffect"),":"),(0,s.kt)("pre",null,(0,s.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyCustomEffect.cs"',title:'"MyCustomEffect.cs"'},"// highlight-next-line\npublic class MyCustomEffect : CustomEffect\n{\n    /* ... */\n}\n")),(0,s.kt)("p",null,"There are 5 methods that you need to implement:"),(0,s.kt)("pre",null,(0,s.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyCustomEffect.cs"',title:'"MyCustomEffect.cs"'},"public class MyCustomEffect : CustomEffect\n{\n    // highlight-start\n    public override int GetEffectTime() { /* ... */ }\n    public override int GetEffectHate() { /* ... */ }\n    public override void OnAdded() { /* ... */ }\n    public override void OnRemoved() { /* ... */ }\n    public override void OnUpdated(EffectUpdatedArgs e) { /* ... */ }\n    // highlight-end\n}\n")),(0,s.kt)("p",null,(0,s.kt)("inlineCode",{parentName:"p"},"GetEffectTime"),' determines the default status effect time. Traits like "Longer Status Effects", "Longer Status Effects +" and "Shorter Status Effects" are applied after calling this method.'),(0,s.kt)("p",null,(0,s.kt)("inlineCode",{parentName:"p"},"GetEffectHate")," determines how much hate other characters will get towards the character who inflicted the status effect on them. Usually, it's 5 for negative effects and 0 for positive effects."),(0,s.kt)("div",{className:"admonition admonition-caution alert alert--warning"},(0,s.kt)("div",{parentName:"div",className:"admonition-heading"},(0,s.kt)("h5",{parentName:"div"},(0,s.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,s.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"16",height:"16",viewBox:"0 0 16 16"},(0,s.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M8.893 1.5c-.183-.31-.52-.5-.887-.5s-.703.19-.886.5L.138 13.499a.98.98 0 0 0 0 1.001c.193.31.53.501.886.501h13.964c.367 0 .704-.19.877-.5a1.03 1.03 0 0 0 .01-1.002L8.893 1.5zm.133 11.497H6.987v-2.003h2.039v2.003zm0-3.004H6.987V5.987h2.039v4.006z"}))),"caution")),(0,s.kt)("div",{parentName:"div",className:"admonition-content"},(0,s.kt)("p",{parentName:"div"},(0,s.kt)("inlineCode",{parentName:"p"},"GetEffectTime")," and ",(0,s.kt)("inlineCode",{parentName:"p"},"GetEffectHate")," are called on partially initialized hooks, so the effect's owner might not actually have the effect. Do not initialize any effect-specific variables in these methods."))),(0,s.kt)("p",null,(0,s.kt)("inlineCode",{parentName:"p"},"OnAdded")," is called when the effect is added to a character, and ",(0,s.kt)("inlineCode",{parentName:"p"},"OnRemoved")," is called when it's removed from a character."),(0,s.kt)("p",null,(0,s.kt)("inlineCode",{parentName:"p"},"OnUpdated")," works like Unity's ",(0,s.kt)("inlineCode",{parentName:"p"},"Update"),", but with a settable interval (default is 1 second):"),(0,s.kt)("pre",null,(0,s.kt)("code",{parentName:"pre",className:"language-csharp"},"    public void OnUpdated(EffectUpdatedArgs e)\n    {\n        // highlight-next-line\n        e.UpdateDelay = 0.5f; // 2 updates per second\n        /* ... */\n        // highlight-next-line\n        CurrentTime--;\n    }\n")),(0,s.kt)("div",{className:"admonition admonition-info alert alert--info"},(0,s.kt)("div",{parentName:"div",className:"admonition-heading"},(0,s.kt)("h5",{parentName:"div"},(0,s.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,s.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,s.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M7 2.3c3.14 0 5.7 2.56 5.7 5.7s-2.56 5.7-5.7 5.7A5.71 5.71 0 0 1 1.3 8c0-3.14 2.56-5.7 5.7-5.7zM7 1C3.14 1 0 4.14 0 8s3.14 7 7 7 7-3.14 7-7-3.14-7-7-7zm1 3H6v5h2V4zm0 6H6v2h2v-2z"}))),"info")),(0,s.kt)("div",{parentName:"div",className:"admonition-content"},(0,s.kt)("p",{parentName:"div"},"You're responsible for decrementing the effect's ",(0,s.kt)("inlineCode",{parentName:"p"},"CurrentTime"),". So, don't forget to do that."))),(0,s.kt)("p",null,"All custom effect classes should have an ",(0,s.kt)("inlineCode",{parentName:"p"},"EffectParameters")," attribute. You can specify whether your effect should be removed on death, on knockout or between levels. Default is ",(0,s.kt)("inlineCode",{parentName:"p"},"RemoveOnDeath"),"."),(0,s.kt)("pre",null,(0,s.kt)("code",{parentName:"pre",className:"language-csharp"},"[EffectParameters(EffectLimitations.RemoveOnDeath | EffectLimitations.RemoveOnKnockOut)]\npublic class MyCustomEffect : CustomEffect\n{\n    /* ... */\n}\n")),(0,s.kt)("h2",{id:"initialization"},"Initialization"),(0,s.kt)("p",null,"Just call the ",(0,s.kt)("inlineCode",{parentName:"p"},"CreateCustomEffect")," method with your effect's type as a parameter:"),(0,s.kt)("pre",null,(0,s.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyCustomEffect.cs"',title:'"MyCustomEffect.cs"'},"public class MyCustomEffect : CustomEffect\n{\n    [RLSetup]\n    public static void Setup()\n    {\n        // highlight-next-line\n        RogueLibs.CreateCustomEffect<MyCustomEffect>();\n    }\n}\n")),(0,s.kt)("div",{className:"admonition admonition-note alert alert--secondary"},(0,s.kt)("div",{parentName:"div",className:"admonition-heading"},(0,s.kt)("h5",{parentName:"div"},(0,s.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,s.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,s.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.3 5.69a.942.942 0 0 1-.28-.7c0-.28.09-.52.28-.7.19-.18.42-.28.7-.28.28 0 .52.09.7.28.18.19.28.42.28.7 0 .28-.09.52-.28.7a1 1 0 0 1-.7.3c-.28 0-.52-.11-.7-.3zM8 7.99c-.02-.25-.11-.48-.31-.69-.2-.19-.42-.3-.69-.31H6c-.27.02-.48.13-.69.31-.2.2-.3.44-.31.69h1v3c.02.27.11.5.31.69.2.2.42.31.69.31h1c.27 0 .48-.11.69-.31.2-.19.3-.42.31-.69H8V7.98v.01zM7 2.3c-3.14 0-5.7 2.54-5.7 5.68 0 3.14 2.56 5.7 5.7 5.7s5.7-2.55 5.7-5.7c0-3.15-2.56-5.69-5.7-5.69v.01zM7 .98c3.86 0 7 3.14 7 7s-3.14 7-7 7-7-3.12-7-7 3.14-7 7-7z"}))),"note")),(0,s.kt)("div",{parentName:"div",className:"admonition-content"},(0,s.kt)("p",{parentName:"div"},"See more about the ",(0,s.kt)("inlineCode",{parentName:"p"},"RLSetup")," attribute ",(0,s.kt)("a",{parentName:"p",href:"../patching-utilities#rlsetup"},"here"),"."))),(0,s.kt)("p",null,"You can set your effect's name and description using ",(0,s.kt)("inlineCode",{parentName:"p"},"WithName")," and ",(0,s.kt)("inlineCode",{parentName:"p"},"WithDescription")," methods:"),(0,s.kt)("pre",null,(0,s.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyCustomEffect.cs"',title:'"MyCustomEffect.cs"'},'public class MyCustomEffect : CustomEffect\n{\n    [RLSetup]\n    public static void Setup()\n    {\n        RogueLibs.CreateCustomEffect<MyCustomEffect>()\n            // highlight-start\n            .WithName(new CustomNameInfo("My Custom Effect"))\n            .WithDescription(new CustomNameInfo("My Custom Effect is very cool and does a lot of great stuff"));\n            // highlight-end\n    }\n}\n')),(0,s.kt)("div",{className:"admonition admonition-info alert alert--info"},(0,s.kt)("div",{parentName:"div",className:"admonition-heading"},(0,s.kt)("h5",{parentName:"div"},(0,s.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,s.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,s.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M7 2.3c3.14 0 5.7 2.56 5.7 5.7s-2.56 5.7-5.7 5.7A5.71 5.71 0 0 1 1.3 8c0-3.14 2.56-5.7 5.7-5.7zM7 1C3.14 1 0 4.14 0 8s3.14 7 7 7 7-3.14 7-7-3.14-7-7-7zm1 3H6v5h2V4zm0 6H6v2h2v-2z"}))),"info")),(0,s.kt)("div",{parentName:"div",className:"admonition-content"},(0,s.kt)("p",{parentName:"div"},"See ",(0,s.kt)("a",{parentName:"p",href:"../names/custom-names"},"Custom Names")," for more info."))),(0,s.kt)("h2",{id:"examples"},"Examples"),(0,s.kt)(o.Z,{defaultValue:"adrenaline",values:[{label:"Adrenaline",value:"adrenaline"}],mdxType:"Tabs"},(0,s.kt)(r.Z,{value:"adrenaline",mdxType:"TabItem"},(0,s.kt)("p",null,"A simple effect that just gives a temporary boost to some stats. You can see Adrenaline Shot's (item that gives this effect) implementation in ",(0,s.kt)("a",{parentName:"p",href:"../items/usable-items#examples"},"Usable Items: Examples"),"."),(0,s.kt)(c.Z,{mdxType:"CodeSnippet"},'namespace RogueLibsCore.Test\n{\n\t[EffectParameters(EffectLimitations.RemoveOnDeath | EffectLimitations.RemoveOnKnockOut)]\n\tpublic class Adrenaline : CustomEffect\n\t{\n\t\t[RLSetup]\n\t\tpublic static void Setup()\n\t\t{\n\t\t\tRogueLibs.CreateCustomEffect<Adrenaline>()\n\t\t\t\t .WithName(new CustomNameInfo("Adrenaline"))\n\t\t\t\t .WithDescription(new CustomNameInfo("Gives you a ton of boosts for a short period of time."));\n\t\t}\n\n\t\tpublic override int GetEffectTime() => 15;\n\t\tpublic override int GetEffectHate() => 0;\n\t\tpublic override void OnAdded()\n\t\t{\n\t\t\tOwner.ChangeHealth(20);\n\t\t\tOwner.SetStrength(Owner.strengthStatMod + 2);\n\t\t\tOwner.SetEndurance(Owner.enduranceStatMod + 2);\n\t\t\tOwner.SetAccuracy(Owner.accuracyStatMod - 1);\n\t\t\tOwner.SetSpeed(Owner.speedStatMod + 2);\n\t\t\tOwner.critChance += 30;\n\t\t}\n\t\tpublic override void OnRemoved()\n\t\t{\n\t\t\tOwner.SetStrength(Owner.strengthStatMod - 2);\n\t\t\tOwner.SetEndurance(Owner.enduranceStatMod - 2);\n\t\t\tOwner.SetAccuracy(Owner.accuracyStatMod + 1);\n\t\t\tOwner.SetSpeed(Owner.speedStatMod - 2);\n\t\t\tOwner.critChance -= 30;\n\t\t}\n\t\tpublic override void OnUpdated(EffectUpdatedArgs e)\n\t\t{\n\t\t\te.UpdateDelay = 1f;\n\t\t\tCurrentTime--;\n\t\t}\n\t}\n}\n'))))}h.isMDXComponent=!0}}]);