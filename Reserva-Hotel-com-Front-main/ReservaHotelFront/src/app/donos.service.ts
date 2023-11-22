import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { Dono } from './Dono'; // Certifique-se de importar a classe Dono correta

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class DonosService {
  apiUrl = 'http://localhost:5000/dono';

  constructor(private http: HttpClient) { }

  listar(): Observable<Dono[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Dono[]>(url);
  }

  buscar(id: number): Observable<Dono> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.get<Dono>(url);
  }

  cadastrar(dono: Dono): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Dono>(url, dono, httpOptions);
  }

  atualizar(dono: Dono): Observable<any> {
    const url = `${this.apiUrl}/atualizar`;
    return this.http.put<Dono>(url, dono, httpOptions);
  }

  excluir(id: number): Observable<any> {
    const url = `${this.apiUrl}/excluir/${id}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
