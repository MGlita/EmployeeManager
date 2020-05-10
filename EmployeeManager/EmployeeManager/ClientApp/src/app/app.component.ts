import { LoginService } from './login/login.service';
import { Component, ViewEncapsulation } from '@angular/core';
import { AuthService } from './auth/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class AppComponent {
  title = 'EmployeeManager';
  constructor(private loginService: LoginService, private authService: AuthService) {}
  
  logout(){
    this.loginService.logout();
  }
  isLoggedIn(){
    return this.authService.isAuthenticated();
  }
}
