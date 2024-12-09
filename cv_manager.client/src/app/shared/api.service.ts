import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private baseUrl = 'https://localhost:44334/api';
  constructor(private http: HttpClient) { }

  get<T>(endPoint: string): Observable<T> {
    return this.http.get<T>(`${this.baseUrl}/${endPoint}`);
  }

  getDetails<T>(endPoint: string, id: number): Observable<T> {
    return this.http.get<T>(`${this.baseUrl}/${endPoint}/${id}`);
  }
  post<T>(endPoint: string, data: any): Observable<T> {
    return this.http.post<T>(`${this.baseUrl}/${endPoint}`, data);
  }

  put<T>(endPoint: string, data: any, id: number): Observable<T> {
    return this.http.put<T>(`${this.baseUrl}/${endPoint}/${id}`, data);
  }

  delete<T>(endPoint: string): Observable<T> {
    return this.http.delete<T>(`${this.baseUrl}/${endPoint}`);
  }
}
