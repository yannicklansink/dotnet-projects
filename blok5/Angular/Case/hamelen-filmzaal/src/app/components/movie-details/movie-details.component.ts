import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { Film } from 'src/app/models/film';
import { FilmService } from 'src/app/services/film.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css'],
})
export class MovieDetailsComponent implements OnInit {
  film$!: Observable<Film>;
  groupedTijden: { [key: string]: string[] } = {}; // object where each key is a string with a string array as value

  constructor(private filmService: FilmService, private route: ActivatedRoute, private location: Location) {}

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id'); // gets ID from url
    if (id) {
      this.film$ = this.filmService.getById(id);
    }
    this.film$.subscribe(film => {
      if (film.tijdUitzending) {
        this.groupTijden(film.tijdUitzending);
      }
    });
  }

  ngOnDestroy() {
    // clean up the observable?
  }

  private groupTijden(tijden: string[]): void {
    for (const tijd of tijden) {
      const [date, time] = tijd.split(' ');
      if (!this.groupedTijden[date]) {
        this.groupedTijden[date] = [];
      }

      this.groupedTijden[date].push(time);
    }
  }

  goBack(): void {
    this.location.back();
  }

  onTimeClick(tijd: string): void {
    console.log(tijd);
  }
}
