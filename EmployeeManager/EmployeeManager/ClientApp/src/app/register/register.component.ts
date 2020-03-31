import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl, ValidatorFn, FormControl } from '@angular/forms';
import { RegisterService } from './register.service';
import { Router } from '@angular/router';
import { AuthService } from '../auth/auth.service';
import { Register } from './register';

@Component({
  selector: 'register',
  templateUrl: './register.component.html',
  styleUrls: ['../login/login.component.scss','./register.component.scss']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  loading = false;
  submitted = false;
  error = '';
  
  constructor(private formBuilder: FormBuilder,
    private service: RegisterService,             
    private router: Router,
    private authService: AuthService) {
      if(this.authService.isAuthenticated())this.router.navigate(["/"]);
     }

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      fullName: ['', [Validators.required]],
      login: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6), Validators.pattern(/^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[\W_])\S{6,30}$/)]],
      passwordConf: ['',Validators.required]});
  }

  model = new Register();

  get f() { return this.registerForm.controls; }

  public onSubmit(){
    console.log(this.f);
    this.submitted=true;
    this.error = '';
    if (this.registerForm.invalid) {
      return;
    }
    this.loading = true;
    this.model.Email=this.f.login.value;
    this.model.Password=this.f.password.value;
    this.service.register(this.model).subscribe(
      res=>{
        localStorage.setItem('token',res.toString())
        this.router.navigate(["/"])
      },err=>{
        this.error="Error occurred";
        this.loading = false;
        console.log(err);
      });
  }
}
 