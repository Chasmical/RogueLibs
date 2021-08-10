(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[797],{4214:function(e,t,n){"use strict";n.d(t,{Z:function(){return a}});var i=n(7294),r=n(1756);function a(e){var t=e.children,n=e.language;return i.createElement(r.Z,{className:"language-"+(n||"csharp")},t.replace(/\t/g,"    "))}},2725:function(e,t,n){"use strict";n.d(t,{Z:function(){return r}});var i=n(7294);function r(e){var t=e.color,n=(e.size||14)+"px";return i.createElement("div",{style:{display:"inline"}},i.createElement("div",{style:{display:"inline-block",width:n,height:n,background:t,marginRight:"2px"}}),i.createElement("div",{style:{display:"inline"}},t))}},9424:function(e,t,n){"use strict";n.r(t),n.d(t,{contentTitle:function(){return c},default:function(){return h},frontMatter:function(){return m},metadata:function(){return g},toc:function(){return d}});var i=n(2122),r=n(9756),a=(n(7294),n(3905)),o=n(8952),l=n(9309),s=(n(4996),n(2725)),u=n(4214),p=["components"],m={},c="Targetable Items +",g={unversionedId:"dev/items/targetable-items-plus",id:"dev/items/targetable-items-plus",isDocsHomePage:!1,title:"Targetable Items +",description:"Making items targetable anywhere",source:"@site/docs/dev/items/targetable-items-plus.mdx",sourceDirName:"dev/items",slug:"/dev/items/targetable-items-plus",permalink:"/RogueLibs/docs/dev/items/targetable-items-plus",editUrl:"https://github.com/Abbysssal/RogueLibs/edit/main/website/docs/dev/items/targetable-items-plus.mdx",version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"Targetable Items",permalink:"/RogueLibs/docs/dev/items/targetable-items"},next:{title:"Recharging Items",permalink:"/RogueLibs/docs/dev/items/recharging-items"}},d=[{value:"Making items targetable anywhere",id:"making-targetable-anywhere",children:[]},{value:"Examples",id:"examples",children:[]}],b={toc:d};function h(e){var t=e.components,n=(0,r.Z)(e,p);return(0,a.kt)("wrapper",(0,i.Z)({},b,n,{components:t,mdxType:"MDXLayout"}),(0,a.kt)("h1",{id:"targetable-items-"},"Targetable Items +"),(0,a.kt)("h2",{id:"making-targetable-anywhere"},"Making items targetable anywhere"),(0,a.kt)("p",null,"Just implement the ",(0,a.kt)("inlineCode",{parentName:"p"},"IItemTargetableAnywhere")," interface in your item's class:"),(0,a.kt)("pre",null,(0,a.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyTargetableAnywhereItem.cs"',title:'"MyTargetableAnywhereItem.cs"'},"// highlight-next-line\npublic class MyTargetableAnywhereItem : CustomItem, IItemTargetableAnywhere\n{\n    // highlight-start\n    public bool TargetFilter(Vector2 position) { /* ... */ }\n    public bool TargetPosition(Vector2 position) { /* ... */ }\n    public CustomTooltip TargetCursorText(Vector2 position) { /* ... */ }\n    // highlight-end\n}\n")),(0,a.kt)("p",null,(0,a.kt)("inlineCode",{parentName:"p"},"TargetFilter")," determines where the cursor should be highlighted, when using the current item."),(0,a.kt)("p",null,(0,a.kt)("inlineCode",{parentName:"p"},"TargetPosition")," uses the current item on the position. The return value indicates whether it was a success or not. You can play a ",(0,a.kt)("inlineCode",{parentName:"p"},'"CantDo"')," sound and make the player say something, if the item cannot be used. Returning ",(0,a.kt)("inlineCode",{parentName:"p"},"true")," will also play an animation."),(0,a.kt)("p",null,(0,a.kt)("inlineCode",{parentName:"p"},"TargetCursorText")," determines the text under the cursor when hovering over the specified position. ",(0,a.kt)("inlineCode",{parentName:"p"},"Text")," set to ",(0,a.kt)("inlineCode",{parentName:"p"},"null"),' will default to "Use", and ',(0,a.kt)("inlineCode",{parentName:"p"},"Color")," set to ",(0,a.kt)("inlineCode",{parentName:"p"},"null")," will default to ",(0,a.kt)(s.Z,{color:"#FFFFFF",mdxType:"ColorSquare"}),"."),(0,a.kt)("h2",{id:"examples"},"Examples"),(0,a.kt)(o.Z,{defaultValue:"usableteleporter",values:[{label:"Usable Teleporter",value:"usableteleporter"}],mdxType:"Tabs"},(0,a.kt)(l.Z,{value:"usableteleporter",mdxType:"TabItem"},(0,a.kt)(u.Z,{mdxType:"CodeSnippet"},'using UnityEngine;\n\nnamespace RogueLibsCore.Test\n{\n    [ItemCategories(RogueCategories.Usable, RogueCategories.Technology, RogueCategories.Stealth)]\n    public class UsableTeleporter : CustomItem, IItemTargetableAnywhere\n    {\n        [RLSetup]\n        public static void Setup()\n        {\n            RogueLibs.CreateCustomItem<UsableTeleporter>()\n                .WithName(new CustomNameInfo("Usable Teleporter"))\n                .WithDescription(new CustomNameInfo("Teleports you somewhere. Has limited uses."))\n                .WithSprite(Properties.Resources.UsableTeleporter)\n                .WithUnlock(new ItemUnlock\n                {\n                    UnlockCost = 10,\n                    LoadoutCost = 9,\n                    CharacterCreationCost = 5,\n                    Prerequisites = { VanillaItems.QuickEscapeTeleporter, nameof(WildBypasser) },\n                });\n\n            TeleportCursorText = RogueLibs.CreateCustomName("TeleportHere", NameTypes.Interface, new CustomNameInfo("Teleport here"));\n        }\n        private static CustomName TeleportCursorText;\n\n        public override void SetupDetails()\n        {\n            Item.itemType = ItemTypes.Tool;\n            Item.itemValue = 80;\n            Item.initCount = 2;\n            Item.rewardCount = 3;\n            Item.stackable = true;\n            Item.goesInToolbar = true;\n        }\n        public bool TargetFilter(Vector2 position)\n        {\n            TileData tileData = gc.tileInfo.GetTileData(position);\n            return !gc.tileInfo.IsOverlapping(position, "Anything") && tileData.wallMaterial == wallMaterialType.None;\n        }\n        public bool TargetPosition(Vector2 position)\n        {\n            if (!TargetFilter(position)) return false;\n\n            Owner.SpawnParticleEffect("Spawn", Owner.tr.position);\n            Owner.Teleport(position, false, true);\n            Owner.rb.velocity = Vector2.zero;\n            Owner.SpawnParticleEffect("Spawn", Owner.tr.position, false);\n            gc.audioHandler.Play(Owner, VanillaAudio.Spawn);\n\n            Count--;\n            return true;\n        }\n        public CustomTooltip TargetCursorText(Vector2 position) => TeleportCursorText;\n    }\n}\n'))))}h.isMDXComponent=!0}}]);