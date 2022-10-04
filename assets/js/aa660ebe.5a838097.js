"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[8227],{4214:(e,t,a)=>{a.d(t,{Z:()=>l});var n=a(7294),o=a(814);function l(e){let{children:t,language:a}=e;return n.createElement(o.Z,{className:"language-"+(a||"csharp")},t.replace(/\t/g,"    "))}},1016:(e,t,a)=>{a.d(t,{Z:()=>l});var n=a(7462),o=a(7294);function l(e){let{children:t,...a}=e;return o.createElement("div",(0,n.Z)({role:"tabpanel"},a),t)}},250:(e,t,a)=>{a.d(t,{Z:()=>c});var n=a(7294),o=a(7094),l=a(6010);const r="tabItem_V91s",i="tabItemActive_JsUu",s="tab_ntnM";const u=37,m=39;function c(e){const{lazy:t,defaultValue:a,values:c,groupId:d}=e,{tabGroupChoices:p,setTabGroupChoices:g}=(0,o.U)(),[h,C]=(0,n.useState)(a),f=n.Children.toArray(e.children),b=[];if(null!=d){const e=p[d];null!=e&&e!==h&&c.some((t=>t.value===e))&&C(e)}const k=e=>{const t=e.currentTarget,a=b.indexOf(t),n=c[a].value;C(n),null!=d&&(g(d,n),setTimeout((()=>{(function(e){const{top:t,left:a,bottom:n,right:o}=e.getBoundingClientRect(),{innerHeight:l,innerWidth:r}=window;return t>=0&&o<=r&&n<=l&&a>=0})(t)||(t.scrollIntoView({block:"center",behavior:"smooth"}),t.classList.add(i),setTimeout((()=>t.classList.remove(i)),2e3))}),150))},v=e=>{let t;switch(e.keyCode){case m:{const a=b.indexOf(e.target)+1;t=b[a]||b[0];break}case u:{const a=b.indexOf(e.target)-1;t=b[a]||b[b.length-1];break}default:return}t.focus()},w=(e,t)=>t.value===e||t.values&&-1!=t.values.indexOf(e);return n.createElement("div",{className:"tabs-container"},n.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:"tabs"},c.map((e=>{let{value:t,label:a}=e;return n.createElement("li",{role:"tab",tabIndex:h===t?0:-1,"aria-selected":h===t,className:(0,l.Z)("tabs__item",r,{"tabs__item--active":h===t}),key:t,ref:e=>e&&b.push(e),onKeyDown:v,onFocus:k,onClick:k},a)}))),t?n.cloneElement(f.find((e=>w(h,e.props))),{className:s}):n.createElement("div",null,f.map(((e,t)=>n.cloneElement(e,{key:t,hidden:!w(h,e.props),className:s})))),n.createElement("br",null))}},159:(e,t,a)=>{a.r(t),a.d(t,{assets:()=>c,contentTitle:()=>u,default:()=>g,frontMatter:()=>s,metadata:()=>m,toc:()=>d});var n=a(7462),o=(a(7294),a(3905)),l=a(250),r=a(1016),i=(a(4996),a(4214));const s={},u="Recharging Items",m={unversionedId:"dev/items/recharging-items",id:"dev/items/recharging-items",title:"Recharging Items",description:"Making items rechargeable",source:"@site/docs/dev/items/recharging-items.mdx",sourceDirName:"dev/items",slug:"/dev/items/recharging-items",permalink:"/RogueLibs/docs/dev/items/recharging-items",draft:!1,editUrl:"https://github.com/SugarBarrel/RogueLibs/edit/main/website/docs/dev/items/recharging-items.mdx",tags:[],version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"Targetable Items +",permalink:"/RogueLibs/docs/dev/items/targetable-items-plus"},next:{title:"Melee Weapons*",permalink:"/RogueLibs/docs/dev/items/weapons/melee-weapons"}},c={},d=[{value:"Making items rechargeable",id:"making-rechargeable",level:2},{value:"Presets",id:"presets",level:2},{value:"Examples",id:"examples",level:2}],p={toc:d};function g(e){let{components:t,...a}=e;return(0,o.kt)("wrapper",(0,n.Z)({},p,a,{components:t,mdxType:"MDXLayout"}),(0,o.kt)("h1",{id:"recharging-items"},"Recharging Items"),(0,o.kt)("h2",{id:"making-rechargeable"},"Making items rechargeable"),(0,o.kt)("p",null,"If you want to make a rechargeable item, you'll have to make use of the ",(0,o.kt)("a",{parentName:"p",href:"../extra#update-interfaces"},(0,o.kt)("inlineCode",{parentName:"a"},"IDoUpdate")," interface"),":"),(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyRechargeableItem.cs"',title:'"MyRechargeableItem.cs"'},"// highlight-next-line\npublic class MyRechargeableItem : CustomItem, IDoUpdate\n{\n    /* ... */\n}\n")),(0,o.kt)("h2",{id:"presets"},"Presets"),(0,o.kt)("p",null,"Here's a couple of useful presets:"),(0,o.kt)(l.Z,{defaultValue:"cooldown",values:[{label:"Cooldown",value:"cooldown"},{label:"Charge",value:"charge"}],mdxType:"Tabs"},(0,o.kt)(r.Z,{value:"cooldown",mdxType:"TabItem"},(0,o.kt)("p",null,(0,o.kt)("inlineCode",{parentName:"p"},"Cooldown")," represents the amount of seconds to wait until full recharge."),(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-csharp"},"    public float Cooldown { get; private set; }\n    public void Update() => Cooldown = Mathf.Max(Cooldown - Time.deltaTime, 0f);\n")),(0,o.kt)("p",null,"With adjustable recharging speed:"),(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-csharp"},"    public float RechargeSpeed = 1f;\n\n    public float Cooldown { get; private set; }\n    public void Update() => Cooldown = Mathf.Max(Cooldown - Time.deltaTime * RechargeSpeed, 0f);\n")),(0,o.kt)("p",null,"Usage:"),(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-csharp"},"    public bool UseItem()\n    {\n        if (Cooldown != 0f) return false;\n        /* ... */\n        Cooldown = 1.5f;\n        return true;\n    }\n")),(0,o.kt)("admonition",{type:"info"},(0,o.kt)("p",{parentName:"admonition"},"You can use other activation methods too, like ",(0,o.kt)("inlineCode",{parentName:"p"},"CombineItems"),", ",(0,o.kt)("inlineCode",{parentName:"p"},"TargetObject"),", ",(0,o.kt)("inlineCode",{parentName:"p"},"TargetPosition")," and etc.")),(0,o.kt)("p",null,"If you want to display ",(0,o.kt)("inlineCode",{parentName:"p"},"Cooldown")," as the item's count, then override the ",(0,o.kt)("inlineCode",{parentName:"p"},"GetCountString")," method:"),(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-csharp"},"    public override CustomTooltip GetCountString()\n    {\n        if (Cooldown != 0f) return new CustomTooltip(Cooldown, Color.red);\n        return base.GetCountString(); // display default count\n    }\n"))),(0,o.kt)(r.Z,{value:"charge",mdxType:"TabItem"},(0,o.kt)("p",null,(0,o.kt)("inlineCode",{parentName:"p"},"Charge"),' represents the amount of seconds of "stored up energy".'),(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-csharp"},"    public float Charge { get; private set; } = 5f;\n    public void Update() => Charge = Mathf.Min(Charge + Time.deltaTime, 5f);\n")),(0,o.kt)("p",null,"With adjustable charging speed and maximum charge:"),(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-csharp"},"    public float ChargeSpeed = 1f, MaxCharge = 5f;\n\n    public float Charge { get; private set; } = 5f;\n    public void Update() => Charge = Mathf.Min(Charge + Time.deltaTime * ChargeSpeed, MaxCharge);\n")),(0,o.kt)("p",null,"Plus, with a charging delay:"),(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-csharp"},"    public float DelayThreshold = 3f, ChargeSpeed = 1f, MaxCharge = 5f;\n\n    private float lastUsage;\n    public float Charge { get; private set; } = 5f;\n    public void Update()\n    {\n        if (lastUsage + DelayThreshold < Time.time)\n            Charge = Mathf.Min(Charge + Time.deltaTime * ChargeSpeed, MaxCharge);\n    }\n")),(0,o.kt)("p",null,"Usage:"),(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-csharp"},"    public bool UseItem()\n    {\n        if (Charge < 1.5f) return false;\n        /* ... */\n        Charge -= 1.5f;\n        lastUsage = Time.time;\n        return true;\n    }\n")),(0,o.kt)("admonition",{type:"info"},(0,o.kt)("p",{parentName:"admonition"},"You can use other activation methods too, like ",(0,o.kt)("inlineCode",{parentName:"p"},"CombineItems"),", ",(0,o.kt)("inlineCode",{parentName:"p"},"TargetObject"),", ",(0,o.kt)("inlineCode",{parentName:"p"},"TargetPosition")," and etc.")),(0,o.kt)("p",null,"If you want to display ",(0,o.kt)("inlineCode",{parentName:"p"},"Charge")," as the item's count, then override the ",(0,o.kt)("inlineCode",{parentName:"p"},"GetCountString")," method:"),(0,o.kt)("pre",null,(0,o.kt)("code",{parentName:"pre",className:"language-csharp"},'    public override CustomTooltip GetCountString()\n    {\n        string text = $"{Charge} ({base.GetCountString()})"; // display both charge and count\n        Color color = Color.Lerp(Color.red, Color.white, Charge / MaxCharge);\n        // color between red and white: red - no charge, white - full charge\n        return new CustomTooltip(text, color);\n    }\n')))),(0,o.kt)("admonition",{type:"note"},(0,o.kt)("p",{parentName:"admonition"},"There's also a vanilla way of recharging items, but it's really messy and unreliable.")),(0,o.kt)("h2",{id:"examples"},"Examples"),(0,o.kt)(l.Z,{defaultValue:"quantumfud",values:[{label:"Quantum Fud",value:"quantumfud"}],mdxType:"Tabs"},(0,o.kt)(r.Z,{value:"quantumfud",mdxType:"TabItem"},(0,o.kt)(i.Z,{mdxType:"CodeSnippet"},'using UnityEngine;\n\nnamespace RogueLibsCore.Test\n{\n    [ItemCategories(RogueCategories.Food, RogueCategories.Technology)]\n    public class QuantumFud : CustomItem, IItemUsable, IDoUpdate\n    {\n        [RLSetup]\n        public static void Setup()\n        {\n            RogueLibs.CreateCustomItem<QuantumFud>()\n                .WithName(new CustomNameInfo("Quantum Fud"))\n                .WithDescription(new CustomNameInfo("A very complicated piece of quantum technology. When you eat it, its quantum equivalent clone is consumed, while the original thing remains intact."))\n                .WithSprite(Properties.Resources.QuantumFud)\n                .WithUnlock(new ItemUnlock\n                {\n                    UnlockCost = 10,\n                    LoadoutCost = 15,\n                    CharacterCreationCost = 10,\n                   Prerequisites = { VanillaItems.FoodProcessor },\n                });\n        }\n\n        public override void SetupDetails()\n        {\n            Item.itemType = ItemTypes.Food;\n            Item.itemValue = 180;\n            Item.healthChange = 1;\n            Item.cantBeCloned = true;\n            Item.goesInToolbar = true;\n        }\n\n        public float Cooldown { get; set; }\n        public void Update() => Cooldown = Mathf.Max(Cooldown - Time.deltaTime, 0f);\n\n        public bool UseItem()\n        {\n            if (Cooldown != 0f) return false;\n\n            int heal = new ItemFunctions().DetermineHealthChange(Item, Owner);\n            Owner!.statusEffects.ChangeHealth(heal);\n\n            if (Owner.HasTrait(VanillaTraits.ShareTheHealth)\n                || Owner.HasTrait(VanillaTraits.ShareTheHealth2))\n                new ItemFunctions().GiveFollowersHealth(Owner, heal);\n\n            gc.audioHandler.Play(Owner, VanillaAudio.UseFood);\n            Cooldown = 0.5f;\n            return true;\n        }\n    }\n}\n'))))}g.isMDXComponent=!0}}]);