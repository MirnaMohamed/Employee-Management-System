import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { DisplayEmployeeDto } from '../models/employee/display-employee-dto';
import { AddEmployeeDto } from '../models/employee/add-employee-dto';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private apiUrl = environment.apiUrl + '/employee';
  constructor(private http: HttpClient) { }
  getEmployeeList() {
    return this.http.get<DisplayEmployeeDto[]>(this.apiUrl)
  }
  getEmployeeListByPageNumber(pageNum: number, pageSize: number = 5): Observable<DisplayEmployeeDto[]> {
    const params = new HttpParams()
      .set('pageSize', pageSize.toString());
    return this.http.get<DisplayEmployeeDto[]>(this.apiUrl + `page/${pageNum}`, { params });
  }
  deleteEmployee(id: number){
    return this.http.delete(this.apiUrl + '/' + id)
  }
  getEmployeeById(id: number) {
    return this.http.get<DisplayEmployeeDto>(this.apiUrl + '/' + id)
  }
  addEmployee(employee: AddEmployeeDto) {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<AddEmployeeDto>(this.apiUrl, employee, httpOptions);
  }

  updateEmployee(id:number, employee: AddEmployeeDto) {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.put<AddEmployeeDto>(this.apiUrl + `/${id}`, employee, httpOptions);
  }
}
