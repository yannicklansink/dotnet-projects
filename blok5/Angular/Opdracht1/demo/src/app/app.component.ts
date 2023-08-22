import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray, AbstractControl, FormControl } from '@angular/forms';
import { Contacten } from './models/contacten';
import { AddContactForm } from './models/add-contact-form';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  styles: ['h1 {color: red}']
})
export class AppComponent {
  addContactForm = new FormGroup<AddContactForm>({
    voornaam: new FormControl<string | null>('', Validators.required),
    email: new FormControl<string | null>('', Validators.email),
  });

  contacten: Contacten[] = 
    [ 
      { id: 1, voornaam: "Sjoerd", achternaam: "Miep", email: "sjoerd.miep@gmail.com" },
      { id: 2, voornaam: "Vincent", achternaam: "Miep", email: "sjoerd.miep@gmail.com" }, 
      { id: 3, voornaam: "Gijsje", achternaam: "Miep", email: "sjoerd.miep@gmail.com" }, 
    ];


  deleteContact(id: number) {
    const index: number = this.contacten.map(x => {return x.id}).indexOf(id);
    this.contacten.splice(index, 1); // params: start and delete count
  }

  editContact(contact: Contacten) {

  }

  addContact() {

    let newContact: Contacten = {
      id: 1,
      voornaam: this.addContactForm.value.voornaam!,
      achternaam: "",
      email: this.addContactForm.value.email!
    }

    this.contacten.push(newContact)
  }

}
