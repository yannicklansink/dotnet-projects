import { CustomPipe } from './name-formatter';  

describe('CustomPipe', () => {
  let pipe: CustomPipe;

  // to ensure tha t all my tests run in isolation
  beforeEach(() => {
    pipe = new CustomPipe();
  });

  it('should concatenate voornaam and achternaam with a space in between', () => {
    expect(pipe.transform('henk', 'achternaam')).toBe('henk achternaam');
  });

  it('should handle empty strings', () => {
    expect(pipe.transform('', '')).toBe(' ');
    expect(pipe.transform('Henk', '')).toBe('Henk ');
    expect(pipe.transform('', 'achternaam')).toBe(' achternaam');
  });

});

