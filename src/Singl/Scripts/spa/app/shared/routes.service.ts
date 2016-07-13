import {Injectable, Injector} from '@angular/core';
import {Http, HTTP_PROVIDERS} from '@angular/http';
import {Observable} from 'rxjs/Observable';

@Injectable()
export class RoutesService {

    private static _URL = "/api/routes/";
    dynamicRoutesObervable$: Observable<any>;
    private dynamicRoutesObserver: any;
    private dynamicRoutesDataStore: any;
    
    navRoutesObervable$: Observable<any>;
    private _navRoutesObserver: any;
    private _navRoutesDataStore: any;
    
    constructor(private http: Http) {
         this.dynamicRoutesObervable$ = new Observable(observer =>
            this.dynamicRoutesObserver = observer).share();
         this.navRoutesObervable$ = new Observable(observer =>
            this._navRoutesObserver = observer).share();
    }

    public routesResolved() : boolean {
        return this.dynamicRoutesDataStore != null;
    }
  
   getDynamicRoutes() {
        if (this.dynamicRoutesDataStore != null) {
            if (this.dynamicRoutesObserver) {
                this.dynamicRoutesObserver.next(this.dynamicRoutesDataStore);
                return;
            }
        }
        this.http.get(RoutesService._URL + "GetDynamicRoutes")
            .map(response => response.json())
            .subscribe(data => {
                this.dynamicRoutesDataStore = data;
                if (this.dynamicRoutesObserver) {
                    this.dynamicRoutesObserver.next(this.dynamicRoutesDataStore);
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
        this.http.get(RoutesService._URL + "GetNavRoutes")
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