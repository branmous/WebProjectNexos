import {Injectable} from "@angular/core";
import { Router } from '@angular/router';
import { UserContract } from "../../Contracts/Auth/UserContract";

@Injectable()
export class StorageService {

  private localStorageService;
  private currentSession : UserContract = null;

  constructor(private router: Router) {
    this.localStorageService = localStorage;
    this.currentSession = this.loadSessionData();
  }

  setCurrentSession(session: UserContract): void {
    this.currentSession = session;
    this.localStorageService.setItem('currentUser', JSON.stringify(session));
  }

  loadSessionData(): UserContract{
    var sessionStr = this.localStorageService.getItem('currentUser');
    return (sessionStr) ? <UserContract> JSON.parse(sessionStr) : null;
  }

  getCurrentSession(): UserContract {
    return this.currentSession;
  }

  removeCurrentSession(): void {
    this.localStorageService.removeItem('currentUser');
    this.currentSession = null;
  }

  getCurrentUser(): UserContract {
    var session: UserContract = this.getCurrentSession();
    return (session && session) ? session : null;
  };

  isAuthenticated(): boolean {
    return (this.getCurrentToken() != null) ? true : false;
  };

  getCurrentToken(): string {
    var session = this.getCurrentSession();
    return (session && session.Token) ? session.Token : null;
  };

  logout(): void{
    this.removeCurrentSession();
    this.router.navigate(['/login']);
  }

}