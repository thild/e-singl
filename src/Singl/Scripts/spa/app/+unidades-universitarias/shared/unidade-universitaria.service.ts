import {Injectable} from '@angular/core';
import {Http} from '@angular/http';

import {ServiceBase} from './../../shared';

import { UnidadeUniversitaria } from './';


@Injectable()
export class UnidadeUniversitariaService extends ServiceBase {
    
    constructor(_http: Http) {
        super(_http, 'sigla', '/api/unidadesuniversitarias/', '`${params.sigla}`');
    }
}
       