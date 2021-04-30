import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Books } from '../Interfaces/book';
import { HttpService } from '../services/http.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {


  private parentRouteId: string;
  private sub: any;
  book: Books
  date2: any;

  constructor(private httpService: HttpService,
    private route: ActivatedRoute) {
      this.date2= formatDate(new Date(), 'yyyy/MM/dd', 'en');
      this.book = {
        name: "", 
        author: "", 
        description: "", 
        releaseDate: this.date2
      };

  }
  ngOnInit(): void {
    this.sub = this.route.paramMap.subscribe(params => {
      this.parentRouteId = params.get('id');
      console.log(params);
      console.log(this.parentRouteId);
    });

  }

  public editBook = () => {
    console.log('making request');
    let route: string = 'https://localhost:44330/api/book/' + this.parentRouteId;
    console.log(this.book);
    console.log(route);
    this.httpService.updateBook(route,this.book)
      .subscribe((result) => {
        console.log(this.book);
      },
        (error) => {
          console.error(error);
        });
  }
  onSubmit() {
    console.log("poszlo");
    this.editBook();
  }
}
