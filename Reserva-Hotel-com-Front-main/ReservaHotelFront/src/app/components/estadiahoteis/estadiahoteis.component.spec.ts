import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EstadiaHotelComponent } from './estadiahoteis.component';

describe('EstadiaHoteisComponent', () => {
  let component: EstadiaHotelComponent;
  let fixture: ComponentFixture<EstadiaHotelComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EstadiaHotelComponent]
    });
    fixture = TestBed.createComponent(EstadiaHotelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
