import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, catchError, map, of, tap } from 'rxjs';
import { Film } from '../models/film';
import { Playtime } from '../models/playtime';
import { Reservatie } from '../models/reservatie';

@Injectable({
  providedIn: 'root',
})
export class PlaytimeService {
  private playtimesMutableSubject: BehaviorSubject<Playtime[]> = new BehaviorSubject<Playtime[]>([]);
  playtime$ = this.playtimesMutableSubject.asObservable();
  private readonly url: string = 'http://localhost:3000/playtime';

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

  findPlaytimeByTime(time: string): Observable<Playtime | null> {
    return this.http.get<Playtime[]>(`http://localhost:3000/playtime?time=${time}`).pipe(
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

  addReservation(reservatie: Reservatie): Observable<boolean> {
    return this.http.post<Reservatie>('http://localhost:3000/reservatie', reservatie).pipe(
      map(addedReservatie => true),
      catchError(error => {
        console.error('Error adding reservation:', error);
        return of(false);
      })
    );
  }

  updatePlaytime(playtimeToUpdate: Playtime): void {
    const url = `${this.url}/${playtimeToUpdate.id}`;
    this.http.put<Playtime>(url, playtimeToUpdate).subscribe(
      updatedPlaytime => {
        this.updateLocalPlaytimeData(updatedPlaytime);
      },
      error => {
        console.warn('An error :():', error);
      }
    );
  }

  private updateLocalPlaytimeData(updatedPlaytime: Playtime): void {
    const currentPlaytimes = this.playtimesMutableSubject.value;
    const indexToUpdate = currentPlaytimes.findIndex(
      playtime => Number(playtime.id) === Number(updatedPlaytime.id)
    );
    console.log(indexToUpdate);
    if (indexToUpdate !== -1) {
      currentPlaytimes[indexToUpdate] = updatedPlaytime;
      this.playtimesMutableSubject.next([...currentPlaytimes]);
    } else {
      console.warn('error in finding the right index');
    }
  }
}
