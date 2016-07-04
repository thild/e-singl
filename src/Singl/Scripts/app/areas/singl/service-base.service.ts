//http://coryrylan.com/blog/angular-2-observable-data-services
//https://github.com/splintercode/focus/tree/master/app
//https://github.com/mgechev/angular2-seed
//https://github.com/AngularClass/angular2-webpack-starter
//https://github.com/pkozlowski-opensource/ng2-play
//bookstore
//https://github.com/opencredo/angular2-boilerplate

import {Injectable} from 'angular2/core';
import {Http} from 'angular2/http';
import {Observable} from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/share';
import 'rxjs/Rx';

export interface IServiceBase {
    observableList$: Observable<Array<any>>;
    get(params: any);
    getAll();
}

//TODO: cache the results
export class ServiceBase implements IServiceBase {

    observableList$: Observable<Array<any>>;
    observableModel$: Observable<any>;
    private _observerList: any;
    private _observerModel: any;
    private _gotList = false;
    private _dataStore: {
        list: Array<any>
    };

    constructor(private _http: Http, public id: string, 
                public baseUrl: string, public getUrl: string) {
        // Create Observable Stream to output our data
        this.observableList$ = new Observable(observer =>
            this._observerList = observer).share();
        this.observableModel$ = new Observable(observer =>
            this._observerModel = observer).share();
        this._dataStore = { list: [] };
    }

    get(params: any) {
        if (this._dataStore.list.length > 0) {
            //console.log("find");
            var model = this._dataStore.list.filter(m => {
                    return m[this.id] == params[this.id.toLowerCase()];
            });
            if (model != null) {
                //console.log("model != null");
                if (this._observerModel) {
                    this._observerModel.next(model[0]);
                    return;
                }
            }
        }
        let url = this.getUrl ? eval(this.getUrl) : '';
        let apiUrl = this.baseUrl + url;
        this._http.get(apiUrl)
            .map(response => response.json())
            .subscribe(data => {
                //console.log("httpGet - subscribe");
                this._dataStore.list.push(data);
                if (this._observerModel) {
                    this._observerModel.next(data);
                }
                if (this._observerList) {
                    this._observerList.next(this._dataStore.list);
                }
            },
            error => console.log('Could not load.', error));
    }


    getAll() {
        if (this._gotList && this._dataStore.list.length > 0) {
            this._observerList.next(this._dataStore.list);
            return;
        }
        this._http.get(this.baseUrl)
            .map(response => response.json())
            .subscribe(data => {
                // Update data store
                this._dataStore.list = data;
                // Push the new list of todos into the Observable stream
                if (this._observerList) {
                    this._observerList.next(this._dataStore.list);
                }
                if (this._observerModel) {
                    this._dataStore.list.forEach(
                        (item) => this._observerModel.next(data) 
                    );
                }                
                this._gotList = true;
            },
            error => console.log('Could not load.', error));
    }
    
    getInfo(params: any) {
        let apiUrl = this.baseUrl + (this.getUrl ? eval(this.getUrl) : '') + '/info';
        return this._http.get(apiUrl)
            .map(response => response.json());
    }
    
}