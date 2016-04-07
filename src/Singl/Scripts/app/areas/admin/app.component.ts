/// <reference path="../../../../node_modules/angular2/core.d.ts" />

import {Component, Inject, OnInit} from 'angular2/core';
import {Location, Router, RouteConfig, ROUTER_DIRECTIVES, AsyncRoute} from 'angular2/router';



declare var System: any;

@Component({
    selector: 'singl-admin-app',
    templateUrl: 'app/areas/singl/app.component.html',
    directives: [ROUTER_DIRECTIVES],
    //styleUrls: ['./css/animate.css', './css/home.css']
})
@RouteConfig([
    new AsyncRoute({ useAsDefault: true, path: '/', name: 'Home', loader: () => System.import('./app/areas/admin/home.component').then(m => m.HomeComponent) }),
    new AsyncRoute({ path: '/templates', name: 'Template', loader: () => System.import('./app/areas/admin/template-component').then(m => m.TemplateComponent) }),
])
export class AppComponent {

  
}