import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { ClienteService } from '../cliente.service';
import { ClienteInterface } from '../interfaces/ClienteInterface';
import { ActualizarClienteComponent } from '../actualizar-cliente/actualizar-cliente.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.css']
})
export class ClientesComponent implements OnInit {
  
  dataSource: any = [];
  displayedColumns:string[] = ['nombres','apellidos','direccion','Acciones'];

  constructor(private service:ClienteService,
              private dialog: MatDialog,
              private router: Router) { }

  ngOnInit(): void {

    this.service.getClientes()
      .subscribe((data:any) =>{
        this.dataSource = new MatTableDataSource<ClienteInterface>(data.result as ClienteInterface[]);
        console.log(data);
      },(errorData)=> this.router.navigate(['/login']));

  }

  actualizarCliente(cliente:ClienteInterface){
    console.log(cliente);

    this.dialog.open(ActualizarClienteComponent,{
      data:{
        nombres: cliente.nombres,
        apellidos: cliente.apellidos,
        direccion: cliente.direccion,
        telefono: cliente.telefono,
        id: cliente.id
      }
    });

  }

  aplicarFlitro(filtro:any){
    this.dataSource.filter = filtro.target.value.trim().toLowerCase();
  }

}
