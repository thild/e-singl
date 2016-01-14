
// TODO SOMEDAY: Feature Componetized like CrisisCenter
import {Component, OnInit}   from 'angular2/core';
import {CampusService}   from './campus.service';
import {Campus} from './campus';
import {Router, RouteParams} from 'angular2/router';

@Component({
  selector:    'campus-list',
  templateUrl: 'app/areas/singl/campus-list.component.html'
})
export class CampusListComponent implements OnInit {
  list: any[];

  private _selectedSigla: string;

  constructor(
    private _service : CampusService,
    public router: Router,
    public routeParams: RouteParams
    ) 
  {
      this._selectedSigla = routeParams.get('sigla');
  }

  isSelected(item: any) { 
      return item.Sigla == this._selectedSigla; 
  }

  onSelect(item: any) {
    this.router.navigateByUrl( '/campi/'+ item.Sigla );
  }
  
  ngOnInit() {
        this._service.observable$.subscribe(m => this.list = m);
        this._service.getAll();
  }
}
