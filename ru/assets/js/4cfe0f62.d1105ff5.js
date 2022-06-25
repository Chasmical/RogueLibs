"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[5838],{4214:(e,t,n)=>{n.d(t,{Z:()=>o});var a=n(7294),i=n(3066);function o(e){let{children:t,language:n}=e;return a.createElement(i.Z,{className:"language-"+(n||"csharp")},t.replace(/\t/g,"    "))}},1016:(e,t,n)=>{n.d(t,{Z:()=>o});var a=n(7462),i=n(7294);function o(e){let{children:t,...n}=e;return i.createElement("div",(0,a.Z)({role:"tabpanel"},n),t)}},250:(e,t,n)=>{n.d(t,{Z:()=>c});var a=n(7294),i=n(7094),o=n(6010);const s="tabItem_V91s",l="tabItemActive_JsUu",r="tab_ntnM";const u=37,m=39;function c(e){const{lazy:t,defaultValue:n,values:c,groupId:p}=e,{tabGroupChoices:d,setTabGroupChoices:b}=(0,i.U)(),[g,C]=(0,a.useState)(n),I=a.Children.toArray(e.children),h=[];if(null!=p){const e=d[p];null!=e&&e!==g&&c.some((t=>t.value===e))&&C(e)}const k=e=>{const t=e.currentTarget,n=h.indexOf(t),a=c[n].value;C(a),null!=p&&(b(p,a),setTimeout((()=>{(function(e){const{top:t,left:n,bottom:a,right:i}=e.getBoundingClientRect(),{innerHeight:o,innerWidth:s}=window;return t>=0&&i<=s&&a<=o&&n>=0})(t)||(t.scrollIntoView({block:"center",behavior:"smooth"}),t.classList.add(l),setTimeout((()=>t.classList.remove(l)),2e3))}),150))},w=e=>{let t;switch(e.keyCode){case m:{const n=h.indexOf(e.target)+1;t=h[n]||h[0];break}case u:{const n=h.indexOf(e.target)-1;t=h[n]||h[h.length-1];break}default:return}t.focus()},v=(e,t)=>t.value===e||t.values&&-1!=t.values.indexOf(e);return a.createElement("div",{className:"tabs-container"},a.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:"tabs"},c.map((e=>{let{value:t,label:n}=e;return a.createElement("li",{role:"tab",tabIndex:g===t?0:-1,"aria-selected":g===t,className:(0,o.Z)("tabs__item",s,{"tabs__item--active":g===t}),key:t,ref:e=>e&&h.push(e),onKeyDown:w,onFocus:k,onClick:k},n)}))),t?a.cloneElement(I.find((e=>v(g,e.props))),{className:r}):a.createElement("div",null,I.map(((e,t)=>a.cloneElement(e,{key:t,hidden:!v(g,e.props),className:r})))),a.createElement("br",null))}},8038:(e,t,n)=>{n.r(t),n.d(t,{assets:()=>c,contentTitle:()=>u,default:()=>b,frontMatter:()=>r,metadata:()=>m,toc:()=>p});var a=n(7462),i=(n(7294),n(3905)),o=n(250),s=n(1016),l=(n(4996),n(4214));const r={},u="\u0418\u0441\u043f\u043e\u043b\u044c\u0437\u0443\u0435\u043c\u044b\u0435 \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u044b",m={unversionedId:"dev/items/usable-items",id:"dev/items/usable-items",title:"\u0418\u0441\u043f\u043e\u043b\u044c\u0437\u0443\u0435\u043c\u044b\u0435 \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u044b",description:"\u0414\u0435\u043b\u0430\u0435\u043c \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u044b \u0438\u0441\u043f\u043e\u043b\u044c\u0437\u0443\u0435\u043c\u044b\u043c\u0438",source:"@site/i18n/ru/docusaurus-plugin-content-docs/current/dev/items/usable-items.mdx",sourceDirName:"dev/items",slug:"/dev/items/usable-items",permalink:"/RogueLibs/ru/docs/dev/items/usable-items",draft:!1,editUrl:"https://github.com/SugarBarrel/RogueLibs/edit/main/website/docs/dev/items/usable-items.mdx",tags:[],version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"\u0421\u043e\u0437\u0434\u0430\u0451\u043c \u043a\u0430\u0441\u0442\u043e\u043c\u043d\u044b\u0439 \u043f\u0440\u0435\u0434\u043c\u0435\u0442",permalink:"/RogueLibs/ru/docs/dev/items/create-item"},next:{title:"\u041e\u0431\u044a\u0435\u0434\u0438\u043d\u044f\u0435\u043c\u044b\u0435 \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u044b",permalink:"/RogueLibs/ru/docs/dev/items/combinable-items"}},c={},p=[{value:"\u0414\u0435\u043b\u0430\u0435\u043c \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u044b \u0438\u0441\u043f\u043e\u043b\u044c\u0437\u0443\u0435\u043c\u044b\u043c\u0438",id:"making-usable",level:2},{value:"\u041f\u0440\u0438\u043c\u0435\u0440\u044b",id:"examples",level:2}],d={toc:p};function b(e){let{components:t,...n}=e;return(0,i.kt)("wrapper",(0,a.Z)({},d,n,{components:t,mdxType:"MDXLayout"}),(0,i.kt)("h1",{id:"\u0438\u0441\u043f\u043e\u043b\u044c\u0437\u0443\u0435\u043c\u044b\u0435-\u043f\u0440\u0435\u0434\u043c\u0435\u0442\u044b"},"\u0418\u0441\u043f\u043e\u043b\u044c\u0437\u0443\u0435\u043c\u044b\u0435 \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u044b"),(0,i.kt)("h2",{id:"making-usable"},"\u0414\u0435\u043b\u0430\u0435\u043c \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u044b \u0438\u0441\u043f\u043e\u043b\u044c\u0437\u0443\u0435\u043c\u044b\u043c\u0438"),(0,i.kt)("p",null,"\u041f\u0440\u043e\u0441\u0442\u043e \u0440\u0435\u0430\u043b\u0438\u0437\u0443\u0439\u0442\u0435 \u0438\u043d\u0442\u0435\u0440\u0444\u0435\u0439\u0441 ",(0,i.kt)("inlineCode",{parentName:"p"},"IItemUsable")," \u0432 \u043a\u043b\u0430\u0441\u0441\u0435 \u0432\u0430\u0448\u0435\u0433\u043e \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u0430:"),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyUsableItem.cs"',title:'"MyUsableItem.cs"'},"// highlight-next-line\npublic class MyUsableItem : CustomItem, IItemUsable\n{\n    // highlight-next-line\n    public bool UseItem() { /* ... */ }\n}\n")),(0,i.kt)("p",null,"\u0412\u043e\u0437\u0432\u0440\u0430\u0449\u0430\u0435\u043c\u043e\u0435 \u0437\u043d\u0430\u0447\u0435\u043d\u0438\u0435 ",(0,i.kt)("inlineCode",{parentName:"p"},"UseItem")," \u043e\u043f\u0440\u0435\u0434\u0435\u043b\u044f\u0435\u0442, \u0431\u044b\u043b \u043b\u0438 \u043f\u0440\u0435\u0434\u043c\u0435\u0442 \u0443\u0441\u043f\u0435\u0448\u043d\u043e \u0438\u0441\u043f\u043e\u043b\u044c\u0437\u043e\u0432\u0430\u043d. \u0412\u043e\u0437\u0432\u0440\u0430\u0442 ",(0,i.kt)("inlineCode",{parentName:"p"},"true")," \u0442\u0430\u043a\u0436\u0435 \u043f\u0440\u043e\u0438\u0433\u0440\u044b\u0432\u0430\u0435\u0442 \u0430\u043d\u0438\u043c\u0430\u0446\u0438\u044e. \u041f\u0440\u0438 \u0432\u043e\u0437\u0432\u0440\u0430\u0442\u0435 ",(0,i.kt)("inlineCode",{parentName:"p"},"false"),", \u0432\u044b \u043c\u043e\u0436\u0435\u0442\u0435 \u043f\u0440\u043e\u0438\u0433\u0440\u0430\u0442\u044c \u0437\u0432\u0443\u043a ",(0,i.kt)("inlineCode",{parentName:"p"},'"CantDo"'),", \u0438, \u043c\u043e\u0436\u0435\u0442, \u0437\u0430\u0441\u0442\u0430\u0432\u0438\u0442\u044c \u0442\u0435\u043a\u0443\u0449\u0435\u0433\u043e \u0432\u043b\u0430\u0434\u0435\u043b\u044c\u0446\u0430 \u0441\u043a\u0430\u0437\u0430\u0442\u044c, \u043f\u043e\u0447\u0435\u043c\u0443 \u043f\u0440\u0435\u0434\u043c\u0435\u0442 \u043d\u0435\u043b\u044c\u0437\u044f \u0438\u0441\u043f\u043e\u043b\u044c\u0437\u043e\u0432\u0430\u0442\u044c:"),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-csharp"},'        if (cantUse)\n        {\n            gc.audioHandler.Play(Owner, "CantDo");\n            Owner.SayDialogue("CantUseItemBecause...");\n            // \u043d\u0435 \u0437\u0430\u0431\u0443\u0434\u044c\u0442\u0435 \u0441\u043e\u0437\u0434\u0430\u0442\u044c \u0434\u0438\u0430\u043b\u043e\u0433 \u0441 \u044d\u0442\u0438\u043c \u0430\u0439\u0434\u0438\n            return false;\n        }\n')),(0,i.kt)("div",{className:"admonition admonition-info alert alert--info"},(0,i.kt)("div",{parentName:"div",className:"admonition-heading"},(0,i.kt)("h5",{parentName:"div"},(0,i.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,i.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,i.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M7 2.3c3.14 0 5.7 2.56 5.7 5.7s-2.56 5.7-5.7 5.7A5.71 5.71 0 0 1 1.3 8c0-3.14 2.56-5.7 5.7-5.7zM7 1C3.14 1 0 4.14 0 8s3.14 7 7 7 7-3.14 7-7-3.14-7-7-7zm1 3H6v5h2V4zm0 6H6v2h2v-2z"}))),"info")),(0,i.kt)("div",{parentName:"div",className:"admonition-content"},(0,i.kt)("p",{parentName:"div"},"\u041e\u0442\u0432\u0435\u0442\u0441\u0442\u0432\u0435\u043d\u043d\u043e\u0441\u0442\u044c \u0437\u0430 \u0443\u043c\u0435\u043d\u044c\u0448\u0435\u043d\u0438\u0435 ",(0,i.kt)("inlineCode",{parentName:"p"},"Count")," \u043b\u0435\u0436\u0438\u0442 \u043d\u0430 \u0432\u0430\u0441. \u0422\u0430\u043a \u0447\u0442\u043e, \u043d\u0435 \u0437\u0430\u0431\u044b\u0432\u0430\u0439\u0442\u0435 \u0434\u0435\u043b\u0430\u0442\u044c \u044d\u0442\u043e."))),(0,i.kt)("h2",{id:"examples"},"\u041f\u0440\u0438\u043c\u0435\u0440\u044b"),(0,i.kt)(o.Z,{defaultValue:"jokebook",values:[{label:"\u0421\u0431\u043e\u0440\u043d\u0438\u043a \u0448\u0443\u0442\u043e\u043a",value:"jokebook"},{label:"\u0410\u0434\u0440\u0435\u043d\u0430\u043b\u0438\u043d",value:"adrenalineshot"},{label:"\u0423\u043d\u0438\u0432\u0435\u0440\u0441\u0430\u043b\u044c\u043d\u044b\u0439 \u043f\u0440\u043e\u0445\u043e\u0434 \u0441\u043a\u0432\u043e\u0437\u044c \u0441\u0442\u0435\u043d\u044b",value:"wildbypasser"}],mdxType:"Tabs"},(0,i.kt)(s.Z,{value:"jokebook",mdxType:"TabItem"},(0,i.kt)("p",null,"\u041f\u0440\u043e\u0441\u0442\u043e\u0439 \u0438\u0441\u043f\u043e\u043b\u044c\u0437\u0443\u0435\u043c\u044b\u0439 \u043f\u0440\u0435\u0434\u043c\u0435\u0442, \u0434\u0430\u044e\u0449\u0438\u0439 \u0438\u0433\u0440\u043e\u043a\u0443 \u0432\u043e\u0437\u043c\u043e\u0436\u043d\u043e\u0441\u0442\u044c \u0438\u0441\u043f\u043e\u043b\u044c\u0437\u043e\u0432\u0430\u0442\u044c \u0441\u043f\u043e\u0441\u043e\u0431\u043d\u043e\u0441\u0442\u044c \u0428\u0443\u0442\u043a\u0430."),(0,i.kt)(l.Z,{mdxType:"CodeSnippet"},'namespace RogueLibsCore.Test\n{\n    [ItemCategories(RogueCategories.Usable, RogueCategories.Social)]\n    public class JokeBook : CustomItem, IItemUsable\n    {\n        [RLSetup]\n        public static void Setup()\n        {\n            RogueLibs.CreateCustomItem<JokeBook>()\n                .WithName(new CustomNameInfo("Joke Book"))\n                .WithDescription(new CustomNameInfo("Always wanted to be a Comedian? Now you can! (kind of)"))\n                .WithSprite(Properties.Resources.JokeBook)\n                .WithUnlock(new ItemUnlock\n                {\n                    UnlockCost = 10,\n                    LoadoutCost = 5,\n                    CharacterCreationCost = 3,\n                    Prerequisites = { VanillaAgents.Comedian + "_BQ" },\n                });\n        }\n\n        public override void SetupDetails()\n        {\n            Item.itemType = ItemTypes.Tool;\n            Item.itemValue = 15;\n            Item.initCount = 10;\n            Item.rewardCount = 10;\n            Item.stackable = true;\n            Item.hasCharges = true;\n            Item.goesInToolbar = true;\n        }\n        public bool UseItem()\n        {\n            if (Owner.statusEffects.makingJoke) return false;\n\n            string prev = Owner.specialAbility;\n            Owner.specialAbility = VanillaAbilities.Joke;\n            Owner.statusEffects.PressedSpecialAbility();\n            Owner.specialAbility = prev;\n\n            Count--;\n            return true;\n        }\n    }\n}\n')),(0,i.kt)(s.Z,{value:"adrenalineshot",mdxType:"TabItem"},(0,i.kt)("p",null,'\u041f\u0440\u043e\u0441\u0442\u043e\u0439 \u0438\u0441\u043f\u043e\u043b\u044c\u0437\u0443\u0435\u043c\u044b\u0439 \u043f\u0440\u0435\u0434\u043c\u0435\u0442, \u0434\u0430\u044e\u0449\u0438\u0439 \u0438\u0433\u0440\u043e\u043a\u0443 \u044d\u0444\u0444\u0435\u043a\u0442 "\u0410\u0434\u0440\u0435\u043d\u0430\u043b\u0438\u043d". \u0412\u044b \u043c\u043e\u0436\u0435\u0442\u0435 \u043f\u043e\u0441\u043c\u043e\u0442\u0440\u0435\u0442\u044c \u0440\u0435\u0430\u043b\u0438\u0437\u0430\u0446\u0438\u044e \u044d\u0444\u0444\u0435\u043a\u0442\u0430 \u0410\u0434\u0440\u0435\u043d\u0430\u043b\u0438\u043d \u0432 ',(0,i.kt)("a",{parentName:"p",href:"../traits/create-effect#examples"},"\u0421\u043e\u0437\u0434\u0430\u0451\u043c \u043a\u0430\u0441\u0442\u043e\u043c\u043d\u044b\u0439 \u044d\u0444\u0444\u0435\u043a\u0442: \u041f\u0440\u0438\u043c\u0435\u0440\u044b"),"."),(0,i.kt)(l.Z,{mdxType:"CodeSnippet"},'namespace RogueLibsCore.Test\n{\n    [ItemCategories(RogueCategories.Drugs, RogueCategories.Melee, RogueCategories.Usable)]\n    public class AdrenalineShot : CustomItem, IItemUsable\n    {\n        [RLSetup]\n        public static void Setup()\n        {\n            RogueLibs.CreateCustomItem<AdrenalineShot>()\n                .WithName(new CustomNameInfo("Adrenaline Shot"))\n                .WithDescription(new CustomNameInfo("Gives you a ton of boosts for a short period of time."))\n                .WithSprite(Properties.Resources.AdrenalineShot)\n                .WithUnlock(new ItemUnlock\n                {\n                    UnlockCost = 10,\n                    LoadoutCost = 5,\n                    CharacterCreationCost = 3,\n                    Prerequisites = { VanillaItems.RagePoison, VanillaItems.Antidote },\n                });\n\n            RogueLibs.CreateCustomName("AdrenalineElectronic", NameTypes.Dialogue,\n                new CustomNameInfo("I don\'t have a circulatory system."));\n        }\n\n        public override void SetupDetails()\n        {\n            Item.itemType = ItemTypes.Consumable;\n            Item.healthChange = 20;\n            Item.itemValue = 60;\n            Item.initCount = 1;\n            Item.rewardCount = 2;\n            Item.stackable = true;\n            Item.goesInToolbar = true;\n        }\n        [IgnoreChecks("FullHealth")]\n        public bool UseItem()\n        {\n            if (Owner.electronic)\n            {\n                Owner.SayDialogue("AdrenalineElectronic");\n                gc.audioHandler.Play(Owner, VanillaAudio.CantDo);\n                return false;\n            }\n            Owner.AddEffect<Adrenaline>();\n            gc.audioHandler.Play(Owner, VanillaAudio.UseSyringe);\n            Count--;\n            return true;\n        }\n    }\n}\n')),(0,i.kt)(s.Z,{value:"wildbypasser",mdxType:"TabItem"},(0,i.kt)("p",null,"\u0411\u043e\u043b\u0435\u0435 \u0441\u043b\u043e\u0436\u043d\u044b\u0439 \u0438\u0441\u043f\u043e\u043b\u044c\u0437\u0443\u0435\u043c\u044b\u0439 \u043f\u0440\u0435\u0434\u043c\u0435\u0442, \u043e\u0441\u043d\u043e\u0432\u0430\u043d\u043d\u044b\u0439 \u043d\u0430 \u043a\u043e\u0434\u0435 \u041f\u0440\u043e\u0445\u043e\u0434\u0430 \u0441\u043a\u0432\u043e\u0437\u044c \u0441\u0442\u0435\u043d\u044b (\u0441\u043c. ",(0,i.kt)("inlineCode",{parentName:"p"},"ItemFunctions.UseItem"),")."),(0,i.kt)(l.Z,{mdxType:"CodeSnippet"},'using UnityEngine;\n\nnamespace RogueLibsCore.Test\n{\n    [ItemCategories(RogueCategories.Technology, RogueCategories.Usable, RogueCategories.Stealth)]\n    public class WildBypasser : CustomItem, IItemUsable\n    {\n        [RLSetup]\n        public static void Setup()\n        {\n            RogueLibs.CreateCustomItem<WildBypasser>()\n                .WithName(new CustomNameInfo("Wild Bypasser"))\n                .WithDescription(new CustomNameInfo("Warps you in the direction you\'re facing. Teleports through any amount of walls."))\n                .WithSprite(Properties.Resources.WildBypasser)\n                .WithUnlock(new ItemUnlock\n                {\n                    UnlockCost = 10,\n                    LoadoutCost = 7,\n                    CharacterCreationCost = 3,\n                    Prerequisites = { VanillaItems.WallBypasser },\n                });\n        }\n\n        public override void SetupDetails()\n        {\n            Item.itemType = ItemTypes.Tool;\n            Item.itemValue = 60;\n            Item.initCount = 2;\n            Item.rewardCount = 3;\n            Item.stackable = true;\n            Item.goesInToolbar = true;\n        }\n        public bool UseItem()\n        {\n            Vector3 position = Owner.agentHelperTr.localPosition = Vector3.zero;\n            TileData tileData;\n            int limit = 0;\n            do\n            {\n                position.x += 0.64f;\n                Owner.agentHelperTr.localPosition = position;\n                tileData = gc.tileInfo.GetTileData(Owner.agentHelperTr.position);\n\n            } while ((gc.tileInfo.IsOverlapping(Owner.agentHelperTr.position, "Anything")\n                || tileData.wallMaterial != wallMaterialType.None) && limit++ < 250);\n\n            if (limit > 250)\n            {\n                gc.audioHandler.Play(Owner, VanillaAudio.CantDo);\n                return false;\n            }\n\n            Owner.SpawnParticleEffect("Spawn", Owner.tr.position);\n            Owner.Teleport(Owner.agentHelperTr.position, false, true);\n            Owner.rb.velocity = Vector2.zero;\n\n            if (!(Owner.HasTrait(VanillaTraits.IntrusionArtist)\n                    && gc.percentChance(Owner.DetermineLuck(80, "ThiefToolsMayNotSubtract", true)))\n                && !(Owner.HasTrait(VanillaTraits.IntrusionArtist2)\n                    && gc.percentChance(Owner.DetermineLuck(40, "ThiefToolsMayNotSubtract", true))))\n                Count--;\n\n            Owner.SpawnParticleEffect("Spawn", Owner.tr.position, false);\n            gc.audioHandler.Play(Owner, VanillaAudio.Spawn);\n            return true;\n        }\n    }\n}\n'))))}b.isMDXComponent=!0}}]);