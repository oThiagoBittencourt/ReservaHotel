import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Hotel } from 'src/app/Hotel';
import { HoteisService } from 'src/app/hotel.service';
import { Avaliacao } from 'src/app/Avaliacao';
import { AvaliacoesService } from 'src/app/avaliacoes.service';
import { Dono } from 'src/app/Dono';
import { DonosService } from 'src/app/donos.service';
import { Cidade } from 'src/app/Cidade';
import { CidadesService } from 'src/app/cidades.service';
import { Observer } from 'rxjs';

@Component({
  selector: 'app-hoteis',
  templateUrl: './hotel.component.html',
  styleUrls: ['./hotel.component.css']
})
export class HoteisComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';
  avaliacoes: Array<Avaliacao> | undefined;
  cidades: Array<Cidade> | undefined;
  donos: Array<Dono> | undefined;

  constructor(private hoteisService: HoteisService,
              private avaliacoesService: AvaliacoesService,
              private cidadesService: CidadesService,
              private donosService: DonosService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Novo Hotel';
    this.avaliacoesService.listar().subscribe(avaliacoes => {
      this.avaliacoes = avaliacoes;
      if (this.avaliacoes && this.avaliacoes.length > 0){
        this.formulario.get('avaliacaoId')?.setValue(this.avaliacoes[0].idAvaliacao);
      }
    });
    this.cidadesService.listar().subscribe(cidades => {
      this.cidades = cidades;
      if (this.cidades && this.cidades.length > 0){
        this.formulario.get('cidadeId')?.setValue(this.cidades[0].idCidade);
      }
    });
    this.donosService.listar().subscribe(donos => {
      this.donos = donos;
      if (this.donos && this.donos.length > 0){
        this.formulario.get('donoId')?.setValue(this.donos[0].donoId);
      }
    });

    this.formulario = new FormGroup({
      nome: new FormControl(null),
      endereco: new FormControl(null),
      descricao: new FormControl(null),
      listaDeQuartos: new FormControl(null), 
      numeroTotalDeQuartos: new FormControl(null), 
      numeroDeQuartosDisponiveis: new FormControl(null), 
      cidadeId: new FormControl(null),
      donoId: new FormControl(null),
      avaliacaoId: new FormControl(null)
    });
  }

  enviarFormulario(): void {
    console.log('Método enviarFormulario() chamado.');
    const hotel: Hotel = this.formulario.value;
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
      if (hotel.idHotel && !isNaN(Number(hotel.idHotel))){
        this.hoteisService.atualizar(hotel).subscribe(observer);
      } else{
        this.hoteisService.cadastrar(hotel).subscribe(observer);
      }
    }
}
