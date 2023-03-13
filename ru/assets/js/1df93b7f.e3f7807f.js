"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[3237],{1381:(e,t,r)=>{r.r(t),r.d(t,{default:()=>A});var n=r(7294),a=r(6010),s=r(2260),o=r(9960),i=r(2263);const c="heroBanner_qdFl",l="buttons_AeoN";var u=r(7462);const m="features_xdhU",p="featureSvg__8YW";var d=r(5999);const f=r.p+"assets/images/Sprites-24d134a111643534aa70b3c2bf87b2cd.jpg",g=r.p+"assets/images/Interactions-3fa5602ecc9c19dcb992423a7e5195ef.gif",y=r.p+"assets/images/Mutators-1e0d3ae625e9dbf925e521190d56d5ab.jpg",b=r.p+"assets/images/Abilities-10c5ac3e2fddad825947ce6f30f8d30b.jpg",E=r.p+"assets/images/Items-03c561f5ca25d10816ead121eff7a22d.jpg",h=r.p+"assets/images/Traits-319e8a6836f79f9fd6bf3a4ec33c1bb0.jpg",v=[{title:n.createElement(d.Z,{id:"features.sprites.title"},"Custom Sprites"),svg:f,description:n.createElement(d.Z,{id:"features.sprites.description"},"RogueLibs allows you to add your own and modify existing tk2d/Unity sprites!")},{title:n.createElement(d.Z,{id:"features.interactions.title"},"Custom Interactions"),svg:g,description:n.createElement(d.Z,{id:"features.interactions.description"},"Ever wondered why SoR doesn't have certain interactions? It's time for you to fill in the blanks!")},{title:n.createElement(d.Z,{id:"features.items.title"},"Custom Items"),svg:E,description:n.createElement(d.Z,{id:"features.items.description"},"Adding custom items with various usages and effects could not be easier with RogueLibs!")},{title:n.createElement(d.Z,{id:"features.mutators.title"},"Custom Mutators"),svg:y,description:n.createElement(d.Z,{id:"features.mutators.description"},"Mutators are pretty cool!")},{title:n.createElement(d.Z,{id:"features.abilities.title"},"Custom Abilities"),svg:b,description:n.createElement(d.Z,{id:"features.abilities.description"},"Yep, RogueLibs also has custom abilities!")},{title:n.createElement(d.Z,{id:"features.traits.title"},"Custom Traits"),svg:h,description:n.createElement(d.Z,{id:"features.traits.description"},"And traits too!")}];function k(e){let{svg:t,title:r,description:s}=e;return n.createElement("div",{className:(0,a.Z)("col col--4")},n.createElement("div",{className:"text--center"},n.createElement("img",{src:t,className:p,alt:"string"==typeof r?r:void 0})),n.createElement("div",{className:"text--center padding-horiz--md"},n.createElement("h3",null,r),n.createElement("p",null,s)))}function j(){return n.createElement("section",{className:m},n.createElement("div",{className:"container"},n.createElement("div",{className:"row"},v.map(((e,t)=>n.createElement(k,(0,u.Z)({key:t},e)))))))}const w=r.p+"assets/images/logo-7f3be2e70becd38d1218ed9780d1e03c.png",x=r.p+"assets/images/logo-pokemon-70bf8649049f256abaf9c37e4362485b.png",F=r.p+"assets/images/logo-legacy-6cf8182acabf5f60b113b40106f18d5e.png";var N=r(6550),S=r(7563),O=r(5742),Z=r(2389);function C(e){let{children:t,fallback:r}=e;return(0,Z.Z)()?n.createElement(n.Fragment,null,null==t?void 0:t()):r??null}function I(e){const t=(0,S.parse)(e.search);return void 0!==t.pokemon?x:void 0!==t.legacy?F:w}function R(){const e=(0,N.TH)(),[t,r]=(0,n.useState)((()=>I(e)));return(0,n.useEffect)((()=>{r(I(e))}),[e]),n.createElement("header",{className:(0,a.Z)("hero hero--primary",c)},n.createElement("div",{className:"container"},n.createElement(C,null,(()=>n.createElement("img",{src:t,width:"50%"}))),n.createElement("p",{className:"hero__subtitle"},n.createElement(d.Z,{id:"homepage.tagline"},"Redefining Limits.")),n.createElement("div",{className:l},n.createElement(o.Z,{className:"button button--secondary button--lg",to:"/docs/intro"},n.createElement(d.Z,{id:"homepage.button",description:"The big button in the center on the home page"},"RogueLibs Documentation")))))}function A(){const{siteConfig:e}=(0,i.Z)(),t="RogueLibs - SoR Modding Library",r="This modding library does nothing on its own, but it provides methods for other mods to easily create custom mutators, items, traits, status effects, abilities, unlocks, menus and even integrate custom sounds and sprites (yep, even TK2D ones)!";return n.createElement(s.Z,{title:`${e.title}`,description:"RogueLibs Modding Library for Streets of Rogue"},n.createElement(O.Z,null,n.createElement("title",null,t),n.createElement("meta",{property:"title",content:t}),n.createElement("meta",{name:"description",content:r}),n.createElement("meta",{property:"og:title",content:t}),n.createElement("meta",{property:"og:description",content:r}),n.createElement("meta",{name:"twitter:title",content:t}),n.createElement("meta",{name:"twitter:description",content:r})),n.createElement(R,null),n.createElement("main",null,n.createElement(j,null)))}},4020:e=>{var t="%[a-f0-9]{2}",r=new RegExp("("+t+")|([^%]+?)","gi"),n=new RegExp("("+t+")+","gi");function a(e,t){try{return[decodeURIComponent(e.join(""))]}catch(s){}if(1===e.length)return e;t=t||1;var r=e.slice(0,t),n=e.slice(t);return Array.prototype.concat.call([],a(r),a(n))}function s(e){try{return decodeURIComponent(e)}catch(s){for(var t=e.match(r)||[],n=1;n<t.length;n++)t=(e=a(t,n).join("")).match(r)||[];return e}}e.exports=function(e){if("string"!=typeof e)throw new TypeError("Expected `encodedURI` to be of type `string`, got `"+typeof e+"`");try{return e=e.replace(/\+/g," "),decodeURIComponent(e)}catch(t){return function(e){for(var r={"%FE%FF":"\ufffd\ufffd","%FF%FE":"\ufffd\ufffd"},a=n.exec(e);a;){try{r[a[0]]=decodeURIComponent(a[0])}catch(t){var o=s(a[0]);o!==a[0]&&(r[a[0]]=o)}a=n.exec(e)}r["%C2"]="\ufffd";for(var i=Object.keys(r),c=0;c<i.length;c++){var l=i[c];e=e.replace(new RegExp(l,"g"),r[l])}return e}(e)}}},2806:e=>{e.exports=function(e,t){for(var r={},n=Object.keys(e),a=Array.isArray(t),s=0;s<n.length;s++){var o=n[s],i=e[o];(a?-1!==t.indexOf(o):t(o,i,e))&&(r[o]=i)}return r}},7563:(e,t,r)=>{const n=r(610),a=r(4020),s=r(500),o=r(2806),i=Symbol("encodeFragmentIdentifier");function c(e){if("string"!=typeof e||1!==e.length)throw new TypeError("arrayFormatSeparator must be single character string")}function l(e,t){return t.encode?t.strict?n(e):encodeURIComponent(e):e}function u(e,t){return t.decode?a(e):e}function m(e){return Array.isArray(e)?e.sort():"object"==typeof e?m(Object.keys(e)).sort(((e,t)=>Number(e)-Number(t))).map((t=>e[t])):e}function p(e){const t=e.indexOf("#");return-1!==t&&(e=e.slice(0,t)),e}function d(e){const t=(e=p(e)).indexOf("?");return-1===t?"":e.slice(t+1)}function f(e,t){return t.parseNumbers&&!Number.isNaN(Number(e))&&"string"==typeof e&&""!==e.trim()?e=Number(e):!t.parseBooleans||null===e||"true"!==e.toLowerCase()&&"false"!==e.toLowerCase()||(e="true"===e.toLowerCase()),e}function g(e,t){c((t=Object.assign({decode:!0,sort:!0,arrayFormat:"none",arrayFormatSeparator:",",parseNumbers:!1,parseBooleans:!1},t)).arrayFormatSeparator);const r=function(e){let t;switch(e.arrayFormat){case"index":return(e,r,n)=>{t=/\[(\d*)\]$/.exec(e),e=e.replace(/\[\d*\]$/,""),t?(void 0===n[e]&&(n[e]={}),n[e][t[1]]=r):n[e]=r};case"bracket":return(e,r,n)=>{t=/(\[\])$/.exec(e),e=e.replace(/\[\]$/,""),t?void 0!==n[e]?n[e]=[].concat(n[e],r):n[e]=[r]:n[e]=r};case"colon-list-separator":return(e,r,n)=>{t=/(:list)$/.exec(e),e=e.replace(/:list$/,""),t?void 0!==n[e]?n[e]=[].concat(n[e],r):n[e]=[r]:n[e]=r};case"comma":case"separator":return(t,r,n)=>{const a="string"==typeof r&&r.includes(e.arrayFormatSeparator),s="string"==typeof r&&!a&&u(r,e).includes(e.arrayFormatSeparator);r=s?u(r,e):r;const o=a||s?r.split(e.arrayFormatSeparator).map((t=>u(t,e))):null===r?r:u(r,e);n[t]=o};case"bracket-separator":return(t,r,n)=>{const a=/(\[\])$/.test(t);if(t=t.replace(/\[\]$/,""),!a)return void(n[t]=r?u(r,e):r);const s=null===r?[]:r.split(e.arrayFormatSeparator).map((t=>u(t,e)));void 0!==n[t]?n[t]=[].concat(n[t],s):n[t]=s};default:return(e,t,r)=>{void 0!==r[e]?r[e]=[].concat(r[e],t):r[e]=t}}}(t),n=Object.create(null);if("string"!=typeof e)return n;if(!(e=e.trim().replace(/^[?#&]/,"")))return n;for(const a of e.split("&")){if(""===a)continue;let[e,o]=s(t.decode?a.replace(/\+/g," "):a,"=");o=void 0===o?null:["comma","separator","bracket-separator"].includes(t.arrayFormat)?o:u(o,t),r(u(e,t),o,n)}for(const a of Object.keys(n)){const e=n[a];if("object"==typeof e&&null!==e)for(const r of Object.keys(e))e[r]=f(e[r],t);else n[a]=f(e,t)}return!1===t.sort?n:(!0===t.sort?Object.keys(n).sort():Object.keys(n).sort(t.sort)).reduce(((e,t)=>{const r=n[t];return Boolean(r)&&"object"==typeof r&&!Array.isArray(r)?e[t]=m(r):e[t]=r,e}),Object.create(null))}t.extract=d,t.parse=g,t.stringify=(e,t)=>{if(!e)return"";c((t=Object.assign({encode:!0,strict:!0,arrayFormat:"none",arrayFormatSeparator:","},t)).arrayFormatSeparator);const r=r=>t.skipNull&&null==e[r]||t.skipEmptyString&&""===e[r],n=function(e){switch(e.arrayFormat){case"index":return t=>(r,n)=>{const a=r.length;return void 0===n||e.skipNull&&null===n||e.skipEmptyString&&""===n?r:null===n?[...r,[l(t,e),"[",a,"]"].join("")]:[...r,[l(t,e),"[",l(a,e),"]=",l(n,e)].join("")]};case"bracket":return t=>(r,n)=>void 0===n||e.skipNull&&null===n||e.skipEmptyString&&""===n?r:null===n?[...r,[l(t,e),"[]"].join("")]:[...r,[l(t,e),"[]=",l(n,e)].join("")];case"colon-list-separator":return t=>(r,n)=>void 0===n||e.skipNull&&null===n||e.skipEmptyString&&""===n?r:null===n?[...r,[l(t,e),":list="].join("")]:[...r,[l(t,e),":list=",l(n,e)].join("")];case"comma":case"separator":case"bracket-separator":{const t="bracket-separator"===e.arrayFormat?"[]=":"=";return r=>(n,a)=>void 0===a||e.skipNull&&null===a||e.skipEmptyString&&""===a?n:(a=null===a?"":a,0===n.length?[[l(r,e),t,l(a,e)].join("")]:[[n,l(a,e)].join(e.arrayFormatSeparator)])}default:return t=>(r,n)=>void 0===n||e.skipNull&&null===n||e.skipEmptyString&&""===n?r:null===n?[...r,l(t,e)]:[...r,[l(t,e),"=",l(n,e)].join("")]}}(t),a={};for(const o of Object.keys(e))r(o)||(a[o]=e[o]);const s=Object.keys(a);return!1!==t.sort&&s.sort(t.sort),s.map((r=>{const a=e[r];return void 0===a?"":null===a?l(r,t):Array.isArray(a)?0===a.length&&"bracket-separator"===t.arrayFormat?l(r,t)+"[]":a.reduce(n(r),[]).join("&"):l(r,t)+"="+l(a,t)})).filter((e=>e.length>0)).join("&")},t.parseUrl=(e,t)=>{t=Object.assign({decode:!0},t);const[r,n]=s(e,"#");return Object.assign({url:r.split("?")[0]||"",query:g(d(e),t)},t&&t.parseFragmentIdentifier&&n?{fragmentIdentifier:u(n,t)}:{})},t.stringifyUrl=(e,r)=>{r=Object.assign({encode:!0,strict:!0,[i]:!0},r);const n=p(e.url).split("?")[0]||"",a=t.extract(e.url),s=t.parse(a,{sort:!1}),o=Object.assign(s,e.query);let c=t.stringify(o,r);c&&(c=`?${c}`);let u=function(e){let t="";const r=e.indexOf("#");return-1!==r&&(t=e.slice(r)),t}(e.url);return e.fragmentIdentifier&&(u=`#${r[i]?l(e.fragmentIdentifier,r):e.fragmentIdentifier}`),`${n}${c}${u}`},t.pick=(e,r,n)=>{n=Object.assign({parseFragmentIdentifier:!0,[i]:!1},n);const{url:a,query:s,fragmentIdentifier:c}=t.parseUrl(e,n);return t.stringifyUrl({url:a,query:o(s,r),fragmentIdentifier:c},n)},t.exclude=(e,r,n)=>{const a=Array.isArray(r)?e=>!r.includes(e):(e,t)=>!r(e,t);return t.pick(e,a,n)}},500:e=>{e.exports=(e,t)=>{if("string"!=typeof e||"string"!=typeof t)throw new TypeError("Expected the arguments to be of type `string`");if(""===t)return[e];const r=e.indexOf(t);return-1===r?[e]:[e.slice(0,r),e.slice(r+t.length)]}},610:e=>{e.exports=e=>encodeURIComponent(e).replace(/[!'()*]/g,(e=>`%${e.charCodeAt(0).toString(16).toUpperCase()}`))}}]);