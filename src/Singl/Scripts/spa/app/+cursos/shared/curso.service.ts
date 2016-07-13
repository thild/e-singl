import {Injectable} from '@angular/core';
import {Http} from '@angular/http';

import {ServiceBase} from './../../shared';

import {Curso} from './';

@Injectable()
export class CursoService extends ServiceBase {
       constructor(_http: Http) {
           super(_http, 'Codigo', '/api/cursos/', '`${params.codigo}`');
       }
} 