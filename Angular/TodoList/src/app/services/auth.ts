import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../types';

@Injectable({
  providedIn: 'root',
})
export class Auth {
  http = inject(HttpClient);
  baseURL = 'http://localhost:3000/users';

  getUserByEmail(email: string) {
    return this.http.get<User[]>(this.baseURL, {
      params: { email: email },
    });
  }

  registerUser(newUser: User) {
    return this.http.post(this.baseURL, newUser);
  }

  loginUser(email: string, password: string) {
    return this.http.get<User[]>(this.baseURL, {
      params: {
        email: email,
        password: password,
      },
    });
  }
}
