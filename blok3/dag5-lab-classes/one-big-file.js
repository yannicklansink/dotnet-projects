

class AppDrawer {

    apps = [];

    constructor(addressBook, calculator) {
        this.addApps(addressBook, calculator);
    }

    addApp(app) {
        if (app instanceof App) {
            this.apps.push(app);
        } else {
            console.log(typeof app)
            console.log('Only AddressBook and Calculator apps can be added.');
        }
    }

    addApps(...multipleApps) {
        for (const app of multipleApps) {
            if (app == undefined) {
                break;
            }
            this.addApp(app);
        }
    }

    getApps() {
        return this.apps;
    }
}

class App {
    name;

    constructor(name) {
        if (this.constructor == App) {
            throw new Error("Abstract classes can't be instantiated.");
        }
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
        if (a == undefined || b == undefined) {
            // throw new Error('Error: You must provide 2 numbers');
            console.log('Error: Division by zero is not allowed');
            return null;
        }
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

    where(filterFunction) {
        return this.contacts.filter(filterFunction);
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

let contact2 = new Contact("Jane", "Smith", "06-765-4321");
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
console.log(calculator.divide(5)); // should print error
console.log("");


let appDrawer = new AppDrawer(addressBook);
// let app1 = new App("App 1");     // can't instantiate a abstract class
appDrawer.addApp(calculator);

let appList = appDrawer.getApps();
for (const app of appList) {
    console.log("App in app list: " + app.name);
}


// let phone = new Phone("Brand", "Type", appDrawer);
// console.log(phone);


// challenge:
console.log("")
for (const c of addressBook.where(c => c.phoneNumber.includes('06'))) {
    console.log(c);
}

