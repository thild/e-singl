//http://plnkr.co/edit/1no1sjZ9Lkv4glsUFnnU?p=preview
//http://plnkr.co/edit/Y5VVAATuKJXhMz69SxfF?p=preview
//http://plnkr.co/edit/z9bhXkqVonScYm7EqiF5?p=preview  //DynamicComponentLoader 
//image processing http://www.syntaxsuccess.com/viewarticle/loading-components-dynamically-in-angular-2.0
//http://www.syntaxsuccess.com/angular-2-samples/#/demo/core


// TODO SOMEDAY: Feature Componetized like CrisisCenter
import {Component, OnInit, Input, Output}   from 'angular2/core';
import {UnidadeUniversitariaService}   from './unidade-universitaria.service';
import {IServiceBase}   from './service-base.service';
import {UnidadeUniversitaria} from './unidade-universitaria';
import {Router, RouteParams} from 'angular2/router';
import {ROUTER_DIRECTIVES} from 'angular2/router';

@Component({
  selector:    'list',
  templateUrl: 'app/areas/singl/list.component.html',
  directives: [ROUTER_DIRECTIVES]    
})
export class ListComponent  {
  private _selectedId: string;
  
  @Input() list: any[];
  @Input() selectionProperty: string;
  @Input() descriptionProperty: string;
  @Input() name: string;
  @Input() navigationUrl: string;

  constructor(
    public router: Router,
    public routeParams: RouteParams
    ) 
  {
      this._selectedId = this.routeParams.get(this.selectionProperty);
  }

  isSelected(item: any) { 
      return item[this.selectionProperty] == this._selectedId; 
  }

  onSelect(item: any) {
    this.router.navigateByUrl(eval(this.navigationUrl));
  }
  
}
