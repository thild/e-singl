// /// <reference path="../../../../../typings/jquery/jquery.d.ts" />

import {Component, OnInit} from 'angular2/core';
import {SetorAdministrativoService}   from './../setor-administrativo.service';
import {InstituicaoService}   from './../instituicao.service';
import {RouteParams, Router, CanActivate, ROUTER_DIRECTIVES} from 'angular2/router';
import {ModelMetadataService} from './../model-metadata.service';
import {Observable} from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/share';
import 'rxjs/Rx';
import {ModelListComponent} from './../model-list.component';

import {UiTabs, UiPane} from './../components/tabs/ui_tabs';
import {InstituicaoFooterComponent} from './../components/fragments/instituicao-footer.component';

//declare var jQuery:JQueryStatic;

// <link asp-append-version="true" rel="stylesheet" href="/css/animate.css" />
// <link asp-append-version="true" rel="stylesheet" href="/css/home.css" />


@Component({
    selector: 'nead-info',
    templateUrl: 'app/areas/singl/info/nead-info.component.html',
    directives: [ROUTER_DIRECTIVES, UiTabs, UiPane, ModelListComponent, InstituicaoFooterComponent],
    styleUrls: ['./css/animate.css', './css/home.css']
})
@CanActivate(() => ModelMetadataService.load('Singl.Models.SetorAdministrativo'))
export class NeadInfoComponent implements OnInit {

    //TODO: gambiarra ridícula;
    //descobrir como fazer binding com interpolation {{}}
    //a interpolação ocorre antes do ngOnInit 
    model: any;
    instituicao: any;

    constructor(
        public _service: SetorAdministrativoService,
        public _instituicaoService: InstituicaoService,
        public router: Router,
        public routeParams: RouteParams
    ) { }

    ngOnInit() {

        if (this.instituicao == null) {
            this._instituicaoService.observableModel$
                .subscribe(m => this.instituicao = m);
            this._instituicaoService.get({});
        }

        if (this.model == null) {
            this._service.getInfo({ sigla: "NEAD", campus: "SC" })
                .subscribe(m => this.model = m);
        }
        
       
            // jQuery for page scrolling feature - requires jQuery Easing plugin
//             jQuery('a.page-scroll').bind('click', function(event) {
//                 var jQueryanchor = jQuery(this);
//                 jQuery('html, body').stop().animate({
//                     scrollTop: (jQuery(jQueryanchor.attr('href')).offset().top - 50)
//                 }, 1250, 'easeInOutExpo');
//                 event.preventDefault();
//             });
// 
            // Highlight the top nav as scrolling occurs
            // jQuery('body')['scrollspy']({
            //     target: '.navbar-fixed-top',
            //     offset: 51
            // });
// 
//             // Fit Text Plugin for Main Header
//             jQuery("h1").fitText(
//                 1.2, {
//                     minFontSize: '35px',
//                     maxFontSize: '65px'
//                 }
//             );
// 
//             // Offset for Main Navigation
//             jQuery('#mainNav').affix({
//                 offset: {
//                     top: 100
//                 }
//             });

      
        
    }
    
    // gotoAnchor(anchor:string) {
    //     location.hash += anchor;
    // }

}