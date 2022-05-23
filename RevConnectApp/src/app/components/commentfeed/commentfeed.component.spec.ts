import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CommentfeedComponent } from './commentfeed.component';

describe('CommentfeedComponent', () => {
  let component: CommentfeedComponent;
  let fixture: ComponentFixture<CommentfeedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CommentfeedComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CommentfeedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
