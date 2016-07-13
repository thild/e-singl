import {Injectable} from '@angular/core';
import {Http} from '@angular/http';

import {ServiceBase} from './../../shared';

import {Campus} from './';

@Injectable()
export class CampusService extends ServiceBase {
       constructor(private http: Http) {
           super(http, 'Sigla', '/api/campi/', '`${params.sigla}`');
       }
} 