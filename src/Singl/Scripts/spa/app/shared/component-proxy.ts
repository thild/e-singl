import {Component, DynamicComponentLoader, Injector, bind, Type, ElementRef} from '@angular/core';

export class ComponentProvider {
  path:string;
  provide:{(module:any):any};
}

const PROXY_CLASSNAME = 'component-wrapper';
const PROXY_SELECTOR = `.${PROXY_CLASSNAME}`;

declare var System:any;

export function componentProxyFactory(provider:ComponentProvider):Type {
  @Component({
    selector: 'component-proxy',
    providers: [bind(ComponentProvider).toValue(provider)],
    template: `<div #content></div>`
  })
  class VirtualComponent {
    constructor(
      el: ElementRef,
      loader:DynamicComponentLoader,
      inj:Injector,
      provider:ComponentProvider) {
        System.import(provider.path)
        .then(m => {
          loader.loadAsRoot(provider.provide(m), el, inj);
        });
      }
  }

  return VirtualComponent;
}
