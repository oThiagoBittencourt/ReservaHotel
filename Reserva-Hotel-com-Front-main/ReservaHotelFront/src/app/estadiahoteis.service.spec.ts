import { TestBed } from '@angular/core/testing';

import { EstadiaHoteisService } from './estadiahoteis.service';

describe('EstadiaHoteisService', () => {
  let service: EstadiaHoteisService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EstadiaHoteisService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
