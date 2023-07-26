import { HttpResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { ResultModel } from 'src/app/models/result.model';
import { CommonService } from 'src/app/services/common.service';
import { EmployeeService } from 'src/app/services/employee.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent {
  displayedColumns: string[] = ['id', 'nombre', 'edad','salario','salarioanual','profile'];
  buscar = { id: null}

  constructor(
    private eService: EmployeeService,
    private commonService: CommonService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.consultar();
  }

  data: any[] = [];
  

  dataSource = new MatTableDataSource(this.data);

  buscarEmpleado(value : any){
    if (value == '') {
      this.commonService.showError('Error: ' + 'Debe ingresar el número de id del empleado');
    }else if (isNaN(value)) {
      this.commonService.showError('Error: ' + 'Debe ingresar el número de id del empleado');
      
    }else{
      this.eService.consultarXId(value).subscribe((result: HttpResponse<ResultModel>) =>{
        if (result.body?.status == "Success") {
          console.log(result.body.data);
          this.data = [];
          this.data.push(result.body.data);
          //this.data = result.body.data;
        }else{
          this.commonService.showError('Error' + result.body?.message);
        }
      });
      
    }
     
  }

  limpiar(event : any){
    if (event == '') {
      this.consultar();
    }
  }

  consultar() {
    this.eService.consultar().subscribe((result: HttpResponse<ResultModel>) => {
      if (result.ok) {
        if (result.body?.status == "Success") {
          this.data = result.body.data;
          console.log(result.body.data);
        } else {
          this.commonService.showError('Error: ' + result.body?.message);
        }
      } else {
        this.commonService.showError('Error');
      }
    }, (error: any) => {
      console.log('Error', error);
      this.commonService.showError('Error');
    });
  }
}
