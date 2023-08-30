import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, map, tap } from 'rxjs';
import { Film } from '../models/film';
import { Playtime } from '../models/playtime';

@Injectable({
  providedIn: 'root',
})
export class PlaytimeService {
  private playtimesMutableSubject: BehaviorSubject<Playtime[]> = new BehaviorSubject<Playtime[]>([]);
  playtime$ = this.playtimesMutableSubject.asObservable();

  constructor(private http: HttpClient) {}

  getAll(): Observable<Playtime[]> {
    return this.http
      .get<Playtime[]>('http://localhost:3000/playtime')
      .pipe(tap(playtimes => this.playtimesMutableSubject.next(playtimes)));
  }

  getPlaytimesForFilm(id: string): Observable<Playtime[]> {
    return this.http.get<Playtime[]>(`http://localhost:3000/playtime?filmId=${id}`).pipe(
      tap(playtimes => {
        console.log('Fetched playtimes:', playtimes);
      })
    );
  }
}
