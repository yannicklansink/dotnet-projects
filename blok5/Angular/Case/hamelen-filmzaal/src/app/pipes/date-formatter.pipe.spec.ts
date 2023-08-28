import { DatePipe } from '@angular/common';
import { DateFormatterPipe } from './date-formatter.pipe';

describe('DateFormatterPipe', () => {
  let pipe: DateFormatterPipe;

  // Create a new instance of the DatePipe and DateFormatterPipe before each test
  beforeEach(() => {
    const datePipe = new DatePipe('en'); // using 'en' as default locale for DatePipe
    pipe = new DateFormatterPipe(datePipe);
  });

  it('create an instance', () => {
    expect(pipe).toBeTruthy();
  });

  it('should return empty string if null is provided', () => {
    expect(pipe.transform(null)).toBe('');
  });

  it('should properly format date string', () => {
    // Using a fixed date for testing
    const date = new Date('2021-09-01T00:00:00');
    const formattedDate = pipe.transform(date);
    
    // For locale 'nl' and format 'dd MMMM yyyy', the date should be formatted as '01 september 2021'
    expect(formattedDate).toBe('01 september 2021');
  });

});
