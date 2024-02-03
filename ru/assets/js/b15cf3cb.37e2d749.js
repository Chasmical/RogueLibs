"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[7577],{7552:(e,t,r)=>{r.r(t),r.d(t,{assets:()=>c,contentTitle:()=>a,default:()=>p,frontMatter:()=>o,metadata:()=>u,toc:()=>l});var n=r(5893),s=r(1151),i=(r(5878),r(1016),r(4996));const o={},a="\u041a\u0430\u0441\u0442\u043e\u043c\u043d\u044b\u0435 \u0441\u043f\u0440\u0430\u0439\u0442\u044b",u={id:"dev/custom-sprites",title:"\u041a\u0430\u0441\u0442\u043e\u043c\u043d\u044b\u0435 \u0441\u043f\u0440\u0430\u0439\u0442\u044b",description:"\u0414\u043e\u0431\u0430\u0432\u043b\u044f\u0435\u043c \u0441\u043f\u0440\u0430\u0439\u0442\u044b \u043a\u0430\u043a \u0440\u0435\u0441\u0443\u0440\u0441\u044b",source:"@site/i18n/ru/docusaurus-plugin-content-docs/current/dev/custom-sprites.mdx",sourceDirName:"dev",slug:"/dev/custom-sprites",permalink:"/RogueLibs/ru/docs/dev/custom-sprites",draft:!1,unlisted:!1,editUrl:"https://github.com/Chasmical/RogueLibs/edit/main/website/docs/dev/custom-sprites.mdx",tags:[],version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"\u041f\u0440\u043e\u0432\u0430\u0439\u0434\u0435\u0440\u044b \u043a\u0430\u0441\u0442\u043e\u043c\u043d\u044b\u0445 \u0438\u043c\u0451\u043d",permalink:"/RogueLibs/ru/docs/dev/names/name-providers"},next:{title:"\u0414\u043e\u043f\u043e\u043b\u043d\u0438\u0442\u0435\u043b\u044c\u043d\u043e",permalink:"/RogueLibs/ru/docs/dev/extra"}},c={},l=[{value:"\u0414\u043e\u0431\u0430\u0432\u043b\u044f\u0435\u043c \u0441\u043f\u0440\u0430\u0439\u0442\u044b \u043a\u0430\u043a \u0440\u0435\u0441\u0443\u0440\u0441\u044b",id:"sprites-as-resources",level:2},{value:"<code>RogueSprite</code>",id:"roguesprite",level:2},{value:"\u0420\u0430\u0437\u043b\u0438\u0447\u043d\u044b\u0435 \u0441\u043f\u0440\u0430\u0439\u0442\u044b",id:"sprite-variations",level:2}];function d(e){const t={a:"a",admonition:"admonition",code:"code",h1:"h1",h2:"h2",p:"p",pre:"pre",...(0,s.a)(),...e.components};return(0,n.jsxs)(n.Fragment,{children:[(0,n.jsx)(t.h1,{id:"\u043a\u0430\u0441\u0442\u043e\u043c\u043d\u044b\u0435-\u0441\u043f\u0440\u0430\u0439\u0442\u044b",children:"\u041a\u0430\u0441\u0442\u043e\u043c\u043d\u044b\u0435 \u0441\u043f\u0440\u0430\u0439\u0442\u044b"}),"\n","\n","\n",(0,n.jsx)(t.h2,{id:"sprites-as-resources",children:"\u0414\u043e\u0431\u0430\u0432\u043b\u044f\u0435\u043c \u0441\u043f\u0440\u0430\u0439\u0442\u044b \u043a\u0430\u043a \u0440\u0435\u0441\u0443\u0440\u0441\u044b"}),"\n",(0,n.jsx)(t.p,{children:"\u0412\u043e-\u043f\u0435\u0440\u0432\u044b\u0445, \u043a\u043e\u0434\u0438\u0440\u0443\u0439\u0442\u0435 \u0432\u0430\u0448\u0438 \u0438\u0437\u043e\u0431\u0440\u0430\u0436\u0435\u043d\u0438\u044f \u0432 PNG \u0438\u043b\u0438 JPG \u0444\u043e\u0440\u043c\u0430\u0442\u0435, \u0430 \u0430\u0443\u0434\u0438\u043e\u043a\u043b\u0438\u043f\u044b \u0432 MP3, OGG \u0438\u043b\u0438 WAV."}),"\n",(0,n.jsx)(t.p,{children:"\u041f\u043e\u0442\u043e\u043c \u043f\u0435\u0440\u0435\u0439\u0434\u0438\u0442\u0435 \u0432 \u0421\u0432\u043e\u0439\u0441\u0442\u0432\u0430 \u0432\u0430\u0448\u0435\u0433\u043e \u043f\u0440\u043e\u0435\u043a\u0442\u0430 \u0438 \u0441\u043e\u0437\u0434\u0430\u0439\u0442\u0435 \u0444\u0430\u0439\u043b \u0440\u0435\u0441\u0443\u0440\u0441\u043e\u0432, \u0435\u0441\u043b\u0438 \u0435\u0433\u043e \u0442\u0430\u043c \u043d\u0435\u0442\u0443."}),"\n",(0,n.jsx)("img",{src:(0,i.Z)("/img/setup/resources.png"),width:"600"}),"\n",(0,n.jsxs)(t.p,{children:["\u041e\u0442\u043a\u0440\u043e\u0439\u0442\u0435 ",(0,n.jsx)(t.code,{children:"Resources.resx"})," \u0432 \u0432\u0430\u0448\u0435\u043c \u043f\u0440\u043e\u0435\u043a\u0442\u0435 \u0432 \u0441\u0442\u043e\u0440\u043e\u043d\u043d\u0435\u043c \u0440\u0435\u0434\u0430\u043a\u0442\u043e\u0440\u0435 \u0438 \u0434\u043e\u0431\u0430\u0432\u044c\u0442\u0435 \u0441\u043b\u0435\u0434\u0443\u044e\u0449\u0438\u0439 \u044d\u043b\u0435\u043c\u0435\u043d\u0442 \u0432 \u043a\u043e\u043d\u0435\u0446:"]}),"\n",(0,n.jsx)(t.pre,{children:(0,n.jsx)(t.code,{className:"language-xml",children:'  \x3c!-- ... --\x3e\n// highlight-start\n  <data name="MyAwesomeSprite" type="System.Resources.ResXFileRef, System.Windows.Forms">\n    <value>..\\Resources\\MyAwesomeSprite.png;System.Byte[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>\n  </data>\n// highlight-end\n</root>\n'})}),"\n",(0,n.jsxs)(t.p,{children:["\u0412\u0430\u043c \u043d\u0430\u0434\u043e \u0442\u043e\u043b\u044c\u043a\u043e \u0438\u0437\u043c\u0435\u043d\u0438\u0442\u044c \u0430\u0442\u0440\u0438\u0431\u0443\u0442 ",(0,n.jsx)(t.code,{children:"name"})," \u0438 \u043f\u0435\u0440\u0432\u0443\u044e \u0447\u0430\u0441\u0442\u044c \u044d\u043b\u0435\u043c\u0435\u043d\u0442\u0430 ",(0,n.jsx)(t.code,{children:"value"})," \u0434\u043b\u044f \u0432\u0430\u0448\u0438\u0445 \u0440\u0435\u0441\u0443\u0440\u0441\u043e\u0432. \u041f\u043e\u0441\u043b\u0435 \u044d\u0442\u043e\u0433\u043e \u0432\u044b \u0441\u043c\u043e\u0436\u0435\u0442\u0435 \u043e\u0431\u0440\u0430\u0449\u0430\u0442\u044c\u0441\u044f \u043a \u043d\u0438\u043c \u0442\u0430\u043a: ",(0,n.jsx)(t.code,{children:"Properties.Resources.MyAwesomeSprite"}),". \u0412\u044b \u043c\u043e\u0436\u0435\u0442\u0435 \u0434\u0435\u043b\u0430\u0442\u044c \u0442\u043e \u0436\u0435 \u0441\u0430\u043c\u043e\u0435 \u0438 \u0441 \u0434\u0440\u0443\u0433\u0438\u043c\u0438 \u0442\u0438\u043f\u0430\u043c\u0438 \u0444\u0430\u0439\u043b\u043e\u0432, \u043d\u0430\u043f\u0440\u0438\u043c\u0435\u0440 \u0430\u0443\u0434\u0438\u043e\u043a\u043b\u0438\u043f\u0430\u043c\u0438, \u0448\u0440\u0438\u0444\u0442\u0430\u043c\u0438 \u0438 \u043c\u043e\u0434\u0435\u043b\u044f\u043c\u0438."]}),"\n",(0,n.jsxs)(t.p,{children:["\u041f\u043e\u0441\u043b\u0435 \u0438\u0437\u043c\u0435\u043d\u0435\u043d\u0438\u044f ",(0,n.jsx)(t.code,{children:".resx"}),' \u0444\u0430\u0439\u043b\u0430, \u043f\u0435\u0440\u0435\u0439\u0434\u0438\u0442\u0435 \u0432 \u0441\u0432\u043e\u0451 \u0440\u0435\u0448\u0435\u043d\u0438\u0435 \u0438 \u043f\u0435\u0440\u0435\u0441\u0442\u0440\u043e\u0439\u0442\u0435 \u043a\u043e\u0434 \u0440\u0435\u0441\u0443\u0440\u0441\u043e\u0432, \u043d\u0430\u0436\u0430\u0432 \u043f\u0440\u0430\u0432\u043e\u0439 \u043a\u043d\u043e\u043f\u043a\u043e\u0439 \u043f\u043e Resources.resx \u0438 \u0432\u044b\u0431\u0440\u0430\u0432 "Run Custom Tool".']}),"\n",(0,n.jsx)("img",{src:(0,i.Z)("img/custom-sprites/run-custom-tool.png"),width:"400"}),"\n",(0,n.jsx)(t.h2,{id:"roguesprite",children:(0,n.jsx)(t.code,{children:"RogueSprite"})}),"\n",(0,n.jsx)(t.admonition,{type:"note",children:(0,n.jsxs)(t.p,{children:["\u0415\u0441\u043b\u0438 \u0432\u0430\u043c \u0438\u043d\u0442\u0435\u0440\u0435\u0441\u043d\u043e, \u043f\u043e\u0447\u0435\u043c\u0443 \u043e\u043d \u043d\u0430\u0437\u044b\u0432\u0430\u0435\u0442\u0441\u044f ",(0,n.jsx)(t.code,{children:"RogueSprite"}),", \u0430 \u043d\u0435 ",(0,n.jsx)(t.code,{children:"CustomSprite"}),", \u043a\u0430\u043a \u043f\u043e\u0447\u0442\u0438 \u0432\u0441\u0435 \u043e\u0441\u0442\u0430\u043b\u044c\u043d\u044b\u0435 \u0448\u0442\u0443\u043a\u0438 \u0432 RogueLibs (",(0,n.jsx)(t.code,{children:"CustomItem"}),", ",(0,n.jsx)(t.code,{children:"CustomTrait"}),", ",(0,n.jsx)(t.code,{children:"CustomEffect"}),"), \u043d\u0443 \u0447\u0442\u043e \u0436, \u044d\u0442\u043e \u043f\u043e\u0442\u043e\u043c\u0443 \u0447\u0442\u043e \u043e\u043d \u0432\u0435\u0434\u0451\u0442 \u0441\u0435\u0431\u044f \u043d\u0435\u043c\u043d\u043e\u0433\u043e \u043f\u043e-\u0434\u0440\u0443\u0433\u043e\u043c\u0443. ",(0,n.jsx)(t.code,{children:"CustomItem"}),", ",(0,n.jsx)(t.code,{children:"CustomTrait"})," \u0438 \u0434\u0440. - \u0445\u0443\u043a\u0438, \u0432 \u0442\u043e \u0432\u0440\u0435\u043c\u044f \u043a\u0430\u043a ",(0,n.jsx)(t.code,{children:"RogueSprite"}),", \u0442\u0435\u0445\u043d\u0438\u0447\u0435\u0441\u043a\u0438, \u043a\u043e\u043b\u043b\u0435\u043a\u0446\u0438\u044f \u0445\u0443\u043a\u043e\u0432. \u0410 \u0435\u0449\u0451, \u044f \u043f\u043e\u0442\u0440\u0430\u0442\u0438\u043b \u043d\u0435\u0432\u0435\u0440\u043e\u044f\u0442\u043d\u043e\u0435 \u043a\u043e\u043b\u0438\u0447\u0435\u0441\u0442\u0432\u043e \u0432\u0440\u0435\u043c\u0435\u043d\u0438 \u0438 \u0440\u0430\u0431\u043e\u0442\u044b, \u0447\u0442\u043e\u0431\u044b \u0440\u0430\u0437\u043e\u0431\u0440\u0430\u0442\u044c\u0441\u044f \u0432 \u044d\u0442\u043e\u0439 TK2D \u0435\u0440\u0443\u043d\u0434\u0435 \u0438 \u044f \u043f\u0440\u043e\u0441\u0442\u043e \u0445\u043e\u0442\u0435\u043b \u043e\u0442\u043b\u0438\u0447\u0438\u0442\u044c \u0435\u0433\u043e \u043e\u0442 \u0434\u0440\u0443\u0433\u0438\u0445 \u043a\u043b\u0430\u0441\u0441\u043e\u0432."]})}),"\n",(0,n.jsxs)(t.p,{children:["\u041e\u0431\u044b\u0447\u043d\u043e, \u043d\u043e\u0432\u044b\u0435 ",(0,n.jsx)(t.code,{children:"RogueSprite"})," \u0441\u043e\u0437\u0434\u0430\u044e\u0442\u0441\u044f \u0432\u043e\u0442 \u0442\u0430\u043a:"]}),"\n",(0,n.jsx)(t.pre,{children:(0,n.jsx)(t.code,{className:"language-csharp",children:"RogueLibs.CreateCustomItem<MyCustomItem>()\n    ...\n    // highlight-next-line\n    .WithSprite(Properties.Resources.MyCustomItem);\n"})}),"\n",(0,n.jsxs)(t.p,{children:["\u041d\u043e \u0432\u044b \u043c\u043e\u0436\u0435\u0442\u0435 \u0441\u043e\u0437\u0434\u0430\u0442\u044c \u0438\u0445 \u043d\u0430\u043f\u0440\u044f\u043c\u0443\u044e \u0442\u043e\u0436\u0435, \u043d\u043e \u0432 \u0442\u0430\u043a\u043e\u043c \u0441\u043b\u0443\u0447\u0430\u0435 \u0432\u0430\u043c \u043f\u0440\u0438\u0434\u0451\u0442\u0441\u044f \u0443\u043a\u0430\u0437\u0430\u0442\u044c \u043d\u0430\u0437\u0432\u0430\u043d\u0438\u0435 \u0438 \u043e\u0431\u043b\u0430\u0441\u0442\u044c \u0434\u0435\u0439\u0441\u0442\u0432\u0438\u044f. \u041e\u0431\u043b\u0430\u0441\u0442\u044c \u0434\u0435\u0439\u0441\u0442\u0432\u0438\u044f \u0441\u043f\u0440\u0430\u0439\u0442\u0430 \u043e\u043f\u0440\u0435\u0434\u0435\u043b\u044f\u0435\u0442 \u0432 \u043a\u0430\u043a\u0438\u0445 \u043e\u0431\u043b\u0430\u0441\u0442\u044f\u0445 \u0438\u0433\u0440\u044b \u0441\u043f\u0440\u0430\u0439\u0442 \u0431\u0443\u0434\u0435\u0442 \u0434\u043e\u0441\u0442\u0443\u043f\u0435\u043d. ",(0,n.jsx)(t.code,{children:"SpriteScope.Items"})," \u0431\u0443\u0434\u0435\u0442 \u0440\u0430\u0431\u043e\u0442\u0430\u0442\u044c \u0442\u043e\u043b\u044c\u043a\u043e \u043d\u0430 \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u0430\u0445, ",(0,n.jsx)(t.code,{children:"SpriteScope.Objects"})," - \u0442\u043e\u043b\u044c\u043a\u043e \u043d\u0430 \u043e\u0431\u044a\u0435\u043a\u0442\u0430\u0445, \u0438 \u0442.\u0434. \u0412\u044b \u043c\u043e\u0436\u0435\u0442\u0435 \u0443\u043a\u0430\u0437\u0430\u0442\u044c \u043d\u0435\u0441\u043a\u043e\u043b\u044c\u043a\u043e \u043e\u0431\u043b\u0430\u0441\u0442\u0435\u0439 \u0442\u043e\u0436\u0435, \u043e\u0431\u044a\u0435\u0434\u0438\u043d\u0438\u0432 \u0438\u0445 \u0441 \u043f\u043e\u043c\u043e\u0449\u044c\u044e \u043e\u043f\u0435\u0440\u0430\u0442\u043e\u0440\u0430 ",(0,n.jsx)(t.code,{children:"|"}),"."]}),"\n",(0,n.jsx)(t.pre,{children:(0,n.jsx)(t.code,{className:"language-csharp",children:'RogueLibs.CreateCustomSprite("name", SpriteScope.Items, Properties.Resources.ResourceName);\n'})}),"\n",(0,n.jsxs)(t.p,{children:["\u041f\u043e \u0443\u043c\u043e\u043b\u0447\u0430\u043d\u0438\u044e, RogueLibs \u0438\u0441\u043f\u043e\u043b\u044c\u0437\u0443\u0435\u0442 \u0432\u0435\u0441\u044c \u0444\u0430\u0439\u043b \u0434\u043b\u044f \u0442\u0435\u043a\u0441\u0442\u0443\u0440\u044b. \u0412\u044b \u043c\u043e\u0436\u0435\u0442\u0435 \u0443\u043a\u0430\u0437\u0430\u0442\u044c \u043d\u0443\u0436\u043d\u0443\u044e \u043e\u0431\u043b\u0430\u0441\u0442\u044c \u0442\u0435\u043a\u0441\u0442\u0443\u0440\u044b ",(0,n.jsx)(t.code,{children:"Rect"})," \u043f\u0430\u0440\u0430\u043c\u0435\u0442\u0440\u043e\u043c:"]}),"\n",(0,n.jsx)(t.pre,{children:(0,n.jsx)(t.code,{className:"language-csharp",children:'RogueLibs.CreateCustom("name", SpriteScope.Items, Properties.Resources.ResourceName,\n                                // highlight-next-line\n                                new Rect(0f, 0f, 64f, 64f));\n'})}),"\n",(0,n.jsx)("img",{src:(0,i.Z)("img/custom-sprites/coordinate-system.png"),width:"400"}),"\n",(0,n.jsx)(t.p,{children:"\u0415\u0441\u043b\u0438 \u0432\u044b \u0438\u0441\u043f\u043e\u043b\u044c\u0437\u0443\u0435\u0442\u0435 \u0442\u0435\u043a\u0441\u0442\u0443\u0440\u044b \u0440\u0430\u0437\u043c\u0435\u0440\u043e\u043c, \u043e\u0442\u043b\u0438\u0447\u0430\u044e\u0449\u0438\u043c\u0441\u044f \u043e\u0442 64x64, \u0442\u043e \u0432\u0430\u043c \u0442\u0430\u043a\u0436\u0435 \u043d\u0430\u0434\u043e \u0443\u043a\u0430\u0437\u0430\u0442\u044c PPU (pixels-per-unit) \u043f\u0430\u0440\u0430\u043c\u0435\u0442\u0440:"}),"\n",(0,n.jsx)(t.pre,{children:(0,n.jsx)(t.code,{className:"language-csharp",children:'RogueLibs.CreateCustom("name", SpriteScope.Items, Properties.Resources.ResourceName,\n                                // highlight-next-line\n                                new Rect(64f, 64f, 128f, 128f), 128f);\n'})}),"\n",(0,n.jsx)(t.h2,{id:"sprite-variations",children:"\u0420\u0430\u0437\u043b\u0438\u0447\u043d\u044b\u0435 \u0441\u043f\u0440\u0430\u0439\u0442\u044b"}),"\n",(0,n.jsxs)(t.p,{children:["\u0415\u0441\u043b\u0438 \u0443 \u0432\u0430\u0448\u0435\u0433\u043e \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u0430 \u0431\u043e\u043b\u0435\u0435 \u043e\u0434\u043d\u043e\u0433\u043e \u0441\u043f\u0440\u0430\u0439\u0442\u0430, \u0438\u0441\u043f\u043e\u043b\u044c\u0437\u0443\u0439\u0442\u0435 ",(0,n.jsx)(t.code,{children:"InvItem.LoadItemSprite"})," \u0432 ",(0,n.jsx)(t.code,{children:"SetupDetails"})," \u0432\u0430\u0448\u0435\u0433\u043e \u043f\u0440\u0435\u0434\u043c\u0435\u0442\u0430:"]}),"\n",(0,n.jsx)(t.pre,{children:(0,n.jsx)(t.code,{className:"language-csharp",children:'public class Present : CustomItem, IItemUsable\n{\n    [RLSetup]\n    public static void Setup()\n    {\n        RogueLibs.CreateCustomItem<Present>()\n            /* ... */\n            .WithSprite(Properties.Resources.Present);\n\n        RogueLibs.CreateCustomSprite("Present2", SpriteScope.Items, Properties.Resources.Present2);\n        RogueLibs.CreateCustomSprite("Present3", SpriteScope.Items, Properties.Resources.Present3);\n    }\n\n    public override void SetupDetails()\n    {\n        /* ... */\n        int rnd = new Random().Next(3) + 1;\n        // \u0441\u043b\u0443\u0447\u0430\u0439\u043d\u043e\u0435 \u0446\u0435\u043b\u043e\u0435 \u0447\u0438\u0441\u043b\u043e x, \u0442\u0430\u043a\u043e\u0435 \u0447\u0442\u043e 1 \u2264 x \u2264 3\n\n        if (rnd != 1) // \u0437\u0430\u0433\u0440\u0443\u0437\u0438\u0442\u044c \u0434\u0440\u0443\u0433\u043e\u0439 \u0441\u043f\u0440\u0430\u0439\u0442, \u0435\u0441\u043b\u0438 \u044d\u0442\u043e 2 \u0438\u043b\u0438 3\n        Item.LoadItemSprite($"Present{rnd}");\n\n        // \u0435\u0441\u043b\u0438 \u044d\u0442\u043e 1, \u0441\u043f\u0440\u0430\u0439\u0442 "Present" \u0431\u0443\u0434\u0435\u0442 \u0438\u0441\u043f\u043e\u043b\u044c\u0437\u043e\u0432\u0430\u043d \u043f\u043e \u0443\u043c\u043e\u043b\u0447\u0430\u043d\u0438\u044e\n    }\n}\n'})}),"\n",(0,n.jsxs)(t.p,{children:["\u042d\u0442\u043e\u0442 \u043f\u0440\u0438\u043c\u0435\u0440 \u0440\u0430\u0431\u043e\u0442\u0430\u0435\u0442 \u0442\u043e\u043b\u044c\u043a\u043e \u0435\u0441\u043b\u0438 \u043f\u0440\u0435\u0434\u043c\u0435\u0442 \u0434\u0435\u0439\u0441\u0442\u0432\u0438\u0442\u0435\u043b\u044c\u043d\u043e \u0441\u0443\u0449\u0435\u0441\u0442\u0432\u0443\u0435\u0442. \u0412 \u041e\u0431\u0432\u0435\u0441\u0435 \u0438 \u041c\u0435\u043d\u044e \u043d\u0430\u0433\u0440\u0430\u0434 \u0443 \u043d\u0435\u0433\u043e \u0432\u0441\u0435\u0433\u0434\u0430 \u0431\u0443\u0434\u0435\u0442 \u0441\u043f\u0440\u0430\u0439\u0442 ",(0,n.jsx)(t.code,{children:"Present"}),". \u0415\u0441\u043b\u0438 \u0432\u044b \u0445\u043e\u0442\u0438\u0442\u0435 \u0447\u0442\u043e\u0431\u044b \u0441\u043f\u0440\u0430\u0439\u0442 \u0432 \u043c\u0435\u043d\u044e \u0442\u0430\u043a\u0436\u0435 \u0441\u043b\u0443\u0447\u0430\u0439\u043d\u043e \u0432\u044b\u0431\u0438\u0440\u0430\u043b\u0441\u044f, \u0432\u0430\u043c \u043f\u0440\u0438\u0434\u0451\u0442\u0441\u044f ",(0,n.jsxs)(t.a,{href:"./unlocks/configuring-unlocks#examples",children:["\u043f\u0435\u0440\u0435\u0433\u0440\u0443\u0437\u0438\u0442\u044c \u043c\u0435\u0442\u043e\u0434 ",(0,n.jsx)(t.code,{children:"DisplayedUnlock.GetImage"})]}),"."]})]})}function p(e={}){const{wrapper:t}={...(0,s.a)(),...e.components};return t?(0,n.jsx)(t,{...e,children:(0,n.jsx)(d,{...e})}):d(e)}},1016:(e,t,r)=>{r.d(t,{Z:()=>s});r(7294);var n=r(5893);function s(e){let{children:t,...r}=e;return(0,n.jsx)("div",{role:"tabpanel",...r,children:t})}},5878:(e,t,r)=>{r.d(t,{Z:()=>f});var n=r(7294),s=r(6550),i=r(469),o=r(1980),a=r(7392),u=r(12);function c(e){return function(e){return n.Children.toArray(e).filter((e=>"\n"!==e)).map((e=>{if(!e||(0,n.isValidElement)(e)&&function(e){const{props:t}=e;return!!t&&"object"==typeof t&&"value"in t}(e))return e;throw new Error(`Docusaurus error: Bad <Tabs> child <${"string"==typeof e.type?e.type:e.type.name}>: all children of the <Tabs> component should be <TabItem>, and every <TabItem> should have a unique "value" prop.`)}))?.filter(Boolean)??[]}(e).map((e=>{let{props:{value:t,label:r,attributes:n,default:s}}=e;return{value:t,label:r,attributes:n,default:s}}))}function l(e){const{values:t,children:r}=e;return(0,n.useMemo)((()=>{const e=t??c(r);return function(e){const t=(0,a.l)(e,((e,t)=>e.value===t.value));if(t.length>0)throw new Error(`Docusaurus error: Duplicate values "${t.map((e=>e.value)).join(", ")}" found in <Tabs>. Every value needs to be unique.`)}(e),e}),[t,r])}function d(e){let{value:t,tabValues:r}=e;return r.some((e=>e.value===t))}function p(e){let{queryString:t=!1,groupId:r}=e;const i=(0,s.k6)(),a=function(e){let{queryString:t=!1,groupId:r}=e;if("string"==typeof t)return t;if(!1===t)return null;if(!0===t&&!r)throw new Error('Docusaurus error: The <Tabs> component groupId prop is required if queryString=true, because this value is used as the search param name. You can also provide an explicit value such as queryString="my-search-param".');return r??null}({queryString:t,groupId:r});return[(0,o._X)(a),(0,n.useCallback)((e=>{if(!a)return;const t=new URLSearchParams(i.location.search);t.set(a,e),i.replace({...i.location,search:t.toString()})}),[a,i])]}function h(e){const{defaultValue:t,queryString:r=!1,groupId:s}=e,o=l(e),[a,c]=(0,n.useState)((()=>function(e){let{defaultValue:t,tabValues:r}=e;if(0===r.length)throw new Error("Docusaurus error: the <Tabs> component requires at least one <TabItem> children component");if(t){if(!d({value:t,tabValues:r}))throw new Error(`Docusaurus error: The <Tabs> has a defaultValue "${t}" but none of its children has the corresponding value. Available values are: ${r.map((e=>e.value)).join(", ")}. If you intend to show no default tab, use defaultValue={null} instead.`);return t}const n=r.find((e=>e.default))??r[0];if(!n)throw new Error("Unexpected error: 0 tabValues");return n.value}({defaultValue:t,tabValues:o}))),[h,m]=p({queryString:r,groupId:s}),[x,g]=function(e){let{groupId:t}=e;const r=function(e){return e?`docusaurus.tab.${e}`:null}(t),[s,i]=(0,u.Nk)(r);return[s,(0,n.useCallback)((e=>{r&&i.set(e)}),[r,i])]}({groupId:s}),b=(()=>{const e=h??x;return d({value:e,tabValues:o})?e:null})();(0,i.Z)((()=>{b&&c(b)}),[b]);return{selectedValue:a,selectValue:(0,n.useCallback)((e=>{if(!d({value:e,tabValues:o}))throw new Error(`Can't select invalid tab value=${e}`);c(e),m(e),g(e)}),[m,g,o]),tabValues:o}}var m=r(512);const x={tabItem:"tabItem_V91s",tabItemActive:"tabItemActive_JsUu",blink:"blink_ZPVS",tab:"tab_ntnM"};var g=r(5893);const b={left:37,right:39};function f(e){const{lazy:t,defaultValue:r,values:s,groupId:i}=e,o=n.Children.toArray(e.children),{tabValues:a,selectedValue:u,selectValue:c}=h({children:o,defaultValue:r,values:s,groupId:i}),l=[],d=e=>{const t=e.currentTarget,r=s[l.indexOf(t)].value;c(r),null!=i&&setTimeout((()=>{(function(e){const{top:t,left:r,bottom:n,right:s}=e.getBoundingClientRect(),{innerHeight:i,innerWidth:o}=window;return t>=0&&s<=o&&n<=i&&r>=0})(t)||(t.scrollIntoView({block:"center",behavior:"smooth"}),t.classList.add(x.tabItemActive),setTimeout((()=>t.classList.remove(x.tabItemActive)),2e3))}),150)},p=e=>{let t;switch(e.keyCode){case b.right:{const r=l.indexOf(e.target)+1;t=l[r]||l[0];break}case b.left:{const r=l.indexOf(e.target)-1;t=l[r]||l[l.length-1];break}default:return}t.focus()},f=(e,t)=>t.value===e||t.values&&-1!=t.values.indexOf(e);return(0,g.jsxs)("div",{className:"tabs-container",children:[(0,g.jsx)("ul",{role:"tablist","aria-orientation":"horizontal",className:"tabs",children:s.map((e=>{let{value:t,label:r}=e;return(0,g.jsx)("li",{role:"tab",tabIndex:u===t?0:-1,"aria-selected":u===t,className:(0,m.Z)("tabs__item",x.tabItem,{"tabs__item--active":u===t}),ref:e=>e&&l.push(e),onKeyDown:p,onFocus:d,onClick:d,children:r},t)}))}),t?n.cloneElement(o.find((e=>f(u,e.props))),{className:x.tab}):(0,g.jsx)("div",{children:o.map(((e,t)=>n.cloneElement(e,{key:t,hidden:!f(u,e.props),className:x.tab})))}),(0,g.jsx)("br",{})]})}},1151:(e,t,r)=>{r.d(t,{Z:()=>a,a:()=>o});var n=r(7294);const s={},i=n.createContext(s);function o(e){const t=n.useContext(i);return n.useMemo((function(){return"function"==typeof e?e(t):{...t,...e}}),[t,e])}function a(e){let t;return t=e.disableParentContext?"function"==typeof e.components?e.components(s):e.components||s:o(e.components),n.createElement(i.Provider,{value:t},e.children)}}}]);