import { Injectable  } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ClienteInterface } from './interfaces/ClienteInterface';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  
  baseUrl:string =  'http://localhost:5118/api/Clientes/';

  constructor(private http: HttpClient) { }

  getClientes(){
    return this.http.get(this.baseUrl);
  }

  getCliente(id:number){
    return this.http.get(this.baseUrl+id);
  }

  crearCliente(cliente:ClienteInterface){
    return this.http.post(this.baseUrl,cliente);
  }
  
  actualizarCliente(id:number, cliente:ClienteInterface){
    
    return this.http.put(this.baseUrl+id,cliente);
  }

  deleteCliente(id:number){
     return this.http.delete(this.baseUrl+id);
  }

}
