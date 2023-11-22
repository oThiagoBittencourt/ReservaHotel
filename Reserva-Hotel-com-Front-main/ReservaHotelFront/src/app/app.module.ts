import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ModalModule } from 'ngx-bootstrap/modal';


import { AvaliacoesService } from './avaliacoes.service';
import { AvaliacoesComponent } from './components/avaliacoes/avaliacoes.component';

import { CidadesService } from './cidades.service';
import { CidadesComponent } from './components/cidades/cidades.component';

import { ClientesService } from './clientes.service';
import { ClientesComponent } from './components/clientes/clientes.component';

import { ComodidadesService } from './comodidades.service';
import { ComodidadesComponent } from './components/comodidades/comodidades.component';

import { DonosService } from './donos.service';
import { DonosComponent } from './components/donos/donos.component';

import { EstadiaHoteisService } from './estadiahoteis.service';
import { EstadiaHotelComponent } from './components/estadiahoteis/estadiahoteis.component';

import { HoteisService } from './hotel.service';
import { HoteisComponent } from './components/hotel/hotel.component';

import { PagamentosService } from './pagamentos.service';
import { PagamentosComponent } from './components/pagamentos/pagamentos.component';

import { ReservaHoteisService } from './reservahoteis.service';
import { ReservaHotelsComponent } from './components/reservahoteis/reservahoteis.component';


@NgModule({
  declarations: [
    AppComponent,
    AvaliacoesComponent,
    CidadesComponent,
    ClientesComponent,
    ComodidadesComponent,
    DonosComponent,
    EstadiaHotelComponent,
    HoteisComponent,
    PagamentosComponent,
    ReservaHotelsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    ModalModule.forRoot()
  ],
  providers: [
    HttpClientModule,
    HoteisService,
    ClientesService,
    AvaliacoesService,
    CidadesService,
    ComodidadesService,
    DonosService,
    EstadiaHoteisService,
    PagamentosService,
    ReservaHoteisService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
