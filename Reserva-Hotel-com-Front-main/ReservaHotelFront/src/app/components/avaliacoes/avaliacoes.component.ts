import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Avaliacao } from 'src/app/Avaliacao'; // Certifique-se de importar a classe Avaliacao correta
import { AvaliacoesService } from 'src/app/avaliacoes.service'; // Certifique-se de importar o serviço de avaliações correto
import { Hotel } from 'src/app/Hotel'; // Certifique-se de importar a classe Hotel correta
import { HoteisService } from 'src/app/hotel.service'; // Certifique-se de importar o serviço de hotéis correto
import { Observer } from 'rxjs';

@Component({
  selector: 'app-avaliacoes',
  templateUrl: './avaliacoes.component.html', // Substitua pelo caminho real do seu template
  styleUrls: ['./avaliacoes.component.css'] // Substitua pelo caminho real do seu arquivo CSS
})
export class AvaliacoesComponent implements OnInit {
  formularioAvaliacao: any;
  tituloFormulario: string = '';
  hoteis: Array<Hotel> | undefined;

  constructor(private avaliacoesService: AvaliacoesService,
              private hoteisService: HoteisService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Nova Avaliação';
    this.hoteisService.listar().subscribe(hoteis => {
      this.hoteis = hoteis;
      if (this.hoteis && this.hoteis.length > 0){
        this.formularioAvaliacao.get('hotelId')?.setValue(this.hoteis[0].idHotel);
      }
    });
    this.formularioAvaliacao = new FormGroup({
      comentario: new FormControl(null),
      avaliacaoEstrelas: new FormControl(null),
      dataAvaliacao: new FormControl(null),
      hotelId: new FormControl(null)
    });
  }

  enviarFormulario(): void {
    console.log('Método enviarFormulario() chamado.');
    const avaliacao: Avaliacao = this.formularioAvaliacao.value;
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
      if (avaliacao.idAvaliacao && !isNaN(Number(avaliacao.idAvaliacao))){
        this.avaliacoesService.atualizar(avaliacao).subscribe(observer);
      } else{
        this.avaliacoesService.cadastrar(avaliacao).subscribe(observer);
      }
    }
}