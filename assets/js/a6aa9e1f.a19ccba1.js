(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[3089],{4428:function(e,t,a){"use strict";a.r(t),a.d(t,{default:function(){return d}});var n=a(7294),r=a(2263),i=a(6165),l=a(4884),o=a(6742),s=a(4973);var c=function(e){var t=e.metadata,a=t.previousPage,r=t.nextPage;return n.createElement("nav",{className:"pagination-nav","aria-label":(0,s.I)({id:"theme.blog.paginator.navAriaLabel",message:"Blog list page navigation",description:"The ARIA label for the blog pagination"})},n.createElement("div",{className:"pagination-nav__item"},a&&n.createElement(o.Z,{className:"pagination-nav__link",to:a},n.createElement("div",{className:"pagination-nav__label"},"\xab"," ",n.createElement(s.Z,{id:"theme.blog.paginator.newerEntries",description:"The label used to navigate to the newer blog posts page (previous page)"},"Newer Entries")))),n.createElement("div",{className:"pagination-nav__item pagination-nav__item--next"},r&&n.createElement(o.Z,{className:"pagination-nav__link",to:r},n.createElement("div",{className:"pagination-nav__label"},n.createElement(s.Z,{id:"theme.blog.paginator.olderEntries",description:"The label used to navigate to the older blog posts page (next page)"},"Older Entries")," ","\xbb"))))},u=a(941);var d=function(e){var t=e.metadata,a=e.items,o=e.sidebar,s=(0,r.Z)().siteConfig.title,d=t.blogDescription,g=t.blogTitle,m="/"===t.permalink?s:g;return n.createElement(i.Z,{title:m,description:d,wrapperClassName:u.kM.wrapper.blogPages,pageClassName:u.kM.page.blogListPage,searchMetadatas:{tag:"blog_posts_list"},sidebar:o},a.map((function(e){var t=e.content;return n.createElement(l.Z,{key:t.metadata.permalink,frontMatter:t.frontMatter,assets:t.assets,metadata:t.metadata,truncated:t.metadata.truncated},n.createElement(t,null))})),n.createElement(c,{metadata:t}))}},5420:function(e,t,a){"use strict";a.d(t,{Do:function(){return o},Xq:function(){return s}});var n=a(7294),r=a(941),i="roguestorage.";function l(){var e=(0,n.useState)(null),t=e[0],a=e[1],l=(0,n.useState)([]),o=l[0],s=(l[1],(0,n.useCallback)((function(e,n){if(null!==t){t[e]=n,(0,r.WA)("roguestorage."+e).set(n),a(t);var i={slotName:e,value:n};o.forEach((function(e){return e(i)}))}}),[t]));return(0,n.useEffect)((function(){var e={};try{(0,r._f)().forEach((function(t){if(t.startsWith(i)){var a=t.substring(i.length),n=(0,r.WA)(t).get();null!==n&&(e[a]=n);var l={slotName:a,value:n};o.forEach((function(e){return e(l)}))}})),a(e)}catch(t){console.error(t)}console.log("Storage set")}),[]),{get:function(e){return a=e,null===t?null:null!=(n=t[a])?n:null;var a,n},set:function(e,t){return s(e,t)},delete:function(e){return function(e){if(null!==t){delete t[e],(0,r.WA)("roguestorage."+e).del(),a(t);var n={slotName:e,value:null};o.forEach((function(e){return e(n)}))}}(e)},subscribe:function(e){return o.push(e)},unsubscribe:function(e){var t=o.indexOf(e);-1!=t&&o.splice(t,1)}}}var o=n.createContext({});function s(e){var t=e.children,a=l();return n.createElement(o.Provider,{key:"storageProvider",value:a},t)}},6627:function(e,t,a){"use strict";a.d(t,{N:function(){return f},Z:function(){return v}});var n=a(2122),r=a(9756),i=a(7294),l=a(6010),o=a(4973),s=a(941),c="enhancedAnchor_3KR1",u="heading_19KT",d="h1Heading_24eg",g=["children"],m=["id"],f=function(e){var t=e.children,a=(0,r.Z)(e,g);return i.createElement("header",null,i.createElement("h1",(0,n.Z)({},a,{id:void 0,className:d}),t))},v=function(e){return"h1"===e?f:(t=e,function(e){var a=e.id,d=(0,r.Z)(e,m),g=(0,s.LU)().navbar.hideOnScroll;return a?i.createElement(t,(0,n.Z)({className:u},d),i.createElement("a",{className:"hash-link",href:"#"+a,title:(0,o.I)({id:"theme.common.headingLinkTitle",message:"Direct link to heading",description:"Title for link to heading"})},"#"),d.children,i.createElement("a",{id:a,"aria-hidden":"true",tabIndex:-1,className:(0,l.Z)("anchor",g||c)})):i.createElement(t,d)});var t}},2024:function(e,t,a){"use strict";a.d(t,{Z:function(){return l}});var n=a(7294),r=a(6482),i=a(5420);function l(e){return n.createElement(i.Xq,null,n.createElement(r.Z,e))}}}]);