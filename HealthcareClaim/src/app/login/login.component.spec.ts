
import { HttpClientModule } from '@angular/common/http';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Router, RouterModule } from '@angular/router';
import { RouterTestingModule } from '@angular/router/testing';
//import { JwtHelperService, JWT_OPTIONS } from '@auth0/angular-jwt';
import { LoginServiceService } from '../services/login-service.service';

import { LoginComponent } from './login.component';

describe('LoginComponent', () => {
    let component: LoginComponent; 
    let fixture: ComponentFixture<LoginComponent>;

    beforeEach(async () => { 
        let _router: Router; 
        let _service: LoginServiceService; 
        await TestBed.configureTestingModule({ 
            imports: [HttpClientTestingModule, HttpClientModule, RouterModule, RouterTestingModule], 
            declarations: [LoginComponent], 
             }).compileComponents(); 
            _router = TestBed.inject(Router); 
            _service = TestBed.inject(LoginServiceService); 
            fixture = TestBed.createComponent(LoginComponent); 
            component = fixture.componentInstance; fixture.detectChanges(); 
        });

    it('should create', () => { expect(component).toBeTruthy(); }); 
    it('login component login user', () => { 
        fixture = TestBed.createComponent(LoginComponent); 
        component = fixture.debugElement.componentInstance; 
        let result = component.loginUser(); 
        console.log('login user', result); 
        expect(result).toEqual(undefined); 
    });
});

