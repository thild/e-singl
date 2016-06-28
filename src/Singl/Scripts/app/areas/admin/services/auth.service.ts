// user.service.ts
import { Injectable } from 'angular2/core';
import { Http, Headers } from 'angular2/http';
import { BehaviorSubject } from 'rxjs/subject/BehaviorSubject';
import {AuthStorageService} from './auth-storage.service';
import {Credentials} from '../components/credentials';

@Injectable()
export class AuthService {
  private _loggedIn = new BehaviorSubject(false);
  private auth_token = ''

  constructor(private _http: Http,
             private _storage: AuthStorageService) {
               
    if(!!this._storage.getAuthToken()) {
      this._loggedIn.next(true);
    }
    
  }

  login(credentials:Credentials) {
    let headers = new Headers();
    headers.append('Content-Type', 'application/json');
    console.log(credentials);
    
    return this._http
      .post(
      '/api/account/login',
      JSON.stringify(credentials),
      { headers }
      )
      .map(res => res.json())
      .map((res) => {
        if (res.Succeeded) {
          this._storage.setAuthToken(res.auth_token);
          this._loggedIn.next(true);  
        }

        return res.Succeeded;
      });
  }

  logout() {
    this._storage.removeAuthToken();
    this._loggedIn.next(false);  
  }

  get isLoggedIn() : boolean {
    return this._loggedIn.getValue();
  }

  get loggedIn() : BehaviorSubject<boolean> {
    return this._loggedIn;
  }

  getProfile() {
    let headers = new Headers();
    headers.append('Content-Type', 'application/json');
    let authToken = this._storage.getAuthToken();
    headers.append('Authorization', `Bearer ${authToken}`);

    return this._http
      .get('/profile', { headers: headers })
      .map(res => res.json());
  }
}