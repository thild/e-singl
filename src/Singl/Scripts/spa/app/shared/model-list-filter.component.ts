//http://plnkr.co/edit/1no1sjZ9Lkv4glsUFnnU?p=preview
//http://plnkr.co/edit/Y5VVAATuKJXhMz69SxfF?p=preview
//http://plnkr.co/edit/z9bhXkqVonScYm7EqiF5?p=preview  //DynamicComponentLoader 
//image processing http://www.syntaxsuccess.com/viewarticle/loading-components-dynamically-in-angular-2.0
//http://www.syntaxsuccess.com/angular-2-samples/#/demo/core


// TODO SOMEDAY: Feature Componetized like CrisisCenter
import {Component, OnInit, Input, Output, EventEmitter, Host, forwardRef, Inject}   from '@angular/core';
import {Router, ROUTER_DIRECTIVES} from '@angular/router';

import {IServiceBase, 
        ModelMetadataService, 
        ServiceBase, 
        ModelListComponent, 
        FilterService, 
        FilterPipe} from './';


//        <button *ngIf="selectedFilters.length > 0" (click)="clean()" type="button" class="btn btn-danger btn-xs"><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></button>

@Component({
    moduleId: module.id,
    selector: 'model-list-filter',
    template: `
        <ul *ngIf="list.filters">
            <li *ngFor="let filter of filterService.getFilters(list.modelName)" >
                <div class="checkbox">
                <label>
                    <input #checkbox type="checkbox" [checked]="isChecked(checkbox.value)" value="{{filter.value}}" (change)="onCheck(checkbox.value, checkbox.checked)" />{{filter.description}}
                </label>
                </div>
            </li>
        </ul>        
        <button *ngIf="list.filters" (click)="clean()" type="button" class="btn btn-danger btn-xs"><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></button>
    `,
    pipes: [FilterPipe],
    templateUrl: 'model-list-filter.component.html',
    directives: [ROUTER_DIRECTIVES],
    providers: [ModelMetadataService, FilterService],
    styles: [`
        ul {list-style-type: none; padding: 0; }
    `]
})
export class ModelListFilterComponent {

    @Output() check = new EventEmitter();
    selectedFilters = new Array<string>();

    clean() {
        this.selectedFilters = new Array<string>();
        this.check.emit(this.selectedFilters);
    }

    onCheck(filter, isChecked) {
        let i = this.selectedFilters.indexOf(filter);
        if (i == -1 && isChecked) {
            this.selectedFilters.push(filter);
        }
        else {
            this.selectedFilters.splice(i, 1);
        }
        this.check.emit(this.selectedFilters);
    }

    isChecked(value): string {
        return this.selectedFilters.indexOf(value) != -1 ? "checked" : "";
    }

    constructor(
        public router: Router,
        public metadataService: ModelMetadataService,
        public filterService: FilterService,
        @Host() @Inject(forwardRef(() => ModelListComponent)) public list: ModelListComponent
    ) {
        
        // let filter = routeParams.get("filter");
        // if (filter) {
        //     this.selectedFilters = filter.split(',');
        //     this.check.emit(this.selectedFilters);
        //     
        // }
    }

    ngOnInit() {
        this.selectedFilters = this.list.selectedFilters;
        if (!this.selectedFilters) {
            this.selectedFilters = new Array<string>();
        }
    }
}
