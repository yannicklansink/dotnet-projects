class Phone {
    brand;
    type;
    appDrawer; // other class

    constructor(brand, type, appDrawer) {
        this.brand = brand;
        this.type = type;
        this.appDrawer = appDrawer;
    }
}

class AppDrawer {

    addressBook; // other class
    calculator; // other class
    apps = [];

    constructor(addressBook, calculator) {
        this.addressBook = addressBook;
        this.calculator = calculator;
    }

    addApp(app) {
        // this.apps.push(app);
        if (app instanceof AddressBook || app instanceof Calculator) {
            this.apps.push(app);
        } else {
            console.log('Only AddressBook and Calculator apps can be added.');
        }
    }

    getApps() {
        return this.apps;
    }
}

class App {
    name;

    constructor(name) {
        this.name = name;
    }

    start() {
        console.log(`${this.name} app is started`);
    }
}

class Calculator extends App {

    constructor(name) {
        super(name);
    }

    add(a, b) {
        return a + b;
    }

    multiply(a, b) {
        return a * b;
    }

    divide(a, b) {
        if(b === 0) {
            console.log('Error: Division by zero is not allowed');
            return null;
        }
        else {
            return a / b;
        }
    }

    subtract(a, b) {
        return a - b;
    }


}

class AddressBook extends App {

    // Contact contacts[]; <- dit is zoooooveel duidelijker :)
    contacts = []; // other class

    constructor(name) {
        super(name);
    }

    addContact(contact) {
        this.contacts.push(contact);
    }

    getContacts() {
        return this.contacts;
    }

}

class Contact {
    firstName;
    surname;
    phoneNumber;

    constructor(firstName, surname, phoneNumber) {
        this.firstName = firstName;
        this.surname = surname;
        this.phoneNumber = phoneNumber;
    }
}


// test 
let contact1 = new Contact("John", "Doe", "123-456-7890");
console.log("details contact 1: " + contact1);

let contact2 = new Contact("Jane", "Smith", "098-765-4321");
console.log("details contact 2: " + contact2);

let addressBook = new AddressBook("My Address Book");
addressBook.addContact(contact1);
addressBook.addContact(contact2);

let contactsList = addressBook.getContacts();
for (const contact of contactsList) {
    console.log("contact in contact list: " + contact.firstName);
}


let calculator = new Calculator("My Calculator");
console.log("");
console.log(calculator.add(5, 3)); // should print 8
console.log(calculator.subtract(5, 3)); // should print 2
console.log(calculator.multiply(5, 3)); // should print 15
console.log(calculator.divide(5, 3)); // should print 1.6666666666666667
console.log(calculator.divide(5, 0)); // should print error
console.log("");

// TODO: verander de addApp methode, zodat er alleen een AddressBook en Calculator object kunnen worden toegevoegd
let appDrawer = new AppDrawer(addressBook, calculator);
let app1 = new App("App 1");
let app2 = new App("App 2");
// appDrawer.addApp(app1);
// appDrawer.addApp(app2);

let appList = appDrawer.getApps();
for (const app of appList) {
    console.log("app in app list: " + app.name);
}


// let phone = new Phone("Brand", "Type", appDrawer);
// console.log(phone);
