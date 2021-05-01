import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { AuthenticationService, } from '../services/authentication.service';
import { HttpService } from '../services/http.service';
import { Users } from '../Interfaces/user';


@Component({templateUrl: 'register.component.html'})
export class RegisterComponent implements OnInit {
    registerForm: FormGroup;
    loading = false;
    submitted = false;
    public user: Users;

    constructor(
        private formBuilder: FormBuilder,
        private router: Router,
        private authenticationService: AuthenticationService,
        private httpservice: HttpService
    ) { 
        this.user = {
            id: 0,
            firstName: "", 
            lastName: "", 
            username: "", 
            password: ""
          };
        if (this.authenticationService.currentUserValue) { 
            this.router.navigate(['/']);
        }

    }

    ngOnInit() {
        this.registerForm = this.formBuilder.group({
            firstName: ['', Validators.required],
            lastName: ['', Validators.required],
            username: ['', Validators.required],
            password: ['', [Validators.required, Validators.minLength(6)]]
        });
    }

    get f() { return this.registerForm.controls; }

    onSubmit() {
        this.submitted = true;

        if (this.registerForm.invalid) {
            return;
        }

        this.loading = true;
        // this.user.firstName = this.registerForm.value('firstName');
        this.httpservice.register('https://localhost:44330/api/user',this.registerForm.value)
            .pipe(first())
            .subscribe(
                data => {
                    this.router.navigate(['/login']);
                },
                error => {
                    this.loading = false;
                });
    }
}