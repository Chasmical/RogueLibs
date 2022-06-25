"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[6688],{4214:(e,t,n)=>{n.d(t,{Z:()=>s});var a=n(7294),i=n(3066);function s(e){let{children:t,language:n}=e;return a.createElement(i.Z,{className:"language-"+(n||"csharp")},t.replace(/\t/g,"    "))}},1016:(e,t,n)=>{n.d(t,{Z:()=>s});var a=n(7462),i=n(7294);function s(e){let{children:t,...n}=e;return i.createElement("div",(0,a.Z)({role:"tabpanel"},n),t)}},250:(e,t,n)=>{n.d(t,{Z:()=>d});var a=n(7294),i=n(7094),s=n(6010);const l="tabItem_V91s",r="tabItemActive_JsUu",o="tab_ntnM";const u=37,g=39;function d(e){const{lazy:t,defaultValue:n,values:d,groupId:c}=e,{tabGroupChoices:m,setTabGroupChoices:b}=(0,i.U)(),[p,h]=(0,a.useState)(n),y=a.Children.toArray(e.children),v=[];if(null!=c){const e=m[c];null!=e&&e!==p&&d.some((t=>t.value===e))&&h(e)}const C=e=>{const t=e.currentTarget,n=v.indexOf(t),a=d[n].value;h(a),null!=c&&(b(c,a),setTimeout((()=>{(function(e){const{top:t,left:n,bottom:a,right:i}=e.getBoundingClientRect(),{innerHeight:s,innerWidth:l}=window;return t>=0&&i<=l&&a<=s&&n>=0})(t)||(t.scrollIntoView({block:"center",behavior:"smooth"}),t.classList.add(r),setTimeout((()=>t.classList.remove(r)),2e3))}),150))},f=e=>{let t;switch(e.keyCode){case g:{const n=v.indexOf(e.target)+1;t=v[n]||v[0];break}case u:{const n=v.indexOf(e.target)-1;t=v[n]||v[v.length-1];break}default:return}t.focus()},N=(e,t)=>t.value===e||t.values&&-1!=t.values.indexOf(e);return a.createElement("div",{className:"tabs-container"},a.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:"tabs"},d.map((e=>{let{value:t,label:n}=e;return a.createElement("li",{role:"tab",tabIndex:p===t?0:-1,"aria-selected":p===t,className:(0,s.Z)("tabs__item",l,{"tabs__item--active":p===t}),key:t,ref:e=>e&&v.push(e),onKeyDown:f,onFocus:C,onClick:C},n)}))),t?a.cloneElement(y.find((e=>N(p,e.props))),{className:o}):a.createElement("div",null,y.map(((e,t)=>a.cloneElement(e,{key:t,hidden:!N(p,e.props),className:o})))),a.createElement("br",null))}},3032:(e,t,n)=>{n.r(t),n.d(t,{assets:()=>d,contentTitle:()=>u,default:()=>b,frontMatter:()=>o,metadata:()=>g,toc:()=>c});var a=n(7462),i=(n(7294),n(3905)),s=n(250),l=n(1016),r=(n(4996),n(4214));const o={},u="\u041d\u0430\u043f\u0440\u0430\u0432\u043b\u044f\u0435\u043c\u044b\u0435 \u0441\u043f\u043e\u0441\u043e\u0431\u043d\u043e\u0441\u0442\u0438",g={unversionedId:"dev/items/abilities/targetable-abilities",id:"dev/items/abilities/targetable-abilities",title:"\u041d\u0430\u043f\u0440\u0430\u0432\u043b\u044f\u0435\u043c\u044b\u0435 \u0441\u043f\u043e\u0441\u043e\u0431\u043d\u043e\u0441\u0442\u0438",description:"\u0414\u0435\u043b\u0430\u0435\u043c \u0441\u043f\u043e\u0441\u043e\u0431\u043d\u043e\u0441\u0442\u0438 \u043d\u0430\u043f\u0440\u0430\u0432\u043b\u044f\u0435\u043c\u044b\u043c\u0438",source:"@site/i18n/ru/docusaurus-plugin-content-docs/current/dev/items/abilities/targetable-abilities.mdx",sourceDirName:"dev/items/abilities",slug:"/dev/items/abilities/targetable-abilities",permalink:"/RogueLibs/ru/docs/dev/items/abilities/targetable-abilities",draft:!1,editUrl:"https://github.com/SugarBarrel/RogueLibs/edit/main/website/docs/dev/items/abilities/targetable-abilities.mdx",tags:[],version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"\u0417\u0430\u0440\u044f\u0436\u0430\u0435\u043c\u044b\u0435 \u0441\u043f\u043e\u0441\u043e\u0431\u043d\u043e\u0441\u0442\u0438",permalink:"/RogueLibs/ru/docs/dev/items/abilities/chargeable-abilities"},next:{title:"\u0421\u043e\u0437\u0434\u0430\u0451\u043c \u043a\u0430\u0441\u0442\u043e\u043c\u043d\u0443\u044e \u043e\u0441\u043e\u0431\u0435\u043d\u043d\u043e\u0441\u0442\u044c",permalink:"/RogueLibs/ru/docs/dev/traits/create-trait"}},d={},c=[{value:"\u0414\u0435\u043b\u0430\u0435\u043c \u0441\u043f\u043e\u0441\u043e\u0431\u043d\u043e\u0441\u0442\u0438 \u043d\u0430\u043f\u0440\u0430\u0432\u043b\u044f\u0435\u043c\u044b\u043c\u0438",id:"making-targetable",level:2},{value:"\u041f\u0440\u0438\u043c\u0435\u0440\u044b",id:"examples",level:2}],m={toc:c};function b(e){let{components:t,...n}=e;return(0,i.kt)("wrapper",(0,a.Z)({},m,n,{components:t,mdxType:"MDXLayout"}),(0,i.kt)("h1",{id:"\u043d\u0430\u043f\u0440\u0430\u0432\u043b\u044f\u0435\u043c\u044b\u0435-\u0441\u043f\u043e\u0441\u043e\u0431\u043d\u043e\u0441\u0442\u0438"},"\u041d\u0430\u043f\u0440\u0430\u0432\u043b\u044f\u0435\u043c\u044b\u0435 \u0441\u043f\u043e\u0441\u043e\u0431\u043d\u043e\u0441\u0442\u0438"),(0,i.kt)("h2",{id:"making-targetable"},"\u0414\u0435\u043b\u0430\u0435\u043c \u0441\u043f\u043e\u0441\u043e\u0431\u043d\u043e\u0441\u0442\u0438 \u043d\u0430\u043f\u0440\u0430\u0432\u043b\u044f\u0435\u043c\u044b\u043c\u0438"),(0,i.kt)("p",null,"\u041f\u0440\u043e\u0441\u0442\u043e \u0440\u0435\u0430\u043b\u0438\u0437\u0443\u0439\u0442\u0435 \u0438\u043d\u0442\u0435\u0440\u0444\u0435\u0439\u0441 ",(0,i.kt)("inlineCode",{parentName:"p"},"IAbilityTargetable")," \u0432 \u043a\u043b\u0430\u0441\u0441\u0435 \u0432\u0430\u0448\u0435\u0439 \u0441\u043f\u043e\u0441\u043e\u0431\u043d\u043e\u0441\u0442\u0438:"),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyTargetableAbility.cs"',title:'"MyTargetableAbility.cs"'},"// highlight-next-line\npublic class MyTargetableAbility : CustomAbility, IAbilityTargetable\n{\n    // highlight-next-line\n    public PlayfieldObject FindTarget() { /* ... */ }\n}\n")),(0,i.kt)("p",null,(0,i.kt)("inlineCode",{parentName:"p"},"FindTarget")," \u043e\u043f\u0440\u0435\u0434\u0435\u043b\u044f\u0435\u0442 \u0431\u043b\u0438\u0436\u0430\u0439\u0448\u0443\u044e \u0446\u0435\u043b\u044c, \u043d\u0430 \u043a\u043e\u0442\u043e\u0440\u043e\u0439 \u043c\u043e\u0436\u043d\u043e \u0438\u0441\u043f\u043e\u043b\u044c\u0437\u043e\u0432\u0430\u0442\u044c \u0441\u043f\u043e\u0441\u043e\u0431\u043d\u043e\u0441\u0442\u044c. \u0418\u043d\u0434\u0438\u043a\u0430\u0442\u043e\u0440 \u0441\u043f\u043e\u0441\u043e\u0431\u043d\u043e\u0441\u0442\u0438 \u0431\u0443\u0434\u0435\u0442 \u043e\u0442\u043e\u0431\u0440\u0430\u0436\u0451\u043d \u043d\u0430\u0434 \u044d\u0442\u0438\u043c \u043e\u0431\u044a\u0435\u043a\u0442\u043e\u043c. \u0415\u0441\u043b\u0438 \u0441\u043f\u043e\u0441\u043e\u0431\u043d\u043e\u0441\u0442\u044c \u043d\u0435 \u043c\u043e\u0436\u0435\u0442 \u0431\u044b\u0442\u044c \u0438\u0441\u043f\u043e\u043b\u044c\u0437\u043e\u0432\u0430\u043d\u0430 \u0441\u0435\u0439\u0447\u0430\u0441, \u0432\u043e\u0437\u0432\u0440\u0430\u0449\u0430\u0439\u0442\u0435 ",(0,i.kt)("inlineCode",{parentName:"p"},"null"),"."),(0,i.kt)("p",null,"\u041f\u043e\u0442\u043e\u043c \u0432\u044b \u043c\u043e\u0436\u0435\u0442\u0435 \u0438\u0441\u043f\u043e\u043b\u044c\u0437\u043e\u0432\u0430\u0442\u044c ",(0,i.kt)("inlineCode",{parentName:"p"},"CurrentTarget")," \u0432 \u043b\u044e\u0431\u043e\u043c \u0438\u0437 \u043c\u0435\u0442\u043e\u0434\u043e\u0432:"),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-csharp"},'    public override void OnPressed()\n    {\n        if (CurrentTarget is null)\n        {\n            gc.audioHandler.Play(Owner, "CantDo");\n            return;\n        }\n        /* ... */\n    }\n')),(0,i.kt)("h2",{id:"examples"},"\u041f\u0440\u0438\u043c\u0435\u0440\u044b"),(0,i.kt)(s.Z,{defaultValue:"hug",values:[{label:"\u041e\u0431\u043d\u0438\u043c\u0430\u0448\u043a\u0438",value:"hug"}],mdxType:"Tabs"},(0,i.kt)(l.Z,{value:"hug",mdxType:"TabItem"},(0,i.kt)(r.Z,{mdxType:"CodeSnippet"},'using System.Collections.Generic;\nusing System.Linq;\nusing UnityEngine;\n\nnamespace RogueLibsCore.Test\n{\n    public class Hug : CustomAbility, IAbilityTargetable\n    {\n        [RLSetup]\n        public static void Setup()\n        {\n            RogueLibs.CreateCustomAbility<Hug>()\n                .WithName(new CustomNameInfo("Hug"))\n                .WithDescription(new CustomNameInfo("Sneak up behind people. And HUG THEM!!"))\n                .WithSprite(Properties.Resources.Hug)\n                .WithUnlock(new AbilityUnlock { UnlockCost = 5, CharacterCreationCost = 5 });\n\n            RogueLibs.CreateCustomName("HugNegative1", NameTypes.Dialogue, new CustomNameInfo("Huh? What are you doing?"));\n            RogueLibs.CreateCustomName("HugNegative2", NameTypes.Dialogue, new CustomNameInfo("Excuse me?!"));\n            RogueLibs.CreateCustomName("HugNegative3", NameTypes.Dialogue, new CustomNameInfo("Stop it!"));\n            RogueLibs.CreateCustomName("HugPositive1", NameTypes.Dialogue, new CustomNameInfo("Oh.. Thanks."));\n            RogueLibs.CreateCustomName("HugPositive2", NameTypes.Dialogue, new CustomNameInfo("Um.. Okay.."));\n            RogueLibs.CreateCustomName("HugPositive3", NameTypes.Dialogue, new CustomNameInfo("?.."));\n            RogueLibs.CreateCustomName("HugForgive1", NameTypes.Dialogue, new CustomNameInfo("Oh.. Okay, I forgive you."));\n            RogueLibs.CreateCustomName("HugForgive2", NameTypes.Dialogue, new CustomNameInfo("Alright, I forgive you."));\n            RogueLibs.CreateCustomName("HugForgive3", NameTypes.Dialogue, new CustomNameInfo("Okay... Don\'t worry about that.."));\n        }\n\n        public override void OnAdded() { }\n        public PlayfieldObject? FindTarget()\n        {\n            Agent? closest = null;\n            float distance = float.MaxValue;\n            foreach (Agent agent in Owner.interactionHelper.TriggerList\n                .Where(static go => go.CompareTag("AgentSprite"))\n                .Select(static go => go.GetComponent<ObjectSprite>().agent))\n            {\n                if (!huggedList.Contains(agent) && !agent.dead && !agent.ghost && !Owner.ghost && !agent.hologram\n                    && agent.go.activeSelf && !agent.mechFilled && !agent.mechEmpty)\n                {\n                    float dist = Vector2.Distance(Owner.curPosition, agent.curPosition);\n                    if (dist < distance)\n                    {\n                        closest = agent;\n                        distance = dist;\n                    }\n                }\n            }\n            return closest;\n        }\n        private readonly List<Agent> huggedList = new List<Agent>();\n        public override void OnPressed()\n        {\n            if (CurrentTarget is null)\n            {\n                gc.audioHandler.Play(Owner, VanillaAudio.CantDo);\n            }\n            else\n            {\n                Agent target = (Agent)CurrentTarget;\n                int rnd = new System.Random().Next(3) + 1;\n\n                relStatus code = target.relationships.GetRelCode(Owner);\n                if (code is relStatus.Friendly or relStatus.Submissive)\n                {\n                    target.SayDialogue("HugPositive" + rnd);\n                    target.relationships.SetRel(Owner, "Loyal");\n                }\n                else if (code == relStatus.Loyal)\n                {\n                    target.SayDialogue("HugPositive" + rnd);\n                    target.relationships.SetRel(Owner, "Aligned");\n                }\n                else if (code == relStatus.Aligned)\n                {\n                    target.SayDialogue("HugPositive" + rnd);\n                }\n                else if (code == relStatus.Neutral)\n                {\n                    target.SayDialogue("HugNegative" + rnd);\n                    target.relationships.SetRel(Owner, "Annoyed");\n                    target.relationships.SetStrikes(Owner, 2);\n                    target.statusEffects.annoyeders.Add(Owner);\n                    gc.audioHandler.Play(target, VanillaAudio.AgentAnnoyed);\n                    return;\n                }\n                else if (code == relStatus.Annoyed)\n                {\n                    target.SayDialogue("HugForgive" + rnd);\n                    target.relationships.SetRel(Owner, "Neutral");\n                }\n                else if (code == relStatus.Hostile)\n                {\n                    return;\n                }\n                target.relationships.SetStrikes(Owner, 0);\n                gc.audioHandler.Play(target, VanillaAudio.AgentOK);\n                huggedList.Add(target);\n            }\n        }\n    }\n}\n'))))}b.isMDXComponent=!0}}]);