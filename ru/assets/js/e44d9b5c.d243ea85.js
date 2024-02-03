"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[7959],{4188:(e,n,t)=>{t.r(n),t.d(n,{assets:()=>h,contentTitle:()=>c,default:()=>g,frontMatter:()=>u,metadata:()=>d,toc:()=>p});var a=t(5893),r=t(1151),l=t(5878),o=t(1016),i=(t(4996),t(4214));const s='using UnityEngine;\n\nnamespace RogueLibsCore.Test\n{\n    [ItemCategories(RogueCategories.Food, RogueCategories.Technology)]\n    public class QuantumFud : CustomItem, IItemUsable, IDoUpdate\n    {\n        [RLSetup]\n        public static void Setup()\n        {\n            RogueLibs.CreateCustomItem<QuantumFud>()\n                .WithName(new CustomNameInfo("Quantum Fud"))\n                .WithDescription(new CustomNameInfo("A very complicated piece of quantum technology. When you eat it, its quantum equivalent clone is consumed, while the original thing remains intact."))\n                .WithSprite(Properties.Resources.QuantumFud)\n                .WithUnlock(new ItemUnlock\n                {\n                    UnlockCost = 10,\n                    LoadoutCost = 15,\n                    CharacterCreationCost = 10,\n                   Prerequisites = { VanillaItems.FoodProcessor },\n                });\n        }\n\n        public override void SetupDetails()\n        {\n            Item.itemType = ItemTypes.Food;\n            Item.itemValue = 180;\n            Item.healthChange = 1;\n            Item.cantBeCloned = true;\n            Item.goesInToolbar = true;\n        }\n\n        public float Cooldown { get; set; }\n        public void Update() => Cooldown = Mathf.Max(Cooldown - Time.deltaTime, 0f);\n\n        public bool UseItem()\n        {\n            if (Cooldown != 0f) return false;\n\n            int heal = new ItemFunctions().DetermineHealthChange(Item, Owner);\n            Owner!.statusEffects.ChangeHealth(heal);\n\n            if (Owner.HasTrait(VanillaTraits.ShareTheHealth)\n                || Owner.HasTrait(VanillaTraits.ShareTheHealth2))\n                new ItemFunctions().GiveFollowersHealth(Owner, heal);\n\n            gc.audioHandler.Play(Owner, VanillaAudio.UseFood);\n            Cooldown = 0.5f;\n            return true;\n        }\n    }\n}\n',u={},c="\u041f\u0435\u0440\u0435\u0437\u0430\u0440\u044f\u0436\u0430\u0435\u043c\u044b\u0435 \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u044b",d={id:"dev/items/recharging-items",title:"\u041f\u0435\u0440\u0435\u0437\u0430\u0440\u044f\u0436\u0430\u0435\u043c\u044b\u0435 \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u044b",description:"\u0414\u0435\u043b\u0430\u0435\u043c \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u044b \u043f\u0435\u0440\u0435\u0437\u0430\u0440\u044f\u0436\u0430\u0435\u043c\u044b\u043c\u0438",source:"@site/i18n/ru/docusaurus-plugin-content-docs/current/dev/items/recharging-items.mdx",sourceDirName:"dev/items",slug:"/dev/items/recharging-items",permalink:"/RogueLibs/ru/docs/dev/items/recharging-items",draft:!1,unlisted:!1,editUrl:"https://github.com/Chasmical/RogueLibs/edit/main/website/docs/dev/items/recharging-items.mdx",tags:[],version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"\u041d\u0430\u043f\u0440\u0430\u0432\u043b\u044f\u0435\u043c\u044b\u0435 \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u044b +",permalink:"/RogueLibs/ru/docs/dev/items/targetable-items-plus"},next:{title:"\u041e\u0440\u0443\u0436\u0438\u0435 \u0431\u043b\u0438\u0436\u043d\u0435\u0433\u043e \u0431\u043e\u044f*",permalink:"/RogueLibs/ru/docs/dev/items/weapons/melee-weapons"}},h={},p=[{value:"\u0414\u0435\u043b\u0430\u0435\u043c \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u044b \u043f\u0435\u0440\u0435\u0437\u0430\u0440\u044f\u0436\u0430\u0435\u043c\u044b\u043c\u0438",id:"making-rechargeable",level:2},{value:"\u0428\u0430\u0431\u043b\u043e\u043d\u044b",id:"presets",level:2},{value:"\u041f\u0440\u0438\u043c\u0435\u0440\u044b",id:"examples",level:2}];function m(e){const n={a:"a",admonition:"admonition",code:"code",h1:"h1",h2:"h2",p:"p",pre:"pre",...(0,r.a)(),...e.components};return(0,a.jsxs)(a.Fragment,{children:[(0,a.jsx)(n.h1,{id:"\u043f\u0435\u0440\u0435\u0437\u0430\u0440\u044f\u0436\u0430\u0435\u043c\u044b\u0435-\u043f\u0440\u0435\u0434\u043c\u0435\u0442\u044b",children:"\u041f\u0435\u0440\u0435\u0437\u0430\u0440\u044f\u0436\u0430\u0435\u043c\u044b\u0435 \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u044b"}),"\n","\n",(0,a.jsx)(n.h2,{id:"making-rechargeable",children:"\u0414\u0435\u043b\u0430\u0435\u043c \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u044b \u043f\u0435\u0440\u0435\u0437\u0430\u0440\u044f\u0436\u0430\u0435\u043c\u044b\u043c\u0438"}),"\n",(0,a.jsxs)(n.p,{children:["\u0415\u0441\u043b\u0438 \u0445\u043e\u0442\u0438\u0442\u0435 \u0441\u0434\u0435\u043b\u0430\u0442\u044c \u043f\u0435\u0440\u0435\u0437\u0430\u0440\u044f\u0436\u0430\u0435\u043c\u044b\u0439 \u043f\u0440\u0435\u0434\u043c\u0435\u0442, \u0432\u043e\u0441\u043f\u043e\u043b\u044c\u0437\u0443\u0439\u0442\u0435\u0441\u044c ",(0,a.jsxs)(n.a,{href:"../extra#update-interfaces",children:["\u0438\u043d\u0442\u0435\u0440\u0444\u0435\u0439\u0441\u043e\u043c ",(0,a.jsx)(n.code,{children:"IDoUpdate"})]}),":"]}),"\n",(0,a.jsx)(n.pre,{children:(0,a.jsx)(n.code,{className:"language-csharp",metastring:'title="MyRechargeableItem.cs"',children:"// highlight-next-line\npublic class MyRechargeableItem : CustomItem, IDoUpdate\n{\n    /* ... */\n}\n"})}),"\n",(0,a.jsx)(n.h2,{id:"presets",children:"\u0428\u0430\u0431\u043b\u043e\u043d\u044b"}),"\n",(0,a.jsx)(n.p,{children:"\u0412\u043e\u0442 \u043f\u0430\u0440\u043e\u0447\u043a\u0430 \u043f\u043e\u043b\u0435\u0437\u043d\u044b\u0445 \u0448\u0430\u0431\u043b\u043e\u043d\u043e\u0432:"}),"\n",(0,a.jsxs)(l.Z,{defaultValue:"cooldown",values:[{label:"\u0412\u0440\u0435\u043c\u044f \u0432\u043e\u0441\u0441\u0442\u0430\u043d\u043e\u0432\u043b\u0435\u043d\u0438\u044f",value:"cooldown"},{label:"\u0417\u0430\u0440\u044f\u0434\u043a\u0430",value:"charge"}],children:[(0,a.jsxs)(o.Z,{value:"cooldown",children:[(0,a.jsxs)(n.p,{children:[(0,a.jsx)(n.code,{children:"Cooldown"})," \u043f\u0440\u0435\u0434\u0441\u0442\u0430\u0432\u043b\u044f\u0435\u0442 \u0438\u0437 \u0441\u0435\u0431\u044f \u043a\u043e\u043b\u0438\u0447\u0435\u0441\u0442\u0432\u043e \u0441\u0435\u043a\u0443\u043d\u0434 \u0434\u043e \u043f\u043e\u043b\u043d\u043e\u0439 \u043f\u0435\u0440\u0435\u0437\u0430\u0440\u044f\u0434\u043a\u0438."]}),(0,a.jsx)(n.pre,{children:(0,a.jsx)(n.code,{className:"language-csharp",children:"    public float Cooldown { get; private set; }\n    public void Update() => Cooldown = Mathf.Max(Cooldown - Time.deltaTime, 0f);\n"})}),(0,a.jsx)(n.p,{children:"\u0421 \u043d\u0430\u0441\u0442\u0440\u0430\u0438\u0432\u0430\u0435\u043c\u043e\u0439 \u0441\u043a\u043e\u0440\u043e\u0441\u0442\u044c\u044e \u043f\u0435\u0440\u0435\u0437\u0430\u0440\u044f\u0434\u043a\u0438:"}),(0,a.jsx)(n.pre,{children:(0,a.jsx)(n.code,{className:"language-csharp",children:"    public float RechargeSpeed = 1f;\n\n    public float Cooldown { get; private set; }\n    public void Update() => Cooldown = Mathf.Max(Cooldown - Time.deltaTime * RechargeSpeed, 0f);\n"})}),(0,a.jsx)(n.p,{children:"\u0418\u0441\u043f\u043e\u043b\u044c\u0437\u043e\u0432\u0430\u043d\u0438\u0435:"}),(0,a.jsx)(n.pre,{children:(0,a.jsx)(n.code,{className:"language-csharp",children:"    public bool UseItem()\n    {\n        if (Cooldown != 0f) return false;\n        /* ... */\n        Cooldown = 1.5f;\n        return true;\n    }\n"})}),(0,a.jsx)(n.admonition,{type:"info",children:(0,a.jsxs)(n.p,{children:["\u0412\u044b \u043c\u043e\u0436\u0435\u0442\u0435 \u0438\u0441\u043f\u043e\u043b\u044c\u0437\u043e\u0432\u0430\u0442\u044c \u0434\u0440\u0443\u0433\u0438\u0435 \u043c\u0435\u0442\u043e\u0434\u044b \u0430\u043a\u0442\u0438\u0432\u0430\u0446\u0438\u0438 \u0442\u043e\u0436\u0435, \u043d\u0430\u043f\u0440\u0438\u043c\u0435\u0440 ",(0,a.jsx)(n.code,{children:"CombineItems"}),", ",(0,a.jsx)(n.code,{children:"TargetObject"}),", ",(0,a.jsx)(n.code,{children:"TargetPosition"})," \u0438 \u0434\u0440."]})}),(0,a.jsxs)(n.p,{children:["\u0415\u0441\u043b\u0438 \u0445\u043e\u0442\u0438\u0442\u0435 \u043e\u0442\u043e\u0431\u0440\u0430\u0436\u0430\u0442\u044c ",(0,a.jsx)(n.code,{children:"Cooldown"})," \u0432\u043c\u0435\u0441\u0442\u043e \u043a\u043e\u043b\u0438\u0447\u0435\u0441\u0442\u0432\u0430 \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u0430, \u0442\u043e \u043f\u0435\u0440\u0435\u0433\u0440\u0443\u0437\u0438\u0442\u0435 \u043c\u0435\u0442\u043e\u0434 ",(0,a.jsx)(n.code,{children:"GetCountString"}),":"]}),(0,a.jsx)(n.pre,{children:(0,a.jsx)(n.code,{className:"language-csharp",children:"    public override CustomTooltip GetCountString()\n    {\n        if (Cooldown != 0f) return new CustomTooltip(Cooldown, Color.red);\n        return base.GetCountString(); // \u043e\u0442\u043e\u0431\u0440\u0430\u0437\u0438\u0442\u044c \u043a\u043e\u043b\u0438\u0447\u0435\u0441\u0442\u0432\u043e \u043f\u043e \u0443\u043c\u043e\u043b\u0447\u0430\u043d\u0438\u044e\n    }\n"})})]}),(0,a.jsxs)(o.Z,{value:"charge",children:[(0,a.jsxs)(n.p,{children:[(0,a.jsx)(n.code,{children:"Charge"}),' \u043f\u0440\u0435\u0434\u0441\u0442\u0430\u0432\u043b\u044f\u0435\u0442 \u0438\u0437 \u0441\u0435\u0431\u044f \u043a\u043e\u043b\u0438\u0447\u0435\u0441\u0442\u0432\u043e \u0441\u0435\u043a\u0443\u043d\u0434 "\u043d\u0430\u043a\u043e\u043f\u043b\u0435\u043d\u043d\u043e\u0439 \u044d\u043d\u0435\u0440\u0433\u0438\u0438".']}),(0,a.jsx)(n.pre,{children:(0,a.jsx)(n.code,{className:"language-csharp",children:"    public float Charge { get; private set; } = 5f;\n    public void Update() => Charge = Mathf.Min(Charge + Time.deltaTime, 5f);\n"})}),(0,a.jsx)(n.p,{children:"\u0421 \u043d\u0430\u0441\u0442\u0440\u0430\u0438\u0432\u0430\u0435\u043c\u043e\u0439 \u0441\u043a\u043e\u0440\u043e\u0441\u0442\u044c\u044e \u0437\u0430\u0440\u044f\u0434\u043a\u0438 \u0438 \u043c\u0430\u043a\u0441\u0438\u043c\u0430\u043b\u044c\u043d\u044b\u043c \u0437\u0430\u0440\u044f\u0434\u043e\u043c:"}),(0,a.jsx)(n.pre,{children:(0,a.jsx)(n.code,{className:"language-csharp",children:"    public float ChargeSpeed = 1f, MaxCharge = 5f;\n\n    public float Charge { get; private set; } = 5f;\n    public void Update() => Charge = Mathf.Min(Charge + Time.deltaTime * ChargeSpeed, MaxCharge);\n"})}),(0,a.jsx)(n.p,{children:"\u041f\u043b\u044e\u0441, \u0441 \u0437\u0430\u0434\u0435\u0440\u0436\u043a\u043e\u0439 \u0437\u0430\u0440\u044f\u0434\u043a\u0438:"}),(0,a.jsx)(n.pre,{children:(0,a.jsx)(n.code,{className:"language-csharp",children:"    public float DelayThreshold = 3f, ChargeSpeed = 1f, MaxCharge = 5f;\n\n    private float lastUsage;\n    public float Charge { get; private set; } = 5f;\n    public void Update()\n    {\n        if (lastUsage + DelayThreshold < Time.time)\n            Charge = Mathf.Min(Charge + Time.deltaTime * ChargeSpeed, MaxCharge);\n    }\n"})}),(0,a.jsx)(n.p,{children:"\u0418\u0441\u043f\u043e\u043b\u044c\u0437\u043e\u0432\u0430\u043d\u0438\u0435:"}),(0,a.jsx)(n.pre,{children:(0,a.jsx)(n.code,{className:"language-csharp",children:"    public bool UseItem()\n    {\n        if (Charge < 1.5f) return false;\n        /* ... */\n        Charge -= 1.5f;\n        lastUsage = Time.time;\n        return true;\n    }\n"})}),(0,a.jsx)(n.admonition,{type:"info",children:(0,a.jsxs)(n.p,{children:["\u0412\u044b \u043c\u043e\u0436\u0435\u0442\u0435 \u0438\u0441\u043f\u043e\u043b\u044c\u0437\u043e\u0432\u0430\u0442\u044c \u0434\u0440\u0443\u0433\u0438\u0435 \u043c\u0435\u0442\u043e\u0434\u044b \u0430\u043a\u0442\u0438\u0432\u0430\u0446\u0438\u0438 \u0442\u043e\u0436\u0435, \u043d\u0430\u043f\u0440\u0438\u043c\u0435\u0440 ",(0,a.jsx)(n.code,{children:"CombineItems"}),", ",(0,a.jsx)(n.code,{children:"TargetObject"}),", ",(0,a.jsx)(n.code,{children:"TargetPosition"})," \u0438 \u0434\u0440."]})}),(0,a.jsxs)(n.p,{children:["\u0415\u0441\u043b\u0438 \u0445\u043e\u0442\u0438\u0442\u0435 \u043e\u0442\u043e\u0431\u0440\u0430\u0436\u0430\u0442\u044c ",(0,a.jsx)(n.code,{children:"Charge"})," \u0432\u043c\u0435\u0441\u0442\u043e \u043a\u043e\u043b\u0438\u0447\u0435\u0441\u0442\u0432\u0430 \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u0430, \u0442\u043e \u043f\u0435\u0440\u0435\u0433\u0440\u0443\u0437\u0438\u0442\u0435 \u043c\u0435\u0442\u043e\u0434 ",(0,a.jsx)(n.code,{children:"GetCountString"}),":"]}),(0,a.jsx)(n.pre,{children:(0,a.jsx)(n.code,{className:"language-csharp",children:'    public override CustomTooltip GetCountString()\n    {\n        string text = $"{Charge} ({base.GetCountString()})"; // display both charge and count\n        Color color = Color.Lerp(Color.red, Color.white, Charge / MaxCharge);\n        // color between red and white: red - no charge, white - full charge\n        return new CustomTooltip(text, color);\n    }\n'})})]})]}),"\n",(0,a.jsx)(n.admonition,{type:"note",children:(0,a.jsx)(n.p,{children:"\u0422\u0430\u043a\u0436\u0435 \u0441\u0443\u0449\u0435\u0441\u0442\u0432\u0443\u0435\u0442 \u0432\u0430\u043d\u0438\u043b\u044c\u043d\u044b\u0439 \u0441\u043f\u043e\u0441\u043e\u0431 \u043f\u0435\u0440\u0435\u0437\u0430\u0440\u044f\u0434\u043a\u0438, \u043d\u043e \u043e\u043d \u043a\u0440\u0430\u0439\u043d\u0435 \u043d\u0435\u043b\u043e\u0433\u0438\u0447\u043d\u044b\u0439 \u0438 \u043d\u0435\u043d\u0430\u0434\u0451\u0436\u043d\u044b\u0439."})}),"\n",(0,a.jsx)(n.h2,{id:"examples",children:"\u041f\u0440\u0438\u043c\u0435\u0440\u044b"}),"\n","\n","\n","\n",(0,a.jsx)(l.Z,{defaultValue:"quantumfud",values:[{label:"Quantum Fud",value:"quantumfud"}],children:(0,a.jsx)(o.Z,{value:"quantumfud",children:(0,a.jsx)(i.Z,{children:s})})})]})}function g(e={}){const{wrapper:n}={...(0,r.a)(),...e.components};return n?(0,a.jsx)(n,{...e,children:(0,a.jsx)(m,{...e})}):m(e)}},4214:(e,n,t)=>{t.d(n,{Z:()=>l});t(7294);var a=t(9286),r=t(5893);function l(e){let{children:n,language:t}=e;return(0,r.jsx)(a.Z,{className:"language-"+(t||"csharp"),children:n.replace(/\t/g,"    ")})}},1016:(e,n,t)=>{t.d(n,{Z:()=>r});t(7294);var a=t(5893);function r(e){let{children:n,...t}=e;return(0,a.jsx)("div",{role:"tabpanel",...t,children:n})}},5878:(e,n,t)=>{t.d(n,{Z:()=>v});var a=t(7294),r=t(6550),l=t(469),o=t(1980),i=t(7392),s=t(12);function u(e){return function(e){return a.Children.toArray(e).filter((e=>"\n"!==e)).map((e=>{if(!e||(0,a.isValidElement)(e)&&function(e){const{props:n}=e;return!!n&&"object"==typeof n&&"value"in n}(e))return e;throw new Error(`Docusaurus error: Bad <Tabs> child <${"string"==typeof e.type?e.type:e.type.name}>: all children of the <Tabs> component should be <TabItem>, and every <TabItem> should have a unique "value" prop.`)}))?.filter(Boolean)??[]}(e).map((e=>{let{props:{value:n,label:t,attributes:a,default:r}}=e;return{value:n,label:t,attributes:a,default:r}}))}function c(e){const{values:n,children:t}=e;return(0,a.useMemo)((()=>{const e=n??u(t);return function(e){const n=(0,i.l)(e,((e,n)=>e.value===n.value));if(n.length>0)throw new Error(`Docusaurus error: Duplicate values "${n.map((e=>e.value)).join(", ")}" found in <Tabs>. Every value needs to be unique.`)}(e),e}),[n,t])}function d(e){let{value:n,tabValues:t}=e;return t.some((e=>e.value===n))}function h(e){let{queryString:n=!1,groupId:t}=e;const l=(0,r.k6)(),i=function(e){let{queryString:n=!1,groupId:t}=e;if("string"==typeof n)return n;if(!1===n)return null;if(!0===n&&!t)throw new Error('Docusaurus error: The <Tabs> component groupId prop is required if queryString=true, because this value is used as the search param name. You can also provide an explicit value such as queryString="my-search-param".');return t??null}({queryString:n,groupId:t});return[(0,o._X)(i),(0,a.useCallback)((e=>{if(!i)return;const n=new URLSearchParams(l.location.search);n.set(i,e),l.replace({...l.location,search:n.toString()})}),[i,l])]}function p(e){const{defaultValue:n,queryString:t=!1,groupId:r}=e,o=c(e),[i,u]=(0,a.useState)((()=>function(e){let{defaultValue:n,tabValues:t}=e;if(0===t.length)throw new Error("Docusaurus error: the <Tabs> component requires at least one <TabItem> children component");if(n){if(!d({value:n,tabValues:t}))throw new Error(`Docusaurus error: The <Tabs> has a defaultValue "${n}" but none of its children has the corresponding value. Available values are: ${t.map((e=>e.value)).join(", ")}. If you intend to show no default tab, use defaultValue={null} instead.`);return n}const a=t.find((e=>e.default))??t[0];if(!a)throw new Error("Unexpected error: 0 tabValues");return a.value}({defaultValue:n,tabValues:o}))),[p,m]=h({queryString:t,groupId:r}),[g,f]=function(e){let{groupId:n}=e;const t=function(e){return e?`docusaurus.tab.${e}`:null}(n),[r,l]=(0,s.Nk)(t);return[r,(0,a.useCallback)((e=>{t&&l.set(e)}),[t,l])]}({groupId:r}),b=(()=>{const e=p??g;return d({value:e,tabValues:o})?e:null})();(0,l.Z)((()=>{b&&u(b)}),[b]);return{selectedValue:i,selectValue:(0,a.useCallback)((e=>{if(!d({value:e,tabValues:o}))throw new Error(`Can't select invalid tab value=${e}`);u(e),m(e),f(e)}),[m,f,o]),tabValues:o}}var m=t(512);const g={tabItem:"tabItem_V91s",tabItemActive:"tabItemActive_JsUu",blink:"blink_ZPVS",tab:"tab_ntnM"};var f=t(5893);const b={left:37,right:39};function v(e){const{lazy:n,defaultValue:t,values:r,groupId:l}=e,o=a.Children.toArray(e.children),{tabValues:i,selectedValue:s,selectValue:u}=p({children:o,defaultValue:t,values:r,groupId:l}),c=[],d=e=>{const n=e.currentTarget,t=r[c.indexOf(n)].value;u(t),null!=l&&setTimeout((()=>{(function(e){const{top:n,left:t,bottom:a,right:r}=e.getBoundingClientRect(),{innerHeight:l,innerWidth:o}=window;return n>=0&&r<=o&&a<=l&&t>=0})(n)||(n.scrollIntoView({block:"center",behavior:"smooth"}),n.classList.add(g.tabItemActive),setTimeout((()=>n.classList.remove(g.tabItemActive)),2e3))}),150)},h=e=>{let n;switch(e.keyCode){case b.right:{const t=c.indexOf(e.target)+1;n=c[t]||c[0];break}case b.left:{const t=c.indexOf(e.target)-1;n=c[t]||c[c.length-1];break}default:return}n.focus()},v=(e,n)=>n.value===e||n.values&&-1!=n.values.indexOf(e);return(0,f.jsxs)("div",{className:"tabs-container",children:[(0,f.jsx)("ul",{role:"tablist","aria-orientation":"horizontal",className:"tabs",children:r.map((e=>{let{value:n,label:t}=e;return(0,f.jsx)("li",{role:"tab",tabIndex:s===n?0:-1,"aria-selected":s===n,className:(0,m.Z)("tabs__item",g.tabItem,{"tabs__item--active":s===n}),ref:e=>e&&c.push(e),onKeyDown:h,onFocus:d,onClick:d,children:t},n)}))}),n?a.cloneElement(o.find((e=>v(s,e.props))),{className:g.tab}):(0,f.jsx)("div",{children:o.map(((e,n)=>a.cloneElement(e,{key:n,hidden:!v(s,e.props),className:g.tab})))}),(0,f.jsx)("br",{})]})}}}]);