import {Injectable} from '@angular/core';
import {Http} from '@angular/http';

import {ServiceBase} from './../../shared';

import {Departamento} from './';

@Injectable()
export class DepartamentoService extends ServiceBase {
       constructor(_http: Http) {
           super(_http, 'Sigla', '/api/departamentos/', '`${params.sigla}/${params.unidadeUniversitaria}`');
       }
} 