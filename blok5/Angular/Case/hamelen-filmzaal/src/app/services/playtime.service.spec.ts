import { TestBed } from '@angular/core/testing';

import { PlaytimeService } from './playtime.service';

describe('PlaytimeService', () => {
  let service: PlaytimeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PlaytimeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
