import { Pagamento } from './Pagamento';
import { EstadiaHotel } from './EstadiaHotel';

export class ReservaHotel {
    idReserva: number = 0;
    nomeHospede: string = '';
    pagamento: Pagamento | undefined;
    estadia: EstadiaHotel | undefined;
}
