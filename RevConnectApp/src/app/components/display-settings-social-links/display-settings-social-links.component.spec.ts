import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DisplaySettingsSocialLinksComponent } from './display-settings-social-links.component';

describe('DisplaySettingsSocialLinksComponent', () => {
  let component: DisplaySettingsSocialLinksComponent;
  let fixture: ComponentFixture<DisplaySettingsSocialLinksComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DisplaySettingsSocialLinksComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DisplaySettingsSocialLinksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
