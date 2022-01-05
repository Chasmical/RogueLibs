"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[8741],{3905:function(e,t,n){n.d(t,{Zo:function(){return u},kt:function(){return d}});var r=n(7294);function o(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function a(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(e);t&&(r=r.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,r)}return n}function i(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?a(Object(n),!0).forEach((function(t){o(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):a(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function c(e,t){if(null==e)return{};var n,r,o=function(e,t){if(null==e)return{};var n,r,o={},a=Object.keys(e);for(r=0;r<a.length;r++)n=a[r],t.indexOf(n)>=0||(o[n]=e[n]);return o}(e,t);if(Object.getOwnPropertySymbols){var a=Object.getOwnPropertySymbols(e);for(r=0;r<a.length;r++)n=a[r],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(o[n]=e[n])}return o}var s=r.createContext({}),l=function(e){var t=r.useContext(s),n=t;return e&&(n="function"==typeof e?e(t):i(i({},t),e)),n},u=function(e){var t=l(e.components);return r.createElement(s.Provider,{value:t},e.children)},p={inlineCode:"code",wrapper:function(e){var t=e.children;return r.createElement(r.Fragment,{},t)}},m=r.forwardRef((function(e,t){var n=e.components,o=e.mdxType,a=e.originalType,s=e.parentName,u=c(e,["components","mdxType","originalType","parentName"]),m=l(n),d=o,f=m["".concat(s,".").concat(d)]||m[d]||p[d]||a;return n?r.createElement(f,i(i({ref:t},u),{},{components:n})):r.createElement(f,i({ref:t},u))}));function d(e,t){var n=arguments,o=t&&t.mdxType;if("string"==typeof e||o){var a=n.length,i=new Array(a);i[0]=m;var c={};for(var s in t)hasOwnProperty.call(t,s)&&(c[s]=t[s]);c.originalType=e,c.mdxType="string"==typeof e?e:o,i[1]=c;for(var l=2;l<a;l++)i[l]=n[l];return r.createElement.apply(null,i)}return r.createElement.apply(null,n)}m.displayName="MDXCreateElement"},1016:function(e,t,n){n.d(t,{Z:function(){return c}});var r=n(7462),o=n(3366),a=n(7294),i=["children"];function c(e){var t=e.children,n=(0,o.Z)(e,i);return a.createElement("div",(0,r.Z)({role:"tabpanel"},n),t)}},2099:function(e,t,n){n.d(t,{Z:function(){return m}});var r=n(7294),o=n(9443);var a=function(){var e=(0,r.useContext)(o.Z);if(null==e)throw new Error('"useUserPreferencesContext" is used outside of "Layout" component.');return e},i=n(6010),c="tabItem_OdQc",s="tabItemActive_YQWB",l="tab_tgHH";var u=37,p=39;function m(e){var t=e.lazy,n=e.defaultValue,o=e.values,m=e.groupId,d=a(),f=d.tabGroupChoices,v=d.setTabGroupChoices,b=(0,r.useState)(n),w=b[0],h=b[1],y=r.Children.toArray(e.children),g=[];if(null!=m){var O=f[m];null!=O&&O!==w&&o.some((function(e){return e.value===O}))&&h(O)}var j=function(e){var t=e.currentTarget,n=g.indexOf(t),r=o[n].value;h(r),null!=m&&(v(m,r),setTimeout((function(){var e,n,r,o,a,i,c,l;(e=t.getBoundingClientRect(),n=e.top,r=e.left,o=e.bottom,a=e.right,i=window,c=i.innerHeight,l=i.innerWidth,n>=0&&a<=l&&o<=c&&r>=0)||(t.scrollIntoView({block:"center",behavior:"smooth"}),t.classList.add(s),setTimeout((function(){return t.classList.remove(s)}),2e3))}),150))},k=function(e){var t;switch(e.keyCode){case p:var n=g.indexOf(e.target)+1;t=g[n]||g[0];break;case u:var r=g.indexOf(e.target)-1;t=g[r]||g[g.length-1];break;default:return}t.focus()},x=function(e,t){return t.value===e||t.values&&-1!=t.values.indexOf(e)};return r.createElement("div",{className:"tabs-container"},r.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:"tabs"},o.map((function(e){var t=e.value,n=e.label;return r.createElement("li",{role:"tab",tabIndex:w===t?0:-1,"aria-selected":w===t,className:(0,i.Z)("tabs__item",c,{"tabs__item--active":w===t}),key:t,ref:function(e){return e&&g.push(e)},onKeyDown:k,onFocus:j,onClick:j},n)}))),t?r.cloneElement(y.find((function(e){return x(w,e.props)})),{className:l}):r.createElement("div",null,y.map((function(e,t){return r.cloneElement(e,{key:t,hidden:!x(w,e.props),className:l})}))),r.createElement("br",null))}},3449:function(e,t,n){n.r(t),n.d(t,{frontMatter:function(){return c},contentTitle:function(){return s},metadata:function(){return l},toc:function(){return u},default:function(){return m}});var r=n(7462),o=n(3366),a=(n(7294),n(3905)),i=(n(2099),n(1016),n(4996),["components"]),c={},s="Projectile Weapons*",l={unversionedId:"dev/items/weapons/projectile-weapons",id:"dev/items/weapons/projectile-weapons",title:"Projectile Weapons*",description:"",source:"@site/docs/dev/items/weapons/projectile-weapons.mdx",sourceDirName:"dev/items/weapons",slug:"/dev/items/weapons/projectile-weapons",permalink:"/RogueLibs/docs/dev/items/weapons/projectile-weapons",editUrl:"https://github.com/Abbysssal/RogueLibs/edit/main/website/docs/dev/items/weapons/projectile-weapons.mdx",tags:[],version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"Thrown Weapons*",permalink:"/RogueLibs/docs/dev/items/weapons/thrown-weapons"},next:{title:"Custom Projectiles*",permalink:"/RogueLibs/docs/dev/items/weapons/custom-projectiles"}},u=[],p={toc:u};function m(e){var t=e.components,n=(0,o.Z)(e,i);return(0,a.kt)("wrapper",(0,r.Z)({},p,n,{components:t,mdxType:"MDXLayout"}),(0,a.kt)("h1",{id:"projectile-weapons"},"Projectile Weapons*"),(0,a.kt)("div",{className:"admonition admonition-info alert alert--info"},(0,a.kt)("div",{parentName:"div",className:"admonition-heading"},(0,a.kt)("h5",{parentName:"div"},(0,a.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,a.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,a.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M7 2.3c3.14 0 5.7 2.56 5.7 5.7s-2.56 5.7-5.7 5.7A5.71 5.71 0 0 1 1.3 8c0-3.14 2.56-5.7 5.7-5.7zM7 1C3.14 1 0 4.14 0 8s3.14 7 7 7 7-3.14 7-7-3.14-7-7-7zm1 3H6v5h2V4zm0 6H6v2h2v-2z"}))),"Work-In-Progress")),(0,a.kt)("div",{parentName:"div",className:"admonition-content"})))}m.isMDXComponent=!0}}]);