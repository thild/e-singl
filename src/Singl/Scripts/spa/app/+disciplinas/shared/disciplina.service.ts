import {Injectable} from '@angular/core';
import {Http} from '@angular/http';

import {ServiceBase} from './../../shared';

import {Disciplina} from './';


@Injectable()
export class DisciplinaService extends ServiceBase {
       constructor(_http: Http) {
           super(_http, 'Codigo', '/api/disciplinas/', '`${params.codigo}`');
       }
} 