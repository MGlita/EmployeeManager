import { VehicleService } from './../vehicle.service';
import { Component, OnInit, ViewEncapsulation, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Vehicle } from '../vehicle';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import * as moment from 'moment';


@Component({
  selector: 'vehicle-detail',
  templateUrl: './vehicle-detail.component.html',
  styleUrls: ['./vehicle-detail.component.scss'],
  encapsulation: ViewEncapsulation.None

})
export class VehicleDetailComponent implements OnInit {
  
  displayedColumns: string[] = ['vehicleType', 'make', 'model', 'registrationNumber', 'productionYear', 'technicalInsp', 'tachograph', 'insuranceOC', 'insuranceAC', 'delete'];
  dataSource = new MatTableDataSource<Vehicle>();
  vehicleType: string[] = [
    'Car',
    'Tractor',
    'Trailer',
    'Other'
  ];

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;

  constructor(private vehicleService: VehicleService) { }

  ngOnInit(): void {
    this.initTable();
    
  }

  populateForm(veh: Vehicle){
    Object.assign(this.vehicleService.formData,veh);
    this.vehicleService.formData.technicalInspectionStart = moment(veh.technicalInspectionStart).isValid()?moment(veh.technicalInspectionStart).format('YYYY-MM-DD'):null;
    this.vehicleService.formData.technicalInspectionEnd = moment(veh.technicalInspectionEnd).isValid()?moment(veh.technicalInspectionEnd).format('YYYY-MM-DD'):null;
    this.vehicleService.formData.tachographStart = moment(veh.tachographStart).isValid()?moment(veh.tachographStart).format('YYYY-MM-DD'):null;
    this.vehicleService.formData.tachographEnd = moment(veh.tachographEnd).isValid()?moment(veh.tachographEnd).format('YYYY-MM-DD'):null;
    this.vehicleService.formData.insuranceOCStart = moment(veh.insuranceOCStart).isValid()?moment(veh.insuranceOCStart).format('YYYY-MM-DD'):null;
    this.vehicleService.formData.insuranceOCEnd = moment(veh.insuranceOCEnd).isValid()?moment(veh.insuranceOCEnd).format('YYYY-MM-DD'):null;
    this.vehicleService.formData.insuranceACStart = moment(veh.insuranceACStart).isValid()?moment(veh.insuranceACStart).format('YYYY-MM-DD'):null;
    this.vehicleService.formData.insuranceACEnd = moment(veh.insuranceACEnd).isValid()?moment(veh.insuranceACEnd).format('YYYY-MM-DD'):null;
    this.vehicleService.isFormOpen=true;
  }

  initTable(){
    this.vehicleService.getAllVehicles().subscribe(res=>{
      this.vehicleService.vehicleList=res as Vehicle[];
      this.dataSource.data=this.vehicleService.vehicleList;
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
      this.vehicleService.vehicleList.forEach(veh =>{
        veh.color=this.setColor(veh.technicalInspectionEnd,veh.insuranceOCEnd,veh.insuranceACEnd);
      })
    });
  }
 
  delete(vehicle:Vehicle){
    console.log(vehicle);
    this.vehicleService.deleteVehicle(vehicle.id).subscribe(res=>{
      console.log(res)
      this.resetForm();
    },err=>{
      console.log(err);  
    },()=>{
      this.initTable();
    })
  }

  daysToEnd(date:Date){
    let endDate = moment(date);
    let dayDiff = endDate.diff(new Date(), 'days',false)
    return isNaN(dayDiff)?"Not":dayDiff;
  }

  setColor(...dates:string[]){
    let daysArr = new Array();
    dates.forEach(element => {
      if(moment(element).isValid()){
      daysArr.push(this.daysToEnd(new Date(element)));
      }
    });
    if(daysArr!==undefined){
    let dayMin = Math.min(...daysArr)
    switch (true) {
      case dayMin>=50:
        return "#90ee90"
        break;
      case dayMin<50&&dayMin>=30:
        return "#ffffba"
        break;
      case dayMin<30:
        return "#ff726f"
        break;
      default:
        break;
    }
    }
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
  }
}
