//http://coryrylan.com/blog/angular-2-observable-data-services
//https://github.com/splintercode/focus/tree/master/app
//https://github.com/mgechev/angular2-seed
//https://github.com/AngularClass/angular2-webpack-starter
//https://github.com/pkozlowski-opensource/ng2-play
//bookstore
//https://github.com/opencredo/angular2-boilerplate

import {Injectable} from 'angular2/core';
import {Http, Response} from 'angular2/http';
import {Headers, RequestOptions} from 'angular2/http';
import {ServiceBase} from './service-base.service';
import {Observable} from 'rxjs/Observable';
import {Template} from './template';


@Injectable()
export class TemplateService extends ServiceBase {

    constructor(public http: Http) {
        super(http, 'Id', '/api/templates/', '`${params.routeName}`', '');
    }

    post(obj: Template): Observable<Template> {
        let body = JSON.stringify(obj);
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        console.log(body);
        
        return this.http.post(this.baseUrl, body, options)
            .map(res => <Template>res.json().data)
            .catch(this.handleError)
    }

    private handleError(error: Response) {
        // in a real world app, we may send the error to some remote logging infrastructure
        // instead of just logging it to the console
        console.error('error:', error);
        return Observable.throw(error.json().error || 'Server error');
    }

} 