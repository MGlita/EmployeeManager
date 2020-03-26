import { Component } from '@angular/core';
import { EmployeeService } from '../employees/employee.service';
import { LoginService } from './login.service';
import { Login } from './login';
import { Router } from '@angular/router';
import { AuthService } from '../auth/auth.service';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  constructor(
    private service: LoginService,             
    private router: Router,
    private authService: AuthService) {
       if(this.authService.isAuthenticated())this.router.navigate(["/"])
      }

  public Test(){
    console.log("Works");
    let login = new Login("hr@hr.com","Testpass12#");
    this.service.Login(login).subscribe(
      res=>{
        localStorage.setItem('token',res.toString())
        this.router.navigate(["/"])
      },err=>{
        console.log(err);
      });
    
    }

}