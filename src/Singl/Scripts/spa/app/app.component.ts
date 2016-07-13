import {Component, Inject, OnInit} from '@angular/core';
import { ROUTER_DIRECTIVES, Router, 
         ActivatedRoute, Resolve,
         ActivatedRouteSnapshot,
         RouterStateSnapshot } from '@angular/router';
import { LocationStrategy, Location, PlatformLocation } from '@angular/common';

import {Observable} from 'rxjs/Observable';

import {HomeComponent} from './+home';

import {HistoryNavigationComponent,  
        AppNav, DynamicRouteConfigurator, RoutesService, ModelListComponent} from './shared';

declare var System: any;

@Component({
    moduleId: module.id,
    selector: 'singl-app',
    templateUrl: 'app.component.html',
    directives: [HistoryNavigationComponent, ROUTER_DIRECTIVES,
        AppNav],
    //styleUrls: ['./css/animate.css', './css/home.css']
})
export class AppComponent implements OnInit, Resolve<any> {

    //https://github.com/angular/angular/issues/4735
    //https://auth0.com/blog/2016/01/25/angular-2-series-part-4-component-router-in-depth/
    //ver autoscroll igual angular1
    hashHack = true;
    private static appRoutes: any[]; 
    private static navRoutes: any[];
    private static isInitialized: boolean = false;

    isInitialized(): boolean {
        return AppComponent.isInitialized;
    }

    constructor(public router: Router, private location: PlatformLocation,
        private dynamicRouteConfigurator: DynamicRouteConfigurator,
        private route: ActivatedRoute,
        private service: RoutesService) {
            console.log('app ctor');
            
        // router.events.subscribe(
        //     url => {
        //         this.resolveHashURL(locationStrategy);
        //     }
        // );
    }

    // private getAppRoutes(): string[][] {
    //     return this.dynamicRouteConfigurator
    //         .getRoutes(this.constructor).configs.map(route => {
    //             return { path: [`/${route.as}`], name: route.as };
    //         });
    // }

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): any {
      
    }    

    getNavRoutes(): any[] {
        return AppComponent.navRoutes;
    }

    ngOnInit() {
        
        console.log("app ngOnInit");
        
        if (AppComponent.isInitialized) {
            return;
        };

        if (AppComponent.navRoutes == null) {
            this.service.navRoutesObervable$.subscribe(m => {
                AppComponent.navRoutes = m;
                AppComponent.isInitialized = true;
            });
            this.service.getNavRoutes();
        }
        if (AppComponent.appRoutes == null) {
        console.log("app appRoutes");
            
            this.service.dynamicRoutesObervable$.subscribe(m => {
                AppComponent.appRoutes = m;
                //console.log('dynamicRouteConfigurator');
                //console.log(this.router['config']);
                
                this.dynamicRouteConfigurator.addRoutes(AppComponent.appRoutes);
                AppComponent.isInitialized = true;
                console.log('this.location.pathname', this.location.pathname);
                console.log('app this.router[\'config\']');
                console.log(this.router['config']);

                this.router.navigateByUrl(this.location.pathname).then(
                    m => 
                        {
                             console.log("navegou");
                            
                            AppComponent.isInitialized = true;
                        }
                );
            });
            this.service.getDynamicRoutes();
        }        
       
    }

    // resolveHashURL(locationStrategy: LocationStrategy) {
    //     let hash = locationStrategy.platformStrategy._platformLocation.hash;
    //     if (hash) {
    //         let path = hash.substring(1);
    //         this.hashHack = false;
    //     }
    //     else {
    //         if (this.hashHack) {
    //             window.scrollTo(0, 0);
    //         }
    //         this.hashHack = true;
    //     }
    // }
}


