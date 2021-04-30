import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Books } from '../Interfaces/book';
import { User } from '../Interfaces/user';
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
  currentUser: User;
  value: number;

  constructor(private httpService: HttpService) {
    // this.currentUserSubscription = this.authenticationService.currentUser.subscribe(user => {
    //     this.currentUser = user;
    // });

    // this.value=0;
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
}
