"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[3945],{3905:function(e,t,n){n.d(t,{Zo:function(){return l},kt:function(){return d}});var r=n(7294);function o(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function a(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(e);t&&(r=r.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,r)}return n}function i(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?a(Object(n),!0).forEach((function(t){o(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):a(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function c(e,t){if(null==e)return{};var n,r,o=function(e,t){if(null==e)return{};var n,r,o={},a=Object.keys(e);for(r=0;r<a.length;r++)n=a[r],t.indexOf(n)>=0||(o[n]=e[n]);return o}(e,t);if(Object.getOwnPropertySymbols){var a=Object.getOwnPropertySymbols(e);for(r=0;r<a.length;r++)n=a[r],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(o[n]=e[n])}return o}var s=r.createContext({}),u=function(e){var t=r.useContext(s),n=t;return e&&(n="function"==typeof e?e(t):i(i({},t),e)),n},l=function(e){var t=u(e.components);return r.createElement(s.Provider,{value:t},e.children)},m={inlineCode:"code",wrapper:function(e){var t=e.children;return r.createElement(r.Fragment,{},t)}},p=r.forwardRef((function(e,t){var n=e.components,o=e.mdxType,a=e.originalType,s=e.parentName,l=c(e,["components","mdxType","originalType","parentName"]),p=u(n),d=o,f=p["".concat(s,".").concat(d)]||p[d]||m[d]||a;return n?r.createElement(f,i(i({ref:t},l),{},{components:n})):r.createElement(f,i({ref:t},l))}));function d(e,t){var n=arguments,o=t&&t.mdxType;if("string"==typeof e||o){var a=n.length,i=new Array(a);i[0]=p;var c={};for(var s in t)hasOwnProperty.call(t,s)&&(c[s]=t[s]);c.originalType=e,c.mdxType="string"==typeof e?e:o,i[1]=c;for(var u=2;u<a;u++)i[u]=n[u];return r.createElement.apply(null,i)}return r.createElement.apply(null,n)}p.displayName="MDXCreateElement"},1016:function(e,t,n){n.d(t,{Z:function(){return c}});var r=n(7462),o=n(3366),a=n(7294),i=["children"];function c(e){var t=e.children,n=(0,o.Z)(e,i);return a.createElement("div",(0,r.Z)({role:"tabpanel"},n),t)}},2099:function(e,t,n){n.d(t,{Z:function(){return p}});var r=n(7294),o=n(9443);var a=function(){var e=(0,r.useContext)(o.Z);if(null==e)throw new Error('"useUserPreferencesContext" is used outside of "Layout" component.');return e},i=n(6010),c="tabItem_OdQc",s="tabItemActive_YQWB",u="tab_tgHH";var l=37,m=39;function p(e){var t=e.lazy,n=e.defaultValue,o=e.values,p=e.groupId,d=a(),f=d.tabGroupChoices,v=d.setTabGroupChoices,b=(0,r.useState)(n),y=b[0],h=b[1],g=r.Children.toArray(e.children),w=[];if(null!=p){var O=f[p];null!=O&&O!==y&&o.some((function(e){return e.value===O}))&&h(O)}var k=function(e){var t=e.currentTarget,n=w.indexOf(t),r=o[n].value;h(r),null!=p&&(v(p,r),setTimeout((function(){var e,n,r,o,a,i,c,u;(e=t.getBoundingClientRect(),n=e.top,r=e.left,o=e.bottom,a=e.right,i=window,c=i.innerHeight,u=i.innerWidth,n>=0&&a<=u&&o<=c&&r>=0)||(t.scrollIntoView({block:"center",behavior:"smooth"}),t.classList.add(s),setTimeout((function(){return t.classList.remove(s)}),2e3))}),150))},j=function(e){var t;switch(e.keyCode){case m:var n=w.indexOf(e.target)+1;t=w[n]||w[0];break;case l:var r=w.indexOf(e.target)-1;t=w[r]||w[w.length-1];break;default:return}t.focus()},x=function(e,t){return t.value===e||t.values&&-1!=t.values.indexOf(e)};return r.createElement("div",{className:"tabs-container"},r.createElement("ul",{role:"tablist","aria-orientation":"horizontal",className:"tabs"},o.map((function(e){var t=e.value,n=e.label;return r.createElement("li",{role:"tab",tabIndex:y===t?0:-1,"aria-selected":y===t,className:(0,i.Z)("tabs__item",c,{"tabs__item--active":y===t}),key:t,ref:function(e){return e&&w.push(e)},onKeyDown:j,onFocus:k,onClick:k},n)}))),t?r.cloneElement(g.find((function(e){return x(y,e.props)})),{className:u}):r.createElement("div",null,g.map((function(e,t){return r.cloneElement(e,{key:t,hidden:!x(y,e.props),className:u})}))),r.createElement("br",null))}},3436:function(e,t,n){n.r(t),n.d(t,{frontMatter:function(){return c},contentTitle:function(){return s},metadata:function(){return u},toc:function(){return l},default:function(){return p}});var r=n(7462),o=n(3366),a=(n(7294),n(3905)),i=(n(2099),n(1016),n(4996),["components"]),c={},s="Custom Projectiles*",u={unversionedId:"dev/items/weapons/custom-projectiles",id:"dev/items/weapons/custom-projectiles",title:"Custom Projectiles*",description:"",source:"@site/docs/dev/items/weapons/custom-projectiles.mdx",sourceDirName:"dev/items/weapons",slug:"/dev/items/weapons/custom-projectiles",permalink:"/RogueLibs/docs/dev/items/weapons/custom-projectiles",editUrl:"https://github.com/Abbysssal/RogueLibs/edit/main/website/docs/dev/items/weapons/custom-projectiles.mdx",tags:[],version:"current",frontMatter:{},sidebar:"documentationSidebar",previous:{title:"Projectile Weapons*",permalink:"/RogueLibs/docs/dev/items/weapons/projectile-weapons"},next:{title:"Inventory Checks",permalink:"/RogueLibs/docs/dev/items/inventory-checks"}},l=[],m={toc:l};function p(e){var t=e.components,n=(0,o.Z)(e,i);return(0,a.kt)("wrapper",(0,r.Z)({},m,n,{components:t,mdxType:"MDXLayout"}),(0,a.kt)("h1",{id:"custom-projectiles"},"Custom Projectiles*"),(0,a.kt)("div",{className:"admonition admonition-info alert alert--info"},(0,a.kt)("div",{parentName:"div",className:"admonition-heading"},(0,a.kt)("h5",{parentName:"div"},(0,a.kt)("span",{parentName:"h5",className:"admonition-icon"},(0,a.kt)("svg",{parentName:"span",xmlns:"http://www.w3.org/2000/svg",width:"14",height:"16",viewBox:"0 0 14 16"},(0,a.kt)("path",{parentName:"svg",fillRule:"evenodd",d:"M7 2.3c3.14 0 5.7 2.56 5.7 5.7s-2.56 5.7-5.7 5.7A5.71 5.71 0 0 1 1.3 8c0-3.14 2.56-5.7 5.7-5.7zM7 1C3.14 1 0 4.14 0 8s3.14 7 7 7 7-3.14 7-7-3.14-7-7-7zm1 3H6v5h2V4zm0 6H6v2h2v-2z"}))),"Work-In-Progress")),(0,a.kt)("div",{parentName:"div",className:"admonition-content"})))}p.isMDXComponent=!0}}]);