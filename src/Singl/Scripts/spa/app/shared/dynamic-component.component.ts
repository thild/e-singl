import {Injectable, Injector, Input, Component, ComponentResolver, OnInit,
    DynamicComponentLoader, ElementRef,
    ViewContainerRef, ViewChild,
    ComponentMetadata, ComponentFactory,
    ReflectiveInjector, OnChanges} from '@angular/core';

import {
    ROUTER_DIRECTIVES, ActivatedRoute
} from '@angular/router';

declare var System: any;


@Component({
    selector: 'dynamic-component',
    directives: [ROUTER_DIRECTIVES],
    template: '<div #extensionAnchor></div>'
})
export class DynamicComponent implements OnInit {

    public type: string;
    @Input() public templateUrl: string;

    @ViewChild('extensionAnchor', { read: ViewContainerRef }) extensionAnchor: ViewContainerRef;

    // constructor(
    //     // private dlc: DynamicComponentLoader,
    //     // private injector: Injector,
    //     // private elementRef: ElementRef,
    //     // private route: ActivatedRoute,
    //     // private resolver: ComponentResolver
    // ) {
    //     // console.log('DynamicComponent ctor');
    //     // this.templateUrl = '';
    //     // route.data.subscribe(param => this.templateUrl = param['templateUrl']);
    // }

    // ngOnInit() {
    //     // console.log('DynamicComponent ngOnInit');
    //     // this.renderTemplate(this.templateUrl, []);
    // }

    ngAfterViewInit() {
        // this.LoadComponentAsync("src/comps/app2/notes/NoteDynamic",
        //     "TestComponent", this.extensionAnchor);
    }

    public LoadComponentAsync(componentPath: string, componentName: string,
        locationAnchor: ViewContainerRef) {
        // System.import(componentPath)
        //     .then(fileContents => {
        //         console.log(fileContents);
        //         return fileContents[componentName]
        //     })
        //     .then(component => {
        //         this.resolver.resolveComponent(component).then(factory => {
        //             locationAnchor.createComponent(factory, 0, locationAnchor.injector);
        //         });
        //     });
    }

    renderTemplate(templateUrl, directives) {

        // var me = this;
        // this.dlc.loadAsRoot(
        //     toComponent(templateUrl, directives, me.type),
        //     '#extensionAnchor',
        //     this.injector
        // );
    }

    constructor(private vcRef: ViewContainerRef,
        private resolver: ComponentResolver,
        private route: ActivatedRoute
    ) {

    }

    ngOnInit() {
                console.log('ngOnInit');

        this.route.data.subscribe(
            param => {
                this.templateUrl = param['templateUrl'];
                console.log('this.templateUrl');
                console.log(this.templateUrl);


                //if (!this.templateUrl) return;

                const metadata = new ComponentMetadata({
                    selector: 'dynamic-html',
                    templateUrl: this.templateUrl,
                });
                createComponentFactory(this.resolver, metadata)
                    .then(factory => {
                        const injector = ReflectiveInjector.fromResolvedProviders([], this.vcRef.parentInjector);
                        this.vcRef.createComponent(factory, 0, injector, []);
                    });
            }
        );


    }
}


export function createComponentFactory(resolver: ComponentResolver,
    metadata: ComponentMetadata): Promise<ComponentFactory<any>> {
    const cmpClass = class DynamicComponent { };
    const decoratedCmp = Component(metadata)(cmpClass);
    return resolver.resolveComponent(decoratedCmp);
}

function toComponent(templateUrl, directives = [], type: string) {
    @Component({
        selector: 'fake-component',
        templateUrl: templateUrl,
        directives: directives
    })
    class FakeComponent {
        public type: string;

        constructor() {
            this.type = type;
            console.log('toComponent');
        }
    }

    return FakeComponent;
}