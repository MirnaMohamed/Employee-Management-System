import { Routes } from '@angular/router';
import { EmployeeListComponent } from './pages/employee/employee-list/employee-list.component';
import { AddEmployeeComponent } from './pages/employee/add-employee/add-employee.component';

export const routes: Routes = [
    {path: 'employee/add', component: AddEmployeeComponent},
    {path: 'employee', component: EmployeeListComponent},
    {path: '', redirectTo: 'employee', pathMatch: 'full'},

];
