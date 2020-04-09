import { Component, ViewChild, ViewEncapsulation, OnInit } from '@angular/core';
import { EmployeeService } from '../employee.service';
import {MatSort} from '@angular/material/sort';
import {MatTableDataSource} from '@angular/material/table';
import { Employee } from '../employee';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'employee-detail',
  templateUrl: './employee-detail.component.html',
  styleUrls: ['./employee-detail.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class EmployeeDetailComponent implements OnInit {

  displayedColumns: string[] = ['firstname', 'surname', 'gender', 'nationality', 'phoneNumber', 'birthDate', 'email', 'department','delete'];
  dataSource = new MatTableDataSource<Employee>();
  department: string[] = [
    'Sales',
    'Marketing',
    'Customer Service',
    'IT',
    'Top Management',
    'HR'
  ];

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;

  constructor(private employeeService: EmployeeService) {}
  

  ngOnInit() {
    this.initTable()
  }
  
  populateForm(emp: Employee){
    Object.assign(this.employeeService.formData,emp);
    this.employeeService.isFormOpen=true;
  }
  initTable(){
    this.employeeService.GetAllEmployees().subscribe(res=>{
      this.employeeService.employeeList=res as Employee[];
      this.dataSource.data=this.employeeService.employeeList;
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
    
  }

  delete(employee:Employee){
    console.log(employee);
    this.employeeService.DeleteEmployee(employee.id).subscribe(res=>{
      console.log(res)
      this.resetForm();
    },err=>{
      console.log(err);  
    },()=>{
      this.initTable();
    })
  }
  resetForm(){
    this.employeeService.formData={
      id:null,
      firstname:"",
      surname:"",
      gender:null,
      nationality:"",
      phoneNumber:"",
      birthDate: null,
      email:"",
      department:null,
      hiredDate: new Date(Date.now()),
      salary: 9999,
      jobTitle: "Ninja",
      city: "Dębno",
      street: "Topolska",
      streetNo: "123",
      zipCode: "12-123"
    }
  }
}
