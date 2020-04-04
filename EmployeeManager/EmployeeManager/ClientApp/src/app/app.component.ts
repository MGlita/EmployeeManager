import { LoginService } from './login/login.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'EmployeeManager';
  constructor(private loginService: LoginService) {}
  
  logout(){
    this.loginService.logout();
  }
}
