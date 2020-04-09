import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Employee } from './employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private apiUrl: string = "https://localhost:44328/api/Employee";
  public formData:  Employee
  public employeeList: Employee[];
  public isFormOpen: Boolean = false;

  constructor(private httpClient: HttpClient) { }

  public GetAllEmployees(){
    return this.httpClient.get(this.apiUrl);//.toPromise().then(res=>this.employeeList=res as Employee[]);
  }
  public CreateEmployee(employee: Employee){
    return this.httpClient.post(this.apiUrl,employee);
  }
  public UpdateEmployee(employee: Employee){
    return this.httpClient.put(this.apiUrl,employee);
  }
  public DeleteEmployee(id: number){
    return this.httpClient.delete(this.apiUrl+"/"+id);
  }
}
