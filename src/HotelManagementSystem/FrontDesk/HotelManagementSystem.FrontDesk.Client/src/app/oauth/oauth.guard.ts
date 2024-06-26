import { Injectable, inject } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router, CanActivateFn } from '@angular/router';
import { OAuthService } from 'angular-oauth2-oidc';
import { Observable, of } from 'rxjs';
import { SessionStorageService } from '../services/shared/session/session-storage.service';

@Injectable({
  providedIn: 'root'
})
class OauthGuard {

  constructor(private router: Router, private oAuthService: OAuthService, private sesssionStorageService: SessionStorageService) {

  }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    let canActivate = false;
    if (this.sesssionStorageService.isLoggedIn()) 
    {
      console.log("OAuth valid");
      canActivate = true;
    } 
    else {
      canActivate = false;
      return this.router.createUrlTree(['/login'], {queryParams: {returnUrl: state.url}});
    }
    console.debug('canActivate:', canActivate);
    return of(canActivate).pipe();
  }
  // canActivate(
  //   route: ActivatedRouteSnapshot,
  //   state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
  //   let canActivate = false;
  //   if (
  //     this.oAuthService.hasValidAccessToken() &&
  //     this.oAuthService.hasValidIdToken()
  //   ) 
  //   {
  //     console.log("OAuth valid");
  //     canActivate = true;
  //   } 
  //   else {
  //     canActivate = false;
  //     return this.router.createUrlTree(['/login'], {queryParams: {returnUrl: state.url}});
  //   }
  //   console.debug('canActivate:', canActivate);
  //   return of(canActivate).pipe();
  // }
}

export const isAuthGuard: CanActivateFn = ( route: ActivatedRouteSnapshot, state: RouterStateSnapshot) => 
{
    return inject(OauthGuard).canActivate(route, state);
}