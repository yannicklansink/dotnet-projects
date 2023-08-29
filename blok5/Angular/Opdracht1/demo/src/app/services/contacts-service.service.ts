import { Injectable, Component, OnInit, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Contacten } from '../models/contacten';
import { BehaviorSubject, Observable, tap } from 'rxjs';

// @injectable decorator defines a class as a service.
@Injectable({
  // Must register at least one provider of any service.
  // Tree-shaking.
  providedIn: 'root',
})
export class ContactsServiceService {
  private contactenMutableSubject: BehaviorSubject<Contacten[]> = new BehaviorSubject<Contacten[]>([]);
  contacten$ = this.contactenMutableSubject.asObservable();

  constructor(private http: HttpClient) {}

  getAll(): Observable<Contacten[]> {
    return (
      this.http
        .get<Contacten[]>('http://localhost:3000/contacts')
        // tap => doe iets met de data zonder dat de stream beinvloed.
        .pipe(tap(contacten => this.contactenMutableSubject.next(contacten)))
    );
  }

  // contacten: Contacten[] = [];

  // contacten: Contacten[] =
  //   [
  //     { id: 1, voornaam: "Sjoerd", achternaam: "Miep", email: "sjoerd.miep@gmail.com" },
  //     { id: 2, voornaam: "Vincent", achternaam: "Miep", email: "sjoerd.miep@gmail.com" },
  //     { id: 3, voornaam: "Gijsje", achternaam: "Miep", email: "sjoerd.miep@gmail.com" },
  //   ];

  addContact(contact: Contacten) {
    // this.contacten?.push(contact);
    this.http.post<Contacten>('http://localhost:3000/contacts', contact).subscribe(newContact => {
      // get the current contacts[] from behaviorsubject
      const currentContacts = this.contactenMutableSubject.value;

      // add newContact to the other array.
      const updatedContacts = [...currentContacts, newContact];

      // notify subscribers of the updated data
      this.contactenMutableSubject.next(updatedContacts);
    });
  }

  deleteContact(id: string) {
    // const index = this.contacten
    //   .map((contact) => {
    //     return contact.id;
    //   })
    //   .indexOf(id);
    // if (index > -1) {
    //   this.contacten.splice(index, 1); // params: start and delete count
    // }
    const updatedContact = this.contactenMutableSubject.value.filter(contact => contact.id !== id);
    this.contactenMutableSubject.next(updatedContact);
  }
}
