(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[6103],{4147:function(e,t,n){"use strict";n.r(t),n.d(t,{default:function(){return m}});var a=n(7294),r=n(1217),i=n(6165),l=n(4884),o=n(4973),c=n(6742);var s=function(e){var t=e.nextItem,n=e.prevItem;return a.createElement("nav",{className:"pagination-nav docusaurus-mt-lg","aria-label":(0,o.I)({id:"theme.blog.post.paginator.navAriaLabel",message:"Blog post page navigation",description:"The ARIA label for the blog posts pagination"})},a.createElement("div",{className:"pagination-nav__item"},n&&a.createElement(c.Z,{className:"pagination-nav__link",to:n.permalink},a.createElement("div",{className:"pagination-nav__sublabel"},a.createElement(o.Z,{id:"theme.blog.post.paginator.newerPost",description:"The blog post button label to navigate to the newer/previous post"},"Newer Post")),a.createElement("div",{className:"pagination-nav__label"},"\xab ",n.title))),a.createElement("div",{className:"pagination-nav__item pagination-nav__item--next"},t&&a.createElement(c.Z,{className:"pagination-nav__link",to:t.permalink},a.createElement("div",{className:"pagination-nav__sublabel"},a.createElement(o.Z,{id:"theme.blog.post.paginator.olderPost",description:"The blog post button label to navigate to the older/next post"},"Older Post")),a.createElement("div",{className:"pagination-nav__label"},t.title," \xbb"))))},u=n(941);var m=function(e){var t,n=e.content,o=e.sidebar,c=n.frontMatter,m=n.assets,g=n.metadata,d=g.title,p=g.description,v=g.nextItem,f=g.prevItem,h=g.date,b=g.tags,E=g.authors,_=c.hide_table_of_contents,N=c.keywords,k=null!=(t=m.image)?t:c.image;return a.createElement(i.Z,{wrapperClassName:u.kM.wrapper.blogPages,pageClassName:u.kM.page.blogPostPage,sidebar:o,toc:!_&&n.toc?n.toc:void 0},a.createElement(r.Z,{title:d,description:p,keywords:N,image:k},a.createElement("meta",{property:"og:type",content:"article"}),a.createElement("meta",{property:"article:published_time",content:h}),E.some((function(e){return e.url}))&&a.createElement("meta",{property:"article:author",content:E.map((function(e){return e.url})).filter(Boolean).join(",")}),b.length>0&&a.createElement("meta",{property:"article:tag",content:b.map((function(e){return e.label})).join(",")})),a.createElement(l.Z,{frontMatter:c,assets:m,metadata:g,isBlogPostPage:!0},a.createElement(n,null)),(v||f)&&a.createElement(s,{nextItem:v,prevItem:f}))}},5420:function(e,t,n){"use strict";n.d(t,{Do:function(){return o},Xq:function(){return c}});var a=n(7294),r=n(941),i="roguestorage.";function l(){var e=(0,a.useState)(null),t=e[0],n=e[1],l=(0,a.useState)([]),o=l[0],c=(l[1],(0,a.useCallback)((function(e,a){if(null!==t){t[e]=a,(0,r.WA)("roguestorage."+e).set(a),n(t);var i={slotName:e,value:a};o.forEach((function(e){return e(i)}))}}),[t]));return(0,a.useEffect)((function(){var e={};try{(0,r._f)().forEach((function(t){if(t.startsWith(i)){var n=t.substring(i.length),a=(0,r.WA)(t).get();null!==a&&(e[n]=a);var l={slotName:n,value:a};o.forEach((function(e){return e(l)}))}})),n(e)}catch(t){console.error(t)}console.log("Storage set")}),[]),{get:function(e){return n=e,null===t?null:null!=(a=t[n])?a:null;var n,a},set:function(e,t){return c(e,t)},delete:function(e){return function(e){if(null!==t){delete t[e],(0,r.WA)("roguestorage."+e).del(),n(t);var a={slotName:e,value:null};o.forEach((function(e){return e(a)}))}}(e)},subscribe:function(e){return o.push(e)},unsubscribe:function(e){var t=o.indexOf(e);-1!=t&&o.splice(t,1)}}}var o=a.createContext({});function c(e){var t=e.children,n=l();return a.createElement(o.Provider,{key:"storageProvider",value:n},t)}},6627:function(e,t,n){"use strict";n.d(t,{N:function(){return p},Z:function(){return v}});var a=n(2122),r=n(9756),i=n(7294),l=n(6010),o=n(4973),c=n(941),s="enhancedAnchor_3KR1",u="heading_19KT",m="h1Heading_24eg",g=["children"],d=["id"],p=function(e){var t=e.children,n=(0,r.Z)(e,g);return i.createElement("header",null,i.createElement("h1",(0,a.Z)({},n,{id:void 0,className:m}),t))},v=function(e){return"h1"===e?p:(t=e,function(e){var n=e.id,m=(0,r.Z)(e,d),g=(0,c.LU)().navbar.hideOnScroll;return n?i.createElement(t,(0,a.Z)({className:u},m),i.createElement("a",{className:"hash-link",href:"#"+n,title:(0,o.I)({id:"theme.common.headingLinkTitle",message:"Direct link to heading",description:"Title for link to heading"})},"#"),m.children,i.createElement("a",{id:n,"aria-hidden":"true",tabIndex:-1,className:(0,l.Z)("anchor",g||s)})):i.createElement(t,m)});var t}},2024:function(e,t,n){"use strict";n.d(t,{Z:function(){return l}});var a=n(7294),r=n(6482),i=n(5420);function l(e){return a.createElement(i.Xq,null,a.createElement(r.Z,e))}}}]);