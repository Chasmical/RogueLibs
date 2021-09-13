(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[8893],{4214:function(t,e,n){"use strict";n.d(e,{Z:function(){return a}});var o=n(7294),i=n(1756);function a(t){var e=t.children,n=t.language;return o.createElement(i.Z,{className:"language-"+(n||"csharp")},e.replace(/\t/g,"    "))}},2725:function(t,e,n){"use strict";n.d(e,{Z:function(){return i}});var o=n(7294);function i(t){var e=t.color,n=(t.size||14)+"px";return o.createElement("div",{style:{display:"inline"}},o.createElement("div",{style:{display:"inline-block",width:n,height:n,background:e,marginRight:"2px"}}),o.createElement("div",{style:{display:"inline"}},e))}},2380:function(t,e,n){"use strict";n.d(e,{Z:function(){return l}});var o=n(7294),i=n(6010),a={container:"container_2sPt",cursorLocked:"cursorLocked_2zgq",normal:"normal_3G0b",hoverable:"hoverable_21Ge",selected:"selected_3EXb",locked:"locked_S145",sprite:"sprite_7g3Y",tooltip:"tooltip_2Zg4",count:"count_2Mnn"};function l(t){var e=t.sprite,n=t.tooltip,l=t.tooltipColor,r=t.count,s=t.countColor,m=t.hoverable,u=t.cantClick,c=t.type,p=void 0===c?"normal":c,d=t.onClick;return o.createElement("div",{onClick:d,className:(0,i.Z)(a.container,u&&a.cursorLocked,p&&a[p],m&&a.hoverable)},e&&o.createElement("img",{key:"sprite",className:a.sprite,src:e}),n&&o.createElement("span",{key:"tooltip",className:a.tooltip,style:{color:l||"#FFED00"}},n),r&&o.createElement("span",{key:"count",className:a.count,style:{color:s||"#FFFFFF"}},r))}},8826:function(t,e,n){"use strict";n.r(e),n.d(e,{PreviewTooltip:function(){return f},contentTitle:function(){return b},default:function(){return v},frontMatter:function(){return C},metadata:function(){return g},toc:function(){return k}});var o=n(2122),i=n(9756),a=n(7294),l=n(3905),r=n(1429),s=n(1016),m=n(4996),u=n(2725),c=n(2380),p=n(4214),d=n(5306),h=["components"],C={},b="Combinable Items",g={unversionedId:"dev/items/combinable-items",id:"dev/items/combinable-items",isDocsHomePage:!1,title:"Combinable Items",description:"Making items combinable",source:"@site/docs/dev/items/combinable-items.mdx",sourceDirName:"dev/items",slug:"/dev/items/combinable-items",permalink:"/RogueLibs/docs/dev/items/combinable-items",editUrl:"https://github.com/Abbysssal/RogueLibs/edit/main/website/docs/dev/items/combinable-items.mdx",tags:[],version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"Usable Items",permalink:"/RogueLibs/docs/dev/items/usable-items"},next:{title:"Targetable Items",permalink:"/RogueLibs/docs/dev/items/targetable-items"}};function f(t){t.props;var e=(0,a.useState)((0,m.Z)("/img/TestItem.png")),n=e[0],o=e[1],i=(0,a.useState)("#FFED00"),r=i[0],s=i[1],u=(0,a.useState)("$123"),p=u[0],d=u[1];return(0,l.kt)("div",{style:{padding:"10px",border:"5px dashed var(--ifm-menu-color-background-hover)",width:"max-content"}},(0,l.kt)("input",{type:"file",accept:"image/*",onChange:function(t){if(t.target.files[0]){var e=new FileReader;e.addEventListener("load",(function(){return o(e.result)})),e.readAsDataURL(t.target.files[0])}},style:{margin:"5px"}}),(0,l.kt)("div",{style:{margin:"5px"}},(0,l.kt)(c.Z,{sprite:n,tooltip:p,tooltipColor:r,mdxType:"InventorySlot"})),(0,l.kt)("input",{type:"text",placeholder:"$123",onChange:function(t){return d(t.target.value)},style:{fontSize:"22px",margin:"5px"}}),(0,l.kt)("input",{type:"color",value:r,onChange:function(t){return s(t.target.value)}}))}var k=[{value:"Making items combinable",id:"making-combinable",children:[{value:"Inventory Slot Preview",id:"slot-preview",children:[]}]},{value:"Examples",id:"examples",children:[]}],I={PreviewTooltip:f,toc:k};function v(t){var e=t.components,n=(0,i.Z)(t,h);return(0,l.kt)("wrapper",(0,o.Z)({},I,n,{components:e,mdxType:"MDXLayout"}),(0,l.kt)("h1",{id:"combinable-items"},"Combinable Items"),(0,l.kt)("h2",{id:"making-combinable"},"Making items combinable"),(0,l.kt)("p",null,"Just implement the ",(0,l.kt)("inlineCode",{parentName:"p"},"IItemCombinable")," interface in your item's class:"),(0,l.kt)("pre",null,(0,l.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyCombinableItem.cs"',title:'"MyCombinableItem.cs"'},"// highlight-next-line\npublic class MyCombinableItem : CustomItem, IItemCombinable\n{\n    // highlight-start\n    public bool CombineFilter(InvItem other) { /* ... */ }\n    public bool CombineItems(InvItem other) { /* ... */ }\n    public CustomTooltip CombineTooltip(InvItem other) { /* ... */ }\n    public CustomTooltip CombineCursorText(InvItem other) { /* ... */ }\n    // highlight-end\n}\n")),(0,l.kt)("p",null,"Plus, your item's type must be ",(0,l.kt)("inlineCode",{parentName:"p"},'"Combine"'),":"),(0,l.kt)("pre",null,(0,l.kt)("code",{parentName:"pre",className:"language-csharp"},"    public override void SetupDetails()\n    {\n        // highlight-next-line\n        Item.itemType = ItemTypes.Combine;\n        /* ... */\n    }\n")),(0,l.kt)("p",null,(0,l.kt)("inlineCode",{parentName:"p"},"CombineFilter")," determines what items will be highlighted, when combining the current item."),(0,l.kt)("p",null,(0,l.kt)("inlineCode",{parentName:"p"},"CombineItems")," combines the current item with the other one. The return value indicates whether it was a success or not. Usually you'd just play a ",(0,l.kt)("inlineCode",{parentName:"p"},'"CantDo"')," sound, if the items cannot be combined. Returning ",(0,l.kt)("inlineCode",{parentName:"p"},"true")," will also play an animation."),(0,l.kt)("p",null,(0,l.kt)("inlineCode",{parentName:"p"},"CombineTooltip")," determines the tooltip in the upper-left corner of the inventory slot. ",(0,l.kt)("inlineCode",{parentName:"p"},"Text")," set to ",(0,l.kt)("inlineCode",{parentName:"p"},"null")," will default to an empty string, and ",(0,l.kt)("inlineCode",{parentName:"p"},"Color")," set to ",(0,l.kt)("inlineCode",{parentName:"p"},"null")," will default to ",(0,l.kt)(u.Z,{color:"#FFED00",mdxType:"ColorSquare"}),". ",(0,l.kt)("a",{parentName:"p",href:"#slot-preview"},"See the tool below"),"."),(0,l.kt)("p",null,(0,l.kt)("inlineCode",{parentName:"p"},"CombineCursorText")," determines the cursor text when hovering over the item. ",(0,l.kt)("inlineCode",{parentName:"p"},"Text")," set to ",(0,l.kt)("inlineCode",{parentName:"p"},"null"),' will default to "Combine", and ',(0,l.kt)("inlineCode",{parentName:"p"},"Color")," set to ",(0,l.kt)("inlineCode",{parentName:"p"},"null")," will default to ",(0,l.kt)(u.Z,{color:"#FFFFFF",mdxType:"ColorSquare"}),"."),(0,l.kt)("h3",{id:"slot-preview"},"Inventory Slot Preview"),(0,l.kt)("p",null,"Wanna see how your ",(0,l.kt)("inlineCode",{parentName:"p"},"CombineTooltip")," will look in the game? Check out this small tool:"),(0,l.kt)(f,{mdxType:"PreviewTooltip"}),(0,l.kt)("h2",{id:"examples"},"Examples"),(0,l.kt)(r.Z,{defaultValue:"ammobox",values:[{label:"Centrifuge",value:"centrifuge"},{label:"Spice Rack",value:"spicerack"},{label:"Ammo Box",value:"ammobox"}],mdxType:"Tabs"},(0,l.kt)(s.Z,{value:"centrifuge",mdxType:"TabItem"},(0,l.kt)("p",null,"A simple example that inverts the Syringes' effects."),(0,l.kt)(p.Z,{mdxType:"CodeSnippet"},'using System;\nusing System.Collections.Generic;\nusing System.Linq;\nusing System.Text;\nusing System.Threading.Tasks;\n\nnamespace RogueLibsCore.Test\n{\n\tpublic class Centrifuge : CustomItem, IItemCombinable\n\t{\n\t\t[RLSetup]\n\t\tpublic static void Setup()\n\t\t{\n\t\t\t/*\n\t\t\tRogueLibs.CreateCustomItem<Centrifuge>()\n\t\t\t\t.WithName(new CustomNameInfo("Centrifuge"))\n\t\t\t\t.WithDescription(new CustomNameInfo("Combine with a syringe to invert its effect."))\n\t\t\t\t.WithSprite(Properties.Resources.Centrifuge)\n\t\t\t\t.WithUnlock(new ItemUnlock\n\t\t\t\t{\n\t\t\t\t\tUnlockCost = 10,\n\t\t\t\t\tLoadoutCost = 5,\n\t\t\t\t\tCharacterCreationCost = 3,\n\t\t\t\t\tPrerequisites = { VanillaItems.Antidote },\n\t\t\t\t});\n\t\t\t*/\n\t\t}\n\n\t\tpublic override void SetupDetails()\n\t\t{\n\t\t\tItem.itemType = ItemTypes.Combine;\n\t\t\tItem.itemValue = 8;\n\t\t\tItem.initCount = 10;\n\t\t\tItem.stackable = true;\n\t\t\tItem.hasCharges = true;\n\t\t}\n\n\t\tprivate static readonly Dictionary<string, string> invertDictionary = new Dictionary<string, string>\n\t\t{\n\t\t\t[VanillaEffects.Poisoned] = VanillaEffects.RegenerateHealth,\n\t\t\t[VanillaEffects.Slow] = VanillaEffects.Fast,\n\t\t\t[VanillaEffects.Weak] = VanillaEffects.Strength,\n\t\t\t[VanillaEffects.Acid] = VanillaEffects.Invincible,\n\t\t\t[VanillaEffects.Confused] = VanillaEffects.Invisible,\n\t\t};\n\t\tstatic Centrifuge()\n\t\t{\n\t\t\tforeach (KeyValuePair<string, string> pair in invertDictionary.ToArray())\n\t\t\t\tinvertDictionary.Add(pair.Value, pair.Key);\n\t\t}\n\n\t\tpublic bool CombineFilter(InvItem other) => other.invItemName == VanillaItems.Syringe\n\t\t\t&& other.contents.Count > 0 && invertDictionary.ContainsKey(other.contents[0]);\n\t\tpublic bool CombineItems(InvItem other)\n\t\t{\n\t\t\tif (!CombineFilter(other)) return false;\n\n\t\t\tother.contents[0] = invertDictionary[other.contents[0]];\n\n\t\t\tCount--;\n\t\t\tgc.audioHandler.Play(Owner, VanillaAudio.CombineItem);\n\t\t\treturn true;\n\t\t}\n\t\tpublic CustomTooltip CombineCursorText(InvItem other) => default;\n\t\tpublic CustomTooltip CombineTooltip(InvItem other) => default;\n\t}\n}\n')),(0,l.kt)(s.Z,{value:"spicerack",mdxType:"TabItem"},(0,l.kt)("p",null,"A simple example, with custom hooks to keep track of seasoned items."),(0,l.kt)("p",null,"See more about custom hooks ",(0,l.kt)("a",{parentName:"p",href:"../hooks/hooks"},"here"),"."),(0,l.kt)(p.Z,{mdxType:"CodeSnippet"},d.Z)),(0,l.kt)(s.Z,{value:"ammobox",mdxType:"TabItem"},(0,l.kt)("p",null,"A pretty complicated example with a lot of math."),(0,l.kt)(p.Z,{mdxType:"CodeSnippet"},'using UnityEngine;\n\nnamespace RogueLibsCore.Test\n{\n\t[ItemCategories(RogueCategories.Technology, RogueCategories.GunAccessory, RogueCategories.Guns)]\n\tpublic class AmmoBox : CustomItem, IItemCombinable\n\t{\n\t\t[RLSetup]\n\t\tpublic static void Setup()\n\t\t{\n\t\t\tRogueLibs.CreateCustomItem<AmmoBox>()\n\t\t\t\t.WithName(new CustomNameInfo("Ammo Box"))\n\t\t\t\t.WithDescription(new CustomNameInfo("Combine with any refillable weapon to refill it. Limited ammo."))\n\t\t\t\t.WithSprite(Properties.Resources.AmmoBox)\n\t\t\t\t.WithUnlock(new ItemUnlock\n\t\t\t\t{\n\t\t\t\t\tUnlockCost = 10,\n\t\t\t\t\tLoadoutCost = 5,\n\t\t\t\t\tCharacterCreationCost = 3,\n\t\t\t\t\tPrerequisites = { VanillaItems.KillAmmunizer },\n\t\t\t\t});\n\t\t}\n\n\t\tpublic override void SetupDetails()\n\t\t{\n\t\t\tItem.itemType = ItemTypes.Combine;\n\t\t\tItem.itemValue = 4;\n\t\t\tItem.initCount = 100;\n\t\t\tItem.rewardCount = 200;\n\t\t\tItem.hasCharges = true;\n\t\t\tItem.stackable = true;\n\t\t}\n\t\tpublic bool CombineFilter(InvItem other) => other.itemType == ItemTypes.WeaponProjectile && !other.noRefills;\n\t\tpublic bool CombineItems(InvItem other)\n\t\t{\n\t\t\tif (!CombineFilter(other))\n\t\t\t{\n\t\t\t\tgc.audioHandler.Play(Owner, VanillaAudio.CantDo);\n\t\t\t\treturn false;\n\t\t\t}\n\t\t\tif (other.invItemCount >= other.maxAmmo)\n\t\t\t{\n\t\t\t\tOwner.SayDialogue("AmmoDispenserFull");\n\t\t\t\tgc.audioHandler.Play(Owner, VanillaAudio.CantDo);\n\t\t\t\treturn false;\n\t\t\t}\n\n\t\t\tint amountToRefill = other.maxAmmo - other.invItemCount;\n\t\t\tfloat singleCost = (float)other.itemValue / other.maxAmmo;\n\t\t\tif (Owner.oma.superSpecialAbility && (Owner.agentName == VanillaAgents.Soldier || Owner.agentName == VanillaAgents.Doctor))\n\t\t\t\tsingleCost = 0f;\n\n\t\t\tint affordableAmount = (int)Mathf.Ceil(Count / singleCost);\n\t\t\tint willBeBought = Mathf.Min(affordableAmount, amountToRefill);\n\t\t\tint willBeReduced = (int)Mathf.Min(Count, willBeBought * singleCost);\n\n\t\t\tCount -= willBeReduced;\n\t\t\tother.invItemCount += willBeBought;\n\t\t\tOwner.SayDialogue("AmmoDispenserFilled");\n\t\t\tgc.audioHandler.Play(Owner, VanillaAudio.BuyItem);\n\t\t\treturn true;\n\t\t}\n\n\t\tpublic CustomTooltip CombineTooltip(InvItem other)\n\t\t{\n\t\t\tif (!CombineFilter(other)) return default;\n\n\t\t\tint amountToRefill = other.maxAmmo - other.invItemCount;\n\t\t\tif (amountToRefill == 0) return default;\n\n\t\t\tfloat singleCost = (float)other.itemValue / other.maxAmmo;\n\t\t\tif (Owner.oma.superSpecialAbility && (Owner.agentName == VanillaAgents.Soldier || Owner.agentName == VanillaAgents.Doctor))\n\t\t\t\tsingleCost = 0f;\n\t\t\tint cost = (int)Mathf.Floor(amountToRefill * singleCost);\n\t\t\tint canAfford = (int)Mathf.Ceil(Count / singleCost);\n\n\t\t\treturn "+" + Mathf.Min(amountToRefill, canAfford) + " (" + Mathf.Min(cost, Count) + ")";\n\t\t}\n\n\t\tpublic CustomTooltip CombineCursorText(InvItem other) => gc.nameDB.GetName("RefillGun", NameTypes.Interface);\n\t\t// it\'s one of the vanilla dialogues, so there\'s no need to define it in the mod\n\t}\n}\n'))))}v.isMDXComponent=!0},5306:function(t,e){"use strict";e.Z='using UnityEngine;\n\nnamespace RogueLibsCore.Test\n{\n\t[ItemCategories(RogueCategories.Food, RogueCategories.Health)]\n\tpublic class SpiceRack : CustomItem, IItemCombinable\n\t{\n\t\t[RLSetup]\n\t\tpublic static void Setup()\n\t\t{\n\t\t\tRogueLibs.CreateCustomItem<SpiceRack>()\n\t\t\t\t.WithName(new CustomNameInfo("Spice Rack"))\n\t\t\t\t.WithDescription(new CustomNameInfo("Combine with any food item to increase its healing properties."))\n\t\t\t\t.WithSprite(Properties.Resources.SpiceRack)\n\t\t\t\t.WithUnlock(new ItemUnlock\n\t\t\t\t{\n\t\t\t\t\tUnlockCost = 10,\n\t\t\t\t\tLoadoutCost = 3,\n\t\t\t\t\tCharacterCreationCost = 2,\n\t\t\t\t\tPrerequisites = { VanillaItems.FoodProcessor },\n\t\t\t\t});\n\n\t\t\tSeasonCursorText = RogueLibs.CreateCustomName("SeasonItem", NameTypes.Interface, new CustomNameInfo("Season"));\n\t\t}\n\t\tprivate static CustomName SeasonCursorText;\n\n\t\tpublic override void SetupDetails()\n\t\t{\n\t\t\tItem.itemType = ItemTypes.Combine;\n\t\t\tItem.itemValue = 4;\n\t\t\tItem.initCount = 10;\n\t\t\tItem.rewardCount = 15;\n\t\t\tItem.stackable = true;\n\t\t\tItem.hasCharges = true;\n\t\t}\n\t\tpublic bool CombineFilter(InvItem other)\n\t\t{\n\t\t\tif (other.itemType != ItemTypes.Food || other.healthChange is 0\n\t\t\t\t|| !other.Categories.Contains(RogueCategories.Food)) return false;\n\n\t\t\tSpicedHook hook = other.GetHook<SpicedHook>();\n\t\t\treturn hook is null || hook.Spiciness < 3;\n\t\t}\n\t\tpublic bool CombineItems(InvItem other)\n\t\t{\n\t\t\tif (!CombineFilter(other)) return false;\n\n\t\t\tSpicedHook hook = other.GetHook<SpicedHook>() ?? other.AddHook<SpicedHook>();\n\t\t\thook.IncreaseSpiciness();\n\n\t\t\tCount--;\n\t\t\tgc.audioHandler.Play(Owner, VanillaAudio.CombineItem);\n\t\t\treturn true;\n\t\t}\n\t\tpublic CustomTooltip CombineCursorText(InvItem other) => SeasonCursorText;\n\t\tpublic CustomTooltip CombineTooltip(InvItem other)\n\t\t{\n\t\t\tif (!CombineFilter(other)) return default;\n\n\t\t\tSpicedHook hook = other.GetHook<SpicedHook>();\n\t\t\tint bonus = hook is null ? (int)Mathf.Ceil(other.healthChange / 4f) : hook.HealthBonus;\n\t\t\treturn new CustomTooltip($"+{bonus}", Color.green);\n\t\t}\n\n\t\tprivate class SpicedHook : HookBase<InvItem>\n\t\t{\n\t\t\tprotected override void Initialize()\n\t\t\t\t=> HealthBonus = (int)Mathf.Ceil(Instance.healthChange / 4f);\n\n\t\t\tpublic int HealthBonus { get; private set; }\n\t\t\tpublic int Spiciness { get; private set; }\n\n\t\t\tpublic void IncreaseSpiciness()\n\t\t\t{\n\t\t\t\tif (Spiciness is 3) return;\n\n\t\t\t\tSpiciness++;\n\t\t\t\tInstance.healthChange += HealthBonus;\n\t\t\t}\n\t\t}\n\t}\n}\n'}}]);