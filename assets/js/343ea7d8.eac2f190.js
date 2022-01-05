"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[9706],{4214:function(e,t,i){i.d(t,{Z:function(){return r}});var n=i(7294),a=i(9055);function r(e){var t=e.children,i=e.language;return n.createElement(a.Z,{className:"language-"+(i||"csharp")},t.replace(/\t/g,"    "))}},1016:function(e,t,i){i.d(t,{Z:function(){return o}});var n=i(7462),a=i(3366),r=i(7294),l=["children"];function o(e){var t=e.children,i=(0,a.Z)(e,l);return r.createElement("div",(0,n.Z)({role:"tabpanel"},i),t)}},2099:function(e,t,i){i.d(t,{Z:function(){return b}});var n=i(7294),a=i(9443);var r=function(){var e=(0,n.useContext)(a.Z);if(null==e)throw new Error('"useUserPreferencesContext" is used outside of "Layout" component.');return e},l=i(6010),o="tabItem_OdQc",s="tabItemActive_YQWB",c="tab_tgHH";var u=37,d=39;function b(e){var t=e.lazy,i=e.defaultValue,a=e.values,b=e.groupId,m=r(),g=m.tabGroupChoices,h=m.setTabGroupChoices,p=(0,n.useState)(i),f=p[0],v=p[1],C=n.Children.toArray(e.children),k=[];if(null!=b){var y=g[b];null!=y&&y!==f&&a.some((function(e){return e.value===y}))&&v(y)}var w=function(e){var t=e.currentTarget,i=k.indexOf(t),n=a[i].value;v(n),null!=b&&(h(b,n),setTimeout((function(){var e,i,n,a,r,l,o,c;(e=t.getBoundingClientRect(),i=e.top,n=e.left,a=e.bottom,r=e.right,l=window,o=l.innerHeight,c=l.innerWidth,i>=0&&r<=c&&a<=o&&n>=0)||(t.scrollIntoView({block:"center",behavior:"smooth"}),t.classList.add(s),setTimeout((function(){return t.classList.remove(s)}),2e3))}),150))},A=function(e){var t;switch(e.keyCode){case d:var i=k.indexOf(e.target)+1;t=k[i]||k[0];break;case u:var n=k.indexOf(e.target)-1;t=k[n]||k[k.length-1];break;default:return}t.focus()},N=function(e,t){return t.value===e||t.values&&-1!=t.values.indexOf(e)};return n.createElement("div",{className:"tabs-container"},n.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:"tabs"},a.map((function(e){var t=e.value,i=e.label;return n.createElement("li",{role:"tab",tabIndex:f===t?0:-1,"aria-selected":f===t,className:(0,l.Z)("tabs__item",o,{"tabs__item--active":f===t}),key:t,ref:function(e){return e&&k.push(e)},onKeyDown:A,onFocus:w,onClick:w},i)}))),t?n.cloneElement(C.find((function(e){return N(f,e.props)})),{className:c}):n.createElement("div",null,C.map((function(e,t){return n.cloneElement(e,{key:t,hidden:!N(f,e.props),className:c})}))),n.createElement("br",null))}},5081:function(e,t,i){i.r(t),i.d(t,{contentTitle:function(){return d},default:function(){return h},frontMatter:function(){return u},metadata:function(){return b},toc:function(){return m}});var n=i(7462),a=i(3366),r=(i(7294),i(3905)),l=i(2099),o=i(1016),s=(i(4996),i(4214)),c=["components"],u={},d="Chargeable Abilities",b={unversionedId:"dev/items/abilities/chargeable-abilities",id:"dev/items/abilities/chargeable-abilities",title:"Chargeable Abilities",description:"Making abilities chargeable",source:"@site/docs/dev/items/abilities/chargeable-abilities.mdx",sourceDirName:"dev/items/abilities",slug:"/dev/items/abilities/chargeable-abilities",permalink:"/RogueLibs/docs/dev/items/abilities/chargeable-abilities",editUrl:"https://github.com/Abbysssal/RogueLibs/edit/main/website/docs/dev/items/abilities/chargeable-abilities.mdx",tags:[],version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"Rechargeable Abilities",permalink:"/RogueLibs/docs/dev/items/abilities/rechargeable-abilities"},next:{title:"Targetable Abilities",permalink:"/RogueLibs/docs/dev/items/abilities/targetable-abilities"}},m=[{value:"Making abilities chargeable",id:"making-chargeable",children:[],level:2},{value:"Examples",id:"examples",children:[],level:2}],g={toc:m};function h(e){var t=e.components,i=(0,a.Z)(e,c);return(0,r.kt)("wrapper",(0,n.Z)({},g,i,{components:t,mdxType:"MDXLayout"}),(0,r.kt)("h1",{id:"chargeable-abilities"},"Chargeable Abilities"),(0,r.kt)("h2",{id:"making-chargeable"},"Making abilities chargeable"),(0,r.kt)("p",null,"Just implement the ",(0,r.kt)("inlineCode",{parentName:"p"},"IAbilityChargeable")," interface in your ability's class:"),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyChargeableAbility.cs"',title:'"MyChargeableAbility.cs"'},"// highlight-next-line\npublic class MyChargeableAbility : CustomAbility, IAbilityChargeable\n{\n    // highlight-start\n    public void OnHeld(AbilityHeldArgs e) { /* ... */ }\n    public void OnReleased(AbilityReleasedArgs e) { /* ... */ }\n    // highlight-end\n}\n")),(0,r.kt)("p",null,(0,r.kt)("inlineCode",{parentName:"p"},"OnHeld")," is called every frame ",(0,r.kt)("em",{parentName:"p"},"(I think?)")," that the special ability button is held. ",(0,r.kt)("inlineCode",{parentName:"p"},"OnReleased")," is called on the frame that the special ability button is released. Use these in tandem with ",(0,r.kt)("inlineCode",{parentName:"p"},"OnPressed")," to charge your ability and stuff."),(0,r.kt)("div",{className:"admonition admonition-caution alert alert--warning"},(0,r.kt)("div",{parentName:"div",className:"admonition-heading"},(0,r.kt)("h5",{parentName:"div"},(0,r.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,r.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"16",height:"16",viewBox:"0 0 16 16"},(0,r.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M8.893 1.5c-.183-.31-.52-.5-.887-.5s-.703.19-.886.5L.138 13.499a.98.98 0 0 0 0 1.001c.193.31.53.501.886.501h13.964c.367 0 .704-.19.877-.5a1.03 1.03 0 0 0 .01-1.002L8.893 1.5zm.133 11.497H6.987v-2.003h2.039v2.003zm0-3.004H6.987V5.987h2.039v4.006z"}))),"caution")),(0,r.kt)("div",{parentName:"div",className:"admonition-content"},(0,r.kt)("p",{parentName:"div"},(0,r.kt)("inlineCode",{parentName:"p"},"AbilityHeldArgs.Interrupt()")," method is still work-in-progress."))),(0,r.kt)("h2",{id:"examples"},"Examples"),(0,r.kt)(l.Z,{defaultValue:"kamikaze",values:[{label:"Kamikaze",value:"kamikaze"}],mdxType:"Tabs"},(0,r.kt)(o.Z,{value:"kamikaze",mdxType:"TabItem"},(0,r.kt)(s.Z,{mdxType:"CodeSnippet"},'using UnityEngine;\n\nnamespace RogueLibsCore.Test\n{\n\tpublic class Kamikaze : CustomAbility, IAbilityChargeable, IDoUpdate\n\t{\n\t\t[RLSetup]\n\t\tpublic static void Setup()\n\t\t{\n\t\t\tRogueLibs.CreateCustomAbility<Kamikaze>()\n\t\t\t\t.WithName(new CustomNameInfo("Kamikaze"))\n\t\t\t\t.WithDescription(new CustomNameInfo("Charge up and explode everything around you."))\n\t\t\t\t.WithSprite(Properties.Resources.Kamikaze)\n\t\t\t\t.WithUnlock(new AbilityUnlock { UnlockCost = 20, CharacterCreationCost = 20 });\n\t\t}\n\n\t\tpublic float Charge { get; private set; }\n\t\tpublic bool IsCharging { get; private set; }\n\n\t\tpublic override void OnAdded() { }\n\t\tpublic override void OnPressed()\n\t\t{\n\t\t\tIsCharging = true;\n\t\t\tgc.audioHandler.Play(Owner, VanillaAudio.GeneratorHiss);\n\t\t\tOwner.objectMult.chargingSpecialLunge = true;\n\t\t}\n\t\tpublic override CustomTooltip GetCountString()\n\t\t{\n\t\t\tif (Charge is 0) return default;\n\t\t\tstring text = $"{Charge:#.#}s";\n\t\t\tColor color = Color.Lerp(Color.white, Color.red, Charge / 10f);\n\t\t\tif (Charge > 10f)\n\t\t\t{\n\t\t\t\ttext = "BOOM!";\n\t\t\t\tcolor = Color.Lerp(Color.white, Color.red, Mathf.PingPong(Time.time * 5, 1f));\n\t\t\t}\n\t\t\treturn new CustomTooltip(text, color);\n\t\t}\n\t\tpublic void OnHeld(AbilityHeldArgs e)\n\t\t{\n\t\t\tCharge += Time.deltaTime;\n\t\t\te.HeldTime = Charge;\n\t\t\tif (Charge > 10f)\n\t\t\t{\n\t\t\t\tOwner.objectMult.chargingSpecialLunge = true;\n\t\t\t}\n\t\t}\n\t\tpublic void OnReleased(AbilityReleasedArgs e)\n\t\t{\n\t\t\tIsCharging = false;\n\t\t\tOwner.objectMult.chargingSpecialLunge = false;\n\t\t\tif (e.HeldTime > 10f)\n\t\t\t{\n\t\t\t\tOwner.AddEffect(VanillaEffects.Resurrection, new CreateEffectInfo(1) { DontShowText = true, IgnoreElectronic = true });\n\t\t\t\tgc.spawnerMain.SpawnExplosion(Owner, Owner.tr.position, "Huge", false, -1, false, true).noOwnCheck = true;\n\t\t\t\tCharge = 0f;\n\t\t\t}\n\t\t\tgc.audioHandler.Stop(Owner, VanillaAudio.GeneratorHiss);\n\t\t}\n\t\tpublic void Update()\n\t\t{\n\t\t\tif (!IsCharging) Charge = Mathf.Max(Charge - Time.deltaTime * 5f, 0f);\n\t\t}\n\t}\n}\n'))))}h.isMDXComponent=!0}}]);