import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { Film } from 'src/app/models/film';
import { FilmService } from 'src/app/services/film.service';
import { Location } from '@angular/common';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-reserveren',
  templateUrl: './reserveren.component.html',
  styleUrls: ['./reserveren.component.css'],
})
export class ReserverenComponent {
  film$!: Observable<Film>;
  mapOfAvailableSeats!: boolean[][];
  availableSeats!: number;
  tijd: string | null = '';
  datum!: Date | null;

  addReservationForm = new FormGroup({
    voornaam: new FormControl<string | null>('', [
      Validators.required,
      // nameValidator(),
    ]),
    email: new FormControl<string | null>('', Validators.email),
  });

  constructor(private filmService: FilmService, private route: ActivatedRoute, private location: Location) {}

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id'); // gets ID from url
    if (id) {
      this.film$ = this.filmService.getById(id);
    }
    this.film$.subscribe(film => {
      this.availableSeats = this.filmService.getAvailableSeats(film);
      this.mapOfAvailableSeats = film.plaatsenBeschikbaar;
      console.log(this.mapOfAvailableSeats);
      console.log(this.availableSeats);
    });

    this.tijd = this.route.snapshot.paramMap.get('tijd');
    const dateString = this.route.snapshot.paramMap.get('group');
    if (dateString) {
      this.datum = new Date(dateString);
    }
  }

  addReservation() {
    console.log('Added reservation');
  }

  goBack(): void {
    this.location.back();
  }
}
