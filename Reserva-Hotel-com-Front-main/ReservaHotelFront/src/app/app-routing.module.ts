import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HoteisComponent } from './components/hotel/hotel.component';
import { ClientesComponent } from './components/clientes/clientes.component';
import { AvaliacoesComponent } from './components/avaliacoes/avaliacoes.component';
import { CidadesComponent } from './components/cidades/cidades.component';
import { ComodidadesComponent } from './components/comodidades/comodidades.component';
import { DonosComponent } from './components/donos/donos.component';
import { EstadiaHotelComponent } from './components/estadiahoteis/estadiahoteis.component';
import { PagamentosComponent } from './components/pagamentos/pagamentos.component';
import { ReservaHotelsComponent } from './components/reservahoteis/reservahoteis.component';

const routes: Routes = [
  { path: 'avaliacao', component: AvaliacoesComponent },
  { path: 'cidade', component: CidadesComponent },
  { path: 'cliente', component: ClientesComponent },
  { path: 'comodidade', component: ComodidadesComponent },
  { path: 'dono', component: DonosComponent },
  { path: 'estadiahotel', component: EstadiaHotelComponent },
  { path: 'hotel', component: HoteisComponent },
  { path: 'pagamento', component: PagamentosComponent },
  { path: 'reservahotel', component: ReservaHotelsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
