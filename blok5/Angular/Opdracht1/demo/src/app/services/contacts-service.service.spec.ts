import { TestBed } from '@angular/core/testing';

import { ContactsServiceService } from './contacts-service.service';

describe('ContactsServiceService', () => {
  let service: ContactsServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ContactsServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
