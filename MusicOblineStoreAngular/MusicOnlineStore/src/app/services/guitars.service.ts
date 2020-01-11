import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GuitarsTypes } from '../models/guitars';

@Injectable({ providedIn: 'root' })
export class GuitarsTypesService {
    constructor(private http: HttpClient) { }

    getGuitarsTypes() {
        return this.http.get<GuitarsTypes[]>(`https://localhost:44390/guitarstypes`);
    }

}