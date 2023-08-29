import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { FilmOverzichtComponent } from './components/film-overzicht/film-overzicht.component';
import { DienstenComponent } from './components/diensten/diensten.component';
import { MovieDetailsComponent } from './components/movie-details/movie-details.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { ReserverenComponent } from './components/reserveren/reserveren.component';

const routes: Routes = [];

@NgModule({
  imports: [
    RouterModule.forRoot([
      { path: '', component: FilmOverzichtComponent },
      { path: 'diensten', component: DienstenComponent },
      { path: 'film/:id', component: MovieDetailsComponent },
      { path: 'film/:id/reserveren/:tijd/:group', component: ReserverenComponent },
      { path: '**', component: PageNotFoundComponent },
    ]),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
