import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Cliente } from 'src/app/cliente'; // Certifique-se de importar a classe Cliente correta
import { ClientesService } from 'src/app/clientes.service'; // Certifique-se de importar o serviço de clientes correto
import { Observer } from 'rxjs';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html', // Substitua pelo caminho real do seu template
  styleUrls: ['./clientes.component.css'], // Substitua pelo caminho real do seu arquivo CSS
})
export class ClientesComponent implements OnInit {
  formularioClientes: any;
  tituloFormulario: string = '';

  constructor(private clientesService: ClientesService) {}

  ngOnInit(): void {
    this.tituloFormulario = 'Novo Cliente';
    this.formularioClientes = new FormGroup({
      nome: new FormControl(null),
      numeroTelefone: new FormControl(null),
      email: new FormControl(null),
      login: new FormControl(null),
      senha: new FormControl(null),
    });
  }

  enviarFormulario(): void {
    const cliente: Cliente = this.formularioClientes.value;
    const observer: Observer<Cliente> = {
      next(_result): void {
        alert('cliente salvo com sucesso.');
      },
      error(_error): void {
        alert('Erro ao salvar!');
      },
      complete(): void {},
    };
    if (cliente.idCliente && !isNaN(Number(cliente.idCliente))) {
      this.clientesService.atualizar(cliente).subscribe(observer);
    } else {
      this.clientesService.cadastrar(cliente).subscribe(observer);
    }
  }
}
