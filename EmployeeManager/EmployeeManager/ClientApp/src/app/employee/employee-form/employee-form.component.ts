import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EmployeeService } from '../employee.service';
import { Employee } from '../employee';

@Component({
  selector: 'employee-form',
  templateUrl: './employee-form.component.html',
  styleUrls: ['./employee-form.component.scss']
})
export class EmployeeFormComponent implements OnInit {
  employeeForm: FormGroup;
  isFormOpen: Boolean = false;
  submitted: Boolean = false;
  error = "";
  loading = false;
  departments: string[] = [
    'Sales',
    'Marketing',
    'Customer Service',
    'IT',
    'Top Management',
    'HR'
  ];
  constructor(
    private formBuilder: FormBuilder,
    private employeeService: EmployeeService) { }

  ngOnInit(): void {

    this.employeeForm = this.formBuilder.group({
      firstname: ['', [Validators.required]],
      surname: ['', Validators.required],
      gender: ['', Validators.required],
      nationality: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      birthDate: ['', Validators.required],
      department: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],

  });
  
  }
  model = new Employee();

  get f() { return this.employeeForm.controls; }

  openForm(){
    this.f.department.setValue(null);
    this.isFormOpen=!this.isFormOpen;
  }

  onSubmit(){
    console.log(this.f);
    this.submitted=true;
    this.error = '';
    if (this.employeeForm.invalid) {
      return;
    }
    this.loading = true;
    this.model.firstname = this.f.firstname.value;
    this.model.surname = this.f.surname.value;
    this.model.gender = this.f.gender.value;
    this.model.nationality = this.f.nationality.value;
    this.model.phoneNumber = this.f.phoneNumber.value;
    //this.model.birthDate = this.f.birthDate.value;
    this.model.department = 1;//this.f.department.value;
    this.model.email = this.f.email.value;
    console.log(this.model);
    this.employeeService.CreateEmployee(this.model).subscribe(res=>{console.log(res)}
      ,err=>{
        this.error="Error occurred";
        console.log(err)
        this.loading = false;
      });
  }
}
