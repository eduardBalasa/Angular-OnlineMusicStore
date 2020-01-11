import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MicrophonesTypes } from '../models/microphones';

@Injectable({ providedIn: 'root' })
export class MicrophonesTypesService {
    constructor(private http: HttpClient) { }

    getMicrophonesTypes() {
        return this.http.get<MicrophonesTypes[]>(`https://localhost:44390/microphonestypes`);
    }

}