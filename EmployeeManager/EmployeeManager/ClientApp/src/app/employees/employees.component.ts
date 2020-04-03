import { Component, ViewChild } from '@angular/core';
import { EmployeeService } from './employee.service';
import {MatSort} from '@angular/material/sort';
import {MatTableDataSource} from '@angular/material/table';
import { Employee } from './employee';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employee.component.scss'],
})
export class EmployeesComponent {

  displayedColumns: string[] = ['firstname', 'surname', 'gender', 'nationality', 'phoneNumber', 'birthDate', 'email', 'department'];
  dataSource = new MatTableDataSource<Employee>();
  department: string[] = [
    'Sales',
    'Marketing',
    'Customer Service',
    'IT',
    'TopManagement',
    'HR'
  ];

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;

  constructor(private employeeService: EmployeeService) {}
  

  ngOnInit() {
    this.getAllEmployees();
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  public getAllEmployees(){
    return this.employeeService.GetAllEmployees().toPromise().then(res=>this.dataSource.data=res);
  }
}
