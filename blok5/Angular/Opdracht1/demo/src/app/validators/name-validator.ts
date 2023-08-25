import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export function nameValidator(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const value = control.value;
    const pattern = /^[A-Za-z]+$/;
    const isValid = pattern.test(value);
    return !isValid ? { invalidName: { value } } : null;
  };
}
