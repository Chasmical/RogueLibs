"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[5333],{4214:(e,t,i)=>{i.d(t,{Z:()=>l});var a=i(7294),n=i(814);function l(e){let{children:t,language:i}=e;return a.createElement(n.Z,{className:"language-"+(i||"csharp")},t.replace(/\t/g,"    "))}},1016:(e,t,i)=>{i.d(t,{Z:()=>l});var a=i(7462),n=i(7294);function l(e){let{children:t,...i}=e;return n.createElement("div",(0,a.Z)({role:"tabpanel"},i),t)}},250:(e,t,i)=>{i.d(t,{Z:()=>d});var a=i(7294),n=i(7094),l=i(6010);const r="tabItem_V91s",s="tabItemActive_JsUu",o="tab_ntnM";const c=37,u=39;function d(e){const{lazy:t,defaultValue:i,values:d,groupId:m}=e,{tabGroupChoices:b,setTabGroupChoices:g}=(0,n.U)(),[h,p]=(0,a.useState)(i),f=a.Children.toArray(e.children),k=[];if(null!=m){const e=b[m];null!=e&&e!==h&&d.some((t=>t.value===e))&&p(e)}const y=e=>{const t=e.currentTarget,i=k.indexOf(t),a=d[i].value;p(a),null!=m&&(g(m,a),setTimeout((()=>{(function(e){const{top:t,left:i,bottom:a,right:n}=e.getBoundingClientRect(),{innerHeight:l,innerWidth:r}=window;return t>=0&&n<=r&&a<=l&&i>=0})(t)||(t.scrollIntoView({block:"center",behavior:"smooth"}),t.classList.add(s),setTimeout((()=>t.classList.remove(s)),2e3))}),150))},v=e=>{let t;switch(e.keyCode){case u:{const i=k.indexOf(e.target)+1;t=k[i]||k[0];break}case c:{const i=k.indexOf(e.target)-1;t=k[i]||k[k.length-1];break}default:return}t.focus()},C=(e,t)=>t.value===e||t.values&&-1!=t.values.indexOf(e);return a.createElement("div",{className:"tabs-container"},a.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:"tabs"},d.map((e=>{let{value:t,label:i}=e;return a.createElement("li",{role:"tab",tabIndex:h===t?0:-1,"aria-selected":h===t,className:(0,l.Z)("tabs__item",r,{"tabs__item--active":h===t}),key:t,ref:e=>e&&k.push(e),onKeyDown:v,onFocus:y,onClick:y},i)}))),t?a.cloneElement(f.find((e=>C(h,e.props))),{className:o}):a.createElement("div",null,f.map(((e,t)=>a.cloneElement(e,{key:t,hidden:!C(h,e.props),className:o})))),a.createElement("br",null))}},6038:(e,t,i)=>{i.r(t),i.d(t,{assets:()=>d,contentTitle:()=>c,default:()=>g,frontMatter:()=>o,metadata:()=>u,toc:()=>m});var a=i(7462),n=(i(7294),i(3905)),l=i(250),r=i(1016),s=(i(4996),i(4214));const o={},c="Rechargeable Abilities",u={unversionedId:"dev/items/abilities/rechargeable-abilities",id:"dev/items/abilities/rechargeable-abilities",title:"Rechargeable Abilities",description:"Custom abilities can be made rechargeable by implementing the IAbilityRechargeable interface. Ability's Count here works as a cooldown and usually represents the amount of time to wait until full recharge. This interface makes use of some of the game's recharging mechanics, but it doesn't completely rely on it. I'd recommend taking a look at Recharging Items, if you need finer control.",source:"@site/docs/dev/items/abilities/rechargeable-abilities.mdx",sourceDirName:"dev/items/abilities",slug:"/dev/items/abilities/rechargeable-abilities",permalink:"/RogueLibs/docs/dev/items/abilities/rechargeable-abilities",draft:!1,editUrl:"https://github.com/SugarBarrel/RogueLibs/edit/main/website/docs/dev/items/abilities/rechargeable-abilities.mdx",tags:[],version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"Creating a Custom Ability",permalink:"/RogueLibs/docs/dev/items/abilities/create-ability"},next:{title:"Chargeable Abilities",permalink:"/RogueLibs/docs/dev/items/abilities/chargeable-abilities"}},d={},m=[{value:"Making abilities rechargeable",id:"making-rechargeable",level:2},{value:"Examples",id:"examples",level:2}],b={toc:m};function g(e){let{components:t,...i}=e;return(0,n.kt)("wrapper",(0,a.Z)({},b,i,{components:t,mdxType:"MDXLayout"}),(0,n.kt)("h1",{id:"rechargeable-abilities"},"Rechargeable Abilities"),(0,n.kt)("p",null,"Custom abilities can be made rechargeable by implementing the ",(0,n.kt)("inlineCode",{parentName:"p"},"IAbilityRechargeable")," interface. Ability's ",(0,n.kt)("inlineCode",{parentName:"p"},"Count")," here works as a cooldown and usually represents the amount of time to wait until full recharge. This interface makes use of some of the game's recharging mechanics, but it doesn't completely rely on it. I'd recommend taking a look at ",(0,n.kt)("a",{parentName:"p",href:"/RogueLibs/docs/dev/items/recharging-items"},"Recharging Items"),", if you need finer control."),(0,n.kt)("h2",{id:"making-rechargeable"},"Making abilities rechargeable"),(0,n.kt)("p",null,"Just implement the ",(0,n.kt)("inlineCode",{parentName:"p"},"IAbilityRechargeable")," interface in your ability's class:"),(0,n.kt)("pre",null,(0,n.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyRechargeableAbility.cs"',title:'"MyRechargeableAbility.cs"'},"// highlight-next-line\npublic class MyRechargeableAbility : CustomAbility, IAbilityRechargeable\n{\n    // highlight-next-line\n    public void OnRecharging(AbilityRechargingArgs e) { /* ... */ }\n}\n")),(0,n.kt)("admonition",{title:"Pro-tip",type:"tip"},(0,n.kt)("p",{parentName:"admonition"},"You can just set it to 0 when it's fully recharged and to 1 when it's recharging (you can override the displayed count if you want), and use your own cooldown mechanism instead. See ",(0,n.kt)("a",{parentName:"p",href:"../recharging-items"},"Recharging Items")," for more info.")),(0,n.kt)("p",null,(0,n.kt)("inlineCode",{parentName:"p"},"OnRecharging")," works like Unity's ",(0,n.kt)("inlineCode",{parentName:"p"},"Update"),", but with a settable interval (default is 1 second):"),(0,n.kt)("pre",null,(0,n.kt)("code",{parentName:"pre",className:"language-csharp"},"    public void OnRecharging(AbilityRechargingArgs e)\n    {\n        // highlight-next-line\n        e.UpdateDelay = 2f; // 1 update every 2 seconds\n        Count--;\n    }\n")),(0,n.kt)("admonition",{type:"info"},(0,n.kt)("p",{parentName:"admonition"},"You're responsible for decrementing the ability's ",(0,n.kt)("inlineCode",{parentName:"p"},"Count"),". So, don't forget to do that.",(0,n.kt)("br",{parentName:"p"}),"\n","Ability will stop recharging when ",(0,n.kt)("inlineCode",{parentName:"p"},"Count")," reaches 0. To start recharging again, just set ",(0,n.kt)("inlineCode",{parentName:"p"},"Count")," to any other value.")),(0,n.kt)("h2",{id:"examples"},"Examples"),(0,n.kt)(l.Z,{defaultValue:"titan",values:[{label:"Titan",value:"titan"}],mdxType:"Tabs"},(0,n.kt)(r.Z,{value:"titan",mdxType:"TabItem"},(0,n.kt)(s.Z,{mdxType:"CodeSnippet"},'namespace RogueLibsCore.Test\n{\n    public class Titan : CustomAbility, IAbilityRechargeable\n    {\n        [RLSetup]\n        public static void Setup()\n        {\n            RogueLibs.CreateCustomAbility<Titan>()\n                .WithName(new CustomNameInfo("Titan"))\n                .WithDescription(new CustomNameInfo("Willpower alone isn\'t enough in battle."))\n                .WithSprite(Properties.Resources.Titan)\n                .WithUnlock(new AbilityUnlock\n                {\n                    UnlockCost = 10,\n                    CharacterCreationCost = 10,\n                    Prerequisites = { VanillaItems.Giantizer },\n                });\n        }\n\n        public override void OnAdded() { }\n        public override void OnPressed()\n        {\n            if (Count != 0)\n            {\n                gc.audioHandler.Play(Owner, VanillaAudio.CantDo);\n                return;\n            }\n            Owner!.statusEffects.AddStatusEffect(VanillaEffects.Giant, 15);\n            Count = 30;\n        }\n        public void OnRecharging(AbilityRechargingArgs e)\n        {\n            e.UpdateDelay = 1f;\n            Count--;\n        }\n    }\n}\n'))))}g.isMDXComponent=!0}}]);