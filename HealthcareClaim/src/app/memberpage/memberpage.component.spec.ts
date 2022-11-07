import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MemberpageComponent } from './memberpage.component';

xdescribe('MemberpageComponent', () => {
  let component: MemberpageComponent;
  let fixture: ComponentFixture<MemberpageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MemberpageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MemberpageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
