import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddLikeComponent } from './add-like.component';

describe('AddLikeComponent', () => {
  let component: AddLikeComponent;
  let fixture: ComponentFixture<AddLikeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddLikeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddLikeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
