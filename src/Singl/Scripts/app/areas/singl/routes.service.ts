import {Injectable, Injector} from 'angular2/core';
import {Http, HTTP_PROVIDERS} from 'angular2/http';
import {Observable} from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/share';
import 'rxjs/Rx';

@Injectable()
export class RoutesService {

    private static _URL = "/api/routes/";
    dynamicRoutesObervable$: Observable<any>;
    private _dynamicRoutesObserver: any;
    private _dynamicRoutesDataStore: any;
    
    navRoutesObervable$: Observable<any>;
    private _navRoutesObserver: any;
    private _navRoutesDataStore: any;
    
    constructor(private _http: Http) {
         this.dynamicRoutesObervable$ = new Observable(observer =>
            this._dynamicRoutesObserver = observer).share();
         this.navRoutesObervable$ = new Observable(observer =>
            this._navRoutesObserver = observer).share();
    }
  
   getDynamicRoutes() {
        if (this._dynamicRoutesDataStore != null) {
            if (this._dynamicRoutesObserver) {
                this._dynamicRoutesObserver.next(this._dynamicRoutesDataStore);
                return;
            }
        }
        this._http.get(RoutesService._URL + "GetDynamicRoutes")
            .map(response => response.json())
            .subscribe(data => {
                this._dynamicRoutesDataStore = data;
                if (this._dynamicRoutesObserver) {
                    this._dynamicRoutesObserver.next(this._dynamicRoutesDataStore);
                }
            },
            error => console.log('Could not load.', error));
    }
    
    getNavRoutes() {
        if (this._navRoutesDataStore != null) {
            if (this._navRoutesObserver) {
                this._navRoutesObserver.next(this._navRoutesDataStore);
                return;
            }
        }
        this._http.get(RoutesService._URL + "GetNavRoutes")
            .map(response => response.json())
            .subscribe(data => {
                this._navRoutesDataStore = data;
                if (this._navRoutesObserver) {
                    this._navRoutesObserver.next(this._navRoutesDataStore);
                }
            },
            error => console.log('Could not load.', error));
    }    
}