/// <reference path="../../../../node_modules/angular2/core.d.ts" />

import {Injectable} from 'angular2/core';

@Injectable()
export class Logger {
  log(msg: any)   { console.log(msg); }
  error(msg: any) { console.error(msg); }
  warn(msg: any)  { console.warn(msg); }
}
