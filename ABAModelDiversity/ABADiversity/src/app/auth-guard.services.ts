import { Injectable } from '@angular/core';
import { CanActivate, CanActivateChild, Router } from '@angular/router';

// import { UserService } from './user.service';

@Injectable()
export class AuthGuard implements CanActivate, CanActivateChild{
    constructor ( private router: Router) {}

    canActivate() : boolean {
      
        let isAllowed: boolean = false;
        // if(sessionStorage.getItem('Cache0')==null){
        //     this.router.navigate(['./Login']) 
        // }
        // else{
        //     isAllowed=true;
        // }
        if(sessionStorage.getItem('BWAPI')==null){
            this.router.navigate(['./Login']) 
        }
        else{
            isAllowed=true;
        }
        return isAllowed;
    }

    canActivateChild() : boolean {
        return  this.canActivate();
    }
}