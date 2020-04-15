import { VehicleService } from './../vehicle.service';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Vehicle } from '../vehicle';
import * as moment from 'moment';

@Component({
  selector: 'vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.scss']
})
export class VehicleFormComponent implements OnInit {
  @Output() change = new EventEmitter();

  vehicleForm: FormGroup;
  submitted: Boolean = false;
  error = "";
  loading = false;
  vehicles: string[] = [
    'Car',
    'Tractor',
    'Trailer',
    'Other'
  ];


  constructor(
    private formBuilder: FormBuilder,
    public vehicleService: VehicleService) { }

  ngOnInit(): void {
    this.resetForm();
    this.vehicleForm = this.formBuilder.group({
      vehicleType: ['', [Validators.required]],
      make: ['', [Validators.required,Validators.maxLength(50)]],
      model: ['', [Validators.maxLength(50)]],
      registrationNumber: ['', [Validators.required,Validators.maxLength(10)]],
      productionYear: ['', [Validators.required,Validators.min(1900),Validators.max(new Date().getFullYear())]],
      technicalInspectionStart: ['',],
      technicalInspectionEnd: ['',],
      tachographStart: ['',],
      tachographEnd: ['',],
      insuranceOCStart: ['',],
      insuranceOCEnd: ['',],
      insuranceACStart: ['',],
      insuranceACEnd: ['',]
    }) 
  }

  model = new Vehicle();

  get f() {return this.vehicleForm.controls; }

  openForm(){
    this.f.vehicleType.setValue(null);
    this.vehicleService.isFormOpen=!this.vehicleService.isFormOpen;
  }

  setDateInput(date:Date, fieldName:string,duration:number){
    let dateStart = moment(date)
    dateStart = dateStart.add(duration,'year');
    this.vehicleForm.controls[fieldName].setValue(dateStart.format('YYYY-MM-DD'));
  }
  onSubmit(){
    this.submitted=true;
    this.error = '';
    if (this.vehicleForm.invalid) {
      return;
    }
    this.loading = true;

    if(this.vehicleService.formData.id==null)
      this.addVehicle();

    else 
      this.updateVehicle();
    
  }

  addVehicle(){
    this.model.vehicleType = this.f.vehicleType.value;
    this.model.make = this.f.make.value;
    this.model.model = this.f.model.value;
    this.model.registrationNumber = this.f.registrationNumber.value;
    this.model.productionYear = this.f.productionYear.value;
    this.model.technicalInspectionStart = this.f.technicalInspectionStart.value;
    this.model.technicalInspectionEnd = this.f.technicalInspectionEnd.value;
    this.model.tachographStart = this.f.tachographStart.value;
    this.model.tachographEnd = this.f.tachographEnd.value;
    this.model.insuranceOCStart = this.f.insuranceOCStart.value;
    this.model.insuranceOCEnd = this.f.insuranceOCEnd.value;
    this.model.insuranceACStart = this.f.insuranceACStart.value;
    this.model.insuranceACEnd = this.f.insuranceACEnd.value;
    console.log(this.model);
    this.vehicleService.createVehicle(this.model).subscribe(res=>{
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
  updateVehicle(){
    this.model.id=this.vehicleService.formData.id;
    this.model.vehicleType = this.f.vehicleType.value;
    this.model.make = this.f.make.value;
    this.model.model = this.f.model.value;
    this.model.registrationNumber = this.f.registrationNumber.value;
    this.model.productionYear = this.f.productionYear.value;
    this.model.technicalInspectionStart = this.f.technicalInspectionStart.value;
    this.model.technicalInspectionEnd = this.f.technicalInspectionEnd.value;
    this.model.tachographStart = this.f.tachographStart.value;
    this.model.tachographEnd = this.f.tachographEnd.value;
    this.model.insuranceOCStart = this.f.insuranceOCStart.value;
    this.model.insuranceOCEnd = this.f.insuranceOCEnd.value;
    this.model.insuranceACStart = this.f.insuranceACStart.value;
    this.model.insuranceACEnd = this.f.insuranceACEnd.value;
    this.vehicleService.updateVehicle(this.model).subscribe(res=>{
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
  resetForm(){
    this.vehicleService.formData={
      id:null,
      vehicleType:null,
      make:"",
      model:"",
      registrationNumber:"",
      productionYear:null,
      technicalInspectionStart:null,
      technicalInspectionEnd:null,
      tachographStart:null,
      tachographEnd:null,
      insuranceOCStart:null,
      insuranceOCEnd:null,
      insuranceACStart:null,
      insuranceACEnd:null,
      color:"",
    }
    this.submitted=false;
  }
}
