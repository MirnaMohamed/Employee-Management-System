import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { DisplayEmployeeDto } from '../models/employee/display-employee-dto';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private apiUrl = environment.apiUrl + '/employee';
  constructor(private http: HttpClient) { }
  getEmployeeList() {
    return this.http.get<DisplayEmployeeDto[]>(this.apiUrl)
  }
}
