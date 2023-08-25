import { Component, EventEmitter, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AddContactForm } from 'src/app/models/add-contact-form';
import { Contacten } from 'src/app/models/contacten';
import { ContactsServiceService } from 'src/app/services/contacts-service.service';
import { nameValidator } from 'src/app/validators/name-validator';
import { v4 as uuidv4 } from 'uuid';

@Component({
  selector: 'app-contact-form',
  templateUrl: './contact-form.component.html',
  styleUrls: ['./contact-form.component.css'],
})
export class ContactFormComponent {
  constructor(private service: ContactsServiceService) {}

  addContactForm = new FormGroup({
    voornaam: new FormControl<string | null>('', [
      Validators.required,
      nameValidator(),
    ]),
    email: new FormControl<string | null>('', Validators.email),
  });

  addContact() {
    // this.add.emit(this.addContactForm.value as AddContactForm);
    const contactToAdd = this.addContactForm.value as AddContactForm;

    const newId = uuidv4();
    let newContact: Contacten = {
      id: newId,
      voornaam: contactToAdd.voornaam!,
      achternaam: '',
      email: contactToAdd.email!,
    };

    this.service.addContact(newContact);
  }
}
