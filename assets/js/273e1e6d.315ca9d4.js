"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[4798],{3905:function(e,t,n){n.d(t,{Zo:function(){return u},kt:function(){return m}});var a=n(7294);function o(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function r(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var a=Object.getOwnPropertySymbols(e);t&&(a=a.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,a)}return n}function i(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?r(Object(n),!0).forEach((function(t){o(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):r(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function s(e,t){if(null==e)return{};var n,a,o=function(e,t){if(null==e)return{};var n,a,o={},r=Object.keys(e);for(a=0;a<r.length;a++)n=r[a],t.indexOf(n)>=0||(o[n]=e[n]);return o}(e,t);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(e);for(a=0;a<r.length;a++)n=r[a],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(o[n]=e[n])}return o}var l=a.createContext({}),c=function(e){var t=a.useContext(l),n=t;return e&&(n="function"==typeof e?e(t):i(i({},t),e)),n},u=function(e){var t=c(e.components);return a.createElement(l.Provider,{value:t},e.children)},p={inlineCode:"code",wrapper:function(e){var t=e.children;return a.createElement(a.Fragment,{},t)}},d=a.forwardRef((function(e,t){var n=e.components,o=e.mdxType,r=e.originalType,l=e.parentName,u=s(e,["components","mdxType","originalType","parentName"]),d=c(n),m=o,h=d["".concat(l,".").concat(m)]||d[m]||p[m]||r;return n?a.createElement(h,i(i({ref:t},u),{},{components:n})):a.createElement(h,i({ref:t},u))}));function m(e,t){var n=arguments,o=t&&t.mdxType;if("string"==typeof e||o){var r=n.length,i=new Array(r);i[0]=d;var s={};for(var l in t)hasOwnProperty.call(t,l)&&(s[l]=t[l]);s.originalType=e,s.mdxType="string"==typeof e?e:o,i[1]=s;for(var c=2;c<r;c++)i[c]=n[c];return a.createElement.apply(null,i)}return a.createElement.apply(null,n)}d.displayName="MDXCreateElement"},1016:function(e,t,n){n.d(t,{Z:function(){return s}});var a=n(7462),o=n(3366),r=n(7294),i=["children"];function s(e){var t=e.children,n=(0,o.Z)(e,i);return r.createElement("div",(0,a.Z)({role:"tabpanel"},n),t)}},2099:function(e,t,n){n.d(t,{Z:function(){return d}});var a=n(7294),o=n(9443);var r=function(){var e=(0,a.useContext)(o.Z);if(null==e)throw new Error('"useUserPreferencesContext" is used outside of "Layout" component.');return e},i=n(6010),s="tabItem_OdQc",l="tabItemActive_YQWB",c="tab_tgHH";var u=37,p=39;function d(e){var t=e.lazy,n=e.defaultValue,o=e.values,d=e.groupId,m=r(),h=m.tabGroupChoices,f=m.setTabGroupChoices,g=(0,a.useState)(n),y=g[0],v=g[1],b=a.Children.toArray(e.children),k=[];if(null!=d){var C=h[d];null!=C&&C!==y&&o.some((function(e){return e.value===C}))&&v(C)}var I=function(e){var t=e.currentTarget,n=k.indexOf(t),a=o[n].value;v(a),null!=d&&(f(d,a),setTimeout((function(){var e,n,a,o,r,i,s,c;(e=t.getBoundingClientRect(),n=e.top,a=e.left,o=e.bottom,r=e.right,i=window,s=i.innerHeight,c=i.innerWidth,n>=0&&r<=c&&o<=s&&a>=0)||(t.scrollIntoView({block:"center",behavior:"smooth"}),t.classList.add(l),setTimeout((function(){return t.classList.remove(l)}),2e3))}),150))},w=function(e){var t;switch(e.keyCode){case p:var n=k.indexOf(e.target)+1;t=k[n]||k[0];break;case u:var a=k.indexOf(e.target)-1;t=k[a]||k[k.length-1];break;default:return}t.focus()},N=function(e,t){return t.value===e||t.values&&-1!=t.values.indexOf(e)};return a.createElement("div",{className:"tabs-container"},a.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:"tabs"},o.map((function(e){var t=e.value,n=e.label;return a.createElement("li",{role:"tab",tabIndex:y===t?0:-1,"aria-selected":y===t,className:(0,i.Z)("tabs__item",s,{"tabs__item--active":y===t}),key:t,ref:function(e){return e&&k.push(e)},onKeyDown:w,onFocus:I,onClick:I},n)}))),t?a.cloneElement(b.find((function(e){return N(y,e.props)})),{className:c}):a.createElement("div",null,b.map((function(e,t){return a.cloneElement(e,{key:t,hidden:!N(y,e.props),className:c})}))),a.createElement("br",null))}},5792:function(e,t,n){n.r(t),n.d(t,{frontMatter:function(){return c},contentTitle:function(){return u},metadata:function(){return p},toc:function(){return d},default:function(){return h}});var a=n(7462),o=n(3366),r=(n(7294),n(3905)),i=n(2099),s=n(1016),l=(n(4996),["components"]),c={},u="Patching Utilities",p={unversionedId:"dev/patching-utilities",id:"dev/patching-utilities",title:"Patching Utilities",description:"RLSetup attribute",source:"@site/docs/dev/patching-utilities.mdx",sourceDirName:"dev",slug:"/dev/patching-utilities",permalink:"/RogueLibs/docs/dev/patching-utilities",editUrl:"https://github.com/Abbysssal/RogueLibs/edit/main/website/docs/dev/patching-utilities.mdx",tags:[],version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"Extra Stuff",permalink:"/RogueLibs/docs/dev/extra"},next:{title:"Hooks",permalink:"/RogueLibs/docs/dev/hooks/"}},d=[{value:"<code>RLSetup</code> attribute",id:"rlsetup",children:[],level:2},{value:"<code>RoguePatcher</code>",id:"roguepatcher",children:[],level:2},{value:"Transpiler helper methods",id:"transpiler-helper-methods",children:[],level:2}],m={toc:d};function h(e){var t=e.components,n=(0,o.Z)(e,l);return(0,r.kt)("wrapper",(0,a.Z)({},m,n,{components:t,mdxType:"MDXLayout"}),(0,r.kt)("h1",{id:"patching-utilities"},"Patching Utilities"),(0,r.kt)("h2",{id:"rlsetup"},(0,r.kt)("inlineCode",{parentName:"h2"},"RLSetup")," attribute"),(0,r.kt)("p",null,"Since RogueLibs handles custom stuff as classes, you might forget to initialize a new class in your plugin's ",(0,r.kt)("inlineCode",{parentName:"p"},"Awake"),". That's why ",(0,r.kt)("inlineCode",{parentName:"p"},"RLSetup")," attribute is here. You can just add it to a static method, and initialize your custom thing in there."),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyCustomItem.cs"',title:'"MyCustomItem.cs"'},'public class MyCustomItem : CustomItem\n{\n    // highlight-start\n    [RLSetup]\n    public static void Setup()\n    // highlight-end\n    {\n        RogueLibs.CreateCustomItem<MyCustomItem>()\n            .WithName(new CustomNameInfo("Name"))\n            .WithDescription(new CustomNameInfo("Description"))\n            .WithSprite(Properties.Resources.Sprite)\n            .WithUnlock(new ItemUnlock());\n        \n        RogueLibs.CreateCustomName("SomeName", "Dialogue", new CustomNameInfo("Text"));\n    }\n}\n')),(0,r.kt)("p",null,"You'll just have to call the following method in your plugin's ",(0,r.kt)("inlineCode",{parentName:"p"},"Awake"),":"),(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp",metastring:'title="MyCoolPlugin.cs"',title:'"MyCoolPlugin.cs"'},"    public void Awake()\n    {\n        // highlight-next-line\n        RogueLibs.LoadFromAssembly();\n        /* ... */\n    }\n")),(0,r.kt)("div",{className:"admonition admonition-tip alert alert--success"},(0,r.kt)("div",{parentName:"div",className:"admonition-heading"},(0,r.kt)("h5",{parentName:"div"},(0,r.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,r.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"12",height:"16",viewBox:"0 0 12 16"},(0,r.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.5 0C3.48 0 1 2.19 1 5c0 .92.55 2.25 1 3 1.34 2.25 1.78 2.78 2 4v1h5v-1c.22-1.22.66-1.75 2-4 .45-.75 1-2.08 1-3 0-2.81-2.48-5-5.5-5zm3.64 7.48c-.25.44-.47.8-.67 1.11-.86 1.41-1.25 2.06-1.45 3.23-.02.05-.02.11-.02.17H5c0-.06 0-.13-.02-.17-.2-1.17-.59-1.83-1.45-3.23-.2-.31-.42-.67-.67-1.11C2.44 6.78 2 5.65 2 5c0-2.2 2.02-4 4.5-4 1.22 0 2.36.42 3.22 1.19C10.55 2.94 11 3.94 11 5c0 .66-.44 1.78-.86 2.48zM4 14h5c-.23 1.14-1.3 2-2.5 2s-2.27-.86-2.5-2z"}))),"Pro-tip")),(0,r.kt)("div",{parentName:"div",className:"admonition-content"},(0,r.kt)("p",{parentName:"div"},"Seriously, you should use it. It helps with versioning too. All of the logic in one place."))),(0,r.kt)("h2",{id:"roguepatcher"},(0,r.kt)("inlineCode",{parentName:"h2"},"RoguePatcher")),(0,r.kt)("p",null,(0,r.kt)("inlineCode",{parentName:"p"},"RoguePatcher")," is a small helper class that makes writing patches a little bit faster and easier. If you need more control (patch order, priority, etc.), then you should use the original Harmony methods."),(0,r.kt)(i.Z,{defaultValue:"roguepatcher",values:[{label:"RoguePatcher",value:"roguepatcher"},{label:"Harmony",value:"harmony"}],mdxType:"Tabs"},(0,r.kt)(s.Z,{value:"roguepatcher",mdxType:"TabItem"},(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},"RoguePatcher patcher = new RoguePatcher(this);\n\npatcher.Postfix(typeof(StatusEffects), nameof(StatusEffects.hasStatusEffect));\n\npatcher.Postfix(typeof(InvDatabase), nameof(InvDatabase.ChooseArmor), new Type[1] { typeof(string) });\n"))),(0,r.kt)(s.Z,{value:"harmony",mdxType:"TabItem"},(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},"Harmony harmony = new Harmony(pluginGUID);\n\nMethodInfo original = AccessTools.Method(typeof(StatusEffects), nameof(StatusEffects.hasStatusEffect));\nMethodInfo patch = AccessTools.Method(GetType(), nameof(MyPatchMethod));\nharmony.Patch(original, new HarmonyMethod(patch));\n\noriginal = AccessTools.Method(typeof(InvDatabase), nameof(InvDatabase.ChooseArmor), new Type[1] { typeof(string) });\npatch = AccessTools.Method(GetType(), nameof(MyPatchMethod2));\nharmony.Patch(original, new HarmonyMethod(patch));\n")))),(0,r.kt)("div",{className:"admonition admonition-tip alert alert--success"},(0,r.kt)("div",{parentName:"div",className:"admonition-heading"},(0,r.kt)("h5",{parentName:"div"},(0,r.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,r.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"12",height:"16",viewBox:"0 0 12 16"},(0,r.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.5 0C3.48 0 1 2.19 1 5c0 .92.55 2.25 1 3 1.34 2.25 1.78 2.78 2 4v1h5v-1c.22-1.22.66-1.75 2-4 .45-.75 1-2.08 1-3 0-2.81-2.48-5-5.5-5zm3.64 7.48c-.25.44-.47.8-.67 1.11-.86 1.41-1.25 2.06-1.45 3.23-.02.05-.02.11-.02.17H5c0-.06 0-.13-.02-.17-.2-1.17-.59-1.83-1.45-3.23-.2-.31-.42-.67-.67-1.11C2.44 6.78 2 5.65 2 5c0-2.2 2.02-4 4.5-4 1.22 0 2.36.42 3.22 1.19C10.55 2.94 11 3.94 11 5c0 .66-.44 1.78-.86 2.48zM4 14h5c-.23 1.14-1.3 2-2.5 2s-2.27-.86-2.5-2z"}))),"Pro-tip")),(0,r.kt)("div",{parentName:"div",className:"admonition-content"},(0,r.kt)("p",{parentName:"div"},"Instead of specifying method names using strings, you should specify them using the ",(0,r.kt)("inlineCode",{parentName:"p"},"nameof")," keyword. Use string names only if the method you're trying to patch is not public."))),(0,r.kt)("p",null,"Patch methods should have the following name: ",(0,r.kt)("inlineCode",{parentName:"p"},"<TargetType>_<TargetMethod>"),". In the example above, ",(0,r.kt)("inlineCode",{parentName:"p"},"RoguePatcher")," will search for patch methods called ",(0,r.kt)("inlineCode",{parentName:"p"},"StatusEffects_hasStatusEffect")," and ",(0,r.kt)("inlineCode",{parentName:"p"},"InvDatabase_ChooseArmor")," in your plugin's class."),(0,r.kt)("p",null,"You can change the type to search patch methods in. Specify it in the constructor or set the property between patches:"),(0,r.kt)(i.Z,{defaultValue:"roguepatcher",values:[{label:"RoguePatcher",value:"roguepatcher"},{label:"Harmony",value:"harmony"}],mdxType:"Tabs"},(0,r.kt)(s.Z,{value:"roguepatcher",mdxType:"TabItem"},(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},"public class MyCoolPlugin : BaseUnityPlugin\n{\n    public void Awake()\n    {\n        // highlight-next-line\n        RoguePatcher patcher = new RoguePatcher(this, typeof(MyCoolPatches));\n\n        patcher.Postfix(typeof(StatusEffects), nameof(StatusEffects.hasStatusEffect));\n\n        // highlight-next-line\n        patcher.TypeWithPatches = typeof(MyEvenCoolerPatches);\n\n        patcher.Postfix(typeof(InvDatabase), nameof(InvDatabase.ChooseArmor), new Type[1] { typeof(string) });\n    }\n}\npublic class MyCoolPatches\n{\n    public static void StatusEffects_hasStatusEffect(StatusEffects __instance)\n    {\n        /* ... */\n    }\n}\npublic class MyEvenCoolerPatches\n{\n    public static void InvDatabase_ChooseArmor(InvDatabase __instance, string previousArmorName)\n    {\n        /* ... */\n    }\n}\n"))),(0,r.kt)(s.Z,{value:"harmony",mdxType:"TabItem"},(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},"public class MyCoolPlugin : BaseUnityPlugin\n{\n    public void Awake()\n    {\n        Harmony harmony = new Harmony(pluginGUID);\n\n        MethodInfo original = AccessTools.Method(typeof(StatusEffects), nameof(StatusEffects.hasStatusEffect));\n        MethodInfo patch = AccessTools.Method(typeof(MyCoolPatches), nameof(MyPatchMethod));\n        harmony.Patch(original, new HarmonyMethod(patch));\n\n        original = AccessTools.Method(typeof(InvDatabase), nameof(InvDatabase.ChooseArmor), new Type[1] { typeof(string) });\n        patch = AccessTools.Method(typeof(MyEvenCoolerPatches), nameof(MyPatchMethod2));\n        harmony.Patch(original, new HarmonyMethod(patch));\n    }\n}\npublic class MyCoolPatches\n{\n    public static void MyPatchMethod(StatusEffects __instance)\n    {\n        /* ... */\n    }\n}\npublic class MyEvenCoolerPatches\n{\n    public static void MyPatchMethod2(InvDatabase __instance, string previousArmorName)\n    {\n        /* ... */\n    }\n}\n")))),(0,r.kt)("h2",{id:"transpiler-helper-methods"},"Transpiler helper methods"),(0,r.kt)("p",null,"Transpilers are kind of complicated."),(0,r.kt)("p",null,"Here's an example from RogueLibs:"),(0,r.kt)(i.Z,{defaultValue:"helper",values:[{label:"Helper methods",value:"helper"},{label:"Harmony",value:"harmony"}],mdxType:"Tabs"},(0,r.kt)(s.Z,{value:"helper",mdxType:"TabItem"},(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},"public static IEnumerable<CodeInstruction> StatusEffects_AddStatusEffect(IEnumerable<CodeInstruction> codeEnumerable)\n    => codeEnumerable.AddRegionAfter(\n        new Func<CodeInstruction, bool>[]\n        {\n            i => i.IsLdloc(),\n            i => i.opcode == OpCodes.Ldarg_3,\n            i => i.opcode == OpCodes.Stfld && i.StoresField(causingAgentField),\n        },\n        new Func<CodeInstruction[], CodeInstruction>[]\n        {\n            a => a[0],\n            _ => new CodeInstruction(OpCodes.Ldarg_0),\n            _ => new CodeInstruction(OpCodes.Call, typeof(RogueLibsPlugin).GetMethod(nameof(SetupEffectHook))),\n        });\n\nprivate static readonly FieldInfo causingAgentField = typeof(StatusEffect).GetField(nameof(StatusEffect.causingAgent));\n"))),(0,r.kt)(s.Z,{value:"harmony",mdxType:"TabItem"},(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},"public static IEnumerable<CodeInstruction> StatusEffects_AddStatusEffect(IEnumerable<CodeInstruction> code)\n{\n    bool searching = true;\n    int current = 0;\n    CodeInstruction[] matches = new CodeInstruction[after.Length];\n    foreach (CodeInstruction instr in code)\n    {\n        yield return instr;\n        if (searching)\n        {\n            if (current is 0 ? instr.IsLdloc()\n                : current is 1 ? instr.opcode == OpCodes.Ldarg_3\n                : instr.opcode == OpCodes.Stfld && instr.StoresField(causingAgentField))\n            {\n                matches[current] = instr;\n                if (++current is 3)\n                {\n                    searching = false;\n                    yield return matches[0];\n                    yield return new CodeInstruction(OpCodes.Ldarg_0);\n                    yield return new CodeInstruction(OpCodes.Call, typeof(RogueLibsPlugin).GetMethod(nameof(SetupEffectHook)));\n                }\n            }\n            else current = 0;\n        }\n    }\n}\n\nprivate static readonly FieldInfo causingAgentField = typeof(StatusEffect).GetField(nameof(StatusEffect.causingAgent));\n")),(0,r.kt)("p",null,"Yeah, it looks easy. But that's only because it's a very simple example."))),(0,r.kt)("div",{className:"admonition admonition-tip alert alert--success"},(0,r.kt)("div",{parentName:"div",className:"admonition-heading"},(0,r.kt)("h5",{parentName:"div"},(0,r.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,r.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"12",height:"16",viewBox:"0 0 12 16"},(0,r.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M6.5 0C3.48 0 1 2.19 1 5c0 .92.55 2.25 1 3 1.34 2.25 1.78 2.78 2 4v1h5v-1c.22-1.22.66-1.75 2-4 .45-.75 1-2.08 1-3 0-2.81-2.48-5-5.5-5zm3.64 7.48c-.25.44-.47.8-.67 1.11-.86 1.41-1.25 2.06-1.45 3.23-.02.05-.02.11-.02.17H5c0-.06 0-.13-.02-.17-.2-1.17-.59-1.83-1.45-3.23-.2-.31-.42-.67-.67-1.11C2.44 6.78 2 5.65 2 5c0-2.2 2.02-4 4.5-4 1.22 0 2.36.42 3.22 1.19C10.55 2.94 11 3.94 11 5c0 .66-.44 1.78-.86 2.48zM4 14h5c-.23 1.14-1.3 2-2.5 2s-2.27-.86-2.5-2z"}))),"Avoid heavy calculations")),(0,r.kt)("div",{parentName:"div",className:"admonition-content"},(0,r.kt)("p",{parentName:"div"},"When writing predicates, keep in mind that they might get called hundreds or thousands of times. For example, you can pre-calculate the ",(0,r.kt)("inlineCode",{parentName:"p"},"FieldInfo")," value, used by your predicate, just put it in a static readonly field, like in the example above."),(0,r.kt)("p",{parentName:"div"},"Heavy calculations like that can cost you ",(0,r.kt)("strong",{parentName:"p"},"hundreds of milliseconds")," of start-up time (or even entire seconds, if you're working on a big project)."))),(0,r.kt)("p",null,"Here's another example from RogueLibs:"),(0,r.kt)(i.Z,{defaultValue:"helper",values:[{label:"Helper methods",value:"helper"},{label:"Harmony",value:"harmony"}],mdxType:"Tabs"},(0,r.kt)(s.Z,{value:"helper",mdxType:"TabItem"},(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},'public static IEnumerable<CodeInstruction> Unlocks_LoadInitialUnlocks(IEnumerable<CodeInstruction> codeEnumerable)\n    => codeEnumerable.ReplaceRegion(\n        new Func<CodeInstruction, bool>[]\n        {\n            i => i.opcode == OpCodes.Callvirt && i.Calls(List_Unlock_GetEnumerator),\n            i => i.IsStloc(),\n        },\n        new Func<CodeInstruction, bool>[]\n        {\n            i => i.opcode == OpCodes.Callvirt,\n            i => i.opcode == OpCodes.Endfinally,\n            i => i.opcode == OpCodes.Ldarg_0,\n        },\n        new CodeInstruction[]\n        {\n            new CodeInstruction(OpCodes.Pop),\n            new CodeInstruction(OpCodes.Pop),\n            new CodeInstruction(OpCodes.Call, typeof(RogueLibsPlugin).GetMethod(nameof(LoadUnlockWrappersAndCategorize)))\n        });\n\nprivate static readonly MethodInfo List_Unlock_GetEnumerator = typeof(List<Unlock>).GetMethod("GetEnumerator");\n'))),(0,r.kt)(s.Z,{value:"harmony",mdxType:"TabItem"},(0,r.kt)("pre",null,(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},'public static IEnumerable<CodeInstruction> Unlocks_LoadInitialUnlocks(IEnumerable<CodeInstruction> code)\n{\n    int state = 0;\n    int current = 0;\n    CodeInstruction[] beginCache = new CodeInstruction[2];\n    foreach (CodeInstruction instr in code)\n    {\n        if (state is 2)\n            yield return instr;\n        else if (state is 0)\n        {\n            if (current is 0 ? instr.opcode == OpCodes.Callvirt && instr.Calls(List_Unlock_GetEnumerator)\n                : instr.IsStloc())\n            {\n                beginCache[current] = instr;\n                if (++current == 2)\n                {\n                    state = 1;\n                    current = 0;\n                }\n            }\n            else\n            {\n                if (current > 0)\n                {\n                    for (int i = 0; i < current; i++)\n                        yield return beginCache[i];\n                    current = 0;\n                }\n                yield return instr;\n            }\n        }\n        else\n        {\n            if (current is 0 ? instr.opcode == OpCodes.Callvirt\n                : current is 1 ? instr.opcode == OpCodes.Endfinally\n                : instr.opcode == OpCodes.Ldarg_0)\n            {\n                if (++current == 3)\n                {\n                    yield return new CodeInstruction(OpCodes.Pop);\n                    yield return new CodeInstruction(OpCodes.Pop);\n                    yield return new CodeInstruction(OpCodes.Call, typeof(RogueLibsPlugin).GetMethod(nameof(LoadUnlockWrappersAndCategorize)));\n                }\n            }\n            else current = 0;\n        }\n    }\n}\n\nprivate static readonly MethodInfo List_Unlock_GetEnumerator = typeof(List<Unlock>).GetMethod("GetEnumerator");\n')),(0,r.kt)("p",null,"Still relatively simple. I just don't want to spend my time writing a really complicated example."))))}h.isMDXComponent=!0}}]);