import { Component, OnInit } from '@angular/core';
import { DisplayEmployeeDto } from '../../../models/employee/display-employee-dto';
import { EmployeeService } from '../../../services/employee.service';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrl: './employee-list.component.css'
})
export class EmployeeListComponent implements OnInit {
  constructor(private employeeService: EmployeeService) { }
  employeeList: DisplayEmployeeDto[] = [];

  ngOnInit(): void {
    this.employeeService.getEmployeeList().subscribe((data) => {
      this.employeeList = data;
    });
  }

}
