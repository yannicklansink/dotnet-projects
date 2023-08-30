import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { Film } from 'src/app/models/film';
import { FilmService } from 'src/app/services/film.service';
import { Location } from '@angular/common';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { nameValidator } from 'src/app/validators/name-validator';

@Component({
  selector: 'app-reserveren',
  templateUrl: './reserveren.component.html',
  styleUrls: ['./reserveren.component.css'],
})
export class ReserverenComponent {
  film$!: Observable<Film>;
  mapOfAvailableSeats!: boolean[][];
  availableSeats: number = 0;
  tijd: string | null = '';
  datum!: Date | null;
  selectedSeats: boolean[][] = [
    [false, false, false, false, false],
    [false, false, false, false, false],
    [false, false, false, false, false],
    [false, false, false, false, false],
    [false, false, false, false, false],
  ];

  addReservationForm = new FormGroup({
    voornaam: new FormControl<string | null>('', [Validators.required, nameValidator()]),
    email: new FormControl<string | null>('', Validators.email),
    straatnaam: new FormControl<string | null>('', Validators.required),
    woonplaats: new FormControl<string | null>('', Validators.required),
  });

  constructor(private filmService: FilmService, private route: ActivatedRoute, private location: Location) {}

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id'); // gets ID from url
    if (id) {
      this.film$ = this.filmService.getById(id);
    }
    this.film$.subscribe(film => {
      // this.availableSeats = this.filmService.getAvailableSeats(film);
      // this.mapOfAvailableSeats = film.plaatsenBeschikbaar;
      console.log(this.mapOfAvailableSeats);
      console.log(this.availableSeats);
    });

    this.tijd = this.route.snapshot.paramMap.get('tijd');
    const dateString = this.route.snapshot.paramMap.get('group');
    if (dateString) {
      this.datum = new Date(dateString);
    }
  }

  // selectSeat(row: number, seatNumber: number): void {
  //   if (this.selectedSeats.length >= 4) {
  //     console.log('user selected to many setas');
  //     return;
  //   }

  //   this.selectedSeats.push({ row, seatNumber });
  //   this.mapOfAvailableSeats[row][seatNumber] = false;
  //   this.availableSeats--;
  // }

  addReservation() {
    console.log('Added reservation');
  }

  goBack(): void {
    this.location.back();
  }
}
