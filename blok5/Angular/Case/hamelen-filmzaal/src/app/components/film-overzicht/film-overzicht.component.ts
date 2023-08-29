import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { Film } from 'src/app/models/film';
import { FilmService } from 'src/app/services/film.service';

@Component({
  selector: 'app-film-overzicht',
  templateUrl: './film-overzicht.component.html',
  styleUrls: ['./film-overzicht.component.css'],
})
export class FilmOverzichtComponent {
  films$: Observable<Film[]> = this.filmService.films$;

  constructor(private filmService: FilmService) {}

  ngOnInit() {
    this.filmService.getAll().subscribe();
  }
}
