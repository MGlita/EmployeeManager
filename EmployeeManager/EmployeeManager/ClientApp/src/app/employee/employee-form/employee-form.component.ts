import { Component, OnInit, ViewEncapsulation, ViewChild, Output,EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ValidatorFn, ValidationErrors } from '@angular/forms';
import { EmployeeService } from '../employee.service';
import { Employee } from '../employee';
import * as moment from 'moment';
import { MatTable } from '@angular/material/table';

export function minimumAge(age:number): ValidatorFn {
  return (fg: FormGroup): ValidationErrors => {
      let result: ValidationErrors = null;
      if (fg.get('birthDate').valid) {
        // carefull, moment months range is from 0 to 11
        const value = fg.get('birthDate').value;
        const date = moment(value)
        if (date.isValid()) {
          // https://momentjs.com/docs/#/displaying/difference/
          const now = moment().startOf('day');
          const yearsDiff = date.diff(now, 'years');
          if (yearsDiff > -age) {
            result = {
              'minimumAge': {
                'requiredAge': age,
                'actualAge': -yearsDiff
              }
            };
          }
        }
      }
      return result;
    };
}
@Component({
  selector: 'employee-form',
  templateUrl: './employee-form.component.html',
  styleUrls: ['./employee-form.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class EmployeeFormComponent implements OnInit {
  @Output() change = new EventEmitter();
  
  employeeForm: FormGroup;
  submitted: Boolean = false;
  error = "";
  loading = false;
  departments: string[] = [
    'Sales',
    'Marketing',
    'CustomerService',
    'IT',
    'TopManagement',
    'HR'
  ];
  constructor(
    private formBuilder: FormBuilder,
    public employeeService: EmployeeService) { }

  ngOnInit(): void {
    this.resetForm();

    this.employeeForm = this.formBuilder.group({
      firstname: ['', [Validators.required,Validators.maxLength(50)]],
      surname: ['', [Validators.required,Validators.maxLength(50)]],
      gender: ['', Validators.required],
      nationality: ['', [Validators.required, Validators.maxLength(50)]],
      phoneNumber: ['', [Validators.required,Validators.maxLength(15)]],
      birthDate: ['', [Validators.required]],
      department: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],

  });
  this.employeeForm.setValidators(minimumAge(18));
  }
  model = new Employee();

  get f() { return this.employeeForm.controls; }

  openForm(){
    this.f.department.setValue(null);
    this.f.gender.setValue(null);
    this.employeeService.isFormOpen=!this.employeeService.isFormOpen;
  }

  onSubmit(){
    this.submitted=true;
    this.error = '';
    if (this.employeeForm.invalid) {
      return;
    }
    this.loading = true;

    if(this.employeeService.formData.id==null)
      this.addEmployee();

    else 
      this.updateEmployee();
    
  }

  addEmployee(){  
    this.model.firstname = this.f.firstname.value;
    this.model.surname = this.f.surname.value;
    this.model.gender = this.f.gender.value;
    this.model.nationality = this.f.nationality.value;
    this.model.phoneNumber = this.f.phoneNumber.value;
    this.model.birthDate = new Date(this.f.birthDate.value);
    this.model.department = this.f.department.value;
    this.model.email = this.f.email.value;
    console.log(this.model);
    this.employeeService.CreateEmployee(this.model).subscribe(res=>{
        console.log(res);
        this.change.emit();
        this.submitted=false;
        this.resetForm();
      }
      ,err=>{
        this.error="Error occurred";
        console.log(err)
        this.loading = false;
      });
  }
  updateEmployee(){
    this.model.id=this.employeeService.formData.id;
    this.model.firstname = this.f.firstname.value;
    this.model.surname = this.f.surname.value;
    this.model.gender = this.f.gender.value;
    this.model.nationality = this.f.nationality.value;
    this.model.phoneNumber = this.f.phoneNumber.value;
    this.model.birthDate = new Date(this.f.birthDate.value);
    this.model.department = this.f.department.value;
    this.model.email = this.f.email.value;
    console.log(this.model);
    this.employeeService.UpdateEmployee(this.model).subscribe(res=>{
        console.log(res);
        this.change.emit();
        this.submitted=false;
        this.resetForm();
        console.log(this.f);
        console.log(this.employeeService.formData);
      },
      err=>{
        this.error="Error occurred";
        console.log(err)
        this.loading = false;
      }
      )
      
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
    this.submitted=false;
  }

}
