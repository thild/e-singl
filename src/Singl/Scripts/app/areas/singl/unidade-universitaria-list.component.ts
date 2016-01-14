
// TODO SOMEDAY: Feature Componetized like CrisisCenter
import {Component, OnInit}   from 'angular2/core';
import {UnidadeUniversitariaService}   from './unidade-universitaria.service';
import {UnidadeUniversitaria} from './unidade-universitaria';
import {Router, RouteParams} from 'angular2/router';
import {ROUTER_DIRECTIVES} from 'angular2/router';

@Component({
  selector:    'unidade-universitaria-list',
  templateUrl: 'app/areas/singl/unidade-universitaria-list.component.html',
  directives: [ROUTER_DIRECTIVES]  
})
export class UnidadeUniversitariaListComponent implements OnInit {
  list: any[];

  private _selected: string;

  constructor(
    private _service : UnidadeUniversitariaService,
    public router: Router,
    public routeParams: RouteParams
    ) 
  {
      this._selected = routeParams.get('sigla');
  }

  isSelected(item: any) { 
      return item.Sigla == this._selected; 
  }

  onSelect(item: any) {
    //this._router.navigate( ['UnidadeUniversitariaDetail', { sigla: unidadeUniversitaria.Sigla }] );
    this.router.navigateByUrl( '/unidadesuniversitarias/'+ item.Sigla );
  }
  
  ngOnInit() {
        this._service.observable$.subscribe(m => this.list = m);
        this._service.getAll();
  }
}
