class Person {
    // field of member variable
    name = 'default';
    city;
    #bsn = 123123123; // private

    constructor(name, city) {
        if (new.target === Person) {
            throw new Error("abstract classes can't be instantiated")
        }
        this.name = name;
        this.city = city;
    }


    toon() {
        console.log(this.name + " " + this.city + " " + this.#bsn);
    }

    static create(name, city) {
        return new Person(name, city); 
    }

}

class Employee extends Person {
    constructor(name, city, afdeling) {
        super(name, city);
        this.afdeling = afdeling;
    }

    toon() {
        console.log(this.name + " " + this.city +  " "  + this.afdeling);
    }
}

const person = new Employee('Bas', "oldenzaal" ,"HR")
person.toon();

// let person2 = Person.create('Chiel', 'Helsinki')
// person2.toon()


