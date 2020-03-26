import { Component } from '@angular/core';
import { EmployeeService } from './employee.service';

@Component({
  selector: 'employees',
  templateUrl: './employees.component.html',
})
export class EmployeesComponent {

  constructor(private employeeService: EmployeeService) {}
  
  public Test(){
    this.employeeService.GetAllEmployees().subscribe(res=>{console.log(res)});
  }
}
