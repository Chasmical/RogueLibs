"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[3237],{3203:(e,t,r)=>{r.r(t),r.d(t,{default:()=>re});var n={};r.r(n),r.d(n,{exclude:()=>G,extract:()=>P,parse:()=>K,parseUrl:()=>z,pick:()=>W,stringify:()=>Y,stringifyUrl:()=>H});var s=r(7294),i=r(512),o=r(2695),a=r(3692),c=r(2263);const l={heroBanner:"heroBanner_qdFl",buttons:"buttons_AeoN"},d={features:"features_xdhU",featureSvg:"featureSvg__8YW"};var u=r(5999);const p=r.p+"assets/images/Sprites-24d134a111643534aa70b3c2bf87b2cd.jpg",f=r.p+"assets/images/Interactions-3fa5602ecc9c19dcb992423a7e5195ef.gif",m=r.p+"assets/images/Mutators-1e0d3ae625e9dbf925e521190d56d5ab.jpg",g=r.p+"assets/images/Abilities-10c5ac3e2fddad825947ce6f30f8d30b.jpg",y=r.p+"assets/images/Items-03c561f5ca25d10816ead121eff7a22d.jpg",h=r.p+"assets/images/Traits-319e8a6836f79f9fd6bf3a4ec33c1bb0.jpg";var b=r(5893);const j=[{title:(0,b.jsx)(u.Z,{id:"features.sprites.title",children:"Custom Sprites"}),svg:p,description:(0,b.jsx)(u.Z,{id:"features.sprites.description",children:"RogueLibs allows you to add your own and modify existing tk2d/Unity sprites!"})},{title:(0,b.jsx)(u.Z,{id:"features.interactions.title",children:"Custom Interactions"}),svg:f,description:(0,b.jsx)(u.Z,{id:"features.interactions.description",children:"Ever wondered why SoR doesn't have certain interactions? It's time for you to fill in the blanks!"})},{title:(0,b.jsx)(u.Z,{id:"features.items.title",children:"Custom Items"}),svg:y,description:(0,b.jsx)(u.Z,{id:"features.items.description",children:"Adding custom items with various usages and effects could not be easier with RogueLibs!"})},{title:(0,b.jsx)(u.Z,{id:"features.mutators.title",children:"Custom Mutators"}),svg:m,description:(0,b.jsx)(u.Z,{id:"features.mutators.description",children:"Mutators are pretty cool!"})},{title:(0,b.jsx)(u.Z,{id:"features.abilities.title",children:"Custom Abilities"}),svg:g,description:(0,b.jsx)(u.Z,{id:"features.abilities.description",children:"Yep, RogueLibs also has custom abilities!"})},{title:(0,b.jsx)(u.Z,{id:"features.traits.title",children:"Custom Traits"}),svg:h,description:(0,b.jsx)(u.Z,{id:"features.traits.description",children:"And traits too!"})}];function x(e){let{svg:t,title:r,description:n}=e;return(0,b.jsxs)("div",{className:(0,i.Z)("col col--4"),children:[(0,b.jsx)("div",{className:"text--center",children:(0,b.jsx)("img",{src:t,className:d.featureSvg,alt:"string"==typeof r?r:void 0})}),(0,b.jsxs)("div",{className:"text--center padding-horiz--md",children:[(0,b.jsx)("h3",{children:r}),(0,b.jsx)("p",{children:n})]})]})}function v(){return(0,b.jsx)("section",{className:d.features,children:(0,b.jsx)("div",{className:"container",children:(0,b.jsx)("div",{className:"row",children:j.map(((e,t)=>(0,b.jsx)(x,{...e},t)))})})})}const k=r.p+"assets/images/logo-7f3be2e70becd38d1218ed9780d1e03c.png",w=r.p+"assets/images/logo-pokemon-70bf8649049f256abaf9c37e4362485b.png",F=r.p+"assets/images/logo-legacy-6cf8182acabf5f60b113b40106f18d5e.png";var N=r(6550);const S="%[a-f0-9]{2}",R=new RegExp("("+S+")|([^%]+?)","gi"),C=new RegExp("("+S+")+","gi");function I(e,t){try{return[decodeURIComponent(e.join(""))]}catch{}if(1===e.length)return e;t=t||1;const r=e.slice(0,t),n=e.slice(t);return Array.prototype.concat.call([],I(r),I(n))}function Z(e){try{return decodeURIComponent(e)}catch{let t=e.match(R)||[];for(let r=1;r<t.length;r++)t=(e=I(t,r).join("")).match(R)||[];return e}}function O(e){if("string"!=typeof e)throw new TypeError("Expected `encodedURI` to be of type `string`, got `"+typeof e+"`");try{return decodeURIComponent(e)}catch{return function(e){const t={"%FE%FF":"\ufffd\ufffd","%FF%FE":"\ufffd\ufffd"};let r=C.exec(e);for(;r;){try{t[r[0]]=decodeURIComponent(r[0])}catch{const e=Z(r[0]);e!==r[0]&&(t[r[0]]=e)}r=C.exec(e)}t["%C2"]="\ufffd";const n=Object.keys(t);for(const s of n)e=e.replace(new RegExp(s,"g"),t[s]);return e}(e)}}function E(e,t){if("string"!=typeof e||"string"!=typeof t)throw new TypeError("Expected the arguments to be of type `string`");if(""===e||""===t)return[];const r=e.indexOf(t);return-1===r?[]:[e.slice(0,r),e.slice(r+t.length)]}function A(e,t){const r={};if(Array.isArray(t))for(const n of t){const t=Object.getOwnPropertyDescriptor(e,n);t?.enumerable&&Object.defineProperty(r,n,t)}else for(const n of Reflect.ownKeys(e)){const s=Object.getOwnPropertyDescriptor(e,n);if(s.enumerable){t(n,e[n],e)&&Object.defineProperty(r,n,s)}}return r}const $=e=>null==e,L=e=>encodeURIComponent(e).replace(/[!'()*]/g,(e=>`%${e.charCodeAt(0).toString(16).toUpperCase()}`)),U=Symbol("encodeFragmentIdentifier");function T(e){if("string"!=typeof e||1!==e.length)throw new TypeError("arrayFormatSeparator must be single character string")}function _(e,t){return t.encode?t.strict?L(e):encodeURIComponent(e):e}function B(e,t){return t.decode?O(e):e}function q(e){return Array.isArray(e)?e.sort():"object"==typeof e?q(Object.keys(e)).sort(((e,t)=>Number(e)-Number(t))).map((t=>e[t])):e}function M(e){const t=e.indexOf("#");return-1!==t&&(e=e.slice(0,t)),e}function D(e,t){return t.parseNumbers&&!Number.isNaN(Number(e))&&"string"==typeof e&&""!==e.trim()?e=Number(e):!t.parseBooleans||null===e||"true"!==e.toLowerCase()&&"false"!==e.toLowerCase()||(e="true"===e.toLowerCase()),e}function P(e){const t=(e=M(e)).indexOf("?");return-1===t?"":e.slice(t+1)}function K(e,t){T((t={decode:!0,sort:!0,arrayFormat:"none",arrayFormatSeparator:",",parseNumbers:!1,parseBooleans:!1,...t}).arrayFormatSeparator);const r=function(e){let t;switch(e.arrayFormat){case"index":return(e,r,n)=>{t=/\[(\d*)]$/.exec(e),e=e.replace(/\[\d*]$/,""),t?(void 0===n[e]&&(n[e]={}),n[e][t[1]]=r):n[e]=r};case"bracket":return(e,r,n)=>{t=/(\[])$/.exec(e),e=e.replace(/\[]$/,""),t?void 0!==n[e]?n[e]=[...n[e],r]:n[e]=[r]:n[e]=r};case"colon-list-separator":return(e,r,n)=>{t=/(:list)$/.exec(e),e=e.replace(/:list$/,""),t?void 0!==n[e]?n[e]=[...n[e],r]:n[e]=[r]:n[e]=r};case"comma":case"separator":return(t,r,n)=>{const s="string"==typeof r&&r.includes(e.arrayFormatSeparator),i="string"==typeof r&&!s&&B(r,e).includes(e.arrayFormatSeparator);r=i?B(r,e):r;const o=s||i?r.split(e.arrayFormatSeparator).map((t=>B(t,e))):null===r?r:B(r,e);n[t]=o};case"bracket-separator":return(t,r,n)=>{const s=/(\[])$/.test(t);if(t=t.replace(/\[]$/,""),!s)return void(n[t]=r?B(r,e):r);const i=null===r?[]:r.split(e.arrayFormatSeparator).map((t=>B(t,e)));void 0!==n[t]?n[t]=[...n[t],...i]:n[t]=i};default:return(e,t,r)=>{void 0!==r[e]?r[e]=[...[r[e]].flat(),t]:r[e]=t}}}(t),n=Object.create(null);if("string"!=typeof e)return n;if(!(e=e.trim().replace(/^[?#&]/,"")))return n;for(const s of e.split("&")){if(""===s)continue;const e=t.decode?s.replace(/\+/g," "):s;let[i,o]=E(e,"=");void 0===i&&(i=e),o=void 0===o?null:["comma","separator","bracket-separator"].includes(t.arrayFormat)?o:B(o,t),r(B(i,t),o,n)}for(const[s,i]of Object.entries(n))if("object"==typeof i&&null!==i)for(const[e,r]of Object.entries(i))i[e]=D(r,t);else n[s]=D(i,t);return!1===t.sort?n:(!0===t.sort?Object.keys(n).sort():Object.keys(n).sort(t.sort)).reduce(((e,t)=>{const r=n[t];return Boolean(r)&&"object"==typeof r&&!Array.isArray(r)?e[t]=q(r):e[t]=r,e}),Object.create(null))}function Y(e,t){if(!e)return"";T((t={encode:!0,strict:!0,arrayFormat:"none",arrayFormatSeparator:",",...t}).arrayFormatSeparator);const r=r=>t.skipNull&&$(e[r])||t.skipEmptyString&&""===e[r],n=function(e){switch(e.arrayFormat){case"index":return t=>(r,n)=>{const s=r.length;return void 0===n||e.skipNull&&null===n||e.skipEmptyString&&""===n?r:null===n?[...r,[_(t,e),"[",s,"]"].join("")]:[...r,[_(t,e),"[",_(s,e),"]=",_(n,e)].join("")]};case"bracket":return t=>(r,n)=>void 0===n||e.skipNull&&null===n||e.skipEmptyString&&""===n?r:null===n?[...r,[_(t,e),"[]"].join("")]:[...r,[_(t,e),"[]=",_(n,e)].join("")];case"colon-list-separator":return t=>(r,n)=>void 0===n||e.skipNull&&null===n||e.skipEmptyString&&""===n?r:null===n?[...r,[_(t,e),":list="].join("")]:[...r,[_(t,e),":list=",_(n,e)].join("")];case"comma":case"separator":case"bracket-separator":{const t="bracket-separator"===e.arrayFormat?"[]=":"=";return r=>(n,s)=>void 0===s||e.skipNull&&null===s||e.skipEmptyString&&""===s?n:(s=null===s?"":s,0===n.length?[[_(r,e),t,_(s,e)].join("")]:[[n,_(s,e)].join(e.arrayFormatSeparator)])}default:return t=>(r,n)=>void 0===n||e.skipNull&&null===n||e.skipEmptyString&&""===n?r:null===n?[...r,_(t,e)]:[...r,[_(t,e),"=",_(n,e)].join("")]}}(t),s={};for(const[o,a]of Object.entries(e))r(o)||(s[o]=a);const i=Object.keys(s);return!1!==t.sort&&i.sort(t.sort),i.map((r=>{const s=e[r];return void 0===s?"":null===s?_(r,t):Array.isArray(s)?0===s.length&&"bracket-separator"===t.arrayFormat?_(r,t)+"[]":s.reduce(n(r),[]).join("&"):_(r,t)+"="+_(s,t)})).filter((e=>e.length>0)).join("&")}function z(e,t){t={decode:!0,...t};let[r,n]=E(e,"#");return void 0===r&&(r=e),{url:r?.split("?")?.[0]??"",query:K(P(e),t),...t&&t.parseFragmentIdentifier&&n?{fragmentIdentifier:B(n,t)}:{}}}function H(e,t){t={encode:!0,strict:!0,[U]:!0,...t};const r=M(e.url).split("?")[0]||"";let n=Y({...K(P(e.url),{sort:!1}),...e.query},t);n&&(n=`?${n}`);let s=function(e){let t="";const r=e.indexOf("#");return-1!==r&&(t=e.slice(r)),t}(e.url);if(e.fragmentIdentifier){const n=new URL(r);n.hash=e.fragmentIdentifier,s=t[U]?n.hash:`#${e.fragmentIdentifier}`}return`${r}${n}${s}`}function W(e,t,r){r={parseFragmentIdentifier:!0,[U]:!1,...r};const{url:n,query:s,fragmentIdentifier:i}=z(e,r);return H({url:n,query:A(s,t),fragmentIdentifier:i},r)}function G(e,t,r){return W(e,Array.isArray(t)?e=>!t.includes(e):(e,r)=>!t(e,r),r)}const J=n;var Q=r(5742),V=r(2389);function X(e){let{children:t,fallback:r}=e;return(0,V.Z)()?(0,b.jsx)(b.Fragment,{children:t?.()}):r??null}function ee(e){const t=J.parse(e.search);return void 0!==t.pokemon?w:void 0!==t.legacy?F:k}function te(){const e=(0,N.TH)(),[t,r]=(0,s.useState)((()=>ee(e)));return(0,s.useEffect)((()=>{r(ee(e))}),[e]),(0,b.jsx)("header",{className:(0,i.Z)("hero hero--primary",l.heroBanner),children:(0,b.jsxs)("div",{className:"container",children:[(0,b.jsx)(X,{children:()=>(0,b.jsx)("img",{src:t,width:"50%"})}),(0,b.jsx)("p",{className:"hero__subtitle",children:(0,b.jsx)(u.Z,{id:"homepage.tagline",children:"Redefining Limits."})}),(0,b.jsx)("div",{className:l.buttons,children:(0,b.jsx)(a.Z,{className:"button button--secondary button--lg",to:"/docs/intro",children:(0,b.jsx)(u.Z,{id:"homepage.button",description:"The big button in the center on the home page",children:"RogueLibs Documentation"})})})]})})}function re(){const{siteConfig:e}=(0,c.Z)(),t="RogueLibs - SoR Modding Library",r="This modding library does nothing on its own, but it provides methods for other mods to easily create custom mutators, items, traits, status effects, abilities, unlocks, menus and even integrate custom sounds and sprites (yep, even TK2D ones)!";return(0,b.jsxs)(o.Z,{title:`${e.title}`,description:"RogueLibs Modding Library for Streets of Rogue",children:[(0,b.jsxs)(Q.Z,{children:[(0,b.jsx)("title",{children:t}),(0,b.jsx)("meta",{property:"title",content:t}),(0,b.jsx)("meta",{name:"description",content:r}),(0,b.jsx)("meta",{property:"og:title",content:t}),(0,b.jsx)("meta",{property:"og:description",content:r}),(0,b.jsx)("meta",{name:"twitter:title",content:t}),(0,b.jsx)("meta",{name:"twitter:description",content:r})]}),(0,b.jsx)(te,{}),(0,b.jsx)("main",{children:(0,b.jsx)(v,{})})]})}}}]);