import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Employee } from './employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private apiUrl: string = "https://localhost:44328/api/Employee";

  constructor(private httpClient: HttpClient) { }

  public GetAllEmployees(){
    return this.httpClient.get<Employee[]>(this.apiUrl);
  }
  public CreateEmployee(employee: Employee){
    this.httpClient.post(this.apiUrl,employee);
  }
  public UpdateEmployee(employee: Employee){
    this.httpClient.put(this.apiUrl,employee);
  }
  public DeleteEmployee(id: string){
    this.httpClient.delete(this.apiUrl+"/"+id);
  }
}
