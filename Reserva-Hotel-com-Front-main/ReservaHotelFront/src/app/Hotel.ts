import { Avaliacao } from './Avaliacao';
import { Dono } from './Dono';
import { Cidade } from './Cidade';

export class Hotel {
    idHotel: number = 0;
    nome: string = '';
    endereco: string = '';
    avaliacoes: Avaliacao | undefined;
    descricao: string = '';
    listaDeQuartos: string = '';
    donoId: number = 0;
    dono: Dono | undefined;
    cidade: Cidade | undefined;
    numeroTotalDeQuartos: number = 0;
    numeroDeQuartosDisponiveis: number = 0;
}
