//http://plnkr.co/edit/1no1sjZ9Lkv4glsUFnnU?p=preview
//http://plnkr.co/edit/Y5VVAATuKJXhMz69SxfF?p=preview
//http://plnkr.co/edit/z9bhXkqVonScYm7EqiF5?p=preview  //DynamicComponentLoader 
//image processing http://www.syntaxsuccess.com/viewarticle/loading-components-dynamically-in-angular-2.0
//http://www.syntaxsuccess.com/angular-2-samples/#/demo/core


// TODO SOMEDAY: Feature Componetized like CrisisCenter
import {Component, OnInit, Input, Output, Host}   from '@angular/core';
import {Router, ActivatedRoute, ROUTER_DIRECTIVES} from '@angular/router';

import {IServiceBase,
    ModelMetadataService,
    ServiceBase,
    ModelListFilterComponent,
    FilterService,
    FilterPipe} from './';

@Component({
    moduleId: module.id,
    selector: 'model-list',
    templateUrl: 'model-list.component.html',
    directives: [ModelListFilterComponent, ROUTER_DIRECTIVES],
    styleUrls: ['model-detail.component.css'],
    styles: [`
        ul {list-style-type: none; padding: 0; }
        hr { border-width: 1px 0 0;}        
    `]
})
export class ModelListComponent {
    private selectedId: string;

    modelMetadata: any;

    @Input() list: any[];
    @Input() filteredList: any[];
    @Input() modelName: string = '';
    @Input() selectionProperty: string = '';
    @Input() descriptionProperty: string = '';
    @Input() name: string = '';
    @Input() detailNavigationUrl: string = '';
    @Input() listNavigationUrl: string = '';
    @Input() listRouteName: string = '';
    @Input() showHeading: boolean = false;
    @Input() showFilters: boolean = true;
    @Input() headingMessage: string = '';

    @Input() selectedFilters: Array<string>;
    @Input() filters: Array<any>;

    constructor(
        public router: Router,
        public route: ActivatedRoute,
        public metadataService: ModelMetadataService
    ) {
        console.log('ModelListComponent ctor');

        if (this.selectionProperty)
            this.selectedId = '';
        this.route.params.subscribe(params => {
            console.log('ModelListComponent this.route.params.subscribe');
            this.selectedId = params[this.selectionProperty.toLowerCase()];
        });
    }

    filterList() {
        if (this.list && this.selectedFilters) {
            let ret = this.selectedFilters.reduce(
                (acc, y) => FilterService[y](acc), this.list
            );
            this.filteredList = ret;
        }
        else {
            this.filteredList = this.list;
        }
    }

    hasSelectedItems(): boolean {
        if (!this.selectedFilters || this.selectedFilters.length == 0) {
            return true;
        }
        if (this.filteredList && this.filteredList.length > 0) {
            return true;
        }
        return false
        //return list ? list.length == 0 ? false : true : true;
    }

    onCheck(selectedFilters: Array<string>) {
        // this.selectedFilters = selectedFilters;
        this.filterList();
        if (selectedFilters.length > 0) {
            this.router.navigate([this.listRouteName, { filter: selectedFilters.join(",") }]);
        } else {
            this.router.navigate([this.listRouteName]);
        }
    }

    isSelected(model: any) {
        return model[this.selectionProperty] == this.selectedId;
    }

    onSelect(model: any) {
        this.router.navigateByUrl(eval(this.detailNavigationUrl));
    }

    gotoHome(model: any) {
        this.router.navigateByUrl(eval(this.detailNavigationUrl) + "/home");
    }

    ngOnInit() {
        console.log('ModelListComponent ngOnInit');

        if (this.modelName !== '') {
            this.metadataService.get(this.modelName)
                .subscribe(data => {
                    console.log('data', data);
                    
                    this.modelMetadata = data;
                    this.selectionProperty = this.modelMetadata.selectionProperty;
                    this.descriptionProperty = this.modelMetadata.descriptionProperty;
                    this.detailNavigationUrl = this.modelMetadata.detailNavigationUrl;
                    this.listNavigationUrl = this.modelMetadata.listNavigationUrl;
                    this.listRouteName = this.modelMetadata.listRouteName;
                    this.selectedId = '';
                    this.route.params.subscribe(params => {
                        this.selectedId = params[this.selectionProperty.toLowerCase()];
                    });
                },
                error => console.log('Could not load.', error));
        }
        let filter = '';
        this.route.params.subscribe(params => {
            filter = params['filter'];
        });
        if (filter) {
            this.selectedFilters = filter.split(',');
        }
    }
    ngAfterContentChecked() {
        this.filterList();

        // Component content has been Checked
    }


    //remover
    getFilterParams() {
        let filter = '';
        this.route.params.subscribe(params => {
            filter = params['filter'];
        });
        if (!filter) return;
        let params = filter.split(',');
        if (params.length != 2) return;
        return { property: params[0], value: params[1] };
    }

    getFilterFunction() {
        let filter = '';
        this.route.params.subscribe(params => {
            filter = params['filter'];
        });
        if (!filter) return;
        return filter;
    }

}
