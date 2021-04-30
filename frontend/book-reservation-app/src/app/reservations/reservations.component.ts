import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Reservations } from '../Interfaces/reservation';
import { HttpService } from '../services/http.service';

@Component({
  selector: 'app-reservations',
  templateUrl: './reservations.component.html',
  styleUrls: ['./reservations.component.css']
})

export class ReservationsComponent implements OnInit {


  public reservations: Reservations[];
  private parentRouteId: string;
  private sub: any;

  constructor(private httpService: HttpService,
    private route: ActivatedRoute) {

  }
  ngOnInit(): void {
    this.sub = this.route.paramMap.subscribe(params => {
      this.parentRouteId = params.get('id');
      console.log(params);
      console.log(this.parentRouteId);
    });
    this.getReservations();
  }

  public getReservations = () => {
    console.log('making request');
    let route: string = 'https://localhost:44330/api/reservation/' + this.parentRouteId;
    this.httpService.getData(route)
      .subscribe((result) => {
        this.reservations = result as Reservations[];
        console.log(this.reservations);
      },
        (error) => {
          console.error(error);
        });
  }
}