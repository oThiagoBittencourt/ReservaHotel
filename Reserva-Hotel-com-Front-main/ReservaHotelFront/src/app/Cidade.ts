import { Hotel } from './Hotel';

export class Cidade {
    idCidade: number = 0;
    nome: string = '';
    estado: string = '';
    pais: string = '';
    descricao: string = '';
    hotelId: number = 0;
    hotel: Hotel | undefined;
}
