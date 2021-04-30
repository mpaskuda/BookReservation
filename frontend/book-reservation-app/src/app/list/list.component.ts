import { Component, OnInit } from '@angular/core';
import { Books } from '../Interfaces/book';
import { HttpService } from '../services/http.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  public books: Books[];

  constructor(private httpService: HttpService) {

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
