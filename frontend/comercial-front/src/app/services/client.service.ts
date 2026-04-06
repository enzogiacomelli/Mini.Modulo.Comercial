import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ClientService {
  private apiUrl = '/api/clients';

  constructor(private http: HttpClient) {}

  getClients() {
    return this.http.get<any>(this.apiUrl);
  }
}
