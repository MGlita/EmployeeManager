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
    this.vehicleService.formData.technicalInspectionStart = moment(veh.technicalInspectionStart).format('YYYY-MM-DD');
    this.vehicleService.formData.technicalInspectionEnd = moment(veh.technicalInspectionEnd).format('YYYY-MM-DD');
    this.vehicleService.formData.tachographStart = moment(veh.tachographStart).format('YYYY-MM-DD');
    this.vehicleService.formData.tachographEnd = moment(veh.tachographEnd).format('YYYY-MM-DD');
    this.vehicleService.formData.insuranceOCStart = moment(veh.insuranceOCStart).format('YYYY-MM-DD');
    this.vehicleService.formData.insuranceOCEnd = moment(veh.insuranceOCEnd).format('YYYY-MM-DD');
    this.vehicleService.formData.insuranceACStart = moment(veh.insuranceACStart).format('YYYY-MM-DD');
    this.vehicleService.formData.insuranceACEnd = moment(veh.insuranceACEnd).format('YYYY-MM-DD');

    console.log(new Date(veh.technicalInspectionStart).toLocaleDateString());
    console.log(new Date(veh.technicalInspectionStart).toLocaleString());
    this.vehicleService.isFormOpen=true;
  }

  initTable(){
    this.vehicleService.getAllVehicles().subscribe(res=>{
      this.vehicleService.vehicleList=res as Vehicle[];
      this.dataSource.data=this.vehicleService.vehicleList;
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
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
  // setColor(...dates:Date[]){
  //   let res =
  //   switch (key) {
  //     case value:
        
  //       break;
    
  //     default:
  //       break;
  //   }
  // }
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
