import { TestBed } from '@angular/core/testing';

import { SignalRclientService } from './signal-rclient.service';

describe('SignalRclientService', () => {
  let service: SignalRclientService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SignalRclientService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
