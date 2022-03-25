import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserInterface } from './interfaces/userInterface';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  
  baseUrl:string =  'http://localhost:5118/api/Users/';

  constructor(private http:HttpClient,
    private router:Router) { }

  register(user:UserInterface){
    return this.http.post(this.baseUrl+'Register',user);
  }

  login(user:UserInterface){
    return this.http.post(this.baseUrl+'Login',user);
  }
  
  logout(){
    localStorage.removeItem('userName');
    localStorage.removeItem('token_value');
    this.router.navigate(['/clientes']);
    window.location.reload();
  }

  get getUsername(){
    return localStorage.getItem('userName');
  }

  get isAutenticado(){
    return !!localStorage.getItem('token_value')
  }
}
