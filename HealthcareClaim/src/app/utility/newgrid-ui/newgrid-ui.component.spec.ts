import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewgridUiComponent } from './newgrid-ui.component';

describe('NewgridUiComponent', () => {
  let component: NewgridUiComponent;
  let fixture: ComponentFixture<NewgridUiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewgridUiComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewgridUiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
