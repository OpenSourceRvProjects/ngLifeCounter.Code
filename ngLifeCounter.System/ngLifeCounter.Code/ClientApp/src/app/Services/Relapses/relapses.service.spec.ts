import { TestBed } from '@angular/core/testing';

import { RelapsesService } from './relapses.service';

describe('RelapsesService', () => {
  let service: RelapsesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RelapsesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
