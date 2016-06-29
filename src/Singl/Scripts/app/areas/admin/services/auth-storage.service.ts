import {LocalStorageService} from './local-storage.service';
import { Injectable } from 'angular2/core';
const STORAGE_KEY = 'auth_token';

@Injectable()
export class AuthStorageService {
  
  constructor(private _localStorageService: LocalStorageService) {
  }
  
  getAuthToken() {
    return this._localStorageService.getItem(STORAGE_KEY);
  }

  setAuthToken(token) {
    this._localStorageService.setItem(STORAGE_KEY, token);
  }

  removeAuthToken() {
    this._localStorageService.removeItem(STORAGE_KEY);
  }
}
