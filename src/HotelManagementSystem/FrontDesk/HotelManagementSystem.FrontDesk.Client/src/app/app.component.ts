import { Component } from '@angular/core';
import { AppConfig } from './app.config';
import { NavigationEnd, Router } from '@angular/router';
import { authCodeFlowConfig } from './oauth/oauth-config';
import { JwksValidationHandler, OAuthService } from 'angular-oauth2-oidc';
import { filter } from 'rxjs/internal/operators/filter';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  constructor(private router: Router, private oauthService: OAuthService, private appConfig: AppConfig) {
    this.configureCodeFlow();
  }

  private configureCodeFlow() {
    console.log(this.appConfig.config.oAuth.issuer)
    authCodeFlowConfig.issuer = this.appConfig.config.oAuth.issuer;
    authCodeFlowConfig.postLogoutRedirectUri = this.appConfig.config.oAuth.postLogoutRedirectUri;
    const sameSiteCookie = window.location.protocol === 'https:' ? 'None' : 'None';
    document.cookie = `idsrv.session=...; SameSite=${sameSiteCookie}`;
    this.oauthService.configure(authCodeFlowConfig);
    this.oauthService.setupAutomaticSilentRefresh();
    this.oauthService.tokenValidationHandler = new JwksValidationHandler();
    this.oauthService.loadDiscoveryDocumentAndTryLogin({
      onTokenReceived: () => {
        console.debug('state:', this.oauthService.state);
        // this.router.navigateByUrl(encodeURIComponent(this.oauthService.state));
      }
    });
    // Automatically load user profile
    this.oauthService.events
      .pipe(filter(e => e.type === 'token_received'))
      .subscribe(async (_) => {
        console.debug('token_received: loading discovery document');
        await this.oauthService.loadDiscoveryDocument();
        console.debug('token_receivedh: loaded discovery document');
        console.debug('token_receivedh: loading user profile');
        await this.oauthService.loadUserProfile();
        console.debug('token_received: loaded user profile');
      });

    this.oauthService.events.subscribe(e => {
      console.debug('oauth/oidc event', e);
    });

    this.router.events.subscribe(async (event) => {
      if (event instanceof NavigationEnd) {
        console.debug('page refresh: loading discovery document');
        await this.oauthService.loadDiscoveryDocument();
        console.debug('page refresh: loaded discovery document');

        if (this.oauthService.hasValidAccessToken()) {
          console.debug('page refresh: loading user profile');
          await this.oauthService.loadUserProfile();
          console.debug('page refresh: loaded user profile');
        }
      }
    });
  }
}
