import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Pagamento } from 'src/app/Pagamento';
import { PagamentosService } from 'src/app/pagamentos.service';
import { Observer } from 'rxjs';
import { ReservaHotel } from 'src/app/ReservaHotel';
import { ReservaHoteisService } from 'src/app/reservahoteis.service';

@Component({
  selector: 'app-pagamentos',
  templateUrl: './pagamentos.component.html',
  styleUrls: ['./pagamentos.component.css']
})
export class PagamentosComponent implements OnInit {
  formularioPagamentos: any;
  tituloFormulario: string = '';
  reservas: Array<ReservaHotel> | undefined;

  constructor(private pagamentoService: PagamentosService, private reservaHoteisService: ReservaHoteisService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Novo Pagamento';
    this.reservaHoteisService.listar().subscribe(reservas => {
      this.reservas = reservas;
      if (this.reservas && this.reservas.length > 0){
        this.formularioPagamentos.get('reservaHotelId')?.setValue(this.reservas[0].idReserva);
      }
    });
    this.formularioPagamentos = new FormGroup({
      MetodoPagamento: new FormControl(null),
      Valor: new FormControl(null),
      DataPagamento: new FormControl(null)
    });
  }

  enviarFormulario(): void {
    console.log('Método enviarFormulario() chamado.');
    const pagamento: Pagamento = this.formularioPagamentos.value;
    const observer: Observer<Pagamento> = {
        next(_result): void{
          alert('Modelo salvo com sucesso.');
        },
        error(_error): void {
          alert('Erro ao salvar!');
        },
        complete(): void {
        },
        };
      if (pagamento.idPagamento && !isNaN(Number(pagamento.idPagamento))){
        this.pagamentoService.atualizar(pagamento).subscribe(observer);
      } else{
        this.pagamentoService.cadastrar(pagamento).subscribe(observer);
      }
    }
}
