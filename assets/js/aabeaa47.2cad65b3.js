(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[808],{3905:function(e,t,n){"use strict";n.d(t,{Zo:function(){return u},kt:function(){return p}});var a=n(7294);function r(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function i(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var a=Object.getOwnPropertySymbols(e);t&&(a=a.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,a)}return n}function l(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?i(Object(n),!0).forEach((function(t){r(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):i(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function o(e,t){if(null==e)return{};var n,a,r=function(e,t){if(null==e)return{};var n,a,r={},i=Object.keys(e);for(a=0;a<i.length;a++)n=i[a],t.indexOf(n)>=0||(r[n]=e[n]);return r}(e,t);if(Object.getOwnPropertySymbols){var i=Object.getOwnPropertySymbols(e);for(a=0;a<i.length;a++)n=i[a],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(r[n]=e[n])}return r}var c=a.createContext({}),s=function(e){var t=a.useContext(c),n=t;return e&&(n="function"==typeof e?e(t):l(l({},t),e)),n},u=function(e){var t=s(e.components);return a.createElement(c.Provider,{value:t},e.children)},d={inlineCode:"code",wrapper:function(e){var t=e.children;return a.createElement(a.Fragment,{},t)}},m=a.forwardRef((function(e,t){var n=e.components,r=e.mdxType,i=e.originalType,c=e.parentName,u=o(e,["components","mdxType","originalType","parentName"]),m=s(n),p=r,h=m["".concat(c,".").concat(p)]||m[p]||d[p]||i;return n?a.createElement(h,l(l({ref:t},u),{},{components:n})):a.createElement(h,l({ref:t},u))}));function p(e,t){var n=arguments,r=t&&t.mdxType;if("string"==typeof e||r){var i=n.length,l=new Array(i);l[0]=m;var o={};for(var c in t)hasOwnProperty.call(t,c)&&(o[c]=t[c]);o.originalType=e,o.mdxType="string"==typeof e?e:r,l[1]=o;for(var s=2;s<i;s++)l[s]=n[s];return a.createElement.apply(null,l)}return a.createElement.apply(null,n)}m.displayName="MDXCreateElement"},3919:function(e,t,n){"use strict";function a(e){return!0===/^(\w*:|\/\/)/.test(e)}function r(e){return void 0!==e&&!a(e)}n.d(t,{b:function(){return a},Z:function(){return r}})},4996:function(e,t,n){"use strict";n.d(t,{C:function(){return i},Z:function(){return l}});var a=n(2263),r=n(3919);function i(){var e=(0,a.Z)().siteConfig,t=(e=void 0===e?{}:e).baseUrl,n=void 0===t?"/":t,i=e.url;return{withBaseUrl:function(e,t){return function(e,t,n,a){var i=void 0===a?{}:a,l=i.forcePrependBaseUrl,o=void 0!==l&&l,c=i.absolute,s=void 0!==c&&c;if(!n)return n;if(n.startsWith("#"))return n;if((0,r.b)(n))return n;if(o)return t+n;var u=n.startsWith(t)?n:t+n.replace(/^\//,"");return s?e+u:u}(i,n,e,t)}}}function l(e,t){return void 0===t&&(t={}),(0,i().withBaseUrl)(e,t)}},9443:function(e,t,n){"use strict";var a=(0,n(7294).createContext)(void 0);t.Z=a},9309:function(e,t,n){"use strict";n.d(t,{Z:function(){return o}});var a=n(2122),r=n(9756),i=n(7294),l=["children"];function o(e){var t=e.children,n=(0,r.Z)(e,l);return i.createElement("div",(0,a.Z)({role:"tabpanel"},n),t)}},8952:function(e,t,n){"use strict";n.d(t,{Z:function(){return m}});var a=n(7294),r=n(9443);var i=function(){var e=(0,a.useContext)(r.Z);if(null==e)throw new Error('"useUserPreferencesContext" is used outside of "Layout" component.');return e},l=n(6010),o="tabItem_2O3c",c="tabItemActive_Fpbe",s="tab_1pgU";var u=37,d=39;var m=function(e){var t=e.lazy,n=e.block,r=e.defaultValue,m=e.values,p=e.groupId,h=e.className,k=i(),g=k.tabGroupChoices,y=k.setTabGroupChoices,f=(0,a.useState)(r),b=f[0],N=f[1],v=a.Children.toArray(e.children),C=[];if(null!=p){var w=g[p];null!=w&&w!==b&&m.some((function(e){return e.value===w}))&&N(w)}var I=function(e){var t=e.currentTarget,n=C.indexOf(t),a=m[n].value;N(a),null!=p&&(y(p,a),setTimeout((function(){var e,n,a,r,i,l,o,s;(e=t.getBoundingClientRect(),n=e.top,a=e.left,r=e.bottom,i=e.right,l=window,o=l.innerHeight,s=l.innerWidth,n>=0&&i<=s&&r<=o&&a>=0)||(t.scrollIntoView({block:"center",behavior:"smooth"}),t.classList.add(c),setTimeout((function(){return t.classList.remove(c)}),2e3))}),150))},O=function(e){var t,n;switch(e.keyCode){case d:var a=C.indexOf(e.target)+1;n=C[a]||C[0];break;case u:var r=C.indexOf(e.target)-1;n=C[r]||C[C.length-1]}null==(t=n)||t.focus()},T=function(e,t){return t.value===e||t.values&&-1!=t.values.indexOf(e)};return a.createElement("div",{className:"tabs-container"},a.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:(0,l.Z)("tabs",{"tabs--block":n},h)},m.map((function(e){var t=e.value,n=e.label;return a.createElement("li",{role:"tab",tabIndex:b===t?0:-1,"aria-selected":b===t,className:(0,l.Z)("tabs__item",o,{"tabs__item--active":b===t}),key:t,ref:function(e){return C.push(e)},onKeyDown:O,onFocus:I,onClick:I},n)}))),t?(0,a.cloneElement)(v.filter((function(e){return T(b,e.props)}))[0],{className:s}):a.createElement("div",null,v.map((function(e,t){return(0,a.cloneElement)(e,{key:t,hidden:!T(b,e.props),className:s})}))),a.createElement("br",null))}},4965:function(e,t,n){"use strict";n.r(t),n.d(t,{frontMatter:function(){return o},contentTitle:function(){return c},metadata:function(){return s},toc:function(){return u},default:function(){return m}});var a=n(2122),r=n(9756),i=(n(7294),n(3905)),l=(n(8952),n(9309),n(4996),["components"]),o={},c="Inventory Checks",s={unversionedId:"dev/items/inventory-checks",id:"dev/items/inventory-checks",isDocsHomePage:!1,title:"Inventory Checks",description:"InventoryChecks",source:"@site/docs/dev/items/inventory-checks.mdx",sourceDirName:"dev/items",slug:"/dev/items/inventory-checks",permalink:"/RogueLibs/docs/dev/items/inventory-checks",editUrl:"https://github.com/Abbysssal/RogueLibs/edit/master/website/docs/dev/items/inventory-checks.mdx",version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"Custom Projectiles*",permalink:"/RogueLibs/docs/dev/items/weapons/custom-projectiles"},next:{title:"Creating a Custom Ability",permalink:"/RogueLibs/docs/dev/items/abilities/create-ability"}},u=[{value:"<code>InventoryChecks</code>",id:"inventorychecks",children:[]},{value:"Ignoring inventory checks",id:"ignoring-checks",children:[]},{value:"Adding inventory checks",id:"adding-checks",children:[]},{value:"Table of default checks",id:"default-checks",children:[{value:"<code>IItemUsable</code> checks",id:"iitemusable-checks",children:[]},{value:"<code>IItemCombinable</code> checks",id:"iitemcombinable-checks",children:[]},{value:"<code>IItemTargetable</code> checks",id:"iitemtargetable-checks",children:[]}]}],d={toc:u};function m(e){var t=e.components,n=(0,r.Z)(e,l);return(0,i.kt)("wrapper",(0,a.Z)({},d,n,{components:t,mdxType:"MDXLayout"}),(0,i.kt)("h1",{id:"inventory-checks"},"Inventory Checks"),(0,i.kt)("h2",{id:"inventorychecks"},(0,i.kt)("inlineCode",{parentName:"h2"},"InventoryChecks")),(0,i.kt)("p",null,"So, with inventory checks, you can omit code like this:"),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-csharp"},'if (Owner.statusEffects.hasTrait("BloodRestoresHealth"))\n{\n    Owner.SayDialogue("WontEatThis");\n    return;\n}\nif (Owner.statusEffects.hasTrait("OilRestoresHealth"))\n{\n    Owner.SayDialogue("WontEatThat");\n    return;\n}\nif (Owner.health == Owner.maxHealth)\n{\n    Owner.SayDialogue("NoImFull");\n    return;\n}\n...\n')),(0,i.kt)("p",null,"RogueLibs allows you to make ",(0,i.kt)("strong",{parentName:"p"},"inventory checks"),', that will work on all items in the game that meet a certain criteria (for example, have "Food" type and an "Alcohol" category). These inventory checks also implement some usual stuff, that modders sometimes forget to implement. For example, removing an item from the inventory or stopping the interaction, when the item\'s count reaches 0.'),(0,i.kt)("h2",{id:"ignoring-checks"},"Ignoring inventory checks"),(0,i.kt)("p",null,"Inventory checks can be ignored by using an ",(0,i.kt)("inlineCode",{parentName:"p"},"IgnoreChecks")," attribute."),(0,i.kt)("p",null,"You can put ",(0,i.kt)("inlineCode",{parentName:"p"},"IgnoreChecks")," attributes on your item's class or on any of the interface methods."),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-csharp"},'[ItemCategories(RogueCategories.Food, RogueCategories.Weird, "Meat")]\npublic class MysteryFood : CustomItem, IItemUsable\n{\n    // highlight-next-line\n    [IgnoreChecks("VegetarianCheck")]\n    public bool UseItem()\n    {\n        e.User.ChangeHealth(Item.healthChange);\n        Count--;\n        e.User.Say("Huh, tasty. I wonder what that was..."); // O_o\n        return true;\n    }\n}\n')),(0,i.kt)("p",null,"See the table of inventory checks implemented by RogueLibs ",(0,i.kt)("a",{parentName:"p",href:"#default-checks"},"later on this page"),"."),(0,i.kt)("h2",{id:"adding-checks"},"Adding inventory checks"),(0,i.kt)("p",null,(0,i.kt)("inlineCode",{parentName:"p"},"RogueEventArgs")," class has two properties: ",(0,i.kt)("inlineCode",{parentName:"p"},"Cancel")," and ",(0,i.kt)("inlineCode",{parentName:"p"},"Handled"),". If you set ",(0,i.kt)("inlineCode",{parentName:"p"},"Handled")," to ",(0,i.kt)("inlineCode",{parentName:"p"},"true"),", then all other checks will be skipped. If you set ",(0,i.kt)("inlineCode",{parentName:"p"},"Cancel")," to ",(0,i.kt)("inlineCode",{parentName:"p"},"true"),", then the action that was going to happen will not happen. Usually, they are set to ",(0,i.kt)("inlineCode",{parentName:"p"},"true")," at the same time."),(0,i.kt)("p",null,"For example, there's a trait called ",(0,i.kt)("inlineCode",{parentName:"p"},'"Vegetarian"')," that should prohibit the player from consuming food with ",(0,i.kt)("inlineCode",{parentName:"p"},'"Meat"')," category:"),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-csharp"},'InventoryChecks.AddItemUsingCheck("VegetarianCheck", VegetarianCheck);\n...\npublic static void VegetarianCheck(OnItemUsingArgs e)\n{\n    if (e.Item.itemType == ItemTypes.Food && e.User.HasTrait("Vegetarian") && e.Item.Categories.Contains("Meat"))\n    {\n        // do something to indicate why the item cannot be used\n        e.User.gc.audioHandler.Play(e.User, "CantDo");\n        e.User.SayDialogue("WontEatMeat");\n        // set Cancel and Handled to true\n        e.Cancel = e.Handled = true;\n    }\n};\n')),(0,i.kt)("p",null,"If you want to override an inventory check from another mod, then you'll have to patch it with Harmony."),(0,i.kt)("h2",{id:"default-checks"},"Table of default checks"),(0,i.kt)("h3",{id:"iitemusable-checks"},(0,i.kt)("inlineCode",{parentName:"h3"},"IItemUsable")," checks"),(0,i.kt)("table",null,(0,i.kt)("thead",{parentName:"table"},(0,i.kt)("tr",{parentName:"thead"},(0,i.kt)("th",{parentName:"tr",align:null},"Name"),(0,i.kt)("th",{parentName:"tr",align:null},"Criteria"),(0,i.kt)("th",{parentName:"tr",align:null},"Dialogue"))),(0,i.kt)("tbody",{parentName:"table"},(0,i.kt)("tr",{parentName:"tbody"},(0,i.kt)("td",{parentName:"tr",align:null},(0,i.kt)("inlineCode",{parentName:"td"},"Ghost")),(0,i.kt)("td",{parentName:"tr",align:null},"Player is a ghost."),(0,i.kt)("td",{parentName:"tr",align:null},"-")),(0,i.kt)("tr",{parentName:"tbody"},(0,i.kt)("td",{parentName:"tr",align:null},(0,i.kt)("inlineCode",{parentName:"td"},"PeaBrained")),(0,i.kt)("td",{parentName:"tr",align:null},'"Pea-Brained" trait, ',(0,i.kt)("strong",{parentName:"td"},"NOT")," Food type."),(0,i.kt)("td",{parentName:"tr",align:null},'"GRRRRRRRR!!!!!"')),(0,i.kt)("tr",{parentName:"tbody"},(0,i.kt)("td",{parentName:"tr",align:null},(0,i.kt)("inlineCode",{parentName:"td"},"OnlyOil")),(0,i.kt)("td",{parentName:"tr",align:null},'"Oil Reliant" trait, Food type and (Food or Alcohol category).'),(0,i.kt)("td",{parentName:"tr",align:null},'"I\'m gonna need some oil..."')),(0,i.kt)("tr",{parentName:"tbody"},(0,i.kt)("td",{parentName:"tr",align:null},(0,i.kt)("inlineCode",{parentName:"td"},"OnlyOilMedicine")),(0,i.kt)("td",{parentName:"tr",align:null},'"Oil Reliant" trait, Consumable type and Health category.'),(0,i.kt)("td",{parentName:"tr",align:null},'"I\'m gonna need some oil..."')),(0,i.kt)("tr",{parentName:"tbody"},(0,i.kt)("td",{parentName:"tr",align:null},(0,i.kt)("inlineCode",{parentName:"td"},"OnlyBlood")),(0,i.kt)("td",{parentName:"tr",align:null},'"Jugularious" trait, Food type and (Food or Alcohol category).'),(0,i.kt)("td",{parentName:"tr",align:null},'"Ew gross, I\'m not putting that in my mouth!"')),(0,i.kt)("tr",{parentName:"tbody"},(0,i.kt)("td",{parentName:"tr",align:null},(0,i.kt)("inlineCode",{parentName:"td"},"OnlyBloodMedicine")),(0,i.kt)("td",{parentName:"tr",align:null},'"Jugularious" trait, Consumable type and Health category.'),(0,i.kt)("td",{parentName:"tr",align:null},'"Modern medicine is for humans, I want BLOOD!"')),(0,i.kt)("tr",{parentName:"tbody"},(0,i.kt)("td",{parentName:"tr",align:null},(0,i.kt)("inlineCode",{parentName:"td"},"OnlyCharge")),(0,i.kt)("td",{parentName:"tr",align:null},'"Electronic" trait, Food type and Food category.'),(0,i.kt)("td",{parentName:"tr",align:null},'"I don\'t exactly have a stomach."')),(0,i.kt)("tr",{parentName:"tbody"},(0,i.kt)("td",{parentName:"tr",align:null},(0,i.kt)("inlineCode",{parentName:"td"},"OnlyHumanFlesh")),(0,i.kt)("td",{parentName:"tr",align:null},'"Strict Cannibal" trait, Food type and Food category.'),(0,i.kt)("td",{parentName:"tr",align:null},'"Ew gross, I\'m not putting that in my mouth!"')),(0,i.kt)("tr",{parentName:"tbody"},(0,i.kt)("td",{parentName:"tr",align:null},(0,i.kt)("inlineCode",{parentName:"td"},"FullHealth")),(0,i.kt)("td",{parentName:"tr",align:null},"Player's health is full and the item's ",(0,i.kt)("inlineCode",{parentName:"td"},"healthChange")," is greater than 0."),(0,i.kt)("td",{parentName:"tr",align:null},"\"No need, I'm feelin' good!\"")))),(0,i.kt)("p",null,"These checks are exposed via ",(0,i.kt)("inlineCode",{parentName:"p"},"DefaultInventoryChecks"),". The rest are implemented inside RogueLibs' patches."),(0,i.kt)("h3",{id:"iitemcombinable-checks"},(0,i.kt)("inlineCode",{parentName:"h3"},"IItemCombinable")," checks"),(0,i.kt)("table",null,(0,i.kt)("thead",{parentName:"table"},(0,i.kt)("tr",{parentName:"thead"},(0,i.kt)("th",{parentName:"tr",align:null},"Name"),(0,i.kt)("th",{parentName:"tr",align:null},"Criteria"),(0,i.kt)("th",{parentName:"tr",align:null},"What will happen"))),(0,i.kt)("tbody",{parentName:"table"},(0,i.kt)("tr",{parentName:"tbody"},(0,i.kt)("td",{parentName:"tr",align:null},(0,i.kt)("inlineCode",{parentName:"td"},"AutoStacking")),(0,i.kt)("td",{parentName:"tr",align:null},"Items have the same name"),(0,i.kt)("td",{parentName:"tr",align:null},"They will be highlighted, and once combined, they will be stacked together")),(0,i.kt)("tr",{parentName:"tbody"},(0,i.kt)("td",{parentName:"tr",align:null},(0,i.kt)("inlineCode",{parentName:"td"},"StopOnZero")),(0,i.kt)("td",{parentName:"tr",align:null},"The current item's count is 0, or it's no longer in the inventory"),(0,i.kt)("td",{parentName:"tr",align:null},"Interaction/combining will be stopped")))),(0,i.kt)("h3",{id:"iitemtargetable-checks"},(0,i.kt)("inlineCode",{parentName:"h3"},"IItemTargetable")," checks"),(0,i.kt)("table",null,(0,i.kt)("thead",{parentName:"table"},(0,i.kt)("tr",{parentName:"thead"},(0,i.kt)("th",{parentName:"tr",align:null},"Name"),(0,i.kt)("th",{parentName:"tr",align:null},"Criteria"),(0,i.kt)("th",{parentName:"tr",align:null},"What will happen"))),(0,i.kt)("tbody",{parentName:"table"},(0,i.kt)("tr",{parentName:"tbody"},(0,i.kt)("td",{parentName:"tr",align:null},(0,i.kt)("inlineCode",{parentName:"td"},"Distance")),(0,i.kt)("td",{parentName:"tr",align:null},"The target object is over 15 units away"),(0,i.kt)("td",{parentName:"tr",align:null},(0,i.kt)("inlineCode",{parentName:"td"},"false"))),(0,i.kt)("tr",{parentName:"tbody"},(0,i.kt)("td",{parentName:"tr",align:null},(0,i.kt)("inlineCode",{parentName:"td"},"ButlerBot")),(0,i.kt)("td",{parentName:"tr",align:null},"The target is a Butler Bot"),(0,i.kt)("td",{parentName:"tr",align:null},(0,i.kt)("inlineCode",{parentName:"td"},"false"))),(0,i.kt)("tr",{parentName:"tbody"},(0,i.kt)("td",{parentName:"tr",align:null},(0,i.kt)("inlineCode",{parentName:"td"},"EmptyMech")),(0,i.kt)("td",{parentName:"tr",align:null},"The target is an Empty Mech"),(0,i.kt)("td",{parentName:"tr",align:null},(0,i.kt)("inlineCode",{parentName:"td"},"false"))),(0,i.kt)("tr",{parentName:"tbody"},(0,i.kt)("td",{parentName:"tr",align:null},(0,i.kt)("inlineCode",{parentName:"td"},"StopOnZero")),(0,i.kt)("td",{parentName:"tr",align:null},"The current item's count is 0, or it's no longer in the inventory"),(0,i.kt)("td",{parentName:"tr",align:null},"Interaction/targeting will be stopped")))))}m.isMDXComponent=!0},6010:function(e,t,n){"use strict";function a(e){var t,n,r="";if("string"==typeof e||"number"==typeof e)r+=e;else if("object"==typeof e)if(Array.isArray(e))for(t=0;t<e.length;t++)e[t]&&(n=a(e[t]))&&(r&&(r+=" "),r+=n);else for(t in e)e[t]&&(r&&(r+=" "),r+=t);return r}function r(){for(var e,t,n=0,r="";n<arguments.length;)(e=arguments[n++])&&(t=a(e))&&(r&&(r+=" "),r+=t);return r}n.d(t,{Z:function(){return r}})}}]);