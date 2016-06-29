// Imports
import {
    Component,
    Directive,
    Input,
    Output,
    ElementRef,
    EventEmitter,
    Provider,
    forwardRef,
    NgZone
} from 'angular2/core';

import {
    ControlValueAccessor,
    FORM_DIRECTIVES,
    NG_VALUE_ACCESSOR,
    CORE_DIRECTIVES
} from 'angular2/common';

declare var System: any;
declare var CKEDITOR: any;

//const noop = () => { };

const CUSTOM_INPUT_CONTROL_VALUE_ACCESSOR = new Provider(
    NG_VALUE_ACCESSOR, {
        useExisting: forwardRef(() => CKEditor),
        multi: true
    });

/**
 * CKEditor component
 * Usage :
 * <ckeditor [(ngModel)]="data" [config]="{...}" configFile="file.js"></ckeditor>
 */
@Component({
    selector: 'ckeditor',
    template: `<textarea #host></textarea>`,
    directives: [CORE_DIRECTIVES, FORM_DIRECTIVES],
    providers: [CUSTOM_INPUT_CONTROL_VALUE_ACCESSOR]
})
export class CKEditor implements ControlValueAccessor {

    /**
     * Event emmiter for touched event
     */
    @Output() public touched: EventEmitter<any> = new EventEmitter();
    
    /**
     * Event emmiter for change event
     */
    @Output() public change: EventEmitter<string> = new EventEmitter();

    
    @Input() config;
    @Input() configFile;

    //Internal data model
    private _value: string = '';
    instance = null;

    /**
     * Construct a new CKEditor
     * @constructor
     */
    constructor(private _elementRef: ElementRef,
                private _zone: NgZone) {
    }

    ngOnDestroy() {
        if (this.instance) {
            this.instance.removeAllListeners();
            this.instance.destroy();
            this.instance = null;
        }
    }

    ngAfterViewInit() {
        // Configuration
        var config = {};
        
        // Fetch file
        if (this.configFile) {

            if (System && System.import) {
                System.import(this.configFile)
                    .then((res) => {
                        this.ckeditorInit(res.config);
                    })
            }

            // Config object
        } else {
            config = this.config || {};
            this.ckeditorInit(config);
        }
    }

    /**
     * CKEditor init
     * @see {@link http://docs.ckeditor.com|CKEditor} 
     */
    ckeditorInit(config) {
        
        // CKEditor replace textarea
        this.instance = CKEDITOR.replace(this._elementRef.nativeElement, config);

        // Set initial value
        this.instance.setData(this._value);

        //Fired when the content of the editor is changed.
        this.instance.on('change', () => {
            //run inside zone to change detection work
            this._zone.run(() => this.value = this.instance.getData())
        });
        
        //Fired when the editor instance loses the input focus.
        this.instance.on('blur', () => {
            //run inside zone to change detection work
            this._zone.run(() => this.onTouched())
        });
    }

    get value(): any { return this._value; };

    @Input() set value(v: any) {
        if (v !== this._value) {
            this._value = v;
            this.onChange(v);
        }
    }

    onTouched() {
        this.touched.emit(null);
    }

    onChange(value: string) {
        this.change.emit(value);
    }

    //ControlValueAccessor 
    writeValue(value: string) {
        this._value = value;
        if (this.instance)
            this.instance.setData(value);
    }

    registerOnChange(fn: any) {
        this.change.subscribe(fn);
    }

    registerOnTouched(fn: any) {
        this.touched.subscribe(fn);
    }


}
