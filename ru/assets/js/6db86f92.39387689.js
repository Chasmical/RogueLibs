"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[4488],{3905:(e,t,n)=>{n.d(t,{Zo:()=>m,kt:()=>s});var a=n(7294);function r(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function l(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var a=Object.getOwnPropertySymbols(e);t&&(a=a.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,a)}return n}function i(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?l(Object(n),!0).forEach((function(t){r(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):l(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function o(e,t){if(null==e)return{};var n,a,r=function(e,t){if(null==e)return{};var n,a,r={},l=Object.keys(e);for(a=0;a<l.length;a++)n=l[a],t.indexOf(n)>=0||(r[n]=e[n]);return r}(e,t);if(Object.getOwnPropertySymbols){var l=Object.getOwnPropertySymbols(e);for(a=0;a<l.length;a++)n=l[a],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(r[n]=e[n])}return r}var d=a.createContext({}),p=function(e){var t=a.useContext(d),n=t;return e&&(n="function"==typeof e?e(t):i(i({},t),e)),n},m=function(e){var t=p(e.components);return a.createElement(d.Provider,{value:t},e.children)},u={inlineCode:"code",wrapper:function(e){var t=e.children;return a.createElement(a.Fragment,{},t)}},c=a.forwardRef((function(e,t){var n=e.components,r=e.mdxType,l=e.originalType,d=e.parentName,m=o(e,["components","mdxType","originalType","parentName"]),c=p(n),s=r,k=c["".concat(d,".").concat(s)]||c[s]||u[s]||l;return n?a.createElement(k,i(i({ref:t},m),{},{components:n})):a.createElement(k,i({ref:t},m))}));function s(e,t){var n=arguments,r=t&&t.mdxType;if("string"==typeof e||r){var l=n.length,i=new Array(l);i[0]=c;var o={};for(var d in t)hasOwnProperty.call(t,d)&&(o[d]=t[d]);o.originalType=e,o.mdxType="string"==typeof e?e:r,i[1]=o;for(var p=2;p<l;p++)i[p]=n[p];return a.createElement.apply(null,i)}return a.createElement.apply(null,n)}c.displayName="MDXCreateElement"},1016:(e,t,n)=>{n.d(t,{Z:()=>l});var a=n(7462),r=n(7294);function l(e){let{children:t,...n}=e;return r.createElement("div",(0,a.Z)({role:"tabpanel"},n),t)}},250:(e,t,n)=>{n.d(t,{Z:()=>u});var a=n(7294),r=n(7094),l=n(6010);const i="tabItem_V91s",o="tabItemActive_JsUu",d="tab_ntnM";const p=37,m=39;function u(e){const{lazy:t,defaultValue:n,values:u,groupId:c}=e,{tabGroupChoices:s,setTabGroupChoices:k}=(0,r.U)(),[g,N]=(0,a.useState)(n),h=a.Children.toArray(e.children),b=[];if(null!=c){const e=s[c];null!=e&&e!==g&&u.some((t=>t.value===e))&&N(e)}const y=e=>{const t=e.currentTarget,n=b.indexOf(t),a=u[n].value;N(a),null!=c&&(k(c,a),setTimeout((()=>{(function(e){const{top:t,left:n,bottom:a,right:r}=e.getBoundingClientRect(),{innerHeight:l,innerWidth:i}=window;return t>=0&&r<=i&&a<=l&&n>=0})(t)||(t.scrollIntoView({block:"center",behavior:"smooth"}),t.classList.add(o),setTimeout((()=>t.classList.remove(o)),2e3))}),150))},C=e=>{let t;switch(e.keyCode){case m:{const n=b.indexOf(e.target)+1;t=b[n]||b[0];break}case p:{const n=b.indexOf(e.target)-1;t=b[n]||b[b.length-1];break}default:return}t.focus()},v=(e,t)=>t.value===e||t.values&&-1!=t.values.indexOf(e);return a.createElement("div",{className:"tabs-container"},a.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:"tabs"},u.map((e=>{let{value:t,label:n}=e;return a.createElement("li",{role:"tab",tabIndex:g===t?0:-1,"aria-selected":g===t,className:(0,l.Z)("tabs__item",i,{"tabs__item--active":g===t}),key:t,ref:e=>e&&b.push(e),onKeyDown:C,onFocus:y,onClick:y},n)}))),t?a.cloneElement(h.find((e=>v(g,e.props))),{className:d}):a.createElement("div",null,h.map(((e,t)=>a.cloneElement(e,{key:t,hidden:!v(g,e.props),className:d})))),a.createElement("br",null))}},7419:(e,t,n)=>{n.r(t),n.d(t,{assets:()=>d,contentTitle:()=>i,default:()=>u,frontMatter:()=>l,metadata:()=>o,toc:()=>p});var a=n(7462),r=(n(7294),n(3905));n(250),n(1016),n(4996);const l={},i="\u0418\u043d\u0432\u0435\u043d\u0442\u0430\u0440\u043d\u044b\u0435 \u043f\u0440\u043e\u0432\u0435\u0440\u043a\u0438",o={unversionedId:"dev/items/inventory-checks",id:"dev/items/inventory-checks",title:"\u0418\u043d\u0432\u0435\u043d\u0442\u0430\u0440\u043d\u044b\u0435 \u043f\u0440\u043e\u0432\u0435\u0440\u043a\u0438",description:"InventoryChecks",source:"@site/i18n/ru/docusaurus-plugin-content-docs/current/dev/items/inventory-checks.mdx",sourceDirName:"dev/items",slug:"/dev/items/inventory-checks",permalink:"/RogueLibs/ru/docs/dev/items/inventory-checks",draft:!1,editUrl:"https://github.com/SugarBarrel/RogueLibs/edit/main/website/docs/dev/items/inventory-checks.mdx",tags:[],version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"\u041a\u0430\u0441\u0442\u043e\u043c\u043d\u044b\u0435 \u0441\u043d\u0430\u0440\u044f\u0434\u044b*",permalink:"/RogueLibs/ru/docs/dev/items/weapons/custom-projectiles"},next:{title:"\u0421\u043e\u0437\u0434\u0430\u0451\u043c \u043a\u0430\u0441\u0442\u043e\u043c\u043d\u0443\u044e \u0441\u043f\u043e\u0441\u043e\u0431\u043d\u043e\u0441\u0442\u044c",permalink:"/RogueLibs/ru/docs/dev/items/abilities/create-ability"}},d={},p=[{value:"<code>InventoryChecks</code>",id:"inventorychecks",level:2},{value:"\u0418\u0433\u043d\u043e\u0440\u0438\u0440\u043e\u0432\u0430\u043d\u0438\u0435 \u0438\u043d\u0432\u0435\u043d\u0442\u0430\u0440\u043d\u044b\u0445 \u043f\u0440\u043e\u0432\u0435\u0440\u043e\u043a",id:"ignoring-checks",level:2},{value:"\u0421\u043e\u0437\u0434\u0430\u043d\u0438\u0435 \u0438\u043d\u0432\u0435\u043d\u0442\u0430\u0440\u043d\u044b\u0445 \u043f\u0440\u043e\u0432\u0435\u0440\u043e\u043a",id:"adding-checks",level:2},{value:"\u0422\u0430\u0431\u043b\u0438\u0446\u0430 \u0438\u043d\u0432\u0435\u043d\u0442\u0430\u0440\u043d\u044b\u0445 \u043f\u0440\u043e\u0432\u0435\u0440\u043e\u043a \u043f\u043e \u0443\u043c\u043e\u043b\u0447\u0430\u043d\u0438\u044e",id:"default-checks",level:2},{value:"\u041f\u0440\u043e\u0432\u0435\u0440\u043a\u0438 <code>IItemUsable</code>",id:"iitemusable-checks",level:3},{value:"\u041f\u0440\u043e\u0432\u0435\u0440\u043a\u0438 <code>IItemCombinable</code>",id:"iitemcombinable-checks",level:3},{value:"\u041f\u0440\u043e\u0432\u0435\u0440\u043a\u0438 <code>IItemTargetable</code>",id:"iitemtargetable-checks",level:3}],m={toc:p};function u(e){let{components:t,...n}=e;return(0,r.kt)("wrapper",(0,a.Z)({},m,n,{components:t,mdxType:"MDXLayout"}),(0,r.kt)("h1",{id:"\u0438\u043d\u0432\u0435\u043d\u0442\u0430\u0440\u043d\u044b\u0435-\u043f\u0440\u043e\u0432\u0435\u0440\u043a\u0438"},"\u0418\u043d\u0432\u0435\u043d\u0442\u0430\u0440\u043d\u044b\u0435 \u043f\u0440\u043e\u0432\u0435\u0440\u043a\u0438"),(0,r.kt)("h2",{id:"inventorychecks"},(0,r.kt)("inlineCode",{parentName:"h2"},"InventoryChecks")),(0,r.kt)("p",null,"\u0418\u0442\u0430\u043a, \u0441 \u0438\u043d\u0432\u0435\u043d\u0442\u0430\u0440\u043d\u044b\u043c\u0438 \u043f\u0440\u043e\u0432\u0435\u0440\u043a\u0430\u043c\u0438, \u0432\u044b \u043c\u043e\u0436\u0435\u0442\u0435 \u043e\u043f\u0443\u0441\u0442\u0438\u0442\u044c \u0442\u0430\u043a\u043e\u0439 \u043a\u043e\u0434:"),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},'if (Owner.statusEffects.hasTrait("BloodRestoresHealth"))\n{\n    Owner.SayDialogue("WontEatThis");\n    return;\n}\nif (Owner.statusEffects.hasTrait("OilRestoresHealth"))\n{\n    Owner.SayDialogue("WontEatThat");\n    return;\n}\nif (Owner.health == Owner.maxHealth)\n{\n    Owner.SayDialogue("NoImFull");\n    return;\n}\n...\n')),(0,r.kt)("p",null,"RogueLibs \u043f\u043e\u0437\u0432\u043e\u043b\u044f\u0435\u0442 \u0432\u0430\u043c \u0441\u043e\u0437\u0434\u0430\u0432\u0430\u0442\u044c ",(0,r.kt)("strong",{parentName:"p"},"\u0438\u043d\u0432\u0435\u043d\u0442\u0430\u0440\u043d\u044b\u0435 \u043f\u0440\u043e\u0432\u0435\u0440\u043a\u0438"),', \u043a\u043e\u0442\u043e\u0440\u044b\u0435 \u0431\u0443\u0434\u0443\u0442 \u0440\u0430\u0431\u043e\u0442\u0430\u0442\u044c \u043d\u0430 \u0432\u0441\u0435\u0445 \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u0430\u0445 \u0432 \u0438\u0433\u0440\u0435, \u0441\u043e\u043e\u0442\u0432\u0435\u0442\u0441\u0442\u0432\u0443\u044e\u0449\u0438\u0445 \u043e\u043f\u0440\u0435\u0434\u0435\u043b\u0451\u043d\u043d\u044b\u043c \u043a\u0440\u0438\u0442\u0435\u0440\u0438\u044f\u043c (\u043d\u0430\u043f\u0440\u0438\u043c\u0435\u0440, \u0438\u043c\u0435\u044e\u0442 \u0442\u0438\u043f "Food" \u0438 \u043a\u0430\u0442\u0435\u0433\u043e\u0440\u0438\u044e "Alcohol"). \u0422\u0430\u043a\u0438\u0435 \u0438\u043d\u0432\u0435\u043d\u0442\u0430\u0440\u043d\u044b\u0435 \u043f\u0440\u043e\u0432\u0435\u0440\u043a\u0438 \u0442\u0430\u043a\u0436\u0435 \u0440\u0435\u0430\u043b\u0438\u0437\u0443\u044e\u0442 \u043d\u0435\u043a\u043e\u0442\u043e\u0440\u044b\u0435 \u043e\u0431\u044b\u0447\u043d\u044b\u0435 \u0448\u0442\u0443\u043a\u0438, \u043a\u043e\u0442\u043e\u0440\u044b\u0435 \u043c\u043e\u0434\u0434\u0435\u0440\u044b \u0438\u043d\u043e\u0433\u0434\u0430 \u0437\u0430\u0431\u044b\u0432\u0430\u044e\u0442 \u0440\u0435\u0430\u043b\u0438\u0437\u043e\u0432\u0430\u0442\u044c. \u041d\u0430\u043f\u0440\u0438\u043c\u0435\u0440, \u0443\u0434\u0430\u043b\u0435\u043d\u0438\u0435 \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u0430 \u0438\u0437 \u0438\u043d\u0432\u0435\u043d\u0442\u0430\u0440\u044f \u0438\u043b\u0438 \u043e\u0441\u0442\u0430\u043d\u043e\u0432\u043a\u0430 \u0432\u0437\u0430\u0438\u043c\u043e\u0434\u0435\u0439\u0441\u0442\u0432\u0438\u044f, \u043a\u043e\u0433\u0434\u0430 \u043a\u043e\u043b\u0438\u0447\u0435\u0441\u0442\u0432\u043e \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u0430 \u0441\u0442\u0430\u043d\u043e\u0432\u0438\u0442\u0441\u044f \u0440\u0430\u0432\u043d\u044b\u043c 0.'),(0,r.kt)("h2",{id:"ignoring-checks"},"\u0418\u0433\u043d\u043e\u0440\u0438\u0440\u043e\u0432\u0430\u043d\u0438\u0435 \u0438\u043d\u0432\u0435\u043d\u0442\u0430\u0440\u043d\u044b\u0445 \u043f\u0440\u043e\u0432\u0435\u0440\u043e\u043a"),(0,r.kt)("p",null,"\u0418\u043d\u0432\u0435\u043d\u0442\u0430\u0440\u043d\u044b\u0435 \u043f\u0440\u043e\u0432\u0435\u0440\u043a\u0438 \u043c\u043e\u0433\u0443\u0442 \u0431\u044b\u0442\u044c \u043f\u0440\u043e\u0438\u0433\u043d\u043e\u0440\u0438\u0440\u043e\u0432\u0430\u043d\u044b \u0441 \u043f\u043e\u043c\u043e\u0449\u044c\u044e \u0430\u0442\u0440\u0438\u0431\u0443\u0442\u0430 ",(0,r.kt)("inlineCode",{parentName:"p"},"IgnoreChecks"),"."),(0,r.kt)("p",null,"\u0412\u044b \u043c\u043e\u0436\u0435\u0442\u0435 \u0441\u0442\u0430\u0432\u0438\u0442\u044c \u0430\u0442\u0440\u0438\u0431\u0443\u0442\u044b ",(0,r.kt)("inlineCode",{parentName:"p"},"IgnoreChecks")," \u043d\u0430 \u043a\u043b\u0430\u0441\u0441 \u0432\u0430\u0448\u0435\u0433\u043e \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u0430 \u0438\u043b\u0438 \u043d\u0430 \u043b\u044e\u0431\u043e\u0439 \u0438\u0437 \u0435\u0433\u043e \u0438\u043d\u0442\u0435\u0440\u0444\u0435\u0439\u0441\u043d\u044b\u0445 \u043c\u0435\u0442\u043e\u0434\u043e\u0432."),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},'[ItemCategories(RogueCategories.Food, RogueCategories.Weird, "Meat")]\npublic class MysteryFood : CustomItem, IItemUsable\n{\n    // highlight-next-line\n    [IgnoreChecks("VegetarianCheck")]\n    public bool UseItem()\n    {\n        e.User.ChangeHealth(Item.healthChange);\n        Count--;\n        e.User.Say("Huh, tasty. I wonder what that was..."); // O_o\n        return true;\n    }\n}\n')),(0,r.kt)("p",null,"\u0421\u043c\u043e\u0442\u0440\u0438\u0442\u0435 \u0442\u0430\u0431\u043b\u0438\u0446\u0443 \u0438\u043d\u0432\u0435\u043d\u0442\u0430\u0440\u043d\u044b\u0445 \u043f\u0440\u043e\u0432\u0435\u0440\u043e\u043a \u0440\u0435\u0430\u043b\u0438\u0437\u043e\u0432\u0430\u043d\u043d\u044b\u0445 \u0432 RogueLibs ",(0,r.kt)("a",{parentName:"p",href:"#default-checks"},"\u043f\u043e\u0437\u0436\u0435 \u043d\u0430 \u044d\u0442\u043e\u0439 \u0441\u0442\u0440\u0430\u043d\u0438\u0446\u0435"),"."),(0,r.kt)("h2",{id:"adding-checks"},"\u0421\u043e\u0437\u0434\u0430\u043d\u0438\u0435 \u0438\u043d\u0432\u0435\u043d\u0442\u0430\u0440\u043d\u044b\u0445 \u043f\u0440\u043e\u0432\u0435\u0440\u043e\u043a"),(0,r.kt)("p",null,"\u0423 \u043a\u043b\u0430\u0441\u0441\u0430 ",(0,r.kt)("inlineCode",{parentName:"p"},"RogueEventArgs")," \u0435\u0441\u0442\u044c \u0434\u0432\u0430 \u0441\u0432\u043e\u0439\u0441\u0442\u0432\u0430: ",(0,r.kt)("inlineCode",{parentName:"p"},"Cancel")," \u0438 ",(0,r.kt)("inlineCode",{parentName:"p"},"Handled"),". \u0415\u0441\u043b\u0438 \u0432\u044b\u0441\u0442\u0430\u0432\u0438\u0442\u044c ",(0,r.kt)("inlineCode",{parentName:"p"},"Handled")," \u043d\u0430 ",(0,r.kt)("inlineCode",{parentName:"p"},"true"),", \u0442\u043e \u0432\u0441\u0435 \u0434\u0440\u0443\u0433\u0438\u0435 \u043f\u0440\u043e\u0432\u0435\u0440\u043a\u0438 \u0431\u0443\u0434\u0443\u0442 \u043f\u0440\u043e\u043f\u0443\u0449\u0435\u043d\u044b. \u0415\u0441\u043b\u0438 \u0432\u044b\u0441\u0442\u0430\u0432\u0438\u0442\u044c ",(0,r.kt)("inlineCode",{parentName:"p"},"Cancel")," \u043d\u0430 ",(0,r.kt)("inlineCode",{parentName:"p"},"true"),", \u0442\u043e \u0434\u0435\u0439\u0441\u0442\u0432\u0438\u0435, \u043a\u043e\u0442\u043e\u0440\u043e\u0435 \u0434\u043e\u043b\u0436\u043d\u043e \u0431\u044b\u043b\u043e \u043f\u0440\u043e\u0438\u0437\u043e\u0439\u0442\u0438, \u043d\u0435 \u043f\u0440\u043e\u0438\u0437\u043e\u0439\u0434\u0451\u0442. \u041e\u0431\u044b\u0447\u043d\u043e, \u043e\u043d\u0438 \u0441\u0442\u0430\u0432\u044f\u0442\u0441\u044f \u043d\u0430 ",(0,r.kt)("inlineCode",{parentName:"p"},"true")," \u043e\u0434\u043d\u043e\u0432\u0440\u0435\u043c\u0435\u043d\u043d\u043e."),(0,r.kt)("p",null,"\u041d\u0430\u043f\u0440\u0438\u043c\u0435\u0440, \u0435\u0441\u0442\u044c \u043e\u0441\u043e\u0431\u0435\u043d\u043d\u043e\u0441\u0442\u044c \u043f\u043e\u0434 \u043d\u0430\u0437\u0432\u0430\u043d\u0438\u0435\u043c ",(0,r.kt)("inlineCode",{parentName:"p"},'"Vegetarian"')," \u043a\u043e\u0442\u043e\u0440\u0430\u044f \u043d\u0435 \u0434\u043e\u043b\u0436\u043d\u0430 \u0434\u0430\u0432\u0430\u0442\u044c \u0438\u0433\u0440\u043e\u043a\u0443 \u0443\u043f\u043e\u0442\u0440\u0435\u0431\u043b\u044f\u0442\u044c \u0435\u0434\u0443 \u0441 \u043a\u0430\u0442\u0435\u0433\u043e\u0440\u0438\u0435\u0439 ",(0,r.kt)("inlineCode",{parentName:"p"},'"Meat"'),":"),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},'InventoryChecks.AddItemUsingCheck("VegetarianCheck", VegetarianCheck);\n...\npublic static void VegetarianCheck(OnItemUsingArgs e)\n{\n    if (e.Item.itemType == ItemTypes.Food && e.User.HasTrait("Vegetarian") && e.Item.Categories.Contains("Meat"))\n    {\n        // \u0441\u0434\u0435\u043b\u0430\u0442\u044c \u0447\u0442\u043e-\u043d\u0438\u0431\u0443\u0434\u044c \u0447\u0442\u043e\u0431\u044b \u043f\u043e\u043a\u0430\u0437\u0430\u0442\u044c \u043f\u043e\u0447\u0435\u043c\u0443 \u043f\u0440\u0435\u0434\u043c\u0435\u0442 \u043d\u0435 \u043c\u043e\u0436\u0435\u0442 \u0431\u044b\u0442\u044c \u0438\u0441\u043f\u043e\u043b\u044c\u0437\u043e\u0432\u0430\u043d\n        e.User.gc.audioHandler.Play(e.User, "CantDo");\n        e.User.SayDialogue("WontEatMeat");\n        // \u0432\u044b\u0441\u0442\u0430\u0432\u0438\u0442\u044c Cancel \u0438 Handled \u043d\u0430 true\n        e.Cancel = e.Handled = true;\n    }\n};\n')),(0,r.kt)("p",null,"\u0415\u0441\u043b\u0438 \u0432\u044b \u0445\u043e\u0442\u0438\u0442\u0435 \u043f\u0435\u0440\u0435\u0433\u0440\u0443\u0437\u0438\u0442\u044c \u0438\u043d\u0432\u0435\u043d\u0442\u0430\u0440\u043d\u0443\u044e \u043f\u0440\u043e\u0432\u0435\u0440\u043a\u0443 \u0438\u0437 \u0434\u0440\u0443\u0433\u043e\u0433\u043e \u043c\u043e\u0434\u0430, \u0442\u043e \u0432\u0430\u043c \u043f\u0440\u0438\u0434\u0451\u0442\u0441\u044f \u043f\u0430\u0442\u0447\u0438\u0442\u044c \u0435\u0451 \u0441 Harmony."),(0,r.kt)("h2",{id:"default-checks"},"\u0422\u0430\u0431\u043b\u0438\u0446\u0430 \u0438\u043d\u0432\u0435\u043d\u0442\u0430\u0440\u043d\u044b\u0445 \u043f\u0440\u043e\u0432\u0435\u0440\u043e\u043a \u043f\u043e \u0443\u043c\u043e\u043b\u0447\u0430\u043d\u0438\u044e"),(0,r.kt)("h3",{id:"iitemusable-checks"},"\u041f\u0440\u043e\u0432\u0435\u0440\u043a\u0438 ",(0,r.kt)("inlineCode",{parentName:"h3"},"IItemUsable")),(0,r.kt)("table",null,(0,r.kt)("thead",{parentName:"table"},(0,r.kt)("tr",{parentName:"thead"},(0,r.kt)("th",{parentName:"tr",align:null},"\u041d\u0430\u0437\u0432\u0430\u043d\u0438\u0435"),(0,r.kt)("th",{parentName:"tr",align:null},"\u041a\u0440\u0438\u0442\u0435\u0440\u0438\u0438"),(0,r.kt)("th",{parentName:"tr",align:null},"\u0424\u0440\u0430\u0437\u0430"))),(0,r.kt)("tbody",{parentName:"table"},(0,r.kt)("tr",{parentName:"tbody"},(0,r.kt)("td",{parentName:"tr",align:null},(0,r.kt)("inlineCode",{parentName:"td"},"Ghost")),(0,r.kt)("td",{parentName:"tr",align:null},"\u0418\u0433\u0440\u043e\u043a - \u043f\u0440\u0438\u0437\u0440\u0430\u043a."),(0,r.kt)("td",{parentName:"tr",align:null},"-")),(0,r.kt)("tr",{parentName:"tbody"},(0,r.kt)("td",{parentName:"tr",align:null},(0,r.kt)("inlineCode",{parentName:"td"},"PeaBrained")),(0,r.kt)("td",{parentName:"tr",align:null},'\u041e\u0441\u043e\u0431\u0435\u043d\u043d\u043e\u0441\u0442\u044c "\u0411\u0435\u0437\u043c\u043e\u0437\u0433\u043b\u044b\u0439", \u0442\u0438\u043f ',(0,r.kt)("strong",{parentName:"td"},"\u041d\u0415")," Food."),(0,r.kt)("td",{parentName:"tr",align:null},'"\u0420-\u0440-\u0440-\u0440-\u0440!!!!!"')),(0,r.kt)("tr",{parentName:"tbody"},(0,r.kt)("td",{parentName:"tr",align:null},(0,r.kt)("inlineCode",{parentName:"td"},"OnlyOil")),(0,r.kt)("td",{parentName:"tr",align:null},'\u041e\u0441\u043e\u0431\u0435\u043d\u043d\u043e\u0441\u0442\u044c "\u0411\u0435\u043d\u0437\u0438\u043d\u043e\u0437\u0430\u0432\u0438\u0441\u0438\u043c\u043e\u0441\u0442\u044c", \u0442\u0438\u043f Food \u0438 (\u043a\u0430\u0442\u0435\u0433\u043e\u0440\u0438\u044f Food \u0438\u043b\u0438 Alcohol).'),(0,r.kt)("td",{parentName:"tr",align:null},'"\u041c\u043d\u0435 \u043d\u0443\u0436\u0435\u043d \u0431\u0435\u043d\u0437\u0438\u043d..."')),(0,r.kt)("tr",{parentName:"tbody"},(0,r.kt)("td",{parentName:"tr",align:null},(0,r.kt)("inlineCode",{parentName:"td"},"OnlyOilMedicine")),(0,r.kt)("td",{parentName:"tr",align:null},'\u041e\u0441\u043e\u0431\u0435\u043d\u043d\u043e\u0441\u0442\u044c "\u0411\u0435\u043d\u0437\u0438\u043d\u043e\u0437\u0430\u0432\u0438\u0441\u0438\u043c\u043e\u0441\u0442\u044c", \u0442\u0438\u043f Consumable \u0438 \u043a\u0430\u0442\u0435\u0433\u043e\u0440\u0438\u044f Health.'),(0,r.kt)("td",{parentName:"tr",align:null},'"\u041c\u043d\u0435 \u043d\u0443\u0436\u0435\u043d \u0431\u0435\u043d\u0437\u0438\u043d..."')),(0,r.kt)("tr",{parentName:"tbody"},(0,r.kt)("td",{parentName:"tr",align:null},(0,r.kt)("inlineCode",{parentName:"td"},"OnlyBlood")),(0,r.kt)("td",{parentName:"tr",align:null},'\u041e\u0441\u043e\u0431\u0435\u043d\u043d\u043e\u0441\u0442\u044c "\u041a\u0440\u043e\u0432\u043e\u043f\u0438\u0439\u0446\u0430", \u0442\u0438\u043f Food \u0438 (\u043a\u0430\u0442\u0435\u0433\u043e\u0440\u0438\u044f Food \u0438\u043b\u0438 Alcohol).'),(0,r.kt)("td",{parentName:"tr",align:null},'"\u0424\u0443, \u0433\u0430\u0434\u043e\u0441\u0442\u044c, \u044f \u043d\u0435 \u0431\u0443\u0434\u0443 \u044d\u0442\u043e \u0435\u0441\u0442\u044c!"')),(0,r.kt)("tr",{parentName:"tbody"},(0,r.kt)("td",{parentName:"tr",align:null},(0,r.kt)("inlineCode",{parentName:"td"},"OnlyBloodMedicine")),(0,r.kt)("td",{parentName:"tr",align:null},'\u041e\u0441\u043e\u0431\u0435\u043d\u043d\u043e\u0441\u0442\u044c "\u041a\u0440\u043e\u0432\u043e\u043f\u0438\u0439\u0446\u0430", \u0442\u0438\u043f Consumable \u0438 \u043a\u0430\u0442\u0435\u0433\u043e\u0440\u0438\u044f Health.'),(0,r.kt)("td",{parentName:"tr",align:null},'"\u0421\u043e\u0432\u0440\u0435\u043c\u0435\u043d\u043d\u0430\u044f \u043c\u0435\u0434\u0438\u0446\u0438\u043d\u0430 \u0434\u043b\u044f \u043b\u044e\u0434\u0435\u0439, \u043c\u043d\u0435 \u043d\u0443\u0436\u043d\u0430 \u041a\u0420\u041e\u0412\u042c!"')),(0,r.kt)("tr",{parentName:"tbody"},(0,r.kt)("td",{parentName:"tr",align:null},(0,r.kt)("inlineCode",{parentName:"td"},"OnlyCharge")),(0,r.kt)("td",{parentName:"tr",align:null},'\u041e\u0441\u043e\u0431\u0435\u043d\u043d\u043e\u0441\u0442\u044c "\u042d\u043b\u0435\u043a\u0442\u0440\u043e\u043d\u043d\u044b\u0439", \u0442\u0438\u043f Food \u0438 \u043a\u0430\u0442\u0435\u0433\u043e\u0440\u0438\u044f Food.'),(0,r.kt)("td",{parentName:"tr",align:null},'"\u0423 \u043c\u0435\u043d\u044f \u043d\u0435\u0442 \u0436\u0435\u043b\u0443\u0434\u043a\u0430."')),(0,r.kt)("tr",{parentName:"tbody"},(0,r.kt)("td",{parentName:"tr",align:null},(0,r.kt)("inlineCode",{parentName:"td"},"OnlyHumanFlesh")),(0,r.kt)("td",{parentName:"tr",align:null},'\u041e\u0441\u043e\u0431\u0435\u043d\u043d\u043e\u0441\u0442\u044c "\u042f\u0440\u044b\u0439 \u043a\u0430\u043d\u043d\u0438\u0431\u0430\u043b\u0438\u0437\u043c", \u0442\u0438\u043f Food \u0438 \u043a\u0430\u0442\u0435\u0433\u043e\u0440\u0438\u044f Food.'),(0,r.kt)("td",{parentName:"tr",align:null},'"\u0424\u0443, \u0433\u0430\u0434\u043e\u0441\u0442\u044c, \u044f \u043d\u0435 \u0431\u0443\u0434\u0443 \u044d\u0442\u043e \u0435\u0441\u0442\u044c!"')),(0,r.kt)("tr",{parentName:"tbody"},(0,r.kt)("td",{parentName:"tr",align:null},(0,r.kt)("inlineCode",{parentName:"td"},"FullHealth")),(0,r.kt)("td",{parentName:"tr",align:null},"\u0423 \u0438\u0433\u0440\u043e\u043a\u0430 \u043f\u043e\u043b\u043d\u043e\u0435 \u0437\u0434\u043e\u0440\u043e\u0432\u044c\u0435 \u0438 ",(0,r.kt)("inlineCode",{parentName:"td"},"healthChange")," \u0443 \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u0430 \u0431\u043e\u043b\u044c\u0448\u0435 0."),(0,r.kt)("td",{parentName:"tr",align:null},'"\u041d\u0435 \u043d\u0430\u0434\u043e, \u0443 \u043c\u0435\u043d\u044f \u0438 \u0442\u0430\u043a \u0432\u0441\u0435 \u0432 \u043f\u043e\u0440\u044f\u0434\u043a\u0435!"')))),(0,r.kt)("p",null,"\u042d\u0442\u0438 \u043f\u0440\u043e\u0432\u0435\u0440\u043a\u0438 \u0434\u043e\u0441\u0442\u0443\u043f\u043d\u044b \u0447\u0435\u0440\u0435\u0437 ",(0,r.kt)("inlineCode",{parentName:"p"},"DefaultInventoryChecks"),". \u041e\u0441\u0442\u0430\u043b\u044c\u043d\u044b\u0435 \u0440\u0435\u0430\u043b\u0438\u0437\u043e\u0432\u0430\u043d\u044b \u0432\u043d\u0443\u0442\u0440\u0438 \u043f\u0430\u0442\u0447\u0435\u0439 RogueLibs."),(0,r.kt)("h3",{id:"iitemcombinable-checks"},"\u041f\u0440\u043e\u0432\u0435\u0440\u043a\u0438 ",(0,r.kt)("inlineCode",{parentName:"h3"},"IItemCombinable")),(0,r.kt)("table",null,(0,r.kt)("thead",{parentName:"table"},(0,r.kt)("tr",{parentName:"thead"},(0,r.kt)("th",{parentName:"tr",align:null},"\u041d\u0430\u0437\u0432\u0430\u043d\u0438\u0435"),(0,r.kt)("th",{parentName:"tr",align:null},"\u041a\u0440\u0438\u0442\u0435\u0440\u0438\u0438"),(0,r.kt)("th",{parentName:"tr",align:null},"\u0427\u0442\u043e \u043f\u0440\u043e\u0438\u0437\u043e\u0439\u0434\u0451\u0442"))),(0,r.kt)("tbody",{parentName:"table"},(0,r.kt)("tr",{parentName:"tbody"},(0,r.kt)("td",{parentName:"tr",align:null},(0,r.kt)("inlineCode",{parentName:"td"},"AutoStacking")),(0,r.kt)("td",{parentName:"tr",align:null},"\u0423 \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u043e\u0432 \u043e\u0434\u0438\u043d\u0430\u043a\u043e\u0432\u043e\u0435 \u043d\u0430\u0437\u0432\u0430\u043d\u0438\u0435"),(0,r.kt)("td",{parentName:"tr",align:null},"\u041e\u043d\u0438 \u0431\u0443\u0434\u0443\u0442 \u043f\u043e\u0434\u0441\u0432\u0435\u0447\u0435\u043d\u044b, \u0438 \u0431\u0443\u0434\u0443\u0447\u0438 \u043e\u0431\u044a\u0435\u0434\u0438\u043d\u0451\u043d\u043d\u044b\u043c\u0438, \u043e\u043d\u0438 \u0431\u0443\u0434\u0443\u0442 \u043e\u0431\u044a\u0435\u0434\u0438\u043d\u0435\u043d\u044b \u0432 \u043e\u0434\u0438\u043d \u043f\u0440\u0435\u0434\u043c\u0435\u0442")),(0,r.kt)("tr",{parentName:"tbody"},(0,r.kt)("td",{parentName:"tr",align:null},(0,r.kt)("inlineCode",{parentName:"td"},"StopOnZero")),(0,r.kt)("td",{parentName:"tr",align:null},"\u041a\u043e\u043b\u0438\u0447\u0435\u0441\u0442\u0432\u043e \u0442\u0435\u043a\u0443\u0449\u0435\u0433\u043e \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u0430 \u0440\u0430\u0432\u043d\u043e 0, \u0438\u043b\u0438 \u043e\u043d \u0431\u043e\u043b\u044c\u0448\u0435 \u043d\u0435 \u043d\u0430\u0445\u043e\u0434\u0438\u0442\u0441\u044f \u0432 \u0438\u043d\u0432\u0435\u043d\u0442\u0430\u0440\u0435"),(0,r.kt)("td",{parentName:"tr",align:null},"\u0412\u0437\u0430\u0438\u043c\u043e\u0434\u0435\u0439\u0441\u0442\u0432\u0438\u0435/\u043e\u0431\u044a\u0435\u0434\u0438\u043d\u0435\u043d\u0438\u0435 \u0431\u0443\u0434\u0435\u0442 \u043e\u0441\u0442\u0430\u043d\u043e\u0432\u043b\u0435\u043d\u043e")))),(0,r.kt)("h3",{id:"iitemtargetable-checks"},"\u041f\u0440\u043e\u0432\u0435\u0440\u043a\u0438 ",(0,r.kt)("inlineCode",{parentName:"h3"},"IItemTargetable")),(0,r.kt)("table",null,(0,r.kt)("thead",{parentName:"table"},(0,r.kt)("tr",{parentName:"thead"},(0,r.kt)("th",{parentName:"tr",align:null},"\u041d\u0430\u0437\u0432\u0430\u043d\u0438\u0435"),(0,r.kt)("th",{parentName:"tr",align:null},"\u041a\u0440\u0438\u0442\u0435\u0440\u0438\u0438"),(0,r.kt)("th",{parentName:"tr",align:null},"\u0427\u0442\u043e \u043f\u0440\u043e\u0438\u0437\u043e\u0439\u0434\u0451\u0442"))),(0,r.kt)("tbody",{parentName:"table"},(0,r.kt)("tr",{parentName:"tbody"},(0,r.kt)("td",{parentName:"tr",align:null},(0,r.kt)("inlineCode",{parentName:"td"},"Distance")),(0,r.kt)("td",{parentName:"tr",align:null},"\u0420\u0430\u0441\u0441\u0442\u043e\u044f\u043d\u0438\u0435 \u043c\u0435\u0436\u0434\u0443 \u0438\u0433\u0440\u043e\u043a\u043e\u043c \u0438 \u0446\u0435\u043b\u044c\u044e \u0431\u043e\u043b\u044c\u0448\u0435 15 \u0435\u0434\u0438\u043d\u0438\u0446"),(0,r.kt)("td",{parentName:"tr",align:null},(0,r.kt)("inlineCode",{parentName:"td"},"false"))),(0,r.kt)("tr",{parentName:"tbody"},(0,r.kt)("td",{parentName:"tr",align:null},(0,r.kt)("inlineCode",{parentName:"td"},"ButlerBot")),(0,r.kt)("td",{parentName:"tr",align:null},"\u0426\u0435\u043b\u044c - \u0420\u043e\u0431\u043e\u0442-\u0434\u0432\u043e\u0440\u0435\u0446\u043a\u0438\u0439"),(0,r.kt)("td",{parentName:"tr",align:null},(0,r.kt)("inlineCode",{parentName:"td"},"false"))),(0,r.kt)("tr",{parentName:"tbody"},(0,r.kt)("td",{parentName:"tr",align:null},(0,r.kt)("inlineCode",{parentName:"td"},"EmptyMech")),(0,r.kt)("td",{parentName:"tr",align:null},"\u0426\u0435\u043b\u044c - \u043f\u0443\u0441\u0442\u043e\u0439 \u041c\u0435\u0445"),(0,r.kt)("td",{parentName:"tr",align:null},(0,r.kt)("inlineCode",{parentName:"td"},"false"))),(0,r.kt)("tr",{parentName:"tbody"},(0,r.kt)("td",{parentName:"tr",align:null},(0,r.kt)("inlineCode",{parentName:"td"},"StopOnZero")),(0,r.kt)("td",{parentName:"tr",align:null},"\u041a\u043e\u043b\u0438\u0447\u0435\u0441\u0442\u0432\u043e \u0442\u0435\u043a\u0443\u0449\u0435\u0433\u043e \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u0430 \u0440\u0430\u0432\u043d\u043e 0, \u0438\u043b\u0438 \u043e\u043d \u0431\u043e\u043b\u044c\u0448\u0435 \u043d\u0435 \u043d\u0430\u0445\u043e\u0434\u0438\u0442\u0441\u044f \u0432 \u0438\u043d\u0432\u0435\u043d\u0442\u0430\u0440\u0435"),(0,r.kt)("td",{parentName:"tr",align:null},"\u0412\u0437\u0430\u0438\u043c\u043e\u0434\u0435\u0439\u0441\u0442\u0432\u0438\u0435/\u043d\u0430\u043f\u0440\u0430\u0432\u043b\u0435\u043d\u0438\u0435 \u0431\u0443\u0434\u0435\u0442 \u043e\u0441\u0442\u0430\u043d\u043e\u0432\u043b\u0435\u043d\u043e")))))}u.isMDXComponent=!0}}]);