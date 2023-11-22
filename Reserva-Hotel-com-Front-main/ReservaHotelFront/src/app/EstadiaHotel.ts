import { ReservaHotel } from "./ReservaHotel";

export class EstadiaHotel {
    idEstadia: number = 0;
    qtdQuartos: number = 0;
    dataEntrada: Date = new Date();
    dataSaida: Date = new Date();
    reservaId: number = 0;
    reserva: ReservaHotel | undefined;
}
