//http://coryrylan.com/blog/angular-2-observable-data-services
//https://github.com/splintercode/focus/tree/master/app
//https://github.com/mgechev/angular2-seed
//https://github.com/AngularClass/angular2-webpack-starter
//https://github.com/pkozlowski-opensource/ng2-play
//bookstore
//https://github.com/opencredo/angular2-boilerplate

import {Injectable} from 'angular2/core';
import {UnidadeUniversitaria} from './unidade-universitaria';
import {Http} from 'angular2/http';
import {Observable} from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/share';
import 'rxjs/Rx';

export interface IServiceBase<TModel> {
    observable$: Observable<Array<TModel>>;
    get(params: any);
    getAll();
} 

export class ServiceBase<TModel> implements IServiceBase<TModel> {
    
    observable$: Observable<Array<TModel>>;
    private _observer: any;
    private _dataStore: {
        list: Array<TModel>
    };    

    constructor(private _http: Http, public id:string, public baseUrl:string, public getUrl:string) {
        // Create Observable Stream to output our data
        this.observable$ = new Observable(observer => 
            this._observer = observer).share();
        this._dataStore = { list: [] };
    }
        
    get(params: any) {
        if (this._dataStore.list.length > 0) {
            let model = this._dataStore.list.find(m => {
                return (m as any)[this.id] == (params as any)[this.id];
            });
            if (model != null) return Observable.of<TModel>(model);
        }
        let apiUrl = this.baseUrl + eval(this.getUrl);
        return this._http.get(apiUrl).map(response => response.json());
    }
  
  
    getAll() {
        if (this._dataStore.list.length > 0) {
            this._observer.next(this._dataStore.list);
            return;
        }
        this._http.get(this.baseUrl)
            .map(response => response.json())
            .subscribe(data => {
                    // Update data store
                    this._dataStore.list = data;
                    // Push the new list of todos into the Observable stream
                    this._observer.next(this._dataStore.list);
                }, 
                error => console.log('Could not load.', error)
            );
    }
}