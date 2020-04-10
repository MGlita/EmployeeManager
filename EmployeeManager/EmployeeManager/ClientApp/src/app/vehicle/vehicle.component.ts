import { Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'vehicle',
  templateUrl: './vehicle.component.html',
  styleUrls: ['./vehicle.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class VehicleComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
