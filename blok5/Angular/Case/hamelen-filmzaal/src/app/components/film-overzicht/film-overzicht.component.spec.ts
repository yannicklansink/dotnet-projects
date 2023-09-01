import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FilmOverzichtComponent } from './film-overzicht.component';
import { FilmService } from 'src/app/services/film.service';
import { of } from 'rxjs';
import { Film } from 'src/app/models/film';

describe('FilmOverzichtComponent', () => {
  let component: FilmOverzichtComponent;
  let fixture: ComponentFixture<FilmOverzichtComponent>;
  let mockFilmService: jasmine.SpyObj<FilmService>;

  beforeEach(async () => {
    mockFilmService = jasmine.createSpyObj(['getAll']);

    await TestBed.configureTestingModule({
      declarations: [FilmOverzichtComponent],
      providers: [{ provide: FilmService, useValue: mockFilmService }],
    }).compileComponents();

    fixture = TestBed.createComponent(FilmOverzichtComponent);
    component = fixture.componentInstance;
  });

  it('should fetch all films on ngOnInit', () => {
    const mockFilms: Film[] = [
      {
        id: '1',
        titel: 'Film 1',
        afbeeldingUrl: 'url1',
        beschrijving: 'Desc 1',
        releaseDatum: null,
        regisseur: null,
        lengte: null,
      },
      {
        id: '2',
        titel: 'Film 2',
        afbeeldingUrl: 'url2',
        beschrijving: 'Desc 2',
        releaseDatum: null,
        regisseur: null,
        lengte: null,
      },
    ];

    mockFilmService.getAll.and.returnValue(of(mockFilms));

    component.ngOnInit();

    expect(mockFilmService.getAll).toHaveBeenCalled();
  });
});
