import { Component, OnInit } from '@angular/core';
import { DisplayEmployeeDto } from '../../../models/employee/display-employee-dto';
import { EmployeeService } from '../../../services/employee.service';
import { Router, RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrl: './employee-list.component.css'
})
export class EmployeeListComponent implements OnInit {
  constructor(private employeeService: EmployeeService, private router: Router) { }
  employeeList: DisplayEmployeeDto[] = [];

  ngOnInit(): void {
    this.employeeService.getEmployeeList().subscribe((data) => {
      this.employeeList = data;
    });
  }
  deleteEmployee(id: number) {
    this.employeeService.deleteEmployee(id).subscribe(() => {
      this.ngOnInit();
    });
  }

  editEmployee(id: number) {
    this.employeeService.getEmployeeById(id).subscribe();
    // Navigate to the edit employee page with the selected employee's ID
    this.router.navigate(['/employee/edit', id]);
  }
}
