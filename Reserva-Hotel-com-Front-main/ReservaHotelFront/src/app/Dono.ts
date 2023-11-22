import { Hotel } from './Hotel';

export class Dono {
    donoId: number = 0;
    nome: string = '';
    numeroTelefone: number = 0;
    email: string = '';
    login: string = '';
    senha: string = '';
    hotelId: number = 0;
    hotel: Hotel | undefined;
}
