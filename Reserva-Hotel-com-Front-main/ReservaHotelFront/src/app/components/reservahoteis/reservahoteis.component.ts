import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ReservaHotel } from 'src/app/ReservaHotel';
import { ReservaHoteisService } from 'src/app/reservahoteis.service';
import { Observer } from 'rxjs';
@Component({
  selector: 'app-reservahotels',
  templateUrl: './reservahoteis.component.html',
  styleUrls: ['./reservahoteis.component.css']
})
export class ReservaHotelsComponent implements OnInit {
  formularioReservaHotel: any;
  tituloFormulario: string = '';

  constructor(private reservaHotelService: ReservaHoteisService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Nova Reserva de Hotel';
    this.formularioReservaHotel = new FormGroup({
      NomeHospede: new FormControl(null)
    });
  }

  enviarFormulario(): void {
    console.log('Método enviarFormulario() chamado.');
    const reserva: ReservaHotel = this.formularioReservaHotel.value;
    const observer: Observer<ReservaHotel> = {
        next(_result): void{
          alert('Modelo salvo com sucesso.');
        },
        error(_error): void {
          alert('Erro ao salvar!');
        },
        complete(): void {
        },
        };
      if (reserva.idReserva && !isNaN(Number(reserva.idReserva))){
        this.reservaHotelService.atualizar(reserva).subscribe(observer);
      } else{
        this.reservaHotelService.cadastrar(reserva).subscribe(observer);
      }
    }
  }
