import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Login } from './login';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private apiUrl: string = "https://localhost:44328/Account";

  constructor(private httpClient: HttpClient) { }

  public login(login: Login){
    return this.httpClient.post(this.apiUrl+"/Login",login);
  }

  public logout(){
    localStorage.removeItem('token');
  }
}
