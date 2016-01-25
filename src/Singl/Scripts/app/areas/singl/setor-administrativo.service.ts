//http://coryrylan.com/blog/angular-2-observable-data-services
//https://github.com/splintercode/focus/tree/master/app
//https://github.com/mgechev/angular2-seed
//https://github.com/AngularClass/angular2-webpack-starter
//https://github.com/pkozlowski-opensource/ng2-play
//bookstore
//https://github.com/opencredo/angular2-boilerplate

import {Injectable} from 'angular2/core';
import {SetorAdministrativo} from './setor-administrativo';
import {Http} from 'angular2/http';
import {ServiceBase} from './service-base.service';


@Injectable()
export class SetorAdministrativoService extends ServiceBase {
       constructor(_http: Http) {
           super(_http, 'Sigla', '/api/setoresadministrativos/', '`${params.sigla}/${params.campus}`');
       }
} 