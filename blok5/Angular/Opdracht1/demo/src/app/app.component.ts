import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray, AbstractControl, FormControl } from '@angular/forms';
import { Contacten } from './models/contacten';
import { AddContactForm } from './models/add-contact-form';
import { nameValidator } from './validators/name-validator';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  styles: ['h1 {color: green}']
})
export class AppComponent {
  addContactForm = new FormGroup<AddContactForm>({
    voornaam: new FormControl<string | null>('', [Validators.required, nameValidator()]),
    email: new FormControl<string | null>('', Validators.email),
  });

  contacten: Contacten[] = 
    [ 
      { id: 1, voornaam: "Sjoerd", achternaam: "Miep", email: "sjoerd.miep@gmail.com" },
      { id: 2, voornaam: "Vincent", achternaam: "Miep", email: "sjoerd.miep@gmail.com" }, 
      { id: 3, voornaam: "Gijsje", achternaam: "Miep", email: "sjoerd.miep@gmail.com" }, 
    ];


  handleDelete(id: number) {
    const index: number = this.contacten.map(x => {return x.id}).indexOf(id);
    this.contacten.splice(index, 1); // params: start and delete count
  }

  handleAdd(contactToAdd: AddContactForm) {

    let newContact: Contacten = {
      id: 1,
      voornaam: contactToAdd.voornaam!,
      achternaam: "",
      email: contactToAdd.email!
    }

    this.contacten.push(newContact)
  }

}
