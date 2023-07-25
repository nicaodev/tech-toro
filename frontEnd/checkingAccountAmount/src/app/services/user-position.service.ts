import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable, tap } from 'rxjs';

interface UserPosition {
  cpf: any;
  CheckingAccountAmount: number;
  Positions: any[]; // You can create an interface for this too, matching the returned JSON structure
  Consolidated: number;
}

@Injectable({
  providedIn: 'root'
})
export class UserPositionService {
  private apiUrl = 'http://localhost:5056/api/checkingAccountAmount/userPosition'; // Replace with your API URL

  constructor(private http: HttpClient) { }

  getUserPosition(): Observable<UserPosition> {
    var abc = this.http.get<any>(this.apiUrl);

    return this.http.get<any>(this.apiUrl);

  }
  get apiListAllPokemons(): Observable<any> {
    return this.http.get<any>(this.apiUrl).pipe(
      tap(res => res),
      tap(res => {
        console.log(res);


      })
    )
  }


}
