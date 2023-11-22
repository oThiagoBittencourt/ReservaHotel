import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ComodidadesComponent } from './comodidades.component';

describe('ComodidadesComponent', () => {
  let component: ComodidadesComponent;
  let fixture: ComponentFixture<ComodidadesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ComodidadesComponent]
    });
    fixture = TestBed.createComponent(ComodidadesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
