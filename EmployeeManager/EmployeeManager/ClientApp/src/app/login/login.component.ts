import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../employees/employee.service';
import { LoginService } from './login.service';
import { Login } from './login';
import { Router } from '@angular/router';
import { AuthService } from '../auth/auth.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  loading = false;
  submitted = false;
  error = '';
  constructor(
    private formBuilder: FormBuilder,
    private service: LoginService,             
    private router: Router,
    private authService: AuthService) {
       if(this.authService.isAuthenticated())this.router.navigate(["/"])
      };
  
  ngOnInit() {
      this.loginForm = this.formBuilder.group({
        login: ['', [Validators.required, Validators.email]],
        password: ['', Validators.required]
    });
  }

  model = new Login("","");

  get f() { return this.loginForm.controls; }

  public onSubmit(){
    this.submitted=true;
    this.error = '';
    if (this.loginForm.invalid) {
      return;
    }
    this.loading = true;
    console.log(this.f);
    let login = new Login(this.f.login.value,this.f.password.value);

    this.service.login(login).subscribe(
      res=>{
        localStorage.setItem('token',res.toString())
        this.router.navigate(["/"])
      },err=>{
        if(err.status==401)this.error="Invalid email or password";
        else this.error="Error occurred";
        this.loading = false;
        console.log(err.status);
      });
    
    }

}