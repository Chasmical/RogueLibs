"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[5333],{4214:function(e,t,n){n.d(t,{Z:function(){return r}});var i=n(7294),a=n(9055);function r(e){var t=e.children,n=e.language;return i.createElement(a.Z,{className:"language-"+(n||"csharp")},t.replace(/\t/g,"    "))}},1016:function(e,t,n){n.d(t,{Z:function(){return s}});var i=n(7462),a=n(3366),r=n(7294),l=["children"];function s(e){var t=e.children,n=(0,a.Z)(e,l);return r.createElement("div",(0,i.Z)({role:"tabpanel"},n),t)}},2099:function(e,t,n){n.d(t,{Z:function(){return m}});var i=n(7294),a=n(9443);var r=function(){var e=(0,i.useContext)(a.Z);if(null==e)throw new Error('"useUserPreferencesContext" is used outside of "Layout" component.');return e},l=n(6010),s="tabItem_OdQc",o="tabItemActive_YQWB",c="tab_tgHH";var u=37,d=39;function m(e){var t=e.lazy,n=e.defaultValue,a=e.values,m=e.groupId,p=r(),b=p.tabGroupChoices,h=p.setTabGroupChoices,g=(0,i.useState)(n),v=g[0],f=g[1],k=i.Children.toArray(e.children),y=[];if(null!=m){var C=b[m];null!=C&&C!==v&&a.some((function(e){return e.value===C}))&&f(C)}var N=function(e){var t=e.currentTarget,n=y.indexOf(t),i=a[n].value;f(i),null!=m&&(h(m,i),setTimeout((function(){var e,n,i,a,r,l,s,c;(e=t.getBoundingClientRect(),n=e.top,i=e.left,a=e.bottom,r=e.right,l=window,s=l.innerHeight,c=l.innerWidth,n>=0&&r<=c&&a<=s&&i>=0)||(t.scrollIntoView({block:"center",behavior:"smooth"}),t.classList.add(o),setTimeout((function(){return t.classList.remove(o)}),2e3))}),150))},w=function(e){var t;switch(e.keyCode){case d:var n=y.indexOf(e.target)+1;t=y[n]||y[0];break;case u:var i=y.indexOf(e.target)-1;t=y[i]||y[y.length-1];break;default:return}t.focus()},A=function(e,t){return t.value===e||t.values&&-1!=t.values.indexOf(e)};return i.createElement("div",{className:"tabs-container"},i.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:"tabs"},a.map((function(e){var t=e.value,n=e.label;return i.createElement("li",{role:"tab",tabIndex:v===t?0:-1,"aria-selected":v===t,className:(0,l.Z)("tabs__item",s,{"tabs__item--active":v===t}),key:t,ref:function(e){return e&&y.push(e)},onKeyDown:w,onFocus:N,onClick:N},n)}))),t?i.cloneElement(k.find((function(e){return A(v,e.props)})),{className:c}):i.createElement("div",null,k.map((function(e,t){return i.cloneElement(e,{key:t,hidden:!A(v,e.props),className:c})}))),i.createElement("br",null))}},6038:function(e,t,n){n.r(t),n.d(t,{contentTitle:function(){return d},default:function(){return h},frontMatter:function(){return u},metadata:function(){return m},toc:function(){return p}});var i=n(7462),a=n(3366),r=(n(7294),n(3905)),l=n(2099),s=n(1016),o=(n(4996),n(4214)),c=["components"],u={},d="Rechargeable Abilities",m={unversionedId:"dev/items/abilities/rechargeable-abilities",id:"dev/items/abilities/rechargeable-abilities",title:"Rechargeable Abilities",description:"Making abilities rechargeable",source:"@site/docs/dev/items/abilities/rechargeable-abilities.mdx",sourceDirName:"dev/items/abilities",slug:"/dev/items/abilities/rechargeable-abilities",permalink:"/RogueLibs/docs/dev/items/abilities/rechargeable-abilities",editUrl:"https://github.com/Abbysssal/RogueLibs/edit/main/website/docs/dev/items/abilities/rechargeable-abilities.mdx",tags:[],version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"Creating a Custom Ability",permalink:"/RogueLibs/docs/dev/items/abilities/create-ability"},next:{title:"Chargeable Abilities",permalink:"/RogueLibs/docs/dev/items/abilities/chargeable-abilities"}},p=[{value:"Making abilities rechargeable",id:"making-rechargeable",children:[],level:2},{value:"Examples",id:"examples",children:[],level:2}],b={toc:p};function h(e){var t=e.components,n=(0,a.Z)(e,c);return(0,r.kt)("wrapper",(0,i.Z)({},b,n,{components:t,mdxType:"MDXLayout"}),(0,r.kt)("h1",{id:"rechargeable-abilities"},"Rechargeable Abilities"),(0,r.kt)("h2",{id:"making-rechargeable"},"Making abilities rechargeable"),(0,r.kt)("p",null,"Just implement the ",(0,r.kt)("inlineCode",{parentName:"p"},"IAbilityRechargeable")," interface in your ability's class:"),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyRechargeableAbility.cs"',title:'"MyRechargeableAbility.cs"'},"// highlight-next-line\npublic class MyRechargeableAbility : CustomAbility, IAbilityRechargeable\n{\n    // highlight-next-line\n    public void OnRecharging(AbilityRechargingArgs e) { /* ... */ }\n}\n")),(0,r.kt)("p",null,(0,r.kt)("inlineCode",{parentName:"p"},"Count")," here works as a cooldown and represents the amount of time to wait until full recharge."),(0,r.kt)("div",{className:"admonition admonition-tip alert alert--success"},(0,r.kt)("div",{parentName:"div",className:"admonition-heading"},(0,r.kt)("h5",{parentName:"div"},(0,r.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,r.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"12",height:"16",viewBox:"0 0 12 16"},(0,r.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.5 0C3.48 0 1 2.19 1 5c0 .92.55 2.25 1 3 1.34 2.25 1.78 2.78 2 4v1h5v-1c.22-1.22.66-1.75 2-4 .45-.75 1-2.08 1-3 0-2.81-2.48-5-5.5-5zm3.64 7.48c-.25.44-.47.8-.67 1.11-.86 1.41-1.25 2.06-1.45 3.23-.02.05-.02.11-.02.17H5c0-.06 0-.13-.02-.17-.2-1.17-.59-1.83-1.45-3.23-.2-.31-.42-.67-.67-1.11C2.44 6.78 2 5.65 2 5c0-2.2 2.02-4 4.5-4 1.22 0 2.36.42 3.22 1.19C10.55 2.94 11 3.94 11 5c0 .66-.44 1.78-.86 2.48zM4 14h5c-.23 1.14-1.3 2-2.5 2s-2.27-.86-2.5-2z"}))),"Pro-tip")),(0,r.kt)("div",{parentName:"div",className:"admonition-content"},(0,r.kt)("p",{parentName:"div"},"You can just set it to 0 when it's fully recharged and to 1 when it's recharging (you can override the displayed count if you want), and use your own cooldown mechanism instead. See ",(0,r.kt)("a",{parentName:"p",href:"../recharging-items"},"Recharging Items")," for more info."))),(0,r.kt)("p",null,(0,r.kt)("inlineCode",{parentName:"p"},"OnRecharging")," works like Unity's ",(0,r.kt)("inlineCode",{parentName:"p"},"Update"),", but with a settable interval (default is 1 second):"),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},"    public void OnRecharging(AbilityRechargingArgs e)\n    {\n        // highlight-next-line\n        e.UpdateDelay = 2f; // 1 update every 2 seconds\n        Count--;\n    }\n")),(0,r.kt)("div",{className:"admonition admonition-info alert alert--info"},(0,r.kt)("div",{parentName:"div",className:"admonition-heading"},(0,r.kt)("h5",{parentName:"div"},(0,r.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,r.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,r.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M7 2.3c3.14 0 5.7 2.56 5.7 5.7s-2.56 5.7-5.7 5.7A5.71 5.71 0 0 1 1.3 8c0-3.14 2.56-5.7 5.7-5.7zM7 1C3.14 1 0 4.14 0 8s3.14 7 7 7 7-3.14 7-7-3.14-7-7-7zm1 3H6v5h2V4zm0 6H6v2h2v-2z"}))),"info")),(0,r.kt)("div",{parentName:"div",className:"admonition-content"},(0,r.kt)("p",{parentName:"div"},"You're responsible for decrementing the ability's ",(0,r.kt)("inlineCode",{parentName:"p"},"Count"),". So, don't forget to do that.",(0,r.kt)("br",{parentName:"p"}),"\n","Ability will stop recharging when ",(0,r.kt)("inlineCode",{parentName:"p"},"Count")," reaches 0. To start recharging again, just set ",(0,r.kt)("inlineCode",{parentName:"p"},"Count")," to any other value."))),(0,r.kt)("h2",{id:"examples"},"Examples"),(0,r.kt)(l.Z,{defaultValue:"titan",values:[{label:"Titan",value:"titan"}],mdxType:"Tabs"},(0,r.kt)(s.Z,{value:"titan",mdxType:"TabItem"},(0,r.kt)(o.Z,{mdxType:"CodeSnippet"},'namespace RogueLibsCore.Test\n{\n\tpublic class Titan : CustomAbility, IAbilityRechargeable\n\t{\n\t\t[RLSetup]\n\t\tpublic static void Setup()\n\t\t{\n\t\t\tRogueLibs.CreateCustomAbility<Titan>()\n\t\t\t\t.WithName(new CustomNameInfo("Titan"))\n\t\t\t\t.WithDescription(new CustomNameInfo("Willpower alone isn\'t enough in battle."))\n\t\t\t\t.WithSprite(Properties.Resources.Titan)\n\t\t\t\t.WithUnlock(new AbilityUnlock\n\t\t\t\t{\n\t\t\t\t\tUnlockCost = 10,\n\t\t\t\t\tCharacterCreationCost = 10,\n\t\t\t\t\tPrerequisites = { VanillaItems.Giantizer },\n\t\t\t\t});\n\t\t}\n\n\t\tpublic override void OnAdded() { }\n\t\tpublic override void OnPressed()\n\t\t{\n\t\t\tif (Count != 0)\n\t\t\t{\n\t\t\t\tgc.audioHandler.Play(Owner, VanillaAudio.CantDo);\n\t\t\t\treturn;\n\t\t\t}\n\t\t\tOwner.statusEffects.AddStatusEffect(VanillaEffects.Giant, 15);\n\t\t\tCount = 30;\n\t\t}\n\t\tpublic void OnRecharging(AbilityRechargingArgs e)\n\t\t{\n\t\t\te.UpdateDelay = 1f;\n\t\t\tCount--;\n\t\t}\n\t}\n}\n'))))}h.isMDXComponent=!0}}]);