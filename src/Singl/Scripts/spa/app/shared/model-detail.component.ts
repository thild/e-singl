//http://plnkr.co/edit/1no1sjZ9Lkv4glsUFnnU?p=preview
//http://plnkr.co/edit/Y5VVAATuKJXhMz69SxfF?p=preview
//http://plnkr.co/edit/z9bhXkqVonScYm7EqiF5?p=preview  //DynamicComponentLoader 
//image processing http://www.syntaxsuccess.com/viewarticle/loading-components-dynamically-in-angular-2.0
//http://www.syntaxsuccess.com/angular-2-samples/#/demo/core
//http://angularjs.blogspot.com.br/2015/03/forms-in-angular-2.html

// TODO SOMEDAY: Feature Componetized like CrisisCenter
import {Component, OnInit, Input, Output}   from '@angular/core';
import {ModelMetadataService}   from './model-metadata.service';
import {ModelListComponent} from './model-list.component';
import {Router, RouterLink} from '@angular/router';
import {ROUTER_DIRECTIVES} from '@angular/router';
import {IServiceBase}   from './service-base.service';
import {Observable} from 'rxjs/Observable';

@Component({
    moduleId: module.id, 
    selector: 'model-detail',
    templateUrl: 'model-detail.component.html',
    directives: [ROUTER_DIRECTIVES, ModelListComponent, RouterLink],
    providers: [ModelMetadataService],
    styleUrls: ['model-detail.component.css']
})
export class ModelDetailComponent implements OnInit {

    modelMetadata: any;
    properties: Observable<any>;
    @Input() model: any;
    @Input() modelName: string = '';
    @Input() notFoundMessage: string = '';
    @Input() headingMessage: string = '';

    constructor(public router: Router,
                public metadataService: ModelMetadataService)
    { }

    getModelNavigationDescription(model, property): string {
        if (model[property.propertyName])
            return model[property.PropertyName][property.descriptionProperty]
        return "-";
    }

    onSelect(model: any, property: any) {
        if (model)
            this.router.navigateByUrl(eval(property.detailNavigationUrl));
    }

    getHomeUrl(model): string {
        return eval(this.modelMetadata.detailNavigationUrl) + "/home";
    }

    ngOnInit() {
        
        this.metadataService.get(this.modelName)
            .subscribe(data => {
                console.log('data', data);
                this.modelMetadata = data;
                this.properties = Observable.of(data.properties);
            },
            error => console.log('Could not load.', error));

    }

    gotoList() {
        let model = this.model;
        let args = JSON.parse(eval(this.modelMetadata["listRouteParams"]));
        this.router.navigate([this.modelMetadata["listRouteName"], args]);
    }

    gotoHome(model) {
        this.router.navigateByUrl(this.getHomeUrl(model));
    }
}
