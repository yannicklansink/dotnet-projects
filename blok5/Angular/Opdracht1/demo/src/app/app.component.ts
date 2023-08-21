import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray, AbstractControl } from '@angular/forms';
import { Contacten } from 'src/models/contacten';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  styles: ['h1 {color: red}']
})
export class AppComponent {
  // tableForm: FormGroup;
  contacten: Contacten[] = 
    [ 
      { id: 1, voornaam: "Sjoerd", achternaam: "Miep", email: "sjoerd.miep@gmail.com" },
      { id: 2, voornaam: "Vincent", achternaam: "Miep", email: "sjoerd.miep@gmail.com" }, 
      { id: 3, voornaam: "Gijsje", achternaam: "Miep", email: "sjoerd.miep@gmail.com" }, 
    ];

  // constructor(private fb: FormBuilder) {}

  // get QuestionsAndAnswers() {
  //   return this.tableForm.get('QuestionsAndAnswers') as FormArray;
  // }

  deleteContact(id: number) {
    const index: number = this.contacten.map(x => {return x.id}).indexOf(id);
    this.contacten.splice(index, 1); // params: start and delete count
  }

  editContact(contact: Contacten) {

  }

}
