import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Comodidade } from 'src/app/Comodidade'; // Certifique-se de importar a classe Comodidade correta
import { ComodidadesService } from 'src/app/comodidades.service'; // Certifique-se de importar o serviço de comodidades correto
import { Hotel } from 'src/app/Hotel'; // Certifique-se de importar a classe Hotel correta
import { HoteisService } from 'src/app/hotel.service'; // Certifique-se de importar o serviço de hotéis correto
import { Observer } from 'rxjs';

@Component({
  selector: 'app-comodidades',
  templateUrl: './comodidades.component.html', // Substitua pelo caminho real do seu template
  styleUrls: ['./comodidades.component.css'] // Substitua pelo caminho real do seu arquivo CSS
})
export class ComodidadesComponent implements OnInit {
  formularioComodidades: any;
  tituloFormulario: string = '';
  hoteis: Array<Hotel> | undefined;

  constructor(private comodidadesService: ComodidadesService,private hoteisService: HoteisService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Nova Comodidade';
    this.hoteisService.listar().subscribe(hoteis => {
      this.hoteis = hoteis;
      if (this.hoteis && this.hoteis.length > 0){
        this.formularioComodidades.get('hotelId')?.setValue(this.hoteis[0].idHotel);
      }
    });
    this.formularioComodidades = new FormGroup({
      NumeroDoQuarto: new FormControl(null),
      TipoDeQuarto: new FormControl(null),
      PrecoPorNoite: new FormControl(null),
      Descricao: new FormControl(null),
      Disponibilidade: new FormControl(null),
      hotelId: new FormControl(null)
    });
  }

  enviarFormulario(): void {
    console.log('Método enviarFormulario() chamado.');
    const comodidade: Comodidade = this.formularioComodidades.value;
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
      if (comodidade.iDComodidade && !isNaN(Number(comodidade.iDComodidade))){
        this.comodidadesService.atualizar(comodidade).subscribe(observer);
      } else{
        this.comodidadesService.cadastrar(comodidade).subscribe(observer);
      }
    }
}
