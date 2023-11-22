import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { Cidade } from './Cidade'; // Certifique-se de importar a classe cliente correta

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class CidadesService {
  apiUrl = 'http://localhost:5000/cidade';

  constructor(private http: HttpClient) { }

  listar(): Observable<Cidade[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Cidade[]>(url);
  }

  buscar(id: number): Observable<Cidade> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.get<Cidade>(url);
  }

  cadastrar(cidade: Cidade): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Cidade>(url, cidade, httpOptions);
  }

  atualizar(cidade: Cidade): Observable<any> {
    const url = `${this.apiUrl}/atualizar`;
    return this.http.put<Cidade>(url, cidade, httpOptions);
  }

  excluir(id: number): Observable<any> {
    const url = `${this.apiUrl}/excluir/${id}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
