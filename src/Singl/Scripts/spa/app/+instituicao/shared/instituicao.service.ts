import {Injectable} from '@angular/core';
import {Http} from '@angular/http';

import {ServiceBase} from './../../shared';

@Injectable()
export class InstituicaoService extends ServiceBase {
    constructor(_http: Http) {
        super(_http, '', '/api/instituicao', '');
    }
} 