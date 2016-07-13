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
import 'rxjs/Rx';

@Injectable()
export class HomeService {

    private static URL = "/api/info/";
    
    private static cache = new Array<Observable<any>>();
    
    constructor(private http: Http) {
    }
  
    get(modelName: string) : Observable<any> {
        if(HomeService.cache[modelName]) {
            return HomeService.cache[modelName];
        }
        let ret = this.http.get(HomeService.URL + modelName)
            .map(response => response.json());
        return ret;
    }  
    
    static load(modelName: string) : Promise<boolean> {
        let injector = ReflectiveInjector.resolveAndCreate([
            HomeService, HTTP_PROVIDERS
        ]);

        let mms = injector.get(HomeService) as HomeService;

        return mms.get(modelName)
            .toPromise()
            .then((value) => {
                HomeService.cache[modelName] = Observable.of(value);
                return value != null;
        });
        
    };    
}