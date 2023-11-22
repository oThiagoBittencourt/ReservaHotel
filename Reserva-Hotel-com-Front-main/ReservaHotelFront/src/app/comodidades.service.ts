import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { Comodidade } from './Comodidade'; // Certifique-se de importar a classe Comodidade correta

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class ComodidadesService {
  apiUrl = 'http://localhost:5000/comodidade';

  constructor(private http: HttpClient) { }

  listar(): Observable<Comodidade[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Comodidade[]>(url);
  }

  buscar(id: number): Observable<Comodidade> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.get<Comodidade>(url);
  }

  cadastrar(Comodidade: Comodidade): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Comodidade>(url, Comodidade, httpOptions);
  }

  atualizar(Comodidade: Comodidade): Observable<any> {
    const url = `${this.apiUrl}/atualizar`;
    return this.http.put<Comodidade>(url, Comodidade, httpOptions);
  }

  excluir(id: number): Observable<any> {
    const url = `${this.apiUrl}/excluir/${id}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
