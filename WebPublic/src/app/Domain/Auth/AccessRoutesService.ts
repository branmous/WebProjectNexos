import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Router, RouterStateSnapshot } from "@angular/router";
import { CanActivate } from "@angular/router/src/utils/preactivation";
import { StorageService } from "./StorageService";


@Injectable()
export class AccessRoutesService implements CanActivate{

    path: ActivatedRouteSnapshot[];

    route: ActivatedRouteSnapshot;

    constructor(private storageService: StorageService,
        private router: Router){

    }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

        if(this.storageService.getCurrentSession()){
            if(this.storageService.getCurrentToken()){
                return true;
            }
        }

        this.router.navigate(['/login']);
        return false;
    }
    
}