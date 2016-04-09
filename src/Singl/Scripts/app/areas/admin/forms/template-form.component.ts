    import {Component} from 'angular2/core';
    import {NgForm}    from 'angular2/common';
    import {Template}    from './template';

    @Component({
      selector: 'template-form',
      templateUrl: 'app/areas/admin/forms/template-form.component.html'
    })
    export class TemplateFormComponent {
      
      model : Template;
      submitted = false;
      
      onSubmit() { this.submitted = true; }
      
      // TODO: Remove this when we're done
      get diagnostic() { return JSON.stringify(this.model); }
      
    }