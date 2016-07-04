/// <reference path="../../../../node_modules/angular2/core.d.ts" />

import {Component, Inject, OnInit} from 'angular2/core';
import {Location, Router, RouteConfig, ROUTER_DIRECTIVES, AsyncRoute} from 'angular2/router';
import {TemplateFormComponent} from './forms/template-form.component';
import {CidadeFormComponent} from './forms/cidade-form.component';
import {FileUploadFormComponent} from './forms/file-upload-form.component';


declare var System: any;

@Component({
    selector: 'singl-admin-app',
    templateUrl: 'app/areas/admin/app.component.html',
    directives: [ROUTER_DIRECTIVES],
    //styleUrls: ['./css/animate.css', './css/home.css']
})
@RouteConfig([
    new AsyncRoute({ useAsDefault: true, path: '/', name: 'Home', loader: () => System.import('./app/areas/admin/home.component').then(m => m.HomeComponent) }),
    new AsyncRoute({ path: '/templates', name: 'TemplateForm', loader: () => System.import('./app/areas/admin/forms/template-form.component').then(m => m.TemplateFormComponent) }),
    new AsyncRoute({ path: '/cidades2', name: 'CidadeForm', loader: () => System.import('./app/areas/admin/forms/cidade-form.component').then(m => m.CidadeFormComponent) }),
    new AsyncRoute({ path: '/upload', name: 'FileUploadForm', loader: () => System.import('./app/areas/admin/forms/file-upload-form.component').then(m => m.FileUploadFormComponent) }),
    new AsyncRoute({ path: '/login', name: 'Login', loader: () => System.import('./app/areas/admin/components/login.component').then(m => m.LoginComponent) }),
])
export class AppComponent {

  
}