import { Component } from '@angular/core';
import { AuthService } from '../auth/auth.service';
import { Router } from '@angular/router';
import { faUserTie, faUserFriends, faTruckMoving } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  faUserTie = faUserTie;
  faUserFriends = faUserFriends;
  faTruckMoving = faTruckMoving;

constructor(
  private authService: AuthService,
  private router: Router, ) {
  if(!this.authService.isAuthenticated())this.router.navigate(['login']);

}

  public onCustomers(){
    this.router.navigate(["customers"]);
  }
  public onEmployees(){
    this.router.navigate(["employees"]);
  }
  public onVehicles(){
    this.router.navigate(["vehicle"]);
  }
}
