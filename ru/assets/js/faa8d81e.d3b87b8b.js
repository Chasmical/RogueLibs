(self.webpackChunkdocs=self.webpackChunkdocs||[]).push([[677],{3905:function(e,t,n){"use strict";n.d(t,{Zo:function(){return m},kt:function(){return f}});var o=n(7294);function r(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function i(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var o=Object.getOwnPropertySymbols(e);t&&(o=o.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,o)}return n}function a(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?i(Object(n),!0).forEach((function(t){r(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):i(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function l(e,t){if(null==e)return{};var n,o,r=function(e,t){if(null==e)return{};var n,o,r={},i=Object.keys(e);for(o=0;o<i.length;o++)n=i[o],t.indexOf(n)>=0||(r[n]=e[n]);return r}(e,t);if(Object.getOwnPropertySymbols){var i=Object.getOwnPropertySymbols(e);for(o=0;o<i.length;o++)n=i[o],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(r[n]=e[n])}return r}var s=o.createContext({}),u=function(e){var t=o.useContext(s),n=t;return e&&(n="function"==typeof e?e(t):a(a({},t),e)),n},m=function(e){var t=u(e.components);return o.createElement(s.Provider,{value:t},e.children)},c={inlineCode:"code",wrapper:function(e){var t=e.children;return o.createElement(o.Fragment,{},t)}},p=o.forwardRef((function(e,t){var n=e.components,r=e.mdxType,i=e.originalType,s=e.parentName,m=l(e,["components","mdxType","originalType","parentName"]),p=u(n),f=r,d=p["".concat(s,".").concat(f)]||p[f]||c[f]||i;return n?o.createElement(d,a(a({ref:t},m),{},{components:n})):o.createElement(d,a({ref:t},m))}));function f(e,t){var n=arguments,r=t&&t.mdxType;if("string"==typeof e||r){var i=n.length,a=new Array(i);a[0]=p;var l={};for(var s in t)hasOwnProperty.call(t,s)&&(l[s]=t[s]);l.originalType=e,l.mdxType="string"==typeof e?e:r,a[1]=l;for(var u=2;u<i;u++)a[u]=n[u];return o.createElement.apply(null,a)}return o.createElement.apply(null,n)}p.displayName="MDXCreateElement"},3919:function(e,t,n){"use strict";function o(e){return!0===/^(\w*:|\/\/)/.test(e)}function r(e){return void 0!==e&&!o(e)}n.d(t,{b:function(){return o},Z:function(){return r}})},4996:function(e,t,n){"use strict";n.d(t,{C:function(){return i},Z:function(){return a}});var o=n(2263),r=n(3919);function i(){var e=(0,o.Z)().siteConfig,t=(e=void 0===e?{}:e).baseUrl,n=void 0===t?"/":t,i=e.url;return{withBaseUrl:function(e,t){return function(e,t,n,o){var i=void 0===o?{}:o,a=i.forcePrependBaseUrl,l=void 0!==a&&a,s=i.absolute,u=void 0!==s&&s;if(!n)return n;if(n.startsWith("#"))return n;if((0,r.b)(n))return n;if(l)return t+n;var m=n.startsWith(t)?n:t+n.replace(/^\//,"");return u?e+m:m}(i,n,e,t)}}}function a(e,t){return void 0===t&&(t={}),(0,i().withBaseUrl)(e,t)}},9443:function(e,t,n){"use strict";var o=(0,n(7294).createContext)(void 0);t.Z=o},944:function(e,t,n){"use strict";var o=n(7294),r=n(9443);t.Z=function(){var e=(0,o.useContext)(r.Z);if(null==e)throw new Error('"useUserPreferencesContext" is used outside of "Layout" component.');return e}},9309:function(e,t,n){"use strict";n.d(t,{Z:function(){return l}});var o=n(2122),r=n(9756),i=n(7294),a=["children"];function l(e){var t=e.children,n=(0,r.Z)(e,a);return i.createElement("div",(0,o.Z)({role:"tabpanel"},n),t)}},9037:function(e,t,n){"use strict";n.d(t,{Z:function(){return c}});var o=n(7294),r=n(944),i=n(6010),a="tabItem_2O3c",l="tabItemActive_Fpbe",s="tab_1pgU";var u=37,m=39;var c=function(e){var t=e.lazy,n=e.block,c=e.defaultValue,p=e.values,f=e.groupId,d=e.className,b=(0,r.Z)(),h=b.tabGroupChoices,v=b.setTabGroupChoices,g=(0,o.useState)(c),C=g[0],y=g[1],I=o.Children.toArray(e.children),k=[];if(null!=f){var w=h[f];null!=w&&w!==C&&p.some((function(e){return e.value===w}))&&y(w)}var x=function(e){var t=e.currentTarget,n=k.indexOf(t),o=p[n].value;y(o),null!=f&&(v(f,o),setTimeout((function(){var e,n,o,r,i,a,s,u;(e=t.getBoundingClientRect(),n=e.top,o=e.left,r=e.bottom,i=e.right,a=window,s=a.innerHeight,u=a.innerWidth,n>=0&&i<=u&&r<=s&&o>=0)||(t.scrollIntoView({block:"center",behavior:"smooth"}),t.classList.add(l),setTimeout((function(){return t.classList.remove(l)}),2e3))}),150))},T=function(e){var t,n;switch(e.keyCode){case m:var o=k.indexOf(e.target)+1;n=k[o]||k[0];break;case u:var r=k.indexOf(e.target)-1;n=k[r]||k[k.length-1]}null==(t=n)||t.focus()},O=function(e,t){return t.value===e||t.values&&-1!=t.values.indexOf(e)};return o.createElement("div",{className:"tabs-container"},o.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:(0,i.Z)("tabs",{"tabs--block":n},d)},p.map((function(e){var t=e.value,n=e.label;return o.createElement("li",{role:"tab",tabIndex:C===t?0:-1,"aria-selected":C===t,className:(0,i.Z)("tabs__item",a,{"tabs__item--active":C===t}),key:t,ref:function(e){return k.push(e)},onKeyDown:T,onFocus:x,onClick:x},n)}))),t?(0,o.cloneElement)(I.filter((function(e){return O(C,e.props)}))[0],{curSelected:C,className:s}):o.createElement("div",null,I.map((function(e,t){return(0,o.cloneElement)(e,{key:t,hidden:!O(C,e.props),selectedValue:C,className:s})}))),o.createElement("br",null))}},7338:function(e,t,n){"use strict";n.r(t),n.d(t,{frontMatter:function(){return u},contentTitle:function(){return m},metadata:function(){return c},toc:function(){return p},default:function(){return d}});var o=n(2122),r=n(9756),i=(n(7294),n(3905)),a=n(9037),l=n(9309),s=(n(4996),["components"]),u={},m="Combinable Items",c={unversionedId:"dev-items/combinable-items",id:"dev-items/combinable-items",isDocsHomePage:!1,title:"Combinable Items",description:"Making items combinable",source:"@site/docs/dev-items/combinable-items.mdx",sourceDirName:"dev-items",slug:"/dev-items/combinable-items",permalink:"/RogueLibs/ru/docs/dev-items/combinable-items",editUrl:"https://github.com/Abbysssal/RogueLibs/edit/master/docs/docs/dev-items/combinable-items.mdx",version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"Usable Items",permalink:"/RogueLibs/ru/docs/dev-items/usable-items"},next:{title:"Inventory Events and Checks",permalink:"/RogueLibs/ru/docs/dev-items/inventory-events"}},p=[{value:"Making items combinable",id:"making-combinable",children:[]},{value:"Examples",id:"examples",children:[]}],f={toc:p};function d(e){var t=e.components,n=(0,r.Z)(e,s);return(0,i.kt)("wrapper",(0,o.Z)({},f,n,{components:t,mdxType:"MDXLayout"}),(0,i.kt)("h1",{id:"combinable-items"},"Combinable Items"),(0,i.kt)("h2",{id:"making-combinable"},"Making items combinable"),(0,i.kt)("p",null,"Just implement the ",(0,i.kt)("inlineCode",{parentName:"p"},"IItemCombinable")," interface in your item's class:"),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-csharp"},"// highlight-next-line\npublic class MyCustomItem : CustomItem, IItemCombinable\n{\n    // highlight-start\n    public void CombineItems(InvItem other)\n    {\n        ...\n    }\n    // highlight-end\n}\n")),(0,i.kt)("h2",{id:"examples"},"Examples"),(0,i.kt)(a.Z,{defaultValue:"grindstone",values:[{label:"Grindstone",value:"grindstone"},{label:"Ammo Box",value:"ammobox"}],mdxType:"Tabs"},(0,i.kt)(l.Z,{value:"grindstone",mdxType:"TabItem"},(0,i.kt)("p",null,"A simple example. Uses special item attributes (functionality is added in patches)."),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="Grindstone.cs"',title:'"Grindstone.cs"'},'[ItemCategories(RogueCategories.Technology, RogueCategories.MeleeAccessory, RogueCategories.Melee)]\npublic class Grindstone : CustomItem, IItemCombinable\n{\n    public override void SetupDetails()\n    {\n        Item.itemType = ItemTypes.Combine;\n        Item.itemValue = 40;\n        Item.initCount = 10;\n        Item.rewardCount = 10;\n        Item.hasCharges = true;\n        Item.stackable = true;\n    }\n    public bool CombineFilter(InvItem other)\n        => other.itemType == ItemTypes.WeaponMelee && !other.contents.Exists(c => c.StartsWith("Sharpened:"));\n    public bool CombineItems(InvItem other)\n    {\n        other.contents.Add("Sharpened:3");\n        Count--;\n        return true;\n    }\n    public CustomTooltip CombineTooltip(InvItem other) => null;\n    public CustomTooltip CombineCursorText(InvItem other) => null;\n}\n')),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-csharp"},'RogueLibs.CreateCustomItem<Grindstone>()\n    .WithName(new CustomNameInfo("Grindstone"))\n    .WithDescription(new CustomNameInfo("Use on melee weapons to sharpen them. Sharpened weapons will ignore all damage-reducing effects."))\n    .WithSprite(Properties.Resources.Grindstone)\n    .WithUnlock(new ItemUnlock\n    {\n        UnlockCost = 10,\n        CharacterCreationCost = 5,\n        LoadoutCost = 5,\n        // Melee Durability Spray must be unlocked in order to unlock Grindstone\n        Prerequisites = { "MeleeDurabilityDoubler" },\n    });\n'))),(0,i.kt)(l.Z,{value:"ammobox",mdxType:"TabItem"},(0,i.kt)("p",null,"A pretty complicated example with a lot of math."),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="AmmoBox.cs"',title:'"AmmoBox.cs"'},'[ItemCategories(RogueCategories.Technology, RogueCategories.GunAccessory, RogueCategories.Guns)]\npublic class AmmoBox : CustomItem, IItemCombinable\n{\n    public override void SetupDetails()\n    {\n        Item.itemType = ItemTypes.Combine;\n        Item.itemValue = 4;\n        Item.initCount = 100;\n        Item.rewardCount = 200;\n        Item.hasCharges = true;\n        Item.stackable = true;\n    }\n    public bool CombineFilter(InvItem other) => other.itemType == ItemTypes.WeaponProjectile && !other.noRefills;\n    public bool CombineItems(InvItem other)\n    {\n        int amountToRefill = other.maxAmmo - other.invItemCount;\n        float singleCost = (float)other.itemValue / other.maxAmmo;\n        if (Owner.oma.superSpecialAbility && (Owner.agentName == "Soldier" || Owner.agentName == "Doctor"))\n            singleCost = 0f;\n        if (other.invItemCount >= other.maxAmmo)\n        {\n            Owner.SayDialogue("AmmoDispenserFull");\n            gc.audioHandler.Play(Owner, "CantDo");\n            return false;\n        }\n\n        int affordableAmount = (int)Mathf.Ceil(Count / singleCost);\n        int willBeBought = Mathf.Min(affordableAmount, amountToRefill);\n        int willBeReduced = (int)Mathf.Min(Count, willBeBought * singleCost);\n\n        Count -= willBeReduced;\n        other.invItemCount += willBeBought;\n        Owner.SayDialogue("AmmoDispenserFilled");\n        gc.audioHandler.Play(Owner, "BuyItem");\n        return true;\n    }\n    public CustomTooltip CombineTooltip(InvItem other)\n    {\n        // WIP: API is not stable yet. Will do later.\n        // Plus, I\'m not sure if this thing does the math correctly.\n        if (other.invItemName == "AmmoBox") return null;\n\n        int amountToRefill = other.maxAmmo - other.invItemCount;\n        if (amountToRefill == 0) return null;\n\n        float singleCost = (float)other.itemValue / other.maxAmmo;\n        if (Owner.oma.superSpecialAbility && (Owner.agentName == "Soldier" || Owner.agentName == "Doctor"))\n            singleCost = 0f;\n        int cost = (int)Mathf.Floor(amountToRefill * singleCost);\n        int canAfford = (int)Mathf.Ceil(Count / singleCost);\n\n        return "+" + Mathf.Min(amountToRefill, canAfford) + " (" + Mathf.Min(cost, Count) + ")";\n    }\n    public CustomTooltip CombineCursorText(InvItem other) => null;\n}\n')),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-csharp"},'RogueLibs.CreateCustomItem<AmmoBox>()\n    .WithName(new CustomNameInfo("Ammo Box"))\n    .WithDescription(new CustomNameInfo("Combine with any refillable weapon to refill it. Limited ammo."))\n    .WithSprite(Properties.Resources.AmmoBox)\n    .WithUnlock(new ItemUnlock\n    {\n        UnlockCost = 10,\n        CharacterCreationCost = 3,\n        LoadoutCost = 3,\n        // Portable Ammo Dispenser must be unlocked in order to unlock Ammo Box\n        // Portable Ammo Dispenser is another custom item\n        Prerequisites = { nameof(PortableAmmoDispenser) },\n    });\n')))))}d.isMDXComponent=!0},6010:function(e,t,n){"use strict";function o(e){var t,n,r="";if("string"==typeof e||"number"==typeof e)r+=e;else if("object"==typeof e)if(Array.isArray(e))for(t=0;t<e.length;t++)e[t]&&(n=o(e[t]))&&(r&&(r+=" "),r+=n);else for(t in e)e[t]&&(r&&(r+=" "),r+=t);return r}function r(){for(var e,t,n=0,r="";n<arguments.length;)(e=arguments[n++])&&(t=o(e))&&(r&&(r+=" "),r+=t);return r}n.d(t,{Z:function(){return r}})}}]);