import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { ReservaHotel } from './ReservaHotel'; // Certifique-se de importar a classe ReservaHotel correta

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class ReservaHoteisService {
  apiUrl = 'http://localhost:5000/reserva';

  constructor(private http: HttpClient) { }

  listar(): Observable<ReservaHotel[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<ReservaHotel[]>(url);
  }

  buscar(id: number): Observable<ReservaHotel> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.get<ReservaHotel>(url);
  }

  cadastrar(reservaHotel: ReservaHotel): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<ReservaHotel>(url, reservaHotel, httpOptions);
  }

  atualizar(reservaHotel: ReservaHotel): Observable<any> {
    const url = `${this.apiUrl}/atualizar`;
    return this.http.put<ReservaHotel>(url, reservaHotel, httpOptions);
  }

  excluir(id: number): Observable<any> {
    const url = `${this.apiUrl}/excluir/${id}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
