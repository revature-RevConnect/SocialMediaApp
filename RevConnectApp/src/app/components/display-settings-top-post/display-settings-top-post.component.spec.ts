import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DisplaySettingsTopPostComponent } from './display-settings-top-post.component';

describe('DisplaySettingsTopPostComponent', () => {
  let component: DisplaySettingsTopPostComponent;
  let fixture: ComponentFixture<DisplaySettingsTopPostComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DisplaySettingsTopPostComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DisplaySettingsTopPostComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
