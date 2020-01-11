import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DrumsTypes } from '../models/drums';

@Injectable({ providedIn: 'root' })
export class DrumsTypesService {
    constructor(private http: HttpClient) { }

    getDrumsTypes() {
        return this.http.get<DrumsTypes[]>(`https://localhost:44390/drumstypes`);
    }

}