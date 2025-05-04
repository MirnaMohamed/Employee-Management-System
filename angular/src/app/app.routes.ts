import { Routes } from '@angular/router';
import { EmployeeListComponent } from './pages/employee/employee-list/employee-list.component';
import { AddEmployeeComponent } from './pages/employee/add-employee/add-employee.component';
import { EditEmployeeComponent } from './pages/employee/edit-employee/edit-employee.component';

export const routes: Routes = [
    {path: 'employee/add', component: AddEmployeeComponent},
    {path: 'employee/edit/:id', component: EditEmployeeComponent},
    {path: 'employee', component: EmployeeListComponent},
    {path: '', redirectTo: 'employee', pathMatch: 'full'},

];
