import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { API_URL } from '../constants';
import { UserInfo } from '../models/userinfo';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private httpClient: HttpClient, private router: Router) { }

  isAuthenticated(): boolean {
    return localStorage.getItem('token') !== null;
  }

  register(email: string, username: string, password: string): Observable<UserInfo> {

    const userInfo: UserInfo = {
      email: email,
      username: username,
      password: password
    };

    return this.httpClient.post<UserInfo>(`${API_URL}/token/register`, userInfo);
  }

  login(userInfo: UserInfo): Observable<any> {
    return this.httpClient.post<any>(`${API_URL}/token/login`, userInfo);
  }

  logout(): void {
    localStorage.removeItem('token');
  }

  redirectToLogin(): void {
    this.router.navigate(['auth/login']);
  }
}
