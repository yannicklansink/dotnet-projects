import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, catchError, map, of, tap } from 'rxjs';
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

  // findPlaytimeByTime(time: string): Observable<Playtime | null> {
  //   return this.playtime$.pipe(
  //     map(playtimes => {
  //       const foundPlaytime = playtimes.find(playtime => {
  //         const timePart = playtime.tijdUitzending!.split(' ')[1];
  //         return timePart.startsWith(time); // Comparing just the time part
  //       });
  //       return foundPlaytime || null;
  //     })
  //   );
  // }

  findPlaytimeByTime(time: string): Observable<Playtime | null> {
    return this.http.get<Playtime[]>(`http://localhost:3000/playtime?time=${time}`)
      .pipe(
        map(playtimes => {
          const foundPlaytime = playtimes.find(playtime => {
            const timePart = playtime.tijdUitzending!.split(' ')[1];
            return timePart.startsWith(time); // Comparing just the time part
          });
          return foundPlaytime || null;
        }),
        catchError(error => {
          // Handle errors here
          console.error('An error occurred:', error);
          return of(null); // Return an Observable of null if there's an error
        })
      );
  }
  
  

}
