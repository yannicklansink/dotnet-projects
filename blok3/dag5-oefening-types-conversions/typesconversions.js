let watch = {
    model: 'ABC123',      
    color: 'silver',       
    isInStock: true,      
    price: 199.99,
    get fullName() {
        return `${this.model} in the color: ${this.color}`
    },
    set fullName(value) {
        let parts = value.split(" in the color: ");
        this.model = parts[0];
        this.color = parts[1];
    },
    toString: function() {
        return `Watch Model: ${this.model}\nColor: ${this.color}\nIn Stock: ${this.isInStock}\nPrice: ${this.price}`;
    },
};

const jsonValue = '{"discount":"20"}';
const discount = JSON.parse(jsonValue)

console.log(discount)

const discountPercentage = parseFloat(discount.discount);

console.log(discountPercentage)

// formatter
const formattedDiscount = (discountPercentage / 100).toLocaleString(undefined, { style: 'percent', minimumFractionDigits: 2 });


console.log(formattedDiscount)


// puzzle
let falseValues = [false, 0, NaN, null, undefined, ""];

for (let i = 0; i < falseValues.length; i++) {
  let x = falseValues[i];
  console.log(`For x = ${x}, +!x === 1 is ${+!x === 1}`);
}


console.log("--------------------------")
// array
const primes = [2, 3, 5, 6, 11, 13, 17];
console.log(...primes); // spread
console.log(primes.reduce((accumulator, nextElem) => accumulator + nextElem));
// reduce method of the array, which takes a function as a parameter and 
// applies this function across the array in 
// a way that it reduces the array to a single value. 

const aanbestedingen = [
    { code: 'ZP', burgernr: 23 },
    { code: 'ND', burgernr: 772 },
    { code: 'PS', burgernr: 45 },
    { code: 'AW', burgernr: 11 },
];

const res1 = aanbestedingen.map(o => o.code).sort();
console.log(res1);




