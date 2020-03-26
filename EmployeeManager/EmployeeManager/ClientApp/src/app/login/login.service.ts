import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Login } from './login';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private apiUrl: string = "https://localhost:44328/Account";

  constructor(private httpClient: HttpClient) { }

  public Login(login: Login){
    return this.httpClient.post(this.apiUrl+"/Login",login);
  }
}
