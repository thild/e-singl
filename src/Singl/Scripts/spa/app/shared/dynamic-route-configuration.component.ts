import {Type, Injectable, Input, Component, ViewEncapsulation, ComponentResolver} from '@angular/core';
import {
    ActivatedRoute,
    Route,
    Router,
    ROUTER_DIRECTIVES,
    RouterConfig
} from '@angular/router';

import {AppComponent} from '../app.component'
import {DynamicComponent} from './';

import {InstituicaoHomeComponent} from '../+instituicao';
declare var System: any;

@Injectable()
export class DynamicRouteConfigurator {

    constructor(private router: Router,
        private resolver: ComponentResolver) { }

    addRoutes(newRoutes: Array<any>) {
        //console.log('addRoutes');
        let routes = this.router['config'] as RouterConfig;
        //console.log(routes);
        //console.log(newRoutes);
        newRoutes.forEach(route => {
            for (var i = 0; i < routes.length; i++) {
                if (routes[i].path === route.path) {
                    routes.splice(i, 1);
                }
            }
            let localRoute = {
                path: route.path,
                data: { templateUrl: `/api/templates/${route.path}` },
                component: DynamicComponent,
                children: []
            };
            let cf = ComponentHelper.LoadComponentAsync(route.component, route.componentPath, this.resolver);
            cf.then(value => localRoute.component = value)
            routes.push(localRoute);
        });
        //console.log('antes resetConfig');
        let i = routes.findIndex((value) => value.path == '**');
        let dynamicRoute = routes[i];
        routes.splice(i, 1);
        routes.push(dynamicRoute);

        this.router.resetConfig(routes);
        //console.log('depois resetConfig');

    }

    removeRoute() {
        // need to touch private APIs - bad
    }

    getRoutes(component: Type) {

    }

    updateRouteConfig(component: Type, routeConfig) {

    }
}

class InstanceLoader {
    static getInstance<T>(context: Object, name: string, ...args: any[]): T {
        var instance = Object.create(context[name].prototype);
        instance.constructor.apply(instance, args);
        return <T>instance;
    }
}


class ComponentHelper {

    static LoadComponentAsync(name, path, resolver: ComponentResolver) {
        let type: Type;
        let cf = System.import(path).then(component => component[name])
            .then(component => resolver.resolveComponent(component)
                .then(factory => factory.componentType)
            );
        return cf;
    }

}