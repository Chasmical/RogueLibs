"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[8893],{9761:(e,n,t)=>{t.r(n),t.d(n,{PreviewTooltip:()=>v,assets:()=>g,contentTitle:()=>f,default:()=>y,frontMatter:()=>b,metadata:()=>C,toc:()=>I});var i=t(5893),o=t(1151),a=t(5878),l=t(1016),r=t(4996),s=t(2725),u=t(5880),c=t(7294),m=t(4214);const h='using System.Collections.Generic;\nusing System.Linq;\n\nnamespace RogueLibsCore.Test\n{\n    public class Centrifuge : CustomItem, IItemCombinable\n    {\n        [RLSetup]\n        public static void Setup()\n        {\n            /*\n            RogueLibs.CreateCustomItem<Centrifuge>()\n                .WithName(new CustomNameInfo("Centrifuge"))\n                .WithDescription(new CustomNameInfo("Combine with a syringe to invert its effect."))\n                .WithSprite(Properties.Resources.Centrifuge)\n                .WithUnlock(new ItemUnlock\n                {\n                    UnlockCost = 10,\n                    LoadoutCost = 5,\n                    CharacterCreationCost = 3,\n                    Prerequisites = { VanillaItems.Antidote },\n                });\n            */\n        }\n\n        public override void SetupDetails()\n        {\n            Item.itemType = ItemTypes.Combine;\n            Item.itemValue = 8;\n            Item.initCount = 10;\n            Item.stackable = true;\n            Item.hasCharges = true;\n        }\n\n        private static readonly Dictionary<string, string> invertDictionary = new Dictionary<string, string>\n        {\n            [VanillaEffects.Poisoned] = VanillaEffects.RegenerateHealth,\n            [VanillaEffects.Slow] = VanillaEffects.Fast,\n            [VanillaEffects.Weak] = VanillaEffects.Strength,\n            [VanillaEffects.Acid] = VanillaEffects.Invincible,\n            [VanillaEffects.Confused] = VanillaEffects.Invisible,\n        };\n        static Centrifuge()\n        {\n            foreach (KeyValuePair<string, string> pair in invertDictionary.ToArray())\n                invertDictionary.Add(pair.Value, pair.Key);\n        }\n\n        public bool CombineFilter(InvItem other) => other.invItemName == VanillaItems.Syringe\n            && other.contents.Count > 0 && invertDictionary.ContainsKey(other.contents[0]);\n        public bool CombineItems(InvItem other)\n        {\n            if (!CombineFilter(other)) return false;\n\n            other.contents[0] = invertDictionary[other.contents[0]];\n\n            Count--;\n            gc.audioHandler.Play(Owner, VanillaAudio.CombineItem);\n            return true;\n        }\n        public CustomTooltip CombineCursorText(InvItem other) => default;\n        public CustomTooltip CombineTooltip(InvItem other) => default;\n    }\n}\n';var d=t(5306);const p='using UnityEngine;\n\nnamespace RogueLibsCore.Test\n{\n    [ItemCategories(RogueCategories.Technology, RogueCategories.GunAccessory, RogueCategories.Guns)]\n    public class AmmoBox : CustomItem, IItemCombinable\n    {\n        [RLSetup]\n        public static void Setup()\n        {\n            RogueLibs.CreateCustomItem<AmmoBox>()\n                .WithName(new CustomNameInfo("Ammo Box"))\n                .WithDescription(new CustomNameInfo("Combine with any refillable weapon to refill it. Limited ammo."))\n                .WithSprite(Properties.Resources.AmmoBox)\n                .WithUnlock(new ItemUnlock\n                {\n                    UnlockCost = 10,\n                    LoadoutCost = 5,\n                    CharacterCreationCost = 3,\n                    Prerequisites = { VanillaItems.KillAmmunizer },\n                });\n        }\n\n        public override void SetupDetails()\n        {\n            Item.itemType = ItemTypes.Combine;\n            Item.itemValue = 4;\n            Item.initCount = 100;\n            Item.rewardCount = 200;\n            Item.hasCharges = true;\n            Item.stackable = true;\n        }\n        public bool CombineFilter(InvItem other) => other.itemType == ItemTypes.WeaponProjectile && !other.noRefills;\n        public bool CombineItems(InvItem other)\n        {\n            if (!CombineFilter(other))\n            {\n                gc.audioHandler.Play(Owner, VanillaAudio.CantDo);\n                return false;\n            }\n            if (other.invItemCount >= other.maxAmmo)\n            {\n                Owner!.SayDialogue("AmmoDispenserFull");\n                gc.audioHandler.Play(Owner, VanillaAudio.CantDo);\n                return false;\n            }\n\n            int amountToRefill = other.maxAmmo - other.invItemCount;\n            float singleCost = (float)other.itemValue / other.maxAmmo;\n            if (Owner!.oma.superSpecialAbility && Owner.agentName is VanillaAgents.Soldier or VanillaAgents.Doctor)\n                singleCost = 0f;\n\n            int affordableAmount = (int)Mathf.Ceil(Count / singleCost);\n            int willBeBought = Mathf.Min(affordableAmount, amountToRefill);\n            int willBeReduced = (int)Mathf.Min(Count, willBeBought * singleCost);\n\n            Count -= willBeReduced;\n            other.invItemCount += willBeBought;\n            Owner.SayDialogue("AmmoDispenserFilled");\n            gc.audioHandler.Play(Owner, VanillaAudio.BuyItem);\n            return true;\n        }\n\n        public CustomTooltip CombineTooltip(InvItem other)\n        {\n            if (!CombineFilter(other)) return default;\n\n            int amountToRefill = other.maxAmmo - other.invItemCount;\n            if (amountToRefill == 0) return default;\n\n            float singleCost = (float)other.itemValue / other.maxAmmo;\n            if (Owner!.oma.superSpecialAbility && Owner.agentName is VanillaAgents.Soldier or VanillaAgents.Doctor)\n                singleCost = 0f;\n            int cost = (int)Mathf.Floor(amountToRefill * singleCost);\n            int canAfford = (int)Mathf.Ceil(Count / singleCost);\n\n            return "+" + Mathf.Min(amountToRefill, canAfford) + " (" + Mathf.Min(cost, Count) + ")";\n        }\n\n        public CustomTooltip CombineCursorText(InvItem other) => gc.nameDB.GetName("RefillGun", NameTypes.Interface);\n        // it\'s one of the vanilla dialogues, so there\'s no need to define it in the mod\n    }\n}\n',b={},f="Combinable Items",C={id:"dev/items/combinable-items",title:"Combinable Items",description:"Custom items can be made combinable with other items by implementing the IItemCombinable interface. You can define what kind of items your item is combinable with, what happens when you combine these items, and what tooltips to display in the combinable item's cell, and when hovering over it.",source:"@site/docs/dev/items/combinable-items.mdx",sourceDirName:"dev/items",slug:"/dev/items/combinable-items",permalink:"/RogueLibs/docs/dev/items/combinable-items",draft:!1,unlisted:!1,editUrl:"https://github.com/Chasmical/RogueLibs/edit/main/website/docs/dev/items/combinable-items.mdx",tags:[],version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"Usable Items",permalink:"/RogueLibs/docs/dev/items/usable-items"},next:{title:"Targetable Items",permalink:"/RogueLibs/docs/dev/items/targetable-items"}},g={};function v({props:e}){const n={div:"div",input:"input",...(0,o.a)()},[t,a]=(0,c.useState)((0,r.Z)("/img/TestItem.png")),[l,s]=(0,c.useState)("#FFED00"),[m,h]=(0,c.useState)("$123");return(0,i.jsxs)(n.div,{style:{padding:"10px",border:"5px dashed var(--ifm-menu-color-background-hover)",width:"max-content"},children:[(0,i.jsx)(n.input,{type:"file",accept:"image/*",onChange:e=>{if(e.target.files[0]){const n=new FileReader;n.addEventListener("load",(()=>a(n.result))),n.readAsDataURL(e.target.files[0])}},style:{margin:"5px"}}),(0,i.jsx)(n.div,{style:{margin:"5px"},children:(0,i.jsx)(u.Z,{sprite:t,tooltip:m,tooltipColor:l})}),(0,i.jsx)(n.input,{type:"text",placeholder:"$123",onChange:e=>h(e.target.value),style:{fontSize:"22px",margin:"5px"}}),(0,i.jsx)(n.input,{type:"color",value:l,onChange:e=>s(e.target.value)})]})}const I=[{value:"Making items combinable",id:"making-combinable",level:2},{value:"Inventory Slot Preview",id:"slot-preview",level:3},{value:"Examples",id:"examples",level:2}];function x(e){const n={a:"a",code:"code",h1:"h1",h2:"h2",h3:"h3",p:"p",pre:"pre",...(0,o.a)(),...e.components};return(0,i.jsxs)(i.Fragment,{children:[(0,i.jsx)(n.h1,{id:"combinable-items",children:"Combinable Items"}),"\n",(0,i.jsxs)(n.p,{children:["Custom items can be made combinable with other items by implementing the ",(0,i.jsx)(n.code,{children:"IItemCombinable"})," interface. You can define what kind of items your item is combinable with, what happens when you combine these items, and what tooltips to display in the combinable item's cell, and when hovering over it."]}),"\n","\n",(0,i.jsx)(n.h2,{id:"making-combinable",children:"Making items combinable"}),"\n",(0,i.jsxs)(n.p,{children:["Just implement the ",(0,i.jsx)(n.code,{children:"IItemCombinable"})," interface in your item's class:"]}),"\n",(0,i.jsx)(n.pre,{children:(0,i.jsx)(n.code,{className:"language-csharp",metastring:'title="MyCombinableItem.cs"',children:"// highlight-next-line\npublic class MyCombinableItem : CustomItem, IItemCombinable\n{\n    // highlight-start\n    public bool CombineFilter(InvItem other) { /* ... */ }\n    public bool CombineItems(InvItem other) { /* ... */ }\n    public CustomTooltip CombineTooltip(InvItem other) { /* ... */ }\n    public CustomTooltip CombineCursorText(InvItem other) { /* ... */ }\n    // highlight-end\n}\n"})}),"\n",(0,i.jsxs)(n.p,{children:["Plus, your item's type must be ",(0,i.jsx)(n.code,{children:'"Combine"'}),":"]}),"\n",(0,i.jsx)(n.pre,{children:(0,i.jsx)(n.code,{className:"language-csharp",children:"    public override void SetupDetails()\n    {\n        // highlight-next-line\n        Item.itemType = ItemTypes.Combine;\n        /* ... */\n    }\n"})}),"\n",(0,i.jsxs)(n.p,{children:[(0,i.jsx)(n.code,{children:"CombineFilter"})," determines what items will be highlighted, when combining the current item."]}),"\n",(0,i.jsxs)(n.p,{children:[(0,i.jsx)(n.code,{children:"CombineItems"})," combines the current item with the other one. The return value indicates whether it was a success or not. Usually you'd just play a ",(0,i.jsx)(n.code,{children:'"CantDo"'})," sound, if the items cannot be combined. Returning ",(0,i.jsx)(n.code,{children:"true"})," will also play an animation."]}),"\n",(0,i.jsxs)(n.p,{children:[(0,i.jsx)(n.code,{children:"CombineTooltip"})," determines the tooltip in the upper-left corner of the inventory slot. ",(0,i.jsx)(n.code,{children:"Text"})," set to ",(0,i.jsx)(n.code,{children:"null"})," will default to an empty string, and ",(0,i.jsx)(n.code,{children:"Color"})," set to ",(0,i.jsx)(n.code,{children:"null"})," will default to ",(0,i.jsx)(s.Z,{color:"#FFED00"}),". ",(0,i.jsx)(n.a,{href:"#slot-preview",children:"See the tool below"}),"."]}),"\n",(0,i.jsxs)(n.p,{children:[(0,i.jsx)(n.code,{children:"CombineCursorText"})," determines the cursor text when hovering over the item. ",(0,i.jsx)(n.code,{children:"Text"})," set to ",(0,i.jsx)(n.code,{children:"null"}),' will default to "Combine", and ',(0,i.jsx)(n.code,{children:"Color"})," set to ",(0,i.jsx)(n.code,{children:"null"})," will default to ",(0,i.jsx)(s.Z,{color:"#FFFFFF"}),"."]}),"\n",(0,i.jsx)(n.h3,{id:"slot-preview",children:"Inventory Slot Preview"}),"\n",(0,i.jsxs)(n.p,{children:["Wanna see how your ",(0,i.jsx)(n.code,{children:"CombineTooltip"})," will look in the game? Check out this small tool:"]}),"\n","\n","\n",(0,i.jsx)(v,{}),"\n",(0,i.jsx)(n.h2,{id:"examples",children:"Examples"}),"\n","\n","\n","\n",(0,i.jsxs)(a.Z,{defaultValue:"ammobox",values:[{label:"Centrifuge",value:"centrifuge"},{label:"Spice Rack",value:"spicerack"},{label:"Ammo Box",value:"ammobox"}],children:[(0,i.jsxs)(l.Z,{value:"centrifuge",children:[(0,i.jsx)(n.p,{children:"A simple example that inverts the Syringes' effects."}),(0,i.jsx)(m.Z,{children:h})]}),(0,i.jsxs)(l.Z,{value:"spicerack",children:[(0,i.jsx)(n.p,{children:"A simple example, with custom hooks to keep track of seasoned items."}),(0,i.jsxs)(n.p,{children:["See more about custom hooks ",(0,i.jsx)(n.a,{href:"/RogueLibs/docs/dev/hooks/",children:"here"}),"."]}),(0,i.jsx)(m.Z,{children:d.Z})]}),(0,i.jsxs)(l.Z,{value:"ammobox",children:[(0,i.jsx)(n.p,{children:"A pretty complicated example with a lot of math."}),(0,i.jsx)(m.Z,{children:p})]})]})]})}function y(e={}){const{wrapper:n}={...(0,o.a)(),...e.components};return n?(0,i.jsx)(n,{...e,children:(0,i.jsx)(x,{...e})}):x(e)}},4214:(e,n,t)=>{t.d(n,{Z:()=>a});t(7294);var i=t(9286),o=t(5893);function a(e){let{children:n,language:t}=e;return(0,o.jsx)(i.Z,{className:"language-"+(t||"csharp"),children:n.replace(/\t/g,"    ")})}},2725:(e,n,t)=>{t.d(n,{Z:()=>o});t(7294);var i=t(5893);function o(e){let{color:n,size:t}=e,o=(t||14)+"px";return(0,i.jsxs)("div",{style:{display:"inline"},children:[(0,i.jsx)("div",{style:{display:"inline-block",width:o,height:o,background:n,marginRight:"2px"}}),(0,i.jsx)("div",{style:{display:"inline"},children:n})]})}},5880:(e,n,t)=>{t.d(n,{Z:()=>l});t(7294);var i=t(512);const o={container:"container_ek75",cursorLocked:"cursorLocked_H61i",normal:"normal_n5ah",hoverable:"hoverable_F5EM",selected:"selected_mneN",locked:"locked_H8Qp",sprite:"sprite_ZRUo",tooltip:"tooltip_QxcU",count:"count_Z8Fk"};var a=t(5893);function l(e){let{sprite:n,tooltip:t,tooltipColor:l,count:r,countColor:s,hoverable:u,cantClick:c,type:m="normal",onClick:h}=e;return(0,a.jsxs)("div",{onClick:h,className:(0,i.Z)(o.container,c&&o.cursorLocked,m&&o[m],u&&o.hoverable),children:[n&&(0,a.jsx)("img",{className:o.sprite,src:n},"sprite"),t&&(0,a.jsx)("span",{className:o.tooltip,style:{color:l||"#FFED00"},children:t},"tooltip"),r&&(0,a.jsx)("span",{className:o.count,style:{color:s||"#FFFFFF"},children:r},"count")]})}},1016:(e,n,t)=>{t.d(n,{Z:()=>o});t(7294);var i=t(5893);function o(e){let{children:n,...t}=e;return(0,i.jsx)("div",{role:"tabpanel",...t,children:n})}},5878:(e,n,t)=>{t.d(n,{Z:()=>g});var i=t(7294),o=t(6550),a=t(469),l=t(1980),r=t(7392),s=t(12);function u(e){return function(e){return i.Children.toArray(e).filter((e=>"\n"!==e)).map((e=>{if(!e||(0,i.isValidElement)(e)&&function(e){const{props:n}=e;return!!n&&"object"==typeof n&&"value"in n}(e))return e;throw new Error(`Docusaurus error: Bad <Tabs> child <${"string"==typeof e.type?e.type:e.type.name}>: all children of the <Tabs> component should be <TabItem>, and every <TabItem> should have a unique "value" prop.`)}))?.filter(Boolean)??[]}(e).map((e=>{let{props:{value:n,label:t,attributes:i,default:o}}=e;return{value:n,label:t,attributes:i,default:o}}))}function c(e){const{values:n,children:t}=e;return(0,i.useMemo)((()=>{const e=n??u(t);return function(e){const n=(0,r.l)(e,((e,n)=>e.value===n.value));if(n.length>0)throw new Error(`Docusaurus error: Duplicate values "${n.map((e=>e.value)).join(", ")}" found in <Tabs>. Every value needs to be unique.`)}(e),e}),[n,t])}function m(e){let{value:n,tabValues:t}=e;return t.some((e=>e.value===n))}function h(e){let{queryString:n=!1,groupId:t}=e;const a=(0,o.k6)(),r=function(e){let{queryString:n=!1,groupId:t}=e;if("string"==typeof n)return n;if(!1===n)return null;if(!0===n&&!t)throw new Error('Docusaurus error: The <Tabs> component groupId prop is required if queryString=true, because this value is used as the search param name. You can also provide an explicit value such as queryString="my-search-param".');return t??null}({queryString:n,groupId:t});return[(0,l._X)(r),(0,i.useCallback)((e=>{if(!r)return;const n=new URLSearchParams(a.location.search);n.set(r,e),a.replace({...a.location,search:n.toString()})}),[r,a])]}function d(e){const{defaultValue:n,queryString:t=!1,groupId:o}=e,l=c(e),[r,u]=(0,i.useState)((()=>function(e){let{defaultValue:n,tabValues:t}=e;if(0===t.length)throw new Error("Docusaurus error: the <Tabs> component requires at least one <TabItem> children component");if(n){if(!m({value:n,tabValues:t}))throw new Error(`Docusaurus error: The <Tabs> has a defaultValue "${n}" but none of its children has the corresponding value. Available values are: ${t.map((e=>e.value)).join(", ")}. If you intend to show no default tab, use defaultValue={null} instead.`);return n}const i=t.find((e=>e.default))??t[0];if(!i)throw new Error("Unexpected error: 0 tabValues");return i.value}({defaultValue:n,tabValues:l}))),[d,p]=h({queryString:t,groupId:o}),[b,f]=function(e){let{groupId:n}=e;const t=function(e){return e?`docusaurus.tab.${e}`:null}(n),[o,a]=(0,s.Nk)(t);return[o,(0,i.useCallback)((e=>{t&&a.set(e)}),[t,a])]}({groupId:o}),C=(()=>{const e=d??b;return m({value:e,tabValues:l})?e:null})();(0,a.Z)((()=>{C&&u(C)}),[C]);return{selectedValue:r,selectValue:(0,i.useCallback)((e=>{if(!m({value:e,tabValues:l}))throw new Error(`Can't select invalid tab value=${e}`);u(e),p(e),f(e)}),[p,f,l]),tabValues:l}}var p=t(512);const b={tabItem:"tabItem_V91s",tabItemActive:"tabItemActive_JsUu",blink:"blink_ZPVS",tab:"tab_ntnM"};var f=t(5893);const C={left:37,right:39};function g(e){const{lazy:n,defaultValue:t,values:o,groupId:a}=e,l=i.Children.toArray(e.children),{tabValues:r,selectedValue:s,selectValue:u}=d({children:l,defaultValue:t,values:o,groupId:a}),c=[],m=e=>{const n=e.currentTarget,t=o[c.indexOf(n)].value;u(t),null!=a&&setTimeout((()=>{(function(e){const{top:n,left:t,bottom:i,right:o}=e.getBoundingClientRect(),{innerHeight:a,innerWidth:l}=window;return n>=0&&o<=l&&i<=a&&t>=0})(n)||(n.scrollIntoView({block:"center",behavior:"smooth"}),n.classList.add(b.tabItemActive),setTimeout((()=>n.classList.remove(b.tabItemActive)),2e3))}),150)},h=e=>{let n;switch(e.keyCode){case C.right:{const t=c.indexOf(e.target)+1;n=c[t]||c[0];break}case C.left:{const t=c.indexOf(e.target)-1;n=c[t]||c[c.length-1];break}default:return}n.focus()},g=(e,n)=>n.value===e||n.values&&-1!=n.values.indexOf(e);return(0,f.jsxs)("div",{className:"tabs-container",children:[(0,f.jsx)("ul",{role:"tablist","aria-orientation":"horizontal",className:"tabs",children:o.map((e=>{let{value:n,label:t}=e;return(0,f.jsx)("li",{role:"tab",tabIndex:s===n?0:-1,"aria-selected":s===n,className:(0,p.Z)("tabs__item",b.tabItem,{"tabs__item--active":s===n}),ref:e=>e&&c.push(e),onKeyDown:h,onFocus:m,onClick:m,children:t},n)}))}),n?i.cloneElement(l.find((e=>g(s,e.props))),{className:b.tab}):(0,f.jsx)("div",{children:l.map(((e,n)=>i.cloneElement(e,{key:n,hidden:!g(s,e.props),className:b.tab})))}),(0,f.jsx)("br",{})]})}},5306:(e,n,t)=>{t.d(n,{Z:()=>i});const i='using UnityEngine;\n\nnamespace RogueLibsCore.Test\n{\n    [ItemCategories(RogueCategories.Food, RogueCategories.Health)]\n    public class SpiceRack : CustomItem, IItemCombinable\n    {\n        [RLSetup]\n        public static void Setup()\n        {\n            RogueLibs.CreateCustomItem<SpiceRack>()\n                .WithName(new CustomNameInfo("Spice Rack"))\n                .WithDescription(new CustomNameInfo("Combine with any food item to increase its healing properties."))\n                .WithSprite(Properties.Resources.SpiceRack)\n                .WithUnlock(new ItemUnlock\n                {\n                    UnlockCost = 10,\n                    LoadoutCost = 3,\n                    CharacterCreationCost = 2,\n                    Prerequisites = { VanillaItems.FoodProcessor },\n                });\n\n            SeasonCursorText = RogueLibs.CreateCustomName("SeasonItem", NameTypes.Interface, new CustomNameInfo("Season"));\n        }\n        private static CustomName SeasonCursorText = null!;\n\n        public override void SetupDetails()\n        {\n            Item.itemType = ItemTypes.Combine;\n            Item.itemValue = 4;\n            Item.initCount = 10;\n            Item.rewardCount = 15;\n            Item.stackable = true;\n            Item.hasCharges = true;\n        }\n        public bool CombineFilter(InvItem other)\n        {\n            if (other.itemType != ItemTypes.Food || other.healthChange is 0\n                || !other.Categories.Contains(RogueCategories.Food)) return false;\n\n            SpicedHook? hook = other.GetHook<SpicedHook>();\n            return hook is null || hook.Spiciness < 3;\n        }\n        public bool CombineItems(InvItem other)\n        {\n            if (!CombineFilter(other)) return false;\n\n            SpicedHook hook = other.GetHook<SpicedHook>() ?? other.AddHook<SpicedHook>();\n            hook.IncreaseSpiciness();\n\n            Count--;\n            gc.audioHandler.Play(Owner, VanillaAudio.CombineItem);\n            return true;\n        }\n        public CustomTooltip CombineCursorText(InvItem other) => SeasonCursorText;\n        public CustomTooltip CombineTooltip(InvItem other)\n        {\n            if (!CombineFilter(other)) return default;\n\n            SpicedHook? hook = other.GetHook<SpicedHook>();\n            int bonus = hook is null ? (int)Mathf.Ceil(other.healthChange / 4f) : hook.HealthBonus;\n            return new CustomTooltip($"+{bonus}", Color.green);\n        }\n\n        private class SpicedHook : HookBase<InvItem>\n        {\n            protected override void Initialize()\n                => HealthBonus = (int)Mathf.Ceil(Instance.healthChange / 4f);\n\n            public int HealthBonus { get; private set; }\n            public int Spiciness { get; private set; }\n\n            public void IncreaseSpiciness()\n            {\n                if (Spiciness is 3) return;\n\n                Spiciness++;\n                Instance.healthChange += HealthBonus;\n            }\n        }\n    }\n}\n'}}]);