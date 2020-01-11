import { Component } from '@angular/core';
import { first } from 'rxjs/operators';

import { User } from '../models/user';
import { UserService } from '../services/user.service';
import { AuthenticationService } from '../services/authentication.service';
import { ActivatedRoute } from '@angular/router';

@Component({templateUrl: 'home.component.html'})
export class HomeComponent {
    currentUser: User;
    userFromApi: User;
    returnUrl: string;

    constructor(
        private userService: UserService,
        private authenticationService: AuthenticationService,
        private route: ActivatedRoute,

    ) {
        this.currentUser = this.authenticationService.currentUserValue;
    }

    ngOnInit() {
        this.userService.getById(this.currentUser.userid).pipe(first()).subscribe(user => { 
            this.userFromApi = user;
        });
        this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    }
}