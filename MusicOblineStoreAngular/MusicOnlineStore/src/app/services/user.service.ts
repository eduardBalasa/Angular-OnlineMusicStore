import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/user';

@Injectable({ providedIn: 'root' })
export class UserService {
    constructor(private http: HttpClient) { }

    getAll() {
        return this.http.get<User[]>(`https://localhost:44390/users`);
    }

    getById(id: number) {
        return this.http.get<User>(`https://localhost:44390/users/${id}`);
    }

    register(user: User) {
        return this.http.post(`https://localhost:44390/users/register`, user);
    }

    delete(id: number) {
        return this.http.delete(`https://localhost:44390/users/${id}`);
    }
}