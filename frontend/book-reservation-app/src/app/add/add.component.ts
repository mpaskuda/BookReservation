import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Books } from '../Interfaces/book';
import { HttpService } from '../services/http.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent  {
  public book: Books;
  date: any;
   public name:any;
  constructor(private httpService: HttpService) {
    this.date= formatDate(new Date(), 'yyyy/MM/dd', 'en');
    this.book = {
      name: "", 
      author: "", 
      description: "", 
      releaseDate: this.date
    };
  }



  public addBook = () => {
    let route: string = 'https://localhost:44330/api/book';
    this.httpService.addBook(route, this.book)
      .subscribe((result) => {
        alert("udało się")
      },
        (error) => {
          console.error(error);
        });
  }
  onSubmit() {
    console.log("poszlo");
    this.addBook();
  }
}