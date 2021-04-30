import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Books } from '../Interfaces/book';
import { Reservations } from '../Interfaces/reservation';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private httpService: HttpClient) { }

  public getData = (route: string) => {
    return this.httpService.get(route);
  }

  public addBook = (route: string, body: Books) => {
    return this.httpService.post(route, body);
  }

  public addReservation = (route: string, body: Reservations) => {
    return this.httpService.post(route, body);
  }

  public updateBook = (route: string, body: Books) => {
    return this.httpService.post(route, body);
  }
}
