import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CustomPipe } from './pipes/name-formatter';
import { ReactiveFormsModule } from '@angular/forms';
import { ContactsTableComponent } from './components/contacts-table/contacts-table.component';
import { ContactFormComponent } from './components/contact-form/contact-form.component';
import { ContactsServiceService } from './services/contacts-service.service';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    CustomPipe,
    ContactsTableComponent,
    ContactFormComponent,
  ],
  imports: [ // modules
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
