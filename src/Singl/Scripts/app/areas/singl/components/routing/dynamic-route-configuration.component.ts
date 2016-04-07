/// <reference path="../../../../../../node_modules/reflect-metadata/reflect-metadata.d.ts"/>

import {Type, Injectable, Input, Component, ViewEncapsulation} from 'angular2/core';
import {
    RouteConfig,
    ROUTER_DIRECTIVES,
    RouteRegistry,
    AsyncRoute
} from 'angular2/router';

import {AppComponent} from '../../app.component'
import {componentProxyFactory} from '../../component-proxy';

import {InstituicaoHomeComponent} from '../../home/instituicao-home.component';
declare var System: any;

@Injectable()
export class DynamicRouteConfigurator {

    constructor(private registry: RouteRegistry) { }

    addRoute(component: Type, route) {
        
        //touching private api - bad things can happen
        this.registry['_rules'].forEach(m => {
            // console.log('m.rules 1');
            // m.rules.forEach(x => console.log(x));
            // console.log('---');
            // m.rulesByName.forEach(x => console.log(x));
            for (var i = 0; i < m.rules.length; i++) {
                if (m.rules[i]._routePath.routePath === route.Path) {
                    // console.log('===', m.rules[i]._routePath.routePath, route.Path);
                    (m.rules as []).splice(i, 1);
                }
            }            
            m.rulesByName.delete(route.Name);
            // console.log('m.rules 2');
            // m.rules.forEach(x => console.log(x));
            // console.log('---');
            // m.rulesByName.forEach(x => console.log(x));
            
        });

        let routeConfig = this.getRoutes(component);
        // let r = routeConfig.configs.filter(x => x.name === route.Name);

        // if (r.length > 0) 
        // {
        //     console.log('fuuuuuuu');

        //     return;
        // }

        // console.log('ComponentHelper.LoadComponentAsync');
        // console.log(ComponentHelper.LoadComponentAsync('InstituicaoHomeComponent', './app/areas/singl/home/instituicao-home.component'));

        // console.log(route.Component, route.ComponentPath);
        
         let localRoute = new AsyncRoute ({path: route.Path, name: route.Name, data: {templateUrl: `/api/templates/${route.Name}`},
             loader:  () => ComponentHelper.LoadComponentAsync(route.Component, route.ComponentPath)});        

        // let localRoute =
        //     {
        //         path: route.Path, name: route.Name,
        //         component: componentProxyFactory({
        //             path: route.ComponentPath,
        //             provide: m => m[route.Loader]
        //         })
        //     };
        routeConfig.configs.push(localRoute);

        this.registry.config(component, localRoute);
        this.updateRouteConfig(component, routeConfig);
        
        //component.templateUrl = '/api/dynamiccomponents/bla';
        //
        
        // this.registry['_rules'].forEach(m => {
        //     console.log('m.rules 3');
        //     m.rules.forEach(x => console.log(x));
        //     console.log('---');
        //     m.rulesByName.forEach(x => console.log(x));
            
        // });        
        
        // console.log(this.getRoutes(component));
         
    }

    removeRoute() {
        // need to touch private APIs - bad
    }

    getRoutes(component: Type) {
        return Reflect.getMetadata('annotations', component)
            .filter(a => {
                return a.constructor.name === 'RouteConfig';
            }).pop();
    }

    updateRouteConfig(component: Type, routeConfig) {
        let annotations = Reflect.getMetadata('annotations', component);
        let routeConfigIndex = -1;
        for (let i = 0; i < annotations.length; i++) {
            if (annotations[i].constructor.name === 'RouteConfig') {
                routeConfigIndex = i;
                break;
            }
        }
        if (routeConfigIndex < 0) {
            throw new Error('No route metadata attached to the component');
        }
        annotations[routeConfigIndex] = routeConfig;
        Reflect.defineMetadata('annotations', annotations, AppComponent);
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

    static LoadComponentAsync(name, path) {
        return System.import(path).then(m => m[name]);
    }
}