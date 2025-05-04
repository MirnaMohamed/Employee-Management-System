import { Component, Inject } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { EmployeeService } from '../../../services/employee.service';
import { AddEmployeeDto } from '../../../models/employee/add-employee-dto';
import { Location } from '@angular/common';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-employee',
  imports: [ReactiveFormsModule],
  templateUrl: './add-employee.component.html',
  styleUrl: './add-employee.component.css'
})
export class AddEmployeeComponent {
  
  constructor(private location: Location,
    private employeeService: EmployeeService,
    private toastr: ToastrService
  ) { }

  employeeForm: FormGroup = new FormGroup({
    firstName: new FormControl<string>(''),
    lastName: new FormControl<string>(''),
    email: new FormControl<string>(''),
    departmentId: new FormControl<number| null>(null),
    position: new FormControl<string>('')
  });
  onSubmit() {
    let employee = this.employeeForm.value as AddEmployeeDto;
    if (this.employeeForm.valid)
      this.employeeService.addEmployee(employee).subscribe({
        next: () => {
          this.location.back();
          this.toastr.success('Employee added successfully', 'Success');
        },
        
        error: (e) => { 
          this.toastr.error(e.error,  'Error ' + e.status, {
          timeOut: 3000
        });
        }
      });
  }

  GoBack() {
    this.location.back();
  }
}
