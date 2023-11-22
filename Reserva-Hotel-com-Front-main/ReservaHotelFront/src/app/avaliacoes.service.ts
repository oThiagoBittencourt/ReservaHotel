import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { Avaliacao } from './Avaliacao';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class AvaliacoesService {
  apiUrl = 'http://localhost:5000/avaliacao';

  constructor(private http: HttpClient) { }

  listar(): Observable<Avaliacao[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Avaliacao[]>(url);
  }

  buscar(id: number): Observable<Avaliacao> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.get<Avaliacao>(url);
  }

  cadastrar(Avaliacao: Avaliacao): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Avaliacao>(url, Avaliacao, httpOptions);
  }

  atualizar(Avaliacao: Avaliacao): Observable<any> {
    const url = `${this.apiUrl}/atualizar`;
    return this.http.put<Avaliacao>(url, Avaliacao, httpOptions);
  }

  excluir(id: number): Observable<any> {
    const url = `${this.apiUrl}/excluir/${id}`;
    return this.http.delete<string>(url, httpOptions);
  }
}