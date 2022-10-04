"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[8993],{4214:(e,t,n)=>{n.d(t,{Z:()=>i});var a=n(7294),s=n(814);function i(e){let{children:t,language:n}=e;return a.createElement(s.Z,{className:"language-"+(n||"csharp")},t.replace(/\t/g,"    "))}},1016:(e,t,n)=>{n.d(t,{Z:()=>i});var a=n(7462),s=n(7294);function i(e){let{children:t,...n}=e;return s.createElement("div",(0,a.Z)({role:"tabpanel"},n),t)}},250:(e,t,n)=>{n.d(t,{Z:()=>d});var a=n(7294),s=n(7094),i=n(6010);const r="tabItem_V91s",o="tabItemActive_JsUu",l="tab_ntnM";const m=37,u=39;function d(e){const{lazy:t,defaultValue:n,values:d,groupId:c}=e,{tabGroupChoices:p,setTabGroupChoices:h}=(0,s.U)(),[C,g]=(0,a.useState)(n),k=a.Children.toArray(e.children),N=[];if(null!=c){const e=p[c];null!=e&&e!==C&&d.some((t=>t.value===e))&&g(e)}const y=e=>{const t=e.currentTarget,n=N.indexOf(t),a=d[n].value;g(a),null!=c&&(h(c,a),setTimeout((()=>{(function(e){const{top:t,left:n,bottom:a,right:s}=e.getBoundingClientRect(),{innerHeight:i,innerWidth:r}=window;return t>=0&&s<=r&&a<=i&&n>=0})(t)||(t.scrollIntoView({block:"center",behavior:"smooth"}),t.classList.add(o),setTimeout((()=>t.classList.remove(o)),2e3))}),150))},v=e=>{let t;switch(e.keyCode){case u:{const n=N.indexOf(e.target)+1;t=N[n]||N[0];break}case m:{const n=N.indexOf(e.target)-1;t=N[n]||N[N.length-1];break}default:return}t.focus()},f=(e,t)=>t.value===e||t.values&&-1!=t.values.indexOf(e);return a.createElement("div",{className:"tabs-container"},a.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:"tabs"},d.map((e=>{let{value:t,label:n}=e;return a.createElement("li",{role:"tab",tabIndex:C===t?0:-1,"aria-selected":C===t,className:(0,i.Z)("tabs__item",r,{"tabs__item--active":C===t}),key:t,ref:e=>e&&N.push(e),onKeyDown:v,onFocus:y,onClick:y},n)}))),t?a.cloneElement(k.find((e=>f(C,e.props))),{className:l}):a.createElement("div",null,k.map(((e,t)=>a.cloneElement(e,{key:t,hidden:!f(C,e.props),className:l})))),a.createElement("br",null))}},4028:(e,t,n)=>{n.r(t),n.d(t,{assets:()=>d,contentTitle:()=>m,default:()=>h,frontMatter:()=>l,metadata:()=>u,toc:()=>c});var a=n(7462),s=(n(7294),n(3905)),i=n(250),r=n(1016),o=(n(4996),n(4214));const l={},m="Creating a Custom Disaster",u={unversionedId:"dev/disasters/create-disaster",id:"dev/disasters/create-disaster",title:"Creating a Custom Disaster",description:"CustomDisaster class",source:"@site/docs/dev/disasters/create-disaster.mdx",sourceDirName:"dev/disasters",slug:"/dev/disasters/create-disaster",permalink:"/RogueLibs/docs/dev/disasters/create-disaster",draft:!1,editUrl:"https://github.com/SugarBarrel/RogueLibs/edit/main/website/docs/dev/disasters/create-disaster.mdx",tags:[],version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"Creating a Custom Interaction",permalink:"/RogueLibs/docs/dev/interactions/create-interaction"},next:{title:"Custom Unlocks",permalink:"/RogueLibs/docs/dev/unlocks/custom-unlocks"}},d={},c=[{value:"<code>CustomDisaster</code> class",id:"customdisaster",level:2},{value:"Disaster Conditions",id:"disaster-conditions",level:2},{value:"Disaster Settings",id:"disaster-settings",level:2},{value:"Initialization",id:"initialization",level:2},{value:"Examples",id:"examples",level:2}],p={toc:c};function h(e){let{components:t,...n}=e;return(0,s.kt)("wrapper",(0,a.Z)({},p,n,{components:t,mdxType:"MDXLayout"}),(0,s.kt)("h1",{id:"creating-a-custom-disaster"},"Creating a Custom Disaster"),(0,s.kt)("h2",{id:"customdisaster"},(0,s.kt)("inlineCode",{parentName:"h2"},"CustomDisaster")," class"),(0,s.kt)("p",null,"To make a custom disaster, you need to create a class deriving from ",(0,s.kt)("inlineCode",{parentName:"p"},"CustomDisaster"),":"),(0,s.kt)("pre",null,(0,s.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyCustomDisaster.cs"',title:'"MyCustomDisaster.cs"'},"// highlight-next-line\npublic class MyCustomDisaster : CustomDisaster\n{\n    /* ... */\n}\n")),(0,s.kt)("p",null,"There are 3 methods that you need to implement:"),(0,s.kt)("pre",null,(0,s.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyCustomDisaster.cs"',title:'"MyCustomDisaster.cs"'},"public class MyCustomDisaster : CustomDisaster\n{\n    // highlight-start\n    public override void Start() { /* ... */ }\n    public override void Finish() { /* ... */ }\n    public override IEnumerator? Updating() { /* ... */ }\n    // highlight-end\n}\n")),(0,s.kt)("p",null,(0,s.kt)("inlineCode",{parentName:"p"},"Start")," is called when the disaster starts. ",(0,s.kt)("inlineCode",{parentName:"p"},"Finish")," is called when the disaster ends."),(0,s.kt)("admonition",{type:"caution"},(0,s.kt)("mdxAdmonitionTitle",{parentName:"admonition"},(0,s.kt)("inlineCode",{parentName:"mdxAdmonitionTitle"},"Start")," and ",(0,s.kt)("inlineCode",{parentName:"mdxAdmonitionTitle"},"Finish")," methods"),(0,s.kt)("p",{parentName:"admonition"},"These methods are called between levels, so some stuff might not be available at the time they're called.")),(0,s.kt)("p",null,(0,s.kt)("inlineCode",{parentName:"p"},"Updating")," returns the updating coroutine for the disaster. It starts ",(0,s.kt)("strong",{parentName:"p"},"after the disaster's notification"),". It is stopped automatically, when the disaster ends. If your disaster doesn't need updating, you can just return ",(0,s.kt)("inlineCode",{parentName:"p"},"null"),"."),(0,s.kt)("h2",{id:"disaster-conditions"},"Disaster Conditions"),(0,s.kt)("p",null,"If you want your disaster to appear only under certain conditions, override the ",(0,s.kt)("inlineCode",{parentName:"p"},"Test")," method:"),(0,s.kt)("pre",null,(0,s.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyCustomDisaster.cs"',title:'"MyCustomDisaster.cs"'},"public class MyCustomDisaster : CustomDisaster\n{\n    // highlight-start\n    public override bool Test()\n    {\n        // for example, if it's a Park level\n        return CurrentDistrict == 2;\n    }\n    // highlight-end\n}\n")),(0,s.kt)("admonition",{type:"info"},(0,s.kt)("p",{parentName:"admonition"},(0,s.kt)("inlineCode",{parentName:"p"},"CustomDisaster")," exposes several useful properties for that:"),(0,s.kt)("ul",{parentName:"admonition"},(0,s.kt)("li",{parentName:"ul"},(0,s.kt)("inlineCode",{parentName:"li"},"CurrentDistrict")," - index of the current level's district.\n",(0,s.kt)("em",{parentName:"li"},"(",(0,s.kt)("inlineCode",{parentName:"em"},"0")," - Slums, ",(0,s.kt)("inlineCode",{parentName:"em"},"1")," - Industrial, ",(0,s.kt)("inlineCode",{parentName:"em"},"2")," - Park, ",(0,s.kt)("inlineCode",{parentName:"em"},"3")," - Downtown, ",(0,s.kt)("inlineCode",{parentName:"em"},"4")," - Uptown, ",(0,s.kt)("inlineCode",{parentName:"em"},"5")," - Mayor Village)")),(0,s.kt)("li",{parentName:"ul"},(0,s.kt)("inlineCode",{parentName:"li"},"CurrentFloor")," - index of the current level's floor of the district.\n",(0,s.kt)("em",{parentName:"li"},"(",(0,s.kt)("inlineCode",{parentName:"em"},"0"),", ",(0,s.kt)("inlineCode",{parentName:"em"},"1")," or ",(0,s.kt)("inlineCode",{parentName:"em"},"2")," in a normal playthrough, and ",(0,s.kt)("inlineCode",{parentName:"em"},"0")," or ",(0,s.kt)("inlineCode",{parentName:"em"},"1"),' with "Quick Game" mutator on)')),(0,s.kt)("li",{parentName:"ul"},(0,s.kt)("inlineCode",{parentName:"li"},"CurrentLevel")," - index of the current level.\n",(0,s.kt)("em",{parentName:"li"},"(",(0,s.kt)("inlineCode",{parentName:"em"},"0-2")," - Slums, ",(0,s.kt)("inlineCode",{parentName:"em"},"3-5")," - Industrial, ",(0,s.kt)("inlineCode",{parentName:"em"},"6-8")," - Park, ",(0,s.kt)("inlineCode",{parentName:"em"},"9-11")," - Downtown, ",(0,s.kt)("inlineCode",{parentName:"em"},"12-14")," - Uptown, ",(0,s.kt)("inlineCode",{parentName:"em"},"15")," - Mayor Village)"),(0,s.kt)("em",{parentName:"li"},"(or ",(0,s.kt)("inlineCode",{parentName:"em"},"0-1"),", ",(0,s.kt)("inlineCode",{parentName:"em"},"2-3"),", ",(0,s.kt)("inlineCode",{parentName:"em"},"4-5"),", ",(0,s.kt)("inlineCode",{parentName:"em"},"6-7"),", ",(0,s.kt)("inlineCode",{parentName:"em"},"8-9"),", ",(0,s.kt)("inlineCode",{parentName:"em"},"10")," if Quick Game is on), and more in Endless mode)")))),(0,s.kt)("p",null,"And, if you want to force your disaster onto a level, override the ",(0,s.kt)("inlineCode",{parentName:"p"},"TestForced")," method."),(0,s.kt)("pre",null,(0,s.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyCustomDisaster.cs"',title:'"MyCustomDisaster.cs"'},"public class MyCustomDisaster : CustomDisaster\n{\n    // highlight-start\n    public override bool TestForced()\n    {\n        // for example, if there's a Mayor on the level\n        return gc.agentList.Exists(a => a.agentName === VanillaAgents.Mayor);\n    }\n    // highlight-end\n}\n")),(0,s.kt)("admonition",{title:"Current limitations",type:"caution"},(0,s.kt)("p",{parentName:"admonition"},"At the moment, ",(0,s.kt)("inlineCode",{parentName:"p"},"TestForced")," cannot force a disaster onto a non-disastrous level. It only works on levels that normally have disasters: ","*","-3 (or ","*","-2 with Quick Game on), or every level with the Disasters Every Level mutator.")),(0,s.kt)("h2",{id:"disaster-settings"},"Disaster Settings"),(0,s.kt)("p",null,"Normally, you can't teleport during disasters, but you can change that by overriding the ",(0,s.kt)("inlineCode",{parentName:"p"},"AllowTeleport")," property:"),(0,s.kt)("pre",null,(0,s.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyCustomDisaster.cs"',title:'"MyCustomDisaster.cs"'},"public class MyCustomDisaster : CustomDisaster\n{\n    // highlight-start\n    public override bool AllowTeleport => true;\n    // highlight-end\n}\n")),(0,s.kt)("p",null,"The property is accessed constantly, so you can change the return value with time."),(0,s.kt)("h2",{id:"initialization"},"Initialization"),(0,s.kt)("p",null,"Just call the ",(0,s.kt)("inlineCode",{parentName:"p"},"CreateCustomDisaster")," method with your disaster's type as a parameter:"),(0,s.kt)("pre",null,(0,s.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyCustomDisaster.cs"',title:'"MyCustomDisaster.cs"'},"public class MyCustomDisaster : CustomDisaster\n{\n    [RLSetup]\n    public static void Setup()\n    {\n        // highlight-next-line\n        RogueLibs.CreateCustomDisaster<MyCustomDisaster>();\n    }\n}\n")),(0,s.kt)("admonition",{type:"note"},(0,s.kt)("p",{parentName:"admonition"},"See more about the ",(0,s.kt)("inlineCode",{parentName:"p"},"RLSetup")," attribute ",(0,s.kt)("a",{parentName:"p",href:"../patching-utilities#rlsetup"},"here"),".")),(0,s.kt)("p",null,"You can set your disaster's name and description using ",(0,s.kt)("inlineCode",{parentName:"p"},"WithName")," and ",(0,s.kt)("inlineCode",{parentName:"p"},"WithDescription")," methods:"),(0,s.kt)("pre",null,(0,s.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyCustomDisaster.cs"',title:'"MyCustomDisaster.cs"'},'public class MyCustomDisaster : CustomDisaster\n{\n    [RLSetup]\n    public static void Setup()\n    {\n        RogueLibs.CreateCustomDisaster<MyCustomDisaster>()\n            // highlight-start\n            .WithName(new CustomNameInfo("My Custom Disaster"))\n            .WithDescription(new CustomNameInfo("My Custom Disaster is very cool and does a lot of great stuff"));\n            // highlight-end\n    }\n}\n')),(0,s.kt)("p",null,"Plus, you can add two messages (they are displayed at the same time, on two lines):"),(0,s.kt)("pre",null,(0,s.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyCustomDisaster.cs"',title:'"MyCustomDisaster.cs"'},'public class MyCustomDisaster : CustomDisaster\n{\n    [RLSetup]\n    public static void Setup()\n    {\n        RogueLibs.CreateCustomDisaster<MyCustomDisaster>()\n            .WithName(new CustomNameInfo("My Custom Disaster"))\n            .WithDescription(new CustomNameInfo("My Custom Disaster is very cool and does a lot of great stuff"))\n            // highlight-start\n            .WithMessage(new CustomNameInfo("My Custom Disaster!"))\n            .WithMessage(new CustomNameInfo("Watch out for... uh, something dangerous!"));\n            // highlight-end\n    }\n}\n')),(0,s.kt)("admonition",{type:"info"},(0,s.kt)("p",{parentName:"admonition"},"See ",(0,s.kt)("a",{parentName:"p",href:"../names/custom-names"},"Custom Names")," for more info.")),(0,s.kt)("p",null,"You can also create a removal mutator automatically:"),(0,s.kt)("pre",null,(0,s.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyCustomDisaster.cs"',title:'"MyCustomDisaster.cs"'},'public class MyCustomDisaster : CustomDisaster\n{\n    [RLSetup]\n    public static void Setup()\n    {\n        RogueLibs.CreateCustomDisaster<MyCustomDisaster>()\n            .WithName(new CustomNameInfo("My Custom Disaster"))\n            .WithDescription(new CustomNameInfo("My Custom Disaster is very cool and does a lot of great stuff"))\n            .WithMessage(new CustomNameInfo("My Custom Disaster!"))\n            .WithMessage(new CustomNameInfo("Watch out for... uh, something dangerous!"))\n            // highlight-next-line\n            .WithRemovalMutator();\n    }\n}\n')),(0,s.kt)("h2",{id:"examples"},"Examples"),(0,s.kt)(i.Z,{defaultValue:"newhealthorder",values:[{label:"New Health Order",value:"newhealthorder"}],mdxType:"Tabs"},(0,s.kt)(r.Z,{value:"newhealthorder",mdxType:"TabItem"},(0,s.kt)("p",null,"A simple disaster that just gives everyone Resurrection after the notification."),(0,s.kt)(o.Z,{mdxType:"CodeSnippet"},'using System.Collections;\n\nnamespace RogueLibsCore.Test\n{\n    public class NewHealthOrder : CustomDisaster\n    {\n        [RLSetup]\n        public static void Setup()\n        {\n            RogueLibs.CreateCustomDisaster<NewHealthOrder>()\n                     .WithName(new CustomNameInfo\n                     {\n                         English = "New Health Order",\n                     })\n                     .WithDescription(new CustomNameInfo\n                     {\n                         English = "Where is this line used?!",\n                     })\n                     .WithMessage(new CustomNameInfo\n                     {\n                         English = "N.H.O. - New Health Order",\n                     })\n                     .WithMessage(new CustomNameInfo\n                     {\n                         English = "Resurrection for everyone!",\n                     })\n                     .WithRemovalMutator();\n        }\n\n        public override void Start() { }\n        public override void Finish() { }\n\n        public override IEnumerator Updating()\n        {\n            foreach (Agent agent in gc.agentList)\n                if (!agent.dead && !agent.electronic && !agent.inhuman)\n                {\n                    agent.statusEffects.AddStatusEffect(VanillaEffects.Resurrection, false);\n                }\n            yield break;\n        }\n    }\n}\n'))))}h.isMDXComponent=!0}}]);