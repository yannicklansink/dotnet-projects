import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Contacten } from 'src/app/models/contacten';

@Component({
  selector: 'app-contacts-table',
  templateUrl: './contacts-table.component.html',
  styleUrls: ['./contacts-table.component.css']
})
export class ContactsTableComponent {

  @Input() contacten: any[] = [];
  @Output() delete = new EventEmitter<number>();

  deleteContact(id: number) {
    // const index: number = this.contacten.map(x => {return x.id}).indexOf(id);
    // this.contacten.splice(index, 1); // params: start and delete count
    this.delete.emit(id);
  }


}
