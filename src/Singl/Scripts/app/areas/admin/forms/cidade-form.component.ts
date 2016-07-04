import {Component} from 'angular2/core';
import {RouteConfig, ROUTER_DIRECTIVES, CanActivate, ComponentInstruction} from 'angular2/router';
import {isLoggedIn} from '../components/login.component'

import {NgForm, FormBuilder, Control, Validators, ControlGroup, FORM_DIRECTIVES}    from 'angular2/common';
import {Cidade}    from './../cidade';
import {CidadeService}    from './../cidade.service';
import {CKEditor} from './ckeditor.component';

@Component({
    selector: 'cidade-form',
    templateUrl: 'app/areas/admin/forms/cidade-form.component.html',
    directives: [FORM_DIRECTIVES, CKEditor]
})
@CanActivate((next: ComponentInstruction, previous: ComponentInstruction) => {
  return isLoggedIn(next, previous);
})
export class CidadeFormComponent {

    form: ControlGroup;

    id: Control = new Control('00000000-0000-0000-0000-000000000000');
    nome: Control = new Control('', Validators.required);

    model: Cidade = new Cidade('00000000-0000-0000-0000-000000000000', '');

    submitted = false;

    // Reset the form with a new hero AND restore 'pristine' class state
    // by toggling 'active' flag which causes the form
    // to be removed/re-added in a tick via NgIf
    // TODO: Workaround until NgForm has a reset method (#6822)
    active = true;

    constructor(fb: FormBuilder, public service: CidadeService) {
        this.form = fb.group({
            "id": this.id,
            "nome": this.nome
        });
    }

    onSubmit() {
        this.service.post(this.model).subscribe(m => console.log('foisimbora'));
    }

    // TODO: Remove this when we're done
    get diagnostic() { return JSON.stringify(this.model); }



    newCidade() {
        this.model.id = '00000000-0000-0000-0000-000000000000';
        this.model.nome = '';
        this.active = false;
        setTimeout(() => this.active = true, 0);
    }

}