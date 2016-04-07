// /// <reference path="../../../../../typings/jquery/jquery.d.ts" />

import {Component, OnInit} from 'angular2/core';
import {RouteParams, Router, CanActivate, ROUTER_DIRECTIVES} from 'angular2/router';
import {Observable} from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/share';
import 'rxjs/Rx';

//declare var jQuery:JQueryStatic;

// <link asp-append-version="true" rel="stylesheet" href="/css/animate.css" />
// <link asp-append-version="true" rel="stylesheet" href="/css/home.css" />


@Component({
    selector: 'home',
    templateUrl: 'app/areas/admin/home.component.html',
    directives: [ROUTER_DIRECTIVES],
    styleUrls: ['./css/home.css']
})
export class HomeComponent implements OnInit {

    constructor(
        public router: Router,
        public routeParams: RouteParams
    ) { }

    ngOnInit() {
        
    }

}