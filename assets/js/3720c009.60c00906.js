(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[3751],{3578:function(e,t,n){"use strict";n.r(t);var r=n(7294),a=n(9040),u=n(941),c=n(6584);t.default=function(e){var t=e.tags,n=(0,u.MA)();return r.createElement(a.Z,{title:n,wrapperClassName:u.kM.wrapper.docsPages,pageClassName:u.kM.page.docsTagsListPage,searchMetadatas:{tag:"doc_tags_list"}},r.createElement("div",{className:"container margin-vert--lg"},r.createElement("div",{className:"row"},r.createElement("main",{className:"col col--8 col--offset-2"},r.createElement("h1",null,n),r.createElement(c.Z,{tags:t})))))}},7211:function(e,t,n){"use strict";n.d(t,{Z:function(){return o}});var r=n(7294),a=n(6010),u=n(6742),c="tag_1Okp",l="tagRegular_3MiF",s="tagWithCount_1HU1";var o=function(e){var t,n=e.permalink,o=e.name,i=e.count;return r.createElement(u.Z,{href:n,className:(0,a.Z)(c,(t={},t[l]=!i,t[s]=i,t))},o,i&&r.createElement("span",null,i))}},6584:function(e,t,n){"use strict";n.d(t,{Z:function(){return s}});var r=n(7294),a=n(7211),u=n(941),c="tag_21yA";function l(e){var t=e.letterEntry;return r.createElement("article",null,r.createElement("h2",null,t.letter),r.createElement("ul",{className:"padding--none"},t.tags.map((function(e){return r.createElement("li",{key:e.permalink,className:c},r.createElement(a.Z,e))}))),r.createElement("hr",null))}var s=function(e){var t=e.tags,n=(0,u.PZ)(t);return r.createElement("section",{className:"margin-vert--lg"},n.map((function(e){return r.createElement(l,{key:e.letter,letterEntry:e})})))}},2924:function(e,t,n){"use strict";var r=n(7294).createContext(void 0);t.Z=r},5350:function(e,t,n){"use strict";var r=n(7294),a=n(2924);t.Z=function(){var e=(0,r.useContext)(a.Z);if(null==e)throw new Error('"useThemeContext" is used outside of "Layout" component. Please see https://docusaurus.io/docs/api/themes/configuration#usethemecontext.');return e}},5420:function(e,t,n){"use strict";n.d(t,{Do:function(){return l},Xq:function(){return s}});var r=n(7294),a=n(941),u="roguestorage.";function c(){var e=(0,r.useState)(null),t=e[0],n=e[1],c=(0,r.useState)([]),l=c[0],s=(c[1],(0,r.useCallback)((function(e,r){if(null!==t){t[e]=r,(0,a.WA)("roguestorage."+e).set(r),n(t);var u={slotName:e,value:r};l.forEach((function(e){return e(u)}))}}),[t]));return(0,r.useEffect)((function(){var e={};try{(0,a._f)().forEach((function(t){if(t.startsWith(u)){var n=t.substring(u.length),r=(0,a.WA)(t).get();null!==r&&(e[n]=r);var c={slotName:n,value:r};l.forEach((function(e){return e(c)}))}})),n(e)}catch(t){console.error(t)}console.log("Storage set")}),[]),{get:function(e){return n=e,null===t?null:null!=(r=t[n])?r:null;var n,r},set:function(e,t){return s(e,t)},delete:function(e){return function(e){if(null!==t){delete t[e],(0,a.WA)("roguestorage."+e).del(),n(t);var r={slotName:e,value:null};l.forEach((function(e){return e(r)}))}}(e)},subscribe:function(e){return l.push(e)},unsubscribe:function(e){var t=l.indexOf(e);-1!=t&&l.splice(t,1)}}}var l=r.createContext({});function s(e){var t=e.children,n=c();return r.createElement(l.Provider,{key:"storageProvider",value:n},t)}},2024:function(e,t,n){"use strict";n.d(t,{Z:function(){return c}});var r=n(7294),a=n(6482),u=n(5420);function c(e){return r.createElement(u.Xq,null,r.createElement(a.Z,e))}}}]);