(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[242],{2268:function(t,e,n){"use strict";n.d(e,{Z:function(){return s}});var o=n(2122),i=n(9756),a=n(7294),r=n(1756),l=["children","language"];function s(t){var e=t.children,n=t.language,s=(0,i.Z)(t,l);return a.createElement(r.Z,(0,o.Z)({className:n||"language-csharp"},s),e.replace(/\t/g,"    "))}},7052:function(t,e,n){"use strict";n.d(e,{Z:function(){return r}});var o=n(9756),i=n(7294),a=["color","size"];function r(t){var e=t.color,n=t.size;(0,o.Z)(t,a);return n=(n||14)+"px",i.createElement("div",{style:{display:"inline"}},i.createElement("div",{style:{display:"inline-block",width:n,height:n,background:e,marginRight:"2px"}}),i.createElement("div",{style:{display:"inline"}},e))}},9309:function(t,e,n){"use strict";n.d(e,{Z:function(){return l}});var o=n(2122),i=n(9756),a=n(7294),r=["children"];function l(t){var e=t.children,n=(0,i.Z)(t,r);return a.createElement("div",(0,o.Z)({role:"tabpanel"},n),e)}},8952:function(t,e,n){"use strict";n.d(e,{Z:function(){return p}});var o=n(7294),i=n(9443);var a=function(){var t=(0,o.useContext)(i.Z);if(null==t)throw new Error('"useUserPreferencesContext" is used outside of "Layout" component.');return t},r=n(6010),l="tabItem_2O3c",s="tabItemActive_Fpbe",m="tab_1pgU";var u=37,c=39;var p=function(t){var e=t.lazy,n=t.block,i=t.defaultValue,p=t.values,d=t.groupId,h=t.className,b=a(),C=b.tabGroupChoices,f=b.setTabGroupChoices,g=(0,o.useState)(i),k=g[0],v=g[1],I=o.Children.toArray(t.children),y=[];if(null!=d){var w=C[d];null!=w&&w!==k&&p.some((function(t){return t.value===w}))&&v(w)}var T=function(t){var e=t.currentTarget,n=y.indexOf(e),o=p[n].value;v(o),null!=d&&(f(d,o),setTimeout((function(){var t,n,o,i,a,r,l,m;(t=e.getBoundingClientRect(),n=t.top,o=t.left,i=t.bottom,a=t.right,r=window,l=r.innerHeight,m=r.innerWidth,n>=0&&a<=m&&i<=l&&o>=0)||(e.scrollIntoView({block:"center",behavior:"smooth"}),e.classList.add(s),setTimeout((function(){return e.classList.remove(s)}),2e3))}),150))},x=function(t){var e,n;switch(t.keyCode){case c:var o=y.indexOf(t.target)+1;n=y[o]||y[0];break;case u:var i=y.indexOf(t.target)-1;n=y[i]||y[y.length-1]}null==(e=n)||e.focus()},S=function(t,e){return e.value===t||e.values&&-1!=e.values.indexOf(t)};return o.createElement("div",{className:"tabs-container"},o.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:(0,r.Z)("tabs",{"tabs--block":n},h)},p.map((function(t){var e=t.value,n=t.label;return o.createElement("li",{role:"tab",tabIndex:k===e?0:-1,"aria-selected":k===e,className:(0,r.Z)("tabs__item",l,{"tabs__item--active":k===e}),key:e,ref:function(t){return y.push(t)},onKeyDown:x,onFocus:T,onClick:T},n)}))),e?(0,o.cloneElement)(I.filter((function(t){return S(k,t.props)}))[0],{className:m}):o.createElement("div",null,I.map((function(t,e){return(0,o.cloneElement)(t,{key:e,hidden:!S(k,t.props),className:m})}))),o.createElement("br",null))}},7376:function(t,e,n){"use strict";n.r(e),n.d(e,{PreviewTooltip:function(){return w},contentTitle:function(){return I},default:function(){return S},frontMatter:function(){return v},metadata:function(){return y},toc:function(){return T}});var o=n(2122),i=n(9756),a=n(7294),r=n(3905),l=n(8952),s=n(9309),m=n(4996),u=n(7052),c="container_373Z",p="slot_32Ts",d="sprite_ipAF",h="tooltip_2_kr",b="count_39FS",C=["sprite","tooltip","tooltipColor","count","countColor"];function f(t){var e=t.sprite,n=t.tooltip,o=t.tooltipColor,r=t.count,l=t.countColor;(0,i.Z)(t,C);return a.createElement("div",{className:c},a.createElement("img",{key:"slot",className:p,src:(0,m.Z)("/img/SetupDetailsGenerator/ToolbarSlot.png")}),null==e?[]:a.createElement("img",{key:"sprite",className:d,src:e}),null==n?[]:a.createElement("span",{key:"tooltip",className:h},a.createElement("span",{style:{color:o||"#FFED00"}},n)),null==r?[]:a.createElement("span",{key:"count",className:b},a.createElement("span",{style:{color:l||"#FFFFFF"}},r)))}var g=n(2268),k=["components"],v={},I="Combinable Items",y={unversionedId:"items/combinable-items",id:"items/combinable-items",isDocsHomePage:!1,title:"Combinable Items",description:"Making items combinable",source:"@site/docs/items/combinable-items.mdx",sourceDirName:"items",slug:"/items/combinable-items",permalink:"/RogueLibs/ru/docs/items/combinable-items",editUrl:"https://github.com/Abbysssal/RogueLibs/edit/master/website/docs/items/combinable-items.mdx",version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"Usable Items",permalink:"/RogueLibs/ru/docs/items/usable-items"},next:{title:"Targetable Items",permalink:"/RogueLibs/ru/docs/items/targetable-items"}};function w(t){t.props;var e=(0,a.useState)((0,m.Z)("/img/SetupDetailsGenerator/TestItem.png")),n=e[0],o=e[1],i=(0,a.useState)("#FFED00"),l=i[0],s=i[1],u=(0,a.useState)("$123"),c=u[0],p=u[1];return(0,r.kt)("div",{style:{padding:"10px",border:"5px dashed var(--ifm-menu-color-background-hover)",width:"max-content"}},(0,r.kt)("input",{type:"file",accept:"image/*",onChange:function(t){if(t.target.files[0]){var e=new FileReader;e.addEventListener("load",(function(){return o(e.result)})),e.readAsDataURL(t.target.files[0])}},style:{margin:"5px"}}),(0,r.kt)("div",{style:{margin:"5px"}},(0,r.kt)(f,{sprite:n,tooltip:c,tooltipColor:l,mdxType:"InventorySlot"})),(0,r.kt)("input",{type:"text",placeholder:"$123",onChange:function(t){return p(t.target.value)},style:{fontSize:"22px",margin:"5px"}}),(0,r.kt)("input",{type:"color",value:l,onChange:function(t){return s(t.target.value)}}))}var T=[{value:"Making items combinable",id:"making-combinable",children:[{value:"Inventory Slot Preview",id:"slot-preview",children:[]}]},{value:"Examples",id:"examples",children:[]}],x={PreviewTooltip:w,toc:T};function S(t){var e=t.components,n=(0,i.Z)(t,k);return(0,r.kt)("wrapper",(0,o.Z)({},x,n,{components:e,mdxType:"MDXLayout"}),(0,r.kt)("h1",{id:"combinable-items"},"Combinable Items"),(0,r.kt)("h2",{id:"making-combinable"},"Making items combinable"),(0,r.kt)("p",null,"Just implement the ",(0,r.kt)("inlineCode",{parentName:"p"},"IItemCombinable")," interface in your item's class:"),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyCombinableItem.cs"',title:'"MyCombinableItem.cs"'},"// highlight-next-line\npublic class MyCombinableItem : CustomItem, IItemCombinable\n{\n    // highlight-start\n    public bool CombineFilter(InvItem other) { /* ... */ }\n    public bool CombineItems(InvItem other) { /* ... */ }\n    public CustomTooltip CombineTooltip(InvItem other) { /* ... */ }\n    public CustomTooltip CombineCursorText(InvItem other) { /* ... */ }\n    // highlight-end\n}\n")),(0,r.kt)("p",null,"Plus, your item's type must be ",(0,r.kt)("inlineCode",{parentName:"p"},'"Combine"'),":"),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},"    public override void SetupDetails()\n    {\n        // highlight-next-line\n        Item.itemType = ItemTypes.Combine;\n        /* ... */\n    }\n")),(0,r.kt)("p",null,(0,r.kt)("inlineCode",{parentName:"p"},"CombineFilter")," determines what items will be highlighted, when combining the current item."),(0,r.kt)("p",null,(0,r.kt)("inlineCode",{parentName:"p"},"CombineItems")," combines the current item with the other one. The return value indicates whether it was a success or not. Usually you'd just play a ",(0,r.kt)("inlineCode",{parentName:"p"},'"CantDo"')," sound, if the items cannot be combined. Returning ",(0,r.kt)("inlineCode",{parentName:"p"},"true")," will also play an animation."),(0,r.kt)("p",null,(0,r.kt)("inlineCode",{parentName:"p"},"CombineTooltip")," determines the tooltip in the upper-left corner of the inventory slot. Text set to ",(0,r.kt)("inlineCode",{parentName:"p"},"null")," will default to an empty string, and Color set to ",(0,r.kt)("inlineCode",{parentName:"p"},"null")," will default to ",(0,r.kt)(u.Z,{color:"#FFED00",mdxType:"ColorSquare"}),". ",(0,r.kt)("a",{parentName:"p",href:"#slot-preview"},"See the tool below"),"."),(0,r.kt)("p",null,(0,r.kt)("inlineCode",{parentName:"p"},"CombineCursorText")," determines the cursor text when hovering over the item. You can also specify the cursor text's color. Text set to ",(0,r.kt)("inlineCode",{parentName:"p"},"null"),' will default to "Combine", and Color set to ',(0,r.kt)("inlineCode",{parentName:"p"},"null")," will default to ",(0,r.kt)(u.Z,{color:"#FFFFFF",mdxType:"ColorSquare"}),"."),(0,r.kt)("h3",{id:"slot-preview"},"Inventory Slot Preview"),(0,r.kt)("p",null,"Wanna see how your ",(0,r.kt)("inlineCode",{parentName:"p"},"CombineTooltip")," will look in the game? Check out this small tool:"),(0,r.kt)(w,{mdxType:"PreviewTooltip"}),(0,r.kt)("h2",{id:"examples"},"Examples"),(0,r.kt)(l.Z,{defaultValue:"ammobox",values:[{label:"Ammo Box",value:"ammobox"},{label:"Spice Rack",value:"spicerack"}],mdxType:"Tabs"},(0,r.kt)(s.Z,{value:"ammobox",mdxType:"TabItem"},(0,r.kt)("p",null,"A pretty complicated example with a lot of math."),(0,r.kt)(g.Z,{mdxType:"CodeSnippet"},'using UnityEngine;\n\nnamespace RogueLibsCore.Test\n{\n\t[ItemCategories(RogueCategories.Technology, RogueCategories.GunAccessory, RogueCategories.Guns)]\n\tpublic class AmmoBox : CustomItem, IItemCombinable\n\t{\n\t\t[RLSetup]\n\t\tpublic static void Setup()\n\t\t{\n\t\t\tRogueLibs.CreateCustomItem<AmmoBox>()\n\t\t\t\t.WithName(new CustomNameInfo("Ammo Box"))\n\t\t\t\t.WithDescription(new CustomNameInfo("Combine with any refillable weapon to refill it. Limited ammo."))\n\t\t\t\t.WithSprite(Properties.Resources.AmmoBox)\n\t\t\t\t.WithUnlock(new ItemUnlock\n\t\t\t\t{\n\t\t\t\t\tUnlockCost = 10,\n\t\t\t\t\tCharacterCreationCost = 3,\n\t\t\t\t\tLoadoutCost = 3,\n\t\t\t\t\tPrerequisites = { "AmmoProcessor", "KillProfiterAmmo", "AmmoCapacityMod" },\n\t\t\t\t});\n\t\t}\n\n\t\tpublic override void SetupDetails()\n\t\t{\n\t\t\tItem.itemType = ItemTypes.Combine;\n\t\t\tItem.itemValue = 4;\n\t\t\tItem.initCount = 100;\n\t\t\tItem.rewardCount = 200;\n\t\t\tItem.hasCharges = true;\n\t\t\tItem.stackable = true;\n\t\t}\n\t\tpublic bool CombineFilter(InvItem other) => other.itemType == ItemTypes.WeaponProjectile && !other.noRefills;\n\t\tpublic bool CombineItems(InvItem other)\n\t\t{\n\t\t\tif (!CombineFilter(other))\n\t\t\t{\n\t\t\t\tgc.audioHandler.Play(Owner, "CantDo");\n\t\t\t\treturn false;\n\t\t\t}\n\t\t\tif (other.invItemCount >= other.maxAmmo)\n\t\t\t{\n\t\t\t\tOwner.SayDialogue("AmmoDispenserFull");\n\t\t\t\tgc.audioHandler.Play(Owner, "CantDo");\n\t\t\t\treturn false;\n\t\t\t}\n\n\t\t\tint amountToRefill = other.maxAmmo - other.invItemCount;\n\t\t\tfloat singleCost = (float)other.itemValue / other.maxAmmo;\n\t\t\tif (Owner.oma.superSpecialAbility && (Owner.agentName == "Soldier" || Owner.agentName == "Doctor"))\n\t\t\t\tsingleCost = 0f;\n\n\t\t\tint affordableAmount = (int)Mathf.Ceil(Count / singleCost);\n\t\t\tint willBeBought = Mathf.Min(affordableAmount, amountToRefill);\n\t\t\tint willBeReduced = (int)Mathf.Min(Count, willBeBought * singleCost);\n\n\t\t\tCount -= willBeReduced;\n\t\t\tother.invItemCount += willBeBought;\n\t\t\tOwner.SayDialogue("AmmoDispenserFilled");\n\t\t\tgc.audioHandler.Play(Owner, "BuyItem");\n\t\t\treturn true;\n\t\t}\n\n\t\tpublic CustomTooltip CombineTooltip(InvItem other)\n\t\t{\n\t\t\tif (!CombineFilter(other)) return default;\n\n\t\t\tint amountToRefill = other.maxAmmo - other.invItemCount;\n\t\t\tif (amountToRefill == 0) return default;\n\n\t\t\tfloat singleCost = (float)other.itemValue / other.maxAmmo;\n\t\t\tif (Owner.oma.superSpecialAbility && (Owner.agentName == "Soldier" || Owner.agentName == "Doctor"))\n\t\t\t\tsingleCost = 0f;\n\t\t\tint cost = (int)Mathf.Floor(amountToRefill * singleCost);\n\t\t\tint canAfford = (int)Mathf.Ceil(Count / singleCost);\n\n\t\t\treturn "+" + Mathf.Min(amountToRefill, canAfford) + " (" + Mathf.Min(cost, Count) + ")";\n\t\t}\n\n\t\tpublic CustomTooltip CombineCursorText(InvItem other) => gc.nameDB.GetName("RefillGun", "Interface");\n\t\t// it\'s one of the vanilla dialogues, so there\'s no need to define it in the mod\n\t}\n}\n')),(0,r.kt)(s.Z,{value:"spicerack",mdxType:"TabItem"},(0,r.kt)("p",null,"A simple example, with custom hooks to keep track of seasoned items."),(0,r.kt)(g.Z,{mdxType:"CodeSnippet"},'using UnityEngine;\n\nnamespace RogueLibsCore.Test\n{\n\t[ItemCategories(RogueCategories.Food, RogueCategories.Health)]\n\tpublic class SpiceRack : CustomItem, IItemCombinable\n\t{\n\t\t[RLSetup]\n\t\tpublic static void Setup()\n\t\t{\n\t\t\tRogueLibs.CreateCustomItem<SpiceRack>()\n\t\t\t\t.WithName(new CustomNameInfo("Spice Rack"))\n\t\t\t\t.WithDescription(new CustomNameInfo("Combine with any food item to increase its healing properties."))\n\t\t\t\t.WithSprite(Properties.Resources.SpiceRack)\n\t\t\t\t.WithUnlock(new ItemUnlock\n\t\t\t\t{\n\t\t\t\t\tUnlockCost = 10,\n\t\t\t\t\tCharacterCreationCost = 3,\n\t\t\t\t\tLoadoutCost = 3,\n\t\t\t\t\tPrerequisites = { "FoodProcessor", nameof(QuantumFud) },\n\t\t\t\t});\n\n\t\t\tSeasonCursorText = RogueLibs.CreateCustomName("Season", "Interface", new CustomNameInfo("Season"));\n\t\t}\n\t\tprivate static CustomName SeasonCursorText;\n\n\t\tpublic override void SetupDetails()\n\t\t{\n\t\t\tItem.itemType = ItemTypes.Combine;\n\t\t\tItem.itemValue = 4;\n\t\t\tItem.initCount = 10;\n\t\t\tItem.rewardCount = 15;\n\t\t\tItem.stackable = true;\n\t\t\tItem.hasCharges = true;\n\t\t}\n\t\tpublic bool CombineFilter(InvItem other)\n\t\t{\n\t\t\tif (other.itemType != ItemTypes.Food || other.healthChange is 0\n\t\t\t\t|| !other.Categories.Contains(RogueCategories.Food)) return false;\n\n\t\t\tSpicedHook hook = other.GetHook<SpicedHook>();\n\t\t\treturn hook is null || hook.Spiciness < 3;\n\t\t}\n\t\tpublic bool CombineItems(InvItem other)\n\t\t{\n\t\t\tif (!CombineFilter(other)) return false;\n\n\t\t\tSpicedHook hook = other.GetHook<SpicedHook>() ?? other.AddHook<SpicedHook>();\n\t\t\thook.IncreaseSpiciness();\n\n\t\t\tCount--;\n\t\t\tgc.audioHandler.Play(Owner, "CombineItem");\n\t\t\treturn true;\n\t\t}\n\t\tpublic CustomTooltip CombineCursorText(InvItem other) => SeasonCursorText;\n\t\tpublic CustomTooltip CombineTooltip(InvItem other)\n\t\t{\n\t\t\tif (!CombineFilter(other)) return default;\n\n\t\t\tSpicedHook hook = other.GetHook<SpicedHook>();\n\t\t\tint bonus = hook is null ? (int)Mathf.Ceil(other.healthChange / 4f) : hook.HealthBonus;\n\t\t\treturn new CustomTooltip($"+{bonus}", Color.green);\n\t\t}\n\n\t\tprivate class SpicedHook : HookBase<InvItem>\n\t\t{\n\t\t\tprotected override void Initialize()\n\t\t\t\t=> HealthBonus = (int)Mathf.Ceil(Instance.healthChange / 4f);\n\n\t\t\tpublic int HealthBonus { get; private set; }\n\t\t\tpublic int Spiciness { get; private set; }\n\n\t\t\tpublic void IncreaseSpiciness()\n\t\t\t{\n\t\t\t\tif (Spiciness is 3) return;\n\n\t\t\t\tSpiciness++;\n\t\t\t\tInstance.healthChange += HealthBonus;\n\t\t\t}\n\t\t}\n\t}\n}\n'))))}S.isMDXComponent=!0}}]);