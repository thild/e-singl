import {Component} from 'angular2/core';
import {NgForm, FormBuilder, Control, Validators, ControlGroup, FORM_DIRECTIVES}    from 'angular2/common';
import {Template}    from './../template';
import {TemplateService}    from './../template.service';
import {CKEditor} from './ckeditor.component';

@Component({
    selector: 'template-form',
    templateUrl: 'app/areas/admin/forms/template-form.component.html',
    directives: [FORM_DIRECTIVES, CKEditor]
})
export class TemplateFormComponent {

    form: ControlGroup;

    name: Control = new Control('');
    path: Control = new Control('', Validators.required);
    html: Control = new Control('', Validators.required);

    model: Template = new Template('', '', '');

    submitted = false;

    // Reset the form with a new hero AND restore 'pristine' class state
    // by toggling 'active' flag which causes the form
    // to be removed/re-added in a tick via NgIf
    // TODO: Workaround until NgForm has a reset method (#6822)
    active = true;

    constructor(fb: FormBuilder, public service: TemplateService) {
        this.form = fb.group({
            "name": this.name,
            "path": this.path,
            "html": this.html
        });
    }

    onSubmit() {
        //this.submitted = true;
        console.log('teste');
        
        this.service.post(this.model).subscribe(m => console.log('foisimbora'));
        // this.form.controls.forEach((name, control) => {
        //     control.updateValue('');
        //     control.setErrors(null);
        // });

    }

    // TODO: Remove this when we're done
    get diagnostic() { return JSON.stringify(this.model); }



    newTemplate() {
        this.model.name = '';
        this.model.path = '';
        this.model.html = '';
        this.active = false;
        setTimeout(() => this.active = true, 0);
    }

}