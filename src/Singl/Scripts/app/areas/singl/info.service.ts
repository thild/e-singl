//http://coryrylan.com/blog/angular-2-observable-data-services
//https://github.com/splintercode/focus/tree/master/app
//https://github.com/mgechev/angular2-seed
//https://github.com/AngularClass/angular2-webpack-starter
//https://github.com/pkozlowski-opensource/ng2-play
//bookstore
//https://github.com/opencredo/angular2-boilerplate

import {Injectable, Injector} from 'angular2/core';
import {Http, HTTP_PROVIDERS} from 'angular2/http';
import {Observable} from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/share';
import 'rxjs/Rx';

@Injectable()
export class InfoService {

    private static _URL = "/api/info/";
    
    private static _cache = new Array<Observable<any>>();
    
    constructor(private _http: Http) {
    }
  
    get(modelName: string) : Observable<any> {
        if(InfoService._cache[modelName]) {
            return InfoService._cache[modelName];
        }
        let ret = this._http.get(InfoService._URL + modelName)
            .map(response => response.json());
        return ret;
    }  
    
    static load(modelName: string) : Promise<boolean> {
        let injector = Injector.resolveAndCreate([
            InfoService, HTTP_PROVIDERS
        ]);

        let mms = injector.get(InfoService) as InfoService;

        return mms.get(modelName)
            .toPromise()
            .then((value) => {
                InfoService._cache[modelName] = Observable.of(value);
                return value != null;
        });
        
    };    
}