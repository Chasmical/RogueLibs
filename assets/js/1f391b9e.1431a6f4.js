(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[85],{6159:function(e,n,t){"use strict";t.d(n,{N:function(){return f},Z:function(){return m}});var r=t(9756),a=t(2122),l=t(7294),c=t(6010),i=t(4973),u=t(3018),o="enhancedAnchor_2LWZ",s="h1Heading_27L5",d=["id"],f=function(e){var n=Object.assign({},e);return l.createElement("header",null,l.createElement("h1",(0,a.Z)({},n,{id:void 0,className:s}),n.children))},m=function(e){return"h1"===e?f:(n=e,function(e){var t,a=e.id,s=(0,r.Z)(e,d),f=(0,u.LU)().navbar.hideOnScroll;return a?l.createElement(n,s,l.createElement("a",{"aria-hidden":"true",tabIndex:-1,className:(0,c.Z)("anchor",(t={},t[o]=!f,t)),id:a}),s.children,l.createElement("a",{className:"hash-link",href:"#"+a,title:(0,i.I)({id:"theme.common.headingLinkTitle",message:"Direct link to heading",description:"Title for link to heading"})},"#")):l.createElement(n,s)});var n}},2238:function(e,n,t){"use strict";t.d(n,{Z:function(){return f}});var r=t(2122),a=t(7294),l=t(6742),c=t(1756),i=t(6159),u=t(6010),o=t(3018),s="details_1VDD";function d(e){var n=Object.assign({},e);return a.createElement(o.PO,(0,r.Z)({},n,{className:(0,u.Z)("alert alert--info",s,n.className)}))}var f={code:function(e){var n=e.children;return(0,a.isValidElement)(n)?n:n.includes("\n")?a.createElement(c.Z,e):a.createElement("code",e)},a:function(e){return a.createElement(l.Z,e)},pre:function(e){var n,t=e.children;return(0,a.isValidElement)(null==t||null==(n=t.props)?void 0:n.children)?null==t?void 0:t.props.children:a.createElement(c.Z,(0,a.isValidElement)(t)?null==t?void 0:t.props:Object.assign({},e))},details:function(e){var n=a.Children.toArray(e.children),t=n.find((function(e){var n;return"summary"===(null==e||null==(n=e.props)?void 0:n.mdxType)})),l=a.createElement(a.Fragment,null,n.filter((function(e){return e!==t})));return a.createElement(d,(0,r.Z)({},e,{summary:t}),l)},h1:(0,i.Z)("h1"),h2:(0,i.Z)("h2"),h3:(0,i.Z)("h3"),h4:(0,i.Z)("h4"),h5:(0,i.Z)("h5"),h6:(0,i.Z)("h6")}},7979:function(e,n,t){"use strict";t.r(n),t.d(n,{default:function(){return d}});var r=t(7294),a=t(6010),l=t(5194),c=t(3905),i=t(2238),u=t(571),o=t(3018),s="mdxPageWrapper_3qD3";var d=function(e){var n=e.content,t=n.frontMatter,d=n.metadata,f=t.title,m=t.description,v=t.wrapperClassName,h=t.hide_table_of_contents,E=d.permalink;return r.createElement(l.Z,{title:f,description:m,permalink:E,wrapperClassName:null!=v?v:o.kM.wrapper.mdxPages,pageClassName:o.kM.page.mdxPage},r.createElement("main",{className:"container container--fluid margin-vert--lg"},r.createElement("div",{className:(0,a.Z)("row",s)},r.createElement("div",{className:(0,a.Z)("col",!h&&"col--8")},r.createElement(c.Zo,{components:i.Z},r.createElement(n,null))),!h&&n.toc&&r.createElement("div",{className:"col col--2"},r.createElement(u.Z,{toc:n.toc})))))}},571:function(e,n,t){"use strict";t.d(n,{r:function(){return u},Z:function(){return o}});var r=t(7294),a=t(6010);var l=function(e,n,t){var a=(0,r.useState)(void 0),l=a[0],c=a[1];(0,r.useEffect)((function(){function r(){var r=function(){var e=Array.from(document.getElementsByClassName("anchor")),n=e.find((function(e){return e.getBoundingClientRect().top>=t}));if(n){if(n.getBoundingClientRect().top>=t){var r=e[e.indexOf(n)-1];return null!=r?r:n}return n}return e[e.length-1]}();if(r)for(var a=0,i=!1,u=document.getElementsByClassName(e);a<u.length&&!i;){var o=u[a],s=o.href,d=decodeURIComponent(s.substring(s.indexOf("#")+1));r.id===d&&(l&&l.classList.remove(n),o.classList.add(n),c(o),i=!0),a+=1}}return document.addEventListener("scroll",r),document.addEventListener("resize",r),r(),function(){document.removeEventListener("scroll",r),document.removeEventListener("resize",r)}}))},c="tableOfContents_35-E",i="table-of-contents__link";function u(e){var n=e.toc,t=e.isChild;return n.length?r.createElement("ul",{className:t?"":"table-of-contents table-of-contents__left-border"},n.map((function(e){return r.createElement("li",{key:e.id},r.createElement("a",{href:"#"+e.id,className:i,dangerouslySetInnerHTML:{__html:e.value}}),r.createElement(u,{isChild:!0,toc:e.children}))}))):null}var o=function(e){var n=e.toc;return l(i,"table-of-contents__link--active",100),r.createElement("div",{className:(0,a.Z)(c,"thin-scrollbar")},r.createElement(u,{toc:n}))}},5420:function(e,n,t){"use strict";t.d(n,{Do:function(){return i},Xq:function(){return u}});var r=t(7294),a=t(3018),l="roguestorage.";function c(){var e=(0,r.useState)(null),n=e[0],t=e[1],c=(0,r.useState)([]),i=c[0],u=(c[1],(0,r.useCallback)((function(e,r){if(null!==n){n[e]=r,(0,a.WA)("roguestorage."+e).set(r),t(n);var l={slotName:e,value:r};i.forEach((function(e){return e(l)}))}}),[n]));return(0,r.useEffect)((function(){var e={};try{(0,a._f)().forEach((function(n){if(n.startsWith(l)){var t=n.substring(l.length),r=(0,a.WA)(n).get();null!==r&&(e[t]=r)}})),t(e)}catch(n){console.error(n)}console.log("Storage set")}),[]),{get:function(e){return t=e,null===n?null:null!=(r=n[t])?r:null;var t,r},set:function(e,n){return u(e,n)},delete:function(e){return function(e){if(null!==n){delete n[e],(0,a.WA)("roguestorage."+e).del(),t(n);var r={slotName:e,value:null};i.forEach((function(e){return e(r)}))}}(e)},subscribe:function(e){return i.push(e)},unsubscribe:function(e){var n=i.indexOf(e);-1!=n&&i.splice(n,1)}}}var i=r.createContext({});function u(e){var n=e.children,t=c();return r.createElement(i.Provider,{value:t},n)}},2024:function(e,n,t){"use strict";t.d(n,{Z:function(){return c}});var r=t(7294),a=t(6482),l=t(5420);function c(e){return r.createElement(l.Xq,null,r.createElement(a.Z,e))}}}]);