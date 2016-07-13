import {Injectable} from '@angular/core';
import {Http} from '@angular/http';

import {ServiceBase} from './../../shared';

import {SetorAdministrativo} from './';

@Injectable()
export class SetorAdministrativoService extends ServiceBase {
       constructor(http: Http) {
           super(http, 'Sigla', '/api/setoresadministrativos/', '`${params.sigla}/${params.campus}`');
       }
} 