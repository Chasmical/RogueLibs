"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[5979],{4214:function(e,t,n){n.d(t,{Z:function(){return i}});var r=n(7294),a=n(9055);function i(e){var t=e.children,n=e.language;return r.createElement(a.Z,{className:"language-"+(n||"csharp")},t.replace(/\t/g,"    "))}},2725:function(e,t,n){n.d(t,{Z:function(){return a}});var r=n(7294);function a(e){var t=e.color,n=(e.size||14)+"px";return r.createElement("div",{style:{display:"inline"}},r.createElement("div",{style:{display:"inline-block",width:n,height:n,background:t,marginRight:"2px"}}),r.createElement("div",{style:{display:"inline"}},t))}},1016:function(e,t,n){n.d(t,{Z:function(){return l}});var r=n(7462),a=n(3366),i=n(7294),o=["children"];function l(e){var t=e.children,n=(0,a.Z)(e,o);return i.createElement("div",(0,r.Z)({role:"tabpanel"},n),t)}},2099:function(e,t,n){n.d(t,{Z:function(){return m}});var r=n(7294),a=n(9443);var i=function(){var e=(0,r.useContext)(a.Z);if(null==e)throw new Error('"useUserPreferencesContext" is used outside of "Layout" component.');return e},o=n(6010),l="tabItem_OdQc",s="tabItemActive_YQWB",u="tab_tgHH";var c=37,p=39;function m(e){var t=e.lazy,n=e.defaultValue,a=e.values,m=e.groupId,d=i(),g=d.tabGroupChoices,b=d.setTabGroupChoices,f=(0,r.useState)(n),v=f[0],h=f[1],T=r.Children.toArray(e.children),C=[];if(null!=m){var k=g[m];null!=k&&k!==v&&a.some((function(e){return e.value===k}))&&h(k)}var w=function(e){var t=e.currentTarget,n=C.indexOf(t),r=a[n].value;h(r),null!=m&&(b(m,r),setTimeout((function(){var e,n,r,a,i,o,l,u;(e=t.getBoundingClientRect(),n=e.top,r=e.left,a=e.bottom,i=e.right,o=window,l=o.innerHeight,u=o.innerWidth,n>=0&&i<=u&&a<=l&&r>=0)||(t.scrollIntoView({block:"center",behavior:"smooth"}),t.classList.add(s),setTimeout((function(){return t.classList.remove(s)}),2e3))}),150))},y=function(e){var t;switch(e.keyCode){case p:var n=C.indexOf(e.target)+1;t=C[n]||C[0];break;case c:var r=C.indexOf(e.target)-1;t=C[r]||C[C.length-1];break;default:return}t.focus()},I=function(e,t){return t.value===e||t.values&&-1!=t.values.indexOf(e)};return r.createElement("div",{className:"tabs-container"},r.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:"tabs"},a.map((function(e){var t=e.value,n=e.label;return r.createElement("li",{role:"tab",tabIndex:v===t?0:-1,"aria-selected":v===t,className:(0,o.Z)("tabs__item",l,{"tabs__item--active":v===t}),key:t,ref:function(e){return e&&C.push(e)},onKeyDown:y,onFocus:w,onClick:w},n)}))),t?r.cloneElement(T.find((function(e){return I(v,e.props)})),{className:u}):r.createElement("div",null,T.map((function(e,t){return r.cloneElement(e,{key:t,hidden:!I(v,e.props),className:u})}))),r.createElement("br",null))}},6446:function(e,t,n){n.r(t),n.d(t,{contentTitle:function(){return m},default:function(){return f},frontMatter:function(){return p},metadata:function(){return d},toc:function(){return g}});var r=n(7462),a=n(3366),i=(n(7294),n(3905)),o=n(2099),l=n(1016),s=(n(4996),n(2725)),u=n(4214),c=["components"],p={},m="\u041d\u0430\u043f\u0440\u0430\u0432\u043b\u044f\u0435\u043c\u044b\u0435 \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u044b +",d={unversionedId:"dev/items/targetable-items-plus",id:"dev/items/targetable-items-plus",title:"\u041d\u0430\u043f\u0440\u0430\u0432\u043b\u044f\u0435\u043c\u044b\u0435 \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u044b +",description:"\u0414\u0435\u043b\u0430\u0435\u043c \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u044b \u043d\u0430\u043f\u0440\u0430\u0432\u043b\u044f\u0435\u043c\u044b\u043c\u0438 \u043a\u0443\u0434\u0430 \u0443\u0433\u043e\u0434\u043d\u043e",source:"@site/i18n/ru/docusaurus-plugin-content-docs/current/dev/items/targetable-items-plus.mdx",sourceDirName:"dev/items",slug:"/dev/items/targetable-items-plus",permalink:"/RogueLibs/ru/docs/dev/items/targetable-items-plus",editUrl:"https://github.com/Abbysssal/RogueLibs/edit/main/website/docs/dev/items/targetable-items-plus.mdx",tags:[],version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"\u041d\u0430\u043f\u0440\u0430\u0432\u043b\u044f\u0435\u043c\u044b\u0435 \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u044b",permalink:"/RogueLibs/ru/docs/dev/items/targetable-items"},next:{title:"\u041f\u0435\u0440\u0435\u0437\u0430\u0440\u044f\u0436\u0430\u0435\u043c\u044b\u0435 \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u044b",permalink:"/RogueLibs/ru/docs/dev/items/recharging-items"}},g=[{value:"\u0414\u0435\u043b\u0430\u0435\u043c \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u044b \u043d\u0430\u043f\u0440\u0430\u0432\u043b\u044f\u0435\u043c\u044b\u043c\u0438 \u043a\u0443\u0434\u0430 \u0443\u0433\u043e\u0434\u043d\u043e",id:"making-targetable-anywhere",children:[],level:2},{value:"\u041f\u0440\u0438\u043c\u0435\u0440\u044b",id:"examples",children:[],level:2}],b={toc:g};function f(e){var t=e.components,n=(0,a.Z)(e,c);return(0,i.kt)("wrapper",(0,r.Z)({},b,n,{components:t,mdxType:"MDXLayout"}),(0,i.kt)("h1",{id:"\u043d\u0430\u043f\u0440\u0430\u0432\u043b\u044f\u0435\u043c\u044b\u0435-\u043f\u0440\u0435\u0434\u043c\u0435\u0442\u044b-"},"\u041d\u0430\u043f\u0440\u0430\u0432\u043b\u044f\u0435\u043c\u044b\u0435 \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u044b +"),(0,i.kt)("h2",{id:"making-targetable-anywhere"},"\u0414\u0435\u043b\u0430\u0435\u043c \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u044b \u043d\u0430\u043f\u0440\u0430\u0432\u043b\u044f\u0435\u043c\u044b\u043c\u0438 \u043a\u0443\u0434\u0430 \u0443\u0433\u043e\u0434\u043d\u043e"),(0,i.kt)("p",null,"\u041f\u0440\u043e\u0441\u0442\u043e \u0440\u0435\u0430\u043b\u0438\u0437\u0443\u0439\u0442\u0435 \u0438\u043d\u0442\u0435\u0440\u0444\u0435\u0439\u0441 ",(0,i.kt)("inlineCode",{parentName:"p"},"IItemTargetableAnywhere")," \u0432 \u043a\u043b\u0430\u0441\u0441\u0435 \u0432\u0430\u0448\u0435\u0433\u043e \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u0430:"),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyTargetableAnywhereItem.cs"',title:'"MyTargetableAnywhereItem.cs"'},"// highlight-next-line\npublic class MyTargetableAnywhereItem : CustomItem, IItemTargetableAnywhere\n{\n    // highlight-start\n    public bool TargetFilter(Vector2 position) { /* ... */ }\n    public bool TargetPosition(Vector2 position) { /* ... */ }\n    public CustomTooltip TargetCursorText(Vector2 position) { /* ... */ }\n    // highlight-end\n}\n")),(0,i.kt)("p",null,(0,i.kt)("inlineCode",{parentName:"p"},"TargetFilter")," \u043e\u043f\u0440\u0435\u0434\u0435\u043b\u044f\u0435\u0442 \u0433\u0434\u0435 \u043a\u0443\u0440\u0441\u043e\u0440 \u0434\u043e\u043b\u0436\u0435\u043d \u0431\u044b\u0442\u044c \u043f\u043e\u0434\u0441\u0432\u0435\u0447\u0435\u043d\u043d\u044b\u043c, \u043f\u0440\u0438 \u0438\u0441\u043f\u043e\u043b\u044c\u0437\u043e\u0432\u0430\u043d\u0438\u0438 \u0442\u0435\u043a\u0443\u0449\u0435\u0433\u043e \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u0430."),(0,i.kt)("p",null,(0,i.kt)("inlineCode",{parentName:"p"},"TargetPosition")," \u0438\u0441\u043f\u043e\u043b\u044c\u0437\u0443\u0435\u0442 \u0442\u0435\u043a\u0443\u0449\u0438\u0439 \u043f\u0440\u0435\u0434\u043c\u0435\u0442 \u043d\u0430 \u0432\u044b\u0431\u0440\u0430\u043d\u043d\u043e\u043c \u043c\u0435\u0441\u0442\u0435. \u0412\u043e\u0437\u0432\u0440\u0430\u0449\u0430\u0435\u043c\u043e\u0435 \u0437\u043d\u0430\u0447\u0435\u043d\u0438\u0435 \u043e\u043f\u0440\u0435\u0434\u0435\u043b\u044f\u0435\u0442 \u0443\u0441\u043f\u0435\u0448\u043d\u043e \u043b\u0438 \u043e\u043d \u0431\u044b\u043b \u0438\u0441\u043f\u043e\u043b\u044c\u0437\u043e\u0432\u0430\u043d \u0438\u043b\u0438 \u043d\u0435\u0442. \u0415\u0441\u043b\u0438 \u043f\u0440\u0435\u0434\u043c\u0435\u0442 \u043d\u0435\u043b\u044c\u0437\u044f \u0438\u0441\u043f\u043e\u043b\u044c\u0437\u043e\u0432\u0430\u0442\u044c, \u0432\u044b \u043c\u043e\u0436\u0435\u0442\u0435 \u043f\u0440\u043e\u0438\u0433\u0440\u0430\u0442\u044c \u0437\u0432\u0443\u043a ",(0,i.kt)("inlineCode",{parentName:"p"},'"CantDo"')," \u0438 \u0437\u0430\u0441\u0442\u0430\u0432\u0438\u0442\u044c \u0438\u0433\u0440\u043e\u043a\u0430 \u0441\u043a\u0430\u0437\u0430\u0442\u044c \u0447\u0442\u043e-\u043d\u0438\u0431\u0443\u0434\u044c. \u0412\u043e\u0437\u0432\u0440\u0430\u0442 ",(0,i.kt)("inlineCode",{parentName:"p"},"true")," \u0442\u0430\u043a\u0436\u0435 \u043f\u0440\u043e\u0438\u0433\u0440\u0430\u0435\u0442 \u0430\u043d\u0438\u043c\u0430\u0446\u0438\u044e."),(0,i.kt)("p",null,(0,i.kt)("inlineCode",{parentName:"p"},"TargetCursorText")," \u043e\u043f\u0440\u0435\u0434\u0435\u043b\u044f\u0435\u0442 \u0442\u0435\u043a\u0441\u0442 \u0432\u043e\u0437\u043b\u0435 \u043a\u0443\u0440\u0441\u043e\u0440\u0430 \u043d\u0430\u0434 \u0432\u044b\u0431\u0440\u0430\u043d\u043d\u044b\u043c \u043c\u0435\u0441\u0442\u043e\u043c. ",(0,i.kt)("inlineCode",{parentName:"p"},"Text")," \u0432\u044b\u0441\u0442\u0430\u0432\u043b\u0435\u043d\u043d\u044b\u0439 \u043d\u0430 ",(0,i.kt)("inlineCode",{parentName:"p"},"null"),' \u043e\u043f\u0440\u0435\u0434\u0435\u043b\u0438\u0442\u0441\u044f \u043a\u0430\u043a "\u0418\u0441\u043f\u043e\u043b\u044c\u0437\u043e\u0432\u0430\u0442\u044c", \u0438 ',(0,i.kt)("inlineCode",{parentName:"p"},"Color")," \u0432\u044b\u0441\u0442\u0430\u0432\u043b\u0435\u043d\u043d\u044b\u0439 \u043d\u0430 ",(0,i.kt)("inlineCode",{parentName:"p"},"null")," \u043e\u043f\u0440\u0435\u0434\u0435\u043b\u0438\u0442\u0441\u044f \u043a\u0430\u043a ",(0,i.kt)(s.Z,{color:"#FFFFFF",mdxType:"ColorSquare"}),"."),(0,i.kt)("h2",{id:"examples"},"\u041f\u0440\u0438\u043c\u0435\u0440\u044b"),(0,i.kt)(o.Z,{defaultValue:"usableteleporter",values:[{label:"\u0418\u0441\u043f\u043e\u043b\u044c\u0437\u0443\u0435\u043c\u044b\u0439 \u0442\u0435\u043b\u0435\u043f\u043e\u0440\u0442\u0430\u0442\u043e\u0440",value:"usableteleporter"}],mdxType:"Tabs"},(0,i.kt)(l.Z,{value:"usableteleporter",mdxType:"TabItem"},(0,i.kt)("p",null,"\u041f\u0440\u043e\u0441\u0442\u043e\u0439 \u043d\u0430\u043f\u0440\u0430\u0432\u043b\u044f\u0435\u043c\u044b\u0439 \u043a\u0443\u0434\u0430 \u0443\u0433\u043e\u0434\u043d\u043e \u043f\u0440\u0435\u0434\u043c\u0435\u0442. \u0422\u0435\u043b\u0435\u043f\u043e\u0440\u0442\u0438\u0440\u0443\u0435\u0442 \u0438\u0433\u0440\u043e\u043a\u0430 \u0432 \u0443\u043a\u0430\u0437\u0430\u043d\u043d\u043e\u0435 \u043c\u0435\u0441\u0442\u043e."),(0,i.kt)(u.Z,{mdxType:"CodeSnippet"},'using UnityEngine;\n\nnamespace RogueLibsCore.Test\n{\n    [ItemCategories(RogueCategories.Usable, RogueCategories.Technology, RogueCategories.Stealth)]\n    public class UsableTeleporter : CustomItem, IItemTargetableAnywhere\n    {\n        [RLSetup]\n        public static void Setup()\n        {\n            RogueLibs.CreateCustomItem<UsableTeleporter>()\n                .WithName(new CustomNameInfo("Usable Teleporter"))\n                .WithDescription(new CustomNameInfo("Teleports you somewhere. Has limited uses."))\n                .WithSprite(Properties.Resources.UsableTeleporter)\n                .WithUnlock(new ItemUnlock\n                {\n                    UnlockCost = 10,\n                    LoadoutCost = 9,\n                    CharacterCreationCost = 5,\n                    Prerequisites = { VanillaItems.QuickEscapeTeleporter, nameof(WildBypasser) },\n                });\n\n            TeleportCursorText = RogueLibs.CreateCustomName("TeleportHere", NameTypes.Interface, new CustomNameInfo("Teleport here"));\n        }\n        private static CustomName TeleportCursorText;\n\n        public override void SetupDetails()\n        {\n            Item.itemType = ItemTypes.Tool;\n            Item.itemValue = 80;\n            Item.initCount = 2;\n            Item.rewardCount = 3;\n            Item.stackable = true;\n            Item.goesInToolbar = true;\n        }\n        public bool TargetFilter(Vector2 position)\n        {\n            TileData tileData = gc.tileInfo.GetTileData(position);\n            return !gc.tileInfo.IsOverlapping(position, "Anything") && tileData.wallMaterial == wallMaterialType.None;\n        }\n        public bool TargetPosition(Vector2 position)\n        {\n            if (!TargetFilter(position)) return false;\n\n            Owner.SpawnParticleEffect("Spawn", Owner.tr.position);\n            Owner.Teleport(position, false, true);\n            Owner.rb.velocity = Vector2.zero;\n            Owner.SpawnParticleEffect("Spawn", Owner.tr.position, false);\n            gc.audioHandler.Play(Owner, VanillaAudio.Spawn);\n\n            Count--;\n            return true;\n        }\n        public CustomTooltip TargetCursorText(Vector2 position) => TeleportCursorText;\n    }\n}\n'))))}f.isMDXComponent=!0}}]);