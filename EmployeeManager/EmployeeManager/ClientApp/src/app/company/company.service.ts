import { Company } from './company';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {
  private apiUrl: string = "https://localhost:44328/api/Company";
  constructor(private httpClient: HttpClient) { }

  public getAllCompanies(){
    return this.httpClient.get<Company[]>(this.apiUrl);
  }
  public createCompany(company: Company){
    this.httpClient.post(this.apiUrl,company);
  }
  public updateCompany(company: Company){
    this.httpClient.put(this.apiUrl,company);
  }
  public deleteCompany(id: string){
    this.httpClient.delete(this.apiUrl+"/"+id);
  }
}
