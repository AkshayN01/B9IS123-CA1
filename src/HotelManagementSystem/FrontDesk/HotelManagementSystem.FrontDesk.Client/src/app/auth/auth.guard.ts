import {Injectable} from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot} from '@angular/router';
import {OAuthService} from 'angular-oauth2-oidc';
import { SessionStorageService } from '../services/shared/session/session-storage.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private router: Router, private oauthService: OAuthService, private sesssionStorageService: SessionStorageService) {
  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    if (this.sesssionStorageService.isLoggedIn()) {
      return true;
    }
    else{
      return this.router.createUrlTree(['/login'], {queryParams: {returnUrl: state.url}});
    }
  }
  

  // constructor(private router: Router, private oauthService: OAuthService) {
  // }

  // canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
  //   if (this.hasValidToken()) {
  //     return true;
  //   }

  //   return from(this.oauthService.loadDiscoveryDocumentAndTryLogin()).pipe(
  //     map(() => {
  //       if (this.hasValidToken()) {
  //         return true;
  //       }

  //       return this.router.createUrlTree(['/login'], {queryParams: {returnUrl: state.url}});
  //     })
  //   )
  // }

  private hasValidToken() {
    return this.oauthService.hasValidAccessToken() && this.oauthService.hasValidIdToken();
  }
}