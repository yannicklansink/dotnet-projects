import { Phone } from '../phone.js';


// describe = test suite
// it = een test
// expect = we verwarchten iets: matchers

describe('class Phone', () => {
    it('should work', () => {
        expect(10).toBe(10);
    })
});

describe('class Phone', () => {
    let sut;

    beforeEach(() =>  {
        sut = new Phone('tesla', 'fast');
    })

    it('contains spec with an exception', () => {
        expect(true).toBe(true);
    })

    it("and can have a negative case", function() {
        expect(false).not.toBe(true);
    });

    it('should have a brand of tesla when instantiated with tesla', () => {
        expect(sut.brand).toBe('tesla');
    })

    it('should have a type of fast when instantiated with fast', () => {
        expect(sut.type).toBe('fast');
    })
});



