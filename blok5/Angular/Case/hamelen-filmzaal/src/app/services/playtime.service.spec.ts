import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { PlaytimeService } from './playtime.service';

describe('PlaytimeService', () => {
  let service: PlaytimeService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [PlaytimeService],
    });
    service = TestBed.inject(PlaytimeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
