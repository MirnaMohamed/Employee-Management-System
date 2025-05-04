import { Component, OnInit } from '@angular/core';
import { DisplayEmployeeDto } from '../../../models/employee/display-employee-dto';
import { EmployeeService } from '../../../services/employee.service';
import { Router, RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { ToastrModule, ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrl: './employee-list.component.css'
})
export class EmployeeListComponent implements OnInit {
  constructor(private employeeService: EmployeeService, 
              private router: Router,
              private toastr: ToastrService) { }
  employeeList: DisplayEmployeeDto[] = [];

  ngOnInit(): void {
    this.employeeService.getEmployeeList().subscribe((data) => {
      this.employeeList = data;
    });
  }
  deleteEmployee(id: number) {
    this.employeeService.deleteEmployee(500).subscribe({
      next: () => {
        this.toastr.success('Employee deleted successfully', 'Success');
        this.ngOnInit();
      },
      error: (e) => { 
        this.toastr.error(e.error,  'Error ' + e.status, {
        timeOut: 3000
      });
      }
    });
  }

  editEmployee(id: number) {
    this.employeeService.getEmployeeById(id).subscribe( () => 
      this.router.navigate(['/employee/edit', id]) 
    );
  }
}
