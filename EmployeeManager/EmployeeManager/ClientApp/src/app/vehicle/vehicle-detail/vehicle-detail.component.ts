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
  
  displayedColumns: string[] = ['vehicleType', 'make', 'model', 'registrationNumber', 'productionYear', 'technicalDays', 'tachographDays', 'insuranceOCDays', 'insuranceACDays', 'delete'];
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
      this.setDays();
      this.dataSource.data=this.vehicleService.vehicleList;
      this.vehicleService.vehicleList.forEach(veh =>{
        let min = this.findMin(veh.technicalInspectionEnd,veh.tachographEnd,veh.insuranceOCEnd,veh.insuranceACEnd)
        veh.minDay=min.toString();
        veh.color = this.setColor(min);
        console.log(veh);
      })
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
      this.dataSource.sortingDataAccessor = (data, header) => data[header];
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
    if(date==null)return -999
    let endDate = moment(date);
    let dayDiff = endDate.diff(new Date(), 'days',false)
    //console.log(dayDiff)
    return dayDiff;
    //return isNaN(dayDiff)?"Not":dayDiff;
  }

  setDays(){
    this.vehicleService.vehicleList.forEach(veh =>{
      veh.technicalDays=veh.technicalInspectionEnd?this.daysToEnd(new Date(veh.technicalInspectionEnd)).toString()  :"None";
      veh.tachographDays=veh.tachographEnd?this.daysToEnd(new Date(veh.tachographEnd)).toString()  :"None";
      veh.insuranceOCDays=veh.insuranceOCEnd?this.daysToEnd(new Date(veh.insuranceOCEnd)).toString()  :"None";
      veh.insuranceACDays=veh.insuranceACEnd?this.daysToEnd(new Date(veh.insuranceACEnd)).toString()  :"None";
    })
  }

  findMin(...dates:string[]){
    let daysArr = new Array();
    dates.forEach(element => {
      if(moment(element).isValid()){
      daysArr.push(this.daysToEnd(new Date(element)));
      }
    });
    return Math.min(...daysArr)
  }

  setColor(day){
    switch (true) {
      case day>=50:
        return "#90ee90"
        break;
      case day<50&&day>=30:
        return "#ffffba"
        break;
      case day<30:
        return "#ff726f"
        break;
      default:
        break;
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
      technicalDays:"",
      tachographStart:null,
      tachographEnd:null,
      tachographDays:"",
      insuranceOCStart:null,
      insuranceOCEnd:null,
      insuranceOCDays:"",
      insuranceACStart:null,
      insuranceACEnd:null,
      insuranceACDays:"",
      minDay:"",
      color:"",
    }
  }
}
