import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { OrchestrateTypes } from '../models/orchestrate';

@Injectable({ providedIn: 'root' })
export class OrchestrateTypesService {
    constructor(private http: HttpClient) { }

    getOrchestrateTypes() {
        return this.http.get<OrchestrateTypes[]>(`https://localhost:44390/orchestratetypes`);
    }

}