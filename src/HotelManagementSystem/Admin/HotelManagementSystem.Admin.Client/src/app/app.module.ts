import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms'; // Import FormsModule
import { RouterModule } from '@angular/router'; // Import RouterModule for routing

import { AppComponent } from './app.component';
import { UserComponent } from './pages/protected/user/user.component';

@NgModule({
  declarations: [
    AppComponent,
    UserComponent // Include UserComponent in declarations if it's not already there
    // Other components
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot([]), // Initialize RouterModule with empty routes array
    FormsModule // Add FormsModule to imports
    // Other modules
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
