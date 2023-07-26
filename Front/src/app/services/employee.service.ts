import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ResultModel } from '../models/result.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private base_url: string = 'https://localhost:7155/api';

  constructor(private http: HttpClient) {
  }

  public consultar() {
    return this.http.get<ResultModel>(`${this.base_url}/Employee`, { observe: 'response' });
  }

  public consultarXId(id: number) {
    return this.http.get<ResultModel>(`${this.base_url}/Employee/${id}`, { observe: 'response' });
  }
}
