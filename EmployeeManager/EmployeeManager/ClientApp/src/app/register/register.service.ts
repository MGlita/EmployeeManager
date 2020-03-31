import { Register } from './register';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  private apiUrl: string = "https://localhost:44328/Account";

  constructor(private httpClient: HttpClient) { }

  public register(model: Register){
    return this.httpClient.post(this.apiUrl+"/Register",model);
  }
}
