import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { EmployeeService } from '../../../services/employee.service';
import { AddEmployeeDto } from '../../../models/employee/add-employee-dto';
import { Location } from '@angular/common';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-edit-employee',
  templateUrl: './edit-employee.component.html',
  imports: [ReactiveFormsModule],
  styleUrl: './edit-employee.component.css'
})
export class EditEmployeeComponent implements OnInit {
  employeeForm: FormGroup;
  employeeId!: number;

  constructor(
    private route: ActivatedRoute,
    private employeeService: EmployeeService,
    private router: Router, 
    private location: Location,
    private toastr: ToastrService
  ) {
    this.employeeForm = new FormGroup({
      firstName: new FormControl(''),
      lastName: new FormControl(''),
      email: new FormControl(''),
      departmentId: new FormControl<number | null>(null),
      position: new FormControl('')
    });
    this.employeeForm.get('departmentId')?.valueChanges.subscribe(value => {
      if (value === '') {
        this.employeeForm.get('departmentId')?.setValue(null, { emitEvent: false });
      }
    });
  }

  ngOnInit(): void {
    this.employeeId = Number(this.route.snapshot.paramMap.get('id'));
    console.log(this.employeeId);
    this.employeeService.getEmployeeById(this.employeeId).subscribe(emp => {
      this.employeeForm.patchValue({
        firstName: emp.fullName.split(' ')[0],
        lastName: emp.fullName.split(' ')[1],
        email: emp.email,
        departmentId: emp.departmentId,
        position: emp.position
      });

      console.log(this.employeeForm.get('departmentId')?.errors);
    });
  }
  
  
  GoBack() {
    this.location.back();
  }

  onSubmit() {
    if (this.employeeForm.valid) {
      
      const employee = this.employeeForm.value as AddEmployeeDto;
      console.log(employee);
      this.employeeService.updateEmployee(this.employeeId, employee).subscribe({
        next: () => {
          this.router.navigate(['/employee']);
          this.toastr.success('Employee updated successfully', 'Success');
        },
        error: (e) => {   
          this.toastr.error(e.error,  'Error ' + e.status, {
          timeOut: 3000
        });
        }
      });
    }
  }
}
