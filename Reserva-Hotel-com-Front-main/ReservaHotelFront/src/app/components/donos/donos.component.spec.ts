import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DonosComponent } from './donos.component';

describe('DonosComponent', () => {
  let component: DonosComponent;
  let fixture: ComponentFixture<DonosComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DonosComponent]
    });
    fixture = TestBed.createComponent(DonosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
