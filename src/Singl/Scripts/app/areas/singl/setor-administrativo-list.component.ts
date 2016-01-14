
// TODO SOMEDAY: Feature Componetized like CrisisCenter
import {Component, OnInit}   from 'angular2/core';
import {SetorAdministrativoService}   from './setor-administrativo.service';
import {SetorAdministrativo} from './setor-administrativo';
import {Router, RouteParams} from 'angular2/router';

@Component({
  selector:    'setor-administrativo-list',
  templateUrl: 'app/areas/singl/setor-administrativo-list.component.html'
})
export class SetorAdministrativoListComponent implements OnInit {
  list: any[];

  private _selected: string;

  constructor(
    private _service : SetorAdministrativoService,
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
    this.router.navigateByUrl(`/setoresadministrativos/${item.Sigla}/${item.SiglaCampus}`);
  }
  
  ngOnInit() {
        this._service.observable$.subscribe(m => this.list = m);
        this._service.getAll();
  }
}
