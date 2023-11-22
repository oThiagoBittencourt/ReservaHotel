import { Hotel } from './Hotel';

export class Avaliacao {
    idAvaliacao: number = 0;
    avaliacaoEstrelas: number = 0;
    comentario: string = '';
    dataAvaliacao: Date = new Date();
    hotelId: number = 0;
    hotel: Hotel | undefined;
}
