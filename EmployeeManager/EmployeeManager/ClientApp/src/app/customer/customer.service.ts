import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Customer } from './customer';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  private apiUrl: string = "https://localhost:44328/api/Customer";
  constructor(private httpClient: HttpClient) { }

  public GetAllCustomers(){
    return this.httpClient.get<Customer[]>(this.apiUrl);
  }
  public CreateCustomer(customer: Customer){
    this.httpClient.post(this.apiUrl,customer);
  }
  public UpdateCustomer(customer: Customer){
    this.httpClient.put(this.apiUrl,customer);
  }
  public DeleteCustomer(id: string){
    this.httpClient.delete(this.apiUrl+"/"+id);
  }
}
