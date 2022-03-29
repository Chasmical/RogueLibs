"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[7863],{4214:function(e,t,n){n.d(t,{Z:function(){return r}});var a=n(7294),i=n(1736);function r(e){var t=e.children,n=e.language;return a.createElement(i.Z,{className:"language-"+(n||"csharp")},t.replace(/\t/g,"    "))}},1016:function(e,t,n){n.d(t,{Z:function(){return s}});var a=n(7462),i=n(3366),r=n(7294),o=["children"];function s(e){var t=e.children,n=(0,i.Z)(e,o);return r.createElement("div",(0,a.Z)({role:"tabpanel"},n),t)}},250:function(e,t,n){n.d(t,{Z:function(){return m}});var a=n(7294),i=n(5773),r=n(6010),o="tabItem_V91s",s="tabItemActive_JsUu",c="tab_ntnM";var l=37,d=39;function m(e){var t=e.lazy,n=e.defaultValue,m=e.values,u=e.groupId,f=(0,i.UB)(),p=f.tabGroupChoices,h=f.setTabGroupChoices,v=(0,a.useState)(n),g=v[0],k=v[1],N=a.Children.toArray(e.children),C=[];if(null!=u){var b=p[u];null!=b&&b!==g&&m.some((function(e){return e.value===b}))&&k(b)}var w=function(e){var t=e.currentTarget,n=C.indexOf(t),a=m[n].value;k(a),null!=u&&(h(u,a),setTimeout((function(){var e,n,a,i,r,o,c,l;(e=t.getBoundingClientRect(),n=e.top,a=e.left,i=e.bottom,r=e.right,o=window,c=o.innerHeight,l=o.innerWidth,n>=0&&r<=l&&i<=c&&a>=0)||(t.scrollIntoView({block:"center",behavior:"smooth"}),t.classList.add(s),setTimeout((function(){return t.classList.remove(s)}),2e3))}),150))},E=function(e){var t;switch(e.keyCode){case d:var n=C.indexOf(e.target)+1;t=C[n]||C[0];break;case l:var a=C.indexOf(e.target)-1;t=C[a]||C[C.length-1];break;default:return}t.focus()},y=function(e,t){return t.value===e||t.values&&-1!=t.values.indexOf(e)};return a.createElement("div",{className:"tabs-container"},a.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:"tabs"},m.map((function(e){var t=e.value,n=e.label;return a.createElement("li",{role:"tab",tabIndex:g===t?0:-1,"aria-selected":g===t,className:(0,r.Z)("tabs__item",o,{"tabs__item--active":g===t}),key:t,ref:function(e){return e&&C.push(e)},onKeyDown:E,onFocus:w,onClick:w},n)}))),t?a.cloneElement(N.find((function(e){return y(g,e.props)})),{className:c}):a.createElement("div",null,N.map((function(e,t){return a.cloneElement(e,{key:t,hidden:!y(g,e.props),className:c})}))),a.createElement("br",null))}},5600:function(e,t,n){n.r(t),n.d(t,{contentTitle:function(){return m},default:function(){return h},frontMatter:function(){return d},metadata:function(){return u},toc:function(){return f}});var a=n(7462),i=n(3366),r=(n(7294),n(3905)),o=n(250),s=n(1016),c=(n(4996),n(4214)),l=["components"],d={},m="Creating a Custom Effect",u={unversionedId:"dev/traits/create-effect",id:"dev/traits/create-effect",title:"Creating a Custom Effect",description:"CustomEffect class",source:"@site/docs/dev/traits/create-effect.mdx",sourceDirName:"dev/traits",slug:"/dev/traits/create-effect",permalink:"/RogueLibs/docs/dev/traits/create-effect",editUrl:"https://github.com/SugarBarrel/RogueLibs/edit/main/website/docs/dev/traits/create-effect.mdx",tags:[],version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"Creating a Custom Trait",permalink:"/RogueLibs/docs/dev/traits/create-trait"},next:{title:"Creating a Custom Interaction",permalink:"/RogueLibs/docs/dev/interactions/create-interaction"}},f=[{value:"<code>CustomEffect</code> class",id:"customeffect",children:[],level:2},{value:"Initialization",id:"initialization",children:[],level:2},{value:"Examples",id:"examples",children:[],level:2}],p={toc:f};function h(e){var t=e.components,n=(0,i.Z)(e,l);return(0,r.kt)("wrapper",(0,a.Z)({},p,n,{components:t,mdxType:"MDXLayout"}),(0,r.kt)("h1",{id:"creating-a-custom-effect"},"Creating a Custom Effect"),(0,r.kt)("h2",{id:"customeffect"},(0,r.kt)("inlineCode",{parentName:"h2"},"CustomEffect")," class"),(0,r.kt)("p",null,"To make a custom effect, you need to create a class deriving from ",(0,r.kt)("inlineCode",{parentName:"p"},"CustomEffect"),":"),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyCustomEffect.cs"',title:'"MyCustomEffect.cs"'},"// highlight-next-line\npublic class MyCustomEffect : CustomEffect\n{\n    /* ... */\n}\n")),(0,r.kt)("p",null,"There are 5 methods that you need to implement:"),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyCustomEffect.cs"',title:'"MyCustomEffect.cs"'},"public class MyCustomEffect : CustomEffect\n{\n    // highlight-start\n    public override int GetEffectTime() { /* ... */ }\n    public override int GetEffectHate() { /* ... */ }\n    public override void OnAdded() { /* ... */ }\n    public override void OnRemoved() { /* ... */ }\n    public override void OnUpdated(EffectUpdatedArgs e) { /* ... */ }\n    // highlight-end\n}\n")),(0,r.kt)("p",null,(0,r.kt)("inlineCode",{parentName:"p"},"GetEffectTime"),' determines the default status effect time. Traits like "Longer Status Effects", "Longer Status Effects +" and "Shorter Status Effects" are applied after calling this method.'),(0,r.kt)("p",null,(0,r.kt)("inlineCode",{parentName:"p"},"GetEffectHate")," determines how much hate other characters will get towards the character who inflicted the status effect on them. Usually, it's 5 for negative effects and 0 for positive effects."),(0,r.kt)("div",{className:"admonition admonition-caution alert alert--warning"},(0,r.kt)("div",{parentName:"div",className:"admonition-heading"},(0,r.kt)("h5",{parentName:"div"},(0,r.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,r.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"16",height:"16",viewBox:"0 0 16 16"},(0,r.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M8.893 1.5c-.183-.31-.52-.5-.887-.5s-.703.19-.886.5L.138 13.499a.98.98 0 0 0 0 1.001c.193.31.53.501.886.501h13.964c.367 0 .704-.19.877-.5a1.03 1.03 0 0 0 .01-1.002L8.893 1.5zm.133 11.497H6.987v-2.003h2.039v2.003zm0-3.004H6.987V5.987h2.039v4.006z"}))),"caution")),(0,r.kt)("div",{parentName:"div",className:"admonition-content"},(0,r.kt)("p",{parentName:"div"},(0,r.kt)("inlineCode",{parentName:"p"},"GetEffectTime")," and ",(0,r.kt)("inlineCode",{parentName:"p"},"GetEffectHate")," are called on partially initialized hooks, so the effect's owner might not actually have the effect. Do not initialize any effect-specific variables in these methods."))),(0,r.kt)("p",null,(0,r.kt)("inlineCode",{parentName:"p"},"OnAdded")," is called when the effect is added to a character, and ",(0,r.kt)("inlineCode",{parentName:"p"},"OnRemoved")," is called when it's removed from a character."),(0,r.kt)("p",null,(0,r.kt)("inlineCode",{parentName:"p"},"OnUpdated")," works like Unity's ",(0,r.kt)("inlineCode",{parentName:"p"},"Update"),", but with a settable interval (default is 1 second):"),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},"    public void OnUpdated(EffectUpdatedArgs e)\n    {\n        // highlight-next-line\n        e.UpdateDelay = 0.5f; // 2 updates per second\n        /* ... */\n        // highlight-next-line\n        CurrentTime--;\n    }\n")),(0,r.kt)("div",{className:"admonition admonition-info alert alert--info"},(0,r.kt)("div",{parentName:"div",className:"admonition-heading"},(0,r.kt)("h5",{parentName:"div"},(0,r.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,r.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,r.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M7 2.3c3.14 0 5.7 2.56 5.7 5.7s-2.56 5.7-5.7 5.7A5.71 5.71 0 0 1 1.3 8c0-3.14 2.56-5.7 5.7-5.7zM7 1C3.14 1 0 4.14 0 8s3.14 7 7 7 7-3.14 7-7-3.14-7-7-7zm1 3H6v5h2V4zm0 6H6v2h2v-2z"}))),"info")),(0,r.kt)("div",{parentName:"div",className:"admonition-content"},(0,r.kt)("p",{parentName:"div"},"You're responsible for decrementing the effect's ",(0,r.kt)("inlineCode",{parentName:"p"},"CurrentTime"),". So, don't forget to do that."))),(0,r.kt)("p",null,"All custom effect classes should have an ",(0,r.kt)("inlineCode",{parentName:"p"},"EffectParameters")," attribute. You can specify whether your effect should be removed on death, on knockout or between levels. Default is ",(0,r.kt)("inlineCode",{parentName:"p"},"RemoveOnDeath"),"."),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},"[EffectParameters(EffectLimitations.RemoveOnDeath | EffectLimitations.RemoveOnKnockOut)]\npublic class MyCustomEffect : CustomEffect\n{\n    /* ... */\n}\n")),(0,r.kt)("h2",{id:"initialization"},"Initialization"),(0,r.kt)("p",null,"Just call the ",(0,r.kt)("inlineCode",{parentName:"p"},"CreateCustomEffect")," method with your effect's type as a parameter:"),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyCustomEffect.cs"',title:'"MyCustomEffect.cs"'},"public class MyCustomEffect : CustomEffect\n{\n    [RLSetup]\n    public static void Setup()\n    {\n        // highlight-next-line\n        RogueLibs.CreateCustomEffect<MyCustomEffect>();\n    }\n}\n")),(0,r.kt)("div",{className:"admonition admonition-note alert alert--secondary"},(0,r.kt)("div",{parentName:"div",className:"admonition-heading"},(0,r.kt)("h5",{parentName:"div"},(0,r.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,r.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,r.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.3 5.69a.942.942 0 0 1-.28-.7c0-.28.09-.52.28-.7.19-.18.42-.28.7-.28.28 0 .52.09.7.28.18.19.28.42.28.7 0 .28-.09.52-.28.7a1 1 0 0 1-.7.3c-.28 0-.52-.11-.7-.3zM8 7.99c-.02-.25-.11-.48-.31-.69-.2-.19-.42-.3-.69-.31H6c-.27.02-.48.13-.69.31-.2.2-.3.44-.31.69h1v3c.02.27.11.5.31.69.2.2.42.31.69.31h1c.27 0 .48-.11.69-.31.2-.19.3-.42.31-.69H8V7.98v.01zM7 2.3c-3.14 0-5.7 2.54-5.7 5.68 0 3.14 2.56 5.7 5.7 5.7s5.7-2.55 5.7-5.7c0-3.15-2.56-5.69-5.7-5.69v.01zM7 .98c3.86 0 7 3.14 7 7s-3.14 7-7 7-7-3.12-7-7 3.14-7 7-7z"}))),"note")),(0,r.kt)("div",{parentName:"div",className:"admonition-content"},(0,r.kt)("p",{parentName:"div"},"See more about the ",(0,r.kt)("inlineCode",{parentName:"p"},"RLSetup")," attribute ",(0,r.kt)("a",{parentName:"p",href:"../patching-utilities#rlsetup"},"here"),"."))),(0,r.kt)("p",null,"You can set your effect's name and description using ",(0,r.kt)("inlineCode",{parentName:"p"},"WithName")," and ",(0,r.kt)("inlineCode",{parentName:"p"},"WithDescription")," methods:"),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyCustomEffect.cs"',title:'"MyCustomEffect.cs"'},'public class MyCustomEffect : CustomEffect\n{\n    [RLSetup]\n    public static void Setup()\n    {\n        RogueLibs.CreateCustomEffect<MyCustomEffect>()\n            // highlight-start\n            .WithName(new CustomNameInfo("My Custom Effect"))\n            .WithDescription(new CustomNameInfo("My Custom Effect is very cool and does a lot of great stuff"));\n            // highlight-end\n    }\n}\n')),(0,r.kt)("div",{className:"admonition admonition-info alert alert--info"},(0,r.kt)("div",{parentName:"div",className:"admonition-heading"},(0,r.kt)("h5",{parentName:"div"},(0,r.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,r.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,r.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M7 2.3c3.14 0 5.7 2.56 5.7 5.7s-2.56 5.7-5.7 5.7A5.71 5.71 0 0 1 1.3 8c0-3.14 2.56-5.7 5.7-5.7zM7 1C3.14 1 0 4.14 0 8s3.14 7 7 7 7-3.14 7-7-3.14-7-7-7zm1 3H6v5h2V4zm0 6H6v2h2v-2z"}))),"info")),(0,r.kt)("div",{parentName:"div",className:"admonition-content"},(0,r.kt)("p",{parentName:"div"},"See ",(0,r.kt)("a",{parentName:"p",href:"../names/custom-names"},"Custom Names")," for more info."))),(0,r.kt)("h2",{id:"examples"},"Examples"),(0,r.kt)(o.Z,{defaultValue:"adrenaline",values:[{label:"Adrenaline",value:"adrenaline"}],mdxType:"Tabs"},(0,r.kt)(s.Z,{value:"adrenaline",mdxType:"TabItem"},(0,r.kt)("p",null,"A simple effect that just gives a temporary boost to some stats. You can see Adrenaline Shot's (item that gives this effect) implementation in ",(0,r.kt)("a",{parentName:"p",href:"../items/usable-items#examples"},"Usable Items: Examples"),"."),(0,r.kt)(c.Z,{mdxType:"CodeSnippet"},'namespace RogueLibsCore.Test\n{\n    [EffectParameters(EffectLimitations.RemoveOnDeath | EffectLimitations.RemoveOnKnockOut)]\n    public class Adrenaline : CustomEffect\n    {\n        [RLSetup]\n        public static void Setup()\n        {\n            RogueLibs.CreateCustomEffect<Adrenaline>()\n                 .WithName(new CustomNameInfo("Adrenaline"))\n                 .WithDescription(new CustomNameInfo("Gives you a ton of boosts for a short period of time."));\n        }\n\n        public override int GetEffectTime() => 15;\n        public override int GetEffectHate() => 0;\n        public override void OnAdded()\n        {\n            Owner.ChangeHealth(20);\n            Owner.SetStrength(Owner.strengthStatMod + 2);\n            Owner.SetEndurance(Owner.enduranceStatMod + 2);\n            Owner.SetAccuracy(Owner.accuracyStatMod - 1);\n            Owner.SetSpeed(Owner.speedStatMod + 2);\n            Owner.critChance += 30;\n        }\n        public override void OnRemoved()\n        {\n            Owner.SetStrength(Owner.strengthStatMod - 2);\n            Owner.SetEndurance(Owner.enduranceStatMod - 2);\n            Owner.SetAccuracy(Owner.accuracyStatMod + 1);\n            Owner.SetSpeed(Owner.speedStatMod - 2);\n            Owner.critChance -= 30;\n        }\n        public override void OnUpdated(EffectUpdatedArgs e)\n        {\n            e.UpdateDelay = 1f;\n            CurrentTime--;\n        }\n    }\n}\n'))))}h.isMDXComponent=!0}}]);