import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Contacten } from 'src/app/models/contacten';
import { ContactsServiceService } from 'src/app/services/contacts-service.service';

@Component({
  selector: 'app-contacts-table',
  templateUrl: './contacts-table.component.html',
  styleUrls: ['./contacts-table.component.css']
})
export class ContactsTableComponent {

  // @Input() contacten: any[] = [];
  // @Output() delete = new EventEmitter<number>();

  constructor(private service: ContactsServiceService) { }

  get contacten(): Contacten[] {
    return this.service.contacten;
  }

  handleDelete(id: string) {
    this.service.deleteContact(id);
  }


}
