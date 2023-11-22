import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Cidade } from 'src/app/Cidade'; // Certifique-se de importar a classe Cidade correta
import { CidadesService } from 'src/app/cidades.service'; // Certifique-se de importar o serviço de cidades correto
import { Hotel } from 'src/app/Hotel'; // Certifique-se de importar a classe Hotel correta
import { HoteisService } from 'src/app/hotel.service'; // Certifique-se de importar o serviço de hotéis correto
import { Observer } from 'rxjs';

@Component({
  selector: 'app-cidades',
  templateUrl: './cidades.component.html', // Substitua pelo caminho real do seu template
  styleUrls: ['./cidades.component.css'] // Substitua pelo caminho real do seu arquivo CSS
})
export class CidadesComponent implements OnInit {
  formularioCidades: any;
  tituloFormulario: string = '';
  hoteis: Array<Hotel> | undefined;

  constructor(private cidadesService: CidadesService, private hoteisService: HoteisService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Nova Cidade';
    this.hoteisService.listar().subscribe(hoteis => {
      this.hoteis = hoteis;
      if (this.hoteis && this.hoteis.length > 0){
        this.formularioCidades.get('hotelId')?.setValue(this.hoteis[0].idHotel);
      }
    });
    this.formularioCidades = new FormGroup({
      Nome: new FormControl(null),
      Estado: new FormControl(null),
      País: new FormControl(null),
      Descricao: new FormControl(null),
      hotelId: new FormControl(null)
    });
  }

  enviarFormulario(): void {
    console.log('Método enviarFormulario() chamado.');
    const cidade: Cidade = this.formularioCidades.value;
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
      if (cidade.idCidade && !isNaN(Number(cidade.idCidade))){
        this.cidadesService.atualizar(cidade).subscribe(observer);
      } else{
        this.cidadesService.cadastrar(cidade).subscribe(observer);
      }
    }
}
