import { Injectable } from '@angular/core';
import { UserDetails } from '../../../models/userDetails/userDetails';

@Injectable({
  providedIn: 'root'
})
export class SessionStorageService {

  userDetails! : UserDetails;
  constructor() { }

  isLoggedIn(): boolean {
    var userInfo = sessionStorage.getItem('userDetails');
    if (userInfo !== null && userInfo !== undefined){
      this.userDetails = JSON.parse(userInfo);
      return true;
    }
    else{
      return false;
    }
  }

  getUserDetails(): UserDetails{
    return this.userDetails;
  }

  logIn = (userInfo: UserDetails) => {
    sessionStorage.setItem('userDetails', JSON.stringify(userInfo));
  }
}