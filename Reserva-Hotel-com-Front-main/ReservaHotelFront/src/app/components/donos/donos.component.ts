import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Dono } from 'src/app/Dono';
import { DonosService } from 'src/app/donos.service';
import { Hotel } from 'src/app/Hotel';
import { HoteisService } from 'src/app/hotel.service';
import { Observer } from 'rxjs';

@Component({
  selector: 'app-donos',
  templateUrl: './donos.component.html',
  styleUrls: ['./donos.component.css']
})
export class DonosComponent implements OnInit {
  formularioDonos: any;
  tituloFormulario: string = '';
  hoteis: Array<Hotel> | undefined;

  constructor(private donosService: DonosService, private hoteisService: HoteisService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Novo Dono';
    this.hoteisService.listar().subscribe(hoteis => {
      this.hoteis = hoteis;
      if (this.hoteis && this.hoteis.length > 0){
        this.formularioDonos.get('hotelId')?.setValue(this.hoteis[0].idHotel);
      }
    });
    this.formularioDonos = new FormGroup({
      Nome: new FormControl(null),
      NumeroTelefone: new FormControl(null),
      Email: new FormControl(null),
      Login: new FormControl(null),
      Senha: new FormControl(null),
      hotelId: new FormControl(null)
    });
  }

  enviarFormulario(): void {
    console.log('Método enviarFormulario() chamado.');
    const dono: Dono = this.formularioDonos.value;
    const observer: Observer<Hotel> = {
        next(_result): void{
          alert('Modelo salvo com sucesso.');
        },
        error(_error): void {
          alert('Erro ao salvar!');
        },
        complete(): void {
        },
        };
      if (dono.donoId && !isNaN(Number(dono.donoId))){
        this.donosService.atualizar(dono).subscribe(observer);
      } else{
        this.donosService.cadastrar(dono).subscribe(observer);
      }
    }
}

