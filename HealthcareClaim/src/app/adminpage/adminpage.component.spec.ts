import { HttpClientModule } from '@angular/common/http';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Router, RouterModule } from '@angular/router';
import { RouterTestingModule } from '@angular/router/testing';
//import { JwtHelperService, JWT_OPTIONS } from '@auth0/angular-jwt';
import { LoginServiceService } from '../services/login-service.service';

import { AdminpageComponent } from './adminpage.component';

describe('AdminpageComponent', () => {
  let component: AdminpageComponent;
  let fixture: ComponentFixture<AdminpageComponent>;

  beforeEach(async () => {
    let _router: Router; 
    let _service: LoginServiceService; 
    await TestBed.configureTestingModule({
      imports: [HttpClientTestingModule, HttpClientModule, RouterModule, RouterTestingModule], 
      declarations: [ AdminpageComponent ]
    })
    .compileComponents();
    _router = TestBed.inject(Router); 
    _service = TestBed.inject(LoginServiceService); 
    fixture = TestBed.createComponent(AdminpageComponent); 
    component = fixture.componentInstance; fixture.detectChanges(); 
  });

 

  it('should create', () => {
    expect(component).toBeTruthy();
  });
  it('Adminpage component Add Member', () => { 
    fixture = TestBed.createComponent(AdminpageComponent); 
    component = fixture.debugElement.componentInstance; 
    let result = component.AddMember(); 
    //console.log('login user', result); 
    expect(result).toEqual(undefined); 
  });
  it('Adminpage component Add Claim', () => { 
    fixture = TestBed.createComponent(AdminpageComponent); 
    component = fixture.debugElement.componentInstance; 
    let result = component.ClaimSave(); 
    //console.log('login user', result); 
    expect(result).toEqual(undefined); 
  });
});
