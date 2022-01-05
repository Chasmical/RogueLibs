"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[7959],{4214:function(e,t,n){n.d(t,{Z:function(){return r}});var a=n(7294),i=n(9055);function r(e){var t=e.children,n=e.language;return a.createElement(i.Z,{className:"language-"+(n||"csharp")},t.replace(/\t/g,"    "))}},1016:function(e,t,n){n.d(t,{Z:function(){return l}});var a=n(7462),i=n(3366),r=n(7294),o=["children"];function l(e){var t=e.children,n=(0,i.Z)(e,o);return r.createElement("div",(0,a.Z)({role:"tabpanel"},n),t)}},2099:function(e,t,n){n.d(t,{Z:function(){return m}});var a=n(7294),i=n(9443);var r=function(){var e=(0,a.useContext)(i.Z);if(null==e)throw new Error('"useUserPreferencesContext" is used outside of "Layout" component.');return e},o=n(6010),l="tabItem_OdQc",s="tabItemActive_YQWB",u="tab_tgHH";var d=37,c=39;function m(e){var t=e.lazy,n=e.defaultValue,i=e.values,m=e.groupId,p=r(),h=p.tabGroupChoices,g=p.setTabGroupChoices,v=(0,a.useState)(n),f=v[0],C=v[1],k=a.Children.toArray(e.children),b=[];if(null!=m){var N=h[m];null!=N&&N!==f&&i.some((function(e){return e.value===N}))&&C(N)}var w=function(e){var t=e.currentTarget,n=b.indexOf(t),a=i[n].value;C(a),null!=m&&(g(m,a),setTimeout((function(){var e,n,a,i,r,o,l,u;(e=t.getBoundingClientRect(),n=e.top,a=e.left,i=e.bottom,r=e.right,o=window,l=o.innerHeight,u=o.innerWidth,n>=0&&r<=u&&i<=l&&a>=0)||(t.scrollIntoView({block:"center",behavior:"smooth"}),t.classList.add(s),setTimeout((function(){return t.classList.remove(s)}),2e3))}),150))},T=function(e){var t;switch(e.keyCode){case c:var n=b.indexOf(e.target)+1;t=b[n]||b[0];break;case d:var a=b.indexOf(e.target)-1;t=b[a]||b[b.length-1];break;default:return}t.focus()},I=function(e,t){return t.value===e||t.values&&-1!=t.values.indexOf(e)};return a.createElement("div",{className:"tabs-container"},a.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:"tabs"},i.map((function(e){var t=e.value,n=e.label;return a.createElement("li",{role:"tab",tabIndex:f===t?0:-1,"aria-selected":f===t,className:(0,o.Z)("tabs__item",l,{"tabs__item--active":f===t}),key:t,ref:function(e){return e&&b.push(e)},onKeyDown:T,onFocus:w,onClick:w},n)}))),t?a.cloneElement(k.find((function(e){return I(f,e.props)})),{className:u}):a.createElement("div",null,k.map((function(e,t){return a.cloneElement(e,{key:t,hidden:!I(f,e.props),className:u})}))),a.createElement("br",null))}},3851:function(e,t,n){n.r(t),n.d(t,{contentTitle:function(){return c},default:function(){return g},frontMatter:function(){return d},metadata:function(){return m},toc:function(){return p}});var a=n(7462),i=n(3366),r=(n(7294),n(3905)),o=n(2099),l=n(1016),s=(n(4996),n(4214)),u=["components"],d={},c="\u041f\u0435\u0440\u0435\u0437\u0430\u0440\u044f\u0436\u0430\u0435\u043c\u044b\u0435 \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u044b",m={unversionedId:"dev/items/recharging-items",id:"dev/items/recharging-items",title:"\u041f\u0435\u0440\u0435\u0437\u0430\u0440\u044f\u0436\u0430\u0435\u043c\u044b\u0435 \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u044b",description:"\u0414\u0435\u043b\u0430\u0435\u043c \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u044b \u043f\u0435\u0440\u0435\u0437\u0430\u0440\u044f\u0436\u0430\u0435\u043c\u044b\u043c\u0438",source:"@site/i18n/ru/docusaurus-plugin-content-docs/current/dev/items/recharging-items.mdx",sourceDirName:"dev/items",slug:"/dev/items/recharging-items",permalink:"/RogueLibs/ru/docs/dev/items/recharging-items",editUrl:"https://github.com/Abbysssal/RogueLibs/edit/main/website/docs/dev/items/recharging-items.mdx",tags:[],version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"\u041d\u0430\u043f\u0440\u0430\u0432\u043b\u044f\u0435\u043c\u044b\u0435 \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u044b +",permalink:"/RogueLibs/ru/docs/dev/items/targetable-items-plus"},next:{title:"\u041e\u0440\u0443\u0436\u0438\u0435 \u0431\u043b\u0438\u0436\u043d\u0435\u0433\u043e \u0431\u043e\u044f*",permalink:"/RogueLibs/ru/docs/dev/items/weapons/melee-weapons"}},p=[{value:"\u0414\u0435\u043b\u0430\u0435\u043c \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u044b \u043f\u0435\u0440\u0435\u0437\u0430\u0440\u044f\u0436\u0430\u0435\u043c\u044b\u043c\u0438",id:"making-rechargeable",children:[],level:2},{value:"\u0428\u0430\u0431\u043b\u043e\u043d\u044b",id:"presets",children:[],level:2},{value:"\u041f\u0440\u0438\u043c\u0435\u0440\u044b",id:"examples",children:[],level:2}],h={toc:p};function g(e){var t=e.components,n=(0,i.Z)(e,u);return(0,r.kt)("wrapper",(0,a.Z)({},h,n,{components:t,mdxType:"MDXLayout"}),(0,r.kt)("h1",{id:"\u043f\u0435\u0440\u0435\u0437\u0430\u0440\u044f\u0436\u0430\u0435\u043c\u044b\u0435-\u043f\u0440\u0435\u0434\u043c\u0435\u0442\u044b"},"\u041f\u0435\u0440\u0435\u0437\u0430\u0440\u044f\u0436\u0430\u0435\u043c\u044b\u0435 \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u044b"),(0,r.kt)("h2",{id:"making-rechargeable"},"\u0414\u0435\u043b\u0430\u0435\u043c \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u044b \u043f\u0435\u0440\u0435\u0437\u0430\u0440\u044f\u0436\u0430\u0435\u043c\u044b\u043c\u0438"),(0,r.kt)("p",null,"\u0415\u0441\u043b\u0438 \u0445\u043e\u0442\u0438\u0442\u0435 \u0441\u0434\u0435\u043b\u0430\u0442\u044c \u043f\u0435\u0440\u0435\u0437\u0430\u0440\u044f\u0436\u0430\u0435\u043c\u044b\u0439 \u043f\u0440\u0435\u0434\u043c\u0435\u0442, \u0432\u043e\u0441\u043f\u043e\u043b\u044c\u0437\u0443\u0439\u0442\u0435\u0441\u044c ",(0,r.kt)("a",{parentName:"p",href:"../extra#update-interfaces"},"\u0438\u043d\u0442\u0435\u0440\u0444\u0435\u0439\u0441\u043e\u043c ",(0,r.kt)("inlineCode",{parentName:"a"},"IDoUpdate")),":"),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyRechargeableItem.cs"',title:'"MyRechargeableItem.cs"'},"// highlight-next-line\npublic class MyRechargeableItem : CustomItem, IDoUpdate\n{\n    /* ... */\n}\n")),(0,r.kt)("h2",{id:"presets"},"\u0428\u0430\u0431\u043b\u043e\u043d\u044b"),(0,r.kt)("p",null,"\u0412\u043e\u0442 \u043f\u0430\u0440\u043e\u0447\u043a\u0430 \u043f\u043e\u043b\u0435\u0437\u043d\u044b\u0445 \u0448\u0430\u0431\u043b\u043e\u043d\u043e\u0432:"),(0,r.kt)(o.Z,{defaultValue:"cooldown",values:[{label:"\u0412\u0440\u0435\u043c\u044f \u0432\u043e\u0441\u0441\u0442\u0430\u043d\u043e\u0432\u043b\u0435\u043d\u0438\u044f",value:"cooldown"},{label:"\u0417\u0430\u0440\u044f\u0434\u043a\u0430",value:"charge"}],mdxType:"Tabs"},(0,r.kt)(l.Z,{value:"cooldown",mdxType:"TabItem"},(0,r.kt)("p",null,(0,r.kt)("inlineCode",{parentName:"p"},"Cooldown")," \u043f\u0440\u0435\u0434\u0441\u0442\u0430\u0432\u043b\u044f\u0435\u0442 \u0438\u0437 \u0441\u0435\u0431\u044f \u043a\u043e\u043b\u0438\u0447\u0435\u0441\u0442\u0432\u043e \u0441\u0435\u043a\u0443\u043d\u0434 \u0434\u043e \u043f\u043e\u043b\u043d\u043e\u0439 \u043f\u0435\u0440\u0435\u0437\u0430\u0440\u044f\u0434\u043a\u0438."),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},"    public float Cooldown { get; private set; }\n    public void Update() => Cooldown = Mathf.Max(Cooldown - Time.deltaTime, 0f);\n")),(0,r.kt)("p",null,"\u0421 \u043d\u0430\u0441\u0442\u0440\u0430\u0438\u0432\u0430\u0435\u043c\u043e\u0439 \u0441\u043a\u043e\u0440\u043e\u0441\u0442\u044c\u044e \u043f\u0435\u0440\u0435\u0437\u0430\u0440\u044f\u0434\u043a\u0438:"),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},"    public float RechargeSpeed = 1f;\n\n    public float Cooldown { get; private set; }\n    public void Update() => Cooldown = Mathf.Max(Cooldown - Time.deltaTime * RechargeSpeed, 0f);\n")),(0,r.kt)("p",null,"\u0418\u0441\u043f\u043e\u043b\u044c\u0437\u043e\u0432\u0430\u043d\u0438\u0435:"),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},"    public bool UseItem()\n    {\n        if (Cooldown != 0f) return false;\n        /* ... */\n        Cooldown = 1.5f;\n        return true;\n    }\n")),(0,r.kt)("div",{className:"admonition admonition-info alert alert--info"},(0,r.kt)("div",{parentName:"div",className:"admonition-heading"},(0,r.kt)("h5",{parentName:"div"},(0,r.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,r.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,r.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M7 2.3c3.14 0 5.7 2.56 5.7 5.7s-2.56 5.7-5.7 5.7A5.71 5.71 0 0 1 1.3 8c0-3.14 2.56-5.7 5.7-5.7zM7 1C3.14 1 0 4.14 0 8s3.14 7 7 7 7-3.14 7-7-3.14-7-7-7zm1 3H6v5h2V4zm0 6H6v2h2v-2z"}))),"info")),(0,r.kt)("div",{parentName:"div",className:"admonition-content"},(0,r.kt)("p",{parentName:"div"},"\u0412\u044b \u043c\u043e\u0436\u0435\u0442\u0435 \u0438\u0441\u043f\u043e\u043b\u044c\u0437\u043e\u0432\u0430\u0442\u044c \u0434\u0440\u0443\u0433\u0438\u0435 \u043c\u0435\u0442\u043e\u0434\u044b \u0430\u043a\u0442\u0438\u0432\u0430\u0446\u0438\u0438 \u0442\u043e\u0436\u0435, \u043d\u0430\u043f\u0440\u0438\u043c\u0435\u0440 ",(0,r.kt)("inlineCode",{parentName:"p"},"CombineItems"),", ",(0,r.kt)("inlineCode",{parentName:"p"},"TargetObject"),", ",(0,r.kt)("inlineCode",{parentName:"p"},"TargetPosition")," \u0438 \u0434\u0440."))),(0,r.kt)("p",null,"\u0415\u0441\u043b\u0438 \u0445\u043e\u0442\u0438\u0442\u0435 \u043e\u0442\u043e\u0431\u0440\u0430\u0436\u0430\u0442\u044c ",(0,r.kt)("inlineCode",{parentName:"p"},"Cooldown")," \u0432\u043c\u0435\u0441\u0442\u043e \u043a\u043e\u043b\u0438\u0447\u0435\u0441\u0442\u0432\u0430 \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u0430, \u0442\u043e \u043f\u0435\u0440\u0435\u0433\u0440\u0443\u0437\u0438\u0442\u0435 \u043c\u0435\u0442\u043e\u0434 ",(0,r.kt)("inlineCode",{parentName:"p"},"GetCountString"),":"),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},"    public override CustomTooltip GetCountString()\n    {\n        if (Cooldown != 0f) return new CustomTooltip(Cooldown, Color.red);\n        return base.GetCountString(); // \u043e\u0442\u043e\u0431\u0440\u0430\u0437\u0438\u0442\u044c \u043a\u043e\u043b\u0438\u0447\u0435\u0441\u0442\u0432\u043e \u043f\u043e \u0443\u043c\u043e\u043b\u0447\u0430\u043d\u0438\u044e\n    }\n"))),(0,r.kt)(l.Z,{value:"charge",mdxType:"TabItem"},(0,r.kt)("p",null,(0,r.kt)("inlineCode",{parentName:"p"},"Charge"),' \u043f\u0440\u0435\u0434\u0441\u0442\u0430\u0432\u043b\u044f\u0435\u0442 \u0438\u0437 \u0441\u0435\u0431\u044f \u043a\u043e\u043b\u0438\u0447\u0435\u0441\u0442\u0432\u043e \u0441\u0435\u043a\u0443\u043d\u0434 "\u043d\u0430\u043a\u043e\u043f\u043b\u0435\u043d\u043d\u043e\u0439 \u044d\u043d\u0435\u0440\u0433\u0438\u0438".'),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},"    public float Charge { get; private set; } = 5f;\n    public void Update() => Charge = Mathf.Min(Charge + Time.deltaTime, 5f);\n")),(0,r.kt)("p",null,"\u0421 \u043d\u0430\u0441\u0442\u0440\u0430\u0438\u0432\u0430\u0435\u043c\u043e\u0439 \u0441\u043a\u043e\u0440\u043e\u0441\u0442\u044c\u044e \u0437\u0430\u0440\u044f\u0434\u043a\u0438 \u0438 \u043c\u0430\u043a\u0441\u0438\u043c\u0430\u043b\u044c\u043d\u044b\u043c \u0437\u0430\u0440\u044f\u0434\u043e\u043c:"),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},"    public float ChargeSpeed = 1f, MaxCharge = 5f;\n\n    public float Charge { get; private set; } = 5f;\n    public void Update() => Charge = Mathf.Min(Charge + Time.deltaTime * ChargeSpeed, MaxCharge);\n")),(0,r.kt)("p",null,"\u041f\u043b\u044e\u0441, \u0441 \u0437\u0430\u0434\u0435\u0440\u0436\u043a\u043e\u0439 \u0437\u0430\u0440\u044f\u0434\u043a\u0438:"),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},"    public float DelayThreshold = 3f, ChargeSpeed = 1f, MaxCharge = 5f;\n\n    private float lastUsage;\n    public float Charge { get; private set; } = 5f;\n    public void Update()\n    {\n        if (lastUsage + DelayThreshold < Time.time)\n            Charge = Mathf.Min(Charge + Time.deltaTime * ChargeSpeed, MaxCharge);\n    }\n")),(0,r.kt)("p",null,"\u0418\u0441\u043f\u043e\u043b\u044c\u0437\u043e\u0432\u0430\u043d\u0438\u0435:"),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},"    public bool UseItem()\n    {\n        if (Charge < 1.5f) return false;\n        /* ... */\n        Charge -= 1.5f;\n        lastUsage = Time.time;\n        return true;\n    }\n")),(0,r.kt)("div",{className:"admonition admonition-info alert alert--info"},(0,r.kt)("div",{parentName:"div",className:"admonition-heading"},(0,r.kt)("h5",{parentName:"div"},(0,r.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,r.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,r.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M7 2.3c3.14 0 5.7 2.56 5.7 5.7s-2.56 5.7-5.7 5.7A5.71 5.71 0 0 1 1.3 8c0-3.14 2.56-5.7 5.7-5.7zM7 1C3.14 1 0 4.14 0 8s3.14 7 7 7 7-3.14 7-7-3.14-7-7-7zm1 3H6v5h2V4zm0 6H6v2h2v-2z"}))),"info")),(0,r.kt)("div",{parentName:"div",className:"admonition-content"},(0,r.kt)("p",{parentName:"div"},"\u0412\u044b \u043c\u043e\u0436\u0435\u0442\u0435 \u0438\u0441\u043f\u043e\u043b\u044c\u0437\u043e\u0432\u0430\u0442\u044c \u0434\u0440\u0443\u0433\u0438\u0435 \u043c\u0435\u0442\u043e\u0434\u044b \u0430\u043a\u0442\u0438\u0432\u0430\u0446\u0438\u0438 \u0442\u043e\u0436\u0435, \u043d\u0430\u043f\u0440\u0438\u043c\u0435\u0440 ",(0,r.kt)("inlineCode",{parentName:"p"},"CombineItems"),", ",(0,r.kt)("inlineCode",{parentName:"p"},"TargetObject"),", ",(0,r.kt)("inlineCode",{parentName:"p"},"TargetPosition")," \u0438 \u0434\u0440."))),(0,r.kt)("p",null,"\u0415\u0441\u043b\u0438 \u0445\u043e\u0442\u0438\u0442\u0435 \u043e\u0442\u043e\u0431\u0440\u0430\u0436\u0430\u0442\u044c ",(0,r.kt)("inlineCode",{parentName:"p"},"Charge")," \u0432\u043c\u0435\u0441\u0442\u043e \u043a\u043e\u043b\u0438\u0447\u0435\u0441\u0442\u0432\u0430 \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u0430, \u0442\u043e \u043f\u0435\u0440\u0435\u0433\u0440\u0443\u0437\u0438\u0442\u0435 \u043c\u0435\u0442\u043e\u0434 ",(0,r.kt)("inlineCode",{parentName:"p"},"GetCountString"),":"),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},'    public override CustomTooltip GetCountString()\n    {\n        string text = $"{Charge} ({base.GetCountString()})"; // display both charge and count\n        Color color = Color.Lerp(Color.red, Color.white, Charge / MaxCharge);\n        // color between red and white: red - no charge, white - full charge\n        return new CustomTooltip(text, color);\n    }\n')))),(0,r.kt)("div",{className:"admonition admonition-note alert alert--secondary"},(0,r.kt)("div",{parentName:"div",className:"admonition-heading"},(0,r.kt)("h5",{parentName:"div"},(0,r.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,r.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,r.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.3 5.69a.942.942 0 0 1-.28-.7c0-.28.09-.52.28-.7.19-.18.42-.28.7-.28.28 0 .52.09.7.28.18.19.28.42.28.7 0 .28-.09.52-.28.7a1 1 0 0 1-.7.3c-.28 0-.52-.11-.7-.3zM8 7.99c-.02-.25-.11-.48-.31-.69-.2-.19-.42-.3-.69-.31H6c-.27.02-.48.13-.69.31-.2.2-.3.44-.31.69h1v3c.02.27.11.5.31.69.2.2.42.31.69.31h1c.27 0 .48-.11.69-.31.2-.19.3-.42.31-.69H8V7.98v.01zM7 2.3c-3.14 0-5.7 2.54-5.7 5.68 0 3.14 2.56 5.7 5.7 5.7s5.7-2.55 5.7-5.7c0-3.15-2.56-5.69-5.7-5.69v.01zM7 .98c3.86 0 7 3.14 7 7s-3.14 7-7 7-7-3.12-7-7 3.14-7 7-7z"}))),"note")),(0,r.kt)("div",{parentName:"div",className:"admonition-content"},(0,r.kt)("p",{parentName:"div"},"\u0422\u0430\u043a\u0436\u0435 \u0441\u0443\u0449\u0435\u0441\u0442\u0432\u0443\u0435\u0442 \u0432\u0430\u043d\u0438\u043b\u044c\u043d\u044b\u0439 \u0441\u043f\u043e\u0441\u043e\u0431 \u043f\u0435\u0440\u0435\u0437\u0430\u0440\u044f\u0434\u043a\u0438, \u043d\u043e \u043e\u043d \u043a\u0440\u0430\u0439\u043d\u0435 \u043d\u0435\u043b\u043e\u0433\u0438\u0447\u043d\u044b\u0439 \u0438 \u043d\u0435\u043d\u0430\u0434\u0451\u0436\u043d\u044b\u0439."))),(0,r.kt)("h2",{id:"examples"},"\u041f\u0440\u0438\u043c\u0435\u0440\u044b"),(0,r.kt)(o.Z,{defaultValue:"quantumfud",values:[{label:"Quantum Fud",value:"quantumfud"}],mdxType:"Tabs"},(0,r.kt)(l.Z,{value:"quantumfud",mdxType:"TabItem"},(0,r.kt)(s.Z,{mdxType:"CodeSnippet"},'using UnityEngine;\n\nnamespace RogueLibsCore.Test\n{\n\t[ItemCategories(RogueCategories.Food, RogueCategories.Technology)]\n\tpublic class QuantumFud : CustomItem, IItemUsable, IDoUpdate\n\t{\n\t\t[RLSetup]\n\t\tpublic static void Setup()\n\t\t{\n\t\t\tRogueLibs.CreateCustomItem<QuantumFud>()\n\t\t\t\t.WithName(new CustomNameInfo("Quantum Fud"))\n\t\t\t\t.WithDescription(new CustomNameInfo("A very complicated piece of quantum technology. When you eat it, its quantum equivalent clone is consumed, while the original thing remains intact."))\n\t\t\t\t.WithSprite(Properties.Resources.QuantumFud)\n\t\t\t\t.WithUnlock(new ItemUnlock\n\t\t\t\t{\n\t\t\t\t\tUnlockCost = 10,\n\t\t\t\t\tLoadoutCost = 15,\n\t\t\t\t\tCharacterCreationCost = 10,\n\t\t\t\t   Prerequisites = { VanillaItems.FoodProcessor },\n\t\t\t\t});\n\t\t}\n\n\t\tpublic override void SetupDetails()\n\t\t{\n\t\t\tItem.itemType = ItemTypes.Food;\n\t\t\tItem.itemValue = 180;\n\t\t\tItem.healthChange = 1;\n\t\t\tItem.cantBeCloned = true;\n\t\t\tItem.goesInToolbar = true;\n\t\t}\n\n\t\tpublic float Cooldown { get; set; }\n\t\tpublic void Update() => Cooldown = Mathf.Max(Cooldown - Time.deltaTime, 0f);\n\n\t\tpublic bool UseItem()\n\t\t{\n\t\t\tif (Cooldown != 0f) return false;\n\n\t\t\tint heal = new ItemFunctions().DetermineHealthChange(Item, Owner);\n\t\t\tOwner.statusEffects.ChangeHealth(heal);\n\n\t\t\tif (Owner.HasTrait(VanillaTraits.ShareTheHealth)\n\t\t\t\t|| Owner.HasTrait(VanillaTraits.ShareTheHealth2))\n\t\t\t\tnew ItemFunctions().GiveFollowersHealth(Owner, heal);\n\n\t\t\tgc.audioHandler.Play(Owner, VanillaAudio.UseFood);\n\t\t\tCooldown = 0.5f;\n\t\t\treturn true;\n\t\t}\n\t}\n}\n'))))}g.isMDXComponent=!0}}]);