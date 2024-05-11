import { TestBed } from '@angular/core/testing';

import { MeteoDataService } from './meteo-data.service';

describe('MeteoDataService', () => {
  let service: MeteoDataService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MeteoDataService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
