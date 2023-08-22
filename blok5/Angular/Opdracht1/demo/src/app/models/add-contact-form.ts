import { FormControl } from "@angular/forms";

export interface AddContactForm 
{
    voornaam: FormControl<string | null>;
    email: FormControl<string | null>;
    
}