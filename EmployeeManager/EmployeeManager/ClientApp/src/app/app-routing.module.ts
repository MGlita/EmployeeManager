import { NgModule } from '@angular/core';
import { Routes, RouterModule, CanActivate  } from '@angular/router';
import { 
  AuthGuardService as AuthGuard 
} from './auth/auth-guard.service';
import { 
  RoleGuardService as RoleGuard 
} from './auth/role-guard.service';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { CustomerComponent } from './customer/customer.component';
import { RegisterComponent } from './register/register.component';
import { EmployeeComponent } from './employee/employee.component';
import { VehicleComponent } from './vehicle/vehicle.component';

const routes: Routes = [
  { path: '', component: HomeComponent,
    canActivate: [AuthGuard]
  },
  { 
    path: 'employees',
    component: EmployeeComponent,
    canActivate: [AuthGuard] 
    // data: { 
    //   expectedRole: 'HR'
    // }  
  },
  { 
    path: 'customers',
    component: CustomerComponent,
    canActivate: [AuthGuard] 
    // data: { 
    //   expectedRole: 'Sales'
    // }  
  },
  {
    path: 'vehicle',
    component: VehicleComponent,
    canActivate: [AuthGuard]
  },
  { path: 'login', component: LoginComponent},
  { path: 'register', component: RegisterComponent},
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
