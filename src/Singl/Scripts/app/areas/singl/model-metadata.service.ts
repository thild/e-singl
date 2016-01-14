//http://coryrylan.com/blog/angular-2-observable-data-services
//https://github.com/splintercode/focus/tree/master/app
//https://github.com/mgechev/angular2-seed
//https://github.com/AngularClass/angular2-webpack-starter
//https://github.com/pkozlowski-opensource/ng2-play
//bookstore
//https://github.com/opencredo/angular2-boilerplate

import {Injectable} from 'angular2/core';
import {Http} from 'angular2/http';

@Injectable()
export class ModelMetadataService {

    private static _URL = "/api/modelmetadata/";
    
    constructor(private _http: Http) {
    }
        
    get(modelName: string) {
        return this._http.get(ModelMetadataService._URL + modelName).map(response => response.json());
    }
  
}