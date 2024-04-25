import { TestBed } from '@angular/core/testing';

import { MapPopupService } from './map-popup.service';

describe('MapPopupService', () => {
  let service: MapPopupService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MapPopupService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
