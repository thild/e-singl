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
export class ModelMetadataService {

    private static _URL = "/api/modelmetadata/";
    
    private static _cache = new Array<Observable<any>>();
    
    constructor(private _http: Http) {
    }
  
    get(modelName: string) : Observable<any> {
        //console.log("get");
        //console.log(modelName);
        if(ModelMetadataService._cache[modelName]) {
            //console.log("_cache");
            return ModelMetadataService._cache[modelName];
        }
        let ret = this._http.get(ModelMetadataService._URL + modelName)
            .map(response => response.json());
            
        // ret.subscribe(data => {
        //     //console.log("subscribe");
        //     ModelMetadataService._cache[modelName] = Observable.of(data);
        //     //console.log("subscribe", ModelMetadataService._cache[modelName]);
        // });
        //console.log("ret");
        return ret;
    }  
    
    static load(modelName: string) : Promise<boolean> {
        //console.log("load");
        //console.log(modelName);
        let injector = Injector.resolveAndCreate([
            ModelMetadataService, HTTP_PROVIDERS
        ]);

        let mms = injector.get(ModelMetadataService) as ModelMetadataService;

        return mms.get(modelName)
            .toPromise()
            .then((value) => {
                //console.log("toPromise");
                ModelMetadataService._cache[modelName] = Observable.of(value);
                //console.log("toPromise", ModelMetadataService._cache[modelName]);
                return value != null;
        });
        
    };    
}