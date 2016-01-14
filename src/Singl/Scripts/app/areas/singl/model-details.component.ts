//http://plnkr.co/edit/1no1sjZ9Lkv4glsUFnnU?p=preview
//http://plnkr.co/edit/Y5VVAATuKJXhMz69SxfF?p=preview
//http://plnkr.co/edit/z9bhXkqVonScYm7EqiF5?p=preview  //DynamicComponentLoader 
//image processing http://www.syntaxsuccess.com/viewarticle/loading-components-dynamically-in-angular-2.0
//http://www.syntaxsuccess.com/angular-2-samples/#/demo/core
//http://angularjs.blogspot.com.br/2015/03/forms-in-angular-2.html

// TODO SOMEDAY: Feature Componetized like CrisisCenter
import {Component, OnInit, Input, Output}   from 'angular2/core';
import {ModelMetadataService}   from './model-metadata.service';
import {ListComponent} from './list.component';
import {Router, RouteParams, RouterLink} from 'angular2/router';
import {ROUTER_DIRECTIVES} from 'angular2/router';

@Component({
    selector: 'model-details',
    templateUrl: 'app/areas/singl/model-details.component.html',
    directives: [ROUTER_DIRECTIVES, ListComponent, RouterLink ]
})
export class ModelDetailsComponent implements OnInit {

    properties: any[];
    @Input() model: any;
    @Input() modelName: string;
    @Input() notFoundMessage: string;
    @Input() headingMessage: string;

    constructor(public router: Router,
        public routeParams: RouteParams,
        public metadataService: ModelMetadataService) {

    }

    getModelNavigationDescription(model, property): string {
        if (model[property.PropertyName])
            return model[property.PropertyName][property.DescriptionProperty]
        return "-";
    }

    // getModelNavigationUrl(model, property): string {
    //     if(model == null)
    //         return "";
    //     return eval(property.NavigationUrl);
    // }
    // 
    // getModelNavigationRouteParams(model, property): any {
    //     if(model == null)
    //         return null;
    //     if(property.RouteParams == "")
    //         return null;            
    //     return JSON.parse(eval(property.RouteParams));
    // }
    
    onSelect(model: any, property: any) {
        if (model) 
            this.router.navigateByUrl(eval(property.NavigationUrl));
    }    

    ngOnInit() {
        this.metadataService.get(this.modelName)
            .subscribe(data => {
                this.properties = data.Properties;
            },
            error => console.log('Could not load.', error));
    }

}
