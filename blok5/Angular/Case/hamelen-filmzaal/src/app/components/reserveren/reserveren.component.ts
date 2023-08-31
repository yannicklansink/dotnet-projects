import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { Film } from 'src/app/models/film';
import { FilmService } from 'src/app/services/film.service';
import { Location } from '@angular/common';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { nameValidator } from 'src/app/validators/name-validator';
import { Playtime } from 'src/app/models/playtime';
import { PlaytimeService } from 'src/app/services/playtime.service';
import { uuid } from 'uuidv4';
import { Reservatie } from 'src/app/models/reservatie';

@Component({
  selector: 'app-reserveren',
  templateUrl: './reserveren.component.html',
  styleUrls: ['./reserveren.component.css'],
})
export class ReserverenComponent {
  film$!: Observable<Film>;
  playtime$!: Observable<Playtime | null>;
  playtimeData: Playtime | null = null;
  availableSeats: number = 0;
  time!: string | null;
  date!: Date;
  

  addReservationForm = new FormGroup({
    voornaam: new FormControl<string | null>('', [Validators.required, nameValidator()]),
    email: new FormControl<string | null>('', Validators.email),
    straatnaam: new FormControl<string | null>('', Validators.required),
    woonplaats: new FormControl<string | null>('', Validators.required),
  });

  constructor(private filmService: FilmService, private playtimeService: PlaytimeService, private route: ActivatedRoute, private location: Location) {}

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id'); // gets ID from url
    if (id) {
      this.film$ = this.filmService.getById(id);
    }

    this.time = this.route.snapshot.paramMap.get('tijd');
    const dateString = this.route.snapshot.paramMap.get('group');
    if (dateString) {
      const switched = dateString.split("-").reverse().join("-");
      this.date = new Date(switched);
    }


    this.playtimeService.findPlaytimeByTime(this.time!).subscribe(playtime => {
      this.playtimeData = playtime;
      if (playtime) {
        this.availableSeats = playtime.plaatsenBeschikbaar!;
      } else {
        console.warn("playtime object is undefined?: " +playtime );
      }
    });
    
  }

  addReservation() {
    console.log('add reservation');
    const reservatieToAdd = this.addReservationForm.value as AddReservationForm;

    const newId = uuid();
    let newReservatie: Reservatie = {
      id: newId,
      voornaam: contactToAdd.voornaam!,
      email: contactToAdd.email!,
    };

    this.service.addContact(newContact);
  }

  goBack(): void {
    this.location.back();
  }
}
