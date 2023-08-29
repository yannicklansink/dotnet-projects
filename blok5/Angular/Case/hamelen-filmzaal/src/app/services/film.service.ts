import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Film } from '../models/film';
import { BehaviorSubject, Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class FilmService {
  private filmsMutableSubject: BehaviorSubject<Film[]> = new BehaviorSubject<Film[]>([]);
  films$ = this.filmsMutableSubject.asObservable();

  constructor(private http: HttpClient) {}

  getAll(): Observable<Film[]> {
    return this.http
      .get<Film[]>('http://localhost:3000/films')
      .pipe(tap(films => this.filmsMutableSubject.next(films)));
    // de tap zal ook automatisch alle abonnees van films$ bijwerken.
  }

  getById(id: string): Observable<Film> {
    const idNumber = Number(id);
    return this.http.get<Film>('http://localhost:3000/films/' + idNumber);
  }
}
