import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray, AbstractControl, FormControl } from '@angular/forms';
import { Contacten } from './models/contacten';
import { AddContactForm } from './models/add-contact-form';
import { nameValidator } from './validators/name-validator';
import { ContactsServiceService } from './services/contacts-service.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  styles: ['h1 {color: green}']
})
export class AppComponent {

}
