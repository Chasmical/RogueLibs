"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[3237],{3917:function(e,t,r){r.r(t),r.d(t,{default:function(){return w}});var n=r(7294),a=r(6010),o=r(8173),s=r(9960),c=r(2263),i="heroBanner_1ZBZ",l="buttons_irzW",u=r(3117),p="features_pzNA",f="featureSvg_3LcT",m=r(5999),d=r.p+"assets/images/undraw_docusaurus_mountain-81286e0b614c67b8b2892e52012b16f0.png",g=r.p+"assets/images/undraw_docusaurus_tree-d521d0cbb374ceb670c68b9bd4ed0c1f.png",y=[{title:n.createElement(m.Z,{id:"features.easy.title"},"Easy to Use"),svg:d,description:n.createElement(m.Z,{id:"features.easy.description"},"RogueLibs does all of the patching for you!")},{title:n.createElement(m.Z,{id:"features.focus.title"},"Focus on What Matters"),svg:g,description:n.createElement("span",null,n.createElement(m.Z,{id:"features.focus.description"},"Let RogueLibs handle the hard work, and")," ",n.createElement("b",null,n.createElement(m.Z,{id:"features.focus.description.bold"},"you just focus on the content!")))}];function b(e){var t=e.svg,r=e.title,o=e.description;return n.createElement("div",{className:(0,a.Z)("col col--4")},n.createElement("div",{className:"text--center"},n.createElement("img",{src:t,className:f,alt:"string"==typeof r?r:void 0})),n.createElement("div",{className:"text--center padding-horiz--md"},n.createElement("h3",null,r),n.createElement("p",null,o)))}function h(){return n.createElement("section",{className:p},n.createElement("div",{className:"container"},n.createElement("div",{className:"row"},y.map((function(e,t){return n.createElement(b,(0,u.Z)({key:t},e))})))))}var E=r(5350),v=r.p+"assets/images/logo-6cf8182acabf5f60b113b40106f18d5e.png",k=r.p+"assets/images/logo-inverted-052e407821a4e380ba32f7a1c4f05e36.png",j=r.p+"assets/images/logo-pokemon-70bf8649049f256abaf9c37e4362485b.png",F=r(6775),N=r(7563);function x(){var e=(0,E.Z)().isDarkTheme,t=void 0!==(0,N.parse)((0,F.TH)().search).pokemon?j:e?k:v;return n.createElement("header",{className:(0,a.Z)("hero hero--primary",i)},n.createElement("div",{className:"container"},n.createElement("img",{src:t,width:"50%"}),n.createElement("p",{className:"hero__subtitle"},n.createElement(m.Z,{id:"homepage.tagline"},"Doing the impossible.")),n.createElement("div",{className:l},n.createElement(s.Z,{className:"button button--secondary button--lg",to:"/docs/intro"},n.createElement(m.Z,{id:"homepage.button",description:"The big button in the center on the home page"},"RogueLibs Documentation")))))}function w(){var e=(0,c.Z)().siteConfig;return n.createElement(o.Z,{title:""+e.title,description:"RogueLibs Modding Library for Streets of Rogue"},n.createElement(x,null),n.createElement("main",null,n.createElement(h,null)))}},4020:function(e){var t="%[a-f0-9]{2}",r=new RegExp(t,"gi"),n=new RegExp("("+t+")+","gi");function a(e,t){try{return decodeURIComponent(e.join(""))}catch(o){}if(1===e.length)return e;t=t||1;var r=e.slice(0,t),n=e.slice(t);return Array.prototype.concat.call([],a(r),a(n))}function o(e){try{return decodeURIComponent(e)}catch(o){for(var t=e.match(r),n=1;n<t.length;n++)t=(e=a(t,n).join("")).match(r);return e}}e.exports=function(e){if("string"!=typeof e)throw new TypeError("Expected `encodedURI` to be of type `string`, got `"+typeof e+"`");try{return e=e.replace(/\+/g," "),decodeURIComponent(e)}catch(t){return function(e){for(var r={"%FE%FF":"\ufffd\ufffd","%FF%FE":"\ufffd\ufffd"},a=n.exec(e);a;){try{r[a[0]]=decodeURIComponent(a[0])}catch(t){var s=o(a[0]);s!==a[0]&&(r[a[0]]=s)}a=n.exec(e)}r["%C2"]="\ufffd";for(var c=Object.keys(r),i=0;i<c.length;i++){var l=c[i];e=e.replace(new RegExp(l,"g"),r[l])}return e}(e)}}},2806:function(e){e.exports=function(e,t){for(var r={},n=Object.keys(e),a=Array.isArray(t),o=0;o<n.length;o++){var s=n[o],c=e[s];(a?-1!==t.indexOf(s):t(s,c,e))&&(r[s]=c)}return r}},7563:function(e,t,r){const n=r(610),a=r(4020),o=r(500),s=r(2806),c=Symbol("encodeFragmentIdentifier");function i(e){if("string"!=typeof e||1!==e.length)throw new TypeError("arrayFormatSeparator must be single character string")}function l(e,t){return t.encode?t.strict?n(e):encodeURIComponent(e):e}function u(e,t){return t.decode?a(e):e}function p(e){return Array.isArray(e)?e.sort():"object"==typeof e?p(Object.keys(e)).sort(((e,t)=>Number(e)-Number(t))).map((t=>e[t])):e}function f(e){const t=e.indexOf("#");return-1!==t&&(e=e.slice(0,t)),e}function m(e){const t=(e=f(e)).indexOf("?");return-1===t?"":e.slice(t+1)}function d(e,t){return t.parseNumbers&&!Number.isNaN(Number(e))&&"string"==typeof e&&""!==e.trim()?e=Number(e):!t.parseBooleans||null===e||"true"!==e.toLowerCase()&&"false"!==e.toLowerCase()||(e="true"===e.toLowerCase()),e}function g(e,t){i((t=Object.assign({decode:!0,sort:!0,arrayFormat:"none",arrayFormatSeparator:",",parseNumbers:!1,parseBooleans:!1},t)).arrayFormatSeparator);const r=function(e){let t;switch(e.arrayFormat){case"index":return(e,r,n)=>{t=/\[(\d*)\]$/.exec(e),e=e.replace(/\[\d*\]$/,""),t?(void 0===n[e]&&(n[e]={}),n[e][t[1]]=r):n[e]=r};case"bracket":return(e,r,n)=>{t=/(\[\])$/.exec(e),e=e.replace(/\[\]$/,""),t?void 0!==n[e]?n[e]=[].concat(n[e],r):n[e]=[r]:n[e]=r};case"comma":case"separator":return(t,r,n)=>{const a="string"==typeof r&&r.includes(e.arrayFormatSeparator),o="string"==typeof r&&!a&&u(r,e).includes(e.arrayFormatSeparator);r=o?u(r,e):r;const s=a||o?r.split(e.arrayFormatSeparator).map((t=>u(t,e))):null===r?r:u(r,e);n[t]=s};case"bracket-separator":return(t,r,n)=>{const a=/(\[\])$/.test(t);if(t=t.replace(/\[\]$/,""),!a)return void(n[t]=r?u(r,e):r);const o=null===r?[]:r.split(e.arrayFormatSeparator).map((t=>u(t,e)));void 0!==n[t]?n[t]=[].concat(n[t],o):n[t]=o};default:return(e,t,r)=>{void 0!==r[e]?r[e]=[].concat(r[e],t):r[e]=t}}}(t),n=Object.create(null);if("string"!=typeof e)return n;if(!(e=e.trim().replace(/^[?#&]/,"")))return n;for(const a of e.split("&")){if(""===a)continue;let[e,s]=o(t.decode?a.replace(/\+/g," "):a,"=");s=void 0===s?null:["comma","separator","bracket-separator"].includes(t.arrayFormat)?s:u(s,t),r(u(e,t),s,n)}for(const a of Object.keys(n)){const e=n[a];if("object"==typeof e&&null!==e)for(const r of Object.keys(e))e[r]=d(e[r],t);else n[a]=d(e,t)}return!1===t.sort?n:(!0===t.sort?Object.keys(n).sort():Object.keys(n).sort(t.sort)).reduce(((e,t)=>{const r=n[t];return Boolean(r)&&"object"==typeof r&&!Array.isArray(r)?e[t]=p(r):e[t]=r,e}),Object.create(null))}t.extract=m,t.parse=g,t.stringify=(e,t)=>{if(!e)return"";i((t=Object.assign({encode:!0,strict:!0,arrayFormat:"none",arrayFormatSeparator:","},t)).arrayFormatSeparator);const r=r=>t.skipNull&&null==e[r]||t.skipEmptyString&&""===e[r],n=function(e){switch(e.arrayFormat){case"index":return t=>(r,n)=>{const a=r.length;return void 0===n||e.skipNull&&null===n||e.skipEmptyString&&""===n?r:null===n?[...r,[l(t,e),"[",a,"]"].join("")]:[...r,[l(t,e),"[",l(a,e),"]=",l(n,e)].join("")]};case"bracket":return t=>(r,n)=>void 0===n||e.skipNull&&null===n||e.skipEmptyString&&""===n?r:null===n?[...r,[l(t,e),"[]"].join("")]:[...r,[l(t,e),"[]=",l(n,e)].join("")];case"comma":case"separator":case"bracket-separator":{const t="bracket-separator"===e.arrayFormat?"[]=":"=";return r=>(n,a)=>void 0===a||e.skipNull&&null===a||e.skipEmptyString&&""===a?n:(a=null===a?"":a,0===n.length?[[l(r,e),t,l(a,e)].join("")]:[[n,l(a,e)].join(e.arrayFormatSeparator)])}default:return t=>(r,n)=>void 0===n||e.skipNull&&null===n||e.skipEmptyString&&""===n?r:null===n?[...r,l(t,e)]:[...r,[l(t,e),"=",l(n,e)].join("")]}}(t),a={};for(const s of Object.keys(e))r(s)||(a[s]=e[s]);const o=Object.keys(a);return!1!==t.sort&&o.sort(t.sort),o.map((r=>{const a=e[r];return void 0===a?"":null===a?l(r,t):Array.isArray(a)?0===a.length&&"bracket-separator"===t.arrayFormat?l(r,t)+"[]":a.reduce(n(r),[]).join("&"):l(r,t)+"="+l(a,t)})).filter((e=>e.length>0)).join("&")},t.parseUrl=(e,t)=>{t=Object.assign({decode:!0},t);const[r,n]=o(e,"#");return Object.assign({url:r.split("?")[0]||"",query:g(m(e),t)},t&&t.parseFragmentIdentifier&&n?{fragmentIdentifier:u(n,t)}:{})},t.stringifyUrl=(e,r)=>{r=Object.assign({encode:!0,strict:!0,[c]:!0},r);const n=f(e.url).split("?")[0]||"",a=t.extract(e.url),o=t.parse(a,{sort:!1}),s=Object.assign(o,e.query);let i=t.stringify(s,r);i&&(i=`?${i}`);let u=function(e){let t="";const r=e.indexOf("#");return-1!==r&&(t=e.slice(r)),t}(e.url);return e.fragmentIdentifier&&(u=`#${r[c]?l(e.fragmentIdentifier,r):e.fragmentIdentifier}`),`${n}${i}${u}`},t.pick=(e,r,n)=>{n=Object.assign({parseFragmentIdentifier:!0,[c]:!1},n);const{url:a,query:o,fragmentIdentifier:i}=t.parseUrl(e,n);return t.stringifyUrl({url:a,query:s(o,r),fragmentIdentifier:i},n)},t.exclude=(e,r,n)=>{const a=Array.isArray(r)?e=>!r.includes(e):(e,t)=>!r(e,t);return t.pick(e,a,n)}},500:function(e){e.exports=(e,t)=>{if("string"!=typeof e||"string"!=typeof t)throw new TypeError("Expected the arguments to be of type `string`");if(""===t)return[e];const r=e.indexOf(t);return-1===r?[e]:[e.slice(0,r),e.slice(r+t.length)]}},610:function(e){e.exports=e=>encodeURIComponent(e).replace(/[!'()*]/g,(e=>`%${e.charCodeAt(0).toString(16).toUpperCase()}`))}}]);