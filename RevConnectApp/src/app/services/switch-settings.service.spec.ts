import { TestBed } from '@angular/core/testing';

import { SwitchSettingsService } from './switch-settings.service';

describe('SwitchSettingsService', () => {
  let service: SwitchSettingsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SwitchSettingsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
