(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[399],{4214:function(t,e,n){"use strict";n.d(e,{Z:function(){return r}});var i=n(7294),a=n(1756);function r(t){var e=t.children,n=t.language;return i.createElement(a.Z,{className:"language-"+(n||"csharp")},e.replace(/\t/g,"    "))}},9309:function(t,e,n){"use strict";n.d(e,{Z:function(){return o}});var i=n(2122),a=n(9756),r=n(7294),l=["children"];function o(t){var e=t.children,n=(0,a.Z)(t,l);return r.createElement("div",(0,i.Z)({role:"tabpanel"},n),e)}},8952:function(t,e,n){"use strict";n.d(e,{Z:function(){return d}});var i=n(7294),a=n(9443);var r=function(){var t=(0,i.useContext)(a.Z);if(null==t)throw new Error('"useUserPreferencesContext" is used outside of "Layout" component.');return t},l=n(6010),o="tabItem_2O3c",s="tabItemActive_Fpbe",u="tab_1pgU";var g=37,c=39;var d=function(t){var e=t.lazy,n=t.block,a=t.defaultValue,d=t.values,m=t.groupId,b=t.className,p=r(),h=p.tabGroupChoices,f=p.setTabGroupChoices,v=(0,i.useState)(a),C=v[0],y=v[1],k=i.Children.toArray(t.children),N=[];if(null!=m){var w=h[m];null!=w&&w!==C&&d.some((function(t){return t.value===w}))&&y(w)}var A=function(t){var e=t.currentTarget,n=N.indexOf(e),i=d[n].value;y(i),null!=m&&(f(m,i),setTimeout((function(){var t,n,i,a,r,l,o,u;(t=e.getBoundingClientRect(),n=t.top,i=t.left,a=t.bottom,r=t.right,l=window,o=l.innerHeight,u=l.innerWidth,n>=0&&r<=u&&a<=o&&i>=0)||(e.scrollIntoView({block:"center",behavior:"smooth"}),e.classList.add(s),setTimeout((function(){return e.classList.remove(s)}),2e3))}),150))},S=function(t){var e,n;switch(t.keyCode){case c:var i=N.indexOf(t.target)+1;n=N[i]||N[0];break;case g:var a=N.indexOf(t.target)-1;n=N[a]||N[N.length-1]}null==(e=n)||e.focus()},T=function(t,e){return e.value===t||e.values&&-1!=e.values.indexOf(t)};return i.createElement("div",{className:"tabs-container"},i.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:(0,l.Z)("tabs",{"tabs--block":n},b)},d.map((function(t){var e=t.value,n=t.label;return i.createElement("li",{role:"tab",tabIndex:C===e?0:-1,"aria-selected":C===e,className:(0,l.Z)("tabs__item",o,{"tabs__item--active":C===e}),key:e,ref:function(t){return N.push(t)},onKeyDown:S,onFocus:A,onClick:A},n)}))),e?(0,i.cloneElement)(k.filter((function(t){return T(C,t.props)}))[0],{className:u}):i.createElement("div",null,k.map((function(t,e){return(0,i.cloneElement)(t,{key:e,hidden:!T(C,t.props),className:u})}))),i.createElement("br",null))}},6866:function(t,e,n){"use strict";n.r(e),n.d(e,{contentTitle:function(){return c},default:function(){return p},frontMatter:function(){return g},metadata:function(){return d},toc:function(){return m}});var i=n(2122),a=n(9756),r=(n(7294),n(3905)),l=n(8952),o=n(9309),s=(n(4996),n(4214)),u=["components"],g={},c="Targetable Abilities",d={unversionedId:"dev/items/abilities/targetable-abilities",id:"dev/items/abilities/targetable-abilities",isDocsHomePage:!1,title:"Targetable Abilities",description:"Making abilities targetable",source:"@site/docs/dev/items/abilities/targetable-abilities.mdx",sourceDirName:"dev/items/abilities",slug:"/dev/items/abilities/targetable-abilities",permalink:"/RogueLibs/docs/dev/items/abilities/targetable-abilities",editUrl:"https://github.com/Abbysssal/RogueLibs/edit/master/website/docs/dev/items/abilities/targetable-abilities.mdx",version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"Chargeable Abilities",permalink:"/RogueLibs/docs/dev/items/abilities/chargeable-abilities"},next:{title:"Creating a Custom Trait",permalink:"/RogueLibs/docs/dev/traits/create-trait"}},m=[{value:"Making abilities targetable",id:"making-targetable",children:[]},{value:"Examples",id:"examples",children:[]}],b={toc:m};function p(t){var e=t.components,n=(0,a.Z)(t,u);return(0,r.kt)("wrapper",(0,i.Z)({},b,n,{components:e,mdxType:"MDXLayout"}),(0,r.kt)("h1",{id:"targetable-abilities"},"Targetable Abilities"),(0,r.kt)("h2",{id:"making-targetable"},"Making abilities targetable"),(0,r.kt)("p",null,"Just implement the ",(0,r.kt)("inlineCode",{parentName:"p"},"IAbilityTargetable")," interface in your ability's class:"),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyTargetableAbility.cs"',title:'"MyTargetableAbility.cs"'},"// highlight-next-line\npublic class MyTargetableAbility : CustomAbility, IAbilityTargetable\n{\n    // highlight-next-line\n    public PlayfieldObject FindTarget() { /* ... */ }\n}\n")),(0,r.kt)("p",null,(0,r.kt)("inlineCode",{parentName:"p"},"FindTarget")," determines the closest target, that the ability can be used on. An ability indicator will be displayed over that object. If the ability cannot be used right now, you should return ",(0,r.kt)("inlineCode",{parentName:"p"},"null"),"."),(0,r.kt)("p",null,"Then, you can use ",(0,r.kt)("inlineCode",{parentName:"p"},"CurrentTarget")," in any of the methods:"),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},'    public override void OnPressed()\n    {\n        if (CurrentTarget is null)\n        {\n            gc.audioHandler.Play(Owner, "CantDo");\n            return;\n        }\n        /* ... */\n    }\n')),(0,r.kt)("h2",{id:"examples"},"Examples"),(0,r.kt)(l.Z,{defaultValue:"hug",values:[{label:"Hug",value:"hug"}],mdxType:"Tabs"},(0,r.kt)(o.Z,{value:"hug",mdxType:"TabItem"},(0,r.kt)(s.Z,{mdxType:"CodeSnippet"},'using System.Collections.Generic;\nusing System.Linq;\nusing UnityEngine;\n\nnamespace RogueLibsCore.Test\n{\n\tpublic class Hug : CustomAbility, IAbilityTargetable\n\t{\n\t\t[RLSetup]\n\t\tpublic static void Setup()\n\t\t{\n\t\t\tRogueLibs.CreateCustomAbility<Hug>()\n\t\t\t\t.WithName(new CustomNameInfo("Hug"))\n\t\t\t\t.WithDescription(new CustomNameInfo("Sneak up behind people. And HUG THEM!!"))\n\t\t\t\t.WithSprite(Properties.Resources.Hug)\n\t\t\t\t.WithUnlock(new AbilityUnlock { UnlockCost = 5, CharacterCreationCost = 5, });\n\n\t\t\tRogueLibs.CreateCustomName("HugNegative1", "Dialogue", new CustomNameInfo("Huh? What are you doing?"));\n\t\t\tRogueLibs.CreateCustomName("HugNegative2", "Dialogue", new CustomNameInfo("Excuse me?!"));\n\t\t\tRogueLibs.CreateCustomName("HugNegative3", "Dialogue", new CustomNameInfo("Stop it!"));\n\t\t\tRogueLibs.CreateCustomName("HugPositive1", "Dialogue", new CustomNameInfo("Oh.. Thanks."));\n\t\t\tRogueLibs.CreateCustomName("HugPositive2", "Dialogue", new CustomNameInfo("Um.. Okay.."));\n\t\t\tRogueLibs.CreateCustomName("HugPositive3", "Dialogue", new CustomNameInfo("?.."));\n\t\t\tRogueLibs.CreateCustomName("HugForgive1", "Dialogue", new CustomNameInfo("Oh.. Okay, I forgive you."));\n\t\t\tRogueLibs.CreateCustomName("HugForgive2", "Dialogue", new CustomNameInfo("Alright, I forgive you."));\n\t\t\tRogueLibs.CreateCustomName("HugForgive3", "Dialogue", new CustomNameInfo("Okay... Don\'t worry about that.."));\n\t\t}\n\n\t\tpublic override void OnAdded() { }\n\t\tpublic PlayfieldObject FindTarget()\n\t\t{\n\t\t\tAgent closest = null;\n\t\t\tfloat distance = float.MaxValue;\n\t\t\tforeach (Agent agent in Owner.interactionHelper.TriggerList\n\t\t\t\t.Where(go => go.CompareTag("AgentSprite")).Select(go => go.GetComponent<ObjectSprite>().agent))\n\t\t\t{\n\t\t\t\tif (!huggedList.Contains(agent) && !agent.dead && !agent.ghost && !Owner.ghost && !agent.hologram && agent.go.activeSelf && !agent.mechFilled && !agent.mechEmpty)\n\t\t\t\t{\n\t\t\t\t\tfloat dist = Vector2.Distance(Owner.curPosition, agent.curPosition);\n\t\t\t\t\tif (dist < distance)\n\t\t\t\t\t{\n\t\t\t\t\t\tclosest = agent;\n\t\t\t\t\t\tdistance = dist;\n\t\t\t\t\t}\n\t\t\t\t}\n\t\t\t}\n\t\t\treturn closest;\n\t\t}\n\t\tprivate readonly List<Agent> huggedList = new List<Agent>();\n\t\tpublic override void OnPressed()\n\t\t{\n\t\t\tif (CurrentTarget is null)\n\t\t\t{\n\t\t\t\tgc.audioHandler.Play(Owner, "CantDo");\n}\n\t\t\telse\n\t\t\t{\n\t\t\t\tAgent target = (Agent)CurrentTarget;\n\t\t\t\tint rnd = new System.Random().Next(3) + 1;\n\n\t\t\t\trelStatus code = target.relationships.GetRelCode(Owner);\n\t\t\t\tif (code == relStatus.Friendly || code == relStatus.Submissive)\n\t\t\t\t{\n\t\t\t\t\ttarget.SayDialogue("HugPositive" + rnd);\n\t\t\t\t\ttarget.relationships.SetRel(Owner, "Loyal");\n\t\t\t\t}\n\t\t\t\telse if (code == relStatus.Loyal)\n\t\t\t\t{\n\t\t\t\t\ttarget.SayDialogue("HugPositive" + rnd);\n\t\t\t\t\ttarget.relationships.SetRel(Owner, "Aligned");\n\t\t\t\t}\n\t\t\t\telse if (code == relStatus.Aligned)\n\t\t\t\t{\n\t\t\t\t\ttarget.SayDialogue("HugPositive" + rnd);\n\t\t\t\t}\n\t\t\t\telse if (code == relStatus.Neutral)\n\t\t\t\t{\n\t\t\t\t\ttarget.SayDialogue("HugNegative" + rnd);\n\t\t\t\t\ttarget.relationships.SetRel(Owner, "Annoyed");\n\t\t\t\t\ttarget.relationships.SetStrikes(Owner, 2);\n\t\t\t\t\ttarget.statusEffects.annoyeders.Add(Owner);\n\t\t\t\t\tgc.audioHandler.Play(target, "AgentAnnoyed");\n\t\t\t\t\treturn;\n\t\t\t\t}\n\t\t\t\telse if (code == relStatus.Annoyed)\n\t\t\t\t{\n\t\t\t\t\ttarget.SayDialogue("HugForgive" + rnd);\n\t\t\t\t\ttarget.relationships.SetRel(Owner, "Neutral");\n\t\t\t\t}\n\t\t\t\telse if (code == relStatus.Hostile)\n\t\t\t\t{\n\t\t\t\t\treturn;\n\t\t\t\t}\n\t\t\t\ttarget.relationships.SetStrikes(Owner, 0);\n\t\t\t\tgc.audioHandler.Play(target, "AgentOK");\n\t\t\t\thuggedList.Add(target);\n\t\t\t}\n\t\t}\n\t}\n}\n'))))}p.isMDXComponent=!0}}]);