import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Film } from 'src/app/models/film';
import { FilmService } from 'src/app/services/film.service';
import { Location } from '@angular/common';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { nameValidator } from 'src/app/validators/name-validator';
import { Playtime } from 'src/app/models/playtime';
import { PlaytimeService } from 'src/app/services/playtime.service';
import { v4 as uuidv4 } from 'uuid';
import { Reservatie } from 'src/app/models/reservatie';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-reserveren',
  templateUrl: './reserveren.component.html',
  styleUrls: ['./reserveren.component.css'],
})
export class ReserverenComponent {
  film$!: Observable<Film>;
  // playtime$!: Observable<Playtime | null>;
  playtimeData: Playtime | null = null;
  playtimeId!: string;
  availableSeats: number = 0;
  time!: string | null;
  date!: Date;

  addReservationForm = new FormGroup({
    voornaam: new FormControl<string | null>('', [Validators.required, nameValidator()]),
    email: new FormControl<string | null>('', Validators.email),
    straatnaam: new FormControl<string | null>('', Validators.required),
    woonplaats: new FormControl<string | null>('', Validators.required),
    hoeveelheid: new FormControl<string | null>('', Validators.required),
  });

  constructor(
    private filmService: FilmService,
    private playtimeService: PlaytimeService,
    private route: ActivatedRoute,
    private location: Location,
    private router: Router,
    private toastr: ToastrService
  ) {}

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id'); // gets ID from url
    if (id) {
      this.film$ = this.filmService.getById(id);
    }

    this.time = this.route.snapshot.paramMap.get('tijd');
    const dateString = this.route.snapshot.paramMap.get('group');
    if (dateString) {
      const switched = dateString.split('-').reverse().join('-');
      this.date = new Date(switched);
    }

    this.playtimeService.getAll().subscribe(playtimes => {
      this.playtimeService.findPlaytimeByTime(this.time!).subscribe(playtime => {
        if (playtime) {
          this.playtimeData = playtime;
          this.availableSeats = playtime.plaatsenBeschikbaar!;
          this.playtimeId = playtime.id!;
        }
      });
    });
  }

  addReservation() {
    const formValue = this.addReservationForm.value;
    const newId = uuidv4();

    let newReservatie: Reservatie = {
      id: newId,
      voornaam: formValue.voornaam!,
      email: formValue.email!,
      straatnaam: formValue.straatnaam!,
      woonplaats: formValue.woonplaats!,
      hoeveelheid: Number(formValue.hoeveelheid),
      playtimeId: this.playtimeId,
    };

    this.playtimeData!.plaatsenBeschikbaar =
      this.playtimeData?.plaatsenBeschikbaar! - Number(formValue.hoeveelheid);

    this.playtimeService.addReservation(newReservatie).subscribe(success => {
      if (success) {
        this.playtimeService.updatePlaytime(this.playtimeData!);
        this.toastr.success('Jouw reservering is verwerkt ' + formValue.voornaam, 'Succes', {
          timeOut: 5000,
          progressBar: true,
          positionClass: 'toast-top-full-width',
        });
        this.router.navigate(['/']);
      } else {
        this.toastr.error('Jouw reservering is niet voltooid', 'Error', {
          timeOut: 3000,
          positionClass: 'toast-top-right',
        });
        this.router.navigate(['/']);
      }
    });
  }

  goBack(): void {
    this.location.back();
  }
}
