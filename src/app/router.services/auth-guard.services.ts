import { Injectable } from '@angular/core';
import { CanActivate, CanActivateChild, Router } from '@angular/router';

// import { UserService } from './user.service';


@Injectable()
export class AuthGuard implements CanActivate, CanActivateChild{
    constructor ( private router: Router) {}

    canActivate() : boolean {
        // if (!this.userService.isAuthenticated) {
        //     this.router.navigate(['/signin']);
        // }
        // return this.userService.isAuthenticated;
        let isAllowed: boolean = false;
        if(sessionStorage.getItem('AuthToken')==null){
            this.router.navigate(['./Login']) 
            isAllowed=true;
        }
        console.log('authguard activated');
        return isAllowed;
    }

    canActivateChild() : boolean {
        return  this.canActivate();
    }
}