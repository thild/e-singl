//http://coryrylan.com/blog/angular-2-observable-data-services
//https://github.com/splintercode/focus/tree/master/app
//https://github.com/mgechev/angular2-seed
//https://github.com/AngularClass/angular2-webpack-starter
//https://github.com/pkozlowski-opensource/ng2-play
//bookstore
//https://github.com/opencredo/angular2-boilerplate

import {Injectable, ReflectiveInjector} from '@angular/core';
import {Http, HTTP_PROVIDERS} from '@angular/http';
import {Observable} from 'rxjs/Observable';

@Injectable()
export class ModelMetadataService {

    private static URL = "/api/modelmetadata/";
    
    private static cache = new Array<Observable<any>>();
    
    constructor(private http: Http) {
    }
  
    get(modelName: string) : Observable<any> {
        if(ModelMetadataService.cache[modelName]) {
            return ModelMetadataService.cache[modelName];
        }
        console.log('modelName', modelName);
        
        return this.http.get(ModelMetadataService.URL + modelName)
            .map(response => {
                console.log('response', response);
                console.log('response.json()',response.json());
                return response.json()
            });
    }  
    
    static load(modelName: string) : Observable<boolean> {
        let injector = ReflectiveInjector.resolveAndCreate([
            ModelMetadataService, HTTP_PROVIDERS
        ]);

        let mms = injector.get(ModelMetadataService) as ModelMetadataService;

        return mms.get(modelName)
            .map((value) => {
                ModelMetadataService.cache[modelName] = Observable.of(value);
                return value != null;
        });        
        
    };    
}