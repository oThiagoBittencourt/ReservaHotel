import { Hotel } from './Hotel';

export class Comodidade {
    iDComodidade: number = 0;
    numeroDoQuarto: number = 0;
    tipoDeQuarto: string = '';
    precoPorNoite: number = 0;
    descricao: string = '';
    disponibilidade: boolean | undefined;
    hotelId: number = 0;
    hotel: Hotel | undefined;
}
