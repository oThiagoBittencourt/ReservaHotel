import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { EstadiaHotel } from 'src/app/EstadiaHotel';
import { EstadiaHoteisService } from 'src/app/estadiahoteis.service';
import { Observer } from 'rxjs';

@Component({
  selector: 'app-estadiahotel',
  templateUrl: './estadiahoteis.component.html',
  styleUrls: ['./estadiahoteis.component.css']
})
export class EstadiaHotelComponent implements OnInit {
  formularioEstadiaHotel: any;
  tituloFormulario: string = '';
  

  constructor(private estadiaHotelService: EstadiaHoteisService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Nova Estadia em Hotel';
    this.formularioEstadiaHotel = new FormGroup({
      QtdQuartos: new FormControl(null),
      DataEntrada: new FormControl(null),
      DataSaida: new FormControl(null)
    });
  }

  enviarFormulario(): void {
    console.log('Método enviarFormulario() chamado.');
    const estadia: EstadiaHotel = this.formularioEstadiaHotel.value;
    const observer: Observer<EstadiaHotel> = {
        next(_result): void{
          alert('Modelo salvo com sucesso.');
        },
        error(_error): void {
          alert('Erro ao salvar!');
        },
        complete(): void {
        },
        };
      if (estadia.idEstadia && !isNaN(Number(estadia.idEstadia))){
        this.estadiaHotelService.atualizar(estadia).subscribe(observer);
      } else{
        this.estadiaHotelService.cadastrar(estadia).subscribe(observer);
      }
    }
}
