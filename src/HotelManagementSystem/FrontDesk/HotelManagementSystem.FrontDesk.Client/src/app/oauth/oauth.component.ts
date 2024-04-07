import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { OAuthService } from 'angular-oauth2-oidc';
import { AppConfig } from '../app.config';
import { authCodeFlowConfig } from './oauth-config';
import { NgxSpinnerService } from 'ngx-spinner';
import {MatSnackBar} from '@angular/material/snack-bar';
import { MatCard } from '@angular/material/card';

@Component({
  selector: 'app-oauth',
  templateUrl: './oauth.component.html'
})
export class OAuthComponent implements OnInit {
  showPage: boolean = false;
  constructor(private oAuthService: OAuthService,
    private router: Router,
    private appConfig: AppConfig,
    private spinner: NgxSpinnerService,
    private matSnackBar: MatSnackBar,
  private matCard: MatCard) {

  }

  ngOnInit(): void {
    this.spinner.show();
    setTimeout(() => {
      if (
        this.oAuthService.hasValidAccessToken() &&
        this.oAuthService.hasValidIdToken()
      ) {
        console.debug('token valid');
        console.debug('state:', this.oAuthService.state);

        if (this.oAuthService.state) {
          this.router.navigateByUrl(this.oAuthService.state);
        } else {
          this.router.navigate(['/distribution']);
        }
      } else {
        console.debug('token invalid');
        this.showPage = true;
      }
      this.spinner.hide();
    }, 2000);
  }

  async signIn() {
    try {
      authCodeFlowConfig.issuer = this.appConfig.config.oAuth.issuer;
      authCodeFlowConfig.postLogoutRedirectUri = this.appConfig.config.oAuth.redirectUri;

      this.oAuthService.configure(authCodeFlowConfig);
      this.oAuthService.setupAutomaticSilentRefresh();
      await this.oAuthService.loadDiscoveryDocument();
      this.oAuthService.initLoginFlow();
    }
    catch (error) {
      console.log(error);
      this.matSnackBar.open('Hotel Management System Identity Server is not running', 'Close', {
        panelClass: ['bg-danger']
      });
    }
  }
}