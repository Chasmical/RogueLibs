(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[9257],{3905:(e,t,n)=>{"use strict";n.d(t,{Zo:()=>u,kt:()=>d});var o=n(7294);function r(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function c(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var o=Object.getOwnPropertySymbols(e);t&&(o=o.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,o)}return n}function a(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?c(Object(n),!0).forEach((function(t){r(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):c(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function l(e,t){if(null==e)return{};var n,o,r=function(e,t){if(null==e)return{};var n,o,r={},c=Object.keys(e);for(o=0;o<c.length;o++)n=c[o],t.indexOf(n)>=0||(r[n]=e[n]);return r}(e,t);if(Object.getOwnPropertySymbols){var c=Object.getOwnPropertySymbols(e);for(o=0;o<c.length;o++)n=c[o],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(r[n]=e[n])}return r}var s=o.createContext({}),i=function(e){var t=o.useContext(s),n=t;return e&&(n="function"==typeof e?e(t):a(a({},t),e)),n},u=function(e){var t=i(e.components);return o.createElement(s.Provider,{value:t},e.children)},p={inlineCode:"code",wrapper:function(e){var t=e.children;return o.createElement(o.Fragment,{},t)}},m=o.forwardRef((function(e,t){var n=e.components,r=e.mdxType,c=e.originalType,s=e.parentName,u=l(e,["components","mdxType","originalType","parentName"]),m=i(n),d=r,g=m["".concat(s,".").concat(d)]||m[d]||p[d]||c;return n?o.createElement(g,a(a({ref:t},u),{},{components:n})):o.createElement(g,a({ref:t},u))}));function d(e,t){var n=arguments,r=t&&t.mdxType;if("string"==typeof e||r){var c=n.length,a=new Array(c);a[0]=m;var l={};for(var s in t)hasOwnProperty.call(t,s)&&(l[s]=t[s]);l.originalType=e,l.mdxType="string"==typeof e?e:r,a[1]=l;for(var i=2;i<c;i++)a[i]=n[i];return o.createElement.apply(null,a)}return o.createElement.apply(null,n)}m.displayName="MDXCreateElement"},3066:(e,t,n)=>{"use strict";n.d(t,{Z:()=>W});var o=n(7462),r=n(7294),c=n(2389),a=n(6010),l=n(2949),s=n(6668);function i(){const{prism:e}=(0,s.L)(),{colorMode:t}=(0,l.I)(),n=e.theme,o=e.darkTheme||n;return"dark"===t?o:n}var u=n(7594),p=n.n(u);const m=/title=(?<quote>["'])(?<title>.*?)\1/,d=/\{(?<range>[\d,-]+)\}/,g={js:{start:"\\/\\/",end:""},jsBlock:{start:"\\/\\*",end:"\\*\\/"},jsx:{start:"\\{\\s*\\/\\*",end:"\\*\\/\\s*\\}"},bash:{start:"#",end:""},html:{start:"\x3c!--",end:"--\x3e"}};function y(e,t){const n=e.map((e=>{const{start:n,end:o}=g[e];return"(?:"+n+"\\s*("+t.flatMap((e=>{var t,n;return[e.line,null==(t=e.block)?void 0:t.start,null==(n=e.block)?void 0:n.end].filter(Boolean)})).join("|")+")\\s*"+o+")"})).join("|");return new RegExp("^\\s*(?:"+n+")\\s*$")}function f(e,t){let n=e.replace(/\n$/,"");const{language:o,magicComments:r,metastring:c}=t;if(c&&d.test(c)){const e=c.match(d).groups.range;if(0===r.length)throw new Error("A highlight range has been given in code block's metastring (``` "+c+"), but no magic comment config is available. Docusaurus applies the first magic comment entry's className for metastring ranges.");const t=r[0].className,o=p()(e).filter((e=>e>0)).map((e=>[e-1,[t]]));return{lineClassNames:Object.fromEntries(o),code:n}}if(void 0===o)return{lineClassNames:{},code:n};const a=function(e,t){switch(e){case"js":case"javascript":case"ts":case"typescript":return y(["js","jsBlock"],t);case"jsx":case"tsx":return y(["js","jsBlock","jsx"],t);case"html":return y(["js","jsBlock","html"],t);case"python":case"py":case"bash":return y(["bash"],t);case"markdown":case"md":return y(["html","jsx","bash"],t);default:return y(Object.keys(g),t)}}(o,r),l=n.split("\n"),s=Object.fromEntries(r.map((e=>[e.className,{start:0,range:""}]))),i=Object.fromEntries(r.filter((e=>e.line)).map((e=>{let{className:t,line:n}=e;return[n,t]}))),u=Object.fromEntries(r.filter((e=>e.block)).map((e=>{let{className:t,block:n}=e;return[n.start,t]}))),m=Object.fromEntries(r.filter((e=>e.block)).map((e=>{let{className:t,block:n}=e;return[n.end,t]})));for(let p=0;p<l.length;){const e=l[p].match(a);if(!e){p+=1;continue}const t=e.slice(1).find((e=>void 0!==e));i[t]?s[i[t]].range+=p+",":u[t]?s[u[t]].start=p:m[t]&&(s[m[t]].range+=s[m[t]].start+"-"+(p-1)+","),l.splice(p,1)}n=l.join("\n");const f={};return Object.entries(s).forEach((e=>{let[t,{range:n}]=e;p()(n).forEach((e=>{null!=f[e]||(f[e]=[]),f[e].push(t)}))})),{lineClassNames:f,code:n}}var h=n(5281);const b="codeBlockContainer_Ckt0";function v(e){let{as:t,...n}=e;const c=function(e){const t={color:"--prism-color",backgroundColor:"--prism-background-color"},n={};return Object.entries(e.plain).forEach((e=>{let[o,r]=e;const c=t[o];c&&"string"==typeof r&&(n[c]=r)})),n}(i());return r.createElement(t,(0,o.Z)({},n,{style:c,className:(0,a.Z)(n.className,b,h.k.common.codeBlock)}))}const k={codeBlockContent:"codeBlockContent_biex",codeBlockTitle:"codeBlockTitle_Ktv7",codeBlock:"codeBlock_bY9V",codeBlockStandalone:"codeBlockStandalone_MEMb",codeBlockLines:"codeBlockLines_e6Vv",codeBlockLinesWithNumbering:"codeBlockLinesWithNumbering_o6Pm",buttonGroup:"buttonGroup__atx"};function E(e){let{children:t,className:n}=e;return r.createElement(v,{as:"pre",tabIndex:0,className:(0,a.Z)(k.codeBlockStandalone,"thin-scrollbar",n)},r.createElement("code",{className:k.codeBlockLines},t))}const N={plain:{backgroundColor:"#2a2734",color:"#9a86fd"},styles:[{types:["comment","prolog","doctype","cdata","punctuation"],style:{color:"#6c6783"}},{types:["namespace"],style:{opacity:.7}},{types:["tag","operator","number"],style:{color:"#e09142"}},{types:["property","function"],style:{color:"#9a86fd"}},{types:["tag-id","selector","atrule-id"],style:{color:"#eeebff"}},{types:["attr-name"],style:{color:"#c4b9fe"}},{types:["boolean","string","entity","url","attr-value","keyword","control","directive","unit","statement","regex","at-rule","placeholder","variable"],style:{color:"#ffcc99"}},{types:["deleted"],style:{textDecorationLine:"line-through"}},{types:["inserted"],style:{textDecorationLine:"underline"}},{types:["italic"],style:{fontStyle:"italic"}},{types:["important","bold"],style:{fontWeight:"bold"}},{types:["important"],style:{color:"#c4b9fe"}}]};var B={Prism:n(7410).Z,theme:N};function j(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function w(){return w=Object.assign||function(e){for(var t=1;t<arguments.length;t++){var n=arguments[t];for(var o in n)Object.prototype.hasOwnProperty.call(n,o)&&(e[o]=n[o])}return e},w.apply(this,arguments)}var C=/\r\n|\r|\n/,O=function(e){0===e.length?e.push({types:["plain"],content:"\n",empty:!0}):1===e.length&&""===e[0].content&&(e[0].content="\n",e[0].empty=!0)},L=function(e,t){var n=e.length;return n>0&&e[n-1]===t?e:e.concat(t)},T=function(e,t){var n=e.plain,o=Object.create(null),r=e.styles.reduce((function(e,n){var o=n.languages,r=n.style;return o&&!o.includes(t)||n.types.forEach((function(t){var n=w({},e[t],r);e[t]=n})),e}),o);return r.root=n,r.plain=w({},n,{backgroundColor:null}),r};function x(e,t){var n={};for(var o in e)Object.prototype.hasOwnProperty.call(e,o)&&-1===t.indexOf(o)&&(n[o]=e[o]);return n}const P=function(e){function t(){for(var t=this,n=[],o=arguments.length;o--;)n[o]=arguments[o];e.apply(this,n),j(this,"getThemeDict",(function(e){if(void 0!==t.themeDict&&e.theme===t.prevTheme&&e.language===t.prevLanguage)return t.themeDict;t.prevTheme=e.theme,t.prevLanguage=e.language;var n=e.theme?T(e.theme,e.language):void 0;return t.themeDict=n})),j(this,"getLineProps",(function(e){var n=e.key,o=e.className,r=e.style,c=w({},x(e,["key","className","style","line"]),{className:"token-line",style:void 0,key:void 0}),a=t.getThemeDict(t.props);return void 0!==a&&(c.style=a.plain),void 0!==r&&(c.style=void 0!==c.style?w({},c.style,r):r),void 0!==n&&(c.key=n),o&&(c.className+=" "+o),c})),j(this,"getStyleForToken",(function(e){var n=e.types,o=e.empty,r=n.length,c=t.getThemeDict(t.props);if(void 0!==c){if(1===r&&"plain"===n[0])return o?{display:"inline-block"}:void 0;if(1===r&&!o)return c[n[0]];var a=o?{display:"inline-block"}:{},l=n.map((function(e){return c[e]}));return Object.assign.apply(Object,[a].concat(l))}})),j(this,"getTokenProps",(function(e){var n=e.key,o=e.className,r=e.style,c=e.token,a=w({},x(e,["key","className","style","token"]),{className:"token "+c.types.join(" "),children:c.content,style:t.getStyleForToken(c),key:void 0});return void 0!==r&&(a.style=void 0!==a.style?w({},a.style,r):r),void 0!==n&&(a.key=n),o&&(a.className+=" "+o),a})),j(this,"tokenize",(function(e,t,n,o){var r={code:t,grammar:n,language:o,tokens:[]};e.hooks.run("before-tokenize",r);var c=r.tokens=e.tokenize(r.code,r.grammar,r.language);return e.hooks.run("after-tokenize",r),c}))}return e&&(t.__proto__=e),t.prototype=Object.create(e&&e.prototype),t.prototype.constructor=t,t.prototype.render=function(){var e=this.props,t=e.Prism,n=e.language,o=e.code,r=e.children,c=this.getThemeDict(this.props),a=t.languages[n];return r({tokens:function(e){for(var t=[[]],n=[e],o=[0],r=[e.length],c=0,a=0,l=[],s=[l];a>-1;){for(;(c=o[a]++)<r[a];){var i=void 0,u=t[a],p=n[a][c];if("string"==typeof p?(u=a>0?u:["plain"],i=p):(u=L(u,p.type),p.alias&&(u=L(u,p.alias)),i=p.content),"string"==typeof i){var m=i.split(C),d=m.length;l.push({types:u,content:m[0]});for(var g=1;g<d;g++)O(l),s.push(l=[]),l.push({types:u,content:m[g]})}else a++,t.push(u),n.push(i),o.push(0),r.push(i.length)}a--,t.pop(),n.pop(),o.pop(),r.pop()}return O(l),s}(void 0!==a?this.tokenize(t,o,a,n):[o]),className:"prism-code language-"+n,style:void 0!==c?c.root:{},getLineProps:this.getLineProps,getTokenProps:this.getTokenProps})},t}(r.Component),S="codeLine_lJS_",_="codeLineNumber_Tfdd",I="codeLineContent_feaV";function A(e){let{line:t,classNames:n,showLineNumbers:c,getLineProps:l,getTokenProps:s}=e;1===t.length&&"\n"===t[0].content&&(t[0].content="");const i=l({line:t,className:(0,a.Z)(n,c&&S)}),u=t.map(((e,t)=>r.createElement("span",(0,o.Z)({key:t},s({token:e,key:t})))));return r.createElement("span",i,c?r.createElement(r.Fragment,null,r.createElement("span",{className:_}),r.createElement("span",{className:I},u)):r.createElement(r.Fragment,null,u,r.createElement("br",null)))}var Z=n(5999);const D={copyButtonCopied:"copyButtonCopied_obH4",copyButtonIcons:"copyButtonIcons_eSgA",copyButtonIcon:"copyButtonIcon_y97N",copyButtonSuccessIcon:"copyButtonSuccessIcon_LjdS"};function H(e){let{code:t,className:n}=e;const[o,c]=(0,r.useState)(!1),l=(0,r.useRef)(void 0),s=(0,r.useCallback)((()=>{!function(e,t){let{target:n=document.body}=void 0===t?{}:t;const o=document.createElement("textarea"),r=document.activeElement;o.value=e,o.setAttribute("readonly",""),o.style.contain="strict",o.style.position="absolute",o.style.left="-9999px",o.style.fontSize="12pt";const c=document.getSelection();let a=!1;c.rangeCount>0&&(a=c.getRangeAt(0)),n.append(o),o.select(),o.selectionStart=0,o.selectionEnd=e.length;let l=!1;try{l=document.execCommand("copy")}catch{}o.remove(),a&&(c.removeAllRanges(),c.addRange(a)),r&&r.focus()}(t),c(!0),l.current=window.setTimeout((()=>{c(!1)}),1e3)}),[t]);return(0,r.useEffect)((()=>()=>window.clearTimeout(l.current)),[]),r.createElement("button",{type:"button","aria-label":o?(0,Z.I)({id:"theme.CodeBlock.copied",message:"Copied",description:"The copied button label on code blocks"}):(0,Z.I)({id:"theme.CodeBlock.copyButtonAriaLabel",message:"Copy code to clipboard",description:"The ARIA label for copy code blocks button"}),title:(0,Z.I)({id:"theme.CodeBlock.copy",message:"Copy",description:"The copy button label on code blocks"}),className:(0,a.Z)("clean-btn",n,D.copyButton,o&&D.copyButtonCopied),onClick:s},r.createElement("span",{className:D.copyButtonIcons,"aria-hidden":"true"},r.createElement("svg",{className:D.copyButtonIcon,viewBox:"0 0 24 24"},r.createElement("path",{d:"M19,21H8V7H19M19,5H8A2,2 0 0,0 6,7V21A2,2 0 0,0 8,23H19A2,2 0 0,0 21,21V7A2,2 0 0,0 19,5M16,1H4A2,2 0 0,0 2,3V17H4V3H16V1Z"})),r.createElement("svg",{className:D.copyButtonSuccessIcon,viewBox:"0 0 24 24"},r.createElement("path",{d:"M21,7L9,19L3.5,13.5L4.91,12.09L9,16.17L19.59,5.59L21,7Z"}))))}const z="wordWrapButtonIcon_Bwma",M="wordWrapButtonEnabled_EoeP";function V(e){let{className:t,onClick:n,isEnabled:o}=e;const c=(0,Z.I)({id:"theme.CodeBlock.wordWrapToggle",message:"Toggle word wrap",description:"The title attribute for toggle word wrapping button of code block lines"});return r.createElement("button",{type:"button",onClick:n,className:(0,a.Z)("clean-btn",t,o&&M),"aria-label":c,title:c},r.createElement("svg",{className:z,viewBox:"0 0 24 24","aria-hidden":"true"},r.createElement("path",{fill:"currentColor",d:"M4 19h6v-2H4v2zM20 5H4v2h16V5zm-3 6H4v2h13.25c1.1 0 2 .9 2 2s-.9 2-2 2H15v-2l-3 3l3 3v-2h2c2.21 0 4-1.79 4-4s-1.79-4-4-4z"})))}function R(e){var t;let{children:n,className:c="",metastring:l,title:u,showLineNumbers:p,language:d}=e;const{prism:{defaultLanguage:g,magicComments:y}}=(0,s.L)(),h=null!=(t=null!=d?d:function(e){const t=e.split(" ").find((e=>e.startsWith("language-")));return null==t?void 0:t.replace(/language-/,"")}(c))?t:g,b=i(),E=function(){const[e,t]=(0,r.useState)(!1),[n,o]=(0,r.useState)(!1),c=(0,r.useRef)(null),a=(0,r.useCallback)((()=>{const n=c.current.querySelector("code");e?n.removeAttribute("style"):n.style.whiteSpace="pre-wrap",t((e=>!e))}),[c,e]),l=(0,r.useCallback)((()=>{const{scrollWidth:e,clientWidth:t}=c.current,n=e>t||c.current.querySelector("code").hasAttribute("style");o(n)}),[c]);return(0,r.useEffect)((()=>{l()}),[e,l]),(0,r.useEffect)((()=>(window.addEventListener("resize",l,{passive:!0}),()=>{window.removeEventListener("resize",l)})),[l]),{codeBlockRef:c,isEnabled:e,isCodeScrollable:n,toggle:a}}(),N=function(e){var t,n;return null!=(t=null==e||null==(n=e.match(m))?void 0:n.groups.title)?t:""}(l)||u,{lineClassNames:j,code:w}=f(n,{metastring:l,language:h,magicComments:y}),C=null!=p?p:function(e){return Boolean(null==e?void 0:e.includes("showLineNumbers"))}(l);return r.createElement(v,{as:"div",className:(0,a.Z)(c,h&&!c.includes("language-"+h)&&"language-"+h)},N&&r.createElement("div",{className:k.codeBlockTitle},N),r.createElement("div",{className:k.codeBlockContent},r.createElement(P,(0,o.Z)({},B,{theme:b,code:w,language:null!=h?h:"text"}),(e=>{let{className:t,tokens:n,getLineProps:o,getTokenProps:c}=e;return r.createElement("pre",{tabIndex:0,ref:E.codeBlockRef,className:(0,a.Z)(t,k.codeBlock,"thin-scrollbar")},r.createElement("code",{className:(0,a.Z)(k.codeBlockLines,C&&k.codeBlockLinesWithNumbering)},n.map(((e,t)=>r.createElement(A,{key:t,line:e,getLineProps:o,getTokenProps:c,classNames:j[t],showLineNumbers:C})))))})),r.createElement("div",{className:k.buttonGroup},(E.isEnabled||E.isCodeScrollable)&&r.createElement(V,{className:k.codeButton,onClick:()=>E.toggle(),isEnabled:E.isEnabled}),r.createElement(H,{className:k.codeButton,code:w}))))}function W(e){let{children:t,...n}=e;const a=(0,c.Z)(),l=function(e){return r.Children.toArray(e).some((e=>(0,r.isValidElement)(e)))?e:Array.isArray(e)?e.join(""):e}(t),s="string"==typeof l?R:E;return r.createElement(s,(0,o.Z)({key:String(a)},n),l)}},7594:(e,t)=>{function n(e){let t,n=[];for(let o of e.split(",").map((e=>e.trim())))if(/^-?\d+$/.test(o))n.push(parseInt(o,10));else if(t=o.match(/^(-?\d+)(-|\.\.\.?|\u2025|\u2026|\u22EF)(-?\d+)$/)){let[e,o,r,c]=t;if(o&&c){o=parseInt(o),c=parseInt(c);const e=o<c?1:-1;"-"!==r&&".."!==r&&"\u2025"!==r||(c+=e);for(let t=o;t!==c;t+=e)n.push(t)}}return n}t.default=n,e.exports=n}}]);