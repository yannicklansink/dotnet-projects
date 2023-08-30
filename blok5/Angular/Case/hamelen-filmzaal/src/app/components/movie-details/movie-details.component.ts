import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable, tap } from 'rxjs';
import { Film } from 'src/app/models/film';
import { FilmService } from 'src/app/services/film.service';
import { Location } from '@angular/common';
import { Playtime } from 'src/app/models/playtime';
import { PlaytimeService } from 'src/app/services/playtime.service';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css'],
})
export class MovieDetailsComponent implements OnInit {
  film$!: Observable<Film>;
  playtimes$!: Observable<Playtime[]>;
  groupedTijden: { [key: string]: string[] } = {}; // object where each key is a string with a string array as value

  constructor(
    private filmService: FilmService,
    private playtimeService: PlaytimeService,
    private route: ActivatedRoute,
    private location: Location
  ) {}

  // ngOnInit() {
  //   const id = this.route.snapshot.paramMap.get('id'); // gets ID from url
  //   if (id) {
  //     this.playtimes$ = this.playtimeService.getPlaytimesForFilm(id);
  //     console.log(this.playtimes$);
  //   }
  //   this.playtimes$.subscribe(playtimes => {
  //     this.groupTijden(playtimes);
  //   });
  //   this.film$.subscribe(film => {});
  // }

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id'); // gets ID from url
    if (id) {
      this.film$ = this.filmService.getById(id);

      this.playtimes$ = this.playtimeService.getPlaytimesForFilm(id);
      this.playtimes$.subscribe(playtimes => {
        this.groupTijden(playtimes);
      });
    }
  }

  ngOnDestroy() {
    // clean up the observable? yes, or subscribe inside the service?
  }

  private groupTijden(playtimes: Playtime[]): void {
    this.groupedTijden = {};
    console.log(playtimes.length);

    for (const playtime of playtimes) {
      if (playtime.tijdUitzending) {
        const [date, time] = playtime.tijdUitzending.split(' ');
        console.log(date, time);
        if (!this.groupedTijden[date]) {
          this.groupedTijden[date] = [];
        }

        this.groupedTijden[date].push(time);
      }
    }
  }

  goBack(): void {
    this.location.back();
  }

  onTimeClick(tijd: string): void {
    console.log(tijd);
  }
}
