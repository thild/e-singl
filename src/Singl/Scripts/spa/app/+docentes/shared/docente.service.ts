import {Injectable} from '@angular/core';
import {Http} from '@angular/http';

import {ServiceBase} from './../../shared';

@Injectable()
export class DocenteService extends ServiceBase {
       constructor(_http: Http) {
           super(_http, 'Id', '/api/docentes/', '`${params.id}`');
       }
} 