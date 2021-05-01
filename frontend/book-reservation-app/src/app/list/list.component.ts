import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Books } from '../Interfaces/book';
import { Reservations } from '../Interfaces/reservation';
import { Users } from '../Interfaces/user';
import { ReservationsComponent } from '../reservations/reservations.component';
import { AuthenticationService } from '../services/authentication.service';
import { HttpService } from '../services/http.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  public books: Books[];
  currentUserSubscription: Subscription;
  public authenticationService: AuthenticationService;
  currentUser: Users;
  value: number;
  date: any;
  dateString: string;
  reservation: Reservations;

  constructor(private httpService: HttpService) {
    this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
}
  ngOnInit(): void {
    this.getBooks();
  }

  public getBooks = () => {
    console.log('making request');
    let route: string = 'https://localhost:44330/api/book';
    this.httpService.getData(route)
      .subscribe((result) => {
        this.books = result as Books[];
        console.log(this.books);
      },
        (error) => {
          console.error(error);
        });
  }

  public addReservation(id : number){

    var a = id;
    var b = this.currentUser.id;
    this.date = formatDate(new Date(), 'yyyy-MM-dd', 'en');
    this.dateString = this.date;
    this.reservation = {
      userID: b, 
      bookID: a,
      reservationDate: this.date
    };
    this.addReservationToDatabase();
  }

  public addReservationToDatabase = () => {
    let route: string = 'https://localhost:44330/api/reservation';
    this.httpService.addReservation(route, this.reservation)
      .subscribe((result) => {
        alert("udało się")
      },
        (error) => {
          console.error(error);
        });
  }
}
