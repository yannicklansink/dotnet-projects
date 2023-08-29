import { DatePipe, registerLocaleData } from '@angular/common';
import { Pipe, PipeTransform } from '@angular/core';
import localeNl from '@angular/common/locales/nl';

registerLocaleData(localeNl, 'nl');

@Pipe({
  name: 'dateFormatter',
})
export class DateFormatterPipe implements PipeTransform {
  constructor(private datePipe: DatePipe) {}

  transform(date: Date | null): string {
    if (!date) return ''; // for when date is null
    return this.datePipe.transform(date, 'd MMMM yyyy', undefined, 'nl')!;
  }
}
