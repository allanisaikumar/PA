import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
    
import {  Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { LogDetail, LogSummary } from './log-summary';
   
    
@Injectable({
  providedIn: 'root'
})
export class LogService {
    
  private apiURL = "https://localhost:7219/api/";
    
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }
   
  constructor(private httpClient: HttpClient) { }
    
  getSummary(): Observable<LogSummary[]> {
    return this.httpClient.get<LogSummary[]>(this.apiURL + 'Log/')
    .pipe(
      catchError(this.errorHandler)
    )
  }
    
    
  getLogDetail(id: string): Observable<LogDetail> {
    return this.httpClient.get<LogDetail>(this.apiURL + 'Log/' + id)
    .pipe(
      catchError(this.errorHandler)
    )
  }
    
  errorHandler(error: { error: { message: string; }; status: any; message: any; }) {
    let errorMessage = '';
    if(error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(errorMessage);
 }
}