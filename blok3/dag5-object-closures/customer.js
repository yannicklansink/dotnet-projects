
function createCustomer(id, name, city, nrOfUnpaidBills = 0) {
    // let nrOfUnpaidBills = 0;
    return {
        id,
        name,
        city,
        nrOfUnpaidBills() {
            return nrOfUnpaidBills;
        },
        buyStuff() {
            nrOfUnpaidBills++;
        },
        payBill() {
            nrOfUnpaidBills--;
        },
        toString() {
            return `id: ${this.id}\nname: ${this.name}\ncity: ${this.city}`;
        },
        badPlayer(numberObject) {
            if (nrOfUnpaidBills >= numberObject.number) {
                return true;
            }
            return false;
        } 
    }
}

const customer = createCustomer(1, 'Chiel', 'Paramaribo');
customer.buyStuff();
customer.buyStuff();
console.log("customers number of unpaid bills " + customer.nrOfUnpaidBills());
console.log("customers details: \n" + customer);
console.log("is the customers bad? " + customer.badPlayer({number: 2}))



