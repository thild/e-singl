
import { CanActivate, Router, ROUTER_DIRECTIVES,
  ActivatedRoute, Resolve,
  ActivatedRouteSnapshot,
  RouterStateSnapshot } from '@angular/router';

import { LocationStrategy, Location, PlatformLocation } from '@angular/common';
import {Component, Injectable, OnInit } from '@angular/core';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/delay';

import { RoutesService }   from './';





import {DynamicRouteConfigurator} from './';

@Injectable()
export class AuthService {
  isLoggedIn: boolean = false;

  login() {
    return Observable.of(true).delay(1000).do(val => this.isLoggedIn = true);
  }

  logout() {
    this.isLoggedIn = false;
  }
}



@Injectable()
export class RouteGuard implements CanActivate {
  constructor(private routesService: RoutesService, private router: Router) { }

  canActivate() {
    console.log('this.routesService.routesResolved()');
    console.log(this.routesService.routesResolved());
    return this.routesService.routesResolved();
  }
}

@Component({
    moduleId: module.id,
    selector: 'dynamic-route',
    template: 'DynamicRouteComponent',
    directives: [ROUTER_DIRECTIVES]
})
export class DynamicRouteComponent implements OnInit, Resolve<any> {

  constructor(public router: Router, private location: PlatformLocation,
    private dynamicRouteConfigurator: DynamicRouteConfigurator,
    private route: ActivatedRoute,
    private service: RoutesService) {
    console.log('DynamicRouteComponent ctor');

    // router.events.subscribe(
    //     url => {
    //         this.resolveHashURL(locationStrategy);
    //     }
    // );
  }

  private static appRoutes: any[];
  private static isInitialized: boolean = false;


  ngOnInit() {
    if (DynamicRouteComponent.appRoutes == null) {
      this.service.dynamicRoutesObervable$.subscribe(m => {
        DynamicRouteComponent.appRoutes = m;
        //console.log('dynamicRouteConfigurator');
        this.dynamicRouteConfigurator.addRoutes(DynamicRouteComponent.appRoutes);
        DynamicRouteComponent.isInitialized = true;
        console.log("this.location.path()");
        console.log(this.location.pathname);
        console.log(this.route.url);

        //console.log(this.router['config']);

        this.router.navigateByUrl(this.location.pathname).then(
          m => {
            console.log("navegou");

            DynamicRouteComponent.isInitialized = true;
          }
        );
      });
      this.service.getDynamicRoutes();
    }
  }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): any {

  }

}