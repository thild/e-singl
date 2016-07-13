import {Injectable} from '@angular/core';
import {Http} from '@angular/http';

import {ServiceBase} from './../../shared';

import {SetorConhecimento} from './';


@Injectable()
export class SetorConhecimentoService extends ServiceBase {
       constructor(_http: Http) {
           super(_http, 'Sigla', '/api/setoresconhecimento/', '`${params.sigla}/${params.unidadeUniversitaria}`');
       }
} 