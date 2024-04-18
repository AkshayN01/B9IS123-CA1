import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
// import {OAuthService} from "angular-oauth2-oidc";
// import {ActivatedRoute} from "@angular/router";
// import { Router } from '@angular/router';
// import { AppConfig } from '../../app.config';
// import { authCodeFlowConfig } from '../../oauth/oauth-config';
import { NgxSpinnerService } from 'ngx-spinner';
import { MatSnackBar } from '@angular/material/snack-bar';
import { LoginService } from '../../services/login.service';
import { ResponseHandlerService } from '../../services/shared/response/response-handler.service';
import { UserDetails } from '../../models/userDetails/userDetails';
import { SessionStorageService } from '../../services/session-storage.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {
  showPage: boolean = false;
  loginForm!: FormGroup;
  // constructor(private oAuthService: OAuthService,
  //   private router: Router,
  //   private appConfig: AppConfig,
  //   private spinner: NgxSpinnerService,
  //   private matSnackBar: MatSnackBar) {

  // }
  constructor(private formBuilder: FormBuilder, 
    private loginService: LoginService, 
    private responseHandlerService: ResponseHandlerService, 
    private sessionStorageService:SessionStorageService,
    private router: Router
  ) {}

  // ngOnInit(): void {
  //   this.spinner.show();
  //   setTimeout(() => {
  //     if (
  //       this.oAuthService.hasValidAccessToken() &&
  //       this.oAuthService.hasValidIdToken()
  //     ) {
  //       console.debug('token valid');
  //       console.debug('state:', this.oAuthService.state);

  //       if (this.oAuthService.state) {
  //         this.router.navigateByUrl(this.oAuthService.state);
  //       } else {
  //         this.router.navigate(['/home']);
  //       }
  //     } else {
  //       console.debug('token invalid');
  //       this.showPage = true;
  //     }
  //     this.spinner.hide();
  //   }, 2000);
  // }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

   // Convenience getters for easy access to form controls
   get usernameControl() { return this.loginForm.get('username'); }
   get passwordControl() { return this.loginForm.get('password'); }

  onSubmit() {
    if (this.loginForm.invalid) {
      return;
    }
    console.log(this.loginForm.value);
    this.loginService.login(this.loginForm.value).subscribe(resposne => {
      var loginDetails = this.responseHandlerService.checkResponse(resposne);
      console.debug(loginDetails);
      var userData: UserDetails = {
        guid : loginDetails.userGuid,
        permissions: loginDetails.permissions,
        roles: loginDetails.roles,
        name: ""
      };

      this.sessionStorageService.logIn(userData);
      console.debug(userData);
      this.router.navigateByUrl('/home');
    })
  }
  // async signIn() {
  //   try {
  //     authCodeFlowConfig.issuer = this.appConfig.config.oAuth.issuer;
  //     authCodeFlowConfig.postLogoutRedirectUri = this.appConfig.config.oAuth.redirectUri;

  //     this.oAuthService.configure(authCodeFlowConfig);
  //     this.oAuthService.setupAutomaticSilentRefresh();
  //     await this.oAuthService.loadDiscoveryDocument();
  //     this.oAuthService.initLoginFlow();
  //   }
  //   catch (error) {
  //     console.log(error);
  //     this.matSnackBar.open('Hotel Management System Identity Server is not running', 'Close', {
  //       panelClass: ['bg-danger']
  //     });
  //   }
  // }
}
