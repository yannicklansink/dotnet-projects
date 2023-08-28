import { MovieTimeFormatter } from './movie-time-formatter.pipe';

describe('MovieTimeFormatterPipe', () => {
  it('create an instance', () => {
    const pipe = new MovieTimeFormatterPipe();
    expect(pipe).toBeTruthy();
  });
});
