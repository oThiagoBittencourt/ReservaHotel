import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { Cliente } from './cliente'; // Certifique-se de importar a classe cliente correta

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class ClientesService {
  apiUrl = 'http://localhost:5000/cliente';

  constructor(private http: HttpClient) { }

  listar(): Observable<Cliente[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Cliente[]>(url);
  }

  buscar(id: number): Observable<Cliente> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.get<Cliente>(url);
  }

  cadastrar(Cliente: Cliente): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Cliente>(url, Cliente, httpOptions);
  }

  atualizar(Cliente: Cliente): Observable<any> {
    const url = `${this.apiUrl}/atualizar`;
    return this.http.put<Cliente>(url, Cliente, httpOptions);
  }

  excluir(id: number): Observable<any> {
    const url = `${this.apiUrl}/excluir/${id}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
