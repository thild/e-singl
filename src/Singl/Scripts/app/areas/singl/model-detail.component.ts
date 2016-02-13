//http://plnkr.co/edit/1no1sjZ9Lkv4glsUFnnU?p=preview
//http://plnkr.co/edit/Y5VVAATuKJXhMz69SxfF?p=preview
//http://plnkr.co/edit/z9bhXkqVonScYm7EqiF5?p=preview  //DynamicComponentLoader 
//image processing http://www.syntaxsuccess.com/viewarticle/loading-components-dynamically-in-angular-2.0
//http://www.syntaxsuccess.com/angular-2-samples/#/demo/core
//http://angularjs.blogspot.com.br/2015/03/forms-in-angular-2.html

// TODO SOMEDAY: Feature Componetized like CrisisCenter
import {Component, OnInit, Input, Output}   from 'angular2/core';
import {ModelMetadataService}   from './model-metadata.service';
import {ModelListComponent} from './model-list.component';
import {Router, RouteParams, RouterLink} from 'angular2/router';
import {ROUTER_DIRECTIVES} from 'angular2/router';
import {IServiceBase}   from './service-base.service';
import {Observable} from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/share';
import 'rxjs/Rx';

@Component({
    selector: 'model-detail',
    templateUrl: 'app/areas/singl/model-detail.component.html',
    directives: [ROUTER_DIRECTIVES, ModelListComponent, RouterLink],
    styleUrls: ['./css/navigation.css']
})
export class ModelDetailComponent implements OnInit {

    modelMetadata: any;
    properties: Observable<any>;
    @Input() model: any;
    @Input() modelName: string;
    @Input() notFoundMessage: string;
    @Input() headingMessage: string;

    constructor(public router: Router,
        public routeParams: RouteParams,
        public metadataService: ModelMetadataService)
    { }

    getModelNavigationDescription(model, property): string {
        if (model[property.PropertyName])
            return model[property.PropertyName][property.DescriptionProperty]
        return "-";
    }

    onSelect(model: any, property: any) {
        if (model)
            this.router.navigateByUrl(eval(property.DetailNavigationUrl));
    }

    getInfoUrl(): string {
        let model = this.model;
        return eval(this.modelMetadata.DetailNavigationUrl) + "/info";
    }

    ngOnInit() {
        this.metadataService.get(this.modelName)
            .subscribe(data => {
                this.modelMetadata = data;
                this.properties = Observable.of(data.Properties);
                
                // let sigla = this.routeParams.get(this.modelMetadata.SelectionProperty);
                // this.modelService.get(eval(this.modelMetadata.DetailNavigationUrl))
                //     .subscribe(data => this.model = data,
                //             error => console.log('Could not load.', error));            
                
            },
            error => console.log('Could not load.', error));

    }

    //TODO go to list filtered by previous navigation
    gotoList() {
        let model = this.model;
        let args = JSON.parse(eval(this.modelMetadata["ListRouteParams"]));
        this.router.navigate([this.modelMetadata["ListRouteName"], args]);
    }

    gotoInfo() {
        this.router.navigateByUrl(this.getInfoUrl());
    }
}
