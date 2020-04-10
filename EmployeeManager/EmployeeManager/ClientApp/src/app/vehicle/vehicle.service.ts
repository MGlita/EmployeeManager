import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Vehicle } from './vehicle';

@Injectable({
  providedIn: 'root'
})
export class VehicleService {
  private apiUrl: string = "https://localhost:44328/api/Vehicle";
  public formData:  Vehicle
  public vehicleList: Vehicle[];
  public isFormOpen: Boolean = false;
  constructor(private httpClient: HttpClient) { }

  public getAllVehicles(){
    return this.httpClient.get(this.apiUrl);
  }
  public createVehicle(vehicle: Vehicle){
    return this.httpClient.post(this.apiUrl, vehicle);
  }
  public updateVehicle(vehicle: Vehicle){
    return this.httpClient.put(this.apiUrl, vehicle);
  }
  public deleteVehicle(id:number){
    return this.httpClient.delete(this.apiUrl+"/"+id);
  }
}
