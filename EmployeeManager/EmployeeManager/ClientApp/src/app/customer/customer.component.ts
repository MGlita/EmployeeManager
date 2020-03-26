import { Component, OnInit } from '@angular/core';
import { CustomerService } from './customer.service';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {

  constructor(private customerService: CustomerService) { }

  ngOnInit(): void {
  }

  GetAllCustomers(){
    this.customerService.GetAllCustomers().subscribe(res=>console.log(res));
  }
}
