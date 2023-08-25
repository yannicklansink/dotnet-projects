import { Injectable, Component, OnInit, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Contacten } from '../models/contacten';

// @injectable decorator defines a class as a service.
@Injectable({
  // Must register at least one provider of any service.
  // Tree-shaking.
  providedIn: 'root',
})
export class ContactsServiceService {
  constructor(private http: HttpClient) {
    this.http
      .get<Contacten[]>('http://localhost:3000/contacts')
      .subscribe((contacten) => (this.contacten = contacten));
  }

  contacten: Contacten[] = [];

  // contacten: Contacten[] =
  //   [
  //     { id: 1, voornaam: "Sjoerd", achternaam: "Miep", email: "sjoerd.miep@gmail.com" },
  //     { id: 2, voornaam: "Vincent", achternaam: "Miep", email: "sjoerd.miep@gmail.com" },
  //     { id: 3, voornaam: "Gijsje", achternaam: "Miep", email: "sjoerd.miep@gmail.com" },
  //   ];

  addContact(contact: Contacten) {
    // this.contacten?.push(contact);
    this.http
      .post<Contacten>('http://localhost:3000/contacts', contact)
      .subscribe((updatedContact) => {
        this.contacten.push(updatedContact);
      });
  }

  deleteContact(id: string) {
    const index = this.contacten
      .map((contact) => {
        return contact.id;
      })
      .indexOf(id);
    if (index > -1) {
      this.contacten.splice(index, 1); // params: start and delete count
    }
  }
}
