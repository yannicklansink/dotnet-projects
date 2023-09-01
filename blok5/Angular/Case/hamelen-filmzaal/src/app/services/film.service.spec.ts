import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { FilmService } from './film.service';
import { Film } from '../models/film';

describe('FilmService', () => {
  let service: FilmService;
  let httpTestingController: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [FilmService],
    });

    service = TestBed.inject(FilmService);
    httpTestingController = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpTestingController.verify(); // Verify that no unmatched requests are outstanding
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  // it('should fetch all films', () => {
  //   const mockFilms: Film[] = [
  //     {
  //       id: '1',
  //       titel: 'Film 1',
  //       afbeeldingUrl: 'url1',
  //       beschrijving: 'Desc 1',
  //       releaseDatum: null,
  //       regisseur: null,
  //       lengte: null,
  //     },
  //     {
  //       id: '2',
  //       titel: 'Film 2',
  //       afbeeldingUrl: 'url2',
  //       beschrijving: 'Desc 2',
  //       releaseDatum: null,
  //       regisseur: null,
  //       lengte: null,
  //     },
  //   ];
  //   service.getAll().subscribe(films => {
  //     expect(films).toEqual(mockFilms);
  //   });

  //   const req = httpTestingController.expectOne('http://localhost:3000/films');
  //   expect(req.request.method).toEqual('GET');
  //   req.flush(mockFilms);
  // });

  // it('should fetch a film by id', () => {
  //   const mockFilm: Film = {
  //     id: '1',
  //     titel: 'Film 1',
  //     afbeeldingUrl: 'url1',
  //     beschrijving: 'Desc 1',
  //     releaseDatum: null,
  //     regisseur: null,
  //     lengte: null,
  //   };

  //   service.getById('1').subscribe(film => {
  //     expect(film).toEqual(mockFilm);
  //   });

  //   const req = httpTestingController.expectOne('http://localhost:3000/films/1');
  //   expect(req.request.method).toEqual('GET');
  //   req.flush(mockFilm);
  // });
});
