import { NgModule } from '@angular/core';
import { Routes, RouterModule, CanActivate  } from '@angular/router';
import { 
  AuthGuardService as AuthGuard 
} from './auth/auth-guard.service';
import { 
  RoleGuardService as RoleGuard 
} from './auth/role-guard.service';
import { HomeComponent } from './home/home.component';
import { EmployeesComponent } from './employees/employees.component';
import { LoginComponent } from './login/login.component';
import { CustomerComponent } from './customer/customer.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { 
    path: 'employees',
    component: EmployeesComponent,
    canActivate: [RoleGuard], 
    data: { 
      expectedRole: 'HR'
    }  
  },
  { 
    path: 'customers',
    component: CustomerComponent,
    canActivate: [RoleGuard], 
    data: { 
      expectedRole: 'Sales'
    }  
  },
  { path: 'login', component: LoginComponent},
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
