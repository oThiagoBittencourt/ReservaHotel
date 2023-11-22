import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReservaHotelsComponent } from './reservahoteis.component';

describe('ReservaHoteisComponent', () => {
  let component: ReservaHotelsComponent;
  let fixture: ComponentFixture<ReservaHotelsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ReservaHotelsComponent]
    });
    fixture = TestBed.createComponent(ReservaHotelsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
