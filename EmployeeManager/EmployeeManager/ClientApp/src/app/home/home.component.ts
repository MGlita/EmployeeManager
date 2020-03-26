import { Component } from '@angular/core';
import { EmployeeService } from '../employees/employee.service';

@Component({
  selector: 'home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  
constructor(private employeeService: EmployeeService) {}

  public DeleteToken(){
    localStorage.setItem('token',"");
  }

  public Test(){
    this.employeeService.GetAllEmployees().subscribe(res=>{console.log(res)});
  }
}
