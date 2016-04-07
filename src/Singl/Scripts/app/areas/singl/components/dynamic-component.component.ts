import {Injectable, Input, Component,
    DynamicComponentLoader, ElementRef} from 'angular2/core';

import {
    ROUTER_DIRECTIVES, RouteData
} from 'angular2/router';



@Component({
    selector: 'dynamic-component',
    directives: [ROUTER_DIRECTIVES],
    template: '<div #anchor> </div>'
})
export class DynamicComponent {

    public type: string;
    @Input() public templateUrl: string;

    constructor(private dlc: DynamicComponentLoader,
        private elementRef: ElementRef,
        private data: RouteData) {
        this.templateUrl = data.get('templateUrl');
    }

    ngOnInit() {
        this.renderTemplate(this.templateUrl, []);
    }


    renderTemplate(templateUrl, directives) {
        var me = this;
        this.dlc.loadIntoLocation(
            toComponent(templateUrl, directives, me.type),
            this.elementRef,
            'anchor'
        );
    }
}


function toComponent(templateUrl, directives = [], data: string) {
    @Component({
        selector: 'fake-component',
        templateUrl: templateUrl,
        directives: directives
    })
    class FakeComponent {
        public typeF: string;

        constructor() { this.typeF = data; }
    }

    return FakeComponent;
}