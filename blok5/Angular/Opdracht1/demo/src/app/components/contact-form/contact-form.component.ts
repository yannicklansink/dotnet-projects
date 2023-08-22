import { Component, EventEmitter, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AddContactForm } from 'src/app/models/add-contact-form';
import { nameValidator } from 'src/app/validators/name-validator';

@Component({
  selector: 'app-contact-form',
  templateUrl: './contact-form.component.html',
  styleUrls: ['./contact-form.component.css']
})
export class ContactFormComponent {
  @Output() add = new EventEmitter<AddContactForm>();

  addContactForm = new FormGroup({
    voornaam: new FormControl<string | null>('', [Validators.required, nameValidator()]),
    email: new FormControl<string | null>('', Validators.email),
  });

  addContact() {
    this.add.emit(this.addContactForm.value as AddContactForm);
  }
}
