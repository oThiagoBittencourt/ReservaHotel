import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { EstadiaHotel } from './EstadiaHotel'; // Certifique-se de importar a classe EstadiaHotel correta

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class EstadiaHoteisService {
  apiUrl = 'http://localhost:5000/Estadia';

  constructor(private http: HttpClient) { }

  listar(): Observable<EstadiaHotel[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<EstadiaHotel[]>(url);
  }

  buscar(id: number): Observable<EstadiaHotel> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.get<EstadiaHotel>(url);
  }

  cadastrar(EstadiaHotel: EstadiaHotel): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<EstadiaHotel>(url, EstadiaHotel, httpOptions);
  }

  atualizar(EstadiaHotel: EstadiaHotel): Observable<any> {
    const url = `${this.apiUrl}/atualizar`;
    return this.http.put<EstadiaHotel>(url, EstadiaHotel, httpOptions);
  }

  excluir(id: number): Observable<any> {
    const url = `${this.apiUrl}/excluir/${id}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
