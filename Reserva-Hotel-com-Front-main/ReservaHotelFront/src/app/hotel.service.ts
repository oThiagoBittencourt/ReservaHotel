import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { Hotel } from './Hotel'; // Certifique-se de importar a classe Hotel correta

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class HoteisService {
  apiUrl = 'http://localhost:5000/hotel';

  constructor(private http: HttpClient) { }

  listar(): Observable<Hotel[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Hotel[]>(url);
  }

  buscar(id: number): Observable<Hotel> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.get<Hotel>(url);
  }

  cadastrar(hotel: Hotel): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Hotel>(url, hotel, httpOptions);
  }

  atualizar(hotel: Hotel): Observable<any> {
    const url = `${this.apiUrl}/atualizar`;
    return this.http.put<Hotel>(url, hotel, httpOptions);
  }

  excluir(id: number): Observable<any> {
    const url = `${this.apiUrl}/excluir/${id}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
