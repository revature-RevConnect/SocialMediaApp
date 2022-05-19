import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DisplaySettingsAboutmeComponent } from './display-settings-aboutme.component';

describe('DisplaySettingsAboutmeComponent', () => {
  let component: DisplaySettingsAboutmeComponent;
  let fixture: ComponentFixture<DisplaySettingsAboutmeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DisplaySettingsAboutmeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DisplaySettingsAboutmeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
