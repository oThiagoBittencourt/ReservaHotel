import { ReservaHotel } from './ReservaHotel';

export class Pagamento {
    idPagamento: number = 0;
    metodoPagamento: string = '';
    valor: number = 0;
    dataPagamento: Date = new Date();
    reservaHotelId: number = 0;
    reservaHotel: ReservaHotel | undefined;
}
