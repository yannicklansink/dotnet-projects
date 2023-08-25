import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactsTableComponent } from './components/contacts-table/contacts-table.component';

const routes: Routes = [
  { path: 'tablecomponent', component: ContactsTableComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
