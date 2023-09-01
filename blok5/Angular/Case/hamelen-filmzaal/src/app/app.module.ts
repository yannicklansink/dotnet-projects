import { LOCALE_ID, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FilmOverzichtComponent } from './components/film-overzicht/film-overzicht.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MenuBalkComponent } from './components/menu-balk/menu-balk.component';
import { DienstenComponent } from './components/diensten/diensten.component';
import { MovieDetailsComponent } from './components/movie-details/movie-details.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { DateFormatterPipe } from './pipes/date-formatter.pipe';
import { DatePipe } from '@angular/common';
import { registerLocaleData } from '@angular/common';
import localeNl from '@angular/common/locales/nl';
import { ReserverenComponent } from './components/reserveren/reserveren.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    FilmOverzichtComponent,
    MenuBalkComponent,
    DienstenComponent,
    MovieDetailsComponent,
    PageNotFoundComponent,
    DateFormatterPipe,
    ReserverenComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
  ],
  providers: [DatePipe, { provide: LOCALE_ID, useValue: 'nl' }],
  bootstrap: [AppComponent],
})
export class AppModule {}
