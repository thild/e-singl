// login.component.ts
import { Component, Injectable } from 'angular2/core';
import { FORM_DIRECTIVES, FormBuilder, Validators, NgForm, Control, ControlGroup } from 'angular2/common';
import { Router } from 'angular2/router';
import { AuthService } from '../services/auth.service';
import { Credentials } from './credentials';

import {Observable} from 'rxjs/Observable';

//ver https://github.com/michaeloryl/angular2-bootstrap4-oauth2-webpack/blob/master/src/app/services/auth.service.ts
//https://medium.com/@blacksonic86/authentication-in-angular-2-958052c64492#.c1uiqhrzk
//https://medium.com/@blacksonic86/authentication-in-angular-2-958052c64492#.5rf9fcclp



@Component({
  selector: 'login',
  templateUrl: 'app/areas/admin/components/login.component.html',
  directives: [FORM_DIRECTIVES]
})
export class LoginComponent {

  form: ControlGroup;
  userName: Control = new Control('');
  password: Control = new Control('', Validators.required);
  model: Credentials = new Credentials('', '');

  constructor(
    private authService: AuthService,
    private router: Router,
    fb: FormBuilder
  ) {

    this.form = fb.group({
      //email: ['', Validators.compose([Validators.required, /*validatorFactory('email')*/])],
      userName: this.userName,
      password: this.password
    });

  }

  onSubmit() {
    this.authService.login(this.model)
      .subscribe((success) => {
        if (success) {
          this.router.navigate(['Home']);
        }
      });
  }

  // login() {
  //   this.auth.login();    
  //   this.router.navigate(['Home']);
  // }

  // logout() {
  //   this.auth.logout();
  // }  
}


import {Injector} from 'angular2/core';

let appInjectorRef: Injector;
export const appInjector = (injector?: Injector): Injector => {
  if (injector) {
    appInjectorRef = injector;
  }

  return appInjectorRef;
};

import {ComponentInstruction} from 'angular2/router';

export const isLoggedIn = (next: ComponentInstruction, previous: ComponentInstruction) => {
  let injector: Injector = appInjector(); // get the stored reference to the injector
  let auth: AuthService = injector.get(AuthService);
  let router: Router = injector.get(Router);

  // return a boolean or a promise that resolves a boolean
  return new Promise((resolve) => {
    auth.loggedIn
      .subscribe((result) => {
        if (result) {
          resolve(true);
        } else {
          router.navigate(['/Login']);
          resolve(false);
        }
      });
  });
};

