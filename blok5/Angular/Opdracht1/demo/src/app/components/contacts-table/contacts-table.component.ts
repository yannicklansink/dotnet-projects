import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { Contacten } from 'src/app/models/contacten';
import { ContactsServiceService } from 'src/app/services/contacts-service.service';

@Component({
  selector: 'app-contacts-table',
  templateUrl: './contacts-table.component.html',
  styleUrls: ['./contacts-table.component.css'],
})
export class ContactsTableComponent {
  // $ is a suffix for properties that are observables.
  contacten$: Observable<Contacten[]> = this.service.contacten$;
  // @Input() contacten: any[] = [];
  // @Output() delete = new EventEmitter<number>();

  constructor(private service: ContactsServiceService) {}

  ngOnInit() {
    this.service.getAll().subscribe();
  }

  get contacten(): Observable<Contacten[]> {
    return this.service.contacten$;
  }

  handleDelete(id: string) {
    this.service.deleteContact(id);
  }
}
