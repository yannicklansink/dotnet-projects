import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'movieTimeFormatter'
})
export class MovieTimeFormatterPipe implements PipeTransform {

  transform(tijden: string[]): string {
    if (!tijden || tijden.length === 0) return '';

    let output = '';
    const groupedByDate: { [key: string]: string[] } = {};

    // Group times by date
    for (const tijd of tijden) {
      const [date, time] = tijd.split(' ');
      if (!groupedByDate[date]) {
        groupedByDate[date] = [];
      }
      groupedByDate[date].push(time);
    }

    // Generate the output string
    for (const [date, times] of Object.entries(groupedByDate)) {
      output += `Date: ${date}\nTime: ${times.join('    ')}\n`;
    }

    return output.trim();
  }

}

