import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AuthService } from './auth.service';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class RoleGuardService implements CanActivate {

  constructor(public auth: AuthService, public router: Router) { }

  canActivate(route: ActivatedRouteSnapshot): boolean {
    const expectedRole = route.data.expectedRole;
    const token = localStorage.getItem('token'); 
    const helper = new JwtHelperService();
    const tokenPayload = helper.decodeToken(token);

    if (!this.auth.isAuthenticated() || tokenPayload['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] !== expectedRole) {
      this.router.navigate(['login']);
      return false;
    }
    return true;
  }
}
