import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DisplaySettingsGeneralComponent } from './display-settings-general.component';

describe('DisplaySettingsGeneralComponent', () => {
  let component: DisplaySettingsGeneralComponent;
  let fixture: ComponentFixture<DisplaySettingsGeneralComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DisplaySettingsGeneralComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DisplaySettingsGeneralComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
